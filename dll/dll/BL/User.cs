using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dll.DL;

namespace dll.BL
{
    public class User
    {
        protected int userid;
        protected string username;
        protected string password;
        protected int roleID;
        protected string name;
        protected string email;
        protected string contact;
        protected string gender;

        public User(string username, string password, string name, string email, string contact, int roleID)
        {
            SetPassword(password);
            SetPhone(contact);
            SetName(name);
            SetEmail(email);
            SetUsername(username);
            this.roleID = roleID;

        }
        public User(int userid ,string username, string password, string name, string email, string contact, string gender)
        {
            this.userid = userid;
            SetPassword(password);
            SetPhone(contact);
            SetName(name);
            SetEmail(email);
            SetUsername(username);
            this.gender = gender;

            

        }

        public User(string username, string password , string name, string email, string contact)
        {
            
            this.username = username;
            this.password = password;
            this.name = name;
            this.email = email;
            this.contact = contact;
            
        }

        public bool AddUser(string Password, string Username, string Email,  string Phone,  int roleID ,string Name )
        {
            bool flag = DL.User.AddUsertoDB(Password, Username, Email, Phone, Name , roleID);
            return flag;
        }

        public DataTable GetUsersTable()
        {
            DataTable dt = DL.User.GetAllUsers();
            return dt;
        }

        public bool UpdateUser(int UserID, string Password, string Username, string Email,  string Phone, string Name)
        {
            bool flag = DL.User.UpdateUsertoDB(UserID, Password,  Username, Email,  Phone,  Name);
            return flag;
        }

        //public string GetUserRole(string username, string hashedPassword)
        //{
        //    DL.User dl = new DL.User();
        //    return dl.GetUserRoleFromDB(username, hashedPassword);
        //}

        public int GetUserID(string username, string Password)
        {
            DL.User dl = new DL.User();
            return dl.GetUserIDFromDB(username, Password);
        }
        public User()
        {

        }
        public string getName()

        {
            return name;
        }
        public string getEmail()

        {
            return email; 
        }
        
        public string getcontact()
        {
            return contact;
        }
        public string getUsername()
        {
            return username;
        }

        public string getpassword()
        {
            return password;
        }
        public int UserID()
        {
            return userid;
        }
        public int RoleID()
        {
            return roleID;
        }

        public string getGender()
        {
            return gender;
        }
        public void SetPassword(string Password)
        {
            if (Password.Length < 8 && Password.Length > 20)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            if (!Password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter.");
            }

            if (!Password.Any(char.IsLower))
            {
                throw new ArgumentException("Password must contain at least one lowercase letter.");
            }

            if (!Password.Any(char.IsDigit))
            {
                throw new ArgumentException("Password must contain at least one digit.");
            }

            if (!Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ArgumentException("Password must contain at least one special character.");
            }

            this.password = Password;
        }

        public void SetUsername(string Username)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                throw new ArgumentException("Username cannot be empty.");
            }

            if (Username.All(c => char.IsDigit(c) || c == '.' || !char.IsLetterOrDigit(c)))
            {
                throw new ArgumentException("Username must not consist of only digits, dots, or special characters.");
            }

            this.username = Username;
        }


        public void SetEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            // Regular expression to match basic email format (you can adjust it to be more restrictive if needed)
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(Email, emailPattern))
            {
                throw new ArgumentException("Email is not in a valid format.");
            }

            this.email = Email;
        }

        public void SetPhone(string Phone)
        {
            if (Phone.Length != 11)
            {
                throw new ArgumentException("Phone No must be exactly 11 digits long.");
            }

            if (!Phone.All(char.IsDigit))
            {
                throw new ArgumentException("Phone No must contain only numeric digits.");
            }
            this.contact = Phone;
        }

        public void SetName(string Name)
        {
            Regex regex = new Regex(@"^\D*$"); // ^ means start, \D* means any non-digit characters, $ means end
            if (!regex.IsMatch(Name))
            {
                throw new ArgumentException("Name consists of alphabets only.");
            }
            this.name = Name;
        }

        public object GetUserRole(string username , string password)
        {
            return DL.User.getuser(username, password);
            
        }

        public object getNameFromDB(int userID)
        {

            return DL.User.GettingName(userID);
        }

        public static object GetStudentID(int userID)
        {
            return DL.User.gettingStudentID(userID);
        }

        public object GetEmployees()
        {
            DL.User u = new DL.User();
            return u.GetEmployeesCount();
        }
    }
}
