using System;
using System.IO;
using System.Linq;
using Xunit;
using static Lab03_SystemIO.Program;

namespace Lab03_Tests
{
    public class UnitTest1
    {
        /// <summary>
        /// Create a test file to test that file gets created and exists in repo. I want to delete the file afterwards.
        /// </summary>
        /// <param name="expected">test file path</param>
        /// <param name="created">boolean returned from method</param>
        [Theory]
        [InlineData(true, "../testFile.txt")]
        public void FileCreates(bool expected, string path)
        {
            Assert.Equal(expected, CreateFile(path));
        }

        [Theory]
        [InlineData(true, "../testFile.txt", "hello world")]
        public void CanRead(bool expected, string path, string appendText)
        {
            AppendToFile(path, appendText);
            bool isContainedInFile = ReadFile(path).Contains(appendText);
            Assert.Equal(expected, isContainedInFile);
        }

        /// <summary>
        /// This method tests whether all words can be retrieved from a file. The words currently contained in ../testFile.txt are "hello world." I will add more words in this method.
        /// </summary>
        /// <param name="expected">expected outcome</param>
        /// <param name="path">file to read</param>
        // Do we not need to use the new keyword anymore for initializing new arrays?
        public static string[] words = new string[] { "birds", "feather" };

        [Theory]
        [InlineData(true, "../testFile.txt")]
        public static void RetreiveAllWords(bool expected, string path)
        {
            AppendToFile(path, words);
            string[] allStringsReturn = ReadFile(path);
            bool recentlyAppendedWordsAreContained = allStringsReturn.Contains("birds") && allStringsReturn.Contains("feather");

            Assert.Equal(expected, recentlyAppendedWordsAreContained);

        }

        /*
        Test that the word chosen can accurately detect if the letter exists in the word(test that a letter does exist and does not exist)
        */

        /// <summary>
        /// This method
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="path"></param>
        /// <param name="wordToDelete"></param>
        [Theory]
        [InlineData(false, "../testFile.txt", "chocolate")]
        public void CanUpdateByDeletingWord(bool expected, string path, string wordToDelete)
        {
            AppendToFile(path, wordToDelete);
            DeleteLineFromFile(path, wordToDelete);
            bool isContainedInFile = ReadFile(path).Contains(wordToDelete);
            Assert.Equal(expected, isContainedInFile);
        }

        /// <summary>
        /// This method tests whether a file gets deleted.
        /// </summary>
        /// <param name="expected">expected outcome</param>
        /// <param name="path">tile to be deleted</param>
        [Theory]
        [InlineData(false, "../testFile.txt")]
        public void CanDeleteAFile(bool expected, string path)
        {
            DeleteAFile(path);
            bool fileExists = File.Exists(path);
            Assert.Equal(expected, fileExists);
        }
    }
}
