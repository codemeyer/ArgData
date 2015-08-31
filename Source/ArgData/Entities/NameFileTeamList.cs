using System;
using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of 20 teams to be saved to a name file.
    /// </summary>
    public class NameFileTeamList : IReadOnlyList<Team>
    {
        private readonly List<Team> _teams;

        /// <summary>
        /// Initializes a new instance of NameFileTeamList.
        /// </summary>
        public NameFileTeamList()
        {
            _teams = new List<Team>();
            for (int i = 1; i <= 20; i++)
            {
                _teams.Add(new Team
                {
                    Name = $"Team {i}",
                    Engine = $"Engine {i}"
                });
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Team> GetEnumerator()
        {
            return _teams.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <returns>
        /// The number of elements in the collection.
        /// </returns>
        public int Count => _teams.Count;

        /// <summary>
        /// Gets the element at the specified index in the read-only list.
        /// </summary>
        /// <returns>
        /// The element at the specified index in the read-only list.
        /// </returns>
        /// <param name="index">The zero-based index of the element to get.</param>
        public Team this[int index]
        {
            get
            {
                if (index < 0 || index > 19)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 19");
                }
                return _teams[index];
            }
        }
    }
}
