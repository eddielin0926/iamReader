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
            this.WebsiteTextBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DarkModeButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.NovelTextBox = new System.Windows.Forms.TextBox();
            this.ChapterLabel = new System.Windows.Forms.Label();
            this.WordSizeTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.WordSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // WebsiteTextBox
            // 
            this.WebsiteTextBox.Location = new System.Drawing.Point(305, 294);
            this.WebsiteTextBox.Name = "WebsiteTextBox";
            this.WebsiteTextBox.Size = new System.Drawing.Size(359, 25);
            this.WebsiteTextBox.TabIndex = 0;
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DownloadButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DownloadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DownloadButton.Location = new System.Drawing.Point(692, 286);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(77, 34);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "下載";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DarkModeButton
            // 
            this.DarkModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DarkModeButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DarkModeButton.ForeColor = System.Drawing.Color.White;
            this.DarkModeButton.Location = new System.Drawing.Point(931, 79);
            this.DarkModeButton.Name = "DarkModeButton";
            this.DarkModeButton.Size = new System.Drawing.Size(164, 38);
            this.DarkModeButton.TabIndex = 3;
            this.DarkModeButton.Text = "深色模式";
            this.DarkModeButton.UseVisualStyleBackColor = false;
            this.DarkModeButton.Click += new System.EventHandler(this.DarkModeButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HomeButton.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Location = new System.Drawing.Point(931, 587);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(164, 42);
            this.HomeButton.TabIndex = 4;
            this.HomeButton.Text = "回主頁";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // NovelTextBox
            // 
            this.NovelTextBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NovelTextBox.Location = new System.Drawing.Point(12, 79);
            this.NovelTextBox.MaximumSize = new System.Drawing.Size(890, 500);
            this.NovelTextBox.MinimumSize = new System.Drawing.Size(890, 500);
            this.NovelTextBox.Name = "NovelTextBox";
            this.NovelTextBox.Size = new System.Drawing.Size(890, 500);
            this.NovelTextBox.TabIndex = 6;
            // 
            // ChapterLabel
            // 
            this.ChapterLabel.AutoSize = true;
            this.ChapterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChapterLabel.Location = new System.Drawing.Point(12, 26);
            this.ChapterLabel.MaximumSize = new System.Drawing.Size(200, 30);
            this.ChapterLabel.MinimumSize = new System.Drawing.Size(200, 30);
            this.ChapterLabel.Name = "ChapterLabel";
            this.ChapterLabel.Size = new System.Drawing.Size(200, 30);
            this.ChapterLabel.TabIndex = 7;
            this.ChapterLabel.Text = "章節";
            this.ChapterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WordSizeTrackBar
            // 
            this.WordSizeTrackBar.Location = new System.Drawing.Point(931, 137);
            this.WordSizeTrackBar.Maximum = 30;
            this.WordSizeTrackBar.Minimum = 10;
            this.WordSizeTrackBar.Name = "WordSizeTrackBar";
            this.WordSizeTrackBar.Size = new System.Drawing.Size(164, 56);
            this.WordSizeTrackBar.TabIndex = 8;
            this.WordSizeTrackBar.TickFrequency = 2;
            this.WordSizeTrackBar.Value = 10;
            this.WordSizeTrackBar.Scroll += new System.EventHandler(this.WordSizeTrackBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1134, 853);
            this.Controls.Add(this.WordSizeTrackBar);
            this.Controls.Add(this.ChapterLabel);
            this.Controls.Add(this.NovelTextBox);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.DarkModeButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.WebsiteTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iamReader";
            ((System.ComponentModel.ISupportInitialize)(this.WordSizeTrackBar)).EndInit();
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
        private System.Windows.Forms.TrackBar WordSizeTrackBar;
    }
}

