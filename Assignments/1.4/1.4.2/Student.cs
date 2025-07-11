using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._2
{
    internal class Student
    {
        private int _studentID;
        public int StudentId
        {
            get { return _studentID; }
            set { _studentID = value; }
        }
        public string StudentFname { get; set; }
        public string StudentLname { get; set; }
        public char StudentGrade { get; set; }

        public Student(int id, string fname, string lname, char grade)
        {
            StudentId = id;
            StudentFname = fname;
            StudentLname = lname;
            StudentGrade = grade;
        }
    }
}
