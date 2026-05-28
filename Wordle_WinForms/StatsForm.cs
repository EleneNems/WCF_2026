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
    partial class StatsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;

        private Label lblPlayedNumber;
        private Label lblWinNumber;
        private Label lblCurrentStreakNumber;
        private Label lblMaxStreakNumber;

        private Label lblPlayedText;
        private Label lblWinText;
        private Label lblCurrentStreakText;
        private Label lblMaxStreakText;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblPlayedNumber = new Label();
            lblWinNumber = new Label();
            lblCurrentStreakNumber = new Label();
            lblMaxStreakNumber = new Label();
            lblPlayedText = new Label();
            lblWinText = new Label();
            lblCurrentStreakText = new Label();
            lblMaxStreakText = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(80, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "STATISTICS";
            // 
            // lblPlayedNumber
            // 
            lblPlayedNumber.Font = new Font("Segoe UI", 40F);
            lblPlayedNumber.Location = new Point(80, 85);
            lblPlayedNumber.Name = "lblPlayedNumber";
            lblPlayedNumber.Size = new Size(120, 100);
            lblPlayedNumber.TabIndex = 1;
            lblPlayedNumber.Text = "0";
            lblPlayedNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWinNumber
            // 
            lblWinNumber.Font = new Font("Segoe UI", 40F);
            lblWinNumber.Location = new Point(230, 85);
            lblWinNumber.Name = "lblWinNumber";
            lblWinNumber.Size = new Size(120, 100);
            lblWinNumber.TabIndex = 2;
            lblWinNumber.Text = "0";
            lblWinNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStreakNumber
            // 
            lblCurrentStreakNumber.Font = new Font("Segoe UI", 40F);
            lblCurrentStreakNumber.Location = new Point(390, 85);
            lblCurrentStreakNumber.Name = "lblCurrentStreakNumber";
            lblCurrentStreakNumber.Size = new Size(120, 100);
            lblCurrentStreakNumber.TabIndex = 3;
            lblCurrentStreakNumber.Text = "0";
            lblCurrentStreakNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaxStreakNumber
            // 
            lblMaxStreakNumber.Font = new Font("Segoe UI", 40F);
            lblMaxStreakNumber.Location = new Point(550, 85);
            lblMaxStreakNumber.Name = "lblMaxStreakNumber";
            lblMaxStreakNumber.Size = new Size(120, 100);
            lblMaxStreakNumber.TabIndex = 4;
            lblMaxStreakNumber.Text = "0";
            lblMaxStreakNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayedText
            // 
            lblPlayedText.Font = new Font("Segoe UI", 13F);
            lblPlayedText.Location = new Point(80, 185);
            lblPlayedText.Name = "lblPlayedText";
            lblPlayedText.Size = new Size(120, 40);
            lblPlayedText.TabIndex = 5;
            lblPlayedText.Text = "Played";
            lblPlayedText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWinText
            // 
            lblWinText.Font = new Font("Segoe UI", 13F);
            lblWinText.Location = new Point(230, 185);
            lblWinText.Name = "lblWinText";
            lblWinText.Size = new Size(120, 40);
            lblWinText.TabIndex = 6;
            lblWinText.Text = "Win %";
            lblWinText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStreakText
            // 
            lblCurrentStreakText.Font = new Font("Segoe UI", 13F);
            lblCurrentStreakText.Location = new Point(390, 185);
            lblCurrentStreakText.Name = "lblCurrentStreakText";
            lblCurrentStreakText.Size = new Size(120, 75);
            lblCurrentStreakText.TabIndex = 7;
            lblCurrentStreakText.Text = "Current\r\nStreak";
            lblCurrentStreakText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaxStreakText
            // 
            lblMaxStreakText.Font = new Font("Segoe UI", 13F);
            lblMaxStreakText.Location = new Point(550, 185);
            lblMaxStreakText.Name = "lblMaxStreakText";
            lblMaxStreakText.Size = new Size(140, 40);
            lblMaxStreakText.TabIndex = 8;
            lblMaxStreakText.Text = "Max Streak";
            lblMaxStreakText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(780, 294);
            Controls.Add(lblTitle);
            Controls.Add(lblPlayedNumber);
            Controls.Add(lblWinNumber);
            Controls.Add(lblCurrentStreakNumber);
            Controls.Add(lblMaxStreakNumber);
            Controls.Add(lblPlayedText);
            Controls.Add(lblWinText);
            Controls.Add(lblCurrentStreakText);
            Controls.Add(lblMaxStreakText);
            Name = "StatsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Statistics";
            Load += StatsForm_Load;
            ResumeLayout(false);
        }
    }
}