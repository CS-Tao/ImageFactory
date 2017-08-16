namespace ImageFactory
{
    partial class GetTwoPointForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetTwoPointForm));
            this.x1Num = new System.Windows.Forms.NumericUpDown();
            this.y1Num = new System.Windows.Forms.NumericUpDown();
            this.x2Num = new System.Windows.Forms.NumericUpDown();
            this.y2Num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.x1Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y1Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y2Num)).BeginInit();
            this.SuspendLayout();
            // 
            // x1Num
            // 
            this.x1Num.Location = new System.Drawing.Point(55, 14);
            this.x1Num.Name = "x1Num";
            this.x1Num.Size = new System.Drawing.Size(49, 21);
            this.x1Num.TabIndex = 0;
            // 
            // y1Num
            // 
            this.y1Num.Location = new System.Drawing.Point(151, 14);
            this.y1Num.Name = "y1Num";
            this.y1Num.Size = new System.Drawing.Size(49, 21);
            this.y1Num.TabIndex = 1;
            // 
            // x2Num
            // 
            this.x2Num.Location = new System.Drawing.Point(55, 67);
            this.x2Num.Name = "x2Num";
            this.x2Num.Size = new System.Drawing.Size(49, 21);
            this.x2Num.TabIndex = 2;
            // 
            // y2Num
            // 
            this.y2Num.Location = new System.Drawing.Point(151, 67);
            this.y2Num.Name = "y2Num";
            this.y2Num.Size = new System.Drawing.Size(49, 21);
            this.y2Num.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "X1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "X2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y2:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GetTwoPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(239, 142);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.y2Num);
            this.Controls.Add(this.x2Num);
            this.Controls.Add(this.y1Num);
            this.Controls.Add(this.x1Num);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetTwoPointForm";
            this.Opacity = 0.8D;
            this.Text = "选择像素点";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.eformClosing);
            this.Load += new System.EventHandler(this.GetTwoPointForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.x1Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y1Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y2Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown x1Num;
        private System.Windows.Forms.NumericUpDown y1Num;
        private System.Windows.Forms.NumericUpDown x2Num;
        private System.Windows.Forms.NumericUpDown y2Num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}