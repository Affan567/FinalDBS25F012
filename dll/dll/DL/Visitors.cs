using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dll.BL;

namespace dll.DL
{
    public class Visitors
    {
         static public DataTable ViewVisitors()
        {
            string query = "Select VisitorID , VisitorName , VisitDate from visitors";
            DataTable dt = DatabaseHelper.getDataTable(query);
            return dt;


        }

        static public DataTable getVisitor(int userID)
        {
            string query = "SELECT * FROM visitors as v join students as s on v.StudentID = s.StudentID join users as u on s.userID = u.userID Where s.userId = {0} ";
            query = String.Format(query, userID);
            return DatabaseHelper.getDataTable(query);

        }


    
    
    
    }
}
