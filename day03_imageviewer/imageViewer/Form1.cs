using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageViewer
{
    public partial class Form1 : Form
    {
        string FullName;
        string ShortName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.BackColor = Color.White;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            ShortName = "제목없음";
            this.Text = ShortName + " - ImageViewer";
        }

        private void mnuEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.Title = "Origin Image Open";
            OpenFile.InitialDirectory = Environment.CurrentDirectory;
            OpenFile.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png|All Files(*.*)|*.*";

            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FullName = OpenFile.FileName;
                FileInfo fi = new FileInfo(FullName);
                ShortName = fi.Name;

                pictureBox1.Image = Image.FromFile(FullName);
                this.Text = ShortName + " - ImageViewer";
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();

            SaveFile.Title = "다른 이름으로 저장";
            SaveFile.InitialDirectory = Environment.CurrentDirectory;
            SaveFile.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png|All Files(*.*)|*.*";
            SaveFile.FileName = ShortName;

            if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FullName = SaveFile.FileName;
                FileInfo fi = new FileInfo(FullName);
                ShortName = fi.Name;

                this.Text = ShortName + " - ImageViewer";
                pictureBox1.Image.Save(FullName);
            }
        }
    }
}
