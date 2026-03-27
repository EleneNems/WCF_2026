namespace LibraryManagement.Client
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnLoadBooks = new System.Windows.Forms.Button();
            this.numBookQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtBookISBN = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.btnDeleteMembers = new System.Windows.Forms.Button();
            this.btnUpdateMembers = new System.Windows.Forms.Button();
            this.btnAddMembers = new System.Windows.Forms.Button();
            this.btnLoadMembers = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMemberPhone = new System.Windows.Forms.TextBox();
            this.txtMemberEmail = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.cmbBorrowMembers = new System.Windows.Forms.ComboBox();
            this.cmbBorrowBooks = new System.Windows.Forms.ComboBox();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnLoadTransactions = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReturnTransactionId = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).BeginInit();
            this.tabMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.tabTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Controls.Add(this.tabMembers);
            this.tabControl1.Controls.Add(this.tabTransactions);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(999, 694);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.label5);
            this.tabBooks.Controls.Add(this.label4);
            this.tabBooks.Controls.Add(this.label3);
            this.tabBooks.Controls.Add(this.label2);
            this.tabBooks.Controls.Add(this.label1);
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Controls.Add(this.btnDeleteBook);
            this.tabBooks.Controls.Add(this.btnUpdateBook);
            this.tabBooks.Controls.Add(this.btnAddBook);
            this.tabBooks.Controls.Add(this.btnLoadBooks);
            this.tabBooks.Controls.Add(this.numBookQuantity);
            this.tabBooks.Controls.Add(this.txtBookISBN);
            this.tabBooks.Controls.Add(this.txtBookAuthor);
            this.tabBooks.Controls.Add(this.txtBookTitle);
            this.tabBooks.Controls.Add(this.txtBookId);
            this.tabBooks.Location = new System.Drawing.Point(4, 29);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabBooks.Size = new System.Drawing.Size(991, 661);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "Books";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(373, 0);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 62;
            this.dgvBooks.RowTemplate.Height = 28;
            this.dgvBooks.Size = new System.Drawing.Size(615, 655);
            this.dgvBooks.TabIndex = 9;
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(185, 418);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(87, 37);
            this.btnDeleteBook.TabIndex = 8;
            this.btnDeleteBook.Text = "Delete";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Location = new System.Drawing.Point(44, 418);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(87, 37);
            this.btnUpdateBook.TabIndex = 7;
            this.btnUpdateBook.Text = "Update";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            this.btnUpdateBook.Click += new System.EventHandler(this.btnUpdateBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(185, 335);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(87, 37);
            this.btnAddBook.TabIndex = 6;
            this.btnAddBook.Text = "Add";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnLoadBooks
            // 
            this.btnLoadBooks.Location = new System.Drawing.Point(44, 335);
            this.btnLoadBooks.Name = "btnLoadBooks";
            this.btnLoadBooks.Size = new System.Drawing.Size(87, 37);
            this.btnLoadBooks.TabIndex = 5;
            this.btnLoadBooks.Text = "Load";
            this.btnLoadBooks.UseVisualStyleBackColor = true;
            this.btnLoadBooks.Click += new System.EventHandler(this.btnLoadBooks_Click);
            // 
            // numBookQuantity
            // 
            this.numBookQuantity.Location = new System.Drawing.Point(44, 269);
            this.numBookQuantity.Name = "numBookQuantity";
            this.numBookQuantity.Size = new System.Drawing.Size(120, 26);
            this.numBookQuantity.TabIndex = 4;
            // 
            // txtBookISBN
            // 
            this.txtBookISBN.Location = new System.Drawing.Point(44, 204);
            this.txtBookISBN.Name = "txtBookISBN";
            this.txtBookISBN.Size = new System.Drawing.Size(120, 26);
            this.txtBookISBN.TabIndex = 3;
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.Location = new System.Drawing.Point(44, 151);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(120, 26);
            this.txtBookAuthor.TabIndex = 2;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Location = new System.Drawing.Point(44, 102);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(120, 26);
            this.txtBookTitle.TabIndex = 1;
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(44, 60);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(120, 26);
            this.txtBookId.TabIndex = 0;
            // 
            // tabMembers
            // 
            this.tabMembers.Controls.Add(this.dgvMembers);
            this.tabMembers.Controls.Add(this.btnDeleteMembers);
            this.tabMembers.Controls.Add(this.btnUpdateMembers);
            this.tabMembers.Controls.Add(this.btnAddMembers);
            this.tabMembers.Controls.Add(this.btnLoadMembers);
            this.tabMembers.Controls.Add(this.label6);
            this.tabMembers.Controls.Add(this.label7);
            this.tabMembers.Controls.Add(this.label8);
            this.tabMembers.Controls.Add(this.label9);
            this.tabMembers.Controls.Add(this.txtMemberPhone);
            this.tabMembers.Controls.Add(this.txtMemberEmail);
            this.tabMembers.Controls.Add(this.txtMemberName);
            this.tabMembers.Controls.Add(this.txtMemberId);
            this.tabMembers.Location = new System.Drawing.Point(4, 29);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMembers.Size = new System.Drawing.Size(991, 661);
            this.tabMembers.TabIndex = 1;
            this.tabMembers.Text = "Members";
            this.tabMembers.UseVisualStyleBackColor = true;
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(0, 0);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.RowHeadersWidth = 62;
            this.dgvMembers.RowTemplate.Height = 28;
            this.dgvMembers.Size = new System.Drawing.Size(507, 655);
            this.dgvMembers.TabIndex = 26;
            this.dgvMembers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellClick);
            // 
            // btnDeleteMembers
            // 
            this.btnDeleteMembers.Location = new System.Drawing.Point(790, 482);
            this.btnDeleteMembers.Name = "btnDeleteMembers";
            this.btnDeleteMembers.Size = new System.Drawing.Size(87, 37);
            this.btnDeleteMembers.TabIndex = 25;
            this.btnDeleteMembers.Text = "Delete";
            this.btnDeleteMembers.UseVisualStyleBackColor = true;
            this.btnDeleteMembers.Click += new System.EventHandler(this.btnDeleteMembers_Click);
            // 
            // btnUpdateMembers
            // 
            this.btnUpdateMembers.Location = new System.Drawing.Point(611, 482);
            this.btnUpdateMembers.Name = "btnUpdateMembers";
            this.btnUpdateMembers.Size = new System.Drawing.Size(87, 37);
            this.btnUpdateMembers.TabIndex = 24;
            this.btnUpdateMembers.Text = "Update";
            this.btnUpdateMembers.UseVisualStyleBackColor = true;
            this.btnUpdateMembers.Click += new System.EventHandler(this.btnUpdateMembers_Click);
            // 
            // btnAddMembers
            // 
            this.btnAddMembers.Location = new System.Drawing.Point(790, 399);
            this.btnAddMembers.Name = "btnAddMembers";
            this.btnAddMembers.Size = new System.Drawing.Size(87, 37);
            this.btnAddMembers.TabIndex = 23;
            this.btnAddMembers.Text = "Add";
            this.btnAddMembers.UseVisualStyleBackColor = true;
            this.btnAddMembers.Click += new System.EventHandler(this.btnAddMembers_Click);
            // 
            // btnLoadMembers
            // 
            this.btnLoadMembers.Location = new System.Drawing.Point(611, 399);
            this.btnLoadMembers.Name = "btnLoadMembers";
            this.btnLoadMembers.Size = new System.Drawing.Size(87, 37);
            this.btnLoadMembers.TabIndex = 22;
            this.btnLoadMembers.Text = "Load";
            this.btnLoadMembers.UseVisualStyleBackColor = true;
            this.btnLoadMembers.Click += new System.EventHandler(this.btnLoadMembers_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(822, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Phone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(829, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(797, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Full Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(851, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "ID";
            // 
            // txtMemberPhone
            // 
            this.txtMemberPhone.Location = new System.Drawing.Point(606, 251);
            this.txtMemberPhone.Name = "txtMemberPhone";
            this.txtMemberPhone.Size = new System.Drawing.Size(120, 26);
            this.txtMemberPhone.TabIndex = 17;
            // 
            // txtMemberEmail
            // 
            this.txtMemberEmail.Location = new System.Drawing.Point(606, 198);
            this.txtMemberEmail.Name = "txtMemberEmail";
            this.txtMemberEmail.Size = new System.Drawing.Size(120, 26);
            this.txtMemberEmail.TabIndex = 16;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(606, 149);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(120, 26);
            this.txtMemberName.TabIndex = 15;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(606, 107);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(120, 26);
            this.txtMemberId.TabIndex = 14;
            // 
            // tabTransactions
            // 
            this.tabTransactions.Controls.Add(this.cmbBorrowMembers);
            this.tabTransactions.Controls.Add(this.cmbBorrowBooks);
            this.tabTransactions.Controls.Add(this.dgvTransactions);
            this.tabTransactions.Controls.Add(this.btnReturnBook);
            this.tabTransactions.Controls.Add(this.btnBorrowBook);
            this.tabTransactions.Controls.Add(this.btnLoadTransactions);
            this.tabTransactions.Controls.Add(this.label10);
            this.tabTransactions.Controls.Add(this.label11);
            this.tabTransactions.Controls.Add(this.label12);
            this.tabTransactions.Controls.Add(this.txtReturnTransactionId);
            this.tabTransactions.Location = new System.Drawing.Point(4, 29);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransactions.Size = new System.Drawing.Size(991, 661);
            this.tabTransactions.TabIndex = 2;
            this.tabTransactions.Text = "Transactions";
            this.tabTransactions.UseVisualStyleBackColor = true;
            // 
            // cmbBorrowMembers
            // 
            this.cmbBorrowMembers.FormattingEnabled = true;
            this.cmbBorrowMembers.Location = new System.Drawing.Point(105, 183);
            this.cmbBorrowMembers.Name = "cmbBorrowMembers";
            this.cmbBorrowMembers.Size = new System.Drawing.Size(121, 28);
            this.cmbBorrowMembers.TabIndex = 32;
            // 
            // cmbBorrowBooks
            // 
            this.cmbBorrowBooks.FormattingEnabled = true;
            this.cmbBorrowBooks.Location = new System.Drawing.Point(106, 143);
            this.cmbBorrowBooks.Name = "cmbBorrowBooks";
            this.cmbBorrowBooks.Size = new System.Drawing.Size(121, 28);
            this.cmbBorrowBooks.TabIndex = 31;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(542, 0);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 62;
            this.dgvTransactions.RowTemplate.Height = 28;
            this.dgvTransactions.Size = new System.Drawing.Size(449, 655);
            this.dgvTransactions.TabIndex = 30;
            this.dgvTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellClick);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(226, 456);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(87, 37);
            this.btnReturnBook.TabIndex = 29;
            this.btnReturnBook.Text = "Return";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.Location = new System.Drawing.Point(318, 354);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(87, 37);
            this.btnBorrowBook.TabIndex = 28;
            this.btnBorrowBook.Text = "Borrow";
            this.btnBorrowBook.UseVisualStyleBackColor = true;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // btnLoadTransactions
            // 
            this.btnLoadTransactions.Location = new System.Drawing.Point(139, 354);
            this.btnLoadTransactions.Name = "btnLoadTransactions";
            this.btnLoadTransactions.Size = new System.Drawing.Size(87, 37);
            this.btnLoadTransactions.TabIndex = 27;
            this.btnLoadTransactions.Text = "Load";
            this.btnLoadTransactions.UseVisualStyleBackColor = true;
            this.btnLoadTransactions.Click += new System.EventHandler(this.btnLoadTransactions_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Return Transaction ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Borrow Member ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(339, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Borrow Book ID";
            // 
            // txtReturnTransactionId
            // 
            this.txtReturnTransactionId.Location = new System.Drawing.Point(106, 234);
            this.txtReturnTransactionId.Name = "txtReturnTransactionId";
            this.txtReturnTransactionId.Size = new System.Drawing.Size(120, 26);
            this.txtReturnTransactionId.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 689);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).EndInit();
            this.tabMembers.ResumeLayout(false);
            this.tabMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.tabTransactions.ResumeLayout(false);
            this.tabTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.TabPage tabTransactions;
        private System.Windows.Forms.Button btnLoadBooks;
        private System.Windows.Forms.NumericUpDown numBookQuantity;
        private System.Windows.Forms.TextBox txtBookISBN;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMemberPhone;
        private System.Windows.Forms.TextBox txtMemberEmail;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Button btnDeleteMembers;
        private System.Windows.Forms.Button btnUpdateMembers;
        private System.Windows.Forms.Button btnAddMembers;
        private System.Windows.Forms.Button btnLoadMembers;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnLoadTransactions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtReturnTransactionId;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.ComboBox cmbBorrowMembers;
        private System.Windows.Forms.ComboBox cmbBorrowBooks;
    }
}

