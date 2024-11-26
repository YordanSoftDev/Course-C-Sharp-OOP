using BirthdayCelebrations.Мodels.Interfaces;

namespace BirthdayCelebrations.Мodels
{
    public class Pet : IBirthable
    {
        private string resident;
        private string name;
        private DateTime birthdate;
        private List<DateTime> yearsOfBirth;

        public Pet(string resident, string name, DateTime birthdate)
        {
            this.Resident = resident;
            this.Name = name;
            this.Birthdate = birthdate;
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

        public DateTime Birthdate
        {
            get { return birthdate; }
            private set
            {
                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException("Birthdate cannot be in the future.");

                birthdate = value;
            }
        }

        public string Resident
        {
            get => resident;
            set
            {
                if (value != "Pet")
                    throw new ArgumentException("Wrong type of resident.");

                resident = value;
            }
        }

        public IReadOnlyCollection<DateTime> YearsOfBirth => yearsOfBirth.AsReadOnly();
        public List<DateTime> FindBirthdatesByYears(List<IBirthable> citizens, int yearOfBirth)
        {
            foreach (IBirthable pet in citizens)
            {
                if (pet.Birthdate.Year == yearOfBirth)
                    yearsOfBirth.Add(pet.Birthdate);
            }

            return yearsOfBirth;
        }
    }
}
