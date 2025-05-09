using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;

namespace dll.DL
{
    public class Student : User
    {

        public bool AddStudentToDB(BL.Student s)
        {
            string insertQuery = "INSERT INTO student(RegistrationNo, Semester, RoomID ,userID) " +
                                 "VALUES ('{0}', {1}, {2}, {3})";
            insertQuery = string.Format(insertQuery, s.GetRegistrationNumber(), s.GetSemester(), s.GetroomID(), s.UserID());

            int rowsAffected = DatabaseHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllStudents()
        {
            string query = "Select * From students";
            DataTable studentTable = DatabaseHelper.getDataTable(query);
            return studentTable;
        }

        public bool UpdateStudentInDB(BL.Student s)
        {
            string updateQuery = "UPDATE student SET RegistrationNo = '{0}', Hostellite = {1}, CGPA = {2}, SessionYear = {3}, " +
                                 "Nationality = '{4}',SessionTerm = '{5}' Where UserID = {6}";
            updateQuery = string.Format(updateQuery, s.GetRegistrationNumber(), s.RoleID(),s.Getgender(),s.GetSemester(), s.GetUserID());

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





    }



}
