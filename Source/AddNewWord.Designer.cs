namespace TechnicalDictionary
{
    partial class AddNewWord
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
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EnglishRichTextBox = new System.Windows.Forms.RichTextBox();
            this.JapaneseRichTextBox = new System.Windows.Forms.RichTextBox();
            this.KanjiRichTextBox = new System.Windows.Forms.RichTextBox();
            this.RomanjiRichTextBox = new System.Windows.Forms.RichTextBox();
            this.NoteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(180, 380);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(104, 31);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "English";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Japanese (Hiragana/Katakana)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kanji";
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(45, 380);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(104, 31);
            this.Cancelbutton.TabIndex = 11;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Romanji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Note";
            // 
            // EnglishRichTextBox
            // 
            this.EnglishRichTextBox.Location = new System.Drawing.Point(29, 41);
            this.EnglishRichTextBox.Name = "EnglishRichTextBox";
            this.EnglishRichTextBox.Size = new System.Drawing.Size(271, 34);
            this.EnglishRichTextBox.TabIndex = 20;
            this.EnglishRichTextBox.Text = "";
            // 
            // JapaneseRichTextBox
            // 
            this.JapaneseRichTextBox.Location = new System.Drawing.Point(29, 112);
            this.JapaneseRichTextBox.Name = "JapaneseRichTextBox";
            this.JapaneseRichTextBox.Size = new System.Drawing.Size(271, 34);
            this.JapaneseRichTextBox.TabIndex = 21;
            this.JapaneseRichTextBox.Text = "";
            // 
            // KanjiRichTextBox
            // 
            this.KanjiRichTextBox.Location = new System.Drawing.Point(29, 183);
            this.KanjiRichTextBox.Name = "KanjiRichTextBox";
            this.KanjiRichTextBox.Size = new System.Drawing.Size(271, 34);
            this.KanjiRichTextBox.TabIndex = 22;
            this.KanjiRichTextBox.Text = "";
            // 
            // RomanjiRichTextBox
            // 
            this.RomanjiRichTextBox.Location = new System.Drawing.Point(29, 254);
            this.RomanjiRichTextBox.Name = "RomanjiRichTextBox";
            this.RomanjiRichTextBox.Size = new System.Drawing.Size(271, 34);
            this.RomanjiRichTextBox.TabIndex = 23;
            this.RomanjiRichTextBox.Text = "";
            // 
            // NoteRichTextBox
            // 
            this.NoteRichTextBox.Location = new System.Drawing.Point(29, 325);
            this.NoteRichTextBox.Name = "NoteRichTextBox";
            this.NoteRichTextBox.Size = new System.Drawing.Size(271, 34);
            this.NoteRichTextBox.TabIndex = 24;
            this.NoteRichTextBox.Text = "";
            // 
            // AddNewWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 429);
            this.Controls.Add(this.NoteRichTextBox);
            this.Controls.Add(this.RomanjiRichTextBox);
            this.Controls.Add(this.KanjiRichTextBox);
            this.Controls.Add(this.JapaneseRichTextBox);
            this.Controls.Add(this.EnglishRichTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddButton);
            this.Name = "AddNewWord";
            this.Text = "Add New Word For Tect Dict";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox EnglishRichTextBox;
        private System.Windows.Forms.RichTextBox JapaneseRichTextBox;
        private System.Windows.Forms.RichTextBox KanjiRichTextBox;
        private System.Windows.Forms.RichTextBox RomanjiRichTextBox;
        private System.Windows.Forms.RichTextBox NoteRichTextBox;
    }
}