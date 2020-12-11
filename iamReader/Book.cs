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
using System.Threading;

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

        static readonly HttpClient Client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };
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
        public async Task LoadBook(string downloadUrl)
        {
            var stopwatch = Stopwatch.StartNew();

            string sourceWeb = @"http://big5.quanben5.com";

            // List out chapters
            WebClient client = new WebClient();
            MemoryStream data = new MemoryStream(client.DownloadData(downloadUrl));
            Console.WriteLine("Download data from: {0}", downloadUrl);

            HtmlDocument document = new HtmlDocument();
            document.Load(data, Encoding.UTF8);
            Console.WriteLine("Decode data by UTF-8");

            var chapterList = document.DocumentNode.SelectNodes("//li");
            var urlList = new List<string>();

            Console.WriteLine("Start Download ...");

            foreach (var chapter in chapterList)
            {
                string chapteTitle = chapter.InnerText;
                string chapterUrl = sourceWeb + chapter.SelectSingleNode(".//a[@href]").Attributes["href"].Value;
                urlList.Add(chapterUrl);
            }

            urlArray = urlList.ToArray();

            IEnumerable<Task<int>> downloadTasksQuery =
                from url in urlArray
                select LoadChapterAsync(url, Client);

            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            int totalByte = 0;
            while (downloadTasks.Any())
            {
                Task<int> finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                totalByte += await finishedTask;
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {totalByte:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
        }
        public async Task<int> LoadChapterAsync(string url, HttpClient client)
        {
            byte[] content = null;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    content = await client.GetByteArrayAsync(url);
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
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
        public Chapter(string title)
        {
            Title = title;
            Content = "";
        }
        public void DataDecode(string data)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(data, Encoding.UTF8);

            Title = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='title1']").InnerText;
            var text = htmlDocument.DocumentNode.SelectNodes("//div[@id='content']/p").ToList();
            foreach(var line in text)
            {
                Content += line.InnerText + "\n";
            }
        }
    }
}
