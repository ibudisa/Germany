namespace Riz
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
            this.btnAerodromi = new System.Windows.Forms.Button();
            this.lstAerodromi = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstLinije = new System.Windows.Forms.ListBox();
            this.Linije = new System.Windows.Forms.GroupBox();
            this.rbtnKraci = new System.Windows.Forms.RadioButton();
            this.rbtnPrikazi = new System.Windows.Forms.RadioButton();
            this.rbtnObrisi = new System.Windows.Forms.RadioButton();
            this.rbtnDodaj = new System.Windows.Forms.RadioButton();
            this.btnLinije = new System.Windows.Forms.Button();
            this.txtOd = new System.Windows.Forms.TextBox();
            this.txtDo = new System.Windows.Forms.TextBox();
            this.lstLetovi = new System.Windows.Forms.ListBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.Linije.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAerodromi
            // 
            this.btnAerodromi.Location = new System.Drawing.Point(183, 37);
            this.btnAerodromi.Name = "btnAerodromi";
            this.btnAerodromi.Size = new System.Drawing.Size(75, 23);
            this.btnAerodromi.TabIndex = 0;
            this.btnAerodromi.Text = "Aerodromi";
            this.btnAerodromi.UseVisualStyleBackColor = true;
            this.btnAerodromi.Click += new System.EventHandler(this.btnAerodromi_Click);
            // 
            // lstAerodromi
            // 
            this.lstAerodromi.FormattingEnabled = true;
            this.lstAerodromi.Location = new System.Drawing.Point(302, 37);
            this.lstAerodromi.Name = "lstAerodromi";
            this.lstAerodromi.Size = new System.Drawing.Size(120, 95);
            this.lstAerodromi.TabIndex = 1;
            this.lstAerodromi.SelectedIndexChanged += new System.EventHandler(this.lstAerodromi_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);
            this.menuStrip1.TabIndex = 2;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lstLinije
            // 
            this.lstLinije.FormattingEnabled = true;
            this.lstLinije.Location = new System.Drawing.Point(497, 37);
            this.lstLinije.Name = "lstLinije";
            this.lstLinije.Size = new System.Drawing.Size(159, 95);
            this.lstLinije.TabIndex = 3;
            // 
            // Linije
            // 
            this.Linije.Controls.Add(this.rbtnKraci);
            this.Linije.Controls.Add(this.rbtnPrikazi);
            this.Linije.Controls.Add(this.rbtnObrisi);
            this.Linije.Controls.Add(this.rbtnDodaj);
            this.Linije.Location = new System.Drawing.Point(28, 151);
            this.Linije.Name = "Linije";
            this.Linije.Size = new System.Drawing.Size(169, 126);
            this.Linije.TabIndex = 4;
            this.Linije.TabStop = false;
            this.Linije.Text = "Linije";
            // 
            // rbtnKraci
            // 
            this.rbtnKraci.AutoSize = true;
            this.rbtnKraci.Location = new System.Drawing.Point(7, 91);
            this.rbtnKraci.Name = "rbtnKraci";
            this.rbtnKraci.Size = new System.Drawing.Size(68, 17);
            this.rbtnKraci.TabIndex = 3;
            this.rbtnKraci.TabStop = true;
            this.rbtnKraci.Text = "Manji put";
            this.rbtnKraci.UseVisualStyleBackColor = true;
            // 
            // rbtnPrikazi
            // 
            this.rbtnPrikazi.AutoSize = true;
            this.rbtnPrikazi.Location = new System.Drawing.Point(7, 67);
            this.rbtnPrikazi.Name = "rbtnPrikazi";
            this.rbtnPrikazi.Size = new System.Drawing.Size(79, 17);
            this.rbtnPrikazi.TabIndex = 2;
            this.rbtnPrikazi.TabStop = true;
            this.rbtnPrikazi.Text = "Prikaži liniju";
            this.rbtnPrikazi.UseVisualStyleBackColor = true;
            // 
            // rbtnObrisi
            // 
            this.rbtnObrisi.AutoSize = true;
            this.rbtnObrisi.Location = new System.Drawing.Point(7, 44);
            this.rbtnObrisi.Name = "rbtnObrisi";
            this.rbtnObrisi.Size = new System.Drawing.Size(74, 17);
            this.rbtnObrisi.TabIndex = 1;
            this.rbtnObrisi.TabStop = true;
            this.rbtnObrisi.Text = "Obriši liniju";
            this.rbtnObrisi.UseVisualStyleBackColor = true;
            // 
            // rbtnDodaj
            // 
            this.rbtnDodaj.AutoSize = true;
            this.rbtnDodaj.Location = new System.Drawing.Point(7, 20);
            this.rbtnDodaj.Name = "rbtnDodaj";
            this.rbtnDodaj.Size = new System.Drawing.Size(77, 17);
            this.rbtnDodaj.TabIndex = 0;
            this.rbtnDodaj.TabStop = true;
            this.rbtnDodaj.Text = "DodajLiniju";
            this.rbtnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnLinije
            // 
            this.btnLinije.Location = new System.Drawing.Point(481, 192);
            this.btnLinije.Name = "btnLinije";
            this.btnLinije.Size = new System.Drawing.Size(75, 23);
            this.btnLinije.TabIndex = 5;
            this.btnLinije.Text = "Linije";
            this.btnLinije.UseVisualStyleBackColor = true;
            this.btnLinije.Click += new System.EventHandler(this.btnLinije_Click);
            // 
            // txtOd
            // 
            this.txtOd.Location = new System.Drawing.Point(214, 192);
            this.txtOd.Name = "txtOd";
            this.txtOd.Size = new System.Drawing.Size(100, 20);
            this.txtOd.TabIndex = 6;
            // 
            // txtDo
            // 
            this.txtDo.Location = new System.Drawing.Point(357, 194);
            this.txtDo.Name = "txtDo";
            this.txtDo.Size = new System.Drawing.Size(100, 20);
            this.txtDo.TabIndex = 7;
            // 
            // lstLetovi
            // 
            this.lstLetovi.FormattingEnabled = true;
            this.lstLetovi.Location = new System.Drawing.Point(614, 192);
            this.lstLetovi.Name = "lstLetovi";
            this.lstLetovi.Size = new System.Drawing.Size(245, 251);
            this.lstLetovi.TabIndex = 8;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(28, 88);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 9;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(28, 49);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(100, 20);
            this.txtFile.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Datoteka lokacija";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lstLetovi);
            this.Controls.Add(this.txtDo);
            this.Controls.Add(this.txtOd);
            this.Controls.Add(this.btnLinije);
            this.Controls.Add(this.Linije);
            this.Controls.Add(this.lstLinije);
            this.Controls.Add(this.lstAerodromi);
            this.Controls.Add(this.btnAerodromi);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Linije.ResumeLayout(false);
            this.Linije.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAerodromi;
        private System.Windows.Forms.ListBox lstAerodromi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lstLinije;
        private System.Windows.Forms.GroupBox Linije;
        private System.Windows.Forms.RadioButton rbtnKraci;
        private System.Windows.Forms.RadioButton rbtnPrikazi;
        private System.Windows.Forms.RadioButton rbtnObrisi;
        private System.Windows.Forms.RadioButton rbtnDodaj;
        private System.Windows.Forms.Button btnLinije;
        private System.Windows.Forms.TextBox txtOd;
        private System.Windows.Forms.TextBox txtDo;
        private System.Windows.Forms.ListBox lstLetovi;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
    }
}

