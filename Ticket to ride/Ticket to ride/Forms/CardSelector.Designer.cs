namespace Ticket_to_ride.Forms
{
    partial class CardSelector
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
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBlack
            // 
            this.btnBlack.Enabled = false;
            this.btnBlack.Location = new System.Drawing.Point(6, 12);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(76, 76);
            this.btnBlack.TabIndex = 2;
            this.btnBlack.Text = "Black";
            this.btnBlack.UseVisualStyleBackColor = true;
            this.btnBlack.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPink
            // 
            this.btnPink.Enabled = false;
            this.btnPink.Location = new System.Drawing.Point(282, 13);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(76, 76);
            this.btnPink.TabIndex = 3;
            this.btnPink.Text = "Pink";
            this.btnPink.UseVisualStyleBackColor = true;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.Enabled = false;
            this.btnOrange.Location = new System.Drawing.Point(98, 12);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(76, 76);
            this.btnOrange.TabIndex = 4;
            this.btnOrange.Text = "Orange";
            this.btnOrange.UseVisualStyleBackColor = true;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.Enabled = false;
            this.btnWhite.Location = new System.Drawing.Point(383, 13);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(76, 76);
            this.btnWhite.TabIndex = 5;
            this.btnWhite.Text = "White";
            this.btnWhite.UseVisualStyleBackColor = true;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // btnRed
            // 
            this.btnRed.Enabled = false;
            this.btnRed.Location = new System.Drawing.Point(190, 12);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(76, 76);
            this.btnRed.TabIndex = 6;
            this.btnRed.Text = "Red";
            this.btnRed.UseVisualStyleBackColor = true;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // CardSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 101);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnWhite);
            this.Controls.Add(this.btnOrange);
            this.Controls.Add(this.btnPink);
            this.Controls.Add(this.btnBlack);
            this.Name = "CardSelector";
            this.Text = "CardSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button btnRed;

    }
}