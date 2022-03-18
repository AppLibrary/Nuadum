
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Nuadum
{
    public interface ISortNames
    {
        void Write(string fileOne);
        void Write(string Data, string DataSource);
        string RandomSort(string DataSource);
        void RandomSort(string fileOne, string fileTwo);
        void InsertToTable(string DataSource, string ConnectionString, SqlConnection conn);
        SqlConnection GetConnection(string DataSource);
        string SelectFromTable(string DataSource);
    }

    class PerformSort 
    {
        public void Write(string Data, string DataSource)
        {         
            DatabaseConnection dbConnect = new DatabaseConnection();//Create Database Connection Object
            var conn = dbConnect.GetConnection(DataSource);//Get database connection

            DatabaseOperation dbOperate = new DatabaseOperation();//Create Database Operation Object
            dbOperate.InsertToTable(Data, DataSource, conn);
            
        }
        public string RandomSort(string DataSource)
        {
            DatabaseOperation dbOperate = new DatabaseOperation();
            string unsorted = dbOperate.SelectFromTable(DataSource);
           
            List<string> GetAllNames()//Local List Function GetAllNames
            {
                return new List <string>();
            }

            char[] seperators = new char[] { ' ', '.' };//Char Seperators Variable
            string[] subs = unsorted.Split(seperators, StringSplitOptions.RemoveEmptyEntries);//String Array Subs.
            var yourName = GetAllNames();

            foreach (string sub in subs)//Iterate Through Subs
            {
                yourName.Add(sub);//Add Name To List
            }
         
            Random random = new Random();//Random Object random Initialization
            yourName = yourName.OrderBy(x => random.Next()).ToList();//Randomize The Names in List

            string sorted = "";
            foreach (var name in yourName)//Iterate Through List Object
            {
                sorted = $"{name} ";
            }
            char space = ' ';
            sorted.TrimEnd(space);
            return sorted;
        }
    }

    class DatabaseConnection
    {
        public SqlConnection GetConnection(string DataSource)//Method To Open Connection
        {

            // for the connection to
            // sql server database
            SqlConnection conn;

            conn = new SqlConnection(DataSource);

            return conn;//return connection
        }
    }

    class DatabaseOperation
    {
        public void InsertToTable(string Data, string ConnectionString, SqlConnection conn)
        {
            conn = new SqlConnection(ConnectionString);
            
            string CommandString = "INSERT INTO dbo.Sorted (Data) VALUES (@Data)";//CommandString for Insert Statement
            SqlCommand command = new SqlCommand(CommandString, conn);//Create SqlCommand Object
            command.Connection.Open();//Open Connection
            command.Parameters.Add("@Data", SqlDbType.NVarChar).Value = Data;//Add Data Parameters
            command.ExecuteNonQuery();
            command.Connection.Close();
            
            //string tb = "Record Inserted To Table";
            //return tb;
        }

        public string SelectFromTable(string DataSource)
        {
            DatabaseConnection getconn = new DatabaseConnection();
            var conn = getconn.GetConnection(DataSource);

            string CommandString = "SELECT Data FROM dbo.Sorted;";

            SqlCommand command = new SqlCommand(CommandString, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            string unSortedString = "";

            while (reader.Read())
            {
                unSortedString = reader.GetString(0);
            }
            conn.Close();
            conn.Dispose();
            
            return unSortedString;
        }
    }
}
