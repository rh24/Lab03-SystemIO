using System;
using System.IO;
using System.Text;

namespace Lab03_SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";
            CreateFile(path);
            //ReadFile(path);
            //AppendToFile(path);

            //DeleteLineFromFile(path);
        }

        static void CreateFile(string path)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {
                try
                {
                    sw.Write("chocolate");
                    sw.Write("moist");
                    sw.Write("turtles");
                    sw.Write("easter");
                    sw.Write("christmas");
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
    }
}
