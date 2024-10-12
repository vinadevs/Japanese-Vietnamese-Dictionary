namespace TechnicalDictionary
{
    partial class ApplicationGUI
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
            this.g_menuStrip = new System.Windows.Forms.MenuStrip();
            this.g_menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.g_japaneseEnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_minaNoNihongoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_addNewWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_addNewWordForTechDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_addNewWordForMinnaDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.g_japaneseGrammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.g_aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_splitContainer = new System.Windows.Forms.SplitContainer();
            this.g_groupBox2 = new System.Windows.Forms.GroupBox();
            this.g_listBoxWords = new System.Windows.Forms.ListBox();
            this.g_groupBox1 = new System.Windows.Forms.GroupBox();
            this.g_textToSearch = new System.Windows.Forms.TextBox();
            this.g_translatedText = new System.Windows.Forms.RichTextBox();
            this.g_menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_splitContainer)).BeginInit();
            this.g_splitContainer.Panel1.SuspendLayout();
            this.g_splitContainer.Panel2.SuspendLayout();
            this.g_splitContainer.SuspendLayout();
            this.g_groupBox2.SuspendLayout();
            this.g_groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // g_menuStrip
            // 
            this.g_menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.g_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g_menuFile,
            this.g_menuHelp});
            this.g_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.g_menuStrip.Name = "g_menuStrip";
            this.g_menuStrip.Size = new System.Drawing.Size(1151, 28);
            this.g_menuStrip.TabIndex = 0;
            this.g_menuStrip.Text = "g_menuStrip";
            // 
            // g_menuFile
            // 
            this.g_menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g_japaneseEnglishToolStripMenuItem,
            this.g_minaNoNihongoToolStripMenuItem,
            this.g_addNewWordToolStripMenuItem,
            this.g_menuFileClose,
            this.g_japaneseGrammarToolStripMenuItem});
            this.g_menuFile.Name = "g_menuFile";
            this.g_menuFile.Size = new System.Drawing.Size(84, 24);
            this.g_menuFile.Text = "&Windows";
            // 
            // g_japaneseEnglishToolStripMenuItem
            // 
            this.g_japaneseEnglishToolStripMenuItem.Name = "g_japaneseEnglishToolStripMenuItem";
            this.g_japaneseEnglishToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.g_japaneseEnglishToolStripMenuItem.Text = "Technical Dict/Mina No Nihongo Dict";
            this.g_japaneseEnglishToolStripMenuItem.Click += new System.EventHandler(this.dictChangeToolStripMenuItem_Click);
            // 
            // g_minaNoNihongoToolStripMenuItem
            // 
            this.g_minaNoNihongoToolStripMenuItem.Name = "g_minaNoNihongoToolStripMenuItem";
            this.g_minaNoNihongoToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.g_minaNoNihongoToolStripMenuItem.Text = "Change Language Search";
            this.g_minaNoNihongoToolStripMenuItem.Click += new System.EventHandler(this.languageChangeToolStripMenuItem_Click);
            // 
            // g_addNewWordToolStripMenuItem
            // 
            this.g_addNewWordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g_addNewWordForTechDictToolStripMenuItem,
            this.g_addNewWordForMinnaDictToolStripMenuItem});
            this.g_addNewWordToolStripMenuItem.Name = "g_addNewWordToolStripMenuItem";
            this.g_addNewWordToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.g_addNewWordToolStripMenuItem.Text = "Add New Word";
            // 
            // g_addNewWordForTechDictToolStripMenuItem
            // 
            this.g_addNewWordForTechDictToolStripMenuItem.Name = "g_addNewWordForTechDictToolStripMenuItem";
            this.g_addNewWordForTechDictToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.g_addNewWordForTechDictToolStripMenuItem.Text = "Add New Word For Tech Dict";
            this.g_addNewWordForTechDictToolStripMenuItem.Click += new System.EventHandler(this.addNewWordForTechDictToolStripMenuItem_Click);
            // 
            // g_addNewWordForMinnaDictToolStripMenuItem
            // 
            this.g_addNewWordForMinnaDictToolStripMenuItem.Name = "g_addNewWordForMinnaDictToolStripMenuItem";
            this.g_addNewWordForMinnaDictToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.g_addNewWordForMinnaDictToolStripMenuItem.Text = "Add New Word For Minna Dict";
            this.g_addNewWordForMinnaDictToolStripMenuItem.Click += new System.EventHandler(this.addNewWordForMinnaDictToolStripMenuItem_Click);
            // 
            // g_menuFileClose
            // 
            this.g_menuFileClose.Name = "g_menuFileClose";
            this.g_menuFileClose.Size = new System.Drawing.Size(340, 26);
            this.g_menuFileClose.Text = "&Close";
            this.g_menuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // g_japaneseGrammarToolStripMenuItem
            // 
            this.g_japaneseGrammarToolStripMenuItem.Name = "g_japaneseGrammarToolStripMenuItem";
            this.g_japaneseGrammarToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            // 
            // g_menuHelp
            // 
            this.g_menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g_aboutToolStripMenuItem});
            this.g_menuHelp.Name = "g_menuHelp";
            this.g_menuHelp.Size = new System.Drawing.Size(55, 24);
            this.g_menuHelp.Text = "&Help";
            // 
            // g_aboutToolStripMenuItem
            // 
            this.g_aboutToolStripMenuItem.Name = "g_aboutToolStripMenuItem";
            this.g_aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.g_aboutToolStripMenuItem.Text = "&About...";
            this.g_aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // g_splitContainer
            // 
            this.g_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_splitContainer.Location = new System.Drawing.Point(0, 28);
            this.g_splitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_splitContainer.Name = "g_splitContainer";
            // 
            // g_splitContainer.Panel1
            // 
            this.g_splitContainer.Panel1.Controls.Add(this.g_groupBox2);
            this.g_splitContainer.Panel1.Controls.Add(this.g_groupBox1);
            // 
            // g_splitContainer.Panel2
            // 
            this.g_splitContainer.Panel2.Controls.Add(this.g_translatedText);
            this.g_splitContainer.Size = new System.Drawing.Size(1151, 698);
            this.g_splitContainer.SplitterDistance = 334;
            this.g_splitContainer.SplitterWidth = 5;
            this.g_splitContainer.TabIndex = 1;
            // 
            // g_groupBox2
            // 
            this.g_groupBox2.Controls.Add(this.g_listBoxWords);
            this.g_groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_groupBox2.Location = new System.Drawing.Point(0, 59);
            this.g_groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_groupBox2.Name = "g_groupBox2";
            this.g_groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_groupBox2.Size = new System.Drawing.Size(334, 639);
            this.g_groupBox2.TabIndex = 1;
            this.g_groupBox2.TabStop = false;
            this.g_groupBox2.Text = "Technical Dictionary";
            // 
            // g_listBoxWords
            // 
            this.g_listBoxWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_listBoxWords.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_listBoxWords.FormattingEnabled = true;
            this.g_listBoxWords.ItemHeight = 22;
            this.g_listBoxWords.Location = new System.Drawing.Point(4, 18);
            this.g_listBoxWords.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_listBoxWords.Name = "g_listBoxWords";
            this.g_listBoxWords.Size = new System.Drawing.Size(326, 618);
            this.g_listBoxWords.TabIndex = 0;
            this.g_listBoxWords.SelectedIndexChanged += new System.EventHandler(this.lstTerms_SelectedIndexChanged);
            // 
            // g_groupBox1
            // 
            this.g_groupBox1.Controls.Add(this.g_textToSearch);
            this.g_groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.g_groupBox1.Location = new System.Drawing.Point(0, 0);
            this.g_groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_groupBox1.Name = "g_groupBox1";
            this.g_groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_groupBox1.Size = new System.Drawing.Size(334, 59);
            this.g_groupBox1.TabIndex = 0;
            this.g_groupBox1.TabStop = false;
            this.g_groupBox1.Text = "Find English";
            // 
            // g_textToSearch
            // 
            this.g_textToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.g_textToSearch.Location = new System.Drawing.Point(16, 18);
            this.g_textToSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_textToSearch.Name = "g_textToSearch";
            this.g_textToSearch.Size = new System.Drawing.Size(308, 22);
            this.g_textToSearch.TabIndex = 0;
            this.g_textToSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // g_translatedText
            // 
            this.g_translatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_translatedText.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.g_translatedText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.g_translatedText.Location = new System.Drawing.Point(0, 0);
            this.g_translatedText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.g_translatedText.Name = "g_translatedText";
            this.g_translatedText.ReadOnly = true;
            this.g_translatedText.Size = new System.Drawing.Size(812, 698);
            this.g_translatedText.TabIndex = 0;
            this.g_translatedText.Text = "";
            // 
            // ApplicationGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1151, 726);
            this.Controls.Add(this.g_splitContainer);
            this.Controls.Add(this.g_menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.g_menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ApplicationGUI";
            this.Text = "Technical Dictionary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplicationGUI_FormClosed);
            this.Load += new System.EventHandler(this.ApplicationGUI_Load);
            this.Resize += new System.EventHandler(this.ApplicationGUI_Resize);
            this.g_menuStrip.ResumeLayout(false);
            this.g_menuStrip.PerformLayout();
            this.g_splitContainer.Panel1.ResumeLayout(false);
            this.g_splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g_splitContainer)).EndInit();
            this.g_splitContainer.ResumeLayout(false);
            this.g_groupBox2.ResumeLayout(false);
            this.g_groupBox1.ResumeLayout(false);
            this.g_groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // languge GUIs
        private System.Windows.Forms.ToolStripMenuItem g_japaneseEnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem g_minaNoNihongoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem g_addNewWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem g_addNewWordForTechDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem g_addNewWordForMinnaDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem g_japaneseGrammarToolStripMenuItem;
        // General GUIs
        private System.Windows.Forms.MenuStrip g_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem g_menuFile;
        private System.Windows.Forms.ToolStripMenuItem g_menuFileClose;
        private System.Windows.Forms.ToolStripMenuItem g_menuHelp;
        private System.Windows.Forms.ToolStripMenuItem g_aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer g_splitContainer;
        private System.Windows.Forms.GroupBox g_groupBox1;
        private System.Windows.Forms.TextBox g_textToSearch;
        private System.Windows.Forms.GroupBox g_groupBox2;
        private System.Windows.Forms.ListBox g_listBoxWords;
        private System.Windows.Forms.RichTextBox g_translatedText;
    }
}

