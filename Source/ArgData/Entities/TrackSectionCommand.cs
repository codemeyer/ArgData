using ArgData.Internals;

namespace ArgData.Entities;

/// <summary>
/// Track section command that adds features to the track section it belongs to.
/// </summary>
public class TrackSectionCommand
{
    /// <summary>
    /// Initializes a new TrackSectionCommand.
    /// </summary>
    /// <param name="command">Command type.</param>
    public static TrackSectionCommand Create(byte command)
    {
        return TrackSectionCommandFactory.Create(command);
    }

    internal TrackSectionCommand(byte command, short[] arguments)
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