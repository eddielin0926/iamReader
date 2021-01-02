using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iamReader
{
    static class Program
    {
        public static String Library = @".\library";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(Library))
                {
                    Console.WriteLine("The directory library exists already: {0}", Path.GetFullPath(Library));
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(Library);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(Library));
                    Console.WriteLine("Path: {0}", Path.GetFullPath(Library));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The directory creation failed: {0}", e.ToString());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
