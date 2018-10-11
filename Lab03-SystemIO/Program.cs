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
            //ReadFile(path);
            //AppendToFile(path);

            //DeleteLineFromFile(path);
        }

        public static bool CreateFile(string path)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {
                try
                {
                    sw.WriteLine("chocolate");
                    sw.WriteLine("moist");
                    sw.WriteLine("turtles");
                    sw.WriteLine("easter");
                    sw.WriteLine("christmas");
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

            return File.Exists(path);
        }
    }
}
