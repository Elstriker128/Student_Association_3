using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Project
{
    internal class Container
    {
        private Students[] allStudents;
        private int Capacity;
        public int Count { get;  set; }
        /// <summary>
        /// This constructor creates space for the container variables
        /// </summary>
        /// <param name="capacity">a variable that displays the array size</param>
        public Container(int capacity=16)
        {           
            this.Capacity = capacity;
            this.allStudents = new Students[capacity];
        }
        /// <summary>
        /// This method adds a given object to the container's array and if required increases the array capacity
        /// </summary>
        /// <param name="student">A given object</param>
        public void Add(Students student)
        {
            if(this.Count==this.Capacity)
            {
                this.EnsureCapacity(this.Count * 2);
            }
            this.allStudents[this.Count++]=student;
        }
        /// <summary>
        /// This method gets an object from the container's array based on the given index
        /// </summary>
        /// <param name="index">The given index</param>
        /// <returns>returns an object from the container's array</returns>
        public Students Get(int index)
        {
            return this.allStudents[index];
        }
        /// <summary>
        /// This method ensures the required capacity of the array
        /// </summary>
        /// <param name="minimumCapacity">the required minimum capacity of the array</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if(this.Capacity < minimumCapacity)
            {
                Students[] temp = new Students[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.allStudents[i];
                }
                this.Capacity = minimumCapacity;
                this.allStudents=temp;
            }
        }
        /// <summary>
        /// This method searches the whole container array for the given object
        /// </summary>
        /// <param name="student">The given object</param>
        /// <returns>returns either true or false depending if the object is found</returns>
        public bool Contains(Students student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.allStudents[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// This method puts the given object in the indicated spot in the array. The given index displays the spot
        /// </summary>
        /// <param name="student">The given object</param>
        /// <param name="index">The given index</param>
        public void Put(Students student, int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                this.allStudents[index] = student;
            }            
        }
        /// <summary>
        /// This method inserts the given object in the indicated spot in the array. The given index displays the spot
        /// Other values are pushed down in the array
        /// </summary>
        /// <param name="student">The given object</param>
        /// <param name="index">The given index</param>
        public void Insert(Students student, int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                for (int i = this.Count; i > index; i--)
                {
                    this.allStudents[i] = this.allStudents[i - 1];
                }
                this.Count++;
                this.allStudents[index] = student;

            }            
        }
        /// <summary>
        /// This method removes the given object from the container's array
        /// </summary>
        /// <param name="student">The given object</param>
        public void Remove(Students student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.allStudents[i] == student)
                {
                    for (int j = i; j < this.Count - 1; j++)
                    {
                        this.allStudents[j] = this.allStudents[j + 1];
                    }
                    this.Count--;
                }
            }
        }
        /// <summary>
        /// This method removes an objeect from the given spot in the container's array. The spot is indicated by the given index
        /// </summary>
        /// <param name="index">The given index</param>
        public void RemoveAt(int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (i == index)
                    {
                        for (int j = i; j < this.Count - 1; j++)
                        {
                            this.allStudents[j] = this.allStudents[j + 1];
                        }
                        this.Count--;
                    }
                }
            }           
        }
    }
}
