using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TTS_2
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        Int16 narratorIndex = 0;
        List<string> narratorName = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        public void narratorPicture(Int16 index)
        {
            switch(index)
            {
                case 0:
                    pictureBox1.BackgroundImage = Properties.Resources.heami;
                    break;
                case 1:
                    pictureBox1.BackgroundImage = Properties.Resources.Zira;
                    break;
                case 2:
                    pictureBox1.BackgroundImage = Properties.Resources.david;
                    break;
                default:
                    narratorIndex = 0;
                    pictureBox1.BackgroundImage = Properties.Resources.heami;
                    break;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                narratorName.Add(info.Name);
            }
            narratorPicture(narratorIndex);

            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoice(narratorName[narratorIndex]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (++narratorIndex > 2) narratorIndex = 0;

            narratorPicture(narratorIndex);
            synth.SelectVoice(narratorName[narratorIndex]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label1.Text = now.ToString("HH:mm:ss");

            if(now.Second == 0)
            {
                string message = String.Format("현재 시각은 {0}시{1}분 입니다", now.Hour, now.Minute);
                synth.Speak(message);
            }
            label1.Text = now.ToString("HH:mm:ss");
        }
    }
}
