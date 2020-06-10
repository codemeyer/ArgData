using System;
using ArgData.Entities;

namespace ArgData
{
    /// <summary>
    /// Reads menu helmet images from an image file.
    /// </summary>
    public class HelmetMenuImagesReader
    {
        /// <summary>
        /// Reads the helmet menu image file at the specified path.
        /// </summary>
        /// <param name="path">Path to the helmet menu image file.</param>
        /// <returns>HelmetMenuImages list.</returns>
        public HelmetMenuImages Read(string path)
        {
            var container = new MediaContainerFileReader().Read(path);

            foreach (var item in container.Items)
            {
                if (item.Width != 48 || item.Height != 48)
                {
                    throw new ArgumentOutOfRangeException(nameof(path), "The specified file is not a helmet item container file.");
                }
            }

            var helmetImages = new HelmetMenuImages();

            foreach (var item in container.Items)
            {
                var helmet = new HelmetMenuImage
                {
                    Pixels = (item as ImageItem1774)?.GetPixelData()
                };

                helmetImages.Images.Add(helmet);
            }

            return helmetImages;
        }
    }

    /// <summary>
    /// Writes helmet menu images to a file.
    /// </summary>
    public class HelmetMenuImagesWriter
    {
        /// <summary>
        /// Writes helmet menu images to the specified path.
        /// </summary>
        /// <param name="path">Path to the helmet menu image file to save.</param>
        /// <param name="helmetImages">HelmetMenuImages containing helmet menu image data.</param>
        public void Write(string path, HelmetMenuImages helmetImages)
        {
            ValidateHelmetImages(helmetImages);

            var container = new MediaContainerFile();

            foreach (var helmet in helmetImages.Images)
            {
                var item = new ImageItem1774
                {
                    Width = 48,
                    Height = 48
                };
                item.SetPixelData(helmet.Pixels);

                container.Items.Add(item);
            }

            new MediaContainerFileWriter().Write(path, container);
        }

        private static void ValidateHelmetImages(HelmetMenuImages helmetImages)
        {
            foreach (var item in helmetImages.Images)
            {
                if (item.Pixels.Length != 2304)
                {
                    throw new ArgumentOutOfRangeException(nameof(helmetImages), "All helmet images must be exactly 2304 pixels.");
                }
            }
        }
    }
}
