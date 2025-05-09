using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.BL;

namespace dll.DL
{
    public class HostelBuildings
    {

        public HostelBuildings() { }
        public bool Addbuildings(string name , int rooms , int floors , string status , int wardenID)
        {
            string query = "Insert into hostelbuildings (BuildingName , Floors ,Rooms,WardenID,Status) values ('{0}',{1},{2},{3},'{4}')";
            query = String.Format(query , name , rooms,floors,wardenID, status);
            int rowsaffected = DatabaseHelper.executeDML(query);
            return rowsaffected > 0;
        }

        public static bool Deletebuildings(int buildingid)
        {
            string query = "Delete * from hostelbuildings where BuildingID = {buildingid} ";
            int rowsAffected = DatabaseHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public bool UpdateBuilding(int buildingid, string buildingName, int rooms, int floors, string status, int wardenID)
        {
            string query = "Update Hostelbuildings set BuildingName = '{0}', Floors = {1}, Rooms = {2},  WardenID = {3}, Status = '{4}'  where BuildingID = {5}";
            query = String.Format(query, buildingName, floors, rooms, wardenID,status,buildingid);
            int rowsaffected = DatabaseHelper.executeDML(query);
            return rowsaffected > 0;


        }

        public object GetIDBuilding(string buildingNameBefore)
        {
            string query = "Select BuildingID from hostelbuildings ";
            query = string.Format(query, buildingNameBefore);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public DataTable GetHosteBuildingTable(int userID)
        {
            string query = "Select h.BuildingID , h.BuildingName , h.Floors , h.Rooms ,h.WardenID as WardenID ,h.Status  from hostelbuildings h join hostelwarden w join users u where u.userID = {0}";
            query = String.Format (query, userID);
            return DatabaseHelper.getDataTable(query);

        }

        public bool DelHostel(int buildingid)
        {
            string query = "Delete from hostelbuildings where BuildingID = {0} ";
            query = String.Format(query , buildingid);
            int rowsAffected = DatabaseHelper.executeDML(query );
            return rowsAffected > 0;
        }

        public object getBuildingsCount()
        {
            string query = "Select Count(BuildingID) from hostelbuildings ";
            query = String.Format(query);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public List<object> GetBuildingNamesFromDB()
        {
            string columnName = "BuildingName";
            string query = "Select BuildingName from hostelbuildings ";
            query = String.Format(query);
            List<object> BuildingNames = DatabaseHelper.GetColumnValues(query, columnName);
            return BuildingNames;
        }
    }
}
