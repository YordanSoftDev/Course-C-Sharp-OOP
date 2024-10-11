

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid data for First name");

                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid data for Last name");

                lastName = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid data for age");

                age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
