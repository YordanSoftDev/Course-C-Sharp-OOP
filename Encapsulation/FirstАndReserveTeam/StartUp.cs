﻿
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
                return;
            }

            List<Person> persons = new();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    List<string> cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                    if (cmdArgs != null)
                    {
                        Person person = new(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                        persons.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team.ToString());
        }
    }
}
