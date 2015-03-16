using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VectorEditor
{
    public class VectorImage : IDrawable
    {
        private IList<IFigure> figures;

        public IList<IFigure> Figures
        {
            get { return figures; }
            set { figures = value; }
        }

        public IFigure InsertingFigure { get; set; }

        private int selectedFigure;

        public VectorImage()
        {
            figures = new List<IFigure>();
        }

        public void AddEllipse(IFigureFactory factory, PointF center, float radiusX, float radiusY, Color fillColor, Color strokeColor, float strokeWidth)
        {
            figures.Add(factory.CreateEllipse(center, radiusX, radiusY, fillColor, strokeColor, strokeWidth));
        }

        public void AddRectangle(IFigureFactory factory, float top, float left, float width, float height, Color fillColor, Color strokeColor, float strokeWidth)
        {
            figures.Add(factory.CreateRectangle(top, left, width, height, fillColor, strokeColor, strokeWidth));
        }

        public void AddCurvePath(IFigureFactory factory, PointF start, IList<CurveCoords> curves, Color fillColor, Color strokeColor, float strokeWidth)
        {
            figures.Add(factory.CreateCurvePath(start, curves, fillColor, strokeColor, strokeWidth));
        }

        public void AddPolygon(IFigureFactory factory, IList<PointF> points, Color fillColor, Color strokeColor, float strokeWidth)
        {
            IFigure polygon = factory.CreatePolygon(points, fillColor, strokeColor, strokeWidth);
            if (polygon != null)
                figures.Add(polygon);
        }

        public void Copy(IEnumerable<IFigure> selectedElements)
        {
            foreach (IFigure element in selectedElements)
                figures.Add(element.Clone());
        }

        public void Draw(Graphics g, float scale)
        {
            foreach (IFigure element in Figures)
                element.Draw(g, scale);

            if (InsertingFigure != null)
                InsertingFigure.Draw(g, scale);
        }
    }
}
