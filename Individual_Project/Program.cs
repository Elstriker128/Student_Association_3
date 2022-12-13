using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Individual_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Register Date1, Date2;
            Console.OutputEncoding = Encoding.UTF8;

            Register CurStudents = InOutUtils.ReadStudents(@"Students.csv", out Date1);
            Register PastStudents = InOutUtils.ReadStudents(@"PastStudents.csv", out Date2);

            InOutUtils.PrintStudents(CurStudents, Date1);
            InOutUtils.PrintStudents(PastStudents, Date2);
            
            Register Final = CurStudents.ReturnStudentsWhoLeftAfterFirstYear(PastStudents);
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("Information about who left after first year student: ");
            Console.WriteLine(new string('-', 105));
            if(Final.StudentCount()>0)
            {
                InOutUtils.PrintStudents(Final, Date2);
            }
            else
            {
                Console.WriteLine("Error: No output for who left after the first year");
            }
            Console.WriteLine();

            Register Oldest = CurStudents.ReturnAllOldestExMembers(PastStudents);
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("Information about oldest student(-s): ");
            Console.WriteLine(new string('-', 105));
            if(Oldest.StudentCount() > 0)
            {
                InOutUtils.PrintStudents(Oldest, Date2);
            }
            else
            {
                Console.WriteLine("Error: No output for the oldest students");
            }
            Console.WriteLine();

            string filename = "PalikoPirmi.csv";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            Register FirstYear = CurStudents.ReturnStudentsWhoWereAFirstYear(PastStudents);
            if(FirstYear.StudentCount() > 0)
            {
                InOutUtils.PrintToCSVFile(filename, FirstYear);
            }
            else
            {
                Console.WriteLine("Error: No output for students who were in the first course");
            }
            Console.WriteLine();

            string filename1 = "Seniai.csv";
            if (File.Exists(filename1))
            {
                File.Delete(filename1);
            }
            Register BothYears = CurStudents.ReturnStudentsWhoStudiedBothYears(PastStudents);
            if(BothYears.StudentCount()>0)
            {
                BothYears.Sort();
                InOutUtils.PrintToCSVFile(filename1, BothYears);
            }
            else
            {
                Console.WriteLine("Error: No output for students who studied both years");
            }
            Console.WriteLine();

            string filename2 = "Output_Students.txt";
            if (File.Exists(filename2))
            {
                File.Delete(filename2);
            }
            if(CurStudents.StudentCount()>0 && PastStudents.StudentCount()>0)
            {
                InOutUtils.PrintToTXTFile(filename2, CurStudents, Date1);
                InOutUtils.PrintToTXTFile(filename2, PastStudents, Date2);
            }
            else
            {
                Console.WriteLine("Error: No output for original students ");
            }

            Console.ReadKey();
        }
    }
}
