using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Marksheet
{
    public class StudentDetails
    {
        public int rollNum, maths, science, english;
        public int total { get { return (maths + science + english); }  }
        public float percentage { get { return (total / 3.0f); } }
        public string name;
        public string grade;
        
    }

    public class StudentEntry
    
    {
        private List<StudentDetails> Student1;
        public StudentEntry() 
        {
            Student1 = new List<StudentDetails>();
        }

        public bool CreateStudent(StudentDetails stud) 
        {
            bool isSuccess = false;
            try 
            {
                Student1.Add(stud);
                isSuccess = true;

            }
            catch 
            {
                isSuccess = false;
            }
            return isSuccess;
        } 

        public List<StudentDetails> StudentViewAll() 
        {
            return Student1;
        }
    }

}
