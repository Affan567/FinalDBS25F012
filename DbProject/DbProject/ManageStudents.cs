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
            bindRoomNumber();
            LoadData();
            loadTotalBuildings();
            loadRegisteredStudents();

        }

        private void LoadData()
        {
            Student h = new Student();
            DataTable dt = h.GetStudents();

            dataGridView1.DataSource = dt;

            if (!dataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.HeaderText = "Delete Building";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.DefaultCellStyle.BackColor = Color.Red;
                btnDelete.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                dataGridView1.Columns.Add(btnDelete);
            }
        }

        


        
        private void loadRegisteredStudents()
        {
            Student s = new Student();
            object countStudents = s.getTotalStudents();
            label3.Text = countStudents.ToString(); // object int to string
        }

        private void loadTotalBuildings()
        {
            Hostelbuildings h = new Hostelbuildings();
            object countStudents = h.getTotalBuildins();
            LabelBuildingsCount.Text = countStudents.ToString(); // object int to string
        }

        private void LabelBuildingsCount_Click(object sender, EventArgs e)
        {

        }

        private void bindRoomNumber()
        {
            Rooms room = new Rooms();
            List<object> rooms = room.GetRoomNumbers();


            comboBox3.DataSource = rooms;
            comboBox3.SelectedIndex = -1;
        }
        private void codedButton2_Click(object sender, EventArgs e)
        {


            string Studentname = textBox4.Text.ToString().Trim();
            string StudentContact = textBox1.Text.ToString().Trim();
            string Studentemail = textBox6.Text.ToString().Trim();
            string StudentReg = textBox7.Text.ToString().Trim();
            string Semester = numericUpDown1.Text.Trim();
            int roomNumber = int.Parse(comboBox3.Text.Trim());



            string StudentUsername = textBox3.Text.ToString().Trim();
            string StudentPassword = textBox2.Text.ToString().Trim();

            Rooms r = new Rooms();
            int roomID = (int)r.getRoomID(roomNumber);


            Student s = new Student(Studentname, StudentContact, Studentemail, 2, StudentReg, Semester, roomID, StudentUsername, StudentPassword);

            if (s.AddStudent(s))
            {
                MessageBox.Show("Student Added Successfully");
            }
            else
            {
                MessageBox.Show("An error occurred: ");
            }

            LoadData();



        }

        private void codedButton3_Click(object sender, EventArgs e)
        {

            string Studentname = textBox4.Text.ToString().Trim();
            string StudentContact = textBox1.Text.ToString().Trim();
            string Studentemail = textBox6.Text.ToString().Trim();
            string StudentReg = textBox7.Text.ToString().Trim();
            string Semester = numericUpDown1.Text.Trim();
            int roomNumber = int.Parse(comboBox3.Text.ToString().Trim());

            string StudentUsername = textBox3.Text.ToString().Trim();
            string StudentPassword = textBox2.Text.ToString().Trim();


            Student stu = new Student();
            int userID = stu.GetUserID(StudentUsername, StudentPassword);

            int studentID = (int)stu.GettingstudentID(userID);

            Rooms room = new Rooms();
            int roomid = (int)room.getRoomID(roomNumber);





            Student student = new Student(userID, studentID, Studentname, StudentContact, Studentemail, StudentReg, Semester, roomid, StudentUsername, StudentPassword,2);
            bool flag = student.UpdateStudent(student);

            if (flag)
            {
                MessageBox.Show("Student Data Updated SuccessFully");
            }
        }

        private void codedButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["btnDelete"].Index)
                return;


            int Studentid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value);
            int userid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["userID"].Value);


            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Student s = new Student();
                if (s.DeleteStudent(Studentid, userid))
                {
                    MessageBox.Show("Row Deleted SuccessFully");
                }
                else
                {
                    MessageBox.Show("Can't deleted ");
                }

                LoadData();

                bindRoomNumber();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}