using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;

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

        public Student(int userID ,int studentID,string Studentname ,string StudentContact,string Studentemail,string StudentReg,int Semester,int roomID,string StudentUsername,string StudentPassword) : base( userID, StudentUsername, StudentPassword, Studentname, Studentemail, StudentContact)//Edit student constructor
        {
            this.StudentID =studentID;
            this.RegistrationNumber = StudentReg;
            this.roomID = roomID;
            this.semester = Semester;
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
            bool flag1 = bl.UpdateUser(s.GetUserID(), s.GetPassword(), s.GetUsername(), s.GetEmail(), s.RoleID(), s.GetContact() , s.GetName());
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

        public bool DeleteStudent(int Studentid, int userid)
        {
            DL.Student dl = new DL.Student();
            return dl.DeleteStudentFromDB(Studentid, userid);

        }

        public object getTotalStudents()
        {
            DL.Student s = new DL.Student();
            return s.GetRegisteredStudents();
        }

        public object GetStudentID(int userID)
        {
            DL.Student stu = new DL.Student();
            return stu.getStudentID(userID);
        }
    }
}
