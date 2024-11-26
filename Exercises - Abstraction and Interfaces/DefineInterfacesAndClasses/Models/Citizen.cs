using DefineInterfacesAndClasses.Models.Interfaces;

namespace DefineInterfacesAndClasses.Models
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private int id;
        private DateTime birthdate;

        public Citizen(string name, int age, int id, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The name cannot be empty.");

                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Age cannot be zero or negative.");

                age = value;
            }
        }

        public int Id
        {
            get { return id; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Id cannot be zero or negative.");

                id = value;
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
    }
}
