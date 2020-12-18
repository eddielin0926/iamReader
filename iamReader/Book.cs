using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace iamReader
{
    class Book
    {
        public FileInfo File;
        public string Title;
        public string Path;
        public string Author;
        public string Content;
        public int Article;
        public List<Chapter> chapter_List=new List<Chapter>();
    }
}
