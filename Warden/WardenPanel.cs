using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class WardenPanel : Form
    {
        public WardenPanel()
        {
            InitializeComponent();
            LoadDashboardStats();
        }

        public void LoadDashboardStats()
        {
            try
            {
                richTextBox2.Text = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM students");
                richTextBox3.Text = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM visitors");
                richTextBox4.Text = DBHelper.ExecuteScalar("SELECT COUNT(DISTINCT RoomID) FROM roomallocation");
                richTextBox5.Text = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM studentfees WHERE DueDate < CURDATE() AND PaidStatus = 'Unpaid'");
                richTextBox1.Text = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM complaints WHERE Status = 'Pending'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard stats: " + ex.Message);
            }
        }
    }
}
