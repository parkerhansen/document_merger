using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static string txtFile = "{0}{1}.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Doucment Merger");

            do
            {
                Console.Write("Name of First Text File: ");
                string firstFile = Check();
                Console.Write("Name of Second Text File: ");
                string secondFile = Check();
                Console.WriteLine(CreateName(firstFile, secondFile));
                Console.Write("Would you like to merge two more files? (y/n): ");
            }
            while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string Check()
        {
            bool valid = false;
            string input = null;
            while (!valid)
            {
                input = Console.ReadLine();
                valid = true;
                if (File.Exists(input) == false)
                {
                    Console.WriteLine("File does not exist, enter file name again: ");
                    valid = false;
                }
            }
            return input;
        }

        static string CreateName(string firstFile, string secondFile)
        {
            if (firstFile.Contains(".txt"))
            {
                char[] charsToTrim = { 't', 'x' };
                public string newFirstFile1 = firstFile.TrimEnd(charsToTrim);
                char[] punctToTrim = { '.' };
                string newFirstFile = newFirstFile1.TrimEnd(punctToTrim);
            }
            if (secondFile.Contains(".txt"))
            {
                char[] charsToTrim = { 't', 'x' };
                public string newSecondFile = secondFile.TrimEnd(charsToTrim);
                char[] punctToTrim = { '.' };
                newSecondFile = newSecondFile.TrimEnd(punctToTrim);
            }

            string newFileName = newFirstFile + newSecondFile;

            return newFileName;
        }
    }
}
