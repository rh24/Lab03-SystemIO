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
            //AppendToFile(path);

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
        public static bool ReadFile(string path)
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
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw;
                }
            }
        }

        public static bool AppendToFile(string path, string userInput)
        {
            using (StreamWriter sw = File.AppendText(path))
            {

            }
        }

        public static void AppendToFile(string path, string[] seedData)
        {
            using (StreamWriter sw = File.AppendText(path))
            {

            }
        }
    }
}
