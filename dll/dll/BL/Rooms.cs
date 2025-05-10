using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dll.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace dll.BL
{
    public class Rooms : RoomType
    {


        private int roomID;
        private int roomNumber;
        private int roomTypeID;
        private string status;
        private int buildingID;




        public int GetRoomNumber()

        {
            return roomNumber;
        }



        

        
        public int GetBuildingID()
        {
            return buildingID;

        }
        
        public string GetStatus()
        {
            return status;
        }

        public int GetRoomID()
        {
            return roomID;
        }

        public void setRoomID(int roomID)
        {
            this.roomID = roomID;
        }
        public Rooms(int roomNumber ,int buildingID ,string typeName , int capacity ,string status ,int roomTypeID) : base(typeName,capacity)
        {
            this.roomNumber= roomNumber;
            this.roomTypeID= roomTypeID;
            this.status = status;
            this.buildingID = buildingID;
        }
        
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


        public object getRoomID(int roomNumber)
        {
            DL.Rooms r = new DL.Rooms();
            return r.gettingRoomID(roomNumber);
        }

        public List<object> GetAllRoomID()
        {
            DL.Rooms r = new DL.Rooms();
            return r.GetBuildingRoomIDFromDB();
        }


        public List<object> GetRoomNumbers()
        {
            DL.Rooms r = new DL.Rooms();
            return r.GetRoomNumbersFromDB();
        }

        public bool AddRoom(Rooms r)
        {
            BL.RoomType RT = new BL.RoomType();
            bool flag1 = RT.AddRoomType(r.GetTypeName(), r.Capacity());
            if (flag1)
            {
                
                int TypeID = getRoomTypeID(r.GetTypeName(), r.Capacity());
                r.SetTypeID(TypeID);
                DL.Rooms room = new DL.Rooms();
                bool flag2 = room.AddRoom(r);
                return flag2;
            }
            return false;
        }

        public DataTable GetRoomData()
        {

            DL.Rooms r = new DL.Rooms();
            return r.GettingRoomData();
        }



    }

}
