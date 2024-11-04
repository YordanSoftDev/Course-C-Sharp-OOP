


namespace Animal
{
    public class Tomcat : Cat
    {
        public override string Gender => "Male";
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound() => "MEOW";
    }
}
