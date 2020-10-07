namespace WhiteBalance
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
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.GreyButton = new System.Windows.Forms.Button();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.IterativeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpenPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(25, 25);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(80, 25);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open file";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(111, 25);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 25);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save file";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // OpenPicture
            // 
            this.OpenPicture.Location = new System.Drawing.Point(98, 115);
            this.OpenPicture.Name = "OpenPicture";
            this.OpenPicture.Size = new System.Drawing.Size(520, 435);
            this.OpenPicture.TabIndex = 2;
            this.OpenPicture.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(643, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(520, 435);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // GreyButton
            // 
            this.GreyButton.Location = new System.Drawing.Point(12, 56);
            this.GreyButton.Name = "GreyButton";
            this.GreyButton.Size = new System.Drawing.Size(80, 25);
            this.GreyButton.TabIndex = 4;
            this.GreyButton.Text = "Grey";
            this.GreyButton.UseVisualStyleBackColor = true;
            // 
            // WhiteButton
            // 
            this.WhiteButton.Location = new System.Drawing.Point(98, 56);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(80, 25);
            this.WhiteButton.TabIndex = 5;
            this.WhiteButton.Text = "White";
            this.WhiteButton.UseVisualStyleBackColor = true;
            // 
            // IterativeButton
            // 
            this.IterativeButton.Location = new System.Drawing.Point(184, 56);
            this.IterativeButton.Name = "IterativeButton";
            this.IterativeButton.Size = new System.Drawing.Size(80, 25);
            this.IterativeButton.TabIndex = 6;
            this.IterativeButton.Text = "Iterative";
            this.IterativeButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1199, 561);
            this.Controls.Add(this.IterativeButton);
            this.Controls.Add(this.WhiteButton);
            this.Controls.Add(this.GreyButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.OpenPicture);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OpenPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.PictureBox OpenPicture;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button GreyButton;
        private System.Windows.Forms.Button WhiteButton;
        private System.Windows.Forms.Button IterativeButton;
    }
}

