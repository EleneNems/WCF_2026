using System.Drawing;
using System.Windows.Forms;

namespace Wordle_WinForms
{
    partial class HowToPlayForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblRule1;
        private Label lblRule2;
        private Label lblExamples;

        private Label w1, e1, a1, r1, y1;
        private Label p2, i2, l2a, l2b, s2;
        private Label v3, a3, g3, u3, e3;

        private Label lblExample1Text;
        private Label lblExample2Text;
        private Label lblExample3Text;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblRule1 = new Label();
            lblRule2 = new Label();
            lblExamples = new Label();

            w1 = new Label();
            e1 = new Label();
            a1 = new Label();
            r1 = new Label();
            y1 = new Label();

            p2 = new Label();
            i2 = new Label();
            l2a = new Label();
            l2b = new Label();
            s2 = new Label();

            v3 = new Label();
            a3 = new Label();
            g3 = new Label();
            u3 = new Label();
            e3 = new Label();

            lblExample1Text = new Label();
            lblExample2Text = new Label();
            lblExample3Text = new Label();

            SuspendLayout();

            // lblTitle
            lblTitle.BackColor = Color.White;
            lblTitle.Font = new Font("Georgia", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(25, 101);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 68);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "How To Play";

            // lblSubtitle
            lblSubtitle.BackColor = Color.White;
            lblSubtitle.Font = new Font("Georgia", 20F);
            lblSubtitle.ForeColor = Color.Black;
            lblSubtitle.Location = new Point(25, 180);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(520, 45);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Guess the Wordle in 6 tries.";

            // lblRule1
            lblRule1.BackColor = Color.White;
            lblRule1.Font = new Font("Arial", 12F);
            lblRule1.ForeColor = Color.Gray;
            lblRule1.Location = new Point(25, 235);
            lblRule1.Name = "lblRule1";
            lblRule1.Size = new Size(560, 35);
            lblRule1.TabIndex = 3;
            lblRule1.Text = "•  Each guess must be a valid 5-letter word.";

            // lblRule2
            lblRule2.BackColor = Color.White;
            lblRule2.Font = new Font("Arial", 12F);
            lblRule2.ForeColor = Color.Gray;
            lblRule2.Location = new Point(25, 275);
            lblRule2.Name = "lblRule2";
            lblRule2.Size = new Size(621, 70);
            lblRule2.TabIndex = 4;
            lblRule2.Text = "•  The color of the tiles will change to show how close your guess was to the word.";

            // lblExamples
            lblExamples.BackColor = Color.White;
            lblExamples.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblExamples.ForeColor = Color.Black;
            lblExamples.Location = new Point(24, 356);
            lblExamples.Name = "lblExamples";
            lblExamples.Size = new Size(163, 40);
            lblExamples.TabIndex = 5;
            lblExamples.Text = "Examples";

            // w1
            w1.BackColor = Color.FromArgb(106, 170, 100);
            w1.BorderStyle = BorderStyle.FixedSingle;
            w1.Font = new Font("Arial", 24F, FontStyle.Bold);
            w1.ForeColor = Color.White;
            w1.Location = new Point(24, 411);
            w1.Name = "w1";
            w1.Size = new Size(65, 65);
            w1.TabIndex = 6;
            w1.Text = "W";
            w1.TextAlign = ContentAlignment.MiddleCenter;

            // e1
            e1.BackColor = Color.White;
            e1.BorderStyle = BorderStyle.FixedSingle;
            e1.Font = new Font("Arial", 24F, FontStyle.Bold);
            e1.ForeColor = Color.Black;
            e1.Location = new Point(96, 411);
            e1.Name = "e1";
            e1.Size = new Size(65, 65);
            e1.TabIndex = 7;
            e1.Text = "E";
            e1.TextAlign = ContentAlignment.MiddleCenter;

            // a1
            a1.BackColor = Color.White;
            a1.BorderStyle = BorderStyle.FixedSingle;
            a1.Font = new Font("Arial", 24F, FontStyle.Bold);
            a1.ForeColor = Color.Black;
            a1.Location = new Point(167, 411);
            a1.Name = "a1";
            a1.Size = new Size(65, 65);
            a1.TabIndex = 8;
            a1.Text = "A";
            a1.TextAlign = ContentAlignment.MiddleCenter;

            // r1
            r1.BackColor = Color.White;
            r1.BorderStyle = BorderStyle.FixedSingle;
            r1.Font = new Font("Arial", 24F, FontStyle.Bold);
            r1.ForeColor = Color.Black;
            r1.Location = new Point(238, 411);
            r1.Name = "r1";
            r1.Size = new Size(65, 65);
            r1.TabIndex = 9;
            r1.Text = "R";
            r1.TextAlign = ContentAlignment.MiddleCenter;

            // y1
            y1.BackColor = Color.White;
            y1.BorderStyle = BorderStyle.FixedSingle;
            y1.Font = new Font("Arial", 24F, FontStyle.Bold);
            y1.ForeColor = Color.Black;
            y1.Location = new Point(311, 411);
            y1.Name = "y1";
            y1.Size = new Size(65, 65);
            y1.TabIndex = 10;
            y1.Text = "Y";
            y1.TextAlign = ContentAlignment.MiddleCenter;

            // lblExample1Text
            lblExample1Text.BackColor = Color.White;
            lblExample1Text.Font = new Font("Arial", 15F);
            lblExample1Text.ForeColor = Color.Black;
            lblExample1Text.Location = new Point(25, 487);
            lblExample1Text.Name = "lblExample1Text";
            lblExample1Text.Size = new Size(560, 35);
            lblExample1Text.TabIndex = 11;
            lblExample1Text.Text = "W is in the word and in the correct spot.";

            // p2
            p2.BackColor = Color.White;
            p2.BorderStyle = BorderStyle.FixedSingle;
            p2.Font = new Font("Arial", 24F, FontStyle.Bold);
            p2.ForeColor = Color.Black;
            p2.Location = new Point(25, 556);
            p2.Name = "p2";
            p2.Size = new Size(65, 65);
            p2.TabIndex = 12;
            p2.Text = "P";
            p2.TextAlign = ContentAlignment.MiddleCenter;

            // i2
            i2.BackColor = Color.FromArgb(201, 180, 88);
            i2.BorderStyle = BorderStyle.FixedSingle;
            i2.Font = new Font("Arial", 24F, FontStyle.Bold);
            i2.ForeColor = Color.White;
            i2.Location = new Point(95, 556);
            i2.Name = "i2";
            i2.Size = new Size(65, 65);
            i2.TabIndex = 13;
            i2.Text = "I";
            i2.TextAlign = ContentAlignment.MiddleCenter;

            // l2a
            l2a.BackColor = Color.White;
            l2a.BorderStyle = BorderStyle.FixedSingle;
            l2a.Font = new Font("Arial", 24F, FontStyle.Bold);
            l2a.ForeColor = Color.Black;
            l2a.Location = new Point(167, 556);
            l2a.Name = "l2a";
            l2a.Size = new Size(65, 65);
            l2a.TabIndex = 14;
            l2a.Text = "L";
            l2a.TextAlign = ContentAlignment.MiddleCenter;

            // l2b
            l2b.BackColor = Color.White;
            l2b.BorderStyle = BorderStyle.FixedSingle;
            l2b.Font = new Font("Arial", 24F, FontStyle.Bold);
            l2b.ForeColor = Color.Black;
            l2b.Location = new Point(239, 556);
            l2b.Name = "l2b";
            l2b.Size = new Size(65, 65);
            l2b.TabIndex = 15;
            l2b.Text = "L";
            l2b.TextAlign = ContentAlignment.MiddleCenter;

            // s2
            s2.BackColor = Color.White;
            s2.BorderStyle = BorderStyle.FixedSingle;
            s2.Font = new Font("Arial", 24F, FontStyle.Bold);
            s2.ForeColor = Color.Black;
            s2.Location = new Point(311, 556);
            s2.Name = "s2";
            s2.Size = new Size(65, 65);
            s2.TabIndex = 16;
            s2.Text = "S";
            s2.TextAlign = ContentAlignment.MiddleCenter;

            // lblExample2Text
            lblExample2Text.BackColor = Color.White;
            lblExample2Text.Font = new Font("Arial", 15F);
            lblExample2Text.ForeColor = Color.Black;
            lblExample2Text.Location = new Point(25, 630);
            lblExample2Text.Name = "lblExample2Text";
            lblExample2Text.Size = new Size(560, 35);
            lblExample2Text.TabIndex = 17;
            lblExample2Text.Text = "I is in the word but in the wrong spot.";

            // v3
            v3.BackColor = Color.White;
            v3.BorderStyle = BorderStyle.FixedSingle;
            v3.Font = new Font("Arial", 24F, FontStyle.Bold);
            v3.ForeColor = Color.Black;
            v3.Location = new Point(24, 706);
            v3.Name = "v3";
            v3.Size = new Size(65, 65);
            v3.TabIndex = 18;
            v3.Text = "V";
            v3.TextAlign = ContentAlignment.MiddleCenter;

            // a3
            a3.BackColor = Color.White;
            a3.BorderStyle = BorderStyle.FixedSingle;
            a3.Font = new Font("Arial", 24F, FontStyle.Bold);
            a3.ForeColor = Color.Black;
            a3.Location = new Point(95, 706);
            a3.Name = "a3";
            a3.Size = new Size(65, 65);
            a3.TabIndex = 19;
            a3.Text = "A";
            a3.TextAlign = ContentAlignment.MiddleCenter;

            // g3
            g3.BackColor = Color.White;
            g3.BorderStyle = BorderStyle.FixedSingle;
            g3.Font = new Font("Arial", 24F, FontStyle.Bold);
            g3.ForeColor = Color.Black;
            g3.Location = new Point(167, 706);
            g3.Name = "g3";
            g3.Size = new Size(65, 65);
            g3.TabIndex = 20;
            g3.Text = "G";
            g3.TextAlign = ContentAlignment.MiddleCenter;

            // u3
            u3.BackColor = Color.FromArgb(120, 124, 126);
            u3.BorderStyle = BorderStyle.FixedSingle;
            u3.Font = new Font("Arial", 24F, FontStyle.Bold);
            u3.ForeColor = Color.White;
            u3.Location = new Point(240, 706);
            u3.Name = "u3";
            u3.Size = new Size(65, 65);
            u3.TabIndex = 21;
            u3.Text = "U";
            u3.TextAlign = ContentAlignment.MiddleCenter;

            // e3
            e3.BackColor = Color.White;
            e3.BorderStyle = BorderStyle.FixedSingle;
            e3.Font = new Font("Arial", 24F, FontStyle.Bold);
            e3.ForeColor = Color.Black;
            e3.Location = new Point(311, 706);
            e3.Name = "e3";
            e3.Size = new Size(65, 65);
            e3.TabIndex = 22;
            e3.Text = "E";
            e3.TextAlign = ContentAlignment.MiddleCenter;

            // lblExample3Text
            lblExample3Text.BackColor = Color.White;
            lblExample3Text.Font = new Font("Arial", 15F);
            lblExample3Text.ForeColor = Color.Black;
            lblExample3Text.Location = new Point(25, 777);
            lblExample3Text.Name = "lblExample3Text";
            lblExample3Text.Size = new Size(560, 35);
            lblExample3Text.TabIndex = 23;
            lblExample3Text.Text = "U is not in the word in any spot.";

            // HowToPlayForm
            BackColor = Color.White;
            ClientSize = new Size(691, 892);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(lblRule1);
            Controls.Add(lblRule2);
            Controls.Add(lblExamples);

            Controls.Add(w1);
            Controls.Add(e1);
            Controls.Add(a1);
            Controls.Add(r1);
            Controls.Add(y1);
            Controls.Add(lblExample1Text);

            Controls.Add(p2);
            Controls.Add(i2);
            Controls.Add(l2a);
            Controls.Add(l2b);
            Controls.Add(s2);
            Controls.Add(lblExample2Text);

            Controls.Add(v3);
            Controls.Add(a3);
            Controls.Add(g3);
            Controls.Add(u3);
            Controls.Add(e3);
            Controls.Add(lblExample3Text);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;
            Name = "HowToPlayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "How To Play";

            ResumeLayout(false);
        }
    }
}