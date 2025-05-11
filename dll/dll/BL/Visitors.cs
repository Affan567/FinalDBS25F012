using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dll.DL;

namespace dll.BL
{

    
    public class Visitors
    {


        public Visitors()
        {

        }
        private int visitorID;
        private int StudentID;
        private string date;
        private string Visitorname;


        public Visitors(int StudentID, string Visitorname,  string date)
        {
            this.StudentID = StudentID;
            this.Visitorname = Visitorname;
            this.date = date;

        }
        public string Getname()
        {
            return Visitorname;
        }
        public int GetVisitorID()
        {
            return visitorID;
        }
        public int GetStudentID()
        {
            return StudentID;
        }
        public string Getdate()
        {
            return date;
        }

        public bool InsertVisitor(BL.Visitors b)
        {
            DL.Visitors vis = new DL.Visitors();
            if(vis.AddVisitors(b))
            {
                return true;
            }
            return false;
        }

        public DataTable GetVisitorsoftheUser(int userID)
        {
            return DL.Visitors.getVisitor(userID);
        }
        public void setName(string Name)
        {
         
            Regex regex = new Regex(@"^\D*$"); // ^ means start, \D* means any non-digit characters, $ means end
            if (!regex.IsMatch(Name))
            {
                throw new ArgumentException("Name consists of alphabets only.");
            }
            this.Visitorname = Name;
        

        }

        public void setStudentID(int ID)
        {
            this.StudentID = ID;
        }

        public void setVisitorID(int VisitorID)
        {
            this.visitorID = VisitorID;
        }

        //public void setDate()
        //{
        //    this.date = date;
        //}
        public void viewVisitors()
        {
            DL.Visitors.ViewVisitors();
        }
        
    }
}
