using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mediaplayer
{
    public partial class Form1 : Form
    {
        string[] ShortFileName;
        string[] FullFileName;
        int ListCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.Title = "미디어 파일 열기";
            OpenFile.InitialDirectory = Environment.CurrentDirectory;
            OpenFile.Filter = "미디어파일|*.mp3, *.wav|모든파일(*.*)|*.*";

            if(OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Array.Resize(ref ShortFileName, ListCount + 1);
                Array.Resize(ref FullFileName, ListCount + 1);

                ShortFileName[ListCount] = OpenFile.SafeFileName;
                FullFileName[ListCount] = OpenFile.FileName;
                ListCount++;

                listBox1.Items.Clear();
                for (int SelectCount = 0; SelectCount < ShortFileName.Length; SelectCount++)
                {
                    listBox1.Items.Add(ShortFileName[SelectCount]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int whichSong = listBox1.SelectedIndex;

            axWindowsMediaPlayer1.URL = FullFileName[whichSong];
        }
    }
}
