using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class WardenComplaints : Form
    {
        public WardenComplaints()
        {
            InitializeComponent();
        }
        private void UpdateComplaintStatus(string newStatus)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a complaint first.");
                return;
            }

            int complaintId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["complaintid"].Value);

            string query = "UPDATE complaints SET status = @Status WHERE complaintid = @ComplaintID";
            var parameters = new[]
            {
                new MySqlParameter("@Status", newStatus),
                new MySqlParameter("@ComplaintID", complaintId)
            };

            DBHelper.executeNonQuery(query, parameters);

            MessageBox.Show($"Complaint has been {newStatus.ToLower()}.");
            buttonserach.PerformClick();
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(richTextBox1.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Enter a valid Student ID.");
                return;
            }

            string query = @"SELECT complaintid, studentid, complaintdate, description, status 
                             FROM complaints 
                             WHERE studentid = @StudentID";

            var param = new MySqlParameter("@StudentID", studentId);
            DataTable dt = DBHelper.executeSelect(query, param);
            dataGridView1.DataSource = dt;
        }

        private void buttonapprove_Click(object sender, EventArgs e)
        {
            UpdateComplaintStatus("Approved");
        }

        private void buttonreject_Click(object sender, EventArgs e)
        {
            UpdateComplaintStatus("Rejected");
        }
    }
}

