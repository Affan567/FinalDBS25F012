using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dll.DL
{
    public class Complaints
    {
        public DataTable GetComplaintOfaStudent(int userid)
        {
            string query = "SELECT * FROM complaints as c join students as s on c.StudentID = s.StudentID join users as u on s.userID = u.userID Where s.userId = {0} ";
            query = String.Format(query, userid);
            return DatabaseHelper.getDataTable(query);
        }


        public DataTable GetComplaintOfAllStudent()
        {
            string query = "SELECT * FROM complaints Where ";
            return DatabaseHelper.getDataTable(query);
        }


        public static bool InsertComplaint(BL.Complaints com)
        {
            string query = "Insert into complaints (StudentID , Description , Date , Status) values ('{0}','{1}','{2}','{3}')";
            query = String.Format(query, com.GetStudentID() , com.Getdescription() , com.Getdate() , com.Status());
            int rowsaffected = DatabaseHelper.executeDML(query);
            return rowsaffected > 0;
            
            


        }

    }



    }



