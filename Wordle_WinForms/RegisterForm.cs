using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle_WinForms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblEmail;
        private TextBox txtEmail;

        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnShow;

        private CheckBox chkOffers;
        private Label lblOffers;
        private Label lblTerms;
        private Button btnCreateAccount;

        private Label lblLoginText;
        private LinkLabel linkLogin;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnShow = new Button();
            chkOffers = new CheckBox();
            lblOffers = new Label();
            lblTerms = new Label();
            btnCreateAccount = new Button();
            lblLoginText = new Label();
            linkLogin = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Georgia", 30F);
            lblTitle.Location = new Point(86, 61);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(740, 75);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create your free account";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEmail.Location = new Point(48, 162);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(300, 40);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 17F);
            txtEmail.Location = new Point(48, 205);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(805, 53);
            txtEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPassword.Location = new Point(48, 286);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(300, 40);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 17F);
            txtPassword.Location = new Point(48, 329);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(805, 53);
            txtPassword.TabIndex = 5;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.White;
            btnShow.FlatAppearance.BorderSize = 0;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnShow.ForeColor = Color.Gray;
            btnShow.Location = new Point(737, 331);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(113, 50);
            btnShow.TabIndex = 6;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // chkOffers
            // 
            chkOffers.Location = new Point(62, 400);
            chkOffers.Name = "chkOffers";
            chkOffers.Size = new Size(32, 49);
            chkOffers.TabIndex = 7;
            // 
            // lblOffers
            // 
            lblOffers.Font = new Font("Segoe UI", 10F);
            lblOffers.Location = new Point(109, 400);
            lblOffers.Name = "lblOffers";
            lblOffers.Size = new Size(744, 71);
            lblOffers.TabIndex = 8;
            lblOffers.Text = "You agree to receive updates and offers from The Times. You may opt out or contact us anytime.";
            // 
            // lblTerms
            // 
            lblTerms.Font = new Font("Segoe UI", 10F);
            lblTerms.Location = new Point(48, 475);
            lblTerms.Name = "lblTerms";
            lblTerms.Size = new Size(805, 61);
            lblTerms.TabIndex = 9;
            lblTerms.Text = "By creating an account, you agree to the updated Terms of Sale, Terms of Service, and Privacy Policy.";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.FromArgb(18, 18, 18);
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(48, 539);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(805, 82);
            btnCreateAccount.TabIndex = 10;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // lblLoginText
            // 
            lblLoginText.Font = new Font("Segoe UI", 11F);
            lblLoginText.Location = new Point(48, 633);
            lblLoginText.Name = "lblLoginText";
            lblLoginText.Size = new Size(259, 30);
            lblLoginText.TabIndex = 11;
            lblLoginText.Text = "Already have an account?";
            // 
            // linkLogin
            // 
            linkLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            linkLogin.LinkColor = Color.Black;
            linkLogin.Location = new Point(303, 633);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(100, 30);
            linkLogin.TabIndex = 12;
            linkLogin.TabStop = true;
            linkLogin.Text = "Sign in";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(899, 702);
            Controls.Add(lblTitle);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            Controls.Add(btnShow);
            Controls.Add(chkOffers);
            Controls.Add(lblOffers);
            Controls.Add(lblTerms);
            Controls.Add(btnCreateAccount);
            Controls.Add(lblLoginText);
            Controls.Add(linkLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Account";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
