namespace ImageFactory
{
    partial class GetOpertor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetOpertor));
            this.textBox00 = new System.Windows.Forms.TextBox();
            this.textBox01 = new System.Windows.Forms.TextBox();
            this.textBox02 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox00
            // 
            this.textBox00.Location = new System.Drawing.Point(8, 10);
            this.textBox00.Name = "textBox00";
            this.textBox00.Size = new System.Drawing.Size(35, 21);
            this.textBox00.TabIndex = 0;
            this.textBox00.TextChanged += new System.EventHandler(this.textBox00_TextChanged);
            // 
            // textBox01
            // 
            this.textBox01.Location = new System.Drawing.Point(49, 10);
            this.textBox01.Name = "textBox01";
            this.textBox01.Size = new System.Drawing.Size(35, 21);
            this.textBox01.TabIndex = 1;
            // 
            // textBox02
            // 
            this.textBox02.Location = new System.Drawing.Point(90, 10);
            this.textBox02.Name = "textBox02";
            this.textBox02.Size = new System.Drawing.Size(35, 21);
            this.textBox02.TabIndex = 2;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(8, 37);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(35, 21);
            this.textBox10.TabIndex = 3;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(49, 37);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(35, 21);
            this.textBox11.TabIndex = 4;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(90, 37);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(35, 21);
            this.textBox12.TabIndex = 5;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(8, 64);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(35, 21);
            this.textBox20.TabIndex = 6;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(49, 64);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(35, 21);
            this.textBox21.TabIndex = 7;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(90, 64);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(35, 21);
            this.textBox22.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(132, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(41, 75);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GetOpertor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(181, 96);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox02);
            this.Controls.Add(this.textBox01);
            this.Controls.Add(this.textBox00);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetOpertor";
            this.Opacity = 0.75D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "滤波算子";
            this.Load += new System.EventHandler(this.GetOpertor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox00;
        private System.Windows.Forms.TextBox textBox01;
        private System.Windows.Forms.TextBox textBox02;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Button btnOK;
    }
}