using System;
using System.IO;

namespace Lab03_SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";
            CreateFile(path);
        }

        static void CreateFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.Create(path))
                    {
                        sw.WriteLine = "moist";
                        sw.WriteLine = "chocolate";
                        sw.WriteLine = "turtles";
                        sw.WriteLine = "easter";
                        sw.WriteLine = "christmas";
                    }
                } 
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
