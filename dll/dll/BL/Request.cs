using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Request
    {

        public DataTable GetRequestsOfOneStudent(int userID)
        {
            return DL.Request.GETRequestOfAStudent(userID);
        }

    }
}
