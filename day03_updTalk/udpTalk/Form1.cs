using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace udpTalk
{
    public partial class Form1 : Form
    {
        private Socket UdpServer;
        private IPEndPoint Listen_IPEndPoint;

        private EndPoint Remote;
        private int LocalPort = 9999;
        private string BroadCast;
        private string UserName;

        delegate void StringArgReturningVoidDelegate(string text);
        public Form1()
        {
            InitializeComponent();
            txtPort.Text = LocalPort.ToString();
        }

        private void SetText(string text)
        {
            if (this.MsgWindow.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.MsgWindow.AppendText(text);
                MsgWindow.ScrollToCaret();
            }
        }

        private void threadProc()
        {
            try
            {
                int receive;
                string message;
                byte[] rxBytes = new byte[2048];

                while (true)
                {
                    receive = UdpServer.ReceiveFrom(rxBytes, ref Remote);
                    message = Encoding.UTF8.GetString(rxBytes, 0, receive);
                    SetText(message + "\r\n");
                    Thread.Sleep(500);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                DisConnect();
            }
        }

        private void InterConnect()
        {
            LocalPort = Convert.ToInt32(txtPort.Text, 10);
            UserName = txtMyname.Text;
            UdpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            Listen_IPEndPoint = new IPEndPoint(IPAddress.Any, LocalPort);
            Remote = (EndPoint)Listen_IPEndPoint;
            UdpServer.Bind(Listen_IPEndPoint);

            Thread thread = new Thread(new ThreadStart(threadProc));

            thread.IsBackground = true;
            thread.Start();

            SetText("Listen -\r\n");
            btnConnect.Text = "Close";
        }

        private void DisConnect()
        {
            Thread.EndThreadAffinity();
            UdpServer.Dispose();

            SetText("DisConnect -\r\n");
            btnConnect.Text = "Connect";
        }

        private void SendProc(string broadcast, string user, String msg)
        {
            try
            {
                IPEndPoint Sender = new IPEndPoint(IPAddress.Parse(broadcast), LocalPort);
                byte[] SendData = Encoding.UTF8.GetBytes(user + " > " + msg + "\n");
                UdpServer.SendTo(SendData, SendData.Length, SocketFlags.None, Sender);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect") InterConnect();
            else DisConnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BroadCast = txtSendToIP.Text;
            SendProc(BroadCast, UserName, txtSendMsg.Text);
            txtSendMsg.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisConnect();
        }
    }
}
