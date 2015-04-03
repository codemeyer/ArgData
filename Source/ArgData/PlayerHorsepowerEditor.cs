using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edit horsepower values for the player.
    /// </summary>
    public class PlayerHorsepowerEditor
    {
        private readonly GpExeEditor _exeEditor;

        /// <summary>
        /// Initializes a new instance of a PlayerHorsepowerEditor.
        /// </summary>
        /// <param name="exeEditor">GpExeEditor for the file to edit.</param>
        public PlayerHorsepowerEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        /// <summary>
        /// Reads the horsepower value for the player.
        /// </summary>
        /// <returns>Player horsepower value.</returns>
        public int ReadPlayerHorsepower()
        {
            var fileReader = new FileReader(_exeEditor.ExePath);
            ushort rawHorsepower = fileReader.ReadUShort(_exeEditor.GetPlayerHorsepowerPosition());

            return (rawHorsepower - 632) / 22;  // LOL
        }

        /// <summary>
        /// Writes the horsepower value for the player. The default value is 716.
        /// </summary>
        /// <param name="horsepower">Player horsepower value.</param>
        public void WritePlayerHorsepower(int horsepower)
        {
            ushort rawHorsepower = (ushort)((horsepower * 22) + 632);

            new FileWriter(_exeEditor.ExePath).WriteUInt16(rawHorsepower, _exeEditor.GetPlayerHorsepowerPosition());
        }
    }
}
