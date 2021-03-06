﻿using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static public string firstFile;
        static public string secondFile;
        static public string mergedName;

        public static void Main(string[] args)
        {

            Console.WriteLine("Doucment Merger");

            do
            {
                Console.Write("Name of First Text File: ");
                firstFile = Check();
                Console.Write("Name of Second Text File: ");
                secondFile = Check();
                mergedName = CreateName(firstFile, secondFile);
                Console.Write("Enter new filename (default: {0}): ", mergedName);
                string userName = Console.ReadLine();

                if(userName == "")
                {
                    userName = mergedName;
                }

                if(userName.Contains(".txt") == false)
                {
                    userName += ".txt";
                }

                StreamWriter name = null;

                try
                {
                    name = new StreamWriter(userName);
                    int characters = WriteFile(name, firstFile);
                    characters += WriteFile(name, secondFile);
                    Console.Write("{0} was successfully saved. The document contains {1} characters.", userName, characters);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to write to {0}: {1}", userName, e.Message);
                }
                finally
                {
                    if (name != null)
                    {
                        name.Close();
                    }
                }

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
                    Console.Write("File does not exist, enter file name again: ");
                    valid = false;
                }
            }
            return input;
        }

        static string CreateName(string firstFile, string secondFile)
        {
            string newName = firstFile.Substring(0, firstFile.Length - 4) + secondFile;
            return newName;
        }

        static int WriteFile(StreamWriter name, string file)
        {
            int count = 0;
            StreamReader newMerged = null;

            try
            {
                newMerged = new StreamReader(file);
                string read;
                while ((read = newMerged.ReadLine()) != null)
                {
                    name.WriteLine(read);
                    count += read.Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not write {0} to merged file: {1}", file, e.Message);
            }
            finally
            {
                if (newMerged != null)
                {
                    newMerged.Close();
                }
            }

            return count;
        }
    }
}
