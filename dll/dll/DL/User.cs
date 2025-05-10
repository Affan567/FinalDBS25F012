using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dll.BL;

namespace dll.DL
{
    public class User
    {

        static public DataTable GetAllUsers()
        {
            string query = "Select * From users";
            DataTable usersTable = DatabaseHelper.getDataTable(query);
            return usersTable;
        }

        static public bool DeleteUserFromDB(int UserId)
        {
            string query = "Delete From users Where UserID = {UserId}";
            int rowsAffected = DatabaseHelper.executeDML(query);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

         public static bool AddUsertoDB(string Password, string Username, string Email, string Phone,string Name , int roleID)
        {
            

            string insertusersquery = "$Insert into users (username , password ,role_id ,name,email,contact) Values ('{0}' , '{1}' ,{2} , '{3}','{4}','{5}')";
           insertusersquery = String.Format(insertusersquery ,Username ,Password ,roleID, Name,Email,Phone);
            int rowsaffected2 = DatabaseHelper.executeDML(insertusersquery);
            return rowsaffected2 > 0;
            


        }
        //public string GetUserRoleFromDB(string username, string Password)
        //{
        //    string query = "Select RoleName From roles as r join users as u on r.role_id = u.role_id Where username = '{0}' AND password = '{1}'";
        //    query = String.Format(query, username, Password);
        //    object role = DatabaseHelper.ExecuteScalar(query);
        //    return role.ToString();
        //}

        public int GetUserIDFromDB(string username, string Password)
        {
            string query = "Select UserID From users Where username = '{0}'AND password = '{1}'";
            query = String.Format(query, username, Password);
            object ID = DatabaseHelper.ExecuteScalar(query);
            return (int)ID;
        }

        static public bool UpdateUsertoDB(int UserID, string Username, string Password, int roleID , string Email,string Phone, string Name)
        {
            string updateQuery = "UPDATE users SET password = '{0}',username = '{1}', role_id = {2} ,email = '{3}', contact = '{4}',name = '{5}' Where userID = {6}";
            updateQuery = String.Format(updateQuery, Username, Password, roleID,Email, Phone,  Name,UserID);
            int rowsAffected = DatabaseHelper.executeDML(updateQuery);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public static object getuser(string username , string password)
        {
            string query = "Select RoleName from roles r join users u on r.RoleID = u.role_id where u.username = '{0}' And u.password = '{1}'";
            query = String.Format(query, username, password);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public static object GettingName(int userID)
        {
            string query = "Select name from users where userID = {0}"; 
            query = String.Format(query ,userID);
            return DatabaseHelper.ExecuteScalar(query);

        }

        public static object gettingStudentID(int userID)
        {
            string query = "Select StudentID from students where userID = {0}";
            query = String.Format(query ,userID);
            return DatabaseHelper.ExecuteScalar(query);
        }
        public object GetEmployeesCount()
        {
            string role1 = "Warden";
            string role2 = "Servant";
            string query = "Select Count(userID) from users as u join roles as r on u.role_id = r.RoleID where r.RoleName = '{0}' OR r.RoleName = '{1}'";
            query = String.Format(query, role1, role2);
            return DatabaseHelper.ExecuteScalar(query);
        }
    }
}
