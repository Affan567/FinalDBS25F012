using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll.BL;

namespace DbProject
{
    public partial class SignIN : Form
    {
        public SignIN()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            
                //LogIN Button Implementaion            
                string username = txtusername.Text.Trim(); // Removes extra spaces
                string password = txtpassword.Text.Trim();

                // Check if username or password is empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }
                User user = new User();
                var role = user.GetUserRole(username, password);
                var UserID = (int?)user.GetUserID(username, password);

                if (role != null && UserID != null)
                {
                    Login.SetUsername((string)username);
                    Login.SetUserID((int)UserID);
                }

                // Authenticate the user with the database            
                if (role != null && (string)role == "Admin")
                {
                    MessageBox.Show("Login successful!");
                    AdminDashboard admin = new AdminDashboard();
                    admin.Show();
                    this.Hide();
                }
                else if (role != null && (string)role == "Student")
                {
                    MessageBox.Show("Login successful!");
                    StudentProfileForm student = new StudentProfileForm();
                    student.Show();
                    this.Hide();
                }
                else if (role != null && (string)role == "hostelwarden")
                {
                    MessageBox.Show("Login successful!");
                    WardenPanel student = new WardenPanel();
                    student.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials or incorrect password.");
                }
            
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }
    }
    }

