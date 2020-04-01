using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of TrackCameraCommands.
    /// </summary>
    public class TrackCameraCommandList : IList<TrackCameraCommand>
    {
        private readonly List<TrackCameraCommand> _internalList;

        /// <summary>
        /// Initializes a new instance of a TrackCameraCommandList.
        /// </summary>
        public TrackCameraCommandList()
        {
            _internalList = new List<TrackCameraCommand>();
        }

        /// <inheritdoc />
        public IEnumerator<TrackCameraCommand> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(TrackCameraCommand item)
        {
            _internalList.Add(item);
        }

        /// <inheritdoc />
        public void Clear()
        {
            _internalList.Clear();
        }

        /// <inheritdoc />
        public bool Contains(TrackCameraCommand item)
        {
            return _internalList.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(TrackCameraCommand[] array, int arrayIndex)
        {
            _internalList.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(TrackCameraCommand item)
        {
            return _internalList.Remove(item);
        }

        /// <inheritdoc />
        public int Count => _internalList.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public int IndexOf(TrackCameraCommand item)
        {
            return _internalList.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, TrackCameraCommand item)
        {
            _internalList.Insert(index, item);
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            _internalList.RemoveAt(index);
        }

        /// <inheritdoc />
        public TrackCameraCommand this[int index]
        {
            get => _internalList[index];
            set => _internalList[index] = value;
        }
    }
}
