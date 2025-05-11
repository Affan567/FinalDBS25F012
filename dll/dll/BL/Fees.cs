using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.BL
{
    public class Fees
    {
        private int FeeID;
        private int StudentID;
        private Double Amount;
        private DateTime date;
        private string status;


        public DataTable GetFee(int userID)
        {
            return DL.Fees.GETFee(userID);
        }

        public object GetFeeStatus(int userID)
        {
            return DL.Fees.GetStatusFee(userID);
        }



    }
}
