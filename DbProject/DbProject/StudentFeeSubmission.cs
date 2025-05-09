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
    public partial class StudentFee : StudentHeader
    {
        public StudentFee()
        {
            InitializeComponent();
            LoadFee();
        }


        private void LoadFee()
        {
            dll.BL.Fees c = new dll.BL.Fees();
            int userID = Login.GetUserID();
            DataTable dt = c.GetFee(userID);

            dataGridView1.DataSource = dt;

        }

        private void StudentFee_Load(object sender, EventArgs e)
        {

        }
    }
}
