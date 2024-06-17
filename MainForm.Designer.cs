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
            this.yearDropdown = new System.Windows.Forms.ComboBox();
            this.authorDropdown = new System.Windows.Forms.ComboBox();
            this.genreDropdown = new System.Windows.Forms.ComboBox();
            this.saveHistoryButton = new System.Windows.Forms.Button();
            this.booksList = new System.Windows.Forms.DataGridView();
            this.rentHistoryList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.booksList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentHistoryList)).BeginInit();
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
            // yearDropdown
            // 
            this.yearDropdown.FormattingEnabled = true;
            this.yearDropdown.Location = new System.Drawing.Point(578, 64);
            this.yearDropdown.Name = "yearDropdown";
            this.yearDropdown.Size = new System.Drawing.Size(121, 23);
            this.yearDropdown.TabIndex = 2;
            this.yearDropdown.SelectionChangeCommitted += new System.EventHandler(this.yearDropdown_SelectionChangeCommitted);
            // 
            // authorDropdown
            // 
            this.authorDropdown.FormattingEnabled = true;
            this.authorDropdown.Location = new System.Drawing.Point(578, 113);
            this.authorDropdown.Name = "authorDropdown";
            this.authorDropdown.Size = new System.Drawing.Size(121, 23);
            this.authorDropdown.TabIndex = 3;
            this.authorDropdown.SelectionChangeCommitted += new System.EventHandler(this.authorDropdown_SelectionChangeCommitted);
            // 
            // genreDropdown
            // 
            this.genreDropdown.FormattingEnabled = true;
            this.genreDropdown.Location = new System.Drawing.Point(578, 161);
            this.genreDropdown.Name = "genreDropdown";
            this.genreDropdown.Size = new System.Drawing.Size(121, 23);
            this.genreDropdown.TabIndex = 4;
            this.genreDropdown.SelectionChangeCommitted += new System.EventHandler(this.genreDropdown_SelectionChangeCommitted);
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
            // booksList
            // 
            this.booksList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksList.Location = new System.Drawing.Point(12, 41);
            this.booksList.Name = "booksList";
            this.booksList.RowTemplate.Height = 25;
            this.booksList.Size = new System.Drawing.Size(450, 397);
            this.booksList.TabIndex = 7;
            // 
            // rentHistoryList
            // 
            this.rentHistoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentHistoryList.Location = new System.Drawing.Point(482, 217);
            this.rentHistoryList.Name = "rentHistoryList";
            this.rentHistoryList.RowTemplate.Height = 25;
            this.rentHistoryList.Size = new System.Drawing.Size(306, 221);
            this.rentHistoryList.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rentHistoryList);
            this.Controls.Add(this.booksList);
            this.Controls.Add(this.saveHistoryButton);
            this.Controls.Add(this.genreDropdown);
            this.Controls.Add(this.authorDropdown);
            this.Controls.Add(this.yearDropdown);
            this.Controls.Add(this.typeDropdown);
            this.Name = "MainForm";
            this.Text = "Bogprogram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.booksList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentHistoryList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox typeDropdown;
        private ComboBox yearDropdown;
        private ComboBox authorDropdown;
        private ComboBox genreDropdown;
        private Button saveHistoryButton;
        private DataGridView booksList;
        private DataGridView rentHistoryList;
    }
}