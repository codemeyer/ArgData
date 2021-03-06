using ArgData.Entities;

namespace ArgData.Tests.DefaultData
{
    public static class DefaultCarColors
    {
        private static readonly CarList CarColors;

        static DefaultCarColors()
        {
            CarColors = new CarList();
            CarColors[0] = new Car(new byte[] { 33, 47, 62, 44, 58, 32, 44, 47, 47, 56, 36, 46, 47, 47, 62, 47 });
            CarColors[1] = new Car(new byte[] { 33, 34, 47, 45, 56, 33, 33, 32, 47, 84, 36, 46, 46, 46, 46, 34 });
            CarColors[2] = new Car(new byte[] { 33, 110, 111, 86, 86, 84, 44, 47, 89, 36, 36, 87, 86, 86, 87, 47 });
            CarColors[3] = new Car(new byte[] { 33, 89, 87, 86, 86, 45, 86, 46, 88, 84, 36, 46, 46, 46, 46, 89 });
            CarColors[4] = new Car(new byte[] { 33, 46, 47, 45, 45, 63, 45, 47, 47, 36, 36, 46, 46, 46, 46, 47 });
            CarColors[5] = new Car(new byte[] { 33, 46, 47, 70, 70, 69, 44, 46, 47, 36, 36, 46, 46, 46, 46, 74 });
            CarColors[6] = new Car(new byte[] { 33, 36, 38, 32, 47, 35, 59, 37, 38, 47, 36, 36, 36, 36, 36, 61 });
            CarColors[7] = new Car(new byte[] { 33, 70, 231, 228, 228, 226, 228, 32, 231, 224, 36, 229, 229, 46, 46, 231 });
            CarColors[8] = new Car(new byte[] { 33, 46, 47, 44, 44, 43, 44, 32, 47, 45, 36, 46, 46, 46, 46, 47 });
            CarColors[9] = new Car(new byte[] { 33, 110, 111, 107, 86, 72, 85, 111, 75, 84, 36, 74, 110, 110, 110, 90 });
            CarColors[10] = new Car(new byte[] { 33, 62, 47, 57, 57, 56, 57, 60, 62, 52, 36, 61, 46, 46, 46, 62 });
            CarColors[11] = new Car(new byte[] { 33, 32, 33, 32, 109, 32, 32, 111, 33, 111, 34, 34, 34, 47, 110, 36 });
            CarColors[12] = new Car(new byte[] { 33, 94, 95, 32, 32, 92, 32, 95, 95, 32, 36, 94, 94, 94, 94, 95 });
            CarColors[13] = new Car(new byte[] { 33, 60, 61, 32, 32, 32, 56, 32, 61, 54, 36, 60, 60, 60, 60, 61 });
            CarColors[14] = new Car(new byte[] { 33, 32, 61, 32, 32, 32, 32, 111, 62, 32, 36, 34, 34, 60, 60, 36 });
            CarColors[15] = new Car(new byte[] { 33, 94, 40, 45, 45, 45, 45, 47, 40, 111, 36, 39, 39, 39, 39, 47 });
            CarColors[16] = new Car(new byte[] { 33, 71, 72, 70, 70, 91, 92, 72, 72, 89, 36, 71, 71, 71, 71, 72 });
            CarColors[17] = new Car(new byte[] { 33, 88, 88, 32, 32, 86, 86, 33, 88, 32, 36, 87, 87, 87, 87, 88 });
        }

        public static Car GetByIndex(int index)
        {
            return CarColors[index];
        }
    }
}
