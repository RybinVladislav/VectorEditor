using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public VectorImage vectorImage = new VectorImage();
        private Factory factory = new Factory();

        public Color fillColor = Color.Transparent;
        public Color strokeColor = Color.Black;
        public float strokeWidth = 2F;

        public void Draw()
        {
            Graphics s = panel1.CreateGraphics();
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(Color.White);
            vectorImage.Draw(g);

            s.DrawImage(bmp, 0, 0, panel1.Width, panel1.Height);
            g.Dispose();
            bmp.Dispose();
            s.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        enum Instrument
        {
            None,
            Ellipse,
            Rectangle,
            Polygon,
            CurvePath
        }

        Instrument currentInstument = Instrument.None;
        bool isDrawing = false;
        float x0, y0, x, y;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            currentInstument = Instrument.Ellipse;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;

            switch (currentInstument)
            {
                case Instrument.Ellipse :
                    isDrawing = true;
                    vectorImage.InsertingFigure = factory.CreateEllipse(new PointF(e.X, e.Y), 0, 0, fillColor, strokeColor, strokeWidth);
                    Draw();
                    break;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                x = e.X; y = e.Y;
                switch (currentInstument)
                {
                    case Instrument.Ellipse:
                        vectorImage.InsertingFigure = factory.CreateEllipse(new PointF((x0 + x) / 2, (y0 + y) / 2), Math.Abs(x0 - x) / 2, Math.Abs(y0 - y) / 2,
                            fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                x = e.X; y = e.Y;
                switch (currentInstument)
                {
                    case Instrument.Ellipse:
                        vectorImage.InsertingFigure = null;
                        isDrawing = false;
                        vectorImage.AddEllipse(factory, new PointF((x0 + x) / 2, (y0 + y) / 2), Math.Abs(x0 - x) / 2, Math.Abs(y0 - y) / 2,
                            fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            currentInstument = Instrument.None;
        }
    }
}
