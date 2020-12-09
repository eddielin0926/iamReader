using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string DownloadUrl = @"http://big5.quanben5.com/n/jingsongleyuan/xiaoshuo.html";
            Console.WriteLine("Download from: {0}", DownloadUrl);

            WebClient Client = new WebClient();
            var Data = Client.DownloadData(DownloadUrl);
            string Page = Encoding.UTF8.GetString(Data);
            HtmlDocument Document = new HtmlDocument();
            Document.LoadHtml(Page);

            Console.WriteLine(Document.Text);
        }
    }
}
