using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Individual_Project
{
    class Register
    {
        private Container AllStudents;
        public DateTime date { get; private set; }
        /// <summary>
        /// This constructor creates space for the date variable
        /// </summary>
        /// <param name="date">The date</param>
        public Register(DateTime date)
        {
            this.date = date;
        }
        /// <summary>
        /// This constructor creates space for the container
        /// </summary>
        public Register()
        {
           this.AllStudents = new Container();
        }
        /// <summary>
        /// This constructor adds data to the containers object 
        /// </summary>
        /// <param name="allStudents">The container's object</param>
        public Register(Container allStudents) : this()
        {
            for (int i = 0; i < allStudents.Count; i++)
            {
                this.AllStudents.Add(allStudents.Get(i));
            }
        }
        /// <summary>
        /// This method adds a given object to the container's variable
        /// </summary>
        /// <param name="student">A given object</param>
        public void Add(Students student)
        {
            this.AllStudents.Add(student);
        }
        /// <summary>
        /// This method returns the student count
        /// </summary>
        /// <returns>returns the student count</returns>
        public int StudentCount()
        {
            return this.AllStudents.Count;
        }
        /// <summary>
        /// This method returns the given index value 
        /// </summary>
        /// <param name="index">The index value</param>
        /// <returns>returns the given index value</returns>
        public Students ReturnIndexValue(int index)
        {
            return this.AllStudents.Get(index);
        }
        /// <summary>
        /// This method checks if the register contains the given object's value
        /// </summary>
        /// <param name="Info">the given object' value</param>
        /// <returns>returns either true or false based on whether the object's value is found</returns>
        public bool Contains(Students Info)
        {
            return this.AllStudents.Contains(Info);
        }
        /// <summary>
        /// This method returns a register of all the students that left after the first year of studying
        /// </summary>
        /// <param name="SecondRegister">An object of the second file register</param>
        /// <returns>returns a register of all the students that left after the first year of studying</returns>
        public Register ReturnStudentsWhoLeftAfterFirstYear(Register SecondRegister)
        {
            Register filtered = new Register();
            for (int i = 0; i < AllStudents.Count; i++)
            {
                Students first = AllStudents.Get(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!filtered.Contains(second) && second == 1 && !AllStudents.Contains(second))
                    {
                        filtered.Add(second);
                    }
                }
            }
            return filtered;
        }
        /// <summary>
        /// This method returns the first student who left the association 
        /// </summary>
        /// <param name="SecondRegister">An object of the second file register</param>
        /// <returns>returns the first student who left the association </returns>
        public Students ReturnFirstExStudent(Register SecondRegister)
        {
            Students result = SecondRegister.ReturnIndexValue(0);
            for (int j = 0; j < SecondRegister.StudentCount(); j++)
            {
                Students second = SecondRegister.ReturnIndexValue(j);
                if (!AllStudents.Contains(second))
                {
                    result = second;
                }
            }
            return result;

        }
        /// <summary>
        /// This method returns the oldest member who has already let the association
        /// </summary>
        /// <param name="SecondRegister">An object of the second file register</param>
        /// <returns>returns the oldest member who has already let the association</returns>
        public Students ReturnOldestExMember(Register SecondRegister)
        {
            Students oldest = ReturnFirstExStudent(SecondRegister);
            for (int i = 0; i < AllStudents.Count; i++)
            {
                Students first = AllStudents.Get(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!AllStudents.Contains(second) && DateTime.Compare(oldest.BirthDate, second.BirthDate) > 0)
                    {
                        oldest = second;
                    }
                }
            }

            return oldest;
        }
        /// <summary>
        /// This method returns all the oldest members who have already let the association
        /// </summary>
        /// <param name="SecondRegister">An object of the second file register</param>
        /// <returns>returns all the oldest members who have already let the association</returns>
        public Register ReturnAllOldestExMembers(Register SecondRegister)
        {
            Register AllOldest = new Register();
            Students oldest = ReturnOldestExMember(SecondRegister);
            for (int i = 0; i < AllStudents.Count; i++)
            {
                Students first = AllStudents.Get(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!AllOldest.Contains(second) && !AllStudents.Contains(second) && DateTime.Compare(oldest.BirthDate, second.BirthDate) == 0)
                    {
                        AllOldest.Add(second);
                    }
                }
            }
            return AllOldest;
        }
        /// <summary>
        /// This method returns all the students who studied both years
        /// </summary>
        /// <param name="SecondRegister">An object of the second file register</param>
        /// <returns>returns all the students who studied both years</returns>
        public Register ReturnStudentsWhoStudiedBothYears(Register SecondRegister)
        {
            Register Found = new Register();
            for (int i = 0; i < SecondRegister.StudentCount(); i++)
            {
                Students second = SecondRegister.ReturnIndexValue(i);
                for (int j = i; j < AllStudents.Count; j++)
                {
                    Students first = AllStudents.Get(j);
                    if (!Found.Contains(first) && SecondRegister.Contains(first))
                    {
                        Found.Add(first);
                    }
                }
            }
            return Found;
        }
        /// <summary>
        /// This method returns the students who were a first year las year
        /// </summary>
        /// <param name="SecondRegister">An object of the second file register</param>
        /// <returns>returns the students who were a first year las year</returns>
        public Register ReturnStudentsWhoWereAFirstYear(Register SecondRegister)
        {
            Register filtered = new Register();
            for (int i = 0; i < AllStudents.Count; i++)
            {
                Students first = AllStudents.Get(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!filtered.Contains(second) && second == 1)
                    {
                        filtered.Add(second);
                    }
                }
            }
            return filtered;
        }
        /// <summary>
        /// This method sorts all the students who studied both years by the course and student ID 
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while(flag)
            {
                flag = false;
                for (int i = 0; i < AllStudents.Count-1; i++)
                {
                    Students a = AllStudents.Get(i);
                    Students b = AllStudents.Get(i+1);
                    if(a.CompareTo(b)>0)
                    {
                        AllStudents.Put(b,i);
                        AllStudents.Put(a, i + 1);
                        flag = true;
                    }
                }
            }
        }
    }

}
