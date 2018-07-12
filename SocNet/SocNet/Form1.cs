using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocNet
{
    public partial class Form1 : Form
    {

        SocialNetwork sn = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBroj_Click(object sender, EventArgs e)
        {
              sn = new SocialNetwork(int.Parse(txtBroj.Text));
        }

        private void btnKontakt_Click(object sender, EventArgs e)
        {
            sn.MakeContact(int.Parse(txtPrvi.Text), int.Parse(txtDrugi.Text));
        }

        private void btnPrikaz_Click(object sender, EventArgs e)
        {
            lblPrikaz.Text = string.Empty;
            lblPrikaz.Text += sn.Poznanici(int.Parse(txtOsoba.Text));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
