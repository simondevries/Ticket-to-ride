namespace Ticket_to_ride
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlView = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.txtToLoc = new System.Windows.Forms.TextBox();
            this.txtFromLoc = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnectionColour = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.txtCon2 = new System.Windows.Forms.TextBox();
            this.txtConOne = new System.Windows.Forms.TextBox();
            this.txtRemoveID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.fromTop = new System.Windows.Forms.Button();
            this.turn = new System.Windows.Forms.Label();
            this.playersCards = new System.Windows.Forms.ListBox();
            this.deckSize = new System.Windows.Forms.Label();
            this.boardCardFive = new System.Windows.Forms.Button();
            this.boardCardFour = new System.Windows.Forms.Button();
            this.boardCardThree = new System.Windows.Forms.Button();
            this.boardCardTwo = new System.Windows.Forms.Button();
            this.boardCardOne = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.mainFrame1 = new Ticket_to_ride.MainFrame();
            this.pnlView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlView.BackgroundImage")));
            this.pnlView.Controls.Add(this.button4);
            this.pnlView.Controls.Add(this.txtToLoc);
            this.pnlView.Controls.Add(this.txtFromLoc);
            this.pnlView.Controls.Add(this.button3);
            this.pnlView.Controls.Add(this.label1);
            this.pnlView.Controls.Add(this.txtConnectionColour);
            this.pnlView.Controls.Add(this.txtWeight);
            this.pnlView.Controls.Add(this.btnAttach);
            this.pnlView.Controls.Add(this.txtCon2);
            this.pnlView.Controls.Add(this.txtConOne);
            this.pnlView.Controls.Add(this.txtRemoveID);
            this.pnlView.Controls.Add(this.button2);
            this.pnlView.Controls.Add(this.txtID);
            this.pnlView.Controls.Add(this.btnGenerate);
            this.pnlView.Controls.Add(this.txtOutput);
            this.pnlView.Controls.Add(this.txtY);
            this.pnlView.Controls.Add(this.txtX);
            this.pnlView.Controls.Add(this.fromTop);
            this.pnlView.Controls.Add(this.turn);
            this.pnlView.Controls.Add(this.playersCards);
            this.pnlView.Controls.Add(this.deckSize);
            this.pnlView.Controls.Add(this.boardCardFive);
            this.pnlView.Controls.Add(this.boardCardFour);
            this.pnlView.Controls.Add(this.boardCardThree);
            this.pnlView.Controls.Add(this.boardCardTwo);
            this.pnlView.Controls.Add(this.boardCardOne);
            this.pnlView.Controls.Add(this.button1);
            this.pnlView.Controls.Add(this.elementHost2);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(1367, 741);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1278, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "Move";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtToLoc
            // 
            this.txtToLoc.Location = new System.Drawing.Point(1259, 422);
            this.txtToLoc.Name = "txtToLoc";
            this.txtToLoc.Size = new System.Drawing.Size(66, 20);
            this.txtToLoc.TabIndex = 26;
            this.txtToLoc.Text = "to";
            // 
            // txtFromLoc
            // 
            this.txtFromLoc.Location = new System.Drawing.Point(1197, 422);
            this.txtFromLoc.Name = "txtFromLoc";
            this.txtFromLoc.Size = new System.Drawing.Size(66, 20);
            this.txtFromLoc.TabIndex = 25;
            this.txtFromLoc.Text = "from";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1196, 448);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 25);
            this.button3.TabIndex = 24;
            this.button3.Text = "RemoveID Connection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1153, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = " Black, Orange, Red,Green, White,Undefined";
            // 
            // txtConnectionColour
            // 
            this.txtConnectionColour.Location = new System.Drawing.Point(1162, 577);
            this.txtConnectionColour.Name = "txtConnectionColour";
            this.txtConnectionColour.Size = new System.Drawing.Size(85, 20);
            this.txtConnectionColour.TabIndex = 22;
            this.txtConnectionColour.Text = "Colour";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(1160, 551);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(85, 20);
            this.txtWeight.TabIndex = 21;
            this.txtWeight.Text = "WEight";
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(1259, 499);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(63, 25);
            this.btnAttach.TabIndex = 20;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // txtCon2
            // 
            this.txtCon2.Location = new System.Drawing.Point(1160, 525);
            this.txtCon2.Name = "txtCon2";
            this.txtCon2.Size = new System.Drawing.Size(85, 20);
            this.txtCon2.TabIndex = 19;
            // 
            // txtConOne
            // 
            this.txtConOne.Location = new System.Drawing.Point(1162, 499);
            this.txtConOne.Name = "txtConOne";
            this.txtConOne.Size = new System.Drawing.Size(85, 20);
            this.txtConOne.TabIndex = 18;
            // 
            // txtRemoveID
            // 
            this.txtRemoveID.Location = new System.Drawing.Point(1222, 365);
            this.txtRemoveID.Name = "txtRemoveID";
            this.txtRemoveID.Size = new System.Drawing.Size(100, 20);
            this.txtRemoveID.TabIndex = 17;
            this.txtRemoveID.Text = "RemoveID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1221, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 25);
            this.button2.TabIndex = 16;
            this.button2.Text = "RemoveID Location";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1238, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(109, 20);
            this.txtID.TabIndex = 15;
            this.txtID.Text = "ID";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(1197, 84);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(1244, 120);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(103, 222);
            this.txtOutput.TabIndex = 13;
            this.txtOutput.Text = "";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(1247, 58);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 12;
            this.txtY.Text = "TxtY";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(1238, 32);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(109, 20);
            this.txtX.TabIndex = 11;
            this.txtX.Text = "X";
            // 
            // fromTop
            // 
            this.fromTop.Location = new System.Drawing.Point(814, 747);
            this.fromTop.Name = "fromTop";
            this.fromTop.Size = new System.Drawing.Size(75, 64);
            this.fromTop.TabIndex = 10;
            this.fromTop.Text = "From Top";
            this.fromTop.UseVisualStyleBackColor = true;
            this.fromTop.Click += new System.EventHandler(this.fromTop_Click);
            // 
            // turn
            // 
            this.turn.AutoSize = true;
            this.turn.Location = new System.Drawing.Point(49, 676);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(29, 13);
            this.turn.TabIndex = 9;
            this.turn.Text = "Turn";
            // 
            // playersCards
            // 
            this.playersCards.FormattingEnabled = true;
            this.playersCards.Location = new System.Drawing.Point(627, 704);
            this.playersCards.Name = "playersCards";
            this.playersCards.Size = new System.Drawing.Size(77, 147);
            this.playersCards.TabIndex = 8;
            // 
            // deckSize
            // 
            this.deckSize.AutoSize = true;
            this.deckSize.Location = new System.Drawing.Point(534, 676);
            this.deckSize.Name = "deckSize";
            this.deckSize.Size = new System.Drawing.Size(52, 13);
            this.deckSize.TabIndex = 7;
            this.deckSize.Text = "deck size";
            // 
            // boardCardFive
            // 
            this.boardCardFive.Location = new System.Drawing.Point(1561, 650);
            this.boardCardFive.Name = "boardCardFive";
            this.boardCardFive.Size = new System.Drawing.Size(75, 64);
            this.boardCardFive.TabIndex = 6;
            this.boardCardFive.Text = "Refresh";
            this.boardCardFive.UseVisualStyleBackColor = true;
            // 
            // boardCardFour
            // 
            this.boardCardFour.Location = new System.Drawing.Point(1221, 650);
            this.boardCardFour.Name = "boardCardFour";
            this.boardCardFour.Size = new System.Drawing.Size(75, 64);
            this.boardCardFour.TabIndex = 5;
            this.boardCardFour.Text = "Refresh";
            this.boardCardFour.UseVisualStyleBackColor = true;
            this.boardCardFour.Click += new System.EventHandler(this.boardCardFour_Click);
            // 
            // boardCardThree
            // 
            this.boardCardThree.Location = new System.Drawing.Point(294, 704);
            this.boardCardThree.Name = "boardCardThree";
            this.boardCardThree.Size = new System.Drawing.Size(75, 64);
            this.boardCardThree.TabIndex = 4;
            this.boardCardThree.Text = "Next Turn";
            this.boardCardThree.UseVisualStyleBackColor = true;
            // 
            // boardCardTwo
            // 
            this.boardCardTwo.Location = new System.Drawing.Point(213, 704);
            this.boardCardTwo.Name = "boardCardTwo";
            this.boardCardTwo.Size = new System.Drawing.Size(75, 64);
            this.boardCardTwo.TabIndex = 3;
            this.boardCardTwo.Text = "Next Turn";
            this.boardCardTwo.UseVisualStyleBackColor = true;
            // 
            // boardCardOne
            // 
            this.boardCardOne.Location = new System.Drawing.Point(127, 704);
            this.boardCardOne.Name = "boardCardOne";
            this.boardCardOne.Size = new System.Drawing.Size(80, 64);
            this.boardCardOne.TabIndex = 2;
            this.boardCardOne.Text = "Next Turn";
            this.boardCardOne.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 709);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next Turn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(12, 0);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(97, 78);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.mainFrame1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 741);
            this.Controls.Add(this.pnlView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Label deckSize;
        private System.Windows.Forms.Button boardCardFive;
        private System.Windows.Forms.Button boardCardFour;
        private System.Windows.Forms.Button boardCardThree;
        private System.Windows.Forms.Button boardCardTwo;
        private System.Windows.Forms.Button boardCardOne;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.ListBox playersCards;
        private System.Windows.Forms.Button fromTop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private MainFrame mainFrame1;
        private System.Windows.Forms.TextBox txtRemoveID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.TextBox txtCon2;
        private System.Windows.Forms.TextBox txtConOne;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectionColour;
        private System.Windows.Forms.TextBox txtFromLoc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtToLoc;
        private System.Windows.Forms.Button button4;
    }
}

