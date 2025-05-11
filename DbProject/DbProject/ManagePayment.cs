using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DbProject
{
    public partial class ManagePayment : PapaForm
    {
        public ManagePayment()
        {
            InitializeComponent();
        }

        private void ManagePayment_Load(object sender, EventArgs e)
        {

        }

        private void codedButton3_Click(object sender, EventArgs e)
        {
            //string buildingNameBefore = comboBox3.Text.ToString().Trim();
            //string buildingnameAfter = textBox1.Text.ToString().Trim();
            //string Buildingwarden = comboBox1.Text.ToString().Trim();
            //int floors = int.Parse(numericUpDown2.Text.Trim());
            //int rooms = int.Parse(numericUpDown1.Text.ToString().Trim());
            //string status = comboBox2.Text.ToString().Trim();


            //Hostelbuildings hb = new Hostelbuildings();
            //int buildingID = (int)hb.GetBuildingID(buildingNameBefore);


            //Warden h = new Warden();
            //int wardenID = (int)h.GetWardenID(Buildingwarden);


            //Hostelbuildings building = new Hostelbuildings(buildingID, buildingnameAfter, floors, rooms, wardenID, status);
            //bool flag = building.UpdateBuildings(building);

            //if (flag)
            //{
            //    MessageBox.Show("Building Updated SuccessFully");
            //}
        }
    }
}
