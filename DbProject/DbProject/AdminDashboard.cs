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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            loadRooms();
            loadRegisteredStudents();
            loadRoomsOccupied();
            loadEmployees();
        }

        private void loadRooms()
        {
            Rooms r = new Rooms();
            object countRooms = r.getTotalRooms();
            textBox1.Text = countRooms.ToString(); // Convert object to string
        }

        private void loadRegisteredStudents()
        {
            Student s = new Student();
            object countStudents = s.getTotalStudents();
            textBox3.Text = countStudents.ToString(); // object int to string
        }

        private void loadRoomsOccupied()
        {
            Rooms r = new Rooms();
            object countStudents = r.getRoomsOccupied();
            textBox4.Text = countStudents.ToString(); // object int to string
        }

        private void loadEmployees()
        {
            User u = new User();
            object countEmployees = u.GetEmployees();
            textBox5.Text = countEmployees.ToString(); // object int to string
        }



        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnManageBuildings_Click(object sender, EventArgs e)
        {
            ManageBuilding m = new ManageBuilding();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIN form = new SignIN();
            form.Show();
            this.Hide();
        }
    }
}
