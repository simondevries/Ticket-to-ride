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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.Location = new System.Drawing.Point(3, 38);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(1455, 801);
            this.pnlView.TabIndex = 0;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            this.pnlView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlView_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next Turn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 842);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Button button1;
    }
}

