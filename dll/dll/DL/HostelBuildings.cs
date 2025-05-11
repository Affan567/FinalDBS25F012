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
        public bool Addbuildings(string name ,int rooms, int floors, string status, int wardenID)
        {
            string query = "call InsertHostelBuilding('{0}',{1},{2},{3},'{4}')";
            query = String.Format(query , name ,floors, rooms,wardenID, status);
            int rowsaffected = DatabaseHelper.executeDML(query);
            return rowsaffected > 0;
        }

        public static bool Deletebuildings(int buildingid)
        {


            string query = "Delete * from hostelbuildings where BuildingID = {buildingid} ";
            int rowsAffected = DatabaseHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public bool UpdateBuilding(int buildingid, string buildingName, int rooms, int floors, string status,int wardenID)
        {
            string query = "call UpdateHostelBuilding({0},'{1}',{2},{3},'{4}',{5})";
            query = String.Format(query, buildingid,buildingName, floors, rooms, status,wardenID);
            int rowsaffected = DatabaseHelper.executeDML(query);
            return rowsaffected > 0;


        }

        public object GetIDBuilding(string buildingNameBefore)
        {
            string query = "Select BuildingID from hostelbuildings where BuildingName = '{0}'";
            query = string.Format(query, buildingNameBefore);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public DataTable GetHosteBuildingTable()
        {
            string query = "Select h.BuildingID , h.BuildingName , h.Floors , h.Rooms ,w.WardenID as WardenID ,h.Status , u.name from hostelbuildings h join hostelwarden w on h.WardenID = w.WardenID join users u on w.userID = u.userID ";
            query = String.Format (query);
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
            string query = "Select BuildingName from buildingdataview";
            query = String.Format(query);
            List<object> BuildingNames = DatabaseHelper.GetColumnValues(query, columnName);
            return BuildingNames;
        }
    }
}
