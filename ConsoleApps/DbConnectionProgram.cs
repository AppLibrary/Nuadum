using System;
using System.Data.SqlClient;

namespace Nuadum
{
    internal class DbConnectionProgram
    {
        private static string GetConnectionString()
        {
            string connectionString = @"your connection string";
            return connectionString;
        }
        
        
        static void Main()// Main Method
        {
            Console.WriteLine("Enter Ten Names");
            string str = Console.ReadLine();//Read user input

            if (str.Length == 0)//Prompt User again for input if non is provided
            {
                Console.WriteLine("You have not entered a name... Please Enter Ten Names.");
                Console.ReadLine();
            }

            Console.WriteLine("You've entered {0}", str);
            
            PerformSort performsort = new PerformSort ();//Create New Object NamesDb
            performsort.Write(str, GetConnectionString()); //Pass str and GetConnectionStrigs as arguments
            performsort.RandomSort(GetConnectionString());

            DatabaseOperation dbOperate = new DatabaseOperation ();
            dbOperate.SelectFromTable(GetConnectionString());



            Console.WriteLine("Writing File To Database Table");

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConnectionString());
            
        }
    }
}
