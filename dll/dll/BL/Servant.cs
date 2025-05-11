using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Servant
    {


        public Servant() { }

        public DataTable GetServantData()
        {
            return DL.Servant.getTable();
        }
    }
}
