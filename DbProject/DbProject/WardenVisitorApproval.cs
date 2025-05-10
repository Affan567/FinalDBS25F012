using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class WardenVisitorApproval : Form
    {;
        public WardenVisitorApproval()
        {
            InitializeComponent();
        }

        private void UpdateVisitorStatus(string newStatus)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a visitor request first.");
                return;
            }

            int visitorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["VisitorID"].Value);

            string query = "UPDATE visitors SET Status = @Status WHERE VisitorID = @VisitorID";
            var parameters = new[]
            {
                new MySqlParameter("@Status", newStatus),
                new MySqlParameter("@VisitorID", visitorId)
            };

            DBHelper.executeNonQuery(query, parameters);

            MessageBox.Show($"Visitor request has been {newStatus.ToLower()}.");
            buttonsearch.PerformClick(); 
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(richTextBox1.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Enter a valid Student ID.");
                return;
            }

            string query = @"SELECT VisitorID, VisitorName, VisitDate, VisitTime, Purpose, Status 
                             FROM visitors 
                             WHERE StudentID = @StudentID";

            var param = new MySqlParameter("@StudentID", studentId);
            DataTable dt = DBHelper.executeSelect(query, param);
            dataGridView1.DataSource = dt;
        }

        private void buttonapprove_Click(object sender, EventArgs e)
        {
            UpdateVisitorStatus("Approved");
        }

        private void buttonreject_Click(object sender, EventArgs e)
        {
            UpdateVisitorStatus("Rejected");
        }

        OpenForm OpenForm = new OpenForm();
        
    }
}
