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
    public partial class StudentOtherRequests : StudentHeader
    {
        public StudentOtherRequests()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            dll.BL.Request r = new dll.BL.Request();
            int userID = Login.GetUserID();
            DataTable dt = r.GetRequestsOfOneStudent(userID);

            dataGridView1.DataSource = dt;



        }

        private void StudentOtherRequests_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    // Ignore header and out-of-range clicks
            //    if (e.RowIndex < 0 || e.ColumnIndex != kryptonDataGridView1.Columns["btnDelete"].Index)
            //        return;

            //    // Get ID of the selected row
            //    int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["CourseID"].Value);

            //    // Confirm deletion
            //    var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        DBProjectBackend.BL.Course c = new DBProjectBackend.BL.Course();
            //        bool flag = c.DeleteCourse(id);
            //        LoadData(); // Refresh the grid
            //    }
            //}
        }
    }
}
