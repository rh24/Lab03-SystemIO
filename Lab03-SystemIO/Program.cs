using System;
using System.IO;

namespace Lab03_SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Create("words.txt");
        }

        static void Create(string path)
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
    }
}
