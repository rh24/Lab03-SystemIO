using System;
using System.IO;
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
        [InlineData(true, "../../../testFile.txt")]
        public void FileCreates(bool expected, string path)
        {
            Assert.Equal(expected, CreateFile(path));
            File.Delete(path);
        }
    }
}
