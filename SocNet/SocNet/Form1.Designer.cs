namespace SocNet
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBroj = new System.Windows.Forms.TextBox();
            this.btnBroj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrvi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDrugi = new System.Windows.Forms.TextBox();
            this.btnKontakt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOsoba = new System.Windows.Forms.TextBox();
            this.btnPrikaz = new System.Windows.Forms.Button();
            this.lblPrikaz = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj Osoba";
            // 
            // txtBroj
            // 
            this.txtBroj.Location = new System.Drawing.Point(43, 53);
            this.txtBroj.Name = "txtBroj";
            this.txtBroj.Size = new System.Drawing.Size(100, 20);
            this.txtBroj.TabIndex = 1;
            // 
            // btnBroj
            // 
            this.btnBroj.Location = new System.Drawing.Point(175, 49);
            this.btnBroj.Name = "btnBroj";
            this.btnBroj.Size = new System.Drawing.Size(75, 23);
            this.btnBroj.TabIndex = 2;
            this.btnBroj.Text = "Unesi broj";
            this.btnBroj.UseVisualStyleBackColor = true;
            this.btnBroj.Click += new System.EventHandler(this.btnBroj_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prvi";
            // 
            // txtPrvi
            // 
            this.txtPrvi.Location = new System.Drawing.Point(52, 136);
            this.txtPrvi.Name = "txtPrvi";
            this.txtPrvi.Size = new System.Drawing.Size(100, 20);
            this.txtPrvi.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Drugi";
            // 
            // txtDrugi
            // 
            this.txtDrugi.Location = new System.Drawing.Point(184, 136);
            this.txtDrugi.Name = "txtDrugi";
            this.txtDrugi.Size = new System.Drawing.Size(100, 20);
            this.txtDrugi.TabIndex = 6;
            // 
            // btnKontakt
            // 
            this.btnKontakt.Location = new System.Drawing.Point(318, 136);
            this.btnKontakt.Name = "btnKontakt";
            this.btnKontakt.Size = new System.Drawing.Size(100, 23);
            this.btnKontakt.TabIndex = 7;
            this.btnKontakt.Text = "Napravi kontakt";
            this.btnKontakt.UseVisualStyleBackColor = true;
            this.btnKontakt.Click += new System.EventHandler(this.btnKontakt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Osoba";
            // 
            // txtOsoba
            // 
            this.txtOsoba.Location = new System.Drawing.Point(52, 214);
            this.txtOsoba.Name = "txtOsoba";
            this.txtOsoba.Size = new System.Drawing.Size(100, 20);
            this.txtOsoba.TabIndex = 9;
            // 
            // btnPrikaz
            // 
            this.btnPrikaz.Location = new System.Drawing.Point(184, 214);
            this.btnPrikaz.Name = "btnPrikaz";
            this.btnPrikaz.Size = new System.Drawing.Size(75, 23);
            this.btnPrikaz.TabIndex = 10;
            this.btnPrikaz.Text = "Prikaz";
            this.btnPrikaz.UseVisualStyleBackColor = true;
            this.btnPrikaz.Click += new System.EventHandler(this.btnPrikaz_Click);
            // 
            // lblPrikaz
            // 
            this.lblPrikaz.AutoSize = true;
            this.lblPrikaz.Location = new System.Drawing.Point(52, 274);
            this.lblPrikaz.Name = "lblPrikaz";
            this.lblPrikaz.Size = new System.Drawing.Size(35, 13);
            this.lblPrikaz.TabIndex = 11;
            this.lblPrikaz.Text = "label5";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(430, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 328);
            this.Controls.Add(this.lblPrikaz);
            this.Controls.Add(this.btnPrikaz);
            this.Controls.Add(this.txtOsoba);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnKontakt);
            this.Controls.Add(this.txtDrugi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrvi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBroj);
            this.Controls.Add(this.txtBroj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBroj;
        private System.Windows.Forms.Button btnBroj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrvi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDrugi;
        private System.Windows.Forms.Button btnKontakt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOsoba;
        private System.Windows.Forms.Button btnPrikaz;
        private System.Windows.Forms.Label lblPrikaz;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

