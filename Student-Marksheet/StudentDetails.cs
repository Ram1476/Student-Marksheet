using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Marksheet
{
    public class StudentDetails
    {
        public int rollNum, maths, science, english;
        public int total { get { return (maths + science + english); }  }
        public float percentage { get { return (float)Math.Round(total / 3.0f); } }
        public string name;
        public string grade;
        
    }

    public class StudentEntry
    
    {
        
        StudentDetails s1 = new StudentDetails(); 
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

        public string GradeCalculation(float per) 
        {
            per = (float)Math.Round(per);

            if (per >= 35 && per < 50)
            {
                s1.grade = "C";
            }
            else if (per >= 50 && per <= 60)
            {
                s1.grade = "B";
            }
            else if (per > 60 && per <= 80)
            {
                s1.grade = "A";
            }
            else if (per > 80 && per <= 100)
            {
                s1.grade = "A++";
            }
            else
            {
                s1.grade = "F";
            }
            return s1.grade;
        }
    }

}
