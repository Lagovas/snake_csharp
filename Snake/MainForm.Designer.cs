namespace Snake
{
    partial class MainForm
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
            this.pointsTextLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.snakeLengthTextLabel = new System.Windows.Forms.Label();
            this.snakeLengthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pointsTextLabel
            // 
            this.pointsTextLabel.AutoSize = true;
            this.pointsTextLabel.Location = new System.Drawing.Point(300, 19);
            this.pointsTextLabel.Name = "pointsTextLabel";
            this.pointsTextLabel.Size = new System.Drawing.Size(33, 13);
            this.pointsTextLabel.TabIndex = 0;
            this.pointsTextLabel.Text = "Счет:";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(375, 19);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(13, 13);
            this.pointsLabel.TabIndex = 1;
            this.pointsLabel.Text = "0";
            // 
            // snakeLengthTextLabel
            // 
            this.snakeLengthTextLabel.AutoSize = true;
            this.snakeLengthTextLabel.Location = new System.Drawing.Point(300, 48);
            this.snakeLengthTextLabel.Name = "snakeLengthTextLabel";
            this.snakeLengthTextLabel.Size = new System.Drawing.Size(72, 13);
            this.snakeLengthTextLabel.TabIndex = 2;
            this.snakeLengthTextLabel.Text = "Длина змеи:";
            // 
            // snakeLengthLabel
            // 
            this.snakeLengthLabel.AutoSize = true;
            this.snakeLengthLabel.Location = new System.Drawing.Point(378, 48);
            this.snakeLengthLabel.Name = "snakeLengthLabel";
            this.snakeLengthLabel.Size = new System.Drawing.Size(13, 13);
            this.snakeLengthLabel.TabIndex = 3;
            this.snakeLengthLabel.Text = "3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 277);
            this.Controls.Add(this.snakeLengthLabel);
            this.Controls.Add(this.snakeLengthTextLabel);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.pointsTextLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pointsTextLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label snakeLengthTextLabel;
        private System.Windows.Forms.Label snakeLengthLabel;
    }
}