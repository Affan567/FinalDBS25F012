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
            string query = "SELECT r.RoomNumber ,r.Status,h.BuildingName , u.name as ServantName FROM rooms as r join hostelbuildings as h on r.buildingID = h.BuildingID join roomservants as rs on r.RoomID = rs.roomID join users as u on rs.userID = u.userID Where r.Status = '{0}'";
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
    }
}
