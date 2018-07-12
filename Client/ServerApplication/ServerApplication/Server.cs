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
using System.Xml.Serialization;
 
 

namespace ServerApplication
{
    public partial class Server : Form
    {
        delegate void SetTextCallback(string text);

        TcpListener listener;

        TcpClient client;

        NetworkStream ns;

        Thread t = null;
        bool isRunning;

        public Server()
        {
            InitializeComponent();
            
        }

        private void Function()
        {
            try
            {

                isRunning = true;
                listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), int.Parse("1234"));

                listener.Start();



                t = new Thread(DoWork);

                t.Start();
            }
            catch(Exception ec)
            {
                MessageBox.Show("Values are need to be entered", "Message", MessageBoxButtons.OK);
            }
        }

        
        public void DoWork()

        {
            try
            {
                byte[] bytes = new byte[1024];
                String s = String.Empty;

                while (isRunning)

                {
                    
                    client = listener.AcceptTcpClient();

                    ns = client.GetStream();

                    int bytesRead = ns.Read(bytes, 0, bytes.Length);

                    String str = Encoding.ASCII.GetString(bytes, 0, bytesRead);

                    int b = int.Parse(str);
                    this.SetText(str);

                    if (b > 10)
                    {
                        s = " ";
                    }

                    else
                    {

                        PersonData p = new PersonData();

                        Person t = p.data.Single(c => c.ID == b);

                        var stringwriter = new System.IO.StringWriter();
                        var serializer = new XmlSerializer(typeof(Person));
                        serializer.Serialize(stringwriter, t);

                        s = stringwriter.ToString();
                    }

                    byte[] byteTime = Encoding.ASCII.GetBytes(s);

                    ns.Write(byteTime, 0, byteTime.Length);

                    ns.Close();

                    //MessageBox.Show(Encoding.ASCII.GetString(bytes, 0, bytesRead));

                }
                 
            }
            catch(SocketException ec)
            {
                
            }
            
        }

        private void SetText(string text)

        {

            // InvokeRequired required compares the thread ID of the

            // calling thread to the thread ID of the creating thread.

            // If these threads are different, it returns true.

            if (this.txtStatus.InvokeRequired)

            {

                SetTextCallback d = new SetTextCallback(SetText);

                this.Invoke(d, new object[] { text });

            }

            else

            {

                this.txtStatus.Text = this.txtStatus.Text + text;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                FunctionRestart();

            }
            catch(SocketException ec)
            {

            }
        }

        private void FunctionRestart()
        {
            try
            {
                 
                client.Close();
                Socket s = listener.Server;
                s.Close();
                
                listener.Stop();

                t.Join();

               

                isRunning = true;
                listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), int.Parse(txtPort.Text));

                listener.Start();



                t = new Thread(DoWork);

                t.Start();
            }
            catch (Exception ec)
            {
                MessageBox.Show("Values are need to be entered", "Message", MessageBoxButtons.OK);
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Function();
        }
    }
}
