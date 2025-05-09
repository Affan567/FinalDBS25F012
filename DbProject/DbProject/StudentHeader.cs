using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbProject
{
    public partial class StudentHeader : Form
    {
        public StudentHeader()
        {
            InitializeComponent();
        }

        private void labelResults_Click(object sender, EventArgs e)
        {
            StudentDashBoard studentDashBoard = new StudentDashBoard();
            studentDashBoard.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StudentComplaints stu = new StudentComplaints();
            stu.Show();
            this.Hide();
            
        }

        private void StudentHeader_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            StudentFineForm stu = new StudentFineForm();
            stu.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            StudentOtherRequests stu = new StudentOtherRequests();
            stu.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            StudentVisitorForm stu = new StudentVisitorForm();  
            stu.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            StudentFee fee = new StudentFee();
            fee.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StudentRoom room = new StudentRoom();
            room.Show();
            this.Hide();
        }
    }
}
