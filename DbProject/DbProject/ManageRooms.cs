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
using dll.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            loadRooms();
            LoadAvailableRooms();

        }

        private void ManageRooms_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void codedButton7_Click(object sender, EventArgs e)
        {

            string BuildingName = comboBox5.Text.ToString().Trim();
            //int roomID = int.Parse(comboBox4.Text.ToString().Trim());
            int RoomNumber = int.Parse(textBox3.Text.ToString().Trim());
            string RoomTypeName = comboBox2.Text.ToString().Trim();

            int capacity = int.Parse(comboBox1.Text.ToString().Trim());
            string status = comboBox3.Text.ToString().Trim();


            //Rooms r = new Rooms();
            //int getroomID = (int)r.getRoomID(RoomNumber);

            //RoomType rT = new RoomType();
            //int roomTypeID = (int)rT.getRoomTypeID(RoomTypeName, capacity);


            Hostelbuildings hb = new Hostelbuildings();
            int buildingID = (int)hb.GetBuildingID(BuildingName);

            Rooms room = new Rooms(RoomNumber, buildingID, RoomTypeName, capacity, status);
            bool flag = room.AddRoom(room);

            if (flag)
            {
                MessageBox.Show("Building Added SuccessFully");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["btnDelete"].Index)
                return;



            int roomid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RoomID"].Value);
            int RoomTypeid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RoomTypeID"].Value);


            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Rooms r = new Rooms();
                if (r.DeleteRoom(roomid, RoomTypeid))
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void codedButton6_Click(object sender, EventArgs e)
        {

            string BuildingName = comboBox5.Text.ToString().Trim();
            int roomTypeID = int.Parse(comboBox4.Text.ToString().Trim());
            int RoomNumber = int.Parse(textBox3.Text.ToString().Trim());
            string RoomTypeName = comboBox2.Text.ToString().Trim();

            int capacity = int.Parse(comboBox1.Text.ToString().Trim());
            string status = comboBox3.Text.ToString().Trim();

            Rooms r = new Rooms();
            int roomID = (int)r.getRoomID(RoomNumber);


            Hostelbuildings hb = new Hostelbuildings();
            int buildingID = (int)hb.GetBuildingID(BuildingName);





            Rooms rooms  = new Rooms(roomTypeID, roomID, BuildingName, capacity, status, RoomTypeName,buildingID, RoomNumber);
            bool flag = rooms.UpdateRoom(rooms);

            if (flag)
            {
                MessageBox.Show("Room Data Updated SuccessFully");
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void loadRooms()
        {
            Rooms r = new Rooms();
            object countRooms = r.getTotalRooms();
            textBox1.Text = countRooms.ToString(); // Convert object to string
        }


        private void LoadAvailableRooms()
        {
            Rooms r = new Rooms();
            object countRooms = r.getRoomsAvailable();
            textBox2.Text = countRooms.ToString(); // Convert object to string
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}