using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;


namespace ClientApplication
{
    public partial class Client : Form
    {
        private  int portNum;

        delegate void SetTextCallback(string text);
        delegate DialogResult MessageBoxDelegate(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon); 

        String st;

        TcpClient client;

        NetworkStream ns;

        Thread t = null;

        bool isRunning;

        public Client()
        {
            InitializeComponent();
        }

        

        public void DoWork()

        {
            try
            {
                byte[] bytes = new byte[1024];

                while (isRunning)

                {

                    int bytesRead = ns.Read(bytes, 0, bytes.Length);

                    st = Encoding.ASCII.GetString(bytes, 0, bytesRead);

                    if (st.Equals(" "))
                    {
                        
        
                          this.Invoke(new MessageBoxDelegate(ShowMessage), "Response is not received", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        isRunning = false;
                         // MessageBox.Show("Response is not received", "Message", MessageBoxButtons.OK);
                    }

                    this.SetText(st);

                 

                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message, "Message", MessageBoxButtons.OK);
            }
           
        }

        private DialogResult ShowMessage(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(this, msg, title, buttons, icon);
        }

        private void SetText(string text)

        {

            // InvokeRequired required compares the thread ID of the

            // calling thread to the thread ID of the creating thread.

            // If these threads are different, it returns true.

            if (this.txtResponseServer.InvokeRequired)

            {

                SetTextCallback d = new SetTextCallback(SetText);

                this.Invoke(d, new object[] { text });

            }

            else

            {

                this.txtResponseServer.Text = this.txtResponseServer.Text + text;

            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                isRunning = true;
              
                this.portNum = int.Parse(txtPort.Text);

                client = new TcpClient("127.0.0.1", portNum);

                ns = client.GetStream();

                String s = txtID.Text;

                if (!String.IsNullOrEmpty(s))
                {

                    byte[] byteTime = Encoding.ASCII.GetBytes(s);

                    ns.Write(byteTime, 0, byteTime.Length);

                    t = new Thread(DoWork);

                    t.Start();
                }
            }
            catch(Exception ec)
            {
                MessageBox.Show("Enter the values", "Warning", MessageBoxButtons.OK);
            }
        }
    }
}
