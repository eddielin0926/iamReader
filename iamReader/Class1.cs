using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace iamReader
{
        class Chapter
        {
            public string Title;
            public string Website;
            public string Content;
            public Chapter()
            {
                Title = "";
                Content = "";
                Website = "";
            }
            public Chapter(string title)
            {
                Title = title;
                Content = "";
                Website = "";
            }
            public async Task Page_Download()
            {
                var url = Website;
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                List<HtmlNode> list = htmlDocument.DocumentNode.Descendants("div")
                       .Where(node => node.GetAttributeValue("class", "")
                       .Equals("content")).ToList();
                Content = list[0].InnerText;
            }
        }
    }

