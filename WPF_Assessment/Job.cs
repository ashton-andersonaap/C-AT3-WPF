using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assessment
{
    class Job
    {
        public string Title;
        public DateTime Date;
        public float Cost;
        public bool Completed;
        public Contractor ContractorAssigned;

        public Job(string title, DateTime date, float cost, bool completed, Contractor contractorAssigned) 
        {
            Title = title;
            Date = date;   
            Cost = cost;
            Completed = completed;
            ContractorAssigned = contractorAssigned;

        }

        public override string ToString()
        {
            return @$"
            Job: {Title}
            Date: {Date}
            Cost: ${Cost}
            Completed: {Completed}
            Assigned To: {ContractorAssigned}";
        }

    }
}
