namespace ArgData.Entities
{
    /// <summary>
    /// Wet weather settings.
    /// </summary>
    public class WetWeatherSettings
    {
        /// <summary>
        /// Decides if there can be wet weather races at the first track, i.e. Phoenix. Default is false.
        /// </summary>
        public bool RainAtFirstTrack { get; set; }

        /// <summary>
        /// The (rough) percent chance that a race will be run under wet conditions. Default is approx. 6%.
        /// </summary>
        public byte ChanceOfRain { get; set; } = 6;
    }
}
