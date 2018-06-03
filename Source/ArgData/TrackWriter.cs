﻿using System;
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

            var bestLineBytes = GetBestLineBytes(trackData.BestLineSegments);
            trackBytes.Add(bestLineBytes);

            var computerCarSetupBytes = GetComputerCarSetupBytes(trackData.ComputerCarSetup);
            trackBytes.Add(computerCarSetupBytes);
            trackBytes.Add(trackData.RawData.DataAfterSetup);

            var pitLaneSectionBytes = GetTrackSectionBytes(trackData.PitLaneSections);
            trackBytes.Add(pitLaneSectionBytes);

            trackBytes.Add(trackData.RawData.FinalData1);
            trackBytes.Add((byte)255);
            trackBytes.Add((byte)255);

            int lapCountPosition = trackData.RawData.FinalData2.Length - 6;

            trackBytes.Add(trackData.RawData.FinalData2.Take(lapCountPosition).ToArray());
            trackBytes.Add(trackData.LapCount);
            trackBytes.Add(trackData.RawData.FinalData2.Skip(lapCountPosition + 1).ToArray());

            int checksumPosition = trackBytes.Count - OffsetAdjustment;

            trackBytes.Add((byte)0);
            trackBytes.Add((byte)0);
            trackBytes.Add((byte)0);
            trackBytes.Add((byte)0);

            File.WriteAllBytes(path, trackBytes.GetBytes());

            var fileWriter = new FileWriter(path);

            fileWriter.WriteUInt16((ushort)checksumPosition, 4104);
            fileWriter.WriteUInt16((ushort)objectListPosition, 4106);
            fileWriter.WriteUInt16((ushort)trackHeaderPosition, 4108);

            ChecksumCalculator.UpdateChecksum(path);
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
            byte[] setupBytes = new byte[8];
            setupBytes[0] = (byte)(setup.FrontWing + 151);
            setupBytes[1] = (byte)(setup.RearWing + 151);
            setupBytes[2] = (byte)(setup.GearRatio1 + 151);
            setupBytes[3] = (byte)(setup.GearRatio2 + 151);
            setupBytes[4] = (byte)(setup.GearRatio3 + 151);
            setupBytes[5] = (byte)(setup.GearRatio4 + 151);
            setupBytes[6] = (byte)(setup.GearRatio5 + 151);
            setupBytes[7] = (byte)(setup.GearRatio6 + 151);

            return setupBytes;
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

        private static byte[] GetBestLineBytes(IList<TrackBestLineSegment> bestLines)
        {
            var bestLineBytes = new ByteList();

            var first = bestLines.First();

            bestLineBytes.Add((byte)first.Length);
            bestLineBytes.Add((byte)0x80);
            bestLineBytes.Add(first.Displacement);
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
    }
}