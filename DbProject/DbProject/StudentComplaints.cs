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
    public partial class StudentComplaints : StudentHeader
    {
        public StudentComplaints()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            dll.BL.Complaints c = new dll.BL.Complaints();
            int userID = Login.GetUserID();
            DataTable dt = c.GetComplaint(userID);

            dataGridView1.DataSource = dt;



            //// Add Delete Button Column
            //if (!dataGridView1.Columns.Contains("btnDelete"))
            //{
            //    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

            //    btnDelete.FlatStyle = FlatStyle.Flat;
            //    btnDelete.HeaderText = "Delete Course";
            //    btnDelete.Text = "Delete";
            //    btnDelete.Name = "btnDelete";
            //    btnDelete.UseColumnTextForButtonValue = true;
            //    btnDelete.DefaultCellStyle.BackColor = Color.Red;
            //    btnDelete.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            //    dataGridView1.Columns.Add(btnDelete);
            //}
        }
        private void StudentComplaints_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTheme_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

            string complaintDescription = txtTheme.Text.Trim();
            
            string dateInput = textBox1.Text.Trim();



            if (!string.IsNullOrEmpty(complaintDescription) && !string.IsNullOrEmpty(dateInput))
            {
                //if (DateTime.TryParse(dateInput, out DateTime complaintDate))
                //{


                int userID = Login.GetUserID();
                MessageBox.Show("User ID: " + userID);
                object studentID = User.GetStudentID(userID);
                int id = (int)studentID;
                MessageBox.Show("StudentID: " + id);
                //int id = Students.GetStudentID();
                Complaints c = new Complaints(id, complaintDescription, "Pending", dateInput);
                    if(Complaints.InsertingComplaint(c))
                    {
                        MessageBox.Show("Complaint Submitted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Can't Submit complaint");
                    }
                



            }
            else
            {
                MessageBox.Show("Please enter both description and date.");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
