using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dll.DL
{
    internal class roomtype
    {





        public int GetRoomTypeID(string RoomTypeName, int capacity)
        {
            string query = "Select RoomTypeID from roomtype where TypeName = '{0}' And Capacity = {1}";
            query = String.Format(query, RoomTypeName,capacity);
            object TypeID = DatabaseHelper.ExecuteScalar(query);
            return (int)TypeID;


        }

        public bool AddRoomTypeData(string typeName, int capacity)
        {
            string query = "Insert into roomtype (TypeName,Capacity ) Values ('{0}', {1})";
            query = String.Format (query, typeName, capacity);  
            int affectedrows = DatabaseHelper.executeDML(query);
            return affectedrows > 0;
        }

        public List<object> GetTypeName()
        {
            string columnName = "TypeName";
            string query = "Select TypeName from roomtype";
            query = String.Format(query, "TypeName");
            List<object> TypeNameList = DatabaseHelper.GetColumnValues(query, columnName);
            return TypeNameList;

        }
    }
}
