using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab03_SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";
            CreateFile(path);
            //AppendToFile(path, seedFile);
            //Console.WriteLine(ReadFile(path));
            //AppendToFile(path, Console.ReadLine());

            //DeleteLineFromFile(path, "chocolate");
            string randomWord = ChooseRandomWordFromFile(path);
            StringBuilder underScoredWord = DisplayUnderscoresFromChosenWord(randomWord);
            Console.WriteLine(String.Join(" ", underScoredWord.ToString().ToCharArray()));
            string userInput = GetUserGuess();

            // while not won
            Console.WriteLine(String.Join(" ", CheckIfUserGuessIsInChosenWord(userInput, randomWord, underScoredWord).ToString().ToCharArray()));
            Console.ReadLine();
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

        /// <summary>
        /// This method chooses a random word from my words.txt file using the Random class.
        /// </summary>
        /// <param name="path">relative path of file containing available words</param>
        /// <returns>the chosen word</returns>
        public static string ChooseRandomWordFromFile(string path)
        {
            Random rand = new Random();
            int randIdx = rand.Next(ReadFile(path).Length);

            return ReadFile(path)[randIdx];
        }

        /// <summary>
        /// This method takes the length of the random word and returns a new string of underscores in order to display it to the console. This is to mimic a word guessing game.
        /// For example, a 5 letter word would display like so:
        /// _ _ _ _ _
        /// </summary>
        /// <param name="path">relative path of file containing words</param>
        /// <returns>a string of underscores</returns>
        public static StringBuilder DisplayUnderscoresFromChosenWord(string chosenWord)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < chosenWord.Length; i++)
            {
                sb.Append("_");
            }

            return sb;
        }

        /// <summary>
        /// This method directs the user to guess only one letter and checks the length of the user input string. If it's exactly one letter, the user input string will be returned, if not the user will be continually prompted to guess.
        /// </summary>
        /// <returns>one character string</returns>
        public static string GetUserGuess()
        {
            string userInput;

            do
            {
                Console.WriteLine("Guess a letter. Make sure you're only guessing one letter!");
                userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    userInput = "Goodbye! Thanks for playing!";
                    break;
                }

            } while (userInput.Length != 1);

            return userInput;
        }

        /// <summary>
        /// This method uses StringComparison.CurrentCultureIgnoreCase and Regex to do a case insensitive string comparison between their references.
        /// I use regex to check if there even is a match in the word before trying to find the index of the guessed letter. This is to avoid a common exception. Instead of using a try-catch, I use regex and an if statement in order to execute less code.
        /// </summary>
        /// <param name="userInput">1 character length string the user guesses</param>
        /// <param name="chosenWord">the random word for current game</param>
        /// <param name="sb">StringBuilder object returned from DisplayUnderscoresFromChosenWord method</param>
        /// <returns>true or false, depending on whether the chosen word contains the guessed letter</returns>
        public static StringBuilder CheckIfUserGuessIsInChosenWord(string userInput, string chosenWord, StringBuilder sb)
        {
            bool guessRight = Regex.IsMatch(chosenWord, userInput, RegexOptions.IgnoreCase);

            // ToString() does not create a new object in memory. It simply returns the object.
            if (guessRight)
            {
                userInput = userInput.PadRight(1);

                for (int i = 0; i < chosenWord.Length; i++)
                {
                    if (chosenWord[i].ToString().Equals(userInput, StringComparison.CurrentCultureIgnoreCase))
                    {
                        sb.Remove(i, 1);
                        sb.Insert(i, userInput, 1);
                    }
                }
            }
            else Console.WriteLine("not right");

            return sb;
        }
    }
}