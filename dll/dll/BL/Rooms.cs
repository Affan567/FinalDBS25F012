using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dll.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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



        
        public int GetroomtypeID()
        {
            return roomTypeID;
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
        public Rooms(int roomNumber ,int buildingID ,string typeName , int capacity ,string status ) : base(typeName,capacity)
        {
            this.roomNumber= roomNumber;
            this.status = status;
            this.buildingID = buildingID;
        }
        
        public Rooms(int roomTypeID, int roomID,string  uildingName,int capacity,string status, string RoomTypeName,int buildingID,int roomNumber)
        {
            this.roomTypeID = roomTypeID;
            this.roomNumber = roomNumber;
            this.status = status;
            this.buildingID = buildingID;
        }


        public bool UpdateRoom(Rooms s)
        {
            BL.RoomType bl = new BL.RoomType();
            bool flag1 = bl.UpdateRoomType(s.getRommtypeID(), s.GetTypeName(), s.Capacity());
            if (flag1)
            {
                DL.Rooms dl = new DL.Rooms();

                bool flag2 = dl.UpdateRoomInDB(s);
                return flag2;
            }
            return false;
        }
        public Rooms() { }
        public object getTotalRooms()
        {
            return DL.Rooms.getTotalRoomsFromDB();
        }
        
        public void GetRoomTypeID(string RoomTypeName, int capacity)
        {

        }
        public DataTable ViewRoomofStudent(int userID)
        {
            return DL.Rooms.ViewRoom(userID);
        }
        
        public void viewRoom()
        {
            DL.Rooms.viewRoomsData();
        }

        public object getRoomsAvailable()
        {
            DL.Rooms r = new DL.Rooms();
            return r.RoomsAvailable();



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
        public bool DeleteRoom(int roomid , int RoomTypeid)
        {
            DL.Rooms dl = new DL.Rooms();
            return dl.DeleteroomFromDB(roomid, RoomTypeid);



        }


    }

}
