using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    internal class Users
    {
        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public int RoleID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Contact { get; set; }
        }
    }
}
