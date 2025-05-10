using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;

namespace dll.BL
{
    internal class RoomType
    {

        protected int roomtypeID;
        protected string typename;
        protected int capacity;


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


        

        public void addRooomType(string typename, int capacity)
        {
            DL.roomtype roomtype = new DL.roomtype();
            //roomtype.AddRoomType();

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



    }
}
