using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Student : User
    {

        private string RegistrationNumber;
        private int StudentID;
        private int semester;
        private int roomID;
        private int userID;


        public Student()
        {
        }



        public string GetRegistrationNumber()

        {
            return RegistrationNumber;
        }

        public string Getgender()
        {
            return gender;
        }

        public int GetSemester()
        {
            return semester;
        }

        public int GetroomID()
        {
            return roomID;
        }

        public int GetStudentID()
        {
            return StudentID;

        }
        public int GetUserID()
        {
            return userid;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }
        
        public string GetEmail()
        {
            return email;
        }
        
        public string GetName()
        {
            return name;
        }

        public string GetContact()
        {
            return contact;
        }

        public void setUserID(int userID)
        {
            this.userid = userID;
        }

        public Student(int StudentID ,string RegistrationNumber,int semester,  string Username,string password , string Email,  string Phone,  string Name, string gender , int UserID , int roomID) : base( Username, password , Name, Email, Phone)
        {
            this.StudentID = StudentID;
            this.RegistrationNumber = RegistrationNumber;
            this.roomID = roomID;
            this.semester = semester;
        }
        public Student(string Name ,string Phone,string Email,int roleID, string RegistrationNumber, int semester,int roomid , string Username, string password) : base(Username,password, Name, Email, Phone, roleID)//Add constructor
        {
            
            this.RegistrationNumber = RegistrationNumber;
            this.semester = semester;
            this.roomID=roomid;
            this.userid = userID;


        }

        public bool AddStudent(Student s)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.AddUser(s.getpassword(), s.getUsername(), s.getEmail(),  s.getcontact(), s.RoleID(), s.getName() );
            if (flag1)
            {
                DL.Student dl = new DL.Student();
                int userID = GetUserID(s.getUsername() , s.getpassword());
                s.setUserID(userID);
                bool flag2 = dl.AddStudentToDB(s);
                return flag2;
            }
            return false;
        }
        
        public DataTable GetStudents()
        {
            DL.Student dl = new DL.Student();
            return dl.GetAllStudents();
        }

        public bool UpdateStudent(Student s)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.UpdateUser(s.GetUserID(), s.GetPassword(), s.GetUsername(), s.GetEmail(),s.GetContact() , s.GetName());
            if (flag1)
            {
                DL.Student dl = new DL.Student();
                bool flag2 = dl.UpdateStudentInDB(s);
                return flag2;
            }
            return false;
        }

        public void GetRegNO()
        {
            DL.Student.getRegistrationNumber();
        }

        //public bool DeleteStudent(int facultyid, int userid)
        //{
        //    DL.Student dl = new DL.Student();
        //    return dl.DeleteStudentFromDB(facultyid, userid);

        //}

        public object getTotalStudents()
        {
            DL.Student s = new DL.Student();
            return s.GetRegisteredStudents();

        }
    }
}
