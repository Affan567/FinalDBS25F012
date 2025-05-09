using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Rooms
    {

        public Rooms() { }
        public object getTotalRooms()
        {
            return DL.Rooms.getTotalRoomsFromDB();
        }
        

        public DataTable ViewRoomofStudent(int userID)
        {
            return DL.Rooms.ViewRoom(userID);
        }
        
        public void viewRoom()
        {
            DL.Rooms.viewRoomsData();
        }

        public object getRoomsOccupied()
        {
            DL.Rooms r = new DL.Rooms();
            return r.RoomsOccupied();

        }

        




    }

}
