using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using System.Diagnostics;

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
        public List<Chapter> Chapters;

        public IEnumerable<string> urlArray;

        public Book()
        {
            File = null;
            Title = "";
            Path = "";
            Author = "";
            Content = "";
            Article = 0;
            Chapters = new List<Chapter>();
        }
        public Book(string title, string path, string author, string content,  int article)
        {
            File = new FileInfo(path);
            Title = title;
            Path = path;
            Author = author;
            Content = content;
            Article = 0;
            Chapters = new List<Chapter>();
        }
        public void LoadBook(string url)
        {
            string sourceWeb = @"http://big5.quanben5.com";
            string downloadUrl = @"http://big5.quanben5.com/n/jingsongleyuan/xiaoshuo.html";

            WebClient client = new WebClient();
            MemoryStream data = new MemoryStream(client.DownloadData(downloadUrl));
            Console.WriteLine("Download data from: {0}", downloadUrl);

            HtmlDocument document = new HtmlDocument();
            document.Load(data, Encoding.UTF8);
            Console.WriteLine("Decode data by UTF-8");

            int total = 0;
            var chapterList = document.DocumentNode.SelectNodes("//li");
            var urlList = new List<string>();

            Console.WriteLine("Start Download ...");
            var stopwatch = Stopwatch.StartNew();

            foreach (var chapter in chapterList)
            {
                string chapteTitle = chapter.InnerText;
                string chapterUrl = sourceWeb + chapter.SelectSingleNode(".//a[@href]").Attributes["href"].Value;
                urlList.Add(chapterUrl);
                //Console.WriteLine(chapterUrl);
                Chapter chap = new Chapter();
                chap.LoadChapter(chapterUrl);
            }

            stopwatch.Stop();

            Console.WriteLine("Finish Download");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");

            urlArray = urlList.ToArray();

            Console.WriteLine("Finish LoadBook");
        }
    }

    class Chapter
    {
        public string Title;
        public string Content;

        public Chapter()
        {
            Title = "";
            Content = "";
        }

        public void LoadChapter(string url)
        {
            WebClient client = new WebClient();
            MemoryStream data = new MemoryStream(client.DownloadData(url));

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(data, Encoding.UTF8);

            Title = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='title1']").InnerText;
            var text = htmlDocument.DocumentNode.SelectNodes("//div[@id='content']/p").ToList();
            foreach (var line in text)
            {
                Content += line.InnerText + "\n";
            }
            Console.WriteLine(url);
        }
    }
}
