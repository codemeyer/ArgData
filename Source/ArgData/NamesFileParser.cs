using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgData
{
    public class NamesFileParser
    {
        private const int DriverNameLength = 24;
        private const int TeamNameLength = 13;

        public NamesFile Parse(byte[] nameData)
        {
            var data = new NamesFile();

            data.Drivers = ParseDrivers(nameData);
            data.Teams = ParseTeams(nameData);

            return data;
        }

        private List<Driver> ParseDrivers(byte[] nameData)
        {
            var drivers = new List<Driver>();

            for (int driverIndex = 0; driverIndex <= 35; driverIndex++)
            {
                int position = driverIndex * DriverNameLength;
                var name = GetNameAtPosition(nameData, position);

                drivers.Add(new Driver { Name = name });
            }

            return drivers;
        }

        private List<Team> ParseTeams(byte[] nameData)
        {
            var teams = new List<Team>();

            for (int teamIndex = 0; teamIndex <= 17; teamIndex++)
            {
                int position = 960 + (teamIndex * TeamNameLength);
                string name = GetNameAtPosition(nameData, position);

                int enginePosition = position + 260;
                string engine = GetNameAtPosition(nameData, enginePosition);

                var team = new Team
                {
                    Name = name,
                    Engine = engine
                };
                teams.Add(team);
            }

            return teams;
        }

        private static string GetNameAtPosition(byte[] nameData, int position)
        {
            byte[] nameBytes = nameData.Skip(position).TakeWhile(b => b != 0).ToArray();
            string name = Encoding.ASCII.GetString(nameBytes);

            return name;
        }
    }
}