using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analog_clock
{
    public partial class Form1 : Form
    {
        Graphics g;

        private Point Center;
        private double radius;

        private int hourHand;
        private int minHand;
        private int secHand;

        public Form1()
        {
            InitializeComponent();
        }

        private void ClockSetting()
        {
            Center = new Point(panel1.Width / 2, panel1.Height / 2);
            radius = panel1.Height / 2;

            hourHand = (int)(radius * 0.45);
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            panel1.Refresh();

            double SecAngle = 2 * Math.PI * (now.Second - 15) / 60;
            double MinAngle = 2 * Math.PI * (now.Minute - 15) / 60;
            double HourAngle = (2 * Math.PI * (now.Hour - 15) / 12) + (MinAngle / 12);

            int HrX = Center.X + (int)(hourHand * Math.Cos(HourAngle));
            int HrY = Center.Y + (int)(hourHand * Math.Sin(HourAngle));
            Pen p = new Pen(Brushes.MidnightBlue, 6);
            g.DrawLine(p, HrX, HrY, Center.X, Center.Y);

            int MinX = Center.X + (int)(minHand * Math.Cos(MinAngle));
            int MinY = Center.Y + (int)(minHand * Math.Sin(MinAngle));
            p = new Pen(Brushes.DarkSlateGray, 3);
            g.DrawLine(p, MinX, MinY, Center.X, Center.Y);

            int SecX = Center.X + (int)(secHand * Math.Cos(SecAngle));
            int SecY = Center.Y + (int)(secHand * Math.Sin(SecAngle));
            p = new Pen(Brushes.OrangeRed, 3);
            g.DrawLine(p, SecX, SecY, Center.X, Center.Y);

            Rectangle core = new Rectangle(Center.X - 8, Center.Y - 8, 16, 16);
            g.FillEllipse(Brushes.DimGray, core);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();

            ClockSetting();
            timer1.Start();
        }
    }
}
