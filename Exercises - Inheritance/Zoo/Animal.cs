

namespace Zoo
{
    public class Animal
    {
        private string name;
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                name = value;
            }
        }
    }
}
