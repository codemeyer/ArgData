using System;
using System.IO;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads the points system.
    /// </summary>
    public class PointsSystemReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a PointsSystemReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PointsSystemReader.</returns>
        public PointsSystemReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a PointsSystemReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PointsSystemReader.</returns>
        public static PointsSystemReader For(GpExeFile exeFile)
        {
            return new PointsSystemReader(exeFile);
        }

        /// <summary>
        /// Reads the current points system.
        /// </summary>
        /// <returns>PointsSystem.</returns>
        public PointsSystem Read()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                var pointsSystem = new PointsSystem();

                reader.BaseStream.Position = _exeFile.GetPointsSystemPosition();
                int lengthToRead = _exeFile.ExeInfo.IsDecompressed ? 26 : 6;

                byte[] pointsPerPosition = reader.ReadBytes(lengthToRead);

                for (int i = 0; i < lengthToRead; i++)
                {
                    pointsSystem.Points[i] = pointsPerPosition[i];
                }

                return pointsSystem;
            }
        }
        
        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }

    /// <summary>
    /// Writes the points system.
    /// </summary>
    public class PointsSystemWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a PointsSystemWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to write to.</param>
        /// <returns>PointsSystemWriter.</returns>
        public PointsSystemWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a PointsSystemWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to write to.</param>
        /// <returns>PointsSystemWriter.</returns>
        public static PointsSystemWriter For(GpExeFile exeFile)
        {
            return new PointsSystemWriter(exeFile);
        }

        /// <summary>
        /// Writes a points system to the EXE.
        /// </summary>
        /// <param name="pointsSystem">PointsSystem to write.</param>
        public void Write(PointsSystem pointsSystem)
        {
            if (pointsSystem == null) throw new ArgumentNullException(nameof(pointsSystem));

            int lengthToWrite = _exeFile.ExeInfo.IsDecompressed ? 26 : 6;
            byte[] bytesToWrite = new byte[lengthToWrite];
            Array.Copy(pointsSystem.Points, bytesToWrite, lengthToWrite);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetPointsSystemPosition();
                writer.Write(bytesToWrite);
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
