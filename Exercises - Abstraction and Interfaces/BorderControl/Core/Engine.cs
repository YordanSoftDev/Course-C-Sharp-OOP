using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Мodels.Interfaces;


namespace BorderControl.Core;
public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        IIdentifiable citizen = null;
        IIdentifiable robot = null;
        List<IIdentifiable> people = new();
        List<IIdentifiable> robots = new();
        string data = "";
        while ((data = reader.ReadLine()) != "End")
        {
            string[] tokens = data
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 3)
            {
                string personName = tokens[0];
                int age = int.Parse(tokens[1]);
                double id = double.Parse(tokens[2]);
                try
                {
                    citizen = new Citizen(personName, age, id);
                    people.Add(citizen);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (tokens.Length == 2)
            {
                string robotModel = tokens[0];
                double id = double.Parse(tokens[1]);
                try
                {
                    robot = new Robot(robotModel, id);
                    robots.Add(robot);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        string fakeIdNumber = Console.ReadLine();

        if (people != null)
        {
            citizen.ValidateId(people, fakeIdNumber);
            writer.WriteLine(string.Join("\n", citizen.FakeIdentities));
        }
        if (robot != null)
        {
            robot.ValidateId(robots, fakeIdNumber);
            writer.WriteLine(string.Join("\n", robot.FakeIdentities));
        }
    }
}