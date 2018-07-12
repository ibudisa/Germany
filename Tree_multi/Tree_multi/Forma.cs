using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tree_multi
{
    public partial class Forma : Form
    {
        List<int> lista = new List<int>();

        public Forma()
        {
            InitializeComponent();
        }

        
        private void Forma_Load(object sender, EventArgs e)
        {

        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            try
            {
                lista.Add(int.Parse(txtUnos.Text));
                lstbRezultat.Items.Add(txtUnos.Text);
                txtUnos.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Display", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstbRezultat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRacunaj_Click(object sender, EventArgs e)
        {
            lstbRezultat.Items.Clear();

            Stablo s = new Stablo(lista);
            lstbRezultat.Items.Add(String.Format("Broj listova iznosi:{0}", s.StabloFinal.Count));
            lstbRezultat.Items.Add(String.Format("Duljina stabla iznosi:{0}", s.maxLength()));
        }

        private void Forma_Load_1(object sender, EventArgs e)
        {

        }

        
                                 
    }
}
 