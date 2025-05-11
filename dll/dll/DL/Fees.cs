using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DL
{
    public class Fees
    {


        public static DataTable GETFee(int userID)
        {
            string query = "SELECT * FROM fees as f join students as s on f.StudentID = s.StudentID join users as u on s.userID = u.userID Where s.userId = {0} ";
            query = String.Format(query, userID);
            return DatabaseHelper.getDataTable(query);
        }


        public static object GetStatusFee(int studentID)
        {
            string query = "Select Status From fees where StudentID = {0}";
            query = string.Format(query, studentID);
            return DatabaseHelper.ExecuteScalar(query);

        }
    }
}
