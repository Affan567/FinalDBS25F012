using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class WardenStudentFees : Form
    {
        public WardenStudentFees()
        {
            InitializeComponent();
        }

        private void buttonserach_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(richTextBox1.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Enter a valid Student ID.");
                return;
            }

            string query = "SELECT FeeID, StudentID, Amount, DueDate, Status FROM studentfees WHERE StudentID = @StudentID";
            var param = new MySqlParameter("@StudentID", studentId);

            DataTable dt = DBHelper.ExecuteSelect(query, param);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a record to mark as paid.");
                return;
            }

            int feeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);
            string query = "UPDATE studentfees SET Status = 'Paid' WHERE StudentID = @StudentID";
            var param = new MySqlParameter("@FeeID", feeId);

            DBHelper.ExecuteNonQuery(query, param);
            MessageBox.Show("Fee marked as paid.");
            buttonserach.PerformClick();

        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a record to edit.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            int feeId = Convert.ToInt32(row.Cells["FeeID"].Value);
            decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);
            DateTime dueDate = Convert.ToDateTime(row.Cells["DueDate"].Value);
            string status = row.Cells["Status"].Value.ToString();

            string query = @"UPDATE studentfees 
                             SET Amount = @Amount, DueDate = @DueDate, Status = @Status 
                             WHERE FeeID = @FeeID";

            var parameters = new[]
            {
                new MySqlParameter("@Amount", amount),
                new MySqlParameter("@DueDate", dueDate),
                new MySqlParameter("@Status", status),
                new MySqlParameter("@FeeID", feeId)
            };

            DBHelper.ExecuteNonQuery(query, parameters);
            MessageBox.Show("Fee record updated.");
            buttonserach.PerformClick();

        }

        private void buttonrecord_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a record to delete.");
                return;
            }

            int feeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);
            string query = "DELETE FROM studentfees WHERE StudentID = @StudentID";
            var param = new MySqlParameter("@FeeID", feeId);

            DBHelper.ExecuteNonQuery(query, param);
            MessageBox.Show("Fee record deleted.");
            buttonserach.PerformClick();
        }
    }
}
