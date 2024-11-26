namespace BirthdayCelebrations.Мodels.Interfaces
{
    public class Citizen : IIdentifiable, IBirthable
    {
        private string resident;
        private string name;
        private int age;
        private double id;
        private DateTime birthdate;
        private List<double> fakeIdentities;
        private List<DateTime> yearsOfBirth;

        public Citizen(string resident, string name, int age, double id, DateTime birthdate)
        {
            this.Resident = resident;
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.fakeIdentities = new();
            this.yearsOfBirth = new();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The name cannot be empty.");

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                    throw new ArgumentNullException("The age cannot be negative.");

                this.age = value;
            }
        }
        public double Id
        {
            get => this.id;
            set => this.id = value;
        }
        public DateTime Birthdate
        {
            get { return this.birthdate; }
            private set
            {
                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException("Birthdate cannot be in the future.");

                this.birthdate = value;
            }
        }
        public string Resident
        {
            get => this.resident;
            set
            {
                if (value != "Citizen")
                    throw new ArgumentException("Wrong type of resident.");

                this.resident = value;
            }
        }

        public IReadOnlyCollection<double> FakeIdentities => fakeIdentities.AsReadOnly();
        public IReadOnlyCollection<DateTime> YearsOfBirth => yearsOfBirth.AsReadOnly();


        public List<double> ValidateId(List<IIdentifiable> ids, string fakeId)
        {
            foreach (IIdentifiable person in ids)
            {
                string idToString = person.Id.ToString();

                if (idToString.EndsWith(fakeId))
                    fakeIdentities.Add(person.Id);
            }

            return fakeIdentities;
        }
        public List<DateTime> FindBirthdatesByYears(List<IBirthable> citizens, int yearOfBirth)
        {
            foreach (IBirthable citizen in citizens)
            {
                if(citizen.Birthdate.Year == yearOfBirth)
                    yearsOfBirth.Add(citizen.Birthdate);
            }

            return yearsOfBirth;
        }

    }
}
