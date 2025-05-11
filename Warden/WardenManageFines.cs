using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DbProject
{
    public partial class ManageFines : Form
    {
        public ManageFines()
        {
            InitializeComponent();
            LoadFineReasons();
            SetupRadioButtons();
        }

        private void LoadFineReasons()
        {
            string query = "SELECT RuleID, Description FROM hostelrules";
            DataTable dt = DBHelper.GetData(query);
            cmbReason.DisplayMember = "Description";
            cmbReason.ValueMember = "RuleID";
            cmbReason.DataSource = dt;
        }

        private void SetupRadioButtons()
        {
            radioPaid.CheckedChanged += RadioButtons_CheckedChanged;
            radioUnpaid.CheckedChanged += RadioButtons_CheckedChanged;

            radioPaid.Checked = true; 
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == radioPaid && radioPaid.Checked)
                radioUnpaid.Checked = false;
            else if (sender == radioUnpaid && radioUnpaid.Checked)
                radioPaid.Checked = false;
        }


        private void buttonserach_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(richTextBox2.Text, out int studentId))
            {
                MessageBox.Show("Enter valid Student ID.");
                return;
            }

            LoadFinesByStudentId(studentId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(richTextBox2.Text, out int studentId))
            {
                MessageBox.Show("Enter valid Student ID.");
                return;
            }

            if (cmbReason.SelectedValue == null)
            {
                MessageBox.Show("Please select a fine reason.");
                return;
            }

            string status = radioPaid.Checked ? "Paid" : "Unpaid";
            int ruleId = Convert.ToInt32(cmbReason.SelectedValue);
            DateTime date = dateTimePicker1.Value;

            // Fetch FineAmount from hostelrules
            string amountQuery = "SELECT FineAmount FROM hostelrules WHERE RuleID = @RuleID";
            object result = DBHelper.ExecuteScalar(amountQuery, new MySqlParameter("@RuleID", ruleId));
            decimal fineAmount = result != null ? Convert.ToDecimal(result) : 0;

            // Insert into damagerecords
            string insertQuery = @"INSERT INTO damagerecords (StudentID, RuleID, FineAmount, Date, Status) 
                                   VALUES (@StudentID, @RuleID, @FineAmount, @Date, @Status)";

            DBHelper.ExecuteQuery(insertQuery,
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@RuleID", ruleId),
                new MySqlParameter("@FineAmount", fineAmount),
                new MySqlParameter("@Date", date),
                new MySqlParameter("@Status", status));

            MessageBox.Show("Fine saved.");
            LoadFinesByStudentId(studentId);
        }

        private void LoadFinesByStudentId(int studentId)
        {
            string query = @"SELECT dr.StudentID, hr.Description AS FineReason, hr.FineAmount, dr.Date, dr.Status
                     FROM damagerecords dr
                     JOIN hostelrules hr ON dr.RuleID = hr.RuleID
                     WHERE dr.StudentID = @StudentID";
            DataTable dt = DBHelper.GetData(query, new MySqlParameter("@StudentID", studentId));
            dataGridView1.DataSource = dt;
        }
    }
}
