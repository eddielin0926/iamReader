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
        static IEnumerable<Chapter> s_urlList = null;
        static public List<string> contentList = new List<string>();
        static readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };
        public static async Task<string> GetBookTitleAsync(string sourceUrl)
        {
            string tableHtmlString = await s_client.GetStringAsync(sourceUrl);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(tableHtmlString);
            char[] charsToTrim = { '《', '》', ' ' };
            string title = document.DocumentNode.SelectSingleNode("//span[@class='title']").InnerText;
            return title;
        }
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
            foreach (var node in chapterList)
            {
                Chapter chapter = new Chapter();
                chapter.Title = node.InnerText;
                chapter.Website = "http:" + node.Attributes["href"].Value;
                book.chapter_List.Add(chapter);

                Console.WriteLine("{0} {1}", PadRightChinese(chapter.Title, 35), chapter.Website);
            }

            s_urlList = book.chapter_List.ToArray();

            /// <summary>
            /// Thread Pool
            /// </summary>
            IEnumerable<Task<Chapter>> downloadTasksQuery =
                from url in s_urlList
                select ProcessUrlAsync(url, s_client);

            List<Task<Chapter>> downloadTasks = downloadTasksQuery.ToList();

            int total = 0;
            int totalTask = s_urlList.Count();
            int i = 0;
            while (downloadTasks.Any())
            {
                Task<Chapter> finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
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
            foreach (var chapter in book.chapter_List)
            {
                ParserParagraph(chapter);
            }
            return book;
        }

        static async Task<Chapter> ProcessUrlAsync(Chapter chapter, HttpClient client)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    chapter.Content = await client.GetStringAsync(chapter.Website);
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            if (chapter.Content == null)
            {
                Console.WriteLine($"Failed: {chapter.Website,-60}");
            }
            return chapter;
        }

        static Chapter ParserParagraph(Chapter chapter)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(chapter.Content);
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
