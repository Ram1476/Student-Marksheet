using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Marksheet
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        StudentDetails stud1 = new StudentDetails();
        StudentEntry Stud2 = new StudentEntry();
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

      
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream Fstream = new FileStream(@"D:\C#\StudentData.csv", FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter Swriter = new StreamWriter(Fstream);

            bool ischecked = false;
            try 
            {
                foreach (StudentDetails st in Stud2.StudentViewAll())
                {
                    FileInfo loc = new FileInfo(@"D:\C#\StudentData.csv");
                    if (loc.Length == 0)
                    {
                        Swriter.WriteLine("Student Roll-No" + " | " + "Student Name" + " | " + "Mathematics" + " | " + "Science" + " | " + "English" + " | "+"Percentage" 
                            + " | "+"Grade" + " | "+"Total");
                        Swriter.WriteLine(st.rollNum + " | " + st.name + " | " + st.maths + " | " + st.science + " | " + st.english + " | " + st.percentage + "%" + " | " + st.grade
                        + " | " + st.total);
                        ischecked = true;
                    }
                    else 
                    {
                        Swriter.WriteLine(st.rollNum + " | " + st.name + " | " + st.maths + " | " + st.science + " | " + st.english + " | " + st.percentage + "%" + " | " + st.grade
                        + " | " + st.total);
                        ischecked = true;
                    }
                }    
                if (ischecked)
                {
                    MessageBox.Show("Student Details Successfully Saved in .CSV format");
                }
                else
                {
                    MessageBox.Show("Student Details Not Found to save in .CSV format");
                }
                Swriter.Flush();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error Processing the student data - Data not saved to file" + Environment.NewLine+ex.Message);

            }
            finally 
            {
                Swriter.Close();
                Fstream.Close();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtTot_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            stud1.rollNum = Convert.ToInt32(txtRollno.Text);
            stud1.maths = Convert.ToInt32(txtmath.Text);
            stud1.science = Convert.ToInt32(txtsci.Text);
            stud1.english = Convert.ToInt32(txteng.Text);
            stud1.name = txtname.Text;
            textPer.Text = Math.Round(stud1.percentage,2).ToString() + "%";
            stud1.grade = Stud2.GradeCalculation(stud1.percentage);
            textGD.Text = Stud2.GradeCalculation(stud1.percentage);
            textTot.Text = stud1.total.ToString();

            if (Stud2.CreateStudent(stud1)) 
            {
                MessageBox.Show("Student Data Successfully Created");
            }
            else 
            {
                MessageBox.Show("Student Data Not created ");
            }
           
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\C#\StudentData.txt";
            FileStream Fstream = new FileStream(path,FileMode.Append,FileAccess.Write);
            StreamWriter Swriter = new StreamWriter(Fstream);
            FileInfo len = new FileInfo(path);
            bool isSuccess = false;
            try 
            {
                foreach (StudentDetails st in Stud2.StudentViewAll()) 
                {
                    if (len.Length == 0) 
                    {
                        string fst = "Student Roll-No" + " | " + "Student Name" + " | " + "Mathematics" + " | " + "Science" + " | " + "English";
                        string entry = st.rollNum + " | " + st.name + " | " + st.maths + " | " + st.science + " | " + st.english + " | " +st.percentage+"%"+ " | " + st.grade
                    + " | " + st.total;
                        Swriter.WriteLine(fst);
                        Swriter.WriteLine(entry);
                        isSuccess= true;
                    }
                    else 
                    {
                        string entry = st.rollNum + " | " + st.name + " | " + st.maths + " | " + st.science + " | " + st.english + " | " + st.percentage + "%" + " | " + st.grade
                    + " | " + st.total;

                        Swriter.WriteLine(entry);
                        isSuccess= true;
                    }
                    if (isSuccess) 
                    {
                        MessageBox.Show("Student Details Successfully Saved in .TXT format");
                    }
                    else 
                    {
                        MessageBox.Show("Student Details Not Found to save in .TXT format");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Processing the Student Details" + Environment.NewLine + ex.Message);
            }
            finally 
            {
                Swriter.Close();
                Fstream.Close();
            }
        }

        private void btnOD_Click(object sender, EventArgs e)
        {
            textOD.Text = " ";
            foreach (StudentDetails st in Stud2.StudentViewAll()) 
            {
                textOD.Text += st.rollNum + " | " + st.name + " | " + st.maths + " | " + st.science + " | " + st.english + " | " + st.percentage + "%" + " | " + st.grade
                    + " | " + st.total + Environment.NewLine;

            }

            if (textOD.Text != "") 
            {
                MessageBox.Show("Student Details SuccessFully Displayed");
            }
            else 
            {
                MessageBox.Show("Student Details not available");
            }
        }

        private void txtPer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textTot_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
