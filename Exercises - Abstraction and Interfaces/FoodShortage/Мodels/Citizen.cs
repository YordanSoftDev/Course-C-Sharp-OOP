using System;
namespace FoodShortage.Мodels.Interfaces
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private int age;
        private double id;
        private DateTime birthdate;
        private const int InitialFood = 0;
        private const int DefaultValueIncreasingFood = 10;
        private List<double> fakeIdentities;
        private List<DateTime> yearsOfBirth;

        public Citizen(string name, int age, double id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.fakeIdentities = new();
            this.yearsOfBirth = new();
            this.Food = InitialFood;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The name cannot be empty.");
                if (char.IsLower(value[0]))
                    throw new ArgumentNullException("The group's name cannot start with a lowercase letter.");
                string[] parts = value.Split(' ');
                if (parts.Length > 2 || parts.Any(part => part.Contains(' ')))
                {
                    throw new ArgumentException("The name cannot contain multiple spaces or " +
                        "spaces within a word.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                    throw new ArgumentNullException("The age cannot be negative.");

                this.age = value;
            }
        }
        public double Id
        {
            get => this.id;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Id must be a positive number.");

                this.id = value;
            }
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

        public IReadOnlyCollection<double> FakeIdentities => fakeIdentities.AsReadOnly();
        public IReadOnlyCollection<DateTime> YearsOfBirth => yearsOfBirth.AsReadOnly();

        public int Food { get; private set; }

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
                if (citizen.Birthdate.Year == yearOfBirth)
                    yearsOfBirth.Add(citizen.Birthdate);
            }

            return yearsOfBirth;
        }

        public void BuyFood()
        {
            this.Food += DefaultValueIncreasingFood;
        }
    }
}
