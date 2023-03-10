using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day02_calculator
{
    public partial class Form1 : Form
    {
        string strKeyin;
        int NumA, NumB;
        string Cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            strKeyin = "";
            textBox1.Text = strKeyin;
            NumA = 0;
            NumB = 0;
            Cmd = "";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            strKeyin += "1";
            textBox1.Text = strKeyin;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            strKeyin += "2";
            textBox1.Text = strKeyin;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            strKeyin += "3";
            textBox1.Text = strKeyin;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            strKeyin += "4";
            textBox1.Text = strKeyin;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            strKeyin += "5";
            textBox1.Text = strKeyin;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            strKeyin += "6";
            textBox1.Text = strKeyin;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            strKeyin += "7";
            textBox1.Text = strKeyin;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            strKeyin += "8";
            textBox1.Text = strKeyin;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            strKeyin += "9";
            textBox1.Text = strKeyin;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            string temp;
            int vTemp;
            temp = strKeyin + "0";
            vTemp = Convert.ToInt32(temp);
            if (vTemp > 0)
            {
                strKeyin = Convert.ToString(vTemp);
            }
            else
            {
                strKeyin = "";
            }
            textBox1.Text = strKeyin;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            {
                string temp;
                int vTemp;
                temp = strKeyin + "00";                                                                                                                                                                                                                                                                                                                                                                               0";
                vTemp = Convert.ToInt32(temp);
                if (vTemp > 0)
                {
                    strKeyin = Convert.ToString(vTemp);
                }
                else
                {
                    strKeyin = "";
                }
                textBox1.Text = strKeyin;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            NumA = Convert.ToInt32(strKeyin);
            NumB = 0;
            Cmd = "+";
            strKeyin = "";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            NumA = Convert.ToInt32(strKeyin);
            NumB = 0;
            Cmd = "-";
            strKeyin = "";
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            NumA = Convert.ToInt32(strKeyin);
            NumB = 0;
            Cmd = "*";
            strKeyin = "";
        }

        private void btnDevide_Click(object sender, EventArgs e)
        {
            NumA = Convert.ToInt32(strKeyin);
            NumB = 0;
            Cmd = "/";
            strKeyin = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            strKeyin = "";
            textBox1.Text = strKeyin;
            NumA = 0;
            NumB = 0;
            Cmd = "";

            DateTime now = DateTime.Now;
            label1.Text = now.ToString("HH:mm:ss");

            timer1.Start();
        }

        private void btnEqu_Click(object sender, EventArgs e)
        {
            if ((GetType(NumA)=="int") && (Cmd != ""))
            {
                NumB = Convert.ToInt32(strKeyin);
                Math1();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label1.Text = now.ToString("HH:mm:ss");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            strKeyin += ".";
            textBox1.Text = ".";
        }

        private void Math1()
        {
            int Res;

            switch (Cmd)
            {
                case "+":
                    Res = NumA + NumB;
                    break;

                case "-":
                    Res = NumA - NumB;
                    break;

                case "*":
                    Res = NumA * NumB;
                    break;

                case "/":
                    Res = NumA / NumB;
                    break;

                default:
                    Res = 0;
                    break;

            }

            strKeyin = Convert.ToString(Res);
            textBox1.Text = strKeyin;
            Cmd = "";
        }

        private void Math2()
        {
            float Res;

            switch (Cmd)
            {
                case "+":

            }
        }
    }
}