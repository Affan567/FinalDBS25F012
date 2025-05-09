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
        public object GetWardenID(string wardenUserName)
        {
            string query = "Select WardenID from hostelwarden w join users u on w.userID = u.userID";
            query = String.Format(query, wardenUserName);   
            return DatabaseHelper.ExecuteScalar(query);
        }





        


        public List<object> GetWardenNamesFromDB()
        {
            string columnName = "Warden";
            string query = "Select username from users u join roles r where r.RoleName = '{0}'";
            List<object> WardenNames = DatabaseHelper.GetColumnValues(query, columnName);
            return WardenNames;
        }
    }

}
