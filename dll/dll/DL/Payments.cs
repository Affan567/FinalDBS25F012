using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DL
{
    public class Payments
    {
        public  Payments() { }


        public static DataTable getTable()
        {
            string query = "Select * From payments ";
            DataTable studentTable = DatabaseHelper.getDataTable(query);
            return studentTable;

        }
    }
}
