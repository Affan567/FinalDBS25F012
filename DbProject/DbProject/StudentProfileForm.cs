using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll.BL;

namespace DbProject
{
    public partial class StudentProfileForm : StudentHeader
    {
        public StudentProfileForm()
        {
            InitializeComponent();
            loadName();
            loadRegNO();
            loadComplaint();
            loadFeeStatus();
        }

        private void StudentProfileForm_Load(object sender, EventArgs e)
        {

        }

        
            private void loadName()
        {
            User u = new User();
            int userID = Login.GetUserID();
            string countRooms = (string)u.getNameFromDB(userID);
            textBox1.Text = countRooms; // Convert int to string
        }


        private void loadRegNO()
        {
            User u = new User();
            int userID = Login.GetUserID();
            Student stu = new Student();            
            string countRooms = (string)stu.GetRegNO(userID);
            textBox4.Text= countRooms; // Convert int to string
        }

        private void loadComplaint()
        {
            User u = new User();
            int userID = Login.GetUserID();
            Complaints stu = new Complaints();
            Student student = new Student();
            int studentID = (int)student.GetStudentID(userID); 
            object countRooms = stu.GetComplaintStatus(studentID);
            if (countRooms == null)
            {
                textBox2.Text = "No Complaint";
                // Convert int to string
            }
            else {
                textBox2.Text = (string)countRooms;
            }

        }

        private void loadFeeStatus()
        {
            User u = new User();
            int userID = Login.GetUserID();
            Fees stu = new Fees();
            Student student = new Student();
            int studentID = (int)student.GetStudentID(userID);
            object countRooms = stu.GetFeeStatus(studentID);
            if (countRooms == null)
            {
                textBox3.Text = "No Fee";
                // Convert int to string
            }
            else
            {
                textBox3.Text = (string)countRooms;
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
