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
        ///  
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        public static bool DeleteLineFromFile(string path, string lineToRemove)
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

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool DeleteAFile(string path)
        {

        }
    }
}
