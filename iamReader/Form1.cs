using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace iamReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            string sourceWeb = @"http://big5.quanben5.com";
            string downloadUrl = @"http://big5.quanben5.com/n/jingsongleyuan/xiaoshuo.html";

            WebClient client = new WebClient();
            MemoryStream data = new MemoryStream(client.DownloadData(downloadUrl));
            Console.WriteLine("Download data from: {0}", downloadUrl);

            HtmlDocument document = new HtmlDocument();
            document.Load(data, Encoding.UTF8);
            Console.WriteLine("Decode data by UTF-8");

            var chapterList = document.DocumentNode.SelectNodes("//li");
            foreach (var chapter in chapterList)
            {
                Console.WriteLine("{0} : {1}", chapter.InnerText, sourceWeb + chapter.SelectSingleNode(".//a[@href]").Attributes["href"].Value);
            }

            Console.WriteLine("");
        }
    }
}
