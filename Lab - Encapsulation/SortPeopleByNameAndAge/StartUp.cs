


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
            try
            {
                List<Person> persons = new();
                for (int i = 0; i < lines; i++)
                {
                    List<string> cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    if (cmdArgs != null)
                    {
                        Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                        persons.Add(person);
                    }
                }

                persons.OrderBy(p => p.FirstName)
                       .ThenBy(p => p.Age)
                       .ToList()
                       .ForEach(p => Console.WriteLine(p.ToString()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
