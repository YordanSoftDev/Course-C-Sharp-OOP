
namespace Person
{
    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            try
            {
                if (age > 15)
                {
                    Person person = new(name, age);

                    Console.WriteLine(person);
                }
                else
                {
                    Child child = new(name, age);

                    Console.WriteLine(child);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
