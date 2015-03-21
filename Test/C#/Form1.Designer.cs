namespace HaarCascadeClassifierTEST
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.nudSlidingRatio = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.nudSizeMultForNesRectCon = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.nudScaleMult = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.nudMaxSize = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.nudMinSize = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.nudMinNRectCount = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlidingRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeMultForNesRectCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinNRectCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.ForeColor = System.Drawing.Color.Green;
            this.lblInfo.Location = new System.Drawing.Point(9, 256);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(543, 19);
            this.lblInfo.TabIndex = 35;
            // 
            // btnDetect
            // 
            this.btnDetect.Enabled = false;
            this.btnDetect.Location = new System.Drawing.Point(480, 216);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(75, 23);
            this.btnDetect.TabIndex = 34;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(338, 168);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(163, 20);
            this.Label7.TabIndex = 33;
            this.Label7.Text = "Rectangle line width:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.Location = new System.Drawing.Point(507, 168);
            this.nudLineWidth.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.Size = new System.Drawing.Size(45, 20);
            this.nudLineWidth.TabIndex = 32;
            this.nudLineWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(338, 142);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(163, 20);
            this.Label6.TabIndex = 31;
            this.Label6.Text = "Sliding Ratio:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudSlidingRatio
            // 
            this.nudSlidingRatio.DecimalPlaces = 1;
            this.nudSlidingRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSlidingRatio.Location = new System.Drawing.Point(507, 142);
            this.nudSlidingRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSlidingRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSlidingRatio.Name = "nudSlidingRatio";
            this.nudSlidingRatio.Size = new System.Drawing.Size(45, 20);
            this.nudSlidingRatio.TabIndex = 30;
            this.nudSlidingRatio.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(338, 116);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(163, 20);
            this.Label5.TabIndex = 29;
            this.Label5.Text = "Nested rectangle size multiplier:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudSizeMultForNesRectCon
            // 
            this.nudSizeMultForNesRectCon.DecimalPlaces = 2;
            this.nudSizeMultForNesRectCon.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudSizeMultForNesRectCon.Location = new System.Drawing.Point(507, 116);
            this.nudSizeMultForNesRectCon.Name = "nudSizeMultForNesRectCon";
            this.nudSizeMultForNesRectCon.Size = new System.Drawing.Size(45, 20);
            this.nudSizeMultForNesRectCon.TabIndex = 28;
            this.nudSizeMultForNesRectCon.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(338, 90);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(163, 20);
            this.Label4.TabIndex = 27;
            this.Label4.Text = "Scale multiplier:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudScaleMult
            // 
            this.nudScaleMult.DecimalPlaces = 2;
            this.nudScaleMult.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudScaleMult.Location = new System.Drawing.Point(507, 90);
            this.nudScaleMult.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudScaleMult.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleMult.Name = "nudScaleMult";
            this.nudScaleMult.Size = new System.Drawing.Size(45, 20);
            this.nudScaleMult.TabIndex = 26;
            this.nudScaleMult.Value = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(338, 64);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(163, 20);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "Max size of searched object:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMaxSize
            // 
            this.nudMaxSize.Location = new System.Drawing.Point(507, 64);
            this.nudMaxSize.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.nudMaxSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxSize.Name = "nudMaxSize";
            this.nudMaxSize.Size = new System.Drawing.Size(45, 20);
            this.nudMaxSize.TabIndex = 24;
            this.nudMaxSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(338, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(163, 20);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "Min size of searched object:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMinSize
            // 
            this.nudMinSize.Location = new System.Drawing.Point(507, 38);
            this.nudMinSize.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.nudMinSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinSize.Name = "nudMinSize";
            this.nudMinSize.Size = new System.Drawing.Size(45, 20);
            this.nudMinSize.TabIndex = 22;
            this.nudMinSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(338, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(163, 20);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "Min neighbour rectangle count:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMinNRectCount
            // 
            this.nudMinNRectCount.Location = new System.Drawing.Point(507, 12);
            this.nudMinNRectCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinNRectCount.Name = "nudMinNRectCount";
            this.nudMinNRectCount.Size = new System.Drawing.Size(45, 20);
            this.nudMinNRectCount.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(399, 216);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 279);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.nudLineWidth);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.nudSlidingRatio);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.nudSizeMultForNesRectCon);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.nudScaleMult);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.nudMaxSize);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.nudMinSize);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.nudMinNRectCount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HaarCascadeClassifier.dll Test (C#)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlidingRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeMultForNesRectCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinNRectCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblInfo;
        internal System.Windows.Forms.Button btnDetect;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.NumericUpDown nudLineWidth;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.NumericUpDown nudSlidingRatio;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown nudSizeMultForNesRectCon;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown nudScaleMult;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.NumericUpDown nudMaxSize;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.NumericUpDown nudMinSize;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.NumericUpDown nudMinNRectCount;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Button btnBrowse;
    }
}

