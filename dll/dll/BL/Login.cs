using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace dll.BL
{
    public class Login
    {
        protected static int user_id;
        protected static string username;   


        public static void SetUsername(string Username)
        {
            username = Username;
        }

        public static void SetUserID(int UserID)
        {
            user_id = UserID;
        }

        public static string GetUsername()
        {
            return username;
        }

        public static int GetUserID()
        {
            return user_id;
        }



    }
}
