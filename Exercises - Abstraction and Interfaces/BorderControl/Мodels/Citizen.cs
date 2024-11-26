namespace BorderControl.Мodels.Interfaces
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private double id;
        private List<double> fakeIdentities;

        public Citizen(string name, int age, double id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.fakeIdentities = new();
        }
        public string Name
        {
            get => this.name;
            set 
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The name cannot be empty.");

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0 )
                    throw new ArgumentNullException("The age cannot be negative.");

                this.age = value;
            }
        }
        public double Id
        {
            get => this.id;
            set => this.id = value;
        }
        public IReadOnlyCollection<double> FakeIdentities => fakeIdentities.AsReadOnly();

        public List<double> ValidateId(List<IIdentifiable> ids, string fakeId)
        {
            foreach (IIdentifiable citizen in ids)
            {
                string idToString = citizen.Id.ToString();

                if (idToString.EndsWith(fakeId))
                    fakeIdentities.Add(citizen.Id);                
            }

            return fakeIdentities;
        }
    }
}
