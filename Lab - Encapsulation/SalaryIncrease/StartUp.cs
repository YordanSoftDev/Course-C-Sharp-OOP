
using SalaryIncrease;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            if (lines <= 0)
            {
                Console.WriteLine("Invalid input");
            }
            List<Person> persons = new();
            try
            {
                for (int i = 0; i < lines; i++)
                {
                    List<string> cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    if (cmdArgs != null)
                    {
                        Person person = new(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                        persons.Add(person);
                    }
                }
                decimal parcentage = decimal.Parse(Console.ReadLine());
                persons.ForEach(p => p.IncreaseSalary(parcentage));
                persons.ForEach(p => Console.WriteLine(p.ToString()));                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
