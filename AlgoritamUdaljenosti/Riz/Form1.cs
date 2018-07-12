using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Riz
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private FileData d = new FileData();

        private void btnAerodromi_Click(object sender, EventArgs e)
        {
            FileData d = new FileData();
            List<Aerodrom> ls = d.Data();
            foreach (Aerodrom b in ls)
            {
                lstAerodromi.Items.Add(b.Ime);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstAerodromi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileData d = new FileData();
            List<string> linije = new List<string>();
            linije = d.Linije();

            lstLinije.Items.Clear();

            foreach (string st in linije)
            {
                string[] arr = st.Split(' ');
                string naziv = lstAerodromi.SelectedItem.ToString();

                if (naziv.Equals(arr[0]))
                {
                    lstLinije.Items.Add(st);

                }
            }
        }

        private void btnLinije_Click(object sender, EventArgs e)
        {
            FileData f = new FileData();
            List<string> linije = f.Linije();
            List<string> list = new List<string>();
            if (rbtnDodaj.Checked)
            {

                f.AddFlight(txtOd.Text, txtDo.Text);
            }
            else if (rbtnObrisi.Checked)
            {
                f.RemoveFlight(txtOd.Text, txtDo.Text);
            }
            else if (rbtnPrikazi.Checked)
            {
                if (lstLetovi.Items.Count > 0)
                {
                    lstLetovi.Items.Clear();
                }

                list = f.GetFlight(txtOd.Text, txtDo.Text);

                foreach (string s in list)
                {
                    lstLetovi.Items.Add(s);
                }
            }
            else if (rbtnKraci.Checked)
            {
                if (lstLetovi.Items.Count > 0)
                {
                    lstLetovi.Items.Clear();
                }

                list = f.GetShortPathFlight(txtOd.Text, txtDo.Text);

                foreach (string s in list)
                {
                    lstLetovi.Items.Add(s);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
                FileData.FileName = openFileDialog1.FileName;
            }
        }
    }
}
