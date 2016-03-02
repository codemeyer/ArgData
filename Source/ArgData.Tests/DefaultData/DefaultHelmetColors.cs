using ArgData.Entities;

namespace ArgData.Tests.DefaultData
{
    public static class DefaultHelmetColors
    {
        private static readonly HelmetList HelmetColors;

        static DefaultHelmetColors()
        {
            HelmetColors = new HelmetList();
            HelmetColors.SetByDriverNumber(1, new Helmet(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 }));
            HelmetColors.SetByDriverNumber(35, new Helmet(new byte[] { 0, 1, 63, 63, 95, 95, 6, 79, 63, 79, 79, 63, 79, 95, 63, 63 }));
        }

        public static Helmet GetByDriverNumber(byte driverNumber)
        {
            return HelmetColors.GetByDriverNumber(driverNumber);
        }
    }
}
