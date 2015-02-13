namespace ArgData
{
    public class PlayerHorsepowerEditor
    {
        private readonly GpExeEditor _exeEditor;

        public PlayerHorsepowerEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        public int ReadPlayerHorsepower()
        {
            var fileReader = new FileReader(_exeEditor.ExePath);
            ushort rawHorsepower = fileReader.ReadUShort(_exeEditor.GetPlayerHorsepowerPosition());

            return (rawHorsepower - 632) / 22;  // LOL
        }

        public void WritePlayerHorsepower(int horsepower)
        {
            ushort rawHorsepower = (ushort)((horsepower * 22) + 632);

            new FileWriter(_exeEditor.ExePath).WriteUInt16(rawHorsepower, _exeEditor.GetPlayerHorsepowerPosition());
        }
    }
}
