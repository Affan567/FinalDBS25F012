using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.BL;

namespace dll.DL
{
    public class Request
    {
        public static DataTable GETRequestOfAStudent(int userID)
        {
            string query = "SELECT * FROM request as r join students as s on r.StudentID = s.StudentID join users as u on s.userID = u.userID Where s.userId = {0} ";
            query = String.Format(query, userID);
            return DatabaseHelper.getDataTable(query);
        }



    }
}
