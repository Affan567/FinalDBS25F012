using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll;
using dll.BL;

namespace DbProject
{
    public partial class StudentVisitorForm : StudentHeader
    {
        public StudentVisitorForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void StudentVisitorForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            dll.BL.Visitors c = new dll.BL.Visitors();
            int userID = Login.GetUserID();
            DataTable dt = c.GetVisitorsoftheUser(userID);

            dataGridView1.DataSource = dt;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            string name = txtTheme.Text.Trim();

            string dateInput = textBox1.Text.Trim();



            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(dateInput))
            {
                //if (DateTime.TryParse(dateInput, out DateTime complaintDate))
                //{


                int userID = Login.GetUserID();
                MessageBox.Show("User ID: " + userID);
                object studentID = User.GetStudentID(userID);
                int id = (int)studentID;
                MessageBox.Show("StudentID: " + id);
                //int id = Students.GetStudentID();
                Visitors c = new Visitors(id, name, dateInput);
                if (c.InsertVisitor(c))
                {
                    MessageBox.Show("Complaint Submitted Successfully");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Can't Submit complaint");
                }

            }
        }
    }
}
