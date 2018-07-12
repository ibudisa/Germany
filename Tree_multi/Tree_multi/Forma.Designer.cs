namespace Tree_multi
{
    partial class Forma
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
            this.lstbRezultat = new System.Windows.Forms.ListBox();
            this.btnUnos = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUnos = new System.Windows.Forms.TextBox();
            this.btnRacunaj = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstbRezultat
            // 
            this.lstbRezultat.FormattingEnabled = true;
            this.lstbRezultat.Location = new System.Drawing.Point(163, 80);
            this.lstbRezultat.Name = "lstbRezultat";
            this.lstbRezultat.Size = new System.Drawing.Size(120, 121);
            this.lstbRezultat.TabIndex = 7;
            this.lstbRezultat.SelectedIndexChanged += new System.EventHandler(this.lstbRezultat_SelectedIndexChanged);
            // 
            // btnUnos
            // 
            this.btnUnos.Location = new System.Drawing.Point(32, 117);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(75, 23);
            this.btnUnos.TabIndex = 6;
            this.btnUnos.Text = "Unesi";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(407, 24);
            this.menuStrip1.TabIndex = 8;
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
            // txtUnos
            // 
            this.txtUnos.Location = new System.Drawing.Point(32, 80);
            this.txtUnos.Name = "txtUnos";
            this.txtUnos.Size = new System.Drawing.Size(100, 20);
            this.txtUnos.TabIndex = 9;
            // 
            // btnRacunaj
            // 
            this.btnRacunaj.Location = new System.Drawing.Point(304, 178);
            this.btnRacunaj.Name = "btnRacunaj";
            this.btnRacunaj.Size = new System.Drawing.Size(75, 23);
            this.btnRacunaj.TabIndex = 10;
            this.btnRacunaj.Text = "Računaj";
            this.btnRacunaj.UseVisualStyleBackColor = true;
            this.btnRacunaj.Click += new System.EventHandler(this.btnRacunaj_Click);
            // 
            // Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 262);
            this.Controls.Add(this.btnRacunaj);
            this.Controls.Add(this.txtUnos);
            this.Controls.Add(this.lstbRezultat);
            this.Controls.Add(this.btnUnos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Forma";
            this.Text = "Forma";
            this.Load += new System.EventHandler(this.Forma_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbRezultat;
        private System.Windows.Forms.Button btnUnos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txtUnos;
        private System.Windows.Forms.Button btnRacunaj;
    }
}

