using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Project
{
    /// <summary>
    /// This class collects primary data and holds the constructor
    /// </summary>
    public class Students
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string StudentID { get; private set; }
        public int Course { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Status { get; private set; }
        public int Age { get; private set; }
        public Students(string surname, string name, DateTime birthdate, string studentid, int course, string phonenumber, string status)
        {
            this.Surname = surname;
            this.Name = name;
            this.BirthDate = birthdate;
            this.StudentID = studentid;
            this.Course = course;
            this.PhoneNumber = phonenumber;
            this.Status = status;
        }
        /// <summary>
        /// This method finds the age of the student
        /// </summary>
        /// <returns>returns the age of the student</returns>
        public int FindAge()
        {
            return Age = (Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) - Convert.ToInt32(BirthDate.ToString("yyyyMMdd"))) / 10000;
        }
        /// <summary>
        /// This is a overriden ToString method that returns all the students' data
        /// </summary>
        /// <returns>returns all the students' data</returns>
        public override string ToString()
        {
            string info;
            info = string.Format("| {0,-15} | {1,-15} | {2,-10:yyyy-MM-dd} | {3,-15} | {4,-6} | {5,-15} | {6,-7}| ", Surname, Name, BirthDate,
                      StudentID, Course, PhoneNumber, Status);
            return info;
        }
        /// <summary>
        /// This method checks for students equality based on their student ID
        /// </summary>
        /// <param name="obj">base class object</param>
        /// <returns>return either true or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Students students &&
                   StudentID == students.StudentID;
        }
        /// <summary>
        /// This method works in correlation to the Equals method
        /// </summary>
        /// <returns>returns a variable specific number</returns>
        public override int GetHashCode()
        {
            return -284491835 + EqualityComparer<string>.Default.GetHashCode(StudentID);
        }
        /// <summary>
        /// This method displays a new meaning to the == sign by giving two variables
        /// </summary>
        /// <param name="student">the Students' class object</param>
        /// <param name="i">a random number</param>
        /// <returns>returns either true or false</returns>
        public static bool operator ==(Students student, int i)
        {
            return student.Course == i;
        }
        /// <summary>
        /// This method works in correlation with == operator method 
        /// </summary>
        /// <param name="student">the Students' class object</param>
        /// <param name="i">a random number</param>
        /// <returns>returns either true or false</returns>
        public static bool operator !=(Students student, int i)
        {
            return student.Course != i;
        }
        /// <summary>
        /// This method checks if two objects values are equal and if they are not, they are compared which is bigger 
        /// </summary>
        /// <param name="other">the Students' class object</param>
        /// <returns>returns a value which is bigger</returns>
        public int CompareTo(Students other)
        {
            if(this.Course != other.Course)
            {
                return this.Course.CompareTo(other.Course);
            }
            else if(this.StudentID != other.StudentID)
            {
                return this.StudentID.CompareTo(other.StudentID);
            }
            else
            {
                return -1;
            }
        }
    }
   
}
