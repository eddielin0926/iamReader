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
        
         public async void GetHtmlAsync()
        {          
            HttpClient httpClient = new HttpClient();
            
            string html = await  httpClient.GetStringAsync(book.Path);
            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);            
            
            var title= htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("title")).ToList();
            var content = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("content")).ToList();

            book.Title = title[0].InnerText;
            book.Content=content[0].InnerText;

               

        }
        public void Get_Website(string url= "https://tw.richity.com/novel/pagea/douluodalu-tangjiasanshao_2.html")
        {
            book.Path = url;
        }
    }
}
