using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// A list of SavedGameDrivers.
    /// </summary>
    public class SavedGameDriverList : ReadOnlyList<SavedGameDriver>
    {
        internal SavedGameDriverList(IList<SavedGameDriver> items) : base(items)
        {
        }
    }
}
