


namespace Define_an_Interface_IPerson
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private int id;
        private DateTime birthdate;

        public Citizen(string name, int age, int id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The name cannot be empty.");

                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Age cannot be zero or negative.");

                this.age = value;
            }
        }

        public int Id
        {
            get { return this.id; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Id cannot be zero or negative.");

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
    }
}
