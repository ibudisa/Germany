using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data;

namespace AttributeSearch
{
    public partial class FormAttr : Form
    {
        public FormAttr()
        { 
            InitializeComponent();
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            try
            {
                AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

                
                
                string str = atfile.Match(txtPattern.Text, int.Parse(txtNum.Text),int.Parse(txtFrom.Text),int.Parse(txtTo.Text));

                lblResult.Text = str;
            }
            catch (Exception ec)
            {
                lblResult.Text = ec.Message;

            }
          
        }

        private void FormAttr_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
