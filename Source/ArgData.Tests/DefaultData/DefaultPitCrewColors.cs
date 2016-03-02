using ArgData.Entities;

namespace ArgData.Tests.DefaultData
{
    public static class DefaultPitCrewColors
    {
        private static readonly PitCrewList PitCrewColors;

        static DefaultPitCrewColors()
        {
            PitCrewColors = new PitCrewList();
            // McLaren
            PitCrewColors[0] = new PitCrew(new byte[] { 0, 1, 202, 40, 58, 43, 46, 7, 8, 205, 10, 56, 12, 13, 14, 15 });
            PitCrewColors[1] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            // Williams
            PitCrewColors[2] = new PitCrew(new byte[] { 0, 1, 202, 74, 132, 92, 56, 7, 8, 205, 10, 92, 12, 13, 14, 15 });
            PitCrewColors[3] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[4] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[5] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[6] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[7] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[8] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[9] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[10] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[11] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[12] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            // Ferrari
            PitCrewColors[13] = new PitCrew(new byte[] { 0, 1, 202, 40, 70, 110, 46, 7, 8, 205, 10, 32, 12, 13, 14, 15 });
            PitCrewColors[14] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[15] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[16] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
            PitCrewColors[17] = new PitCrew(new byte[] { 0, 1, 202, 40, 74, 43, 46, 7, 8, 205, 10, 70, 12, 13, 14, 15 });
        }

        public static PitCrew GetByIndex(int index)
        {
            return PitCrewColors[index];
        }
    }
}
