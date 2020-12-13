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
            WordSizeTrackBar.Visible = false;
        }

        // 閱讀畫面
        private void Read() {
            WebsiteTextBox.Visible = false;
            DownloadButton.Visible = false;
            NovelTextBox.Visible = true;
            DarkModeButton.Visible = true;
            HomeButton.Visible = true;
            ChapterLabel.Visible = true;
            WordSizeTrackBar.Visible = true;

            NovelTextBox.ReadOnly = true;
            NovelTextBox.Multiline = true;
            NovelTextBox.ScrollBars = ScrollBars.Vertical;
            NovelTextBox.SelectedText = NovelTextBox.Text + "\r\n";
            NovelTextBox.ScrollToCaret();

            //測試用隨便打的
            NovelTextBox.Text = "朋友買了一件衣料，綠色的底子帶白色方格，" +
                "當她拿給我們看時，一位對圍棋十分感與趣的同學說：「啊，好像棋" +
                "盤似的。」「我看倒有點像稿紙。」我說。「真像一塊塊綠豆糕。」一位外號" +
                "叫「大食客」的同學緊接著說。 我們不禁哄堂大笑，同樣的一件衣料，每個人卻有" +
                "不同的感覺。那位朋友連忙把衣料用紙包好，她覺得衣料就是衣料，" +
                "不是棋盤，也不是稿紙，更不是綠豆糕。 人人的欣賞觀點不盡相同，那是和" +
                "個人的性格與生活環境有關。如果經常逛布店的話，便會發現很少有一匹布沒有" +
                "人選購過；換句話說，任何質地或花色的衣料，都有人欣賞它。一位鞋店的老闆曾" +
                "指著櫥窗裡一雙式樣毫不漂亮的鞋子說：「無論怎麼難看的樣子，還是有人喜歡，所以" +
                "不怕賣不出去。」 就以「人」來說，又何嘗不是如此？也許我們看某人不順眼，但是在" +
                "他的男友和女友心中，往往認為他如「天仙」或「白馬王子」般地完美無缺。 人總會去尋求" +
                "自己喜歡的事物，每個人的看法或觀點不同，並沒有什麼關係，重要的是──人與人之間，應該" +
                "有彼此容忍和尊重對方的看法與觀點的雅量。如果他能從這扇門望見日出的美景，你又何必要" +
                "他走向那扇窗去聆聽鳥鳴呢？你聽你的鳥鳴，他看他的日出，彼此都會有等量的美的感受。人與" +
                "人偶有摩擦，往往都是由於缺乏那分雅量的緣故；因此，為了減少摩擦，增進和諧，我們必須努" +
                "力培養雅量。";
        }

        // 回主頁
        private void HomeButton_Click(object sender, EventArgs e) {
            Home();
        }

        // 調整字體大小
        private void WordSizeTrackBar_Scroll(object sender, EventArgs e) {
            NovelTextBox.Font = new Font("微軟正黑體", WordSizeTrackBar.Value + 10);
        }
    }
}
