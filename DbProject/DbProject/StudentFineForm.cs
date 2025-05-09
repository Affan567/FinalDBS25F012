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
    public partial class StudentFineForm : StudentHeader
    {
        public StudentFineForm()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            dll.BL.DamageRecords c = new dll.BL.DamageRecords();
            int userID = Login.GetUserID();
            DataTable dt = c.GetDamageRecords(userID);

            dataGridView1.DataSource = dt;

        }
        private void StudentFineForm_Load(object sender, EventArgs e)
        {

        }
    }
}
