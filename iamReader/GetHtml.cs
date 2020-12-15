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

        public async Task<string> GetHtmlAsync()
        {
            HttpClient httpClient = new HttpClient();

            string html = await httpClient.GetStringAsync(book.Path);
            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            var title = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("title")).ToList();
            var content = htmlDocument.DocumentNode.SelectNodes("//div[@class='content']/p");
            book.Title = title[0].InnerText;
            foreach(var p in content)
            {
                book.Content += p.InnerText + "\r\n";
            }

            return book.Content;
        }
        public void Get_Website(string url)
        {
            book.Path = url;
        }
    }
}
