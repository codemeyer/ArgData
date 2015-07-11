using ArgData.Entities;

namespace ArgData.Tests.DefaultData
{
    public class DefaultPitCrewColors
    {
        private readonly PitCrewList _pitCrewColors;

        public DefaultPitCrewColors()
        {
            _pitCrewColors = new PitCrewList();
            // McLaren
            _pitCrewColors[0] = new PitCrew(new byte[] { 0, 1, 202, 40, 58, 43, 46, 7, 8, 205, 10, 56, 12, 13, 14, 15 });
            _pitCrewColors[1] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            // Williams
            _pitCrewColors[2] = new PitCrew(new byte[] { 0, 1, 202, 74, 132, 92, 56, 7, 8, 205, 10, 92, 12, 13, 14, 15 });
            _pitCrewColors[3] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[4] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[5] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[6] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[7] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[8] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[9] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[10] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[11] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[12] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            // Ferrari
            _pitCrewColors[13] = new PitCrew(new byte[] { 0, 1, 202, 40, 70, 110, 46, 7, 8, 205, 10, 32, 12, 13, 14, 15 });
            _pitCrewColors[14] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[15] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[16] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            _pitCrewColors[17] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
        }

        public PitCrew this[int index]
        {
            get { return _pitCrewColors[index]; }
        }
    }
}
