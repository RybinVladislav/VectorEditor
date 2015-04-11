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


        public string Save()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            return string.Format("<ellipse cx='{0}' cy='{1}' rx='{2}' ry='{3}' fill='{4}' stroke='{5}' stroke-width='{6}'></ellipse>",
                Center.X, Center.Y, RadiusX, RadiusY, ColorTranslator.ToHtml(FillColor), ColorTranslator.ToHtml(StrokeColor), StrokeWidth);
        }

        public PointF MouseMove(Point e, PointF p, PointF p0)
        {
            if ((p0.X - p.X >= Center.X - RadiusX - 4) && (p0.X - p.X <= Center.X - RadiusX + 4) &&
                (p0.Y - p.Y >= Center.Y - 4) && (p0.Y - p.Y <= Center.Y + 4))
            {
                RadiusX += p0.X - e.X;

                if (RadiusX < 0) RadiusX = -RadiusX;

                return new PointF(e.X, p0.Y);
            }
            else
                if ((p0.X - p.X >= Center.X - 4) && (p0.X - p.X <= Center.X + 4) &&
                (p0.Y - p.Y >= Center.Y - RadiusY - 4) && (p0.Y - p.Y <= Center.Y - RadiusY + 4))
                {
                    RadiusY += p0.Y - e.Y;

                    if (RadiusY < 0) RadiusY = -RadiusY;

                    return new PointF(p0.X, e.Y);
                }
                else
                {
                    Center = new PointF(Center.X - p0.X + e.X, Center.Y - p0.Y + e.Y);
                    return new PointF(e.X, e.Y);
                }
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

        public string Save()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            return string.Format("<rect x='{0}' y='{1}' width='{2}' height='{3}' fill='{4}' stroke='{5}' stroke-width='{6}'></rect>",
                Left, Top, Width, Height, ColorTranslator.ToHtml(FillColor), ColorTranslator.ToHtml(StrokeColor), StrokeWidth);
        }


        public PointF MouseMove(Point e, PointF p, PointF p0)
        {
            if ((p0.X - p.X >= Left - 4) && (p0.X - p.X <= Left + 4) && (p0.Y - p.Y >= Top - 4) && (p0.Y - p.Y <= Top + 4))
            {
                Left += -p0.X + e.X;
                Top += -p0.Y + e.Y;
                Width += p0.X - e.X;
                Height += p0.Y - e.Y;

                if (Width < 0)
                {
                    Left += Width;
                    Width = -Width;
                }

                if (Height < 0)
                {
                    Top += Height;
                    Height = -Height;
                }

                return new PointF(e.X, e.Y);
            }
            else
                if ((p0.X - p.X >= Left + Width - 4) &&
                (p0.X - p.X <= Left + Width + 4) &&
                (p0.Y - p.Y >= Top + Height - 4) &&
                (p0.Y - p.Y <= Top + Height + 4))
                {
                    Width += e.X - p0.X;
                    Height += e.Y - p0.Y;

                    if (Width < 0)
                    {
                        Left += Width;
                        Width = -Width;
                    }

                    if (Height < 0)
                    {
                        Top += Height;
                        Height = -Height;
                    }

                    return new PointF(e.X, e.Y);
                }
                else
                {
                    Left += -p0.X + e.X;
                    Top += -p0.Y + e.Y;

                    return new PointF(e.X, e.Y);
                }
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


        public string Save()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string s = string.Format("<path d='M{0} {1} ", Start.X, Start.Y);
            foreach (CurveCoords curve in Curves)
            {
                s += string.Format("C{0} {1}, {2} {3}, {4} {5} ", curve.P1.X, curve.P1.Y, curve.P2.X, curve.P2.Y, curve.P.X, curve.P.Y);
            }
            s += string.Format("' fill='{0}' stroke='{1}' stroke-width='{2}'></path>", ColorTranslator.ToHtml(FillColor), ColorTranslator.ToHtml(StrokeColor), StrokeWidth);
            return s;
        }


        public PointF MouseMove(Point e, PointF p, PointF p0)
        {
            // проверка на перемещение начала
            if ((p0.X - p.X >= Start.X - 4) && (p0.X - p.X <= Start.X + 4) && (p0.Y - p.Y >= Start.Y - 4) && (p0.Y - p.Y <= Start.Y + 4))
            {
                PointF oldSt = Start;

                Start = new PointF(Start.X - p0.X + e.X, Start.Y - p0.Y + e.Y);

                Curves[0] = new CurveCoords(Start, Start, Start);

                if (oldSt == Curves[Curves.Count - 1].P)
                    Curves[Curves.Count - 1] = new CurveCoords(Curves[Curves.Count - 1].P1, Curves[Curves.Count - 1].P2, Start);
                
                return new PointF(e.X, e.Y);
            }

            // проверка на перемещение узлов
            for (int i = 1; i < Curves.Count; i++)
            {
                if ((p0.X - p.X >= Curves[i].P.X - 4) &&
                    (p0.X - p.X <= Curves[i].P.X + 4) &&
                    (p0.Y - p.Y >= Curves[i].P.Y - 4) &&
                    (p0.Y - p.Y <= Curves[i].P.Y + 4))
                {
                    Curves[i] = new CurveCoords(Curves[i].P1, Curves[i].P2, new PointF(Curves[i].P.X - p0.X + e.X, Curves[i].P.Y - p0.Y + e.Y));

                    return new PointF(e.X, e.Y);
                }
            }

            // проверка на перемещение опорных точек
            for (int i = 1; i < Curves.Count; i++)
            {
                if ((p0.X - p.X >= Curves[i].P1.X - 4) && (p0.X - p.X <= Curves[i].P1.X + 4) &&
                    (p0.Y - p.Y >= Curves[i].P1.Y - 4) && (p0.Y - p.Y <= Curves[i].P1.Y + 4))
                {

                    Curves[i] = new CurveCoords(new PointF(Curves[i].P1.X - p0.X + e.X, Curves[i].P1.Y - p0.Y + e.Y), Curves[i].P2, Curves[i].P);

                    return new PointF(e.X, e.Y);
     
                    //isMovingCurve = true;
                }

                if ((p0.X - p.X >= Curves[i].P2.X - 4) && (p0.X - p.X <= Curves[i].P2.X + 4) &&
                    (p0.Y - p.Y >= Curves[i].P2.Y - 4) && (p0.Y - p.Y <= Curves[i].P2.Y + 4))
                {

                    Curves[i] = new CurveCoords(Curves[i].P1, new PointF(Curves[i].P2.X - p0.X + e.X, Curves[i].P2.Y - p0.Y + e.Y), Curves[i].P);

                    return new PointF(e.X, e.Y);
                    
                    //isMovingCurve = true;
                }
            }
            
            Start = new PointF(Start.X + e.X - p0.X, Start.Y + e.Y - p0.Y);

            for (int i = 0; i < Curves.Count; i++)
                Curves[i] = new CurveCoords(
                            new PointF(Curves[i].P1.X - p0.X + e.X, Curves[i].P1.Y - p0.Y + e.Y),
                            new PointF(Curves[i].P2.X - p0.X + e.X, Curves[i].P2.Y - p0.Y + e.Y),
                            new PointF(Curves[i].P.X - p0.X + e.X, Curves[i].P.Y - p0.Y + e.Y)
                        );

            return new PointF(e.X, e.Y);           
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

