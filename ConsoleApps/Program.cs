using System;

namespace Nuadum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortNamesFile sortNames = new SortNamesFile();
            string file = @"c:\CodingPractice\NotRandomSort.txt";
            sortNames.Write(file);

            string file2 = @"c:\CodingPractice\RandomSorted.csv";
            sortNames.RandomSort(file, file2);

            string[] str = System.IO.File.ReadAllLines(file2);

            foreach (string str2 in str)
            { 
                Console.WriteLine(str2);
            }

            Console.ReadKey();
        }
    }
}
