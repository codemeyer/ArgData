namespace ArgData
{
    /// <summary>
    /// Info about the GP.EXE file version.
    /// </summary>
    public enum GpExeInfo
    {
        /// <summary>
        /// The file is of an unknown version of GP.EXE, or not a valid GP.EXE at all.
        /// </summary>
        Unknown,

        /// <summary>
        /// European 1.05.
        /// </summary>
        European105,

        /// <summary>
        /// Italian 1.05. Currently unsupported by ArgData.
        /// </summary>
        Italian105,

        /// <summary>
        /// US 1.05, World Circuit. Currently unsupported by ArgData.
        /// </summary>
        Us105
    }
}
