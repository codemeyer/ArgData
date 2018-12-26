using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class ObjectShapesReader
    {
        public static List<TrackObjectShape> Read(BinaryReader reader, short trackOffset)
        {
            short count = reader.ReadInt16();

            var offsets = new List<int>();

            // list of offsets
            for (int i = 0; i < count; i++)
            {
                int offset = reader.ReadInt32();
                offsets.Add(offset);
            }

            var objects = new List<TrackObjectShape>();

            var startPos = 4112;

            var sortedOffsets = new List<int>();
            foreach (var offset in offsets)
            {
                sortedOffsets.Add(offset);
            }

            sortedOffsets.Sort();

            // foreach offset, read data between offset location and next offset location
            for (int headerIndex = 0; headerIndex < offsets.Count; headerIndex++)
            {
                var loopOffset = offsets[headerIndex];

                int nextOffset;

                if (offsets.Any(of => of > loopOffset))
                {
                    nextOffset = offsets.Where(of => of > loopOffset).ToList().Min();
                }
                else
                {
                    nextOffset = trackOffset - startPos;
                }

                var readFrom = startPos + loopOffset;
                var lengthToRead = nextOffset - loopOffset;

                reader.BaseStream.Position = readFrom;
                //byte[] data = trackFileReader.ReadBytes(readFrom, lengthToRead);
                byte[] data = reader.ReadBytes(lengthToRead);

                var dataIndex = sortedOffsets.IndexOf(loopOffset);

                var obj = new TrackObjectShape(headerIndex, dataIndex);

                UpdateDataProperties(obj, data, readFrom);

                objects.Add(obj);
            }

            return objects;
        }

        private static void UpdateDataProperties(TrackObjectShape shapeData, byte[] data, int startPoint)
        {
            shapeData.HeaderValue1 = BitConverter.ToInt16(new[] {data[0], data[1]}, 0);
            shapeData.Offset1 = BitConverter.ToInt16(new[] { data[2], data[3] }, 0);
            shapeData.HeaderValue2 = BitConverter.ToInt16(new[] {data[4], data[5]}, 0);
            shapeData.Offset2 = BitConverter.ToInt16(new[] { data[6], data[7] }, 0);
            shapeData.HeaderValue3 = BitConverter.ToInt16(new[] {data[8], data[9]}, 0);
            shapeData.Offset3 = BitConverter.ToInt16(new[] { data[10], data[11] }, 0);
            shapeData.HeaderValue4 = BitConverter.ToInt16(new[] {data[12], data[13]}, 0);
            shapeData.Offset4 = BitConverter.ToInt16(new[] { data[14], data[15] }, 0);
            var header5 = new byte[12];
            Array.Copy(data, 16, header5, 0, 12);
            shapeData.HeaderValue5 = header5;
            shapeData.Offset5 = BitConverter.ToInt16(new[] { data[28], data[29] }, 0);

            // either 2 or (for some odd objects) 10 (which indicates that I don't have any idea
            //  what the data actually is...
            int header6Length = shapeData.Offset1 - startPoint - 30;

            var header6 = new byte[header6Length];
            Array.Copy(data, 30, header6, 0, header6Length);
            shapeData.HeaderValue6 = header6;

            int data1Start = 30 + header6Length;

            var offsetData1Length = shapeData.Offset2 - shapeData.Offset1;
            var offsetData1 = new byte[offsetData1Length];
            Array.Copy(data, data1Start, offsetData1, 0, offsetData1Length);
            shapeData.OffsetData1 = offsetData1;

            int data2Start = data1Start + offsetData1Length;
            var offsetData2Length = shapeData.Offset3 - shapeData.Offset2;
            var offsetData2 = new byte[offsetData2Length];
            Array.Copy(data, data2Start, offsetData2, 0, offsetData2Length);
            shapeData.OffsetData2 = offsetData2;

            int data3Start = data2Start + offsetData2Length;
            var offsetData3Length = shapeData.Offset4 - shapeData.Offset3;
            var offsetData3 = new byte[offsetData3Length];
            Array.Copy(data, data3Start, offsetData3, 0, offsetData3Length);
            shapeData.OffsetData3 = offsetData3;

            int data4Start = data3Start + offsetData3Length;
            var offsetData4Length = shapeData.Offset5 - shapeData.Offset4;
            var offsetData4 = new byte[offsetData4Length];
            Array.Copy(data, data4Start, offsetData4, 0, offsetData4Length);
            shapeData.OffsetData4 = offsetData4;

            int data5Start = data4Start + offsetData4Length;
            var offsetData5Length = data.Length - (data4Start + offsetData4Length);
            var offsetData5 = new byte[offsetData5Length];
            Array.Copy(data, data5Start, offsetData5, 0, offsetData5Length);
            shapeData.OffsetData5 = offsetData5;
        }
    }
}
