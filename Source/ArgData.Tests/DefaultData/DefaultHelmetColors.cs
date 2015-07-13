using ArgData.Entities;

namespace ArgData.Tests.DefaultData
{
    public class DefaultHelmetColors
    {
        private readonly HelmetList _helmetColors;

        public DefaultHelmetColors()
        {
            _helmetColors = new HelmetList();

            _helmetColors[0] = new Helmet(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 });
        }

        public Helmet this[int index]
        {
            get { return _helmetColors[index]; }
        }
    }
}
