using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FindWritableFile
{
    internal class Program
    {   

        public void GetWritable(string[] arg)
        {
            string root = arg[0];
            string filter;
            if (arg.Length > 1)
            {

                filter = arg[1];
            }
            else
            {
                filter = "*";
            }
            var dirs = Directory.EnumerateDirectories(root); 
            foreach (string dir in dirs)
            {
                // Console.WriteLine(dir);
                try
                {
                    var Files = Directory.EnumerateFiles(dir, filter, SearchOption.AllDirectories);
                    foreach (string file in Files)
                    {
                        //Console.WriteLine(File);
                        try
                        {
                            FileStream fs = File.Open(file, FileMode.Open, FileAccess.ReadWrite);
                            Console.WriteLine("Write Aceess On {0}", file);
                             

                        }
                        catch { }

                    }
                }
                catch { }

            }
        }
         

        static void Main(string[] args)
        {
            Program program = new Program();
            string root = args[0];

            program.GetWritable(args);


            Console.ReadKey();

        }
    }
}
