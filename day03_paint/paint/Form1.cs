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

namespace paint
{
    public partial class Form1 : Form
    {
        enum DRAW_MODE : int
        {
            PENMODE = 0,
            ERASERMODE = 1,
            SHAPEMODE = 2,
            FLOODMODE = 3,
        }

        int curMode;
        Color curColor = Color.Black;
        int curLineSize = 1;

        Point mouseDownPoint;
        Bitmap pictureBoxBmp;

        public Form1()
        {
            InitializeComponent();
        }

        private Cursor LoadCursor(byte[] cursorFile)
        {
            MemoryStream cursorMemoryStream = new MemoryStream(cursorFile);
            Cursor hand = new Cursor(cursorMemoryStream);

            return hand;
        }

        private void SetDrawMode(int mode)
        {
            switch (mode)
            {
                case (int)DRAW_MODE.PENMODE:
                    curMode = (int)DRAW_MODE.PENMODE;
                    this.Cursor = LoadCursor(Properties.Resources.PenCursor_small);
                    break;

                case (int)DRAW_MODE.ERASERMODE:
                    curMode = (int)DRAW_MODE.ERASERMODE;
                    this.Cursor = LoadCursor(Properties.Resources.EraserCursor);
                    break;

                case (int)DRAW_MODE.SHAPEMODE:
                    curMode = (int)DRAW_MODE.SHAPEMODE;
                    this.Cursor = LoadCursor(Properties.Resources.ShapesCursor));
                    break;

                case (int)DRAW_MODE.FLOODMODE:
                    curMode = (int)DRAW_MODE.FLOODMODE;
                    this.Cursor = LoadCursor(Properties.Resources.PaintCursor);
                    break;

                default:
                    this.Cursor = Cursors.Default;
                    break;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetDrawMode((int)DRAW_MODE.PENMODE);
        }
    }
}
