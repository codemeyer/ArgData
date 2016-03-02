using System;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads driver helmet colors.
    /// </summary>
    public class HelmetColorReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a HelmetColorReader.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read to.</param>
        public HelmetColorReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the colors of all the helmets in the file.
        /// </summary>
        /// <returns>HelmetList object with the colors of all the helmets.</returns>
        public HelmetList ReadHelmetColors()
        {
            var list = new HelmetList();

            for (int i = 0; i < Constants.NumberOfDrivers; i++)
            {
                byte[] helmetBytes = new FileReader(_exeFile.ExePath)
                    .ReadBytes(_exeFile.GetHelmetColorsPosition(i),
                        _exeFile.GetHelmetColorsPositionByteCountToRead(i));

                list.GetByDriverNumber(Convert.ToByte(i + 1)).SetColors(helmetBytes);
            }

            return list;
        }
    }

    /// <summary>
    /// Writes driver helmet colors.
    /// </summary>
    public class HelmetColorWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a HelmetColorWriter.
        /// </summary>
        /// <param name="exeFile">GpExeFile to write to.</param>
        public HelmetColorWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes the colors of all the helmets in the file.
        /// </summary>
        /// <param name="helmetList">HelmetList.</param>
        public void WriteHelmetColors(HelmetList helmetList)
        {
            int helmetIndex = 0;

            foreach (Helmet helmet in helmetList)
            {
                byte[] helmetBytes = helmet.GetColorsToWriteToFile(helmetIndex);
                int position = _exeFile.GetHelmetColorsPosition(helmetIndex);

                new FileWriter(_exeFile.ExePath).WriteBytes(helmetBytes, position);

                helmetIndex++;
            }
        }
    }
}
