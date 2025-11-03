using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assessment
{
    //Custom Class for Contractors

    class Contractor
    {
        //Fields
        public string FirstName;
        public string LastName;
        public DateTime StartDate;
        public float HourlyWage;

        //Constructor
        public Contractor(string firstName, string lastName, DateTime startDate, float hourlyWage)
        {
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            HourlyWage = hourlyWage;
        }

        //To String
        public override string ToString()
        {
            return $"""
                {FirstName} {LastName} 
                Started: {StartDate} 
                {HourlyWage}$/hr
                """;
        }


    }
}
