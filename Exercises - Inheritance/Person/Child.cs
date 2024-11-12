

namespace Person
{
    public class Child : Person
    {
        private int age;
        private string name;
        public Child(string name, int age) : base(name, age)

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
                if (value >= 15)
                    throw new ArgumentOutOfRangeException("Age cannot be greather than 15!");

                age = value;
            }
        }
    }
}

