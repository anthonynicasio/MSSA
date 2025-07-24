using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Students
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          //  Student student = new Student();
            List<Student> students = Student.GetStudents();
            studentBindingSource.DataSource = students;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
