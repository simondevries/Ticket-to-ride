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
            this.lblScore = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.deckSize = new System.Windows.Forms.Label();
            this.LblTrainsRemaining = new System.Windows.Forms.Label();
            this.BtnPickRouteCard = new System.Windows.Forms.Button();
            this.LstRouteCards = new System.Windows.Forms.ListBox();
            this.fromTop = new System.Windows.Forms.Button();
            this.lblCurrentTurn = new System.Windows.Forms.Label();
            this.playersCards = new System.Windows.Forms.ListBox();
            this.boardCardFive = new System.Windows.Forms.Button();
            this.boardCardFour = new System.Windows.Forms.Button();
            this.boardCardThree = new System.Windows.Forms.Button();
            this.boardCardTwo = new System.Windows.Forms.Button();
            this.boardCardOne = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.txtNumberOfHumans = new System.Windows.Forms.TextBox();
            this.txtNumberOfAi = new System.Windows.Forms.TextBox();
            this.pnlNumberOfPlayers = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.mainFrame1 = new Ticket_to_ride.MainFrame();
            this.pnlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.pnlGame.SuspendLayout();
            this.pnlNumberOfPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlView.BackgroundImage")));
            this.pnlView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlView.Controls.Add(this.lblScore);
            this.pnlView.Location = new System.Drawing.Point(180, 3);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(1041, 720);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(908, 38);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(56, 20);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(3, 690);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(153, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // deckSize
            // 
            this.deckSize.AutoSize = true;
            this.deckSize.Location = new System.Drawing.Point(8, 60);
            this.deckSize.Name = "deckSize";
            this.deckSize.Size = new System.Drawing.Size(52, 13);
            this.deckSize.TabIndex = 7;
            this.deckSize.Text = "deck size";
            // 
            // LblTrainsRemaining
            // 
            this.LblTrainsRemaining.AutoSize = true;
            this.LblTrainsRemaining.Location = new System.Drawing.Point(7, 41);
            this.LblTrainsRemaining.Name = "LblTrainsRemaining";
            this.LblTrainsRemaining.Size = new System.Drawing.Size(89, 13);
            this.LblTrainsRemaining.TabIndex = 12;
            this.LblTrainsRemaining.Text = "Trains Remaining";
            // 
            // BtnPickRouteCard
            // 
            this.BtnPickRouteCard.Location = new System.Drawing.Point(12, 626);
            this.BtnPickRouteCard.Name = "BtnPickRouteCard";
            this.BtnPickRouteCard.Size = new System.Drawing.Size(156, 26);
            this.BtnPickRouteCard.TabIndex = 1;
            this.BtnPickRouteCard.Text = "Pick Route Card";
            this.BtnPickRouteCard.UseVisualStyleBackColor = true;
            this.BtnPickRouteCard.Click += new System.EventHandler(this.BtnPickRouteCard_Click);
            // 
            // LstRouteCards
            // 
            this.LstRouteCards.FormattingEnabled = true;
            this.LstRouteCards.Location = new System.Drawing.Point(12, 525);
            this.LstRouteCards.Name = "LstRouteCards";
            this.LstRouteCards.Size = new System.Drawing.Size(157, 95);
            this.LstRouteCards.TabIndex = 11;
            // 
            // fromTop
            // 
            this.fromTop.Location = new System.Drawing.Point(7, 85);
            this.fromTop.Name = "fromTop";
            this.fromTop.Size = new System.Drawing.Size(156, 36);
            this.fromTop.TabIndex = 10;
            this.fromTop.Text = "From Top";
            this.fromTop.UseVisualStyleBackColor = true;
            this.fromTop.Click += new System.EventHandler(this.fromTop_Click);
            // 
            // lblCurrentTurn
            // 
            this.lblCurrentTurn.AutoSize = true;
            this.lblCurrentTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTurn.Location = new System.Drawing.Point(7, 7);
            this.lblCurrentTurn.Name = "lblCurrentTurn";
            this.lblCurrentTurn.Size = new System.Drawing.Size(56, 25);
            this.lblCurrentTurn.TabIndex = 9;
            this.lblCurrentTurn.Text = "Turn";
            // 
            // playersCards
            // 
            this.playersCards.FormattingEnabled = true;
            this.playersCards.Location = new System.Drawing.Point(7, 346);
            this.playersCards.Name = "playersCards";
            this.playersCards.Size = new System.Drawing.Size(157, 173);
            this.playersCards.TabIndex = 8;
            // 
            // boardCardFive
            // 
            this.boardCardFive.Location = new System.Drawing.Point(7, 267);
            this.boardCardFive.Name = "boardCardFive";
            this.boardCardFive.Size = new System.Drawing.Size(75, 64);
            this.boardCardFive.TabIndex = 6;
            this.boardCardFive.Text = "CardFive";
            this.boardCardFive.UseVisualStyleBackColor = true;
            this.boardCardFive.Click += new System.EventHandler(this.boardCardFive_Click);
            // 
            // boardCardFour
            // 
            this.boardCardFour.Location = new System.Drawing.Point(88, 197);
            this.boardCardFour.Name = "boardCardFour";
            this.boardCardFour.Size = new System.Drawing.Size(75, 64);
            this.boardCardFour.TabIndex = 5;
            this.boardCardFour.Text = "CardFour";
            this.boardCardFour.UseVisualStyleBackColor = true;
            this.boardCardFour.Click += new System.EventHandler(this.boardCardFour_Click);
            // 
            // boardCardThree
            // 
            this.boardCardThree.Location = new System.Drawing.Point(6, 197);
            this.boardCardThree.Name = "boardCardThree";
            this.boardCardThree.Size = new System.Drawing.Size(75, 64);
            this.boardCardThree.TabIndex = 4;
            this.boardCardThree.Text = "CardThree";
            this.boardCardThree.UseVisualStyleBackColor = true;
            this.boardCardThree.Click += new System.EventHandler(this.boardCardThree_Click);
            // 
            // boardCardTwo
            // 
            this.boardCardTwo.Location = new System.Drawing.Point(88, 127);
            this.boardCardTwo.Name = "boardCardTwo";
            this.boardCardTwo.Size = new System.Drawing.Size(75, 64);
            this.boardCardTwo.TabIndex = 3;
            this.boardCardTwo.Text = "CardTwo";
            this.boardCardTwo.UseVisualStyleBackColor = true;
            this.boardCardTwo.Click += new System.EventHandler(this.boardCardTwo_Click);
            // 
            // boardCardOne
            // 
            this.boardCardOne.Location = new System.Drawing.Point(7, 127);
            this.boardCardOne.Name = "boardCardOne";
            this.boardCardOne.Size = new System.Drawing.Size(75, 64);
            this.boardCardOne.TabIndex = 2;
            this.boardCardOne.Text = "CardOne";
            this.boardCardOne.UseVisualStyleBackColor = true;
            this.boardCardOne.Click += new System.EventHandler(this.boardCardOne_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 658);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next Turn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlGame
            // 
            this.pnlGame.Controls.Add(this.trackBar1);
            this.pnlGame.Controls.Add(this.LblTrainsRemaining);
            this.pnlGame.Controls.Add(this.lblCurrentTurn);
            this.pnlGame.Controls.Add(this.BtnPickRouteCard);
            this.pnlGame.Controls.Add(this.deckSize);
            this.pnlGame.Controls.Add(this.button1);
            this.pnlGame.Controls.Add(this.playersCards);
            this.pnlGame.Controls.Add(this.LstRouteCards);
            this.pnlGame.Controls.Add(this.boardCardFive);
            this.pnlGame.Controls.Add(this.boardCardFour);
            this.pnlGame.Controls.Add(this.pnlView);
            this.pnlGame.Controls.Add(this.boardCardThree);
            this.pnlGame.Controls.Add(this.boardCardTwo);
            this.pnlGame.Controls.Add(this.boardCardOne);
            this.pnlGame.Controls.Add(this.fromTop);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Enabled = false;
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(1244, 739);
            this.pnlGame.TabIndex = 9;
            // 
            // txtNumberOfHumans
            // 
            this.txtNumberOfHumans.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfHumans.Location = new System.Drawing.Point(79, 6);
            this.txtNumberOfHumans.Name = "txtNumberOfHumans";
            this.txtNumberOfHumans.Size = new System.Drawing.Size(268, 29);
            this.txtNumberOfHumans.TabIndex = 9;
            this.txtNumberOfHumans.Text = "NumberOfHumans";
            this.txtNumberOfHumans.TextChanged += new System.EventHandler(this.txtNumberOfHumans_TextChanged);
            // 
            // txtNumberOfAi
            // 
            this.txtNumberOfAi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfAi.Location = new System.Drawing.Point(79, 42);
            this.txtNumberOfAi.Name = "txtNumberOfAi";
            this.txtNumberOfAi.Size = new System.Drawing.Size(268, 29);
            this.txtNumberOfAi.TabIndex = 10;
            this.txtNumberOfAi.Text = "Number Of Ai";
            this.txtNumberOfAi.TextChanged += new System.EventHandler(this.txtNumberOfAi_TextChanged);
            // 
            // pnlNumberOfPlayers
            // 
            this.pnlNumberOfPlayers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlNumberOfPlayers.Controls.Add(this.button2);
            this.pnlNumberOfPlayers.Controls.Add(this.txtNumberOfHumans);
            this.pnlNumberOfPlayers.Controls.Add(this.txtNumberOfAi);
            this.pnlNumberOfPlayers.Location = new System.Drawing.Point(475, 9);
            this.pnlNumberOfPlayers.Name = "pnlNumberOfPlayers";
            this.pnlNumberOfPlayers.Size = new System.Drawing.Size(528, 87);
            this.pnlNumberOfPlayers.TabIndex = 11;
            this.pnlNumberOfPlayers.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNumberOfPlayers_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 66);
            this.button2.TabIndex = 11;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(12, 1);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(22, 10);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.mainFrame1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 739);
            this.Controls.Add(this.pnlNumberOfPlayers);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.pnlGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.pnlNumberOfPlayers.ResumeLayout(false);
            this.pnlNumberOfPlayers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private MainFrame mainFrame1;
        private System.Windows.Forms.Label deckSize;
        private System.Windows.Forms.Button boardCardFive;
        private System.Windows.Forms.Button boardCardFour;
        private System.Windows.Forms.Button boardCardThree;
        private System.Windows.Forms.Button boardCardTwo;
        private System.Windows.Forms.Button boardCardOne;
        private System.Windows.Forms.Label lblCurrentTurn;
        private System.Windows.Forms.ListBox playersCards;
        private System.Windows.Forms.Button fromTop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox LstRouteCards;
        private System.Windows.Forms.Button BtnPickRouteCard;
        private System.Windows.Forms.Label LblTrainsRemaining;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Panel pnlNumberOfPlayers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNumberOfHumans;
        private System.Windows.Forms.TextBox txtNumberOfAi;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

