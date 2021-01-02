using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Xml;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace iamReader
{
    class GetHtml
    {
        public Book book = new Book();
        static public Chapter chapter;
        public async Task<Book> GetHtmlAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(book.Path);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            //book detail
            var title = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("title")).ToList();
            book.Title = title[0].InnerText;
            var content = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("description")).ToList();
            book.Content = content[0].InnerText;
            var author = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("author")).ToList();
            book.Author = author[0].InnerText;
            //chapter_list
            var chapterList = htmlDocument.DocumentNode.SelectNodes("//li");
            for (int i = 55; i < chapterList.Count; i++)
            {
                var chapterUrl = chapterList[i];
                chapter = new Chapter(chapterUrl.InnerText);
                try
                {
                    chapter.Website = "https:" + chapterUrl.Descendants("a").FirstOrDefault().GetAttributeValue("href", "");
                    Console.Write(chapter.Title + chapter.Website + "\r\n");
                    Console.Write("download" + "\r\n");
                    await chapter.Page_Download();
                }
                catch
                {
                    chapter.Content = "to next chapter";
                    Console.Write("NULL content" + "\r\n");
                }
                book.chapter_List.Add(chapter);
            }

            stopwatch.Stop();
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");

            return book;
        }
        public void Get_Website(string url)
        {
            book.Path = url;
        }

        /// <summary>
        /// Eddie's version
        /// </summary>
        static IEnumerable<string> s_urlList = null;
        static public List<string> contentList = new List<string>();
        static readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };
        public static async Task<Book> DownloadBookAsync(string sourceUrl)
        {
            Book book = new Book();

            //s_client.BaseAddress = new Uri("https://czbooks.net/");
            Console.WriteLine("Start Download ...");
            var stopwatch = Stopwatch.StartNew();

            /// <summary>
            /// List out chapters' url
            /// </summary>
            Console.WriteLine("List out chapter");
            string tableHtmlString = await s_client.GetStringAsync(sourceUrl);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(tableHtmlString);

            var chapterList = document.DocumentNode.SelectNodes("//ul[@class='nav chapter-list']/li/a");
            var urlList = new List<string>();
            foreach (var chapter in chapterList)
            {
                string chapterTitle = chapter.InnerText;
                string chapterUrl = chapter.Attributes["href"].Value;
                urlList.Add("http:" + chapterUrl);

                Console.WriteLine("{0} {1}", PadRightChinese(chapterTitle, 35), chapterUrl);
            }

            s_urlList = urlList.ToArray();

            /// <summary>
            /// Thread Pool
            /// </summary>
            IEnumerable<Task<string>> downloadTasksQuery =
                from url in s_urlList
                select ProcessUrlAsync(url, s_client);

            List<Task<string>> downloadTasks = downloadTasksQuery.ToList();

            int total = 0;
            int totalTask = s_urlList.Count();
            int i = 0;
            string content = null;
            while (downloadTasks.Any())
            {
                Task<string> finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                content = await finishedTask;
                contentList.Add(content);
                Console.Write("\rDownloading ... {0}% ", ++i * 100 / totalTask);
            }

            stopwatch.Stop();

            /// <summary>
            /// Show Exceution Result
            /// </summary>
            Console.WriteLine("\nFinish Download {0} pages", i);
            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");

            /// <summary>
            /// Parser HTML of Paragraph
            /// </summary>
            foreach (var chapter in contentList)
            {
                book.chapter_List.Add(ParserParagraph(chapter));
            }
            return book;
        }

        static async Task<string> ProcessUrlAsync(string url, HttpClient client)
        {
            string content = null;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    content = await client.GetStringAsync(url);
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            if (content == null)
            {
                Console.WriteLine($"Failed: {url,-60}");
                return "";
            }
            return content;
        }

        static Chapter ParserParagraph(string html)
        {
            Chapter chapter = new Chapter();
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            chapter.Title = document.DocumentNode.SelectSingleNode("//div[@class='name']").InnerText;
            chapter.Content = document.DocumentNode.SelectSingleNode("//div[@class='content']").InnerText;
            return chapter;
        }

        static string PadRightChinese(string str, int alignment)
        {
            int chineseCharacters = new Regex(@"[^\u4e00-\u9fa5]").Replace(str, "").Length;
            return str.PadRight(alignment - chineseCharacters);
        }
    }
}
