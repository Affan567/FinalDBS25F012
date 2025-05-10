using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dll.BL;

namespace dll.DL
{
    internal class Rooms
    {


        public static DataTable viewRoomsData()
        {
            string query = "Select RoomID , RoomNumber,Status  From rooms";
            DataTable dt = DatabaseHelper.getDataTable(query);
            return dt;
        }


        public static object getTotalRoomsFromDB()
        {
            string query = "Select Count(RoomID) from rooms";
            query = String.Format(query);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public static DataTable ViewRoom(int userID)
        {
            string status = "Available";
            string query = "SELECT r.RoomNumber ,r.Status,h.BuildingName , u.name as StudentName FROM rooms as r join hostelbuildings as h on r.buildingID = h.BuildingID join roomservants as rs on r.RoomID = rs.roomID join users as u on rs.userID = u.userID Where r.Status = '{0}'";
            query = String.Format(query, status);
            return DatabaseHelper.getDataTable(query);
        }


        public object RoomsOccupied()
        {
            string status = "Occupied";
            string query = "Select Count(RoomID) from rooms where Status = '{0}'";
            query = String.Format(query , status);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public object gettingRoomID(int roomNumber)
        {
            string query = "Select RoomID from rooms where RoomNumber = {0}";
            query = string.Format(query, roomNumber);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public List<object> GetRoomNumbersFromDB()
        {
            string columnName = "RoomNumber";
            string query = "Select RoomNumber from rooms";
            query = String.Format(query, "RoomNumber");
            List<object> WardenNames = DatabaseHelper.GetColumnValues(query, columnName);
            return WardenNames;
        }

        public bool AddRoom(BL.Rooms r)
        {
            string insertQuery = "INSERT INTO student(RoomNumber, RoomTypeID, Status,BuildingID) " +
                                 "VALUES ('{0}', {1}, {2}, {3})";
            insertQuery = string.Format(insertQuery, r.GetRoomNumber(), r.getRommtypeID(), r.GetStatus() , r.GetBuildingID());

            int rowsAffected = DatabaseHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GettingRoomData()
        {
            string query = "Select r.RoomNumber , r.Status ,rt.TypeName , rt.Capacity from rooms r join roomtype as rt on r.RoomTypeID = rt.RoomTypeID ";
            query = String.Format(query);
            return DatabaseHelper.getDataTable(query);
        }

        public List<object> GetBuildingRoomIDFromDB()
        {
            string columnName = "RoomID";
            string query = "Select RoomID from rooms";
            query = String.Format(query, "RoomID");
            List<object> WardenNames = DatabaseHelper.GetColumnValues(query, columnName);
            return WardenNames;

        }
    }
}
