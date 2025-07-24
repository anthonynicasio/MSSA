using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public enum MonthOfAdmission
    {
        January, February, March, April, May, June,
        July, August, September, October, November, December
    }

    public class Student
    {
        public string StudID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public MonthOfAdmission MonthOfAdmission { get; set; }
        public char Grade { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
            new Student{ StudID="1", FirstName="Dennis", LastName="Davis", Address="1500 Brannon Avenue, Jacksonville, FL 32207",
                MonthOfAdmission = MonthOfAdmission.January, Grade = 'A' },
            new Student { StudID = "2", FirstName = "Tonia", LastName = "Randall", Address = "4477 Fairfax Drive, City Of Commerce, CA 90040",
                MonthOfAdmission = MonthOfAdmission.February, Grade = 'B' },
            new Student { StudID = "3", FirstName = "Alice", LastName = "Gay", Address = "4179 Woodrow Way, Conroe, TX 77301",
                MonthOfAdmission = MonthOfAdmission.March, Grade = 'A' },
            new Student { StudID = "4", FirstName = "Gertrude", LastName = "Rollins", Address = "3239 Glenwood Avenue, Garfield Heights, OH 44125",
                MonthOfAdmission = MonthOfAdmission.April, Grade = 'C' },
            new Student { StudID = "5", FirstName = "James", LastName = "McClinton", Address = "752 Haven Lane, Lansing, MI 48933",
                MonthOfAdmission = MonthOfAdmission.May, Grade = 'B' },
            new Student { StudID = "6", FirstName = "Yasmin", LastName = "Moreno", Address = "1377 Hardman Road, Brattleboro, VT 05301",
                MonthOfAdmission = MonthOfAdmission.June, Grade = 'A' },
            new Student { StudID = "7", FirstName = "Regina", LastName = "Brown", Address = "3176 Poe Lane, Westphalia, KS 66093",
                MonthOfAdmission = MonthOfAdmission.July, Grade = 'C' },
            new Student { StudID = "8", FirstName = "Richard", LastName = "Wynn", Address = "245 Ritter Street, Rogersville, AL 35652",
                MonthOfAdmission = MonthOfAdmission.August, Grade = 'B' },
            new Student { StudID = "9", FirstName = "Samuel", LastName = "Griffin", Address = "699 Roy Alley, Denver, CO 80219",
                MonthOfAdmission = MonthOfAdmission.September, Grade = 'B' },
            new Student { StudID = "10",FirstName = "John", LastName = "Britt", Address = "578 Ward Road, Rye, NY 10580",
                MonthOfAdmission = MonthOfAdmission.October, Grade = 'A' },
            };
        }
    }
}



