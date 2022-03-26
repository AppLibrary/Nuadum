using System.Data.SqlClient;
using System.IO;
using System;

namespace RamdomSort
{
    class DBProgram
    {
        public static void Main()// Main Method
        {
            string names;
            Console.WriteLine("Enter Ten Names");
            names = Console.ReadLine();
            Console.WriteLine("You've entered {0}", names);

            string DataSource = @"Enter Data Source Here";

            DatabaseOperations db = new DatabaseOperations();

            SqlConnection connection = db.GetConnection(DataSource);

            db.InsertTableUnsorted(names, connection);
            string sorted = db.RandomSort(DataSource);
            db.InsertTableSorted(sorted, connection);
      
        }
    }
}