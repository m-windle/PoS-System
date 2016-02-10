using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace SofkhaPOSLib
{
    public class Logging
    {
        /// <summary>
        /// Creates a log entry in the log text file with the timestamp, id of the user, and 
        /// description of what the interaction with the system was.
        /// </summary>
        /// <param name="Content"></param>
        public static void Log(string Content)
        {
            string query = "SELECT TOP 1 ID FROM Log_T ORDER BY ID DESC";
            
            FileStream filStream = new FileStream(SofkhaPOS.LogFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stmWriter = new StreamWriter(filStream);
            filStream.Seek(0, SeekOrigin.End);

            stmWriter.WriteLine("[" + DateTime.Now.Date.ToString() + "] " + Content);
            stmWriter.Flush();
            filStream.Flush();

            filStream.Close();
            filStream.Dispose();

            DataRowCollection res = Database.DatabaseController.GetQueryResults(query, new Dictionary<string, object>(), false);
            int id = res.Count == 0 ? 0 : (int)res[0]["ID"];
            id++;

            Dictionary<string, object> myDic = new Dictionary<string, object>();
            query = "INSERT INTO Log_T (ID, Content, DateLogged) VALUES (@id, @content, CURRENT_TIMESTAMP)";
            myDic.Add("@id", id.ToString());
            myDic.Add("@content", Content);

            Database.DatabaseController.NonQuery(query, myDic, false);
        }

        public static void Log(string format, params object[] parameters)
        {
            Log(string.Format(format, parameters));
        }
    }
}
