using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SofkhaPOSLib.Database
{
    public static class DatabaseController
    {
        //Returns an active connection to local database
        private static SqlConnection GetActiveConnection()
        {
            string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + SofkhaPOS.DatabasePath + ";Integrated Security=True";
            SqlConnection retConnection = new SqlConnection(connString);
            retConnection.Open();
            return retConnection;
        }

        //Takes the parameters of a query string, Dictionary of query parameters and a boolean of whether or not to log
        //returns the results of the query
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static DataRowCollection GetQueryResults(string query, Dictionary<string, object> parameters, bool log = true)
        {
            DataRowCollection retResults;

            using(SqlConnection s = GetActiveConnection())
            {
                SqlCommand sQuery = new SqlCommand();
                sQuery.Connection = s;
                sQuery.CommandText = query;
                sQuery.CommandType = CommandType.Text;

                foreach(KeyValuePair<string, object> i in parameters)
                {
                    sQuery.Parameters.AddWithValue(i.Key, i.Value);
                }

                SqlDataReader sReader = sQuery.ExecuteReader();
                DataTable dTable = new DataTable();
                
                dTable.Load(sReader);
                retResults = dTable.Rows;

                sReader.Close();
                dTable.Dispose();
            }

            if(log) Logging.Log("Query {0} successfully executed ({1} Parameters)", query, parameters.Count);
            return retResults;
        }

        //Takes a string query with a dictionary of parameters for the query and a boolean as to log query or not
        //returns an int with the number of rows affected
        public static int NonQuery(string query, Dictionary<string, object> parameters, bool log = true)
        {
            int retResults;

            using (SqlConnection s = GetActiveConnection())
            {
                SqlCommand sQuery = new SqlCommand();
                sQuery.Connection = s;
                sQuery.CommandText = query;
                sQuery.CommandType = CommandType.Text;

                foreach (KeyValuePair<string, object> i in parameters)
                {
                    sQuery.Parameters.AddWithValue(i.Key, i.Value);
                }

                retResults = sQuery.ExecuteNonQuery();
            }

            if(log) Logging.Log("Query {0} successfully executed ({1} Parameters)", query, parameters.Count);
            return retResults;
        }
    }
}
