using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.BL;

namespace dll.DL
{
    public class DamageRecords
    {

        public static DataTable GetDamage(int userID)
        {
            string query = "Select u.name as StudentName , s.RegistrationNumber , h.Description as RuleDescription ,h.FineAmount , d.Date as DateofRuleBreak from damagerecords as d join students as s on d.StudentID = s.StudentID join users as u on s.userID = u.userID join hostelrules as h on d.RuleID = h.RuleID where u.userID = {0} ";
            query = String.Format(query, userID);
            return DatabaseHelper.getDataTable(query);

        }

    }
}
