namespace ArgData.Entities
{
    /// <summary>
    /// Track-side camera adjustment base class.
    /// </summary>
    public abstract class TrackCameraCommand
    {
    }

    /// <summary>
    /// A camera command that deletes a specific camera.
    /// </summary>
    public class DeleteTrackCameraCommand : TrackCameraCommand
    {
        /// <summary>
        /// Initializes an instance of a DeleteTrackCameraCommand.
        /// </summary>
        /// <param name="cameraIndex">Index of camera to delete.</param>
        public DeleteTrackCameraCommand(int cameraIndex)
        {
            CameraIndex = cameraIndex;
        }

        /// <summary>
        /// Gets or sets the index of the camera to delete.
        /// </summary>
        public int CameraIndex { get; set; }
    }

    /// <summary>
    /// A camera command that adjusts the location of the camera along the track and/or side of the track.
    /// </summary>
    public class TrackCameraAdjustmentCommand : TrackCameraCommand
    {
        /// <summary>
        /// Initializes a new instance of a TrackCameraAdjustmentCommand.
        /// </summary>
        /// <param name="cameraIndex">Index of camera to adjust.</param>
        /// <param name="adjustment">Adjustment along the track.</param>
        /// <param name="trackSide">Side of track.</param>
        public TrackCameraAdjustmentCommand(byte cameraIndex, byte adjustment, TrackSide trackSide)
        {
            CameraIndex = cameraIndex;
            Adjustment = adjustment;
            TrackSide = trackSide;
        }

        /// <summary>
        /// Gets or sets the index of the camera to adjust.
        /// </summary>
        public byte CameraIndex { get; set; }

        /// <summary>
        /// Gets or sets the amount that the camera should be moved back.
        /// </summary>
        public byte Adjustment { get; set; }

        /// <summary>
        /// Gets or sets the side of the track that the camera should be placed at.
        /// </summary>
        public TrackSide TrackSide { get; set; }
    }

    /// <summary>
    /// Camera command that moves a range of track-side cameras to the right side of the track.
    /// </summary>
    public class TrackCameraRangeRightSideAdjustmentCommand : TrackCameraCommand
    {
        /// <summary>
        /// Intializes a new instance of a TrackCameraRangeRightSideAdjustmentCommand.
        /// </summary>
        /// <param name="cameraIndexFrom">The index of the camera that is the first to adjust.</param>
        /// <param name="cameraIndexTo">The index of the camera that is the last to adjust.</param>
        public TrackCameraRangeRightSideAdjustmentCommand(byte cameraIndexFrom, byte cameraIndexTo)
        {
            CameraIndexFrom = cameraIndexFrom;
            CameraIndexTo = cameraIndexTo;
        }

        /// <summary>
        /// Gets or sets the index of the camera that is the first to adjust.
        /// </summary>
        public byte CameraIndexFrom { get; set; }

        /// <summary>
        /// Gets or sets the index of the camera that is the last to adjust.
        /// </summary>
        public byte CameraIndexTo { get; set; }
    }
}
