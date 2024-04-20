using ArgData.Entities;

namespace ArgData.Internals;

internal static class TrackCameraReader
{
    internal static TrackCameraReadingResult Read(BinaryReader reader, int startPosition)
    {
        var commands = new TrackCameraCommandList();

        reader.BaseStream.Position = startPosition;

        while (true)
        {
            byte byte1 = reader.ReadByte();
            byte byte2 = reader.ReadByte();

            if (byte1 == 255)
            {
                break;
            }

            if (byte1 >= 0x80)
            {
                byte cameraIndexFrom = (byte)(byte1 & 0x7f);

                commands.Add(new TrackCameraRangeRightSideAdjustmentCommand(cameraIndexFrom, byte2));
            }
            else
            {
                if (byte2 == 0)
                {
                    commands.Add(new DeleteTrackCameraCommand(byte1));
                }
                else
                {
                    var adjustment = byte2 & 0x7f;

                    if (adjustment != 0 && byte2 >= 0x80)
                    {
                        commands.Add(new TrackCameraAdjustmentCommand(byte1, (byte)adjustment, TrackSide.Right));
                    }
                    else
                    {
                        if (adjustment != 0)
                        {
                            // move camera with index "byte" another "byte2" feet back along the track
                            commands.Add(new TrackCameraAdjustmentCommand(byte1, byte2, TrackSide.Left));
                        }

                        if (byte2 >= 0x80)
                        {
                            commands.Add(new TrackCameraAdjustmentCommand(byte1, (byte)adjustment, TrackSide.Right));
                        }
                    }
                }
            }
        }

        return new TrackCameraReadingResult(commands, (int)reader.BaseStream.Position);
    }

    public class TrackCameraReadingResult
    {
        internal TrackCameraReadingResult(TrackCameraCommandList commands, int positionAfterReading)
        {
            CameraCommands = commands;
            PositionAfterReading = positionAfterReading;
        }

        public TrackCameraCommandList CameraCommands { get; }

        public int PositionAfterReading { get; }
    }
}