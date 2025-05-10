using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class WardenViewProfile : Form
    {
        private int wardenId;

        public WardenViewProfile(int wardenId)
        {
            InitializeComponent();
            this.wardenId = wardenId;
            LoadWardenProfile();
        }

        private void LoadWardenProfile()
        {
            string query = "select name,email,contact,AssignedBuildingID from users natural join hostelwarden WHERE WardenID = @WardenID";
            var param = new MySqlParameter("@WardenID", wardenId);

            try
            {
                using (var reader = DBHelper.ExecuteReader(query, param))
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["WardenName"].ToString();
                        textBox2.Text = reader["Email"].ToString();
                        textBox3.Text = reader["PhoneNumber"].ToString();
                        textBox4.Text = reader["AssignedBuilding"].ToString();

                        dataGridView1.Rows.Add(
                            reader["WardenName"],
                            reader["Email"],
                            reader["PhoneNumber"],
                            reader["AssignedBuilding"]
                        );
                    }
                    else
                    {
                        MessageBox.Show("Warden profile not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }
    }
}
