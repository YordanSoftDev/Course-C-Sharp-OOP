using FoodShortage.Мodels.Interfaces;
using System;

namespace FoodShortage.Мodels
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        private const int InitialFood = 0;
        private const int DefaultValueIncreasingFood = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = InitialFood;
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The name cannot be empty.");
                if (char.IsLower(value[0]))
                    throw new ArgumentNullException("The name cannot start with a lowercase letter.");

                this.name = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                    throw new ArgumentNullException("The age cannot be negative.");

                this.age = value;
            }
        }
        public string Group
        {
            get => group;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The group's name cannot be empty.");
                if (char.IsLower(value[0]))
                    throw new ArgumentNullException("The group's name cannot start with a lowercase letter.");
                group = value;
            }
        }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += DefaultValueIncreasingFood;
        }
    }
}
