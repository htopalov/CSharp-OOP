﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
                }
                this.lastName = value;
            }
        }
    }
}

