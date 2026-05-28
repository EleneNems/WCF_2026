namespace Wordle_WinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblTitle;
        private Button btnHelp;
        private Button btnStats;
        private Button btnNewGame;

        private TextBox[,] _boxes = new TextBox[6, 5];

        private TextBox txt00; private TextBox txt01; private TextBox txt02; private TextBox txt03; private TextBox txt04;
        private TextBox txt10; private TextBox txt11; private TextBox txt12; private TextBox txt13; private TextBox txt14;
        private TextBox txt20; private TextBox txt21; private TextBox txt22; private TextBox txt23; private TextBox txt24;
        private TextBox txt30; private TextBox txt31; private TextBox txt32; private TextBox txt33; private TextBox txt34;
        private TextBox txt40; private TextBox txt41; private TextBox txt42; private TextBox txt43; private TextBox txt44;
        private TextBox txt50; private TextBox txt51; private TextBox txt52; private TextBox txt53; private TextBox txt54;

        private Button btnQ; private Button btnW; private Button btnE; private Button btnR; private Button btnT;
        private Button btnY; private Button btnU; private Button btnI; private Button btnO; private Button btnP;
        private Button btnA; private Button btnS; private Button btnD; private Button btnF; private Button btnG;
        private Button btnH; private Button btnJ; private Button btnK; private Button btnL;
        private Button btnEnter; private Button btnZ; private Button btnX; private Button btnC; private Button btnV;
        private Button btnB; private Button btnN; private Button btnM; private Button btnBackspace;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            btnHelp = new Button();
            lblTitle = new Label();
            btnStats = new Button();
            btnNewGame = new Button();
            txt00 = new TextBox();
            txt01 = new TextBox();
            txt02 = new TextBox();
            txt03 = new TextBox();
            txt04 = new TextBox();
            txt10 = new TextBox();
            txt11 = new TextBox();
            txt12 = new TextBox();
            txt13 = new TextBox();
            txt14 = new TextBox();
            txt20 = new TextBox();
            txt21 = new TextBox();
            txt22 = new TextBox();
            txt23 = new TextBox();
            txt24 = new TextBox();
            txt30 = new TextBox();
            txt31 = new TextBox();
            txt32 = new TextBox();
            txt33 = new TextBox();
            txt34 = new TextBox();
            txt40 = new TextBox();
            txt41 = new TextBox();
            txt42 = new TextBox();
            txt43 = new TextBox();
            txt44 = new TextBox();
            txt50 = new TextBox();
            txt51 = new TextBox();
            txt52 = new TextBox();
            txt53 = new TextBox();
            txt54 = new TextBox();
            btnQ = new Button();
            btnW = new Button();
            btnE = new Button();
            btnR = new Button();
            btnT = new Button();
            btnY = new Button();
            btnU = new Button();
            btnI = new Button();
            btnO = new Button();
            btnP = new Button();
            btnA = new Button();
            btnS = new Button();
            btnD = new Button();
            btnF = new Button();
            btnG = new Button();
            btnH = new Button();
            btnJ = new Button();
            btnK = new Button();
            btnL = new Button();
            btnEnter = new Button();
            btnZ = new Button();
            btnX = new Button();
            btnC = new Button();
            btnV = new Button();
            btnB = new Button();
            btnN = new Button();
            btnM = new Button();
            btnBackspace = new Button();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.BorderStyle = BorderStyle.FixedSingle;
            headerPanel.Controls.Add(btnHelp);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(btnStats);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(520, 70);
            headerPanel.TabIndex = 0;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.White;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnHelp.Location = new Point(35, 8);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(45, 50);
            btnHelp.TabIndex = 0;
            btnHelp.Text = "�";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Georgia", 28F, FontStyle.Bold);
            lblTitle.Location = new Point(141, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(245, 55);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Wordle";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStats
            // 
            btnStats.BackColor = Color.White;
            btnStats.FlatAppearance.BorderSize = 0;
            btnStats.FlatStyle = FlatStyle.Flat;
            btnStats.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnStats.Location = new Point(440, 15);
            btnStats.Name = "btnStats";
            btnStats.Size = new Size(45, 40);
            btnStats.TabIndex = 2;
            btnStats.Text = "📊";
            btnStats.UseVisualStyleBackColor = false;
            btnStats.Click += btnStats_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = Color.Black;
            btnNewGame.FlatAppearance.BorderSize = 0;
            btnNewGame.FlatStyle = FlatStyle.Flat;
            btnNewGame.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNewGame.ForeColor = Color.White;
            btnNewGame.Location = new Point(192, 87);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(140, 53);
            btnNewGame.TabIndex = 1;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // txt00
            // 
            txt00.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt00.Location = new Point(89, 155);
            txt00.Name = "txt00";
            txt00.ReadOnly = true;
            txt00.Size = new Size(62, 66);
            txt00.TabIndex = 2;
            txt00.TextAlign = HorizontalAlignment.Center;
            // 
            // txt01
            // 
            txt01.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt01.Location = new Point(158, 155);
            txt01.Name = "txt01";
            txt01.ReadOnly = true;
            txt01.Size = new Size(62, 66);
            txt01.TabIndex = 3;
            txt01.TextAlign = HorizontalAlignment.Center;
            // 
            // txt02
            // 
            txt02.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt02.Location = new Point(227, 155);
            txt02.Name = "txt02";
            txt02.ReadOnly = true;
            txt02.Size = new Size(62, 66);
            txt02.TabIndex = 4;
            txt02.TextAlign = HorizontalAlignment.Center;
            // 
            // txt03
            // 
            txt03.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt03.Location = new Point(296, 155);
            txt03.Name = "txt03";
            txt03.ReadOnly = true;
            txt03.Size = new Size(62, 66);
            txt03.TabIndex = 5;
            txt03.TextAlign = HorizontalAlignment.Center;
            // 
            // txt04
            // 
            txt04.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt04.Location = new Point(365, 155);
            txt04.Name = "txt04";
            txt04.ReadOnly = true;
            txt04.Size = new Size(62, 66);
            txt04.TabIndex = 6;
            txt04.TextAlign = HorizontalAlignment.Center;
            // 
            // txt10
            // 
            txt10.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt10.Location = new Point(89, 224);
            txt10.Name = "txt10";
            txt10.ReadOnly = true;
            txt10.Size = new Size(62, 66);
            txt10.TabIndex = 7;
            txt10.TextAlign = HorizontalAlignment.Center;
            // 
            // txt11
            // 
            txt11.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt11.Location = new Point(158, 224);
            txt11.Name = "txt11";
            txt11.ReadOnly = true;
            txt11.Size = new Size(62, 66);
            txt11.TabIndex = 8;
            txt11.TextAlign = HorizontalAlignment.Center;
            // 
            // txt12
            // 
            txt12.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt12.Location = new Point(227, 224);
            txt12.Name = "txt12";
            txt12.ReadOnly = true;
            txt12.Size = new Size(62, 66);
            txt12.TabIndex = 9;
            txt12.TextAlign = HorizontalAlignment.Center;
            // 
            // txt13
            // 
            txt13.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt13.Location = new Point(296, 224);
            txt13.Name = "txt13";
            txt13.ReadOnly = true;
            txt13.Size = new Size(62, 66);
            txt13.TabIndex = 10;
            txt13.TextAlign = HorizontalAlignment.Center;
            // 
            // txt14
            // 
            txt14.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt14.Location = new Point(365, 224);
            txt14.Name = "txt14";
            txt14.ReadOnly = true;
            txt14.Size = new Size(62, 66);
            txt14.TabIndex = 11;
            txt14.TextAlign = HorizontalAlignment.Center;
            // 
            // txt20
            // 
            txt20.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt20.Location = new Point(89, 293);
            txt20.Name = "txt20";
            txt20.ReadOnly = true;
            txt20.Size = new Size(62, 66);
            txt20.TabIndex = 12;
            txt20.TextAlign = HorizontalAlignment.Center;
            // 
            // txt21
            // 
            txt21.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt21.Location = new Point(158, 293);
            txt21.Name = "txt21";
            txt21.ReadOnly = true;
            txt21.Size = new Size(62, 66);
            txt21.TabIndex = 13;
            txt21.TextAlign = HorizontalAlignment.Center;
            // 
            // txt22
            // 
            txt22.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt22.Location = new Point(227, 293);
            txt22.Name = "txt22";
            txt22.ReadOnly = true;
            txt22.Size = new Size(62, 66);
            txt22.TabIndex = 14;
            txt22.TextAlign = HorizontalAlignment.Center;
            // 
            // txt23
            // 
            txt23.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt23.Location = new Point(296, 293);
            txt23.Name = "txt23";
            txt23.ReadOnly = true;
            txt23.Size = new Size(62, 66);
            txt23.TabIndex = 15;
            txt23.TextAlign = HorizontalAlignment.Center;
            // 
            // txt24
            // 
            txt24.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt24.Location = new Point(365, 293);
            txt24.Name = "txt24";
            txt24.ReadOnly = true;
            txt24.Size = new Size(62, 66);
            txt24.TabIndex = 16;
            txt24.TextAlign = HorizontalAlignment.Center;
            // 
            // txt30
            // 
            txt30.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt30.Location = new Point(89, 362);
            txt30.Name = "txt30";
            txt30.ReadOnly = true;
            txt30.Size = new Size(62, 66);
            txt30.TabIndex = 17;
            txt30.TextAlign = HorizontalAlignment.Center;
            // 
            // txt31
            // 
            txt31.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt31.Location = new Point(158, 362);
            txt31.Name = "txt31";
            txt31.ReadOnly = true;
            txt31.Size = new Size(62, 66);
            txt31.TabIndex = 18;
            txt31.TextAlign = HorizontalAlignment.Center;
            // 
            // txt32
            // 
            txt32.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt32.Location = new Point(227, 362);
            txt32.Name = "txt32";
            txt32.ReadOnly = true;
            txt32.Size = new Size(62, 66);
            txt32.TabIndex = 19;
            txt32.TextAlign = HorizontalAlignment.Center;
            // 
            // txt33
            // 
            txt33.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt33.Location = new Point(296, 362);
            txt33.Name = "txt33";
            txt33.ReadOnly = true;
            txt33.Size = new Size(62, 66);
            txt33.TabIndex = 20;
            txt33.TextAlign = HorizontalAlignment.Center;
            // 
            // txt34
            // 
            txt34.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt34.Location = new Point(365, 362);
            txt34.Name = "txt34";
            txt34.ReadOnly = true;
            txt34.Size = new Size(62, 66);
            txt34.TabIndex = 21;
            txt34.TextAlign = HorizontalAlignment.Center;
            // 
            // txt40
            // 
            txt40.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt40.Location = new Point(89, 431);
            txt40.Name = "txt40";
            txt40.ReadOnly = true;
            txt40.Size = new Size(62, 66);
            txt40.TabIndex = 22;
            txt40.TextAlign = HorizontalAlignment.Center;
            // 
            // txt41
            // 
            txt41.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt41.Location = new Point(158, 431);
            txt41.Name = "txt41";
            txt41.ReadOnly = true;
            txt41.Size = new Size(62, 66);
            txt41.TabIndex = 23;
            txt41.TextAlign = HorizontalAlignment.Center;
            // 
            // txt42
            // 
            txt42.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt42.Location = new Point(227, 431);
            txt42.Name = "txt42";
            txt42.ReadOnly = true;
            txt42.Size = new Size(62, 66);
            txt42.TabIndex = 24;
            txt42.TextAlign = HorizontalAlignment.Center;
            // 
            // txt43
            // 
            txt43.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt43.Location = new Point(296, 431);
            txt43.Name = "txt43";
            txt43.ReadOnly = true;
            txt43.Size = new Size(62, 66);
            txt43.TabIndex = 25;
            txt43.TextAlign = HorizontalAlignment.Center;
            // 
            // txt44
            // 
            txt44.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt44.Location = new Point(365, 431);
            txt44.Name = "txt44";
            txt44.ReadOnly = true;
            txt44.Size = new Size(62, 66);
            txt44.TabIndex = 26;
            txt44.TextAlign = HorizontalAlignment.Center;
            // 
            // txt50
            // 
            txt50.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt50.Location = new Point(89, 500);
            txt50.Name = "txt50";
            txt50.ReadOnly = true;
            txt50.Size = new Size(62, 66);
            txt50.TabIndex = 27;
            txt50.TextAlign = HorizontalAlignment.Center;
            // 
            // txt51
            // 
            txt51.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt51.Location = new Point(158, 500);
            txt51.Name = "txt51";
            txt51.ReadOnly = true;
            txt51.Size = new Size(62, 66);
            txt51.TabIndex = 28;
            txt51.TextAlign = HorizontalAlignment.Center;
            // 
            // txt52
            // 
            txt52.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt52.Location = new Point(227, 500);
            txt52.Name = "txt52";
            txt52.ReadOnly = true;
            txt52.Size = new Size(62, 66);
            txt52.TabIndex = 29;
            txt52.TextAlign = HorizontalAlignment.Center;
            // 
            // txt53
            // 
            txt53.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt53.Location = new Point(296, 500);
            txt53.Name = "txt53";
            txt53.ReadOnly = true;
            txt53.Size = new Size(62, 66);
            txt53.TabIndex = 30;
            txt53.TextAlign = HorizontalAlignment.Center;
            // 
            // txt54
            // 
            txt54.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txt54.Location = new Point(365, 500);
            txt54.Name = "txt54";
            txt54.ReadOnly = true;
            txt54.Size = new Size(62, 66);
            txt54.TabIndex = 31;
            txt54.TextAlign = HorizontalAlignment.Center;
            // 
            // btnQ
            // 
            btnQ.BackColor = Color.FromArgb(211, 214, 218);
            btnQ.FlatAppearance.BorderSize = 0;
            btnQ.FlatStyle = FlatStyle.Flat;
            btnQ.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQ.Location = new Point(15, 625);
            btnQ.Name = "btnQ";
            btnQ.Size = new Size(45, 48);
            btnQ.TabIndex = 32;
            btnQ.Text = "Q";
            btnQ.UseVisualStyleBackColor = false;
            btnQ.Click += KeyboardButton_Click;
            // 
            // btnW
            // 
            btnW.BackColor = Color.FromArgb(211, 214, 218);
            btnW.FlatAppearance.BorderSize = 0;
            btnW.FlatStyle = FlatStyle.Flat;
            btnW.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnW.Location = new Point(64, 625);
            btnW.Name = "btnW";
            btnW.Size = new Size(45, 48);
            btnW.TabIndex = 33;
            btnW.Text = "W";
            btnW.UseVisualStyleBackColor = false;
            btnW.Click += KeyboardButton_Click;
            // 
            // btnE
            // 
            btnE.BackColor = Color.FromArgb(211, 214, 218);
            btnE.FlatAppearance.BorderSize = 0;
            btnE.FlatStyle = FlatStyle.Flat;
            btnE.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnE.Location = new Point(113, 625);
            btnE.Name = "btnE";
            btnE.Size = new Size(45, 48);
            btnE.TabIndex = 34;
            btnE.Text = "E";
            btnE.UseVisualStyleBackColor = false;
            btnE.Click += KeyboardButton_Click;
            // 
            // btnR
            // 
            btnR.BackColor = Color.FromArgb(211, 214, 218);
            btnR.FlatAppearance.BorderSize = 0;
            btnR.FlatStyle = FlatStyle.Flat;
            btnR.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnR.Location = new Point(162, 625);
            btnR.Name = "btnR";
            btnR.Size = new Size(45, 48);
            btnR.TabIndex = 35;
            btnR.Text = "R";
            btnR.UseVisualStyleBackColor = false;
            btnR.Click += KeyboardButton_Click;
            // 
            // btnT
            // 
            btnT.BackColor = Color.FromArgb(211, 214, 218);
            btnT.FlatAppearance.BorderSize = 0;
            btnT.FlatStyle = FlatStyle.Flat;
            btnT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnT.Location = new Point(211, 625);
            btnT.Name = "btnT";
            btnT.Size = new Size(45, 48);
            btnT.TabIndex = 36;
            btnT.Text = "T";
            btnT.UseVisualStyleBackColor = false;
            btnT.Click += KeyboardButton_Click;
            // 
            // btnY
            // 
            btnY.BackColor = Color.FromArgb(211, 214, 218);
            btnY.FlatAppearance.BorderSize = 0;
            btnY.FlatStyle = FlatStyle.Flat;
            btnY.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnY.Location = new Point(260, 625);
            btnY.Name = "btnY";
            btnY.Size = new Size(45, 48);
            btnY.TabIndex = 37;
            btnY.Text = "Y";
            btnY.UseVisualStyleBackColor = false;
            btnY.Click += KeyboardButton_Click;
            // 
            // btnU
            // 
            btnU.BackColor = Color.FromArgb(211, 214, 218);
            btnU.FlatAppearance.BorderSize = 0;
            btnU.FlatStyle = FlatStyle.Flat;
            btnU.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnU.Location = new Point(309, 625);
            btnU.Name = "btnU";
            btnU.Size = new Size(45, 48);
            btnU.TabIndex = 38;
            btnU.Text = "U";
            btnU.UseVisualStyleBackColor = false;
            btnU.Click += KeyboardButton_Click;
            // 
            // btnI
            // 
            btnI.BackColor = Color.FromArgb(211, 214, 218);
            btnI.FlatAppearance.BorderSize = 0;
            btnI.FlatStyle = FlatStyle.Flat;
            btnI.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnI.Location = new Point(358, 625);
            btnI.Name = "btnI";
            btnI.Size = new Size(45, 48);
            btnI.TabIndex = 39;
            btnI.Text = "I";
            btnI.UseVisualStyleBackColor = false;
            btnI.Click += KeyboardButton_Click;
            // 
            // btnO
            // 
            btnO.BackColor = Color.FromArgb(211, 214, 218);
            btnO.FlatAppearance.BorderSize = 0;
            btnO.FlatStyle = FlatStyle.Flat;
            btnO.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnO.Location = new Point(407, 625);
            btnO.Name = "btnO";
            btnO.Size = new Size(45, 48);
            btnO.TabIndex = 40;
            btnO.Text = "O";
            btnO.UseVisualStyleBackColor = false;
            btnO.Click += KeyboardButton_Click;
            // 
            // btnP
            // 
            btnP.BackColor = Color.FromArgb(211, 214, 218);
            btnP.FlatAppearance.BorderSize = 0;
            btnP.FlatStyle = FlatStyle.Flat;
            btnP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnP.Location = new Point(456, 625);
            btnP.Name = "btnP";
            btnP.Size = new Size(45, 48);
            btnP.TabIndex = 41;
            btnP.Text = "P";
            btnP.UseVisualStyleBackColor = false;
            btnP.Click += KeyboardButton_Click;
            // 
            // btnA
            // 
            btnA.BackColor = Color.FromArgb(211, 214, 218);
            btnA.FlatAppearance.BorderSize = 0;
            btnA.FlatStyle = FlatStyle.Flat;
            btnA.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnA.Location = new Point(39, 680);
            btnA.Name = "btnA";
            btnA.Size = new Size(45, 48);
            btnA.TabIndex = 42;
            btnA.Text = "A";
            btnA.UseVisualStyleBackColor = false;
            btnA.Click += KeyboardButton_Click;
            // 
            // btnS
            // 
            btnS.BackColor = Color.FromArgb(211, 214, 218);
            btnS.FlatAppearance.BorderSize = 0;
            btnS.FlatStyle = FlatStyle.Flat;
            btnS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnS.Location = new Point(88, 680);
            btnS.Name = "btnS";
            btnS.Size = new Size(45, 48);
            btnS.TabIndex = 43;
            btnS.Text = "S";
            btnS.UseVisualStyleBackColor = false;
            btnS.Click += KeyboardButton_Click;
            // 
            // btnD
            // 
            btnD.BackColor = Color.FromArgb(211, 214, 218);
            btnD.FlatAppearance.BorderSize = 0;
            btnD.FlatStyle = FlatStyle.Flat;
            btnD.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnD.Location = new Point(137, 680);
            btnD.Name = "btnD";
            btnD.Size = new Size(45, 48);
            btnD.TabIndex = 44;
            btnD.Text = "D";
            btnD.UseVisualStyleBackColor = false;
            btnD.Click += KeyboardButton_Click;
            // 
            // btnF
            // 
            btnF.BackColor = Color.FromArgb(211, 214, 218);
            btnF.FlatAppearance.BorderSize = 0;
            btnF.FlatStyle = FlatStyle.Flat;
            btnF.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnF.Location = new Point(186, 680);
            btnF.Name = "btnF";
            btnF.Size = new Size(45, 48);
            btnF.TabIndex = 45;
            btnF.Text = "F";
            btnF.UseVisualStyleBackColor = false;
            btnF.Click += KeyboardButton_Click;
            // 
            // btnG
            // 
            btnG.BackColor = Color.FromArgb(211, 214, 218);
            btnG.FlatAppearance.BorderSize = 0;
            btnG.FlatStyle = FlatStyle.Flat;
            btnG.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnG.Location = new Point(235, 680);
            btnG.Name = "btnG";
            btnG.Size = new Size(45, 48);
            btnG.TabIndex = 46;
            btnG.Text = "G";
            btnG.UseVisualStyleBackColor = false;
            btnG.Click += KeyboardButton_Click;
            // 
            // btnH
            // 
            btnH.BackColor = Color.FromArgb(211, 214, 218);
            btnH.FlatAppearance.BorderSize = 0;
            btnH.FlatStyle = FlatStyle.Flat;
            btnH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnH.Location = new Point(284, 680);
            btnH.Name = "btnH";
            btnH.Size = new Size(45, 48);
            btnH.TabIndex = 47;
            btnH.Text = "H";
            btnH.UseVisualStyleBackColor = false;
            btnH.Click += KeyboardButton_Click;
            // 
            // btnJ
            // 
            btnJ.BackColor = Color.FromArgb(211, 214, 218);
            btnJ.FlatAppearance.BorderSize = 0;
            btnJ.FlatStyle = FlatStyle.Flat;
            btnJ.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnJ.Location = new Point(333, 680);
            btnJ.Name = "btnJ";
            btnJ.Size = new Size(45, 48);
            btnJ.TabIndex = 48;
            btnJ.Text = "J";
            btnJ.UseVisualStyleBackColor = false;
            btnJ.Click += KeyboardButton_Click;
            // 
            // btnK
            // 
            btnK.BackColor = Color.FromArgb(211, 214, 218);
            btnK.FlatAppearance.BorderSize = 0;
            btnK.FlatStyle = FlatStyle.Flat;
            btnK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnK.Location = new Point(382, 680);
            btnK.Name = "btnK";
            btnK.Size = new Size(45, 48);
            btnK.TabIndex = 49;
            btnK.Text = "K";
            btnK.UseVisualStyleBackColor = false;
            btnK.Click += KeyboardButton_Click;
            // 
            // btnL
            // 
            btnL.BackColor = Color.FromArgb(211, 214, 218);
            btnL.FlatAppearance.BorderSize = 0;
            btnL.FlatStyle = FlatStyle.Flat;
            btnL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnL.Location = new Point(431, 680);
            btnL.Name = "btnL";
            btnL.Size = new Size(45, 48);
            btnL.TabIndex = 50;
            btnL.Text = "L";
            btnL.UseVisualStyleBackColor = false;
            btnL.Click += KeyboardButton_Click;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = Color.FromArgb(211, 214, 218);
            btnEnter.FlatAppearance.BorderSize = 0;
            btnEnter.FlatStyle = FlatStyle.Flat;
            btnEnter.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnEnter.Location = new Point(15, 735);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(72, 48);
            btnEnter.TabIndex = 51;
            btnEnter.Text = "ENTER";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += KeyboardButton_Click;
            // 
            // btnZ
            // 
            btnZ.BackColor = Color.FromArgb(211, 214, 218);
            btnZ.FlatAppearance.BorderSize = 0;
            btnZ.FlatStyle = FlatStyle.Flat;
            btnZ.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnZ.Location = new Point(91, 735);
            btnZ.Name = "btnZ";
            btnZ.Size = new Size(45, 48);
            btnZ.TabIndex = 52;
            btnZ.Text = "Z";
            btnZ.UseVisualStyleBackColor = false;
            btnZ.Click += KeyboardButton_Click;
            // 
            // btnX
            // 
            btnX.BackColor = Color.FromArgb(211, 214, 218);
            btnX.FlatAppearance.BorderSize = 0;
            btnX.FlatStyle = FlatStyle.Flat;
            btnX.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnX.Location = new Point(140, 735);
            btnX.Name = "btnX";
            btnX.Size = new Size(45, 48);
            btnX.TabIndex = 53;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += KeyboardButton_Click;
            // 
            // btnC
            // 
            btnC.BackColor = Color.FromArgb(211, 214, 218);
            btnC.FlatAppearance.BorderSize = 0;
            btnC.FlatStyle = FlatStyle.Flat;
            btnC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnC.Location = new Point(189, 735);
            btnC.Name = "btnC";
            btnC.Size = new Size(45, 48);
            btnC.TabIndex = 54;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = false;
            btnC.Click += KeyboardButton_Click;
            // 
            // btnV
            // 
            btnV.BackColor = Color.FromArgb(211, 214, 218);
            btnV.FlatAppearance.BorderSize = 0;
            btnV.FlatStyle = FlatStyle.Flat;
            btnV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnV.Location = new Point(238, 735);
            btnV.Name = "btnV";
            btnV.Size = new Size(45, 48);
            btnV.TabIndex = 55;
            btnV.Text = "V";
            btnV.UseVisualStyleBackColor = false;
            btnV.Click += KeyboardButton_Click;
            // 
            // btnB
            // 
            btnB.BackColor = Color.FromArgb(211, 214, 218);
            btnB.FlatAppearance.BorderSize = 0;
            btnB.FlatStyle = FlatStyle.Flat;
            btnB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnB.Location = new Point(287, 735);
            btnB.Name = "btnB";
            btnB.Size = new Size(45, 48);
            btnB.TabIndex = 56;
            btnB.Text = "B";
            btnB.UseVisualStyleBackColor = false;
            btnB.Click += KeyboardButton_Click;
            // 
            // btnN
            // 
            btnN.BackColor = Color.FromArgb(211, 214, 218);
            btnN.FlatAppearance.BorderSize = 0;
            btnN.FlatStyle = FlatStyle.Flat;
            btnN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnN.Location = new Point(336, 735);
            btnN.Name = "btnN";
            btnN.Size = new Size(45, 48);
            btnN.TabIndex = 57;
            btnN.Text = "N";
            btnN.UseVisualStyleBackColor = false;
            btnN.Click += KeyboardButton_Click;
            // 
            // btnM
            // 
            btnM.BackColor = Color.FromArgb(211, 214, 218);
            btnM.FlatAppearance.BorderSize = 0;
            btnM.FlatStyle = FlatStyle.Flat;
            btnM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnM.Location = new Point(385, 735);
            btnM.Name = "btnM";
            btnM.Size = new Size(45, 48);
            btnM.TabIndex = 58;
            btnM.Text = "M";
            btnM.UseVisualStyleBackColor = false;
            btnM.Click += KeyboardButton_Click;
            // 
            // btnBackspace
            // 
            btnBackspace.BackColor = Color.FromArgb(211, 214, 218);
            btnBackspace.FlatAppearance.BorderSize = 0;
            btnBackspace.FlatStyle = FlatStyle.Flat;
            btnBackspace.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBackspace.Location = new Point(434, 735);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(65, 48);
            btnBackspace.TabIndex = 59;
            btnBackspace.Text = "⌫";
            btnBackspace.UseVisualStyleBackColor = false;
            btnBackspace.Click += KeyboardButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 820);
            Controls.Add(headerPanel);
            Controls.Add(btnNewGame);
            Controls.Add(txt00);
            Controls.Add(txt01);
            Controls.Add(txt02);
            Controls.Add(txt03);
            Controls.Add(txt04);
            Controls.Add(txt10);
            Controls.Add(txt11);
            Controls.Add(txt12);
            Controls.Add(txt13);
            Controls.Add(txt14);
            Controls.Add(txt20);
            Controls.Add(txt21);
            Controls.Add(txt22);
            Controls.Add(txt23);
            Controls.Add(txt24);
            Controls.Add(txt30);
            Controls.Add(txt31);
            Controls.Add(txt32);
            Controls.Add(txt33);
            Controls.Add(txt34);
            Controls.Add(txt40);
            Controls.Add(txt41);
            Controls.Add(txt42);
            Controls.Add(txt43);
            Controls.Add(txt44);
            Controls.Add(txt50);
            Controls.Add(txt51);
            Controls.Add(txt52);
            Controls.Add(txt53);
            Controls.Add(txt54);
            Controls.Add(btnQ);
            Controls.Add(btnW);
            Controls.Add(btnE);
            Controls.Add(btnR);
            Controls.Add(btnT);
            Controls.Add(btnY);
            Controls.Add(btnU);
            Controls.Add(btnI);
            Controls.Add(btnO);
            Controls.Add(btnP);
            Controls.Add(btnA);
            Controls.Add(btnS);
            Controls.Add(btnD);
            Controls.Add(btnF);
            Controls.Add(btnG);
            Controls.Add(btnH);
            Controls.Add(btnJ);
            Controls.Add(btnK);
            Controls.Add(btnL);
            Controls.Add(btnEnter);
            Controls.Add(btnZ);
            Controls.Add(btnX);
            Controls.Add(btnC);
            Controls.Add(btnV);
            Controls.Add(btnB);
            Controls.Add(btnN);
            Controls.Add(btnM);
            Controls.Add(btnBackspace);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wordle";
            Load += Form1_Load;
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupBox(TextBox box, int x, int y)
        {
            box.Location = new Point(x, y);
            box.Size = new Size(62, 62);
            box.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            box.TextAlign = HorizontalAlignment.Center;
            box.MaxLength = 1;
            box.CharacterCasing = CharacterCasing.Upper;
            box.ReadOnly = true;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = Color.White;
            box.ForeColor = Color.Black;
            box.TabStop = false;
        }

        private void SetupKey(Button btn, string text, int x, int y, int width)
        {
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(width, 48);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.BackColor = Color.FromArgb(211, 214, 218);
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Click += KeyboardButton_Click;
        }

    }
}