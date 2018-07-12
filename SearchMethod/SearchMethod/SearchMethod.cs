using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Data;
using System.Windows.Forms;

namespace SearchMethod
{
    public partial class SearchMethod : Form
    {
        public SearchMethod()
        {
            InitializeComponent();
        }

        private void SearchMethod_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");
            //lblResult.Text = df.Find(txtPattern.Text, int.Parse(txtFrom.Text), int.Parse(txtTo.Text), int.Parse(txtNum.Text));
            Search();
        }

        private void Search()
        {
            lblResult.Text = Data.Data.FindInFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt", "to").ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
