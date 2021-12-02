namespace Helper
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
            this.stiGroupBox1 = new Stimulsoft.Controls.StiGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdbaddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.integrated = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtun = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btnSave = new Stimulsoft.Controls.Win.DotNetBar.ButtonX();
            this.stiGroupBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stiGroupBox1
            // 
            this.stiGroupBox1.Controls.Add(this.groupBox1);
            this.stiGroupBox1.Controls.Add(this.integrated);
            this.stiGroupBox1.Controls.Add(this.label2);
            this.stiGroupBox1.Controls.Add(this.txtdbaddr);
            this.stiGroupBox1.Controls.Add(this.label1);
            this.stiGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.stiGroupBox1.Name = "stiGroupBox1";
            this.stiGroupBox1.ResHeight = 0;
            this.stiGroupBox1.Size = new System.Drawing.Size(560, 349);
            this.stiGroupBox1.TabIndex = 0;
            this.stiGroupBox1.TabStop = false;
            this.stiGroupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database : ";
            // 
            // txtdbaddr
            // 
            this.txtdbaddr.Location = new System.Drawing.Point(126, 51);
            this.txtdbaddr.Name = "txtdbaddr";
            this.txtdbaddr.Size = new System.Drawing.Size(387, 20);
            this.txtdbaddr.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Integrated Security  :";
            // 
            // integrated
            // 
            this.integrated.AutoSize = true;
            this.integrated.Location = new System.Drawing.Point(199, 137);
            this.integrated.Name = "integrated";
            this.integrated.Size = new System.Drawing.Size(48, 17);
            this.integrated.TabIndex = 3;
            this.integrated.Text = "True";
            this.integrated.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpass);
            this.groupBox1.Controls.Add(this.txtun);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(22, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 130);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "User Name  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password : ";
            // 
            // txtun
            // 
            this.txtun.Location = new System.Drawing.Point(127, 32);
            this.txtun.Name = "txtun";
            this.txtun.Size = new System.Drawing.Size(195, 20);
            this.txtun.TabIndex = 7;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(127, 81);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = 'x';
            this.txtpass.Size = new System.Drawing.Size(195, 20);
            this.txtpass.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Is20Button = false;
            this.btnSave.Location = new System.Drawing.Point(12, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(560, 23);
            this.btnSave.Style = Stimulsoft.Controls.Win.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.stiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.stiGroupBox1.ResumeLayout(false);
            this.stiGroupBox1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Controls.StiGroupBox stiGroupBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox integrated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdbaddr;
        private System.Windows.Forms.Label label1;
        private Stimulsoft.Controls.Win.DotNetBar.ButtonX btnSave;
    }
}

