using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a .DAT file containing a number of items, mostly images.
    /// </summary>
    public class ItemContainerFile
    {
        /// <summary>
        /// Gets the list of items.
        /// </summary>
        public IList<ItemContainerFileItem> Items { get; } = new List<ItemContainerFileItem>();
    }
}
