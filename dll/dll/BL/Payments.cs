using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Payments
    {
        public Payments() { }

        public DataTable GetPaymentsData()
        {
            return DL.Payments.getTable();
        }
    }
}
