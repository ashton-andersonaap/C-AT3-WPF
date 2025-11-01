using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WPF_Assessment
{
    class RecruitmentSystem
    {
        List<Contractor> contractors = new List<Contractor>();
        List<Job> jobs = new List<Job>();

        public Contractor addContractor(string firstName, string lastName, DateTime startDate, float hourlyWage)
        {
            Contractor contractor = new Contractor(firstName, lastName, startDate, hourlyWage);
            contractors.Add(contractor);

            return contractor;
        }

        public Contractor removeContractor(string firstName, string lastName)
        {
            foreach (Contractor c in contractors.ToList())
            {
                if (c.FirstName == firstName && c.LastName == lastName)
                {
                    contractors.Remove(c);
                    return c;
                }

            }
            return null;

        }

        public List<Contractor> getContractors()
        {



            return contractors;

        }

        public Job addJob(string title, DateTime date, float cost, bool completed, Contractor contractorAssigned)
        {
            Job job = new Job(title, date, cost, completed, contractorAssigned);
            jobs.Add(job);
            return job;

        }

        public List<Job> getJobs()
        {
            return jobs;
        }

        public List<Job> getJob_byCost(double cost)
        {
            List<Job> jobs = getJobs();

            return jobs.Where(j => j.Cost == cost).ToList();


        }

        public List<Contractor> getAvailablecontractors()
        {
            List<Contractor> contractors = getContractors();

            List<Job> jobs = getJobs();

            List<Contractor> assignedContractors = new List<Contractor>();

            foreach (Job job in jobs)
            {
                if (job.ContractorAssigned != null)
                {
                    assignedContractors.Add(job.ContractorAssigned);
                }
            }
            List<Contractor> availableContractors = contractors.Where(c => !jobs.Any(j => j.ContractorAssigned == c)).ToList();



            return availableContractors;



        }

        public List<Job> getUnassignedjobs()
        {
            List<Job> jobs = getJobs();

            List<Job> unassignedJobs = new List<Job>();

            foreach (Job job in jobs)
            {
                if (job.ContractorAssigned == null)
                {
                    unassignedJobs.Add(job);
                }

            }


            return unassignedJobs;
        }

        public void completeJob(Job jobTocomplete)
        {
            if (jobTocomplete != null)
            {
                jobTocomplete.Completed = true;
                jobTocomplete.ContractorAssigned = null;
            }
        }
    }
}
