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
            this.ModifiedPicture = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GreyButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GreenScaleSpinBox = new System.Windows.Forms.NumericUpDown();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DownscaleInput = new System.Windows.Forms.NumericUpDown();
            this.TresholdInput = new System.Windows.Forms.NumericUpDown();
            this.IterativeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpenPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPicture)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenScaleSpinBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownscaleInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TresholdInput)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(12, 12);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(80, 25);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open file";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(98, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 25);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save file";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenPicture
            // 
            this.OpenPicture.Location = new System.Drawing.Point(60, 259);
            this.OpenPicture.Name = "OpenPicture";
            this.OpenPicture.Size = new System.Drawing.Size(520, 435);
            this.OpenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OpenPicture.TabIndex = 2;
            this.OpenPicture.TabStop = false;
            // 
            // ModifiedPicture
            // 
            this.ModifiedPicture.Location = new System.Drawing.Point(586, 259);
            this.ModifiedPicture.Name = "ModifiedPicture";
            this.ModifiedPicture.Size = new System.Drawing.Size(520, 435);
            this.ModifiedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ModifiedPicture.TabIndex = 3;
            this.ModifiedPicture.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(184, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 122);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GreyButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(410, 93);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grey World";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GreyButton
            // 
            this.GreyButton.Location = new System.Drawing.Point(324, 6);
            this.GreyButton.Name = "GreyButton";
            this.GreyButton.Size = new System.Drawing.Size(80, 25);
            this.GreyButton.TabIndex = 4;
            this.GreyButton.Text = "Grey";
            this.GreyButton.UseVisualStyleBackColor = true;
            this.GreyButton.Click += new System.EventHandler(this.GreyButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GreenScaleSpinBox);
            this.tabPage2.Controls.Add(this.WhiteButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(410, 93);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "White Patch";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GreenScaleSpinBox
            // 
            this.GreenScaleSpinBox.DecimalPlaces = 2;
            this.GreenScaleSpinBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.GreenScaleSpinBox.Location = new System.Drawing.Point(167, 8);
            this.GreenScaleSpinBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenScaleSpinBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GreenScaleSpinBox.Name = "GreenScaleSpinBox";
            this.GreenScaleSpinBox.Size = new System.Drawing.Size(120, 22);
            this.GreenScaleSpinBox.TabIndex = 9;
            this.GreenScaleSpinBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WhiteButton
            // 
            this.WhiteButton.Location = new System.Drawing.Point(324, 6);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(80, 25);
            this.WhiteButton.TabIndex = 8;
            this.WhiteButton.Text = "White";
            this.WhiteButton.UseVisualStyleBackColor = true;
            this.WhiteButton.Click += new System.EventHandler(this.WhiteButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.DownscaleInput);
            this.tabPage3.Controls.Add(this.TresholdInput);
            this.tabPage3.Controls.Add(this.IterativeButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(410, 93);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Iterative WB";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "downscale";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "gray point treshold";
            // 
            // DownscaleInput
            // 
            this.DownscaleInput.DecimalPlaces = 2;
            this.DownscaleInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DownscaleInput.Location = new System.Drawing.Point(135, 36);
            this.DownscaleInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DownscaleInput.Name = "DownscaleInput";
            this.DownscaleInput.Size = new System.Drawing.Size(63, 22);
            this.DownscaleInput.TabIndex = 10;
            // 
            // TresholdInput
            // 
            this.TresholdInput.DecimalPlaces = 2;
            this.TresholdInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TresholdInput.Location = new System.Drawing.Point(135, 8);
            this.TresholdInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TresholdInput.Name = "TresholdInput";
            this.TresholdInput.Size = new System.Drawing.Size(63, 22);
            this.TresholdInput.TabIndex = 9;
            // 
            // IterativeButton
            // 
            this.IterativeButton.Location = new System.Drawing.Point(324, 6);
            this.IterativeButton.Name = "IterativeButton";
            this.IterativeButton.Size = new System.Drawing.Size(80, 25);
            this.IterativeButton.TabIndex = 8;
            this.IterativeButton.Text = "Iterative";
            this.IterativeButton.UseVisualStyleBackColor = true;
            this.IterativeButton.Click += new System.EventHandler(this.IterativeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1183, 706);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ModifiedPicture);
            this.Controls.Add(this.OpenPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OpenPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPicture)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GreenScaleSpinBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownscaleInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TresholdInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.PictureBox OpenPicture;
        private System.Windows.Forms.PictureBox ModifiedPicture;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button GreyButton;
        private System.Windows.Forms.Button WhiteButton;
        private System.Windows.Forms.Button IterativeButton;
        private System.Windows.Forms.NumericUpDown GreenScaleSpinBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DownscaleInput;
        private System.Windows.Forms.NumericUpDown TresholdInput;
    }
}

