using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Crud;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg;

namespace dll.DL
{
    public class Student : User
    {

        public bool AddStudentToDB(BL.Student s)
        {
            string insertQuery = "INSERT INTO students(RegistrationNumber, Semester, RoomID ,userID) " +
                                 "VALUES ('{0}', {1}, {2}, {3})";
            insertQuery = string.Format(insertQuery, s.GetRegistrationNumber(), s.GetSemester(), s.GetroomID(), s.UserID());

            int rowsAffected = DatabaseHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllStudents()
        {
            string query = "Select u.name, u.contact ,u.username ,u.password ,s.RegistrationNumber , s.Semester , r.RoomNumber From users as u join students as s on u.userID = s.userID join rooms as r on s.RoomID = r.RoomID";
            DataTable studentTable = DatabaseHelper.getDataTable(query);
            return studentTable;
        }

        public bool UpdateStudentInDB(BL.Student s)
        {
            string updateQuery = "UPDATE students SET RegistrationNumber = '{0}', Semester = {1}, RoomID = {2} ,userID = {3} Where StudentID = {4}";
            updateQuery = string.Format(updateQuery, s.GetRegistrationNumber(), s.GetSemester(), s.GetroomID(), s.GetUserID(),s.GetStudentID());

            int rowsAffected = DatabaseHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public static bool getRegistrationNumber()
        {
            string query = "Select RegistrationNumber From Students where userID = {}";
            //query = string.Format(query, UserId);
            int rowsaffected = DatabaseHelper.executeDML(query);
            return rowsaffected > 0;
        }

        public object GetRegisteredStudents()
        {
            string query = "Select Count(RegistrationNumber) From students";
            query = String.Format(query);
            return DatabaseHelper.ExecuteScalar(query);
        }

        public bool DeleteStudentFromDB(int studentid, int userid)
        {
            List<string> queries = new List<string>();


            string query1 = "Delete from complaints where StudentID = {0}";
            query1 = String.Format(query1, studentid);
            string query2 = "Delete from fees where StudentID = {0}";
            query2 = String.Format(query2, studentid);
            string query3 = "Delete from request where StudentID = {0}";
            query3 = String.Format(query3, studentid);
            string query4 = "Delete from damagerecords where StudentID = {0}";
            query4 = String.Format(query4, studentid);
            string query5 = "Delete from visitors where StudentID = {0}";
            query5 = String.Format(query5, studentid);

            string query6 = "Delete From students Where StudentID = {0}";
            query6 = String.Format(query6, studentid);

            string query7 = "Delete From users Where userID = {0}";
            query7 = String.Format(query7, userid);


            queries.Add(query1);
            queries.Add(query2);
            queries.Add(query3);
            queries.Add(query4);
            queries.Add(query5);
            queries.Add(query6);
            queries.Add(query7);


            bool rowsAffected = DatabaseHelper.ExecuteTransaction(queries);

            if (rowsAffected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object getStudentID(int userID)
        {
            string query = "Select StudentID from students where userID = {0}";
            query = String.Format (query, userID);
            return DatabaseHelper.ExecuteScalar(query);
        }




    }



}
