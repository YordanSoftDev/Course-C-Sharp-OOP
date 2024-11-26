

using Microsoft.VisualBasic;
using System.Globalization;

namespace Define_an_Interface_IPerson
{

    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int id = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            DateTime birthdate = DateTime.Parse(input);
            IPerson citizen = new Citizen(name, age, id, birthdate);
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            Console.WriteLine(citizen.Name);
            Console.WriteLine(citizen.Age);
            Console.WriteLine(citizen.Id);
            Console.WriteLine(citizen.Birthdate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
