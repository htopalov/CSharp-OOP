using System;
using System.Collections.Generic;
using System.Text;

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
            get
            {
                return firstName;
            }
            private set
            {
                if (value.Length > 3)
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length > 3)
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary
        {
            get
            {
                return salary;
            }
            private set
            {
                if (value > 460)
                {
                    this.salary = value;
                }
                else
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += Salary * percentage / 200;
            }
            else
            {
                Salary += Salary * percentage / 100;
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
