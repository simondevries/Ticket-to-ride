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
            this.pnlView = new System.Windows.Forms.Panel();
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
            this.pnlView.Size = new System.Drawing.Size(1362, 741);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            // 
            // fromTop
            // 
            this.fromTop.Location = new System.Drawing.Point(541, 585);
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
            this.turn.Location = new System.Drawing.Point(53, 557);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(29, 13);
            this.turn.TabIndex = 9;
            this.turn.Text = "Turn";
            // 
            // playersCards
            // 
            this.playersCards.FormattingEnabled = true;
            this.playersCards.Location = new System.Drawing.Point(631, 585);
            this.playersCards.Name = "playersCards";
            this.playersCards.Size = new System.Drawing.Size(77, 147);
            this.playersCards.TabIndex = 8;
            // 
            // deckSize
            // 
            this.deckSize.AutoSize = true;
            this.deckSize.Location = new System.Drawing.Point(538, 557);
            this.deckSize.Name = "deckSize";
            this.deckSize.Size = new System.Drawing.Size(52, 13);
            this.deckSize.TabIndex = 7;
            this.deckSize.Text = "deck size";
            // 
            // boardCardFive
            // 
            this.boardCardFive.Location = new System.Drawing.Point(460, 585);
            this.boardCardFive.Name = "boardCardFive";
            this.boardCardFive.Size = new System.Drawing.Size(75, 64);
            this.boardCardFive.TabIndex = 6;
            this.boardCardFive.Text = "Next Turn";
            this.boardCardFive.UseVisualStyleBackColor = true;
            // 
            // boardCardFour
            // 
            this.boardCardFour.Location = new System.Drawing.Point(379, 585);
            this.boardCardFour.Name = "boardCardFour";
            this.boardCardFour.Size = new System.Drawing.Size(75, 64);
            this.boardCardFour.TabIndex = 5;
            this.boardCardFour.Text = "Next Turn";
            this.boardCardFour.UseVisualStyleBackColor = true;
            // 
            // boardCardThree
            // 
            this.boardCardThree.Location = new System.Drawing.Point(298, 585);
            this.boardCardThree.Name = "boardCardThree";
            this.boardCardThree.Size = new System.Drawing.Size(75, 64);
            this.boardCardThree.TabIndex = 4;
            this.boardCardThree.Text = "Next Turn";
            this.boardCardThree.UseVisualStyleBackColor = true;
            // 
            // boardCardTwo
            // 
            this.boardCardTwo.Location = new System.Drawing.Point(217, 585);
            this.boardCardTwo.Name = "boardCardTwo";
            this.boardCardTwo.Size = new System.Drawing.Size(75, 64);
            this.boardCardTwo.TabIndex = 3;
            this.boardCardTwo.Text = "Next Turn";
            this.boardCardTwo.UseVisualStyleBackColor = true;
            // 
            // boardCardOne
            // 
            this.boardCardOne.Location = new System.Drawing.Point(131, 585);
            this.boardCardOne.Name = "boardCardOne";
            this.boardCardOne.Size = new System.Drawing.Size(80, 64);
            this.boardCardOne.TabIndex = 2;
            this.boardCardOne.Text = "Next Turn";
            this.boardCardOne.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 590);
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
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.pnlView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
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
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.ListBox playersCards;
        private System.Windows.Forms.Button fromTop;
        private System.Windows.Forms.Button button1;
    }
}

