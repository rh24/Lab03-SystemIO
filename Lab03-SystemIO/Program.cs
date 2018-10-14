using System;
using System.IO;
using System.Text;

namespace Lab03_SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";
            CreateFile(path);
            AppendToFile(path, seedFile);
            Console.WriteLine(ReadFile(path));
            AppendToFile(path, Console.ReadLine());

            //DeleteLineFromFile(path);
        }

        public static string[] seedFile = { "chocolate", "moist", "turtles", "easter", "christmas" };

        /// <summary>
        /// This method creates a file if it doesn't already exist.
        /// </summary>
        /// <param name="path">the relative path of where the file should be created and the file name</param>
        /// <returns>true if file created, false if not</returns>
        public static bool CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.WriteLine("Success!");
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }

            return File.Exists(path);
        }

        /// <summary>
        ///  This method reads the file and populates a string array with the read lines.
        /// </summary>
        /// <param name="path">relative path of file to be read</param>
        /// <returns>an array of strings</returns>
        public static string[] ReadFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                try
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }

                    string[] readWords = File.ReadAllLines(path);

                    return readWords;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static bool AppendToFile(string path, string userInput)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                try
                {
                    sw.WriteLine(userInput);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void AppendToFile(string path, string[] seedData)
        {
            using (StreamWriter sw = File.AppendText(path))
            {

            }
        }

        public static string[] DeleteLineFromFile(string path, string lineToRemove)
        {
            try
            {
                string[] existingWords = ReadFile(path);
                string[] remainingWords = new string[existingWords.Length - 1];

                for (int i = 0; i < existingWords.Length; i++)
                {
                    if (existingWords[i] != lineToRemove)
                    {
                        remainingWords[i] = existingWords[i];
                    }
                }

                return remainingWords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool DeleteAFile(string path)
        {
            File.Delete(path);

            return File.Exists(path);
        }
    }
}
