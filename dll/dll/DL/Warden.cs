using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.BL;

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

        public DataTable gettingWardenDate()
        {
            string query = "Select u.name, u.contact ,u.username ,u.password ,h.BuildingName,w.WardenID,u.userID From users as u join hostelwarden as w on u.userID = w.userID join hostelbuildings as h on w.AssignedBuildingID = h.BuildingID";
            DataTable wardenTable = DatabaseHelper.getDataTable(query);
            return wardenTable;
        }




        public bool DeleteWardenFromDB(int Wardenid, int userid)
        {
            List<string> queries = new List<string>();


            string query1 = "Delete from payments where WardenID = {0}";
            query1 = String.Format(query1, Wardenid);
            string query2 = "Delete From hostelwarden Where WardenID = {0}";
            query2 = String.Format(query2, Wardenid);

            string query3 = "Delete From users Where userID = {0}";
            query3 = String.Format(query3, userid);


            queries.Add(query1);
            queries.Add(query2);
            queries.Add(query3);
            

            bool rowsAffected = DatabaseHelper.ExecuteTransaction(queries);

            if (rowsAffected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public List<object> GetWardenNamesFromDB()
        {
            string columnName = "username";
            string query = "Select username from users u join roles r on u.role_id = r.RoleID where r.RoleName = '{0}'";
            query = String.Format(query,"Warden");
            List<object> WardenNames = DatabaseHelper.GetColumnValues(query, columnName);
            return WardenNames;
        }

        public bool AddWardenToDB(BL.Warden w)
        {
            string insertQuery = "INSERT INTO hostelwarden(AssignedBuildingID , userID) " +
                                 "VALUES ({0}, {1})";
            insertQuery = string.Format(insertQuery, w.GetBuildingID(), w.UserID());

            int rowsAffected = DatabaseHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }
        public object getWardenID(int userID)
        {
            string query = "Select WardenID from hostelwarden where userID = {0}";
            query = String.Format(query, userID);
            return DatabaseHelper.ExecuteScalar(query);
        }


        public bool UpdateWardenInDB(BL.Warden w)
        {
            string updateQuery = "UPDATE hostelwarden SET AssignedBuildingID = {0} Where userID = {1}";
            updateQuery = string.Format(updateQuery, w.GetBuildingID(),w.UserID());

            int rowsAffected = DatabaseHelper.executeDML(updateQuery);
            return rowsAffected > 0;

        }
    }

}
