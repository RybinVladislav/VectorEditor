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
            vectorImage = new VectorImage(640, 480);
            vectorImage.OnImageChangeHandler += vectorImage_OnImageChangeHandler;
        }

        void vectorImage_OnImageChangeHandler(object sender, ImageChangeEventArgs e)
        {
            treeView1.Nodes.Clear();
            imageList1.Images.Clear();
            int a = Math.Max(vectorImage.Width, vectorImage.Height);
            for (int i = 0; i < e.Figures.Count; i++)
            {
                Bitmap bmp = new Bitmap(64, 64);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Figures[i].Draw(g, (float)(64.0 / a));
                g.Dispose();
                imageList1.Images.Add(bmp);
                bmp.Dispose();
                g.Dispose();

                treeView1.Nodes.Add(string.Format("Figure{0}", i), string.Format("Figure{0} [{1}]", i, e.Figures[i].GetType().Name), i, i);
            }
        }

        public VectorImage vectorImage;
        private Factory factory = new Factory();

        public Color fillColor = Color.Transparent;
        public Color strokeColor = Color.Black;
        public float strokeWidth = 2F;

        public IFigure selectedFigure = null;

        float scale = 1;

        PointF GetImageCoords()
        {
            float x0 = (panel1.Width - vectorImage.Width * scale) / 2,
                  y0 = (panel1.Height - vectorImage.Height * scale) / 2;
            return new PointF(x0, y0);
        }

        // начало координат
        public int X0, Y0;

        public bool isNear(PointF p1, PointF p2, float r)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) <= r * r;
        }

        public void Draw()
        {
            Graphics s = panel1.CreateGraphics();
            
            Bitmap bmp1 = new Bitmap(panel1.Width, panel1.Height);
            Graphics g1 = Graphics.FromImage(bmp1);

            Bitmap bmp = new Bitmap(vectorImage.Width, vectorImage.Height);
            Graphics g = Graphics.FromImage(bmp);

            // начало координат для изображения
            PointF p = GetImageCoords();

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(Color.White);
            vectorImage.Draw(g, scale);

            if (selectedFigure != null)
                selectedFigure.Draw(g, scale);

            g1.Clear(Color.Gray);
            g1.DrawImage(bmp, X0 + p.X, Y0 + p.Y, vectorImage.Width * scale, vectorImage.Height * scale);
            
            s.DrawImage(bmp1, 0, 0, panel1.Width, panel1.Height);
            g1.Dispose();
            bmp1.Dispose();
            g.Dispose();
            bmp.Dispose();
            s.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        // Observer

        enum Instrument
        {
            None,
            Ellipse,
            Rectangle,
            CurvePath
        }

        Instrument currentInstrument = Instrument.None;
        bool isDrawing = false;

        bool isMoving = false;

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

            PointF p = GetImageCoords();

            switch (currentInstrument)
            {
                case Instrument.Ellipse :
                    isDrawing = true;
                    vectorImage.InsertingFigure = factory.CreateEllipse(new PointF(e.X - p.X, e.Y - p.Y), 0, 0, fillColor, strokeColor, strokeWidth);
                    Draw();
                    break;
                case Instrument.Rectangle:
                    isDrawing = true;
                    vectorImage.InsertingFigure = factory.CreateRectangle(y0 - p.X, x0 - p.Y, 0, 0, fillColor, strokeColor, strokeWidth);
                    Draw();
                    break;
            }

            if (selectedFigure != null && selectedFigure is IEllipse)
            {
                isMoving = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            PointF p = GetImageCoords();
            x = e.X - p.X; y = e.Y - p.Y;
            if (isDrawing)
            {
                switch (currentInstrument)
                {
                    case Instrument.Ellipse:
                        vectorImage.InsertingFigure = factory.CreateEllipse(new PointF((x0 - p.X + x) / 2, (y0 - p.Y + y) / 2), 
                            Math.Abs(x0 - p.X - x) / 2, Math.Abs(y0 - p.Y - y) / 2, fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                    case Instrument.Rectangle:
                        vectorImage.InsertingFigure = factory.CreateRectangle(Math.Min(y0 - p.Y, y), Math.Min(x0 - p.X, x), 
                            Math.Abs(x - x0 + p.X), Math.Abs(y - y0 + p.Y), fillColor, strokeColor, strokeWidth);
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

            if (isMoving)
            {
                if (selectedFigure != null && selectedFigure is IEllipse)
                {
                    if ((x0 - p.X >= ((IEllipse)selectedFigure).Center.X - ((IEllipse)selectedFigure).RadiusX - 4) &&
                        (x0 - p.X <= ((IEllipse)selectedFigure).Center.X - ((IEllipse)selectedFigure).RadiusX + 4) &&
                        (y0 - p.Y >= ((IEllipse)selectedFigure).Center.Y - 4) &&
                        (y0 - p.Y <= ((IEllipse)selectedFigure).Center.Y + 4))
                    {
                        ((IEllipse)selectedFigure).RadiusX += x0 - e.X;
                        x0 = e.X;
                        Draw();
                    }
                    else
                        if ((x0 - p.X >= ((IEllipse)selectedFigure).Center.X - 4) &&
                        (x0 - p.X <= ((IEllipse)selectedFigure).Center.X + 4) &&
                        (y0 - p.Y >= ((IEllipse)selectedFigure).Center.Y - ((IEllipse)selectedFigure).RadiusY - 4) &&
                        (y0 - p.Y <= ((IEllipse)selectedFigure).Center.Y - ((IEllipse)selectedFigure).RadiusY + 4))
                        {
                            ((IEllipse)selectedFigure).RadiusY += y0 - e.Y;
                            y0 = e.Y;
                            Draw();
                        }
                        else
                        {
                            ((IEllipse)selectedFigure).Center = new PointF(((IEllipse)selectedFigure).Center.X - x0 + e.X,
                                ((IEllipse)selectedFigure).Center.Y - y0 + e.Y);
                            x0 = e.X;
                            y0 = e.Y;
                            Draw();
                        }
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            PointF p = GetImageCoords();
            x = e.X - p.X; y = e.Y - p.Y;

            if (isMoving)
            {
                isMoving = false;
            }

            if (isDrawing)
            {
                switch (currentInstrument)
                {
                    case Instrument.Ellipse:
                        vectorImage.InsertingFigure = null;
                        isDrawing = false;
                        vectorImage.AddEllipse(factory, new PointF((x0 - p.X + x) / 2, (y0 - p.Y + y) / 2),
                            Math.Abs(x0 - p.X - x) / 2, Math.Abs(y0 - p.Y - y) / 2, fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                    case Instrument.Rectangle:
                        vectorImage.InsertingFigure = null;
                        isDrawing = false;
                        vectorImage.AddRectangle(factory, Math.Min(y0 - p.Y, y), Math.Min(x0 - p.X, x),
                            Math.Abs(x - x0 + p.X), Math.Abs(y - y0 + p.Y), fillColor, strokeColor, strokeWidth);
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
            else
            if (currentInstrument == Instrument.None) 
            {
                vectorImage.SelectFigure(x, y, 5);
                if (vectorImage.SelectedFigure != -1)
                    selectedFigure = vectorImage.Figures[vectorImage.SelectedFigure];
                else
                    selectedFigure = null;

                if (selectedFigure is IEllipse)
                    selectedFigure = new EllipseDecorator(selectedFigure as IEllipse);

                Draw();

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
            if (isDrawing && e.KeyData == Keys.Escape)
            {
                vectorImage.InsertingFigure = null;
                isDrawing = false;
                if (currentInstrument == Instrument.CurvePath)
                {
                    curveStart = PointF.Empty;
                    curvePoints = null;
                }
                Draw();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = strokeColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strokeColor = colorDialog1.Color;
				toolStripButton4.BackColor = colorDialog1.Color;
				toolStripButton4.ForeColor = Color.FromArgb(Color.Black.ToArgb() - colorDialog1.Color.ToArgb());
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = fillColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fillColor = colorDialog1.Color;
				toolStripButton6.BackColor = colorDialog1.Color;
				toolStripButton6.ForeColor = Color.FromArgb(Color.Black.ToArgb() - colorDialog1.Color.ToArgb());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //vectorImage.SelectedFigure = e.Node.Index;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
