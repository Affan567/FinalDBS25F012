using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Warden : User
    {
            public Warden() { }



        private int wardenID;
        private int AssignedBuildingID;
        private int userID;




        public object GetWardenID(string wardenName)
        {
            DL.Warden warden = new DL.Warden();
            return warden.GettingWardenID(wardenName);
        }

        public List <object> GetWardenUsername()
        {
            DL.Warden w = new DL.Warden();
            return w.GetWardenNamesFromDB();
        }
    }
}
