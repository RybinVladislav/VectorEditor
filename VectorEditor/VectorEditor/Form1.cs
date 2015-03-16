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

        public Color fillColor = Color.Red;
        public Color strokeColor = Color.Black;
        public float strokeWidth = 2F;

        float scale = 1;

        public bool isNear(PointF p1, PointF p2, float r)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) <= r * r;
        }

        public void Draw()
        {
            Graphics s = panel1.CreateGraphics();
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(Color.White);
            vectorImage.Draw(g, scale);

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

        Instrument currentInstrument = Instrument.None;
        bool isDrawing = false;
        float x0, y0, x, y;
        IList<CurveCoords> curvePoints = new List<CurveCoords>();
        PointF curveStart = PointF.Empty;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.Ellipse;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;

            switch (currentInstrument)
            {
                case Instrument.Ellipse :
                    isDrawing = true;
                    vectorImage.InsertingFigure = factory.CreateEllipse(new PointF(e.X, e.Y), 0, 0, fillColor, strokeColor, strokeWidth);
                    Draw();
                    break;
                case Instrument.Rectangle:
                    isDrawing = true;
                    vectorImage.InsertingFigure = factory.CreateRectangle(y0, x0, 0, 0, fillColor, strokeColor, strokeWidth);
                    Draw();
                    break;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                x = e.X; y = e.Y;
                switch (currentInstrument)
                {
                    case Instrument.Ellipse:
                        vectorImage.InsertingFigure = factory.CreateEllipse(new PointF((x0 + x) / 2, (y0 + y) / 2), Math.Abs(x0 - x) / 2, Math.Abs(y0 - y) / 2,
                            fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                    case Instrument.Rectangle:
                        vectorImage.InsertingFigure = factory.CreateRectangle(Math.Min(y0, y), Math.Min(x0, x), Math.Abs(x - x0), Math.Abs(y - y0), 
                            fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                    case Instrument.CurvePath:
                        curvePoints.RemoveAt(curvePoints.Count - 1);
                        curvePoints.Add(new CurveCoords(curvePoints[curvePoints.Count - 1].P, new PointF(x, y), new PointF(x, y)));
                        vectorImage.InsertingFigure = factory.CreateCurvePath(curveStart, curvePoints, Color.Transparent, strokeColor, strokeWidth);
                        Draw();
                        break;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
            if (isDrawing)
            {
                switch (currentInstrument)
                {
                    case Instrument.Ellipse:
                        vectorImage.InsertingFigure = null;
                        isDrawing = false;
                        vectorImage.AddEllipse(factory, new PointF((x0 + x) / 2, (y0 + y) / 2), Math.Abs(x0 - x) / 2, Math.Abs(y0 - y) / 2,
                            fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                    case Instrument.Rectangle:
                        vectorImage.InsertingFigure = null;
                        isDrawing = false;
                        vectorImage.AddRectangle(factory, Math.Min(y0, y), Math.Min(x0, x), Math.Abs(x - x0), Math.Abs(y - y0),
                            fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                }
            }
            if (currentInstrument == Instrument.CurvePath)
            {
                if (curveStart.IsEmpty && !isDrawing)
                {
                    curveStart = new PointF(x, y);
                    isDrawing = true;
                    curvePoints = new List<CurveCoords>();
                    curvePoints.Add(new CurveCoords(curveStart, new PointF(x, y), new PointF(x, y)));
                    curvePoints.Add(new CurveCoords(new PointF(x, y), new PointF(x, y), new PointF(x, y)));
                    vectorImage.InsertingFigure = factory.CreateCurvePath(curveStart, curvePoints, Color.Transparent, strokeColor, strokeWidth);
                    Draw();
                }
                else
                {
                    if (isNear(curveStart, new PointF(x, y), 10)) 
                    {
                        curvePoints.RemoveAt(curvePoints.Count - 1);
                        curvePoints.Add(new CurveCoords(curvePoints[curvePoints.Count - 1].P, curveStart, curveStart));
                        vectorImage.InsertingFigure = null;
                        isDrawing = false;
                        vectorImage.AddCurvePath(factory, curveStart, curvePoints, fillColor, strokeColor, strokeWidth);
                        curveStart = PointF.Empty;
                        curvePoints = null;
                        Draw();
                    } 
                    else
                    {
                        curvePoints.RemoveAt(curvePoints.Count - 1);
                        curvePoints.Add(new CurveCoords(curvePoints[curvePoints.Count - 1].P, new PointF(x, y), new PointF(x, y)));
                        curvePoints.Add(new CurveCoords(new PointF(x, y), new PointF(x, y), new PointF(x, y)));
                        vectorImage.InsertingFigure = factory.CreateCurvePath(curveStart, curvePoints, Color.Transparent, strokeColor, strokeWidth);
                        Draw();
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.None;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.Rectangle;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.Polygon;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.CurvePath;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isDrawing && currentInstrument == Instrument.CurvePath && e.KeyData == Keys.Enter)
            {
                curvePoints.RemoveAt(curvePoints.Count - 1);
                curvePoints.Add(new CurveCoords(curvePoints[curvePoints.Count - 1].P, new PointF(x, y), new PointF(x, y)));
                vectorImage.InsertingFigure = null;
                isDrawing = false;
                vectorImage.AddCurvePath(factory, curveStart, curvePoints, fillColor, strokeColor, strokeWidth);
                curveStart = PointF.Empty;
                curvePoints = null;
                Draw();
            }
        }
    }
}
