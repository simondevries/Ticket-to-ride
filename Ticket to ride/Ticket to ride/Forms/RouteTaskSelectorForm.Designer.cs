namespace Ticket_to_ride.Forms
{
    partial class RouteTaskSelectorForm
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
            this.LblRouteOne = new System.Windows.Forms.Label();
            this.LblRouteTwo = new System.Windows.Forms.Label();
            this.LblRouteThree = new System.Windows.Forms.Label();
            this.LblRouteFour = new System.Windows.Forms.Label();
            this.LblRouteOneRequired = new System.Windows.Forms.Label();
            this.BtnRouteOne = new System.Windows.Forms.CheckBox();
            this.BtnRouteTwo = new System.Windows.Forms.CheckBox();
            this.BtnRouteThree = new System.Windows.Forms.CheckBox();
            this.BtnRouteFour = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblRouteOne
            // 
            this.LblRouteOne.AutoSize = true;
            this.LblRouteOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRouteOne.Location = new System.Drawing.Point(12, 9);
            this.LblRouteOne.Name = "LblRouteOne";
            this.LblRouteOne.Size = new System.Drawing.Size(66, 24);
            this.LblRouteOne.TabIndex = 4;
            this.LblRouteOne.Text = "label1";
            // 
            // LblRouteTwo
            // 
            this.LblRouteTwo.AutoSize = true;
            this.LblRouteTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRouteTwo.Location = new System.Drawing.Point(14, 120);
            this.LblRouteTwo.Name = "LblRouteTwo";
            this.LblRouteTwo.Size = new System.Drawing.Size(66, 24);
            this.LblRouteTwo.TabIndex = 5;
            this.LblRouteTwo.Text = "label1";
            // 
            // LblRouteThree
            // 
            this.LblRouteThree.AutoSize = true;
            this.LblRouteThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRouteThree.Location = new System.Drawing.Point(14, 228);
            this.LblRouteThree.Name = "LblRouteThree";
            this.LblRouteThree.Size = new System.Drawing.Size(66, 24);
            this.LblRouteThree.TabIndex = 6;
            this.LblRouteThree.Text = "label2";
            // 
            // LblRouteFour
            // 
            this.LblRouteFour.AutoSize = true;
            this.LblRouteFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRouteFour.Location = new System.Drawing.Point(13, 333);
            this.LblRouteFour.Name = "LblRouteFour";
            this.LblRouteFour.Size = new System.Drawing.Size(66, 24);
            this.LblRouteFour.TabIndex = 7;
            this.LblRouteFour.Text = "label3";
            // 
            // LblRouteOneRequired
            // 
            this.LblRouteOneRequired.AutoSize = true;
            this.LblRouteOneRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRouteOneRequired.ForeColor = System.Drawing.Color.Red;
            this.LblRouteOneRequired.Location = new System.Drawing.Point(15, 49);
            this.LblRouteOneRequired.Name = "LblRouteOneRequired";
            this.LblRouteOneRequired.Size = new System.Drawing.Size(58, 13);
            this.LblRouteOneRequired.TabIndex = 8;
            this.LblRouteOneRequired.Text = "Required";
            // 
            // BtnRouteOne
            // 
            this.BtnRouteOne.AutoSize = true;
            this.BtnRouteOne.Checked = true;
            this.BtnRouteOne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnRouteOne.Location = new System.Drawing.Point(15, 71);
            this.BtnRouteOne.Name = "BtnRouteOne";
            this.BtnRouteOne.Size = new System.Drawing.Size(81, 17);
            this.BtnRouteOne.TabIndex = 9;
            this.BtnRouteOne.Text = "Select Card";
            this.BtnRouteOne.UseVisualStyleBackColor = true;
            this.BtnRouteOne.CheckedChanged += new System.EventHandler(this.BtnRouteOne_CheckedChanged);
            // 
            // BtnRouteTwo
            // 
            this.BtnRouteTwo.AutoSize = true;
            this.BtnRouteTwo.Location = new System.Drawing.Point(17, 182);
            this.BtnRouteTwo.Name = "BtnRouteTwo";
            this.BtnRouteTwo.Size = new System.Drawing.Size(81, 17);
            this.BtnRouteTwo.TabIndex = 10;
            this.BtnRouteTwo.Text = "Select Card";
            this.BtnRouteTwo.UseVisualStyleBackColor = true;
            // 
            // BtnRouteThree
            // 
            this.BtnRouteThree.AutoSize = true;
            this.BtnRouteThree.Location = new System.Drawing.Point(17, 290);
            this.BtnRouteThree.Name = "BtnRouteThree";
            this.BtnRouteThree.Size = new System.Drawing.Size(81, 17);
            this.BtnRouteThree.TabIndex = 11;
            this.BtnRouteThree.Text = "Select Card";
            this.BtnRouteThree.UseVisualStyleBackColor = true;
            // 
            // BtnRouteFour
            // 
            this.BtnRouteFour.AutoSize = true;
            this.BtnRouteFour.Location = new System.Drawing.Point(16, 396);
            this.BtnRouteFour.Name = "BtnRouteFour";
            this.BtnRouteFour.Size = new System.Drawing.Size(81, 17);
            this.BtnRouteFour.TabIndex = 12;
            this.BtnRouteFour.Text = "Select Card";
            this.BtnRouteFour.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(17, 447);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(93, 39);
            this.btnContinue.TabIndex = 13;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // RouteTaskSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 539);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.BtnRouteFour);
            this.Controls.Add(this.BtnRouteThree);
            this.Controls.Add(this.BtnRouteTwo);
            this.Controls.Add(this.BtnRouteOne);
            this.Controls.Add(this.LblRouteOneRequired);
            this.Controls.Add(this.LblRouteFour);
            this.Controls.Add(this.LblRouteThree);
            this.Controls.Add(this.LblRouteTwo);
            this.Controls.Add(this.LblRouteOne);
            this.Name = "RouteTaskSelectorForm";
            this.Text = "RouteTaskSelector";
            this.Load += new System.EventHandler(this.RouteTaskSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblRouteOne;
        private System.Windows.Forms.Label LblRouteTwo;
        private System.Windows.Forms.Label LblRouteThree;
        private System.Windows.Forms.Label LblRouteFour;
        private System.Windows.Forms.Label LblRouteOneRequired;
        private System.Windows.Forms.CheckBox BtnRouteOne;
        private System.Windows.Forms.CheckBox BtnRouteTwo;
        private System.Windows.Forms.CheckBox BtnRouteThree;
        private System.Windows.Forms.CheckBox BtnRouteFour;
        private System.Windows.Forms.Button btnContinue;
    }
}