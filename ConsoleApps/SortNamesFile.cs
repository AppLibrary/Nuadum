using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Nuadum
{
    public class SortNamesFile : ISortNames
    {
        public void Write(string fileOne)
        {
            StreamWriter sw = new StreamWriter(fileOne, true);

            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter Ten Names..........");

            // Read Input From User
            string str = Console.ReadLine();

            //Write Line To Buffer
            sw.WriteLine(str);

            //Write In Output Stream
            sw.Flush();

            //Close Stream
            sw.Close();
        }

        public void RandomSort(string fileOne, string fileTwo)
        {
            StreamReader GetReader(string this_file)//Returns new GetReader
            {
                return new StreamReader(this_file);
            }

            StreamWriter GetWriter(string this_file)//Returns new GetWriter
            {
                return new StreamWriter(this_file);
            }

            List<string> GetAllNames()//Local List Function GetAllNames
            {
                return new List<string>();
            }

            var reader_one = GetReader(fileOne);//StreamReader Variable reader


            string line = reader_one.ReadLine();//ReadLine To Variable Line
            char[] seperators = new char[] { ' ', '.' };//Char Seperators Variable
            string[] subs = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);//String Array Subs.
            var yourName = GetAllNames();

            foreach (string sub in subs)//Iterate Through Subs
            {
                yourName.Add(sub);//Add Name To List
            }
            Console.WriteLine("\n");
            Random random = new Random();//Random Object random Initialization
            yourName = yourName.OrderBy(x => random.Next()).ToList();//Randomize The Names in List
            
            var writer_one = GetWriter(fileTwo);

            foreach (var name in yourName)//Iterate Through List Object
            {
                writer_one.WriteLine(name);//Write Names To CSV File
            }
            writer_one.Close();

            return;
        }
    }
}
