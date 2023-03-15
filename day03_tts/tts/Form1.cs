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

namespace tts
{
    
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSpeaker.Items.Clear();
            foreach(InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                cmbSpeaker.Items.Add(info.Name);
            }

            cmbSpeaker.SelectedIndex = 0;

            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoice(cmbSpeaker.Text);
        }

        private void cmbSpeaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpeaker.Text.Length > 0)
            {
                synth.SelectVoice(cmbSpeaker.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 )
            {
                synth.Speak(textBox1.Text);
            }
            else
            {
                synth.Speak("메시지를 넣어주세요");
            }
        }
    }
}
