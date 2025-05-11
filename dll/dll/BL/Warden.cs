using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;

namespace dll.BL
{
    public class Warden : User
    {

 
            public Warden() { }





        private int wardenID;
        private int AssignedBuildingID;
        private int userID;

        public Warden(string Name, string Phone, string Email, int roleID, int AssignedBuildingID, string Username, string password) : base(Username, password, Name, Email, Phone, roleID)//Add constructor
        {

            this.AssignedBuildingID = AssignedBuildingID;
            


        }

        public Warden(int userID, int wardenID, string name, string Contact, string email,  int AssignedBuildingID, string StudentUsername, string StudentPassword, int roleID) : base(userID, StudentUsername, StudentPassword, name, email, Contact, roleID)//Edit student constructor
        {
            this.wardenID = wardenID;
            this.AssignedBuildingID = AssignedBuildingID;
        }

        public int GetuserID()
        {
            return wardenID;
        }

        public int GetBuildingID()
        {
            return AssignedBuildingID;

        }

        public void setUserID(int userID)
        {
            this.userid = userID;
        }

        public bool AddWarden(Warden w)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.AddUser(w.getpassword(), w.getUsername(), w.getEmail(), w.getcontact(), w.RoleID(), w.getName());
            if (flag1)
            {
                DL.Warden dl = new DL.Warden();
                int userID = GetUserID(w.getUsername(), w.getpassword());
                w.setUserID(userID);
                bool flag2 = dl.AddWardenToDB(w);
                return flag2;
            }
            return false;
        }
        public DataTable GetWardenData()
        {
            DL.Warden warden = new DL.Warden();
            return warden.gettingWardenDate();
        }

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

        public bool DeleteWarden(int Wardenid, int userid)
        {
            DL.Warden dl = new DL.Warden();
            return dl.DeleteWardenFromDB(Wardenid, userid);
        }

        public object GettingWardenID(int userID)
        {
            DL.Warden stu = new DL.Warden();
            return stu.getWardenID(userID);
        }

        public bool UpdateWarden(Warden s)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.UpdateUser(s.UserID(), s.getpassword(), s.getUsername(), s.getEmail(), s.RoleID(), s.getcontact(), s.getName());
            if (flag1)
            {
                DL.Warden dl = new DL.Warden();

                bool flag2 = dl.UpdateWardenInDB(s);
                return flag2;
            }
            return false;
        }
    }
}
