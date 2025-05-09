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
using dll.BL;

namespace DbProject
{
    public partial class ManageStudents : PapaForm
    {
        public ManageStudents()
        {
            InitializeComponent();
        }



        private void LabelBuildingsCount_Click(object sender, EventArgs e)
        {

        }

        private void codedButton2_Click(object sender, EventArgs e)
        {

            
                string Studentname = textBox4.Text.ToString().Trim();
                string StudentContact = textBox1.Text.ToString().Trim();
                string Studentemail = textBox6.Text.ToString().Trim();
                string StudentReg = textBox7.Text.ToString().Trim();
                int Semester = int.Parse(numericUpDown1.Text.Trim());
                int roomNumber = int.Parse(comboBox3.Text.ToString().Trim());

                string StudentUsername = textBox3.Text.ToString().Trim();
                string StudentPassword = textBox2.Text.ToString().Trim();



                //    Student h = new Student(Studentname , StudentContact ,Studentemail ,2, StudentReg , Semester , roomNumber);



                //    Hostelbuildings building = new Hostelbuildings(buildingname, floors, rooms, wardenID, status);
                //    bool flag = building.AddHostelBuilding(building);

                //    if (flag)
                //    {
                //        MessageBox.Show("Building Added SuccessFully");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("An error occurred: " + ex.Message);
                //}

            } 

    }
}
