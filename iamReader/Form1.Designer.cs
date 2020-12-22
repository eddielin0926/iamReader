namespace iamReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WebsiteTextBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DarkModeButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.NovelTextBox = new System.Windows.Forms.TextBox();
            this.ChapterLabel = new System.Windows.Forms.Label();
            this.FontSizeTextBox = new System.Windows.Forms.TextBox();
            this.IncreaseFontSize = new System.Windows.Forms.Button();
            this.DecreaseFontSize = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.WebsiteLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.OpenBookTimer = new System.Windows.Forms.Timer(this.components);
            this.CloseBookTimer = new System.Windows.Forms.Timer(this.components);
            this.BackToChapterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WebsiteTextBox
            // 
            this.WebsiteTextBox.Location = new System.Drawing.Point(175, 390);
            this.WebsiteTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WebsiteTextBox.Name = "WebsiteTextBox";
            this.WebsiteTextBox.Size = new System.Drawing.Size(270, 22);
            this.WebsiteTextBox.TabIndex = 0;
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(65)))));
            this.DownloadButton.Font = new System.Drawing.Font("細明體-ExtB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DownloadButton.ForeColor = System.Drawing.Color.Linen;
            this.DownloadButton.Location = new System.Drawing.Point(457, 429);
            this.DownloadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(58, 27);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "下載";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DarkModeButton
            // 
            this.DarkModeButton.BackColor = System.Drawing.Color.Transparent;
            this.DarkModeButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DarkModeButton.ForeColor = System.Drawing.Color.White;
            this.DarkModeButton.Location = new System.Drawing.Point(556, 16);
            this.DarkModeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DarkModeButton.Name = "DarkModeButton";
            this.DarkModeButton.Size = new System.Drawing.Size(123, 30);
            this.DarkModeButton.TabIndex = 3;
            this.DarkModeButton.Text = "深色模式";
            this.DarkModeButton.UseVisualStyleBackColor = false;
            this.DarkModeButton.Click += new System.EventHandler(this.DarkModeButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.Transparent;
            this.HomeButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Location = new System.Drawing.Point(556, 179);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(123, 34);
            this.HomeButton.TabIndex = 4;
            this.HomeButton.Text = "回主頁";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // NovelTextBox
            // 
            this.NovelTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NovelTextBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NovelTextBox.Location = new System.Drawing.Point(21, 84);
            this.NovelTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NovelTextBox.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.NovelTextBox.MinimumSize = new System.Drawing.Size(300, 600);
            this.NovelTextBox.Name = "NovelTextBox";
            this.NovelTextBox.Size = new System.Drawing.Size(529, 600);
            this.NovelTextBox.TabIndex = 6;
            // 
            // ChapterLabel
            // 
            this.ChapterLabel.AutoSize = true;
            this.ChapterLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChapterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChapterLabel.Location = new System.Drawing.Point(21, 30);
            this.ChapterLabel.MaximumSize = new System.Drawing.Size(199, 30);
            this.ChapterLabel.MinimumSize = new System.Drawing.Size(199, 30);
            this.ChapterLabel.Name = "ChapterLabel";
            this.ChapterLabel.Size = new System.Drawing.Size(199, 30);
            this.ChapterLabel.TabIndex = 7;
            this.ChapterLabel.Text = "章節";
            this.ChapterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontSizeTextBox
            // 
            this.FontSizeTextBox.Location = new System.Drawing.Point(556, 70);
            this.FontSizeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FontSizeTextBox.Name = "FontSizeTextBox";
            this.FontSizeTextBox.Size = new System.Drawing.Size(37, 22);
            this.FontSizeTextBox.TabIndex = 8;
            // 
            // IncreaseFontSize
            // 
            this.IncreaseFontSize.Location = new System.Drawing.Point(625, 70);
            this.IncreaseFontSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IncreaseFontSize.Name = "IncreaseFontSize";
            this.IncreaseFontSize.Size = new System.Drawing.Size(37, 22);
            this.IncreaseFontSize.TabIndex = 9;
            this.IncreaseFontSize.Text = "+";
            this.IncreaseFontSize.UseVisualStyleBackColor = true;
            this.IncreaseFontSize.Click += new System.EventHandler(this.IncreaseFontSize_Click);
            // 
            // DecreaseFontSize
            // 
            this.DecreaseFontSize.Location = new System.Drawing.Point(669, 70);
            this.DecreaseFontSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DecreaseFontSize.Name = "DecreaseFontSize";
            this.DecreaseFontSize.Size = new System.Drawing.Size(37, 22);
            this.DecreaseFontSize.TabIndex = 10;
            this.DecreaseFontSize.Text = "-";
            this.DecreaseFontSize.UseVisualStyleBackColor = true;
            this.DecreaseFontSize.Click += new System.EventHandler(this.DecreaseFontSize_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(65)))));
            this.ExitButton.Font = new System.Drawing.Font("細明體-ExtB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExitButton.ForeColor = System.Drawing.Color.Linen;
            this.ExitButton.Location = new System.Drawing.Point(289, 507);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(140, 48);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "離開";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // WebsiteLabel
            // 
            this.WebsiteLabel.AutoSize = true;
            this.WebsiteLabel.BackColor = System.Drawing.Color.Transparent;
            this.WebsiteLabel.Font = new System.Drawing.Font("細明體-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WebsiteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(65)))));
            this.WebsiteLabel.Location = new System.Drawing.Point(171, 352);
            this.WebsiteLabel.Name = "WebsiteLabel";
            this.WebsiteLabel.Size = new System.Drawing.Size(110, 24);
            this.WebsiteLabel.TabIndex = 15;
            this.WebsiteLabel.Text = "輸入網址";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(65)))));
            this.StartButton.Font = new System.Drawing.Font("細明體-ExtB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartButton.ForeColor = System.Drawing.Color.Linen;
            this.StartButton.Location = new System.Drawing.Point(289, 445);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 48);
            this.StartButton.TabIndex = 12;
            this.StartButton.Text = "開始";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // OpenBookTimer
            // 
           
            // 
            // CloseBookTimer
            // 

            // 
            // BackToChapterButton
            // 
            this.BackToChapterButton.BackColor = System.Drawing.Color.Transparent;
            this.BackToChapterButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BackToChapterButton.ForeColor = System.Drawing.Color.White;
            this.BackToChapterButton.Location = new System.Drawing.Point(556, 124);
            this.BackToChapterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackToChapterButton.Name = "BackToChapterButton";
            this.BackToChapterButton.Size = new System.Drawing.Size(164, 42);
            this.BackToChapterButton.TabIndex = 16;
            this.BackToChapterButton.Text = "回章節";
            this.BackToChapterButton.UseVisualStyleBackColor = false;
            this.BackToChapterButton.Click += new System.EventHandler(this.BackToChapterButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(732, 953);
            this.Controls.Add(this.BackToChapterButton);
            this.Controls.Add(this.WebsiteLabel);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.DecreaseFontSize);
            this.Controls.Add(this.IncreaseFontSize);
            this.Controls.Add(this.FontSizeTextBox);
            this.Controls.Add(this.ChapterLabel);
            this.Controls.Add(this.NovelTextBox);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.DarkModeButton);
            this.Controls.Add(this.WebsiteTextBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iamReader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WebsiteTextBox;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button DarkModeButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.TextBox NovelTextBox;
        private System.Windows.Forms.Label ChapterLabel;
        private System.Windows.Forms.TextBox FontSizeTextBox;
        private System.Windows.Forms.Button IncreaseFontSize;
        private System.Windows.Forms.Button DecreaseFontSize;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label WebsiteLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer OpenBookTimer;
        private System.Windows.Forms.Timer CloseBookTimer;
        private System.Windows.Forms.Button BackToChapterButton;
    }
}

