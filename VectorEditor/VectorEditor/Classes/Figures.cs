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

        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }

    public class Line : ILine
    {
        public PointF P1
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public PointF P2
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color FillColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color StrokeColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float StrokeWidth
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }

    public class Curve : ICurve 
    {
        public PointF Start
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<ICurveCoords> Curves
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color FillColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color StrokeColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float StrokeWidth
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }

    public class Polygon : IPolygon
    {
        public IList<PointF> Points
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color FillColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color StrokeColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float StrokeWidth
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }
}
