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
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnContinue;
        private Label lblRegisterText;
        private LinkLabel linkRegister;
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
            btnContinue = new Button();
            lblRegisterText = new Label();
            linkRegister = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Georgia", 28F);
            lblTitle.Location = new Point(79, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(740, 84);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Log in or create an account";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblEmail.Location = new Point(48, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(300, 40);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 18F);
            txtEmail.Location = new Point(48, 203);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(805, 55);
            txtEmail.TabIndex = 2;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.FromArgb(18, 18, 18);
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(48, 295);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(805, 80);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // lblRegisterText
            // 
            lblRegisterText.Font = new Font("Segoe UI", 11F);
            lblRegisterText.Location = new Point(51, 396);
            lblRegisterText.Name = "lblRegisterText";
            lblRegisterText.Size = new Size(237, 30);
            lblRegisterText.TabIndex = 4;
            lblRegisterText.Text = "Don't have an account?";
            // 
            // linkRegister
            // 
            linkRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            linkRegister.LinkColor = Color.Black;
            linkRegister.Location = new Point(294, 396);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(100, 30);
            linkRegister.TabIndex = 5;
            linkRegister.TabStop = true;
            linkRegister.Text = "Sign up";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 470);
            Controls.Add(lblTitle);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnContinue);
            Controls.Add(lblRegisterText);
            Controls.Add(linkRegister);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log in";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
