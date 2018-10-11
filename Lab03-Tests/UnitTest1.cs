using System;
using Xunit;
using static Lab03_SystemIO.Program;

namespace Lab03_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("../../../testFile.txt", true)]
        public void FileCreates(string expected, bool created)
        {
            Assert.Equal(created, CreateFile(expected));
        }
    }
}
