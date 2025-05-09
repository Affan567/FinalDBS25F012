using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DL
{
    public class Warden
    {


        public Warden() { } 
        public object GettingWardenID(string wardenUserName)
        {
            string query = "Select w.WardenID from hostelwarden w join users u on w.userID = u.userID where username = '{0}'";
            query = String.Format(query, wardenUserName);   
            return DatabaseHelper.ExecuteScalar(query);
        }





        


        public List<object> GetWardenNamesFromDB()
        {
            string columnName = "username";
            string query = "Select username from users u join roles r on u.role_id = r.RoleID where r.RoleName = '{0}'";
            query = String.Format(query,"Warden");
            List<object> WardenNames = DatabaseHelper.GetColumnValues(query, columnName);
            return WardenNames;
        }
    }

}
