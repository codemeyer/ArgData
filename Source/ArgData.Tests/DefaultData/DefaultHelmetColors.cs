using ArgData.Entities;

namespace ArgData.Tests.DefaultData
{
    public class DefaultHelmetColors
    {
        private readonly HelmetList _helmetColors;

        public DefaultHelmetColors()
        {
            _helmetColors = new HelmetList();

            // Index is driver number + 1
            _helmetColors[0] = new Helmet(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 });
            _helmetColors[34]= new Helmet(new byte[] { 0, 1, 63, 63, 95, 95, 6, 79, 63, 79, 79, 63, 79, 95, 63, 63 });
        }

        public Helmet this[int index]
        {
            get { return _helmetColors[index]; }
        }
    }
}
