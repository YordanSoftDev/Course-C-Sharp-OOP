

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new();
            this.reserveTeam = new();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid name");

                name = value;
            }
        }

        public IReadOnlyCollection<Person> FirstTeam { get { return this.firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return this.reserveTeam.AsReadOnly(); } }

        public override string ToString()
        {
            return $"First team has {FirstTeam.Count} players." + Environment.NewLine + 
                $"Reverse team has {ReserveTeam.Count} players.";
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
                firstTeam.Add(person);
            else
                reserveTeam.Add(person);
        }
    }
}
