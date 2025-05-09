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
        private DateTime date;
        private string Visitorname;


        public Visitors(int visitorID , int StudentID , DateTime date , string visitorName )
        {
            this.visitorID = visitorID; 
            this.StudentID = StudentID;
            this.date = date;
            this.Visitorname = visitorName;
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
        public DateTime Getdate()
        {
            return date;
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

        public void setDate()
        {
            date = DateTime.Now;
        }
        public void viewVisitors()
        {
            DL.Visitors.ViewVisitors();
        }
    }
}
