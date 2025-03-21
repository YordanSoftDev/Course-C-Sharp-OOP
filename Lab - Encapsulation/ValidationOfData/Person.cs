﻿

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName; 
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid data for First Name");
                else if (value.Length < 3)
                    throw new ArgumentException("First Name cannot contain fewer than 3 symbols!");

                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid data for Last Name");
                else if (value.Length < 3)
                    throw new ArgumentException("Last Name cannot contain fewer than 3 symbols!");
                

                lastName = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Age cannot be zero or negative");

                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value < 650)
                    throw new ArgumentException("Salary cannot be less than 650 leva!");

                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age > 30)
            {
                Salary += Salary * percentage / 100;
            }
            else
            {
                Salary += Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {Salary:f2} leva.";
        }
    }
}
