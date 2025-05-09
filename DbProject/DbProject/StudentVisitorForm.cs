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
    }
}
