using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomException
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName,string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty or null");
                }
                else if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("Name can contain only letters");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty or null");
                }
                else if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("Name can contain only letters");
                }
                this.lastName = value;
            }
        }
        public int Age 
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value <0 || value > 120)
                {
                    throw new IndexOutOfRangeException("Age should be between 0 and 120");
                }
                this.age = value;
            }
        }
    }
}
