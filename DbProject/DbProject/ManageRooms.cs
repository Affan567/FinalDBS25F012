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
    public partial class ManageRooms : PapaForm
    {
        public ManageRooms()
        {
            InitializeComponent();
            LoadData();
            bindRoomID();
            bindBuilding();
            bindRoomType();
        }

        private void ManageRooms_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void codedButton7_Click(object sender, EventArgs e)
        {
            try
            {
                string BuildingName = comboBox5.Text.ToString().Trim();
                int roomID = int.Parse(comboBox4.Text.ToString().Trim());
                int RoomNumber = int.Parse(textBox3.Text.ToString().Trim());
                string RoomTypeName = comboBox2.Text.ToString().Trim();

                int capacity = int.Parse(comboBox1.Text.ToString().Trim());
                string status = comboBox1.Text.ToString().Trim();


                Rooms r = new Rooms();
                int getroomID = (int)r.getRoomID(RoomNumber);

                RoomType rT = new RoomType();
                int roomTypeID = (int)rT.getRoomTypeID(RoomTypeName, capacity);


                Hostelbuildings hb = new Hostelbuildings();
                int buildingID = (int)hb.GetBuildingID(BuildingName);

                Rooms room = new Rooms(RoomNumber, buildingID, RoomTypeName, capacity, status, roomTypeID);
                bool flag = room.AddRoom(room);

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


        private void LoadData()
        {
            Rooms r = new Rooms();
            DataTable dt = r.GetRoomData();

            dataGridView1.DataSource = dt;

            if (!dataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.HeaderText = "Delete Room";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.DefaultCellStyle.BackColor = Color.Red;
                btnDelete.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                dataGridView1.Columns.Add(btnDelete);
            }
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


            }


        }

        private void codedButton8_Click(object sender, EventArgs e)
        {
            LoadData();
            bindRoomID();
            bindBuilding();
            bindRoomType();
        }


        private void bindRoomType()
        {
            RoomType type = new RoomType();
            List<object> TypeNameList = type.GettingTypeName();
            comboBox2.DataSource = TypeNameList;
            comboBox2.SelectedIndex = -1;
        }

        private void bindBuilding()
        {
            Hostelbuildings building = new Hostelbuildings();
            List<object> buildingname = building.GetBuildingName();
            comboBox5.DataSource = buildingname;
            comboBox5.SelectedIndex = -1;
        }

        private void bindRoomID()
        {
            Rooms rooms = new Rooms();
            List<object> roomList = rooms.GetAllRoomID();


            comboBox4.DataSource = roomList;
            comboBox4.SelectedIndex = -1;
        }
    }
}