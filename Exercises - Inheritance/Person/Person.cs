

namespace Person
{
    public class Person

    {
        private int age;

        private string name;
        public Person(string name, int age)

        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public virtual int Age

        {
            get { return age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Age must be positive!");

                age = value;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} -> Name: {this.Name}, Age: {this.Age}";
        }
    }
}


