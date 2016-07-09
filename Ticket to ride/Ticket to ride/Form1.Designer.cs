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
            this.LblTrainsRemaining = new System.Windows.Forms.Label();
            this.BtnPickRouteCard = new System.Windows.Forms.Button();
            this.LstRouteCards = new System.Windows.Forms.ListBox();
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
            this.pnlView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlView.Controls.Add(this.deckSize);
            this.pnlView.Location = new System.Drawing.Point(191, 12);
            this.pnlView.Name = "pnlView";
            this.pnlView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlView.Size = new System.Drawing.Size(1041, 720);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            // 
            // LblTrainsRemaining
            // 
            this.LblTrainsRemaining.AutoSize = true;
            this.LblTrainsRemaining.Location = new System.Drawing.Point(18, 9);
            this.LblTrainsRemaining.Name = "LblTrainsRemaining";
            this.LblTrainsRemaining.Size = new System.Drawing.Size(89, 13);
            this.LblTrainsRemaining.TabIndex = 12;
            this.LblTrainsRemaining.Text = "Trains Remaining";
            // 
            // BtnPickRouteCard
            // 
            this.BtnPickRouteCard.Location = new System.Drawing.Point(18, 607);
            this.BtnPickRouteCard.Name = "BtnPickRouteCard";
            this.BtnPickRouteCard.Size = new System.Drawing.Size(156, 53);
            this.BtnPickRouteCard.TabIndex = 1;
            this.BtnPickRouteCard.Text = "Pick Route Card";
            this.BtnPickRouteCard.UseVisualStyleBackColor = true;
            this.BtnPickRouteCard.Click += new System.EventHandler(this.BtnPickRouteCard_Click);
            // 
            // LstRouteCards
            // 
            this.LstRouteCards.FormattingEnabled = true;
            this.LstRouteCards.Location = new System.Drawing.Point(17, 463);
            this.LstRouteCards.Name = "LstRouteCards";
            this.LstRouteCards.Size = new System.Drawing.Size(157, 134);
            this.LstRouteCards.TabIndex = 11;
            // 
            // fromTop
            // 
            this.fromTop.Location = new System.Drawing.Point(18, 32);
            this.fromTop.Name = "fromTop";
            this.fromTop.Size = new System.Drawing.Size(156, 36);
            this.fromTop.TabIndex = 10;
            this.fromTop.Text = "From Top";
            this.fromTop.UseVisualStyleBackColor = true;
            this.fromTop.Click += new System.EventHandler(this.fromTop_Click);
            // 
            // turn
            // 
            this.turn.AutoSize = true;
            this.turn.Location = new System.Drawing.Point(99, 240);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(29, 13);
            this.turn.TabIndex = 9;
            this.turn.Text = "Turn";
            // 
            // playersCards
            // 
            this.playersCards.FormattingEnabled = true;
            this.playersCards.Location = new System.Drawing.Point(17, 284);
            this.playersCards.Name = "playersCards";
            this.playersCards.Size = new System.Drawing.Size(157, 173);
            this.playersCards.TabIndex = 8;
            // 
            // deckSize
            // 
            this.deckSize.AutoSize = true;
            this.deckSize.Location = new System.Drawing.Point(524, 86);
            this.deckSize.Name = "deckSize";
            this.deckSize.Size = new System.Drawing.Size(52, 13);
            this.deckSize.TabIndex = 7;
            this.deckSize.Text = "deck size";
            // 
            // boardCardFive
            // 
            this.boardCardFive.Location = new System.Drawing.Point(18, 214);
            this.boardCardFive.Name = "boardCardFive";
            this.boardCardFive.Size = new System.Drawing.Size(75, 64);
            this.boardCardFive.TabIndex = 6;
            this.boardCardFive.Text = "CardFive";
            this.boardCardFive.UseVisualStyleBackColor = true;
            this.boardCardFive.Click += new System.EventHandler(this.boardCardFive_Click);
            // 
            // boardCardFour
            // 
            this.boardCardFour.Location = new System.Drawing.Point(99, 144);
            this.boardCardFour.Name = "boardCardFour";
            this.boardCardFour.Size = new System.Drawing.Size(75, 64);
            this.boardCardFour.TabIndex = 5;
            this.boardCardFour.Text = "CardFour";
            this.boardCardFour.UseVisualStyleBackColor = true;
            this.boardCardFour.Click += new System.EventHandler(this.boardCardFour_Click);
            // 
            // boardCardThree
            // 
            this.boardCardThree.Location = new System.Drawing.Point(17, 144);
            this.boardCardThree.Name = "boardCardThree";
            this.boardCardThree.Size = new System.Drawing.Size(75, 64);
            this.boardCardThree.TabIndex = 4;
            this.boardCardThree.Text = "CardThree";
            this.boardCardThree.UseVisualStyleBackColor = true;
            this.boardCardThree.Click += new System.EventHandler(this.boardCardThree_Click);
            // 
            // boardCardTwo
            // 
            this.boardCardTwo.Location = new System.Drawing.Point(99, 74);
            this.boardCardTwo.Name = "boardCardTwo";
            this.boardCardTwo.Size = new System.Drawing.Size(75, 64);
            this.boardCardTwo.TabIndex = 3;
            this.boardCardTwo.Text = "CardTwo";
            this.boardCardTwo.UseVisualStyleBackColor = true;
            this.boardCardTwo.Click += new System.EventHandler(this.boardCardTwo_Click);
            // 
            // boardCardOne
            // 
            this.boardCardOne.Location = new System.Drawing.Point(18, 74);
            this.boardCardOne.Name = "boardCardOne";
            this.boardCardOne.Size = new System.Drawing.Size(75, 64);
            this.boardCardOne.TabIndex = 2;
            this.boardCardOne.Text = "CardOne";
            this.boardCardOne.UseVisualStyleBackColor = true;
            this.boardCardOne.Click += new System.EventHandler(this.boardCardOne_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 677);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next Turn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.Controls.Add(this.turn);
            this.Controls.Add(this.BtnPickRouteCard);
            this.Controls.Add(this.LblTrainsRemaining);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LstRouteCards);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.fromTop);
            this.Controls.Add(this.playersCards);
            this.Controls.Add(this.boardCardOne);
            this.Controls.Add(this.boardCardTwo);
            this.Controls.Add(this.boardCardThree);
            this.Controls.Add(this.boardCardFour);
            this.Controls.Add(this.boardCardFive);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Form1";
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.ListBox playersCards;
        private System.Windows.Forms.Button fromTop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox LstRouteCards;
        private System.Windows.Forms.Button BtnPickRouteCard;
        private System.Windows.Forms.Label LblTrainsRemaining;
    }
}

