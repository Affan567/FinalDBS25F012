using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;

namespace dll.BL
{
    public class RoomType
    {

        protected int roomtypeID;
        protected string typename;
        protected int capacity;


        public RoomType()
        {

        }



        public RoomType(int roomtypeID, string typename, int capacity)
            {
            this.roomtypeID = roomtypeID;
            this.typename = typename;
            this.capacity = capacity;

            }
        public RoomType( string typename, int capacity)
        {
            
            this.typename = typename;
            this.capacity = capacity;

        }


        

        public bool AddRoomType(string typeName, int capacity)
        {
            DL.roomtype roomtype = new DL.roomtype();
            return roomtype.AddRoomTypeData(typeName, capacity);
            

        }

        public int getRommtypeID()
        {
            return roomtypeID;
        }
        public int Capacity()
        {
            return capacity;
        }
        public string GetTypeName()
        {
            return typename;
        }


        public int getRoomTypeID(string RoomTypeName, int capacity)
        {
            DL.roomtype r = new DL.roomtype();
            return r.GetRoomTypeID(RoomTypeName, capacity);
        }


        public void SetTypeID(int TypeID)
        {
            this.roomtypeID = TypeID;
        }


        public List <object> GettingTypeName()
        {
            DL.roomtype type = new DL.roomtype();
            return type.GetTypeName();
        }
    }
}
