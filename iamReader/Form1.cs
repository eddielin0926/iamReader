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
            string downloadUrl = @"http://big5.quanben5.com/n/jingsongleyuan/xiaoshuo.html";
            Book book = new Book();

            book.LoadBook(downloadUrl);
            Console.WriteLine("Finish Download");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DownloadBtn.PerformClick();

            this.Hide();
        }
    }
}
