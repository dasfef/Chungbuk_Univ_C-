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
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace sysinfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void System_ID()
        {
            textBox1.Text = "";
            textBox1.Text += "User : " + Environment.UserName + "\r\n";
            string host = Dns.GetHostName();
            textBox1.Text += "Host Name : " + host + "\r\n";
            textBox1.Text += "Local IP Adress : " + Dns.GetHostByName(host).AddressList[0].ToString() + "\r\n";
            textBox1.Text += "\r\n";
        }

        private void OS_Info()
        {
            textBox1.Text += "OS Platform : " + Environment.OSVersion.Platform + "\r\n";
            textBox1.Text += "OS Ver : " + Environment.OSVersion + "\r\n";
            if (Environment.Is64BitOperatingSystem) textBox1.Text += "64Bit Operating System" + "\r\n";
            textBox1.Text += "Process Count : " + Environment.ProcessorCount + "\r\n";

            TimeSpan TickTime = TimeSpan.FromMilliseconds(Environment.TickCount);
            /*using (PerformanceCounter pc = new PerformanceCounter("System", "System Up Time"))
            {
                pc.NextValue();
                textBox1.Text += "System Elapsed Time : " + TimeSpan.FromMilliseconds(pc.NextValue()).ToString();
            }*/
            textBox1.Text += "System Elapsed Time : " + TickTime.ToString(@"dd\:hh\:mm\:ss\:fff") + "\r\n";
            textBox1.Text += "\r\n";
        }

        private void Drive_Info()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drv in allDrives)
            {
                textBox1.Text += "Drive : " + drv.Name + "\r\n";
                textBox1.Text += "  File type : " + drv.DriveType + "\r\n";
                if (drv.IsReady == true)
                {
                    textBox1.Text += "  Volume label : " + drv.VolumeLabel + "\r\n";
                    textBox1.Text += "  File system : " + drv.DriveFormat + "\r\n";
                    textBox1.Text += string.Format("  Available space to current user : {0:###,##0} bytes \r\n", drv.AvailableFreeSpace);
                    textBox1.Text += string.Format("  Total available space : {0:###,##0} bytes \r\n", drv.TotalFreeSpace);
                    textBox1.Text += string.Format("  Total size of drive : {0:###,##0} bytes \r\n", drv.TotalSize);
                }
                textBox1.Text += "\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System_ID();
            OS_Info();
            Drive_Info();
        }
    }
}
