using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;
using System.Runtime.InteropServices;

namespace Individual_Project
{
    class InOutUtils
    {
        /// <summary>
        /// This method reads all the student's data from the data files
        /// </summary>
        /// <param name="filename">The name of the data file</param>
        /// <param name="register">an object of the register where you store all the data and use it for calculations</param>
        /// <returns>returns the register where you store all the data and use it for calculations</returns>
        public static Register ReadStudents(string filename, out Register register)
        {
            Register collection = new Register();
            register = null;
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            if (new FileInfo(filename).Length == 0)
            {
                Console.WriteLine("Error: no data input");
            }
            else
            {
                DateTime date = DateTime.Parse(Lines[0]);
                register = new Register(date);
                foreach (string Line in Lines.Skip(1))
                {
                    string[] Values = Line.Split(',');
                    string surname = Values[0];
                    string name = Values[1];
                    DateTime birthdate = DateTime.Parse(Values[2]);
                    string studentid = Values[3];
                    int course = int.Parse(Values[4]);
                    string phonenumber = Values[5];
                    string status = Values[6];

                    Students student = new Students(surname, name, birthdate, studentid, course, phonenumber, status);
                    if (!collection.Contains(student))
                    {
                        collection.Add(student);
                    }
                }
            }
            return collection;
        }
        /// <summary>
        /// This method prints all the students' data or only those which are required
        /// </summary>
        /// <param name="AllStudents">an object of the register where you store all the data and use it for calculations</param>
        /// <param name="Date">an object of the register where you store the date</param>
        public static void PrintStudents(Register AllStudents, Register Date)
        {
                Console.WriteLine(new string('-', 105));
                Console.WriteLine("Date");
                Console.WriteLine(new string('-', 105));
                DateTime date = Date.date;
                Console.WriteLine("{0}", date.Year);
                Console.WriteLine(new string('-', 105));
                Console.WriteLine();
                Console.WriteLine(new string('-', 105));
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-10:yyyy-MM-dd} | {3,-15} | {4,-2} | {5,-15} | {6,-7} | ", "Surname", "Name", "BirthDate",
                     "StudentID", "Course", "PhoneNumber", "Status");
                Console.WriteLine(new string('-', 105));

                for (int i = 0; i < AllStudents.StudentCount(); i++)
                {
                    Students info = AllStudents.ReturnIndexValue(i);
                    Console.WriteLine(info.ToString());
                }
                Console.WriteLine(new string('-', 105));          

        }
        /// <summary>
        /// This method prints the required students' data to a CSV file
        /// </summary>
        /// <param name="filename">the CSV file name</param>
        /// <param name="Found">an object of the register where you store all the data and use it for calculations</param>
        public static void PrintToCSVFile(string filename, Register Found)
        {
            
                string[] lines = new string[Found.StudentCount() + 1];
                lines[0] = String.Format(" {0,-15} , {1,-15} , {2,-10:yyyy-MM-dd} , {3,-15} , {4,-6} , {5,-15} , {6,-7}  ",
                    "Surname", "Name", "BirthDate", "StudentID", "Course", "PhoneNumber", "Status");
                for (int i = 0; i < Found.StudentCount(); i++)
                {
                    Students item = Found.ReturnIndexValue(i);
                    lines[i + 1] = item.ToString();
                }
                File.WriteAllLines(filename, lines, Encoding.UTF8);         
        }
        /// <summary>
        /// This method prints all the original data from the given gives to a TXT file
        /// </summary>
        /// <param name="filename">The TXT file name</param>
        /// <param name="All">an object of the register where you store all the data and use it for calculations</param>
        /// <param name="Date">an object of the register where you store the date</param>
        public static void PrintToTXTFile(string filename, Register All, Register Date)
        {
            if (All.StudentCount() > 0)
            {
                string[] lines = new string[All.StudentCount() + 4];
                DateTime date = Date.date;
                lines[0] = String.Format(" {0,-5}", date.Year);
                lines[1] = String.Format(" {0,-15}  {1,-15}  {2,-10:yyyy-MM-dd}  {3,-15}  {4,-6}  {5,-15}  {6,-7}  ",
                   "Surname", "Name", "BirthDate", "StudentID", "Course", "PhoneNumber", "Status");
                for (int i = 0; i < All.StudentCount(); i++)
                {
                    Students item = All.ReturnIndexValue(i);
                    lines[i + 2] = String.Format(" {0,-15}  {1,-15}  {2,-10:yyyy-MM-dd}  {3,-15}  {4,-6}  {5,-15}  {6,-7}  ", item.Surname, item.Name, item.BirthDate,
                        item.StudentID, item.Course, item.PhoneNumber, item.Status);
                }
                File.AppendAllLines(filename, lines, Encoding.UTF8);
            }           
        }
    }
}
