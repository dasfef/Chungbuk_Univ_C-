using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int inputNo = Convert.ToInt32(txtInput.Text);

            switch(cmbFormat.SelectedIndex)
            {
                case 0:
                    txtOutput.Text = Convert.ToString(inputNo, 16);
                    break;

                case 1:
                    txtOutput.Text = Convert.ToString(inputNo, 2);
                    break;

                case 2:
                    txtOutput.Text = Convert.ToString(inputNo, 10);
                    break;

                default:
                    txtOutput.Text = "?";
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] NumFormat = { "HEX", "BIN", "DEC" };

            txtInput.Text = "";
            txtOutput.Text = "";

            cmbFormat.Items.AddRange(NumFormat);
            cmbFormat.SelectedIndex = 0;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
        }
    }
}
