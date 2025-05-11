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
    public partial class PapaForm : Form
    {
        public PapaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIN form = new SignIN();
            form.Show();
            this.Hide();

        }

        private void btnAddEmployees_Click(object sender, EventArgs e)
        {
            AddWarden warden = new AddWarden();
            warden.Show();
            this.Hide();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            ManageRooms rooms = new ManageRooms();
            rooms.Show();
            this.Hide();
        }

        private void btnManageStudent_Click(object sender, EventArgs e)
        {
            ManageStudents student = new ManageStudents();
            student.Show();
            this.Hide();

        }

        private void btnManageBuildings_Click(object sender, EventArgs e)
        {
            ManageBuilding buildings = new ManageBuilding();
            buildings.Show();
            this.Hide();
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            
        }

        private void labelResults_Click(object sender, EventArgs e)
        {
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
            this.Hide();
        }
    }
}
