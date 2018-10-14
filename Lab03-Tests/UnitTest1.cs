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

        /*
        Test that a file can be created
        Test that a file can be updated
        Test that a file can be deleted
        Test that a word can be added to a file
        Test that you can retrieve all words from the file
        Test that the word chosen can accurately detect if the letter exists in the word(test that a letter does exist and does not exist)
        */

        [Theory]
        [InlineData(false, "../testFile.txt", "chocolate")]
        public void CanUpdateByDeletingWord(bool expected, string path, string wordToDelete)
        {
            AppendToFile(path, wordToDelete);
            DeleteLineFromFile(path, wordToDelete);
            bool isContainedInFile = ReadFile(path).Contains(wordToDelete);
            Assert.Equal(expected, isContainedInFile);
        }
    }
}
