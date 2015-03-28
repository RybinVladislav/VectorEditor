using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditor
{
    public class Ellipse : Component, IEllipse
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

        public void Draw(Graphics g, float scale)
        {
            g.FillEllipse(new SolidBrush(FillColor), scale * (Center.X - RadiusX), scale * (Center.Y - RadiusY), scale * 2 * RadiusX, scale * 2 * RadiusY);
            g.DrawEllipse(new Pen(StrokeColor, StrokeWidth), scale * (Center.X - RadiusX), scale * (Center.Y - RadiusY), scale * 2 * RadiusX, scale * 2 * RadiusY);
        }
    }

    public class Rectangle : Component, IRectangle
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

        public void Draw(Graphics g, float scale)
        {
            g.FillRectangle(new SolidBrush(FillColor), scale * Left, scale * Top, scale * Width, scale * Height);
            g.DrawRectangle(new Pen(StrokeColor, StrokeWidth), scale * Left, scale * Top, scale * Width, scale * Height);
        }
    }

    public class CurvePath : Component, ICurvePath
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

        public void Draw(Graphics g, float scale)
        {
            PointF[] pointArray = new PointF[1] { new PointF(scale * Start.X, scale * Start.Y) };

            foreach (CurveCoords curve in Curves)
            {
                int n = pointArray.Length;
                Array.Resize(ref pointArray, n + 3);
                pointArray[n] = new PointF(scale * curve.P1.X, scale * curve.P1.Y);
                pointArray[n + 1] = new PointF(scale * curve.P2.X, scale * curve.P2.Y);
                pointArray[n + 2] = new PointF(scale * curve.P.X, scale * curve.P.Y);
            }

            GraphicsPath path = new GraphicsPath();
            path.AddBeziers(pointArray);

            g.FillPath(new SolidBrush(FillColor), path);
            g.DrawPath(new Pen(StrokeColor, StrokeWidth), path);
        }
    }

    /* public class Polygon : Component, IPolygon
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

        public void Draw(Graphics g, float scale)
        {
            PointF[] pointArray = Points.ToArray();
            Array.ForEach(pointArray, (p) => { p = new PointF(p.X * scale, p.Y * scale); });
            g.FillPolygon(new SolidBrush(FillColor), Points.ToArray());
            g.DrawPolygon(new Pen(StrokeColor, StrokeWidth), Points.ToArray());
        }
    } */

	public class CompositeFigure : IComposite
	{
		public IComponent GetChild ()
		{
			throw new NotImplementedException ();
		}

		public void Operation ()
		{
			throw new NotImplementedException ();
		}

		public void Add (IComponent element)
		{
			this.Children.Add (element);
			element.Parent = this;
		}

		public void Remove (IComponent element)
		{
			throw new NotImplementedException ();
		}

		public IComponent Parent
		{
			get
			{
				throw new NotImplementedException ();
			}
			set
			{
				throw new NotImplementedException ();
			}
		}

		public List<IComponent> Children
		{
			get
			{
				throw new NotImplementedException ();
			}
			set
			{
				throw new NotImplementedException ();
			}
		}

        IList<IComponent> IComposite.Children
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
    }
}

