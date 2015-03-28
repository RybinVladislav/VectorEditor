using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            if (OnImageChangeHandler != null)
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
    }
}
