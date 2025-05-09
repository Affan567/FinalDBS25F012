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
    public partial class StudentDashBoard : StudentHeader
    {
        public StudentDashBoard()
        {
            InitializeComponent();
            loadName();
        }
        private void loadName()
        {
            User u = new User();
            int userID = Login.GetUserID();
            MessageBox.Show("UserID"+ userID);
            string countRooms = (string)u.getNameFromDB(userID);
            textBox3.Text = countRooms; // Convert int to string
        }
        private void StudentDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
