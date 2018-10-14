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
            //Console.WriteLine(ReadFile(path));
            //AppendToFile(path, Console.ReadLine());

            DeleteLineFromFile(path, "chocolate");
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
                        //Console.WriteLine(s);
                    }

                    string[] readWords = File.ReadAllLines(path);

                    return readWords;
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// This method takes user input and updates the file with a new word.
        /// </summary>
        /// <param name="path">relative path of file</param>
        /// <param name="userInput">string to add to file</param>
        /// <returns>boolean indicating whether try block was successful</returns>
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
                finally
                {
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// This method will seed the file with strings from an array that exists as a static field within this class.
        /// </summary>
        /// <param name="path">relative path of file</param>
        /// <param name="seedData">field that contains words to write onto file</param>
        public static void AppendToFile(string path, string[] seedData)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                for (int i = 0; i < seedData.Length; i++)
                {
                    sw.WriteLine(seedData[i]);
                }
            }
        }

        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="lineToRemove"></param>
        /// <returns></returns>
        public static void DeleteLineFromFile(string path, string lineToRemove)
        {
            try
            {
                string[] existingWords = ReadFile(path);
                //string[] remainingWords = new string[existingWords.Length - 1];

                File.WriteAllText(path, String.Empty);

                for (int i = 0; i < existingWords.Length; i++)
                {
                    if (!existingWords[i].Contains(lineToRemove))
                    {
                        AppendToFile(path, existingWords[i]);
                    }
                }

                //return remainingWords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method deletes the file of the path passed in.
        /// </summary>
        /// <param name="path">relative path of file to delete</param>
        /// <returns></returns>
        public static bool DeleteAFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            return File.Exists(path);
        }

        public static string ChooseRandomWordFromFile(string path)
        {
            Random rand = new Random();
            int randIdx = rand.Next(ReadFile(path).Length);

            return ReadFile(path)[randIdx];
        }
    }
}
