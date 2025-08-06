namespace LMS
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> validUsers = new Dictionary<string, string>
        {
            { "teacher1", "password1" },
            { "teacher2", "password2" },
            { "admin", "admin123" }
         };

        public Form1()
        {
            InitializeComponent();
        }
        private List<Student> students = new List<Student>();


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveTopGPA_Click(object sender, EventArgs e)
        {
            var topStudent = students.OrderByDescending(s => s.GPA).FirstOrDefault();
            if (topStudent != null)
            {
                File.WriteAllText("TopStudent.txt",
                    $"ID: {topStudent.StudentId}, Name: {topStudent.StudentFirstName} {topStudent.StudentLastName}, GPA: {topStudent.GPA}");
                MessageBox.Show("Top student saved to TopStudent.txt!");
            }
            else
            {
                MessageBox.Show("No students to save.");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (validUsers.TryGetValue(username, out string correctPassword) && password == correctPassword)
            {
                pnlLogin.Visible = false;
                pnlDashboard.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student
                {
                    StudentId = int.Parse(txtStudentId.Text),
                    StudentFirstName = txtFirstName.Text,
                    StudentLastName = txtLastName.Text,
                    GPA = double.Parse(txtGPA.Text)
                };

                students.Add(student);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                students.RemoveAt(index);
                RefreshGrid();
            }
        }
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }


    }
}
