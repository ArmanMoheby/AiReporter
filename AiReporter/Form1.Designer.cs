namespace AiReporter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt1 = new TextBox();
            btn1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            panelHtmlPreview = new Panel();
            button3 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // txt1
            // 
            txt1.Location = new Point(12, 37);
            txt1.Multiline = true;
            txt1.Name = "txt1";
            txt1.Size = new Size(330, 431);
            txt1.TabIndex = 0;
            // 
            // btn1
            // 
            btn1.Location = new Point(348, 37);
            btn1.Name = "btn1";
            btn1.Size = new Size(102, 23);
            btn1.TabIndex = 1;
            btn1.Text = "<=پیشنهاد";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(884, 19);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 2;
            label1.Text = "راه حل پیشنهادی";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 19);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "صورت مسئله";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(710, 16);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(348, 445);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 1;
            button1.Text = "درباره";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelHtmlPreview
            // 
            panelHtmlPreview.Location = new Point(456, 37);
            panelHtmlPreview.Name = "panelHtmlPreview";
            panelHtmlPreview.Size = new Size(515, 431);
            panelHtmlPreview.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(348, 416);
            button3.Name = "button3";
            button3.Size = new Size(102, 23);
            button3.TabIndex = 1;
            button3.Text = "راهنما";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(389, 500);
            label4.Name = "label4";
            label4.Size = new Size(582, 15);
            label4.TabIndex = 2;
            label4.Text = "توجه: \"این سیستم هوش مصنوعی به صورت آزمایشی پیاده‌سازی شده و نتایج آن ممکن است نیاز به بازنگری داشته باشد.\"";
            label4.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(983, 524);
            Controls.Add(panelHtmlPreview);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(btn1);
            Controls.Add(txt1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            Text = "سیستم هوش مصنوعی پتروسازه مبین  (طرح آزمایشی)";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt1;
        private Button btn1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Panel panelHtmlPreview;
        private Button button3;
        private Label label4;
    }
}
