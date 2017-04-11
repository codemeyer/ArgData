using System;
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
        public static PointsSystemReader For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new PointsSystemReader(exeFile);
        }

        private PointsSystemReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the current points system.
        /// </summary>
        /// <returns>PointsSystem.</returns>
        public PointsSystem Read()
        {
            var pointsSystem = new PointsSystem();

            int position = _exeFile.GetPointsSystemPosition();
            int lengthToRead = _exeFile.ExeInfo.IsDecompressed ? 26 : 6;

            byte[] pointsPerPosition = new FileReader(_exeFile.ExePath).ReadBytes(position, lengthToRead);

            for (int i = 0; i < lengthToRead; i++)
            {
                pointsSystem.Points[i] = pointsPerPosition[i];
            }

            return pointsSystem;
        }
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
        /// <returns>PointsSystemReader.</returns>
        public static PointsSystemWriter For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new PointsSystemWriter(exeFile);
        }

        private PointsSystemWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
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

            int position = _exeFile.GetPointsSystemPosition();

            new FileWriter(_exeFile.ExePath).WriteBytes(bytesToWrite, position);
        }
    }
}
