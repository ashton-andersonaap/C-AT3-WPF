using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Assessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecruitmentSystem system = new RecruitmentSystem();
        public MainWindow()
        {

            InitializeComponent();

          
        }

        


        private void button_addContractor_Click(object sender, RoutedEventArgs e)
        {
            string firstName = textBox_firstName.Text;
            string lastName = textBox_lastName.Text;

            DateTime startDate = datePicker_startDate.DisplayDate;



            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please Enter a Valid Name");
                return;
            }

            if (!float.TryParse(textBox_hourlyWage.Text, out float hourlyWage))
            {
                MessageBox.Show("Please Enter a Valid Wage");
                return;
            }

            if (startDate == null)
            {
                MessageBox.Show("Please Enter a Valid Date");
                return;
            }



            Contractor contractor = system.addContractor(firstName, lastName, startDate, hourlyWage);



            listBox_contractors.Items.Add(contractor);



            textBox_firstName.Clear();
            textBox_lastName.Clear();
            textBox_hourlyWage.Clear();
            datePicker_startDate.SelectedDate = null;

            comboBox_assigning.ItemsSource = system.getContractors();

        }

        private void button_showContractors_Click(object sender, RoutedEventArgs e)
        {
            comboBox_assigning.ItemsSource = system.getContractors();
            listBox_contractors.Items.Clear();
            List<Contractor> listof_contractors = system.getContractors();

            foreach (Contractor contractor in listof_contractors)
            { 
                listBox_contractors.Items.Add(contractor);

            }
        }

        private void button_removeContractors_Click(object sender, RoutedEventArgs e)
        {
            string firstName = textBox_firstName.Text;
            string lastName = textBox_lastName.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please Enter a Valid Name");
                return;
            }

            system.removeContractor(firstName, lastName);
            MessageBox.Show($"Contractor {firstName} {lastName} has been removed");

            listBox_contractors.Items.Clear();
            List<Contractor> listof_contractors = system.getContractors();
            foreach (Contractor contractor in listof_contractors)
            {
                listBox_contractors.Items.Add(contractor);

            }
            comboBox_assigning.ItemsSource = system.getContractors();

        }

        private void button_addJob_Click(object sender, RoutedEventArgs e)
        {
            string title = textBox_jobTitle.Text;
            DateTime date = datePicker_jobDate.DisplayDate;
            bool completed = false;

            if (date == null)
            {
                MessageBox.Show("Please Enter a Valid Date");
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please Enter a Valid Title");
                return;
            }
            if (!float.TryParse(textBox_jobCost.Text, out float cost))
            {
                MessageBox.Show("Please Enter a Valid Cost");
                return;
            }
            if (comboBox_completed.Text.Length == 3)
            {
                completed = true;
            }
            else
            {
                completed = false;
            }
            Contractor contractorAssigned = comboBox_assigning.SelectedItem as Contractor;


                Job job = system.addJob(title, date, cost, completed, contractorAssigned);
            listbox_jobs.Items.Add(job);

            textBox_jobTitle.Clear();
            datePicker_jobDate.SelectedDate = null;
            comboBox_completed.SelectedIndex = -1;
            comboBox_assigning.SelectedIndex = -1;  
            textBox_jobCost.Clear();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listbox_jobs.Items.Clear();
            List<Job> jobs = system.getJobs();

            foreach (Job job in jobs)
            {
                listbox_jobs.Items.Add(job);
            }
        }

        private void button_getJob_Click(object sender, RoutedEventArgs e)
        {
            listbox_jobs.Items.Clear();
            List<Job> jobs = system.getJobs();

            string searchText = textBox_jobTitle.Text.Trim().ToLower();
            string costText = textBox_jobCost.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                jobs = jobs.Where(j => j.Title != null && j.Title.ToLower().Contains(searchText)).ToList();
                
            }

            if (double.TryParse(costText, out double cost))
            {
                jobs = jobs.Where(j => j.Cost == cost).ToList();
                
            
            }

            if (jobs.Count > 0)
            {
                foreach (Job job in jobs)
                {
                    listbox_jobs.Items.Add(job);
                }

            }
            else
            {
                listbox_jobs.Items.Add("No Jobs Found Matching Your Filters.");
            }




        }

        private void button_showAvailablecontractors_Click(object sender, RoutedEventArgs e)
        {
            listBox_contractors.Items.Clear();
            List<Contractor> availableContractors = system.getAvailablecontractors();
            foreach (Contractor contractor in availableContractors)
            {
                listBox_contractors.Items.Add(contractor);
            }
        }

        private void button_showUnassignedjobs_Click(object sender, RoutedEventArgs e)
        {
            listbox_jobs.Items.Clear();
            List<Job> unassignedJobs = system.getUnassignedjobs();
            foreach (Job job in unassignedJobs)
            {
                listbox_jobs.Items.Add(job);
            }
        }
    }
}