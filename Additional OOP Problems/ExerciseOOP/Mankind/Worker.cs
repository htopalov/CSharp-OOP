using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private double hoursPerDay;
        public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }
        public double WeekSalary
        {
            get { return weekSalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }
        public double HoursPerDay
        {
            get { return hoursPerDay; }
            private set
            {
                if (value >= 1 && value <= 12)
                {
                    this.hoursPerDay = value;
                }
                else
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
            }
        }
        public double SalaryPerHour
        {
            get
            {
                return WeekSalary / HoursPerDay / 5;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {FirstName}");
            sb.AppendLine($"Last Name: {LastName}");
            sb.AppendLine($"Week Salary: {WeekSalary:f2}");
            sb.AppendLine($"Hours per day: {HoursPerDay:f2}");
            sb.AppendLine($"Salary per hour: {SalaryPerHour:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
