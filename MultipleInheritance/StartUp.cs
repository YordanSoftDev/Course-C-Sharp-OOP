namespace Farm
{
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new();
            Puppy puppy = new();
            puppy.Weep();
            puppy.Bark();
            dog.Eat();
        }
    }
}
