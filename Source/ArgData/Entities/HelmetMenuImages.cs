using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of helmet menu images.
    /// </summary>
    public class HelmetMenuImages
    {
        /// <summary>
        /// List of HelmetMenuImage items.
        /// </summary>
        public IList<HelmetMenuImage> Images { get; } = new List<HelmetMenuImage>();
    }

    /// <summary>
    /// A helmet image that appears in the driver selection menu.
    /// </summary>
    public class HelmetMenuImage
    {
        /// <summary>
        /// Gets or sets the pixels that make up the helmet menu image.
        /// </summary>
        public byte[] Pixels { get; set; } = new byte[0];
    }
}
