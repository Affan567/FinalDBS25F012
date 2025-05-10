using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class StudentRoomAllocation : Form
    {
        public StudentRoomAllocation()
        {
            InitializeComponent();
            LoadStudentData();
            LoadRoomData();
            LoadAllocationData();
        }

        private void LoadStudentData()
        {
            string query = "SELECT userID, name, email, contact, username, password FROM users WHERE role_id = 2";
            DataTable dt = DBHelper.executeSelect(query, null);
            comboBoxStudents.DisplayMember = "name";
            comboBoxStudents.ValueMember = "userID";
            comboBoxStudents.DataSource = dt;
        }

        private void LoadRoomData()
        {
            string query = "SELECT RoomID, RoomNumber FROM rooms WHERE Status = 'Available'";
            DataTable dt = DBHelper.executeSelect(query, null);
            comboBoxRooms.DisplayMember = "RoomNumber";
            comboBoxRooms.ValueMember = "RoomID";
            comboBoxRooms.DataSource = dt;
        }

        private void comboBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedValue != null)
            {
                int userId = (int)comboBoxStudents.SelectedValue;
                string query = "SELECT name, email, contact, username, password FROM users WHERE userID = @userID";
                var param = new MySqlParameter("@userID", userId);
                DataTable dt = DBHelper.executeSelect(query, param);

                if (dt.Rows.Count > 0)
                {
                    textBox2.Text = dt.Rows[0]["email"].ToString();
                    textBox3.Text = dt.Rows[0]["contact"].ToString();
                    textBox4.Text = dt.Rows[0]["username"].ToString();
                    textBox5.Text = dt.Rows[0]["password"].ToString();
                }
            }
        }

        private void LoadAllocationData()
        {
            string query = @"
            SELECT u.userID, u.name, u.email, u.contact, u.username, r.RoomNumber
            FROM rooms r
            JOIN users u ON r.UserID = u.userID
            WHERE r.Status = 'Occupied'";
            DataTable dt = DBHelper.executeSelect(query, null);
            dataGridView1.DataSource = dt;
        }

        private void buttonallocate_Click_1(object sender, EventArgs e)
        {
            if (comboBoxRooms.SelectedValue == null || comboBoxStudents.SelectedValue == null)
            {
                MessageBox.Show("Please select a student and a room.");
                return;
            }

            int roomId = (int)comboBoxRooms.SelectedValue;

            string query = "UPDATE rooms SET Status = 'Occupied' WHERE RoomID = @RoomID";
            var param = new MySqlParameter("@RoomID", roomId);

            DBHelper.executeNonQuery(query, new[] { param });
            MessageBox.Show("Room allocated successfully.");

            LoadRoomData();
            LoadAllocationData();
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a record to edit.");
                return;
            }

            int selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["userID"].Value);
            int newRoomId = (int)comboBoxRooms.SelectedValue;

            string resetQuery = "UPDATE rooms SET Status = 'Available', UserID = NULL WHERE UserID = @UserID";
            var resetParam = new MySqlParameter("@UserID", selectedUserId);
            DBHelper.executeNonQuery(resetQuery, new[] { resetParam });

            string assignQuery = "UPDATE rooms SET Status = 'Occupied', UserID = @UserID WHERE RoomID = @RoomID";
            var assignParams = new[]
            {
        new MySqlParameter("@UserID", selectedUserId),
        new MySqlParameter("@RoomID", newRoomId)
    };
            DBHelper.executeNonQuery(assignQuery, assignParams);

            MessageBox.Show("Room allocation updated.");
            LoadRoomData();
            LoadAllocationData();
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an allocation record to delete.");
                return;
            }

            string roomNumber = dataGridView1.SelectedRows[0].Cells["RoomNumber"].Value.ToString();
            string query = "UPDATE rooms SET Status = 'Available' WHERE RoomNumber = @RoomNumber";
            var param = new MySqlParameter("@RoomNumber", roomNumber);
            DBHelper.executeNonQuery(query, new[] { param });

            MessageBox.Show("Room deallocated successfully.");
            LoadRoomData();
            LoadAllocationData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
