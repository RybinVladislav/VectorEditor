using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Xml;

namespace VectorEditor
{
    public class ImageChangeEventArgs : EventArgs
    {
        private IList<IFigure> figures;

        public IList<IFigure> Figures { get { return figures; } }

        public ImageChangeEventArgs(IList<IFigure> figures)
        {
            this.figures = figures;
        }
    }

    // тип делегата события
    public delegate void ImageChangeEventHandler(object sender, ImageChangeEventArgs e);

    // класс векторного изображения
    public class VectorImage : IDrawable
    {
        //событие высылаемое при изменении свойства Figures
        public event ImageChangeEventHandler OnImageChangeHandler = null;

        private void OnImageChange()
        {
            if (OnImageChangeHandler != null && OnImageChangeHandler.GetInvocationList().Any())
                OnImageChangeHandler(this, new ImageChangeEventArgs(figures));
        }
        
        private IList<IFigure> figures;

        public IList<IFigure> Figures
        {
            get { return figures; }
            set {
                if (value == figures) return;

                figures = value;
                OnImageChange();
            }
        }

        public IFigure InsertingFigure { get; set; }

        public int SelectedFigure { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Color BackgroundColor = Color.Transparent;

        public VectorImage(int width, int height)
        {
            Figures = new List<IFigure>();
            SelectedFigure = -1;
            Width = width;
            Height = height;
        }

        public void AddEllipse(IFigureFactory factory, PointF center, float radiusX, float radiusY, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Figures.Add(factory.CreateEllipse(center, radiusX, radiusY, fillColor, strokeColor, strokeWidth));
            OnImageChange();
        }

        public void AddRectangle(IFigureFactory factory, float top, float left, float width, float height, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Figures.Add(factory.CreateRectangle(top, left, width, height, fillColor, strokeColor, strokeWidth));
            OnImageChange();
        }

        public void AddCurvePath(IFigureFactory factory, PointF start, IList<CurveCoords> curves, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Figures.Add(factory.CreateCurvePath(start, curves, fillColor, strokeColor, strokeWidth));
            OnImageChange();
        }

        /* public void AddPolygon(IFigureFactory factory, IList<PointF> points, Color fillColor, Color strokeColor, float strokeWidth)
        {
            IFigure polygon = factory.CreatePolygon(points, fillColor, strokeColor, strokeWidth);
            if (polygon != null)
                figures.Add(polygon);
        } */

        public void Copy(IEnumerable<IFigure> selectedElements)
        {
            foreach (IFigure element in selectedElements)
                Figures.Add(element.Clone());
        }

        public void Draw(Graphics g, float scale)
        {
            // покраска фона
            if (BackgroundColor == Color.Transparent)
                g.Clear(Color.White);
            else
                g.Clear(BackgroundColor);

            // отрисовка фигур
            foreach (IFigure element in Figures)
                element.Draw(g, scale);

            if (InsertingFigure != null)
                InsertingFigure.Draw(g, scale);

            //отрисовка границ изображения
            Pen p = new Pen(Color.Black, 3F);
            g.DrawLine(p, new PointF(0, 0), new PointF(Width - 1, 0));
            g.DrawLine(p, new PointF(0, Height - 1), new PointF(Width - 1, Height - 1));
            g.DrawLine(p, new PointF(0, 0), new PointF(0, Height - 1));
            g.DrawLine(p, new PointF(Width - 1, 0), new PointF(Width - 1, Height - 1));
        }

        public void SelectFigure(float x, float y, int r)
        {
            if (x > Width || x < 0 || y > Height || y < 0) return;
            SelectedFigure = -1;
            for (int i = figures.Count - 1; i >= 0; i--)
            {
                Bitmap bmp = new Bitmap(Width, Height);
                Graphics g = Graphics.FromImage(bmp);

                g.Clear(Color.White);

                figures[i].Draw(g, 1);

                g.Dispose();

                for (int x0 = Math.Max((int)Math.Round(x) - r, 0); x0 <= x + r; x0++)
                    for (int y0 = Math.Max((int)Math.Round(y) - r, 0); y0 <= y + r; y0++)
                        if (bmp.GetPixel(x0, y0).ToArgb() != Color.White.ToArgb())
                        {
                            SelectedFigure = i;
                            bmp.Dispose();
                            return; 
                        }
                bmp.Dispose();
            }
        }

        public bool CurvePathCheck(float x, float y, int r)
        {
            if (x > Width || x < 0 || y > Height || y < 0) return false;
            for (int i = figures.Count - 1; i >= 0; i--)
            {
                if (figures[i] is ICurvePath)
                {
                    Bitmap bmp = new Bitmap(Width, Height);
                    Graphics g = Graphics.FromImage(bmp);

                    CurvePathDecorator dec = new CurvePathDecorator(figures[i] as ICurvePath);
                    g.Clear(Color.White);
                    figures[i].Draw(g, 1);
                    dec.Draw(g, 1);

                    g.Dispose();

                    for (int x0 = Math.Max((int)Math.Round(x) - r, 0); x0 <= x + r; x0++)
                        for (int y0 = Math.Max((int)Math.Round(y) - r, 0); y0 <= y + r; y0++)
                            if (bmp.GetPixel(x0, y0).ToArgb() != Color.White.ToArgb())
                            {
                                bmp.Dispose();
                                return true;
                            }
                    bmp.Dispose();
                }
            }
            return false;
        }

        public void LevelUp(IFigure f)
        {
            int k = figures.IndexOf(f);
            if (k != -1 && k != figures.Count - 1)
            {
                figures.RemoveAt(k);
                figures.Insert(k + 1, f);
                if (SelectedFigure == k)
                    SelectedFigure = k + 1;
            }
        }

        public void LevelDown(IFigure f)
        {
            int k = figures.IndexOf(f);
            if (k >= 1)
            {
                figures.RemoveAt(k);
                figures.Insert(k - 1, f);
                if (SelectedFigure == k)
                    SelectedFigure = k - 1;
            }
        }

        public void Save(string path)
        {
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter w = new StreamWriter(f);

            w.WriteLine("<?xml version='1.0' encoding='UTF-8'?>\n<!DOCTYPE svg PUBLIC '-//W3C//DTD SVG 1.1//EN' 'http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd'>");
            w.WriteLine("<svg xmlns='http://www.w3.org/2000/svg' version='1.1' height = '{0}px'  width = '{1}px'>", Height, Width);

            foreach (IFigure figure in figures)
                w.WriteLine(figure.Save());

            w.WriteLine("</svg>");

            w.Flush();
            w.Close();
            f.Close();
        }
    }
}
