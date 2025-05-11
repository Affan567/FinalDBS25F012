using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using dll.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public static bool UpdateRoomTypetoDB(int roomTypeID, string roomTypeName, int capacity)
        {
            string updateQuery = "UPDATE roomtype SET TypeName = '{0}',Capacity = {1} Where RoomTypeID = {2}";
            updateQuery = String.Format(updateQuery, roomTypeName, capacity,roomTypeID);
            int rowsAffected = DatabaseHelper.executeDML(updateQuery);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
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
