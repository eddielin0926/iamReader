using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iamReader
{
    class BookSystem
    {
        public static string Library = @".\library\";
        public BookSystem()
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
        }

        public static Book OpenBook(string title)
        {
            string path = Library + title + "\\";
            Console.WriteLine(Library + title);
            // Determine whether the directory exists.
            if (Directory.Exists(Library + title))
            {
                Console.WriteLine("The directory {0} exists already: {1}", title, Path.GetFullPath(path));
                Book book = new Book();
                book.Title = title;
                string[] lines = System.IO.File.ReadAllLines(path + @"\chapters.txt");
                foreach (var line in lines)
                {
                    Chapter chapter = new Chapter();
                    chapter.Title = line;
                    chapter.Content = System.IO.File.ReadAllText(path + line + ".txt");
                    book.chapter_List.Add(chapter);
                }
                return book;
            }
            else
            {
                Console.WriteLine("The directory doesn't exist: {0}", Library + title);
                return null;
            }
        }

        public static Book CloseBook(Book book)
        {
            string path = Library + book.Title + "\\";
            if (!Directory.Exists(Library + book.Title))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                Console.WriteLine("Path: {0}", Path.GetFullPath(path));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + "chapters.txt", true))
                {
                    foreach(var chapter in book.chapter_List)
                    {
                        file.WriteLine(chapter.Title);
                        System.IO.File.WriteAllText(path + chapter.Title + ".txt", chapter.Content);
                    }
                }
            }
            else
            {
                Console.WriteLine("The directory {0} exists already: {1}", book.Title, Path.GetFullPath(path));
            }
            return book;
        }
    }
}
