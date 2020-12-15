using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace iamReader
{
        
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Home();
           
        }

        private void DownloadButton_Click(object sender, EventArgs e) {
            Read();
        }


        // 預設為淺色模式
        bool DarkMode = false;

        // 深色模式
        private void DarkModeButton_Click(object sender, EventArgs e) {
            // 改為淺色模式
            if (DarkMode) {
                Console.WriteLine("Turn to bright mode");
                DarkMode = false;

                BackColor = Color.FromArgb(255, 255, 255);

                NovelTextBox.BackColor = this.BackColor;
                NovelTextBox.ForeColor = Color.FromArgb(64, 64, 64);

                ChapterLabel.BackColor = this.BackColor;
                ChapterLabel.ForeColor = Color.FromArgb(64, 64, 64);

                DarkModeButton.BackColor = Color.FromArgb(64, 64, 64);
                DarkModeButton.ForeColor = Color.FromArgb(255, 255, 255);

                HomeButton.BackColor = Color.FromArgb(64, 64, 64);
                HomeButton.ForeColor = Color.FromArgb(255, 255, 255);

                DarkModeButton.Text = "深色模式";
            } 
            // 改為深色模式
            else {
                Console.WriteLine("Turn to dark mode");
                DarkMode = true;

                BackColor = Color.FromArgb(64, 64, 64);

                NovelTextBox.BackColor = this.BackColor;
                NovelTextBox.ForeColor = Color.FromArgb(255, 255, 255);

                ChapterLabel.BackColor = this.BackColor;
                ChapterLabel.ForeColor = Color.FromArgb(255, 255, 255);
                
                DarkModeButton.BackColor = Color.FromArgb(255, 255, 255);
                DarkModeButton.ForeColor = Color.FromArgb(64, 64, 64);

                HomeButton.BackColor = Color.FromArgb(255, 255, 255);
                HomeButton.ForeColor = Color.FromArgb(64, 64, 64);

                DarkModeButton.Text = "淺色模式";
            }
        }

        // 主頁
        private void Home() {
            WebsiteTextBox.Visible = true;
            DownloadButton.Visible = true;
            NovelTextBox.Visible = false;
            DarkModeButton.Visible = false;
            HomeButton.Visible = false;
            ChapterLabel.Visible = false;
            FontSizeTextBox.Visible = false;
            IncreaseFontSize.Visible = false;
            DecreaseFontSize.Visible = false;
        }

        // 閱讀畫面
        private async Task Read() {
            var getHtml = new GetHtml();
            string url = WebsiteTextBox.Text;
            Console.WriteLine("Download from: {0}", url);
            getHtml.Get_Website(url);
            string content = await getHtml.GetHtmlAsync();
            Console.WriteLine("Loading content");

            WebsiteTextBox.Visible = false;
            DownloadButton.Visible = false;
            NovelTextBox.Visible = true;
            DarkModeButton.Visible = true;
            HomeButton.Visible = true;
            ChapterLabel.Visible = true;
            FontSizeTextBox.Visible = true;
            IncreaseFontSize.Visible = true;
            DecreaseFontSize.Visible = true;

            NovelTextBox.ReadOnly = true;
            NovelTextBox.Multiline = true;
            NovelTextBox.ScrollBars = ScrollBars.Vertical;
            NovelTextBox.SelectedText = NovelTextBox.Text + "\r\n";
            NovelTextBox.ScrollToCaret();

            //測試用隨便打的
            NovelTextBox.Text = content;

            FontSizeTextBox.Text = Convert.ToString(NovelTextBox.Font.Size);
        }

        // 回主頁
        private void HomeButton_Click(object sender, EventArgs e) {
            Home();
        }

        // 調整字體大小
        private void IncreaseFontSize_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Increase font size");
            NovelTextBox.Font = new Font(NovelTextBox.Font.FontFamily, NovelTextBox.Font.Size + 1);
            FontSizeTextBox.Text = Convert.ToString(NovelTextBox.Font.Size);
        }

        private void DecreaseFontSize_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Decrease font size");
            NovelTextBox.Font = new Font(NovelTextBox.Font.FontFamily, NovelTextBox.Font.Size - 1);
            FontSizeTextBox.Text = Convert.ToString(NovelTextBox.Font.Size);
        }
    }
}
