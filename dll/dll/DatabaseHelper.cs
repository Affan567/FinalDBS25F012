using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
namespace dll
{
    internal class DatabaseHelper
    {



        public static string constring = "server=localhost;database=finalproject;uid=root;pwd=123321*()abc";
        public static int executeDML(string dml)
        {
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(dml, con);
            int affectedRows = cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;
        }

        public static DataTable getDataTable(string sql)
        {
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        public static bool ExecuteTransaction(List<string> queries)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var query in queries)
                        {
                            ExecuteNonQuery(query, transaction, conn);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string query, MySqlTransaction transaction = null, MySqlConnection conn = null)
        {
            bool localConnection = (conn == null);
            if (localConnection)
                conn = new MySqlConnection(constring);

            if (transaction == null)
                conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (localConnection)
                    conn.Close();

                return rowsAffected;
            }
        }

        public static object ExecuteScalar(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }


        public static List<object> GetColumnValues(string query, string columnName)
        {
            List<object> values = new List<object>();

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values.Add(reader[columnName]);
                        }
                    }
                }
                con.Close();        //Although using automatically closes the connection
            }

            return values;
        }
    }
}
