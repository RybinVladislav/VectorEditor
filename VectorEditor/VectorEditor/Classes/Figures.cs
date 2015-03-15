using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VectorEditor
{
    public class Ellipse : IEllipse 
    {
        public PointF Center { get; set; }

        public float RadiusX { get; set; }

        public float RadiusY { get; set; }

        public Color FillColor { get; set; }

        public Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public Ellipse(PointF center, float radiusX, float radiusY, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Center = center;
            RadiusX = radiusX;
            RadiusY = radiusY;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public Ellipse(PointF center, float radiusX, float radiusY, Color fillColor, Color strokeColor)
            : this(center, radiusX, radiusY, fillColor, strokeColor, 1F) { }
        public Ellipse(PointF center, float radiusX, float radiusY)
            : this(center, radiusX, radiusY, Color.Transparent, Color.Black, 1F) { }

        public IFigure Clone()
        {
            return new Ellipse(Center, RadiusX, RadiusY, FillColor, StrokeColor, StrokeWidth);
        }
    }

    public class Rectangle : IRectangle 
    {
        public float Top { get; set; }

        public float Left { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public Color FillColor { get; set; }

        public Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public Rectangle(float top, float left, float width, float height, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public Rectangle(float top, float left, float width, float height, Color fillColor, Color strokeColor)
            : this(top, left, width, height, fillColor, strokeColor, 1F) { }
        public Rectangle(float top, float left, float width, float height)
            : this(top, left, width, height, Color.Transparent, Color.Black, 1F) { }

        public IFigure Clone()
        {
            return new Rectangle(Top, Left, Width, Height, FillColor, StrokeColor, StrokeWidth);
        }
    }


    public class CurvePath : ICurvePath 
    {
        public PointF Start { get; set; }

        public IList<CurveCoords> Curves { get; set; }

        public Color FillColor { get; set; }

        public Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public CurvePath(PointF start, IList<CurveCoords> curves, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Start = start;
            Curves = curves;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public CurvePath(PointF start, IList<CurveCoords> curves, Color fillColor, Color strokeColor)
            : this(start, curves, fillColor, strokeColor, 1F) { }
        public CurvePath(PointF start, IList<CurveCoords> curves)
            : this(start, curves, Color.Transparent, Color.Black, 1F) { }
        
        public CurvePath(PointF start, CurveCoords curve, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Start = start;
            Curves = new List<CurveCoords>();
            Curves.Add(curve);
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public CurvePath(PointF start, CurveCoords curve, Color fillColor, Color strokeColor)
            : this(start, curve, fillColor, strokeColor, 1F) { }
        public CurvePath(PointF start, CurveCoords curve)
            : this(start, curve, Color.Transparent, Color.Black, 1F) { }

        public CurvePath(PointF start, Color fillColor, Color strokeColor, float strokeWidth)
        {
            Start = start;
            Curves = new List<CurveCoords>();
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public CurvePath(PointF start, Color fillColor, Color strokeColor)
            : this(start, fillColor, strokeColor, 1F) { }
        public CurvePath(PointF start)
            : this(start, Color.Transparent, Color.Black, 1F) { }

        public IFigure Clone()
        {
            return new CurvePath(Start, Curves, FillColor, StrokeColor, StrokeWidth);
        }
    }

    public class Polygon : IPolygon
    {
        public IList<PointF> Points { get; set; }

        public Color FillColor { get; set; }

        public Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public Polygon(IList<PointF> points, Color fillColor, Color strokeColor, float strokeWidth)
        {
            if (points.Count < 3) throw new ArgumentException();
            Points = points;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public Polygon(IList<PointF> points, Color fillColor, Color strokeColor)
            : this(points, fillColor, strokeColor, 1F) { }
        public Polygon(IList<PointF> points)
            : this(points, Color.Transparent, Color.Black, 1F) { }

        public IFigure Clone()
        {
            return new Polygon(Points, FillColor, StrokeColor, StrokeWidth);
        }
    }
}
