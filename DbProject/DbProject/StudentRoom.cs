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
    public partial class StudentRoom : StudentHeader
    {
        public StudentRoom()
        {
            InitializeComponent();
            LoadData();
        }



        private void LoadData()
        {
            dll.BL.Rooms c = new dll.BL.Rooms();
            int userID = Login.GetUserID();
            DataTable dt = c.ViewRoomofStudent(userID);

            dataGridView1.DataSource = dt;

        }
        private void StudentRoom_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
