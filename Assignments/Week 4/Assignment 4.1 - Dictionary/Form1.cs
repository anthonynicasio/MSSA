using System.Drawing.Text;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        private PersonDirectory directory = new PersonDirectory();

        public Form1()
        {
            InitializeComponent();
            var capitals = new Dictionary<string, string>();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtMobileNumber.Text) ||
                string.IsNullOrWhiteSpace(txtWorkPhone.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Person person = new Person
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAddress.Text,
                MobilePhone = txtMobileNumber.Text,
                WorkPhone = txtWorkPhone.Text,
            };

            string fullName = $"{txtFirstName.Text} {txtLastName.Text}".Trim();
            directory.AddPerson(fullName, person);
            dataGridViewPeople.DataSource = null;
            dataGridViewPeople.DataSource = directory.GetAllPeople();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtMobileNumber.Clear();
            txtSearch.Clear();
            txtWorkPhone.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchName)) {
                MessageBox.Show("Please enter a name to search.");
                return;
            }
            Person person = directory.GetPerson(searchName);
            if (person == null)
            {
                MessageBox.Show("Person not found.");
                return;
            }
            MessageBox.Show($"Name: {person.FirstName} {person.LastName}\nMobile: " +
                $"{person.MobilePhone}\nWork: {person.WorkPhone}\nAddress: {person.Address}");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string fullName = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Enter a name to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {fullName}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool removed = directory.RemovePerson(fullName);

                if (removed)
                {
                    MessageBox.Show("Person deleted.");
                    dataGridViewPeople.DataSource = null;
                    dataGridViewPeople.DataSource = directory.GetAllPeople();
                }
                else
                {
                    MessageBox.Show("Delete failed. Person not found.");
                }
            }
            else
            {
                MessageBox.Show("Action cancelled.");
            }
        }

    }
}
