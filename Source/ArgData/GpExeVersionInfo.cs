namespace ArgData
{
    /// <summary>
    /// Info about the GP.EXE file version.
    /// </summary>
    public enum GpExeVersionInfo
    {
        /// <summary>
        /// The file is of an unknown version of GP.EXE, or not a valid GP.EXE at all.
        /// </summary>
        Unknown,

        /// <summary>
        /// European 1.03. Not supported by ArgData.
        /// </summary>
        European103,

        /// <summary>
        /// European 1.05.
        /// </summary>
        European105,

        /// <summary>
        /// European 1.05, decompressed.
        /// </summary>
        European105Decompressed,

        /// <summary>
        /// US 1.03, World Circuit. Not supported by ArgData.
        /// </summary>
        Us103,

        /// <summary>
        /// US 1.05, World Circuit.
        /// </summary>
        Us105,

        /// <summary>
        /// US 1.05, World Circuit, decompressed.
        /// </summary>
        Us105Decompressed
    }
}
