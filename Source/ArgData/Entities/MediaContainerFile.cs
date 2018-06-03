using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a .DAT file containing a number of items, mostly images.
    /// </summary>
    public class MediaContainerFile
    {
        /// <summary>
        /// Gets the list of items.
        /// </summary>
        public IList<MediaFileItem> Items { get; } = new List<MediaFileItem>();
    }
}
