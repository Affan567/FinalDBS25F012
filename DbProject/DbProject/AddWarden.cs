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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DbProject
{
    public partial class AddWarden : PapaForm
    {
        public AddWarden()
        {
            InitializeComponent();
            LoadData();
            bindBuilding();
        }



        private void bindBuilding()
        {
            Hostelbuildings building = new Hostelbuildings();
            List<object> buildingname = building.GetBuildingName();
            comboBox1.DataSource = buildingname;
            comboBox1.SelectedIndex = -1;
        }
        private void LoadData()
        {
            Warden h = new Warden();
            DataTable dt = h.GetWardenData();

            dataGridView1.DataSource = dt;

            if (!dataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.HeaderText = "Delete Building";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.DefaultCellStyle.BackColor = Color.Red;
                btnDelete.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                dataGridView1.Columns.Add(btnDelete);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["btnDelete"].Index)
                return;


            int Wardenid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["WardenID"].Value);
            int userid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["userID"].Value);


            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Warden s = new Warden();
                if (s.DeleteWarden(Wardenid, userid))
                {
                    MessageBox.Show("Row Deleted SuccessFully");
                }
                else
                {
                    MessageBox.Show("Can't deleted ");
                }

                LoadData();

                bindBuilding();
            }
        }

        private void codedButton2_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text.ToString().Trim();
            string BuildingName = comboBox1.Text.ToString().Trim();
            string WardenContact = textBox3.Text.ToString().Trim();

            string WardenUsername = textBox1.Text.ToString().Trim();
            string WardenPassword = textBox2.Text.ToString().Trim();

            string email = textBox5.Text.ToString().Trim();





            ////Student stu = new Student();
            ////int userID = stu.GetUserID(WardenUsername, WardenPassword);

            //int studentID = (int)stu.GettingstudentID(userID);

            Hostelbuildings hostel= new Hostelbuildings();
            int buildingid = (int)hostel.GetBuildingID(BuildingName);





            Warden warden = new Warden(name, WardenContact, email, 3, buildingid, WardenUsername, WardenUsername);
            if (warden.AddWarden(warden))
            {
                MessageBox.Show("Student Added Successfully");
            }
            else
            {
                MessageBox.Show("An error occurred: ");
            }

            LoadData();
        }

        private void codedButton3_Click(object sender, EventArgs e)
        {

            string name = textBox4.Text.ToString().Trim();
            string BuildingName = comboBox1.Text.ToString().Trim();
            string WardenContact = textBox3.Text.ToString().Trim();

            string WardenUsername = textBox1.Text.ToString().Trim();
            string WardenPassword = textBox2.Text.ToString().Trim();

            string email = textBox5.Text.ToString().Trim();


            Warden stu = new Warden();
            int userID = stu.GetUserID(WardenUsername, WardenPassword);

            int WardenID = (int)stu.GettingWardenID(userID);

            Hostelbuildings hostel = new Hostelbuildings();
            int buildingid = (int)hostel.GetBuildingID(BuildingName);





            Warden warden = new Warden(userID, WardenID, name, WardenContact, email,  buildingid, WardenUsername, WardenPassword, 2);
            bool flag = warden.UpdateWarden(warden);

            if (flag)
            {
                MessageBox.Show("Student Data Updated SuccessFully");
            }
        }

        private void codedButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
