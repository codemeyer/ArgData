using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.Internals;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Writes a Track object to an F1GP track file.
    /// </summary>
    public class TrackWriter
    {
        private const int OffsetAdjustment = 4112;

        /// <summary>
        /// Writes the specified trackData to a file.
        /// </summary>
        /// <param name="trackData">Track data.</param>
        /// <param name="path">Path to file to create.</param>
        public void Write(Track trackData, string path)
        {
            var trackBytes = new ByteList();

            trackBytes.AddBytes(trackData.Horizon.GetBytes());

            //trackBytes.AddInt32(trackData.Offsets.UnknownLong1);
            //trackBytes.AddInt32(trackData.Offsets.UnknownLong2);
            trackBytes.AddInt16(trackData.Offsets.BaseOffset);
            trackBytes.AddInt16(trackData.Offsets.Unknown2);
            trackBytes.AddInt16(trackData.Offsets.Unknown3);
            trackBytes.AddInt16(trackData.Offsets.Unknown4);

            trackBytes.AddInt16(Convert.ToInt16(trackData.Offsets.ChecksumPosition - OffsetAdjustment));
            trackBytes.AddInt16(Convert.ToInt16(trackData.Offsets.ObjectData - OffsetAdjustment));
            trackBytes.AddInt16(Convert.ToInt16(trackData.Offsets.TrackData - OffsetAdjustment));

            var trackInternalObjectBytes = GetInternalObjectBytes(trackData.ObjectShapes);
            trackBytes.AddBytes(trackInternalObjectBytes);

            int objectListPosition = trackBytes.Count - OffsetAdjustment;

            var trackObjectBytes = GetTrackObjectBytes(trackData.ObjectSettings);
            trackBytes.AddBytes(trackObjectBytes);

            int trackHeaderPosition = trackBytes.Count - OffsetAdjustment;

            var trackDataHeaderBytes = GetTrackDataHeaderBytes(trackData.TrackDataHeader, trackData.TrackSettings);
            trackBytes.AddBytes(trackDataHeaderBytes);

            var trackSectionBytes = GetTrackSectionBytes(trackData.TrackSections);
            trackBytes.AddBytes(trackSectionBytes);

            var carLineBytes = GetComputerCarLineBytes(trackData.ComputerCarLineDisplacement, trackData.ComputerCarLineSegments);
            trackBytes.AddBytes(carLineBytes);

            var computerCarSetupBytes = GetComputerCarSetupBytes(trackData.ComputerCarSetup);
            trackBytes.AddBytes(computerCarSetupBytes);

            var carTrackSettingsPart1Bytes = GetComputerCarTrackSettingsPart1Bytes(trackData.CarSettings, trackData.ComputerCarBehavior, trackData.TrackSettings);
            trackBytes.AddBytes(carTrackSettingsPart1Bytes);

            var pitLaneSectionBytes = GetTrackSectionBytes(trackData.PitLaneSections);
            trackBytes.AddBytes(pitLaneSectionBytes);

            var cameraBytes = GetTrackCameraBytes(trackData.TrackCameraCommands);
            trackBytes.AddBytes(cameraBytes);

            var carTrackSettingsPart2Bytes = GetComputerCarTrackSettingsPart2Bytes(trackData.ComputerCarBehavior, trackData.TrackSettings);
            trackBytes.AddBytes(carTrackSettingsPart2Bytes);

            int checksumPosition = trackBytes.Count - OffsetAdjustment;

            var bytesToWrite = trackBytes.GetBytes();
            var checksumPositionBytes = BitConverter.GetBytes(checksumPosition);
            var objectListPositionBytes = BitConverter.GetBytes(objectListPosition);
            var trackHeaderPositionBytes = BitConverter.GetBytes(trackHeaderPosition);

            bytesToWrite[4104] = checksumPositionBytes[0];
            bytesToWrite[4105] = checksumPositionBytes[1];
            bytesToWrite[4106] = objectListPositionBytes[0];
            bytesToWrite[4107] = objectListPositionBytes[1];
            bytesToWrite[4108] = trackHeaderPositionBytes[0];
            bytesToWrite[4109] = trackHeaderPositionBytes[1];

            var checksum = new ChecksumCalculator().Calculate(bytesToWrite);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var writer = new BinaryWriter(StreamProvider.Invoke(path)))
            {
                writer.Write(bytesToWrite);

                writer.Write((ushort)checksum.Checksum1);
                writer.Write((ushort)checksum.Checksum2);
            }
        }

        private static byte[] GetInternalObjectBytes(IList<TrackObjectShape> objectShapes)
        {
            var offsets = new int[objectShapes.Count];

            var startoffset = objectShapes.Count * 4;

            foreach (var shape in objectShapes.OrderBy(o => o.DataIndex))
            {
                var index = objectShapes.OrderBy(o => o.DataIndex).ToList().IndexOf(shape);

                var dataUntil = objectShapes.Where(o => o.DataIndex < index).Sum(o => o.DataLength);

                var startPoint = OffsetAdjustment + startoffset + dataUntil;
                UpdateShapeDataOffsets(shape, startPoint);

                var nextOffset = startoffset + dataUntil;

                offsets[shape.HeaderIndex] = nextOffset;
            }

            var bytes = new ByteList();

            bytes.AddInt16((short)objectShapes.Count);

            foreach (var offset in offsets)
            {
                bytes.AddInt32(offset);
            }

            foreach (var shape in objectShapes.OrderBy(o => o.DataIndex))
            {
                var shapeData = GetObjectShapeData(shape);

                bytes.AddBytes(shapeData);
            }

            return bytes.GetBytes();
        }

        private static void UpdateShapeDataOffsets(TrackObjectShape shapeData, int startPoint)
        {
            int offset1 = startPoint + 32 + shapeData.HeaderData6.Length;
            int offset2 = offset1 + shapeData.ScaleValues.Count * 2;
            int offset3 = offset2 + shapeData.OffsetData2.Length;
            int offset4 = offset3 + shapeData.Points.Count * 8 + shapeData.PointsAdditionalBytes.Length;
            int offset5 = offset4 + shapeData.Vectors.Count * 2;

            shapeData.ScaleValueOffset = (short)offset1;
            shapeData.Offset2 = (short)offset2;
            shapeData.PointDataOffset = (short)offset3;
            shapeData.VectorDataOffset = (short)offset4;
            shapeData.Offset5 = (short)offset5;
        }

        private static byte[] GetObjectShapeData(TrackObjectShape shapeData)
        {
            var bytes = new ByteList();
            bytes.AddInt16(shapeData.HeaderValue1);
            bytes.AddInt16(shapeData.ScaleValueOffset);
            bytes.AddInt16(shapeData.HeaderValue2);
            bytes.AddInt16(shapeData.Offset2);
            bytes.AddInt16(shapeData.HeaderValue3);
            bytes.AddInt16(shapeData.PointDataOffset);
            bytes.AddInt16(shapeData.HeaderValue4);
            bytes.AddInt16(shapeData.VectorDataOffset);
            bytes.AddInt16(shapeData.HeaderValue5);
            bytes.AddBytes(shapeData.HeaderData5);
            bytes.AddInt16(shapeData.Offset5);
            bytes.AddInt16(shapeData.HeaderValue6);
            bytes.AddBytes(shapeData.HeaderData6);

            // ScaleValues was previously OffsetData1
            foreach (var scaleValue in shapeData.ScaleValues)
            {
                bytes.AddBytes(BitConverter.GetBytes(scaleValue));
            }

            bytes.AddBytes(shapeData.OffsetData2);

            // RawPoints/Points was previously OffsetData3
            foreach (var point in shapeData.Points)
            {
                byte[] pointBytes = point.GetBytes();

                bytes.AddBytes(pointBytes);
            }

            bytes.AddBytes(shapeData.PointsAdditionalBytes);

            // Vectors was previously OffsetData4
            foreach (var vector in shapeData.Vectors)
            {
                bytes.AddByte(vector.From);
                bytes.AddByte(vector.To);
            }

            bytes.AddBytes(shapeData.OffsetData5);

            return bytes.GetBytes();
        }

        private static byte[] GetTrackObjectBytes(IEnumerable<TrackObjectSettings> trackObjects)
        {
            var bytes = new ByteList();

            foreach (var trackObject in trackObjects)
            {
                bytes.AddByte(trackObject.Id);
                bytes.AddByte(trackObject.DetailLevel);
                bytes.AddInt16(trackObject.Unknown);
                bytes.AddInt16(trackObject.DistanceFromTrack);
                bytes.AddInt16(trackObject.AngleX);
                bytes.AddInt16(trackObject.AngleY);
                bytes.AddInt16(trackObject.Unknown2);
                bytes.AddInt16(trackObject.Height);
                bytes.AddInt16(trackObject.Id2);
            }

            return bytes.GetBytes();
        }

        private static byte[] GetComputerCarSetupBytes(Setup setup)
        {
            byte[] setupBytes = new byte[10];
            setupBytes[0] = (byte)(setup.FrontWing + 151);
            setupBytes[1] = (byte)(setup.RearWing + 151);
            setupBytes[2] = (byte)(setup.GearRatio1 + 151);
            setupBytes[3] = (byte)(setup.GearRatio2 + 151);
            setupBytes[4] = (byte)(setup.GearRatio3 + 151);
            setupBytes[5] = (byte)(setup.GearRatio4 + 151);
            setupBytes[6] = (byte)(setup.GearRatio5 + 151);
            setupBytes[7] = (byte)(setup.GearRatio6 + 151);
            setupBytes[8] = (byte)((byte)setup.TyreCompound + 52);
            setupBytes[9] = (byte)setup.BrakeBalance;

            return setupBytes;
        }

        private static byte[] GetComputerCarTrackSettingsPart1Bytes(TrackCarSettings carSettings, TrackComputerCarBehavior computerCarBehavior, TrackSettings trackSettings)
        {
            var dataBytes = new ByteList();

            dataBytes.AddInt16(carSettings.GripFactor);
            dataBytes.AddInt16(computerCarBehavior.LateBrakingFactorNonRace);
            dataBytes.AddInt16(computerCarBehavior.LateBrakingFactorRace);
            dataBytes.AddInt16(trackSettings.TimeFactorNonRace);
            dataBytes.AddInt16(carSettings.Acceleration);
            dataBytes.AddInt16(carSettings.AirResistance);
            dataBytes.AddInt16(carSettings.TyreWearQualifying);
            dataBytes.AddInt16(carSettings.TyreWearNonQualifying);
            dataBytes.AddInt16(carSettings.FuelLoad);
            dataBytes.AddInt16(trackSettings.TimeFactorRace);
            dataBytes.AddInt16(computerCarBehavior.PowerFactor);
            dataBytes.AddInt16(computerCarBehavior.LateBrakingFactorWetRace);
            dataBytes.AddInt16(trackSettings.UnknownTrackDistance);
            dataBytes.AddInt16(trackSettings.DefaultPitLaneViewDistance);

            return dataBytes.GetBytes();
        }

        private static byte[] GetTrackCameraBytes(TrackCameraCommandList cameraCommands)
        {
            var bytes = new ByteList();

            foreach (var command in cameraCommands)
            {
                if (command is TrackCameraAdjustmentCommand adjustmentCommand)
                {
                    bytes.AddByte(adjustmentCommand.CameraIndex);

                    if (adjustmentCommand.TrackSide == TrackSide.Left)
                    {
                        bytes.AddByte(adjustmentCommand.Adjustment);
                    }
                    else
                    {
                        var byte2 = adjustmentCommand.Adjustment + 0x80;
                        bytes.AddByte(byte2);
                    }
                }

                if (command is TrackCameraRangeRightSideAdjustmentCommand rangeAdjustmentCommand)
                {
                    var byte1 = rangeAdjustmentCommand.CameraIndexFrom - 0x80;
                    bytes.AddByte(byte1);
                    bytes.AddByte(rangeAdjustmentCommand.CameraIndexTo);
                }

                if (command is DeleteTrackCameraCommand deleteCommand)
                {
                    bytes.AddByte(deleteCommand.CameraIndex);
                    bytes.AddByte(0);
                }
            }

            bytes.AddByte(255);
            bytes.AddByte(255);

            return bytes.GetBytes();
        }

        private static byte[] GetComputerCarTrackSettingsPart2Bytes(TrackComputerCarBehavior computerCarBehavior, TrackSettings trackSettings)
        {
            var bytes = new ByteList();

            bytes.AddBytes(computerCarBehavior.UnknownData);
            bytes.AddInt16(computerCarBehavior.FormationLength);
            bytes.AddInt32(trackSettings.LapTimeIndication);
            bytes.AddInt16(trackSettings.LapCount);
            bytes.AddInt16(computerCarBehavior.StrategyFirstPitStopLap);
            bytes.AddInt16(computerCarBehavior.StrategyChance);

            return bytes.GetBytes();
        }

        private static byte[] GetTrackDataHeaderBytes(TrackSectionHeader trackDataHeader, TrackSettings settings)
        {
            var header = new ByteList();

            header.AddUInt16(trackDataHeader.FirstSectionAngle);
            header.AddInt16(trackDataHeader.FirstSectionHeight);
            header.AddInt16(trackDataHeader.TrackCenterX);
            header.AddInt16(trackDataHeader.TrackCenterZ);
            header.AddInt16(trackDataHeader.TrackCenterY);

            header.AddInt16(trackDataHeader.StartWidth);

            short poleSideValue = settings.PoleSide == TrackSide.Left ? (short)-768 : (short)768;
            header.AddInt16(poleSideValue);

            byte pitsSideValue = settings.PitsSide == TrackSide.Left ? (byte)10 : (byte)0;
            header.AddByte(pitsSideValue);

            header.AddByte((byte)settings.SurroundingArea);

            header.AddByte(trackDataHeader.RightVergeStartWidth);
            header.AddByte(trackDataHeader.LeftVergeStartWidth);

            if (settings.KerbType == KerbType.DualColor)
            {
                header.AddBytes(new byte[] { 3, 0, 8, 0, settings.KerbUpperColor, 0, settings.KerbLowerColor, 0, 8, 0 });
            }
            else
            {
                header.AddBytes(new byte[] { 4, 0, 8, 0, settings.KerbUpperColor, 0, settings.KerbLowerColor, 0, 8, 0,
                    settings.KerbUpperColor2, 0, settings.KerbLowerColor2, 0 });
            }

            return header.GetBytes();
        }

        private static byte[] GetTrackSectionBytes(IList<TrackSection> sections)
        {
            var sectionBytes = new ByteList();

            foreach (var section in sections)
            {
                foreach (var command in section.Commands)
                {
                    if (command.Arguments.Length == 0)
                    {
                        sectionBytes.AddByte(0);
                        sectionBytes.AddByte(command.Command);
                        continue;
                    }

                    if (command.Arguments.Length > 0)
                    {
                        sectionBytes.AddByte(command.Arguments[0]);
                        sectionBytes.AddByte(command.Command);

                        for (int i = 1; i < command.Arguments.Length; i++)
                        {
                            sectionBytes.AddInt16(command.Arguments[i]);
                        }
                    }
                }

                bool isLast = sections.IndexOf(section) == sections.Count - 1;

                if (ShouldWriteTrackSection(section.Length, isLast))
                {
                    sectionBytes.AddInt16(section.Length);
                    sectionBytes.AddInt16(section.Curvature);
                    sectionBytes.AddInt16(section.Height);
                    sectionBytes.AddInt16(section.Flags);
                    sectionBytes.AddByte(section.RightVergeWidth);
                    sectionBytes.AddByte(section.LeftVergeWidth);
                }
            }

            sectionBytes.AddByte(255);
            sectionBytes.AddByte(255);

            return sectionBytes.GetBytes();
        }

        private static bool ShouldWriteTrackSection(byte length, bool isLast)
        {
            if (length > 0)
            {
                return true;
            }

            return !isLast;
        }

        private static byte[] GetComputerCarLineBytes(short displacement, IList<TrackComputerCarLineSegment> computerCarLines)
        {
            var bytes = new ByteList();

            var first = computerCarLines.First();

            bytes.AddByte(first.Length);
            bytes.AddByte(0x80);
            bytes.AddInt16(displacement);
            bytes.AddInt16(first.Correction);
            bytes.AddInt16(first.Radius);

            foreach (var line in computerCarLines.Skip(1))
            {
                if (line.SegmentType == TrackComputerCarLineSegmentType.Normal)
                {
                    bytes.AddInt16((short)line.Length);
                    bytes.AddInt16(line.Correction);
                    bytes.AddInt16(line.Radius);
                }
                else if (line.SegmentType == TrackComputerCarLineSegmentType.WideRadius)
                {
                    bytes.AddByte(line.Length);
                    bytes.AddByte(0x40);
                    bytes.AddInt16(line.Correction);
                    bytes.AddInt16(line.HighRadius);
                    bytes.AddInt16(line.LowRadius);
                }
            }

            bytes.AddByte(0);
            bytes.AddByte(0);

            return bytes.GetBytes();
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
