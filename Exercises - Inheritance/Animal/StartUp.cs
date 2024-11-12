

using System.Text;

namespace Animal
{
    public class StartUp
    {
        static void Main()
        {
            string animalType = "";
            StringBuilder sb = new();
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];
                try
                {
                    if (animalType == "Dog")
                    {
                        Dog dog = new(name, age, gender);
                        PrintAnimal(animalType, dog);
                    }
                    else if (animalType == "Cat")
                    {
                        Cat cat = new(name, age, gender);
                        PrintAnimal(animalType, cat);
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new(name, age, gender);
                        PrintAnimal(animalType, frog);
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new(name, age, gender);
                        PrintAnimal(animalType, tomcat);
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new(name, age, gender);
                        PrintAnimal(animalType, kitten);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void PrintAnimal<T>(string animalType, T animal) where T : Animal
        {
            Console.WriteLine(animal.ToString());
        }
    }
}
