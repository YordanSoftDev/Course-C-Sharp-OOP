
using System.Text;

namespace Animal
{
    public abstract class Animal
    {
        private int age;
        private string name;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input.");
                }

                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Age cannot be negative number.");

                age = value;
            }
        }
        public virtual string Gender 
        {
            get { return gender; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input.");
                }
                gender = value;
            }
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name}, {this.Age}, {this.Gender}");
            return sb.ToString();
        }
    }
}
