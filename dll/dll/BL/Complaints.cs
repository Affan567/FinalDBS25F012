using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;

namespace dll.BL
{
    public class Complaints
    {
        private int complaintID;
        private string description;
        private string Date;
        private string status;
        private int StudentID;

        public Complaints()
            { }

        public Complaints(int StudentID, string description,  string status, string date)
        {
            this.StudentID = StudentID;
            this.description = description;
            Date = date;
            this.status = status;
        }

        public int GetComplaintID()
        {
            return complaintID;
        }

        public int GetStudentID()
        {
            return StudentID;
        }

        public string Getdescription()
        {
            return description;
        }
        public string Status()
        {
            return status;
        }

        public string Getdate()
        {
            return Date;
        }

        public DataTable GetComplaint(int userID)
        {
            DL.Complaints dl = new DL.Complaints();
            return dl.GetComplaintOfaStudent(userID);
        }

        public DataTable GetAllComplaints()
        {
            DL.Complaints dl = new DL.Complaints();
            return dl.GetComplaintOfAllStudent();
        }

        public static bool InsertingComplaint(BL.Complaints complaints)
        {
            return DL.Complaints.InsertComplaint(complaints);

        }


        public object GetComplaintStatus(int userID)
        {
            return DL.Complaints.GetComplaint(userID);
        }



    }
}
