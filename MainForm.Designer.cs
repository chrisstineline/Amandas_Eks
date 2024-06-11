namespace Amanda_Eks
{
    partial class MainForm
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
            this.typeDropdown = new System.Windows.Forms.ComboBox();
            this.booksList = new System.Windows.Forms.ListView();
            this.Titel = new System.Windows.Forms.ColumnHeader();
            this.Forfatter = new System.Windows.Forms.ColumnHeader();
            this.Genrer = new System.Windows.Forms.ColumnHeader();
            this.PublikationsAar = new System.Windows.Forms.ColumnHeader();
            this.Udgiver = new System.Windows.Forms.ColumnHeader();
            this.MatchPercentage = new System.Windows.Forms.ColumnHeader();
            this.ISBN = new System.Windows.Forms.ColumnHeader();
            this.yearDropdown = new System.Windows.Forms.ComboBox();
            this.authorDropdown = new System.Windows.Forms.ComboBox();
            this.genreDropdown = new System.Windows.Forms.ComboBox();
            this.historyList = new System.Windows.Forms.ListView();
            this.saveHistoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeDropdown
            // 
            this.typeDropdown.FormattingEnabled = true;
            this.typeDropdown.Items.AddRange(new object[] {
            "Bog",
            "Lydbog",
            "Tegneserie"});
            this.typeDropdown.Location = new System.Drawing.Point(12, 12);
            this.typeDropdown.Name = "typeDropdown";
            this.typeDropdown.Size = new System.Drawing.Size(450, 23);
            this.typeDropdown.TabIndex = 0;
            this.typeDropdown.SelectionChangeCommitted += new System.EventHandler(this.typeDropdown_SelectionChangeCommitted);
            // 
            // booksList
            // 
            this.booksList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Titel,
            this.Forfatter,
            this.Genrer,
            this.PublikationsAar,
            this.Udgiver,
            this.MatchPercentage,
            this.ISBN});
            this.booksList.Location = new System.Drawing.Point(12, 41);
            this.booksList.Name = "booksList";
            this.booksList.Size = new System.Drawing.Size(450, 397);
            this.booksList.TabIndex = 1;
            this.booksList.UseCompatibleStateImageBehavior = false;
            this.booksList.SelectedIndexChanged += new System.EventHandler(this.booksList_SelectedIndexChanged);
            // 
            // yearDropdown
            // 
            this.yearDropdown.FormattingEnabled = true;
            this.yearDropdown.Location = new System.Drawing.Point(578, 64);
            this.yearDropdown.Name = "yearDropdown";
            this.yearDropdown.Size = new System.Drawing.Size(121, 23);
            this.yearDropdown.TabIndex = 2;
            // 
            // authorDropdown
            // 
            this.authorDropdown.FormattingEnabled = true;
            this.authorDropdown.Location = new System.Drawing.Point(578, 113);
            this.authorDropdown.Name = "authorDropdown";
            this.authorDropdown.Size = new System.Drawing.Size(121, 23);
            this.authorDropdown.TabIndex = 3;
            // 
            // genreDropdown
            // 
            this.genreDropdown.FormattingEnabled = true;
            this.genreDropdown.Location = new System.Drawing.Point(578, 161);
            this.genreDropdown.Name = "genreDropdown";
            this.genreDropdown.Size = new System.Drawing.Size(121, 23);
            this.genreDropdown.TabIndex = 4;
            // 
            // historyList
            // 
            this.historyList.Location = new System.Drawing.Point(485, 204);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(303, 234);
            this.historyList.TabIndex = 5;
            this.historyList.UseCompatibleStateImageBehavior = false;
            // 
            // saveHistoryButton
            // 
            this.saveHistoryButton.Location = new System.Drawing.Point(713, 160);
            this.saveHistoryButton.Name = "saveHistoryButton";
            this.saveHistoryButton.Size = new System.Drawing.Size(75, 23);
            this.saveHistoryButton.TabIndex = 6;
            this.saveHistoryButton.Text = "Gem";
            this.saveHistoryButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveHistoryButton);
            this.Controls.Add(this.historyList);
            this.Controls.Add(this.genreDropdown);
            this.Controls.Add(this.authorDropdown);
            this.Controls.Add(this.yearDropdown);
            this.Controls.Add(this.booksList);
            this.Controls.Add(this.typeDropdown);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox typeDropdown;
        private ListView booksList;
        private ComboBox yearDropdown;
        private ComboBox authorDropdown;
        private ComboBox genreDropdown;
        private ListView historyList;
        private Button saveHistoryButton;
        private ColumnHeader Titel;
        private ColumnHeader Forfatter;
        private ColumnHeader Genrer;
        private ColumnHeader PublikationsAar;
        private ColumnHeader Udgiver;
        private ColumnHeader MatchPercentage;
        private ColumnHeader ISBN;
    }
}