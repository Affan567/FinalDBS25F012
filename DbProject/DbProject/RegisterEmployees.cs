using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll;
using dll.BL;

namespace DbProject
{
    public partial class RegisterEmployees : PapaForm
    {
        public RegisterEmployees()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            Servant r = new Servant();
            DataTable dt = r.GetServantData();

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
    }
}
