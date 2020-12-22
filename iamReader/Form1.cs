using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace iamReader
{
        
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Cover();
           
        }

        private void DownloadButton_Click(object sender, EventArgs e) {
            Chapter();
        }


        // 預設為淺色模式
        bool DarkMode = false;

        // 深色模式
        private void DarkModeButton_Click(object sender, EventArgs e) {
            // 改為淺色模式
            if (DarkMode) {
                Console.WriteLine("Turn to bright mode");
                DarkMode = false;

                var dir = Directory.GetCurrentDirectory();
                var path = Path.Combine(dir, "Background.png");
                Image Background = new Bitmap(path);
                this.BackgroundImage = Background;

                NovelTextBox.BackColor = Color.FromArgb(255, 255, 255);
                NovelTextBox.ForeColor = Color.FromArgb(64, 64, 64);

                ChapterLabel.BackColor = Color.FromArgb(255, 255, 255);
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

                var dir = Directory.GetCurrentDirectory();
                var path = Path.Combine(dir, "BackgroundDark.png");
                Image Background = new Bitmap(path);
                this.BackgroundImage = Background;

                NovelTextBox.BackColor = Color.FromArgb(64, 64, 64);
                NovelTextBox.ForeColor = Color.FromArgb(255, 255, 255);

                ChapterLabel.BackColor = Color.FromArgb(64, 64, 64);
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
            var dir = Directory.GetCurrentDirectory();
            var path = Path.Combine(dir, "Background.png");
            Image Background = new Bitmap(path);
            this.BackgroundImage = Background;

            StartButton.Visible = false;
            ExitButton.Visible = false;

            WebsiteLabel.Visible = true;
            WebsiteTextBox.Visible = true;
            DownloadButton.Visible = true;

            NovelTextBox.Visible = false;
            DarkModeButton.Visible = false;
            BackToChapterButton.Visible = false;
            HomeButton.Visible = false;
            ChapterLabel.Visible = false;
            FontSizeTextBox.Visible = false;
            IncreaseFontSize.Visible = false;
            DecreaseFontSize.Visible = false;
        }

        private void Cover() {
            StartButton.Visible = true;
            ExitButton.Visible = true;

            WebsiteLabel.Visible = false;
            WebsiteTextBox.Visible = false;
            DownloadButton.Visible = false;

            NovelTextBox.Visible = false;
            DarkModeButton.Visible = false;
            HomeButton.Visible = false;
            BackToChapterButton.Visible = false;
            ChapterLabel.Visible = false;
            FontSizeTextBox.Visible = false;
            IncreaseFontSize.Visible = false;
            DecreaseFontSize.Visible = false;
        }

        private void Chapter() {
            var dir = Directory.GetCurrentDirectory();
            var path = Path.Combine(dir, "Background.png");
            Image Background = new Bitmap(path);
            this.BackgroundImage = Background;

            GenerateChapterButton(true);
            
            StartButton.Visible = false;
            ExitButton.Visible = false;

            WebsiteLabel.Visible = false;
            WebsiteTextBox.Visible = false;
            DownloadButton.Visible = false;

            NovelTextBox.Visible = false;
            DarkModeButton.Visible = false;
            BackToChapterButton.Visible = false;
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
            await getHtml.GetHtmlAsync();
            Console.WriteLine("Loading content");

            StartButton.Visible = false;
            ExitButton.Visible = false;

            WebsiteLabel.Visible = false;
            WebsiteTextBox.Visible = false;
            DownloadButton.Visible = false;

            NovelTextBox.Visible = true;
            DarkModeButton.Visible = true;
            BackToChapterButton.Visible = true;
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
            NovelTextBox.Text = getHtml.book.chapter_List.ElementAt(1).Content;

            FontSizeTextBox.Text = Convert.ToString(NovelTextBox.Font.Size);
        }

        private void OpenCloseBook(bool open) {
            
            if (open) {
                this.Width *= 2;
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            } else {
                this.Width /= 2;
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }
        }

        // 回主頁
        private void HomeButton_Click(object sender, EventArgs e) {
            OpenCloseBook(false);
            Home();
            
        }

        private void ChapterButton_click(object sender, EventArgs e) {
            Button Button = (Button)sender;
            ChapterLabel.Text = Button.Text;
            Read();
            OpenCloseBook(true);
            GenerateChapterButton(false);
        }


        int ChapterNum = 20;
        List<Button> ChapterButton = new List<Button>();
        private void GenerateChapterButton(bool Generate) {
            if (Generate) {
                int ButtonWidth = 90;
                int ButtonHeight = 40;
                for (int i = 0; i < ChapterNum; i++) {
                    Button btn = new Button();
                    btn.Size = new Size(ButtonWidth, ButtonHeight);
                    int ButtonLocationX = this.Width / 2 - ButtonWidth / 2 + (i % 3 - 1) * (ButtonWidth + 10);
                    int ButtonLocationY = this.Height / 2 - ButtonHeight / 2 + (i / 3 - (ChapterNum / 3 + 1) / 2) * (ButtonHeight + 10);
                    btn.Location = new Point(ButtonLocationX, ButtonLocationY);
                    Controls.Add(btn);
                    btn.Click += new EventHandler(ChapterButton_click);
                    btn.Text = "第" + (i + 1) + "章";
                    btn.BackColor = Color.FromArgb(112, 92, 65);
                    btn.ForeColor = Color.Linen;
                    btn.Font = new Font("細明體-ExtB", 10);
                    ChapterButton.Add(btn);
                }
            } else {
                for (int i = 0; i < ChapterButton.Count; i++) {
                    ChapterButton[i].Dispose();
                }
            }
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

        private void StartButton_Click(object sender, EventArgs e) {
            Home();
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

       

        private void BackToChapterButton_Click(object sender, EventArgs e) {
            OpenCloseBook(false);
            Chapter();
           
        }
    }
}
