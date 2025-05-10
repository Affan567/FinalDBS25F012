using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using dll;
using dll.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DbProject
{
    public partial class ManageBuilding : PapaForm
    {
        public ManageBuilding()
        {
            InitializeComponent();
            loadRegisteredStudents();
            loadTotalBuildings();
            LoadData();
            bindWarden();
            bindBuilding();
        }

        private void loadRegisteredStudents()
        {
            Student s = new Student();
            object countStudents = s.getTotalStudents();
            label3.Text = countStudents.ToString(); // object int to string
        }

        private void loadTotalBuildings()
        {
            Hostelbuildings h = new Hostelbuildings();
            object countStudents = h.getTotalBuildins();
            LabelBuildingsCount.Text = countStudents.ToString(); // object int to string
        }
        
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bindWarden()
        {
            Warden war = new Warden();
            List<object> wardenusername = war.GetWardenUsername();
            comboBox1.DataSource = wardenusername;
            comboBox1.SelectedIndex = -1;
        }

        private void bindBuilding()
        {
            Hostelbuildings building = new Hostelbuildings();
            List<object> buildingname = building.GetBuildingName();
            comboBox3.DataSource = buildingname;
            comboBox3.SelectedIndex = -1;
        }

        private void codedButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string buildingname = textBox1.Text.ToString().Trim();
                string Buildingwarden = comboBox1.Text.ToString().Trim();
                int floors = int.Parse(numericUpDown2.Text.Trim());
                int rooms = int.Parse(numericUpDown1.Text.Trim());
                string status = comboBox2.Text.ToString().Trim();


                Warden h = new Warden();
                int wardenID = (int)h.GetWardenID(Buildingwarden);


                Hostelbuildings building = new Hostelbuildings(buildingname , floors , rooms , wardenID , status);
                bool flag = building.AddHostelBuilding(building);

                if (flag)
                {
                    MessageBox.Show("Building Added SuccessFully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void codedButton3_Click(object sender, EventArgs e)
        {
            
                string buildingNameBefore = comboBox3.Text.ToString().Trim();
                string buildingnameAfter = textBox1.Text.ToString().Trim();
                string Buildingwarden = comboBox1.Text.ToString().Trim();
                int floors = int.Parse(numericUpDown2.Text.Trim());
                int rooms = int.Parse(numericUpDown1.Text.ToString().Trim());
                string status = comboBox2.Text.ToString().Trim();
                
                
                Hostelbuildings hb = new Hostelbuildings();
                int buildingID = (int)hb.GetBuildingID(buildingNameBefore);


                Warden h = new Warden();
                int wardenID = (int)h.GetWardenID(Buildingwarden);
                
                
                Hostelbuildings building = new Hostelbuildings(buildingID,buildingnameAfter, floors, rooms, wardenID, status);
                bool flag = building.UpdateBuildings(building);

                if (flag)
                {
                    MessageBox.Show("Building Updated SuccessFully");
                }
            
        }


        private void LoadData()
        {
            Hostelbuildings h = new Hostelbuildings();
            int userID = Login.GetUserID();
            DataTable dt = h.GetHostelbuildingData(userID);

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
         
        private void codedButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void LabelBuildingsCount_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["btnDelete"].Index)
                return;

            
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["BuildingID"].Value);

            
            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Hostelbuildings c = new Hostelbuildings();
                if (c.DeleteBuildings(id))
                {
                    MessageBox.Show("Row Deleted SuccessFully");
                }
                else
                {
                    MessageBox.Show("Can't deleted ");
                }

                LoadData(); 

                bindWarden();
                bindBuilding();
            }


        }
    }
}
