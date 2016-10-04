using System;

namespace ArgData.Validation
{
    internal static class TeamIndexValidator
    {
        internal static void Validate(int teamIndex)
        {
            if (teamIndex < 0 || teamIndex > Constants.NumberOfSupportedTeams - 1)
                throw new ArgumentOutOfRangeException(nameof(teamIndex),
                    $"{nameof(teamIndex)} must be between 0 and {Constants.NumberOfSupportedTeams - 1}");
        }
    }
}
