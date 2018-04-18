using ArgData.Internals;

namespace ArgData.Entities
{
    /// <summary>
    /// Track command that adds features to the track section it belongs to.
    /// </summary>
    public class TrackCommand
    {
        /// <summary>
        /// Initializes a new TrackCommand.
        /// </summary>
        /// <param name="command">Command type.</param>
        public static TrackCommand Create(byte command)
        {
            return TrackCommandFactory.Create(command);
        }

        internal TrackCommand(byte command, short[] arguments)
        {
            Command = command;
            Arguments = arguments;
        }

        /// <summary>
        /// Gets the command type.
        /// </summary>
        public byte Command { get; }

        /// <summary>
        /// Gets the list of arguments.
        /// </summary>
        public short[] Arguments { get; }
    }
}
