using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace VectorEditor
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();

            CreateNew(640, 480);
        }

        void CreateNew(int w, int h)
        {
            vectorImage = new VectorImage(w, h);
            caretaker = new Caretaker();
            undoButton.Enabled = false;
        }

        void SaveMemento()
        {
            caretaker.Memento = vectorImage.CreateMemento();
            undoButton.Enabled = true;
        }

        void Undo()
        {
            vectorImage.SetMemento(caretaker.Memento);
            undoButton.Enabled = false;
            Draw();
        }

        public VectorImage vectorImage;
        private Factory factory = new Factory();
        Caretaker caretaker;

        public Color fillColor = Color.Transparent;
        public Color strokeColor = Color.Black;
        public float strokeWidth = 2F;

        public List<IFigure> selectedFigures = new List<IFigure>();

        float scale = 1;

        PointF GetImageCoords()
        {
            float x0 = (panel1.Width - vectorImage.Width * scale) / 2,
                  y0 = (panel1.Height - vectorImage.Height * scale) / 2;
            return new PointF(x0, y0);
        }

        // начало координат
        public int X0 = 0, Y0 = 0;

        public bool isNear(PointF p1, PointF p2, float r)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) <= r * r;
        }

        public void Draw()
        {
            Graphics s = panel1.CreateGraphics();
            
            Bitmap bmp1 = new Bitmap(panel1.Width, panel1.Height);
            Graphics g1 = Graphics.FromImage(bmp1);

            g1.Clear(Color.Gray);

            if (vectorImage != null)
            {
                Bitmap bmp = new Bitmap((int)(vectorImage.Width * scale), (int)(vectorImage.Height * scale));
                Graphics g = Graphics.FromImage(bmp);

                // начало координат для изображения
                PointF p = GetImageCoords();

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.Clear(Color.White);
                vectorImage.Draw(g, scale);

                foreach (IFigure figure in selectedFigures)
                    figure.Draw(g, scale);

                g1.DrawImage(bmp, X0 + p.X, Y0 + p.Y, vectorImage.Width * scale, vectorImage.Height * scale);

                g.Dispose();
                bmp.Dispose();
            }

            s.DrawImage(bmp1, 0, 0, panel1.Width, panel1.Height);
            g1.Dispose();
            bmp1.Dispose();

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
        bool moving = false;

        float x0, y0, x, y;
        IList<CurveCoords> curvePoints = new List<CurveCoords>();
        PointF curveStart = PointF.Empty;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (vectorImage != null)
            {

                x0 = e.X;
                y0 = e.Y;

                PointF p = GetImageCoords();

                switch (currentInstrument)
                {
                    case Instrument.Ellipse:
                        isDrawing = true; isMoving = false; selectedFigures = new List<IFigure>();
                        vectorImage.InsertingFigure = factory.CreateEllipse(new PointF(e.X - p.X, e.Y - p.Y), 0, 0, fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                    case Instrument.Rectangle:
                        isDrawing = true; isMoving = false; selectedFigures = new List<IFigure>();
                        vectorImage.InsertingFigure = factory.CreateRectangle(y0 - p.X, x0 - p.Y, 0, 0, fillColor, strokeColor, strokeWidth);
                        Draw();
                        break;
                }

                // Выделение

                if (currentInstrument == Instrument.None && !isMoving)
                {
                    if (selectedFigure is ICurvePath)
                    {
                        if (vectorImage.CurvePathCheck(x, y, 5))
                        {
                            isMoving = true;
                            return;
                        }
                    }

                    vectorImage.SelectFigure(x, y, 5);
                    if (vectorImage.SelectedFigure != -1)
                    {
                        selectedFigure = vectorImage.Figures[vectorImage.SelectedFigure];
                        borderColorButton.BackColor = selectedFigure.StrokeColor;
                        fillColorButton.BackColor = selectedFigure.FillColor;
                        numericUpDown1.Value = (decimal)selectedFigure.StrokeWidth;
                        panel5.Visible = true;
                        stripBtn1.Enabled = true;
                        stripBtn2.Enabled = true;
                        stripBtn3.Enabled = true;
                        stripBtn4.Enabled = true;
                    }
                    else
                    {
                        selectedFigure = null;
                        borderColorButton.BackColor = strokeColor;
                        fillColorButton.BackColor = fillColor;
                        numericUpDown1.Value = (decimal)strokeWidth;
                        panel5.Visible = false;
                        stripBtn1.Enabled = false;
                        stripBtn2.Enabled = false;
                        stripBtn3.Enabled = false;
                        stripBtn4.Enabled = false;
                    }

                    if (selectedFigure is IEllipse)
                        selectedFigure = new EllipseDecorator(selectedFigure as IEllipse);

                    if (selectedFigure is IRectangle)
                        selectedFigure = new RectangleDecorator(selectedFigure as IRectangle);

                    if (selectedFigure is ICurvePath)
                        selectedFigure = new CurvePathDecorator(selectedFigure as ICurvePath);

                    Draw();

                }

                if (selectedFigure != null)
                {
                    isMoving = true;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (vectorImage != null)
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

                if (isMoving && selectedFigure != null)
                {
                    PointF p0 = selectedFigure.MouseMove(e.Location, p, new PointF(x0, y0));
                    x0 = p0.X;
                    y0 = p0.Y;
                    Draw();
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (vectorImage != null)
            {
                Focus();
                PointF p = GetImageCoords();
                x = e.X - p.X; y = e.Y - p.Y;

                if (isMoving)
                {
                    //SaveMemento();
                    isMoving = false;
                    moving = false;
                }

                if (isDrawing)
                {
                    switch (currentInstrument)
                    {
                        case Instrument.Ellipse:
                            SaveMemento();
                            vectorImage.InsertingFigure = null;
                            isDrawing = false;
                            vectorImage.AddEllipse(factory, new PointF((x0 - p.X + x) / 2, (y0 - p.Y + y) / 2),
                                Math.Abs(x0 - p.X - x) / 2, Math.Abs(y0 - p.Y - y) / 2, fillColor, strokeColor, strokeWidth);
                            Draw();
                            break;
                        case Instrument.Rectangle:
                            SaveMemento();
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
                    isMoving = false; selectedFigures = new List<IFigure>();
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
                            PointF p1 = new PointF(2 * curvePoints[curvePoints.Count - 1].P.X / 3 + curveStart.X / 3,
                                2 * curvePoints[curvePoints.Count - 1].P.Y / 3 + curveStart.Y / 3);
                            PointF p2 = new PointF(curvePoints[curvePoints.Count - 1].P.X / 3 + 2 * curveStart.X / 3,
                                curvePoints[curvePoints.Count - 1].P.Y / 3 + 2 * curveStart.Y / 3);
                            curvePoints.Add(new CurveCoords(p1, p2, curveStart));

                            SaveMemento();

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
                            PointF p1 = new PointF(2 * curvePoints[curvePoints.Count - 1].P.X / 3 + x / 3, 2 * curvePoints[curvePoints.Count - 1].P.Y / 3 + y / 3);
                            PointF p2 = new PointF(curvePoints[curvePoints.Count - 1].P.X / 3 + 2 * x / 3, curvePoints[curvePoints.Count - 1].P.Y / 3 + 2 * y / 3);
                            curvePoints.Add(new CurveCoords(p1, p2, new PointF(x, y)));
                            curvePoints.Add(new CurveCoords(new PointF(x, y), new PointF(x, y), new PointF(x, y)));
                            vectorImage.InsertingFigure = factory.CreateCurvePath(curveStart, curvePoints, Color.Transparent, strokeColor, strokeWidth);
                            Draw();
                        }
                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isDrawing && currentInstrument == Instrument.CurvePath && e.KeyData == Keys.Enter)
            {
                curvePoints.RemoveAt(curvePoints.Count - 1);
                //PointF p1 = new PointF(2 * curvePoints[curvePoints.Count - 1].P.X / 3 + x / 3, 2 * curvePoints[curvePoints.Count - 1].P.Y / 3 + y / 3);
                //PointF p2 = new PointF(curvePoints[curvePoints.Count - 1].P.X / 3 + 2 * x / 3, curvePoints[curvePoints.Count - 1].P.Y / 3 + 2 * y / 3);
                //curvePoints.Add(new CurveCoords(p1, p2, new PointF(x, y)));

                SaveMemento();

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

        private void Form1_Resize(object sender, EventArgs e)
        {
            Draw();
        }
  
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SaveMemento();
            foreach (IFigure figure in selectedFigures)
            {
                    figure.StrokeWidth = (float)numericUpDown1.Value; 
            }
            Draw();
        }

        private void lvlUpButton_Click(object sender, EventArgs e)
        {
            SaveMemento();
            vectorImage.LevelUp(vectorImage.Figures[vectorImage.SelectedFigure]);
            Draw();
        }

        private void lvlDownButton_Click(object sender, EventArgs e)
        {
            SaveMemento();
            vectorImage.LevelDown(vectorImage.Figures[vectorImage.SelectedFigure]);
            Draw();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vectorImage.Save(saveFileDialog1.FileName);
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newDlg = new Form2(851, 480);
            if (newDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    CreateNew(newDlg.ImageWidth, newDlg.ImageHeight);
                    selectedFigures = new List<IFigure>();
                    Draw();
                }
                catch (Exception) { }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            SaveMemento();
            foreach (IFigure figure in selectedFigures)
                vectorImage.Figures.Add(figure.Clone());
            Draw();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void размерИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newDlg = new Form2(vectorImage.Width, vectorImage.Height);

            if (newDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    vectorImage.Width = newDlg.ImageWidth;
                    vectorImage.Height = newDlg.ImageHeight;
                    selectedFigures = new List<IFigure>();
                    Draw();
                }
                catch (Exception) { }
            }
        }

        void Serialize(string filename)
        {
            IFormatter formatter = (IFormatter)new BinaryFormatter();

            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, vectorImage);
            stream.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SaveMemento();

            selectedFigures = new List<IFigure>();
            vectorImage.Figures.RemoveAt(vectorImage.SelectedFigure);
            vectorImage.SelectedFigure = -1;

            borderColorButton.BackColor = strokeColor;
            fillColorButton.BackColor = fillColor;
            numericUpDown1.Value = (decimal)strokeWidth;
            panel5.Visible = false;
            stripBtn1.Enabled = false;
            stripBtn2.Enabled = false;
            stripBtn3.Enabled = false;
            stripBtn4.Enabled = false;

            Draw();
        }

        private void borderColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = borderColorButton.BackColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    SaveMemento();
                    foreach (IFigure figure in selectedFigures)
                        figure.StrokeColor = colorDialog1.Color;
                    Draw();
                borderColorButton.BackColor = colorDialog1.Color;
            }
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = fillColorButton.BackColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    SaveMemento();
                    foreach (IFigure figure in selectedFigures)
                        figure.FillColor = colorDialog1.Color;
                    Draw();
                fillColorButton.BackColor = colorDialog1.Color;
            }
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.CurvePath;
            Focus();
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.None;
            Focus();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.Ellipse;
            Focus();
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            currentInstrument = Instrument.Rectangle;
            Focus();
        }

        void Deserialize(string filename)
        {
            IFormatter formatter = (IFormatter)new BinaryFormatter();

            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            vectorImage = (VectorImage)formatter.Deserialize(stream);
            stream.Close();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Serialize(saveFileDialog2.FileName);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                try 
                {
                    Deserialize(openFileDialog1.FileName);
                    selectedFigures = new List<IFigure>();
                    borderColorButton.BackColor = strokeColor;
                    fillColorButton.BackColor = fillColor;
                    numericUpDown1.Value = (decimal)strokeWidth;
                    panel5.Visible = false;
                    stripBtn1.Enabled = false;
                    stripBtn2.Enabled = false;
                    stripBtn3.Enabled = false;
                    stripBtn4.Enabled = false;

                    Draw();
                }
                catch (Exception) 
                {
                    MessageBox.Show("Файл имеет неверный формат");
                }
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
    }
}
