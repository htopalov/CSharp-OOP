using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facNumber;
        public Student(string firstName, string lastName, string facNumber)
            : base(firstName, lastName)
        {
            this.FacNumber = facNumber;
        }

        public string FacNumber
        {
            get { return facNumber; }
            private set
            {
                if (value.Length >= 5 && value.Length <= 10 && value.All(char.IsLetterOrDigit))
                {
                    this.facNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {FirstName}");
            sb.AppendLine($"Last Name: {LastName}");
            sb.AppendLine($"Faculty number: {FacNumber}");
            return sb.ToString();
        }
    }
}
