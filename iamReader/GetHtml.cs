using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Xml;


namespace iamReader
{
    class GetHtml
    {
        
        public Book book = new Book();
        static public Chapter chapter;
        public async Task GetHtmlAsync()
        {
            HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(book.Path);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var chapterList = htmlDocument.DocumentNode.SelectNodes("//li");
            for (int i = 55; i < chapterList.Count; i++)
            {
                var chapterUrl = chapterList[i];
                chapter = new Chapter(chapterUrl.InnerText);
                chapter.Website = "https:" + chapterUrl.Descendants("a").FirstOrDefault().GetAttributeValue("href", "");
                Console.Write(chapter.Title + chapter.Website + "\r\n");
                await chapter.Page_Download();
                Console.Write("download" + "\r\n");
                book.chapter_List.Add(chapter);
            } 
        }
        public void Get_Website(string url)
        {
            book.Path = url;
        }
    }
}
