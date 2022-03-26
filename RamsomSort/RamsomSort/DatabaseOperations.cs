using System.Data;
using System.Data.SqlClient;

namespace RamdomSort
{
    class DatabaseOperations : ISortNameDB
    {
        //Method Returns SqlConnection
        public SqlConnection GetConnection(string DataSource)//Method To Open Connection
        {
            // for the connection to
            // sql server database

            SqlConnection conn = new SqlConnection(DataSource);
            return conn;//return connection
        }

        //Method To Insert Data Into dbo.Sorted
        public void InsertTableSorted(string Data, SqlConnection connection)
        {
            string CommandString = "INSERT INTO dbo.Sorted (Data) VALUES (@Data)";//CommandString for Insert Statement
            SqlCommand command = new SqlCommand(CommandString, connection);//Create SqlCommand Object
            command.Connection.Open();//Open Connection
            command.Parameters.Add("@Data", SqlDbType.NVarChar).Value = Data;//Add Data Parameters
            command.ExecuteNonQuery();
            command.Connection.Close();

            Console.WriteLine("Data Inserted");
        }

        //Method To Insert Data Into dbo.Unsorted
        public void InsertTableUnsorted(string Data, SqlConnection connection)
        {
            string CommandString = "INSERT INTO dbo.Unsorted (Data) VALUES (@Data)";//CommandString for Insert Statement
            SqlCommand command = new SqlCommand(CommandString, connection);//Create SqlCommand Object
            command.Connection.Open();//Open Connection
            command.Parameters.Add("@Data", SqlDbType.NVarChar).Value = Data;//Add Data Parameters
            command.ExecuteNonQuery();
            command.Connection.Close();

            Console.WriteLine("Data Inserted dbo.Unsorted");
        }

        //Method selects value from Unsorted Table
        public string SelectFromTable(string DataSource)
        {
            DatabaseOperations getconn = new DatabaseOperations();//Create Database Operations Object
            
            var conn = getconn.GetConnection(DataSource);//get a connection

            string CommandString = "SELECT Data FROM dbo.Unsorted;";

            SqlCommand command = new SqlCommand(CommandString, conn);//Create SqlCommand object
            
            conn.Open();//Open Connection
            
            SqlDataReader reader = command.ExecuteReader();//SqlDataReader variable

            string unSortedString = "";

            while (reader.Read())//Iterate through reader
            {
                unSortedString = reader.GetString(0);//assign string to unSortedString variable
            }
            conn.Close();//Close Connection
            conn.Dispose();//Dispose Connection

            return unSortedString;//Return unsorted string
        }

        //RandomSort Method
        public string RandomSort(string DataSource)
        {
            DatabaseOperations dbOperate = new DatabaseOperations();
            string unsorted = dbOperate.SelectFromTable(DataSource);

            List<string> GetAllNames()//Local List Function GetAllNames
            {
                return new List<string>();
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
}
