
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Мodels;
using BirthdayCelebrations.Мodels.Interfaces;
using System.Globalization;

namespace BirthdayCelebrations.Core;
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
        IBirthable citizen = null;
        IBirthable pet = null;
        List<IBirthable> people = new();
        List<IBirthable> pets = new();
        string data = "";
        while ((data = reader.ReadLine()) != "End")
        {
            string[] tokens = data
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string typeOfResident = tokens[0];
            if (tokens.Length == 5)
            {
                string personName = tokens[1];
                int age = int.Parse(tokens[2]);
                double id = double.Parse(tokens[3]);
                DateTime birthdate = DateTime.Parse(tokens[4]);
                try
                {
                    citizen = new Citizen(typeOfResident, personName, age, id, birthdate);
                    people.Add(citizen);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (tokens.Length == 3 && typeOfResident == "Pet")
            {
                string petName = tokens[1];
                DateTime petBirthdate = DateTime.Parse(tokens[2]);
                try
                {
                    pet = new Pet(typeOfResident, petName, petBirthdate);
                    pets.Add(pet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        int yearOfBirth = int.Parse(Console.ReadLine());

        if (people.Count > 0)
        {
            List<DateTime> birthdates = citizen.FindBirthdatesByYears(people, yearOfBirth);
            List<string> formattedBirthdates = birthdates.Select(date => date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
            writer.WriteLine(string.Join("\n", formattedBirthdates));
        }
        if (pets.Count > 0)
        {
            List<DateTime> birthdates = pet.FindBirthdatesByYears(pets, yearOfBirth);
            List<string> formattedBirthdates = birthdates.Select(date => date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
            writer.WriteLine(string.Join("\n", formattedBirthdates));
        }

        if(people.Count == 0 && pets.Count == 0)
            writer.WriteLine("<empty output>");
    }
}