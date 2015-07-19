using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits the helmet colors.
    /// </summary>
    public class HelmetEditor
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a HelmetEditor.
        /// </summary>
        /// <param name="exeFile">GpExeFile to edit.</param>
        public HelmetEditor(GpExeFile exeFile)
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

            for (int i = 0; i < 40; i++)
            {
                byte[] helmetBytes = new FileReader(_exeFile.ExePath)
                    .ReadBytes(_exeFile.GetHelmetColorsPosition(i),
                        _exeFile.GetHelmetColorsPositionByteCountToRead(i));

                list[i].SetColors(helmetBytes);
            }

            return list;
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
