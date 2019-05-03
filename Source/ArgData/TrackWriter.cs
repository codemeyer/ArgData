using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgData.Entities;
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

            trackBytes.Add(trackData.Horizon.GetBytes());

            trackBytes.Add(trackData.Offsets.UnknownLong1);
            trackBytes.Add(trackData.Offsets.UnknownLong2);
            trackBytes.Add(Convert.ToInt16(trackData.Offsets.ChecksumPosition - OffsetAdjustment));
            trackBytes.Add(Convert.ToInt16(trackData.Offsets.ObjectData - OffsetAdjustment));
            trackBytes.Add(Convert.ToInt16(trackData.Offsets.TrackData - OffsetAdjustment));

            var trackInternalObjectBytes = GetInternalObjectBytes(trackData.ObjectShapes);
            trackBytes.Add(trackInternalObjectBytes);

            int objectListPosition = trackBytes.Count - OffsetAdjustment;

            var trackObjectBytes = GetTrackObjectBytes(trackData.ObjectSettings);
            trackBytes.Add(trackObjectBytes);

            int trackHeaderPosition = trackBytes.Count - OffsetAdjustment;

            var trackDataHeaderBytes = GetTrackDataHeaderBytes(trackData.TrackDataHeader);
            trackBytes.Add(trackDataHeaderBytes);

            var trackSectionBytes = GetTrackSectionBytes(trackData.TrackSections);
            trackBytes.Add(trackSectionBytes);

            var bestLineBytes = GetBestLineBytes(trackData.BestLineDisplacement, trackData.BestLineSegments);
            trackBytes.Add(bestLineBytes);

            var computerCarSetupBytes = GetComputerCarSetupBytes(trackData.ComputerCarSetup);
            trackBytes.Add(computerCarSetupBytes);

            var computerCarDataBytes = GetComputerCarDataBytes(trackData.ComputerCarData);
            trackBytes.Add(computerCarDataBytes);

            var pitLaneSectionBytes = GetTrackSectionBytes(trackData.PitLaneSections);
            trackBytes.Add(pitLaneSectionBytes);

            var cameraBytes = GetTrackCameraBytes(trackData.TrackCameraCommands);
            trackBytes.Add(cameraBytes);

            var behaviorBytes = GetComputerCarBehaviorBytes(trackData.ComputerCarBehavior);
            trackBytes.Add(behaviorBytes);

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

            bytes.Add((short)objectShapes.Count);

            foreach (var of in offsets)
            {
                bytes.Add(of);
            }

            foreach (var shape in objectShapes.OrderBy(o => o.DataIndex))
            {
                var shapeData = GetObjectShapeData(shape);

                bytes.Add(shapeData);
            }

            return bytes.GetBytes();
        }

        private static void UpdateShapeDataOffsets(TrackObjectShape shapeData, int startPoint)
        {
            int offset1 = startPoint + 30 + shapeData.HeaderValue6.Length;
            int offset2 = offset1 + shapeData.OffsetData1.Length;
            int offset3 = offset2 + shapeData.OffsetData2.Length;
            int offset4 = offset3 + shapeData.OffsetData3.Length;
            int offset5 = offset4 + shapeData.OffsetData4.Length;

            shapeData.Offset1 = (short)offset1;
            shapeData.Offset2 = (short)offset2;
            shapeData.Offset3 = (short)offset3;
            shapeData.Offset4 = (short)offset4;
            shapeData.Offset5 = (short)offset5;
        }

        private static byte[] GetObjectShapeData(TrackObjectShape shapeData)
        {
            var bytes = new ByteList();
            bytes.Add(shapeData.HeaderValue1);
            bytes.Add(shapeData.Offset1);
            bytes.Add(shapeData.HeaderValue2);
            bytes.Add(shapeData.Offset2);
            bytes.Add(shapeData.HeaderValue3);
            bytes.Add(shapeData.Offset3);
            bytes.Add(shapeData.HeaderValue4);
            bytes.Add(shapeData.Offset4);
            bytes.Add(shapeData.HeaderValue5);
            bytes.Add(shapeData.Offset5);
            bytes.Add(shapeData.HeaderValue6);
            bytes.Add(shapeData.OffsetData1);
            bytes.Add(shapeData.OffsetData2);
            bytes.Add(shapeData.OffsetData3);
            bytes.Add(shapeData.OffsetData4);
            bytes.Add(shapeData.OffsetData5);

            return bytes.GetBytes();
        }

        private static byte[] GetTrackObjectBytes(IEnumerable<TrackObjectSettings> trackObjects)
        {
            var bytes = new ByteList();

            foreach (var trackObject in trackObjects)
            {
                bytes.Add(trackObject.Id);
                bytes.Add(trackObject.DetailLevel);
                bytes.Add(trackObject.Unknown);
                bytes.Add(trackObject.DistanceFromTrack);
                bytes.Add(trackObject.AngleX);
                bytes.Add(trackObject.AngleY);
                bytes.Add(trackObject.Unknown2);
                bytes.Add(trackObject.Height);
                bytes.Add(trackObject.Id2);
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

        private static byte[] GetComputerCarDataBytes(ComputerCarData data)
        {
            var dataBytes = new ByteList();

            dataBytes.Add(data.GripFactor);
            dataBytes.Add(data.ComputerCarLateBrakingFactorNonRace);
            dataBytes.Add(data.ComputerCarLateBrakingFactorRace);
            dataBytes.Add(data.TimeFactorNonRace);
            dataBytes.Add(data.Acceleration);
            dataBytes.Add(data.AirResistance);
            dataBytes.Add(data.TyreWearQualifying);
            dataBytes.Add(data.TyreWearNonQualifying);
            dataBytes.Add(data.FuelLoad);
            dataBytes.Add(data.TimeFactorRace);
            dataBytes.Add(data.ComputerCarPowerFactor);
            dataBytes.Add(data.ComputerCarLateBrakingFactorWetRace);
            dataBytes.Add(data.UnknownTrackDistance);
            dataBytes.Add(data.DefaultPitLaneViewDistance);

            return dataBytes.GetBytes();
        }

        private static byte[] GetTrackCameraBytes(TrackCameraCommandList cameraCommands)
        {
            var bytes = new ByteList();

            foreach (var command in cameraCommands)
            {
                if (command is TrackCameraAdjustmentCommand adjustmentCommand)
                {
                    bytes.Add(adjustmentCommand.CameraIndex);

                    if (adjustmentCommand.TrackSide == TrackSide.Left)
                    {
                        bytes.Add(adjustmentCommand.Adjustment);
                    }
                    else
                    {
                        var byte2 = adjustmentCommand.Adjustment + 0x80;
                        bytes.Add((byte)byte2);
                    }
                }

                if (command is TrackCameraRangeRightSideAdjustmentCommand rangeAdjustmentCommand)
                {
                    var byte1 = rangeAdjustmentCommand.CameraIndexFrom - 0x80;
                    bytes.Add((byte)byte1);
                    bytes.Add(rangeAdjustmentCommand.CameraIndexTo);
                }

                if (command is DeleteTrackCameraCommand deleteCommand)
                {
                    bytes.Add((byte)deleteCommand.CameraIndex);
                    bytes.Add((byte)0);
                }
            }

            bytes.Add((byte)255);
            bytes.Add((byte)255);

            return bytes.GetBytes();
        }

        private static byte[] GetComputerCarBehaviorBytes(ComputerCarBehavior behavior)
        {
            var bytes = new ByteList();

            bytes.Add(behavior.UnknownData);
            bytes.Add(behavior.FormationLength);
            bytes.Add(behavior.LapTimeIndication);
            bytes.Add(behavior.LapCount);
            bytes.Add(behavior.StrategyFirstPitStopLap);
            bytes.Add(behavior.StrategyChance);

            return bytes.GetBytes();
        }

        private static byte[] GetTrackDataHeaderBytes(TrackSectionHeader trackDataHeader)
        {
            var header = new ByteList();

            header.Add(trackDataHeader.FirstSectionAngle);
            header.Add(trackDataHeader.FirstSectionHeight);
            header.Add(trackDataHeader.TrackCenterX);
            header.Add(trackDataHeader.TrackCenterZ);
            header.Add(trackDataHeader.TrackCenterY);

            header.Add(trackDataHeader.StartWidth);

            short poleSideValue = trackDataHeader.PoleSide == TrackSide.Left ? (short)-768 : (short)768;
            header.Add(poleSideValue);

            byte pitsSideValue = trackDataHeader.PitsSide == TrackSide.Left ? (byte)10 : (byte)0;
            header.Add(pitsSideValue);

            header.Add((byte)trackDataHeader.SurroundingArea);

            header.Add(trackDataHeader.RightVergeStartWidth);
            header.Add(trackDataHeader.LeftVergeStartWidth);

            if (trackDataHeader.KerbType == KerbType.DualColor)
            {
                header.Add(new byte[] { 3, 0, 8, 0, trackDataHeader.KerbUpperColor, 0, trackDataHeader.KerbLowerColor, 0, 8, 0 });
            }
            else
            {
                header.Add(new byte[] { 4, 0, 8, 0, trackDataHeader.KerbUpperColor, 0, trackDataHeader.KerbLowerColor, 0, 8, 0,
                    trackDataHeader.KerbUpperColor2, 0, trackDataHeader.KerbLowerColor2, 0 });
            }

            return header.GetBytes();
        }

        private static byte[] GetTrackSectionBytes(IEnumerable<TrackSection> sections)
        {
            var sectionBytes = new ByteList();

            foreach (var section in sections)
            {
                foreach (var command in section.Commands)
                {
                    if (command.Arguments.Length == 0)
                    {
                        sectionBytes.Add(0);
                        sectionBytes.Add(command.Command);
                        continue;
                    }

                    if (command.Arguments.Length > 0)
                    {
                        sectionBytes.Add(Convert.ToByte(command.Arguments[0]));
                        sectionBytes.Add(command.Command);

                        for (int i = 1; i < command.Arguments.Length; i++)
                        {
                            sectionBytes.Add(command.Arguments[i]);
                        }
                    }
                }

                if (section.Length > 0)
                {
                    sectionBytes.Add((short)section.Length);
                    sectionBytes.Add(section.Curvature);
                    sectionBytes.Add(section.Height);
                    sectionBytes.Add(section.Flags);
                    sectionBytes.Add(section.RightVergeWidth);
                    sectionBytes.Add(section.LeftVergeWidth);
                }
            }

            sectionBytes.Add((byte)255);
            sectionBytes.Add((byte)255);

            return sectionBytes.GetBytes();
        }

        private static byte[] GetBestLineBytes(short displacement, IList<TrackBestLineSegment> bestLines)
        {
            var bestLineBytes = new ByteList();

            var first = bestLines.First();

            bestLineBytes.Add((byte)first.Length);
            bestLineBytes.Add((byte)0x80);
            bestLineBytes.Add(displacement);
            bestLineBytes.Add(first.Correction);
            bestLineBytes.Add(first.Radius);

            foreach (var bestLine in bestLines.Skip(1))
            {
                if (bestLine.SegmentType == TrackBestLineSegmentType.Normal)
                {
                    bestLineBytes.Add((short)bestLine.Length);
                    bestLineBytes.Add(bestLine.Correction);
                    bestLineBytes.Add(bestLine.Radius);
                }
                else if (bestLine.SegmentType == TrackBestLineSegmentType.WideRadius)
                {
                    bestLineBytes.Add((byte)bestLine.Length);
                    bestLineBytes.Add((byte)0x40);
                    bestLineBytes.Add(bestLine.Correction);
                    bestLineBytes.Add(bestLine.HighRadius);
                    bestLineBytes.Add(bestLine.LowRadius);
                }
            }

            bestLineBytes.Add((byte)0);
            bestLineBytes.Add((byte)0);

            return bestLineBytes.GetBytes();
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
