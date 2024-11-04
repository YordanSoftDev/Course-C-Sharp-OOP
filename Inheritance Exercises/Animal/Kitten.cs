

namespace Animal
{
    public class Kitten : Cat
    {
        public override string Gender => "Female";
        public Kitten(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound() => "Meow";      
    }
}
