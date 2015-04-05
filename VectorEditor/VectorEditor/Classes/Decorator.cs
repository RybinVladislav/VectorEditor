using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditor
{    
    public class EllipseDecoratorBase : IEllipse
    {
        protected readonly IEllipse figure;

        public EllipseDecoratorBase(IEllipse figure)
        {
            this.figure = figure;
        }
        
        public PointF Center
        {
            get { return figure.Center; }
            set { figure.Center = value; }
        }

        public float RadiusX
        {
            get { return figure.RadiusX; }
            set { figure.RadiusX = value; }
        }

        public float RadiusY
        {
            get { return figure.RadiusY; }
            set { figure.RadiusY = value; }
        }

        public Color FillColor
        {
            get { return figure.FillColor; }
            set { figure.FillColor = value; }
        }

        public Color StrokeColor
        {
            get { return figure.StrokeColor; }
            set { figure.StrokeColor = value; }
        }

        public float StrokeWidth
        {
            get { return figure.StrokeWidth; }
            set { figure.StrokeWidth = value; }
        }

        public IFigure Clone()
        {
            return figure.Clone();
        }

        public virtual void Draw(Graphics g, float scale)
        {
            figure.Draw(g, scale);
        }

        public string Save()
        {
            return figure.Save();
        }
    }

    public class EllipseDecorator : EllipseDecoratorBase
    {
        public EllipseDecorator(IEllipse figure) : base(figure) { }

        public override void Draw(Graphics g, float scale)
        {
            Pen p = new Pen(Color.Black, 1F);
            p.DashStyle = DashStyle.Dash;
            g.DrawRectangle(p, Center.X - RadiusX - 1, Center.Y - RadiusY - 1, RadiusX * 2 + 2, RadiusY * 2 + 2);
            
            g.FillRectangle(Brushes.White, Center.X - RadiusX - 4, Center.Y - 4, 8, 8);
            g.DrawRectangle(Pens.Black, Center.X - RadiusX - 4, Center.Y - 4, 8, 8);
            g.FillRectangle(Brushes.White, Center.X - 4, Center.Y - RadiusY - 4, 8, 8);
            g.DrawRectangle(Pens.Black, Center.X - 4, Center.Y - RadiusY - 4, 8, 8);
        }
    }

    public class RectangleDecoratorBase : IRectangle
    {
        protected readonly IRectangle figure;

        public RectangleDecoratorBase(IRectangle figure)
        {
            this.figure = figure;
        }

        public Color FillColor
        {
            get { return figure.FillColor; }
            set { figure.FillColor = value; }
        }

        public Color StrokeColor
        {
            get { return figure.StrokeColor; }
            set { figure.StrokeColor = value; }
        }

        public float StrokeWidth
        {
            get { return figure.StrokeWidth; }
            set { figure.StrokeWidth = value; }
        }

        public IFigure Clone()
        {
            return figure.Clone();
        }

        public virtual void Draw(Graphics g, float scale)
        {
            figure.Draw(g, scale);
        }

        public float Top
        {
            get { return figure.Top; }
            set { figure.Top = value; }
        }

        public float Left
        {
            get { return figure.Left; }
            set { figure.Left = value; }
        }

        public float Width
        {
            get { return figure.Width; }
            set { figure.Width = value; }
        }

        public float Height
        {
            get { return figure.Height; }
            set { figure.Height = value; }
        }

        public string Save()
        {
            return figure.Save();
        }
    }

    public class RectangleDecorator : RectangleDecoratorBase
    {
        public RectangleDecorator(IRectangle figure) : base(figure) { }

        public override void Draw(Graphics g, float scale)
        {
            Pen p = new Pen(Color.Black, 1F);
            p.DashStyle = DashStyle.Dash;
            g.DrawRectangle(p, Left - 1, Top - 1, Width + 2, Height + 2);

            g.FillRectangle(Brushes.White, Left - 4, Top - 4, 8, 8);
            g.DrawRectangle(Pens.Black, Left - 4, Top - 4, 8, 8);
            g.FillRectangle(Brushes.White, Left + Width - 4, Top + Height - 4, 8, 8);
            g.DrawRectangle(Pens.Black, Left + Width - 4, Top + Height - 4, 8, 8);
        }
    }

    public class CurvePathDecoratorBase : ICurvePath
    {
        protected readonly ICurvePath figure;

        public CurvePathDecoratorBase(ICurvePath figure)
        {
            this.figure = figure;
        }

        public Color FillColor
        {
            get { return figure.FillColor; }
            set { figure.FillColor = value; }
        }

        public Color StrokeColor
        {
            get { return figure.StrokeColor; }
            set { figure.StrokeColor = value; }
        }

        public float StrokeWidth
        {
            get { return figure.StrokeWidth; }
            set { figure.StrokeWidth = value; }
        }

        public IFigure Clone()
        {
            return figure.Clone();
        }

        public virtual void Draw(Graphics g, float scale)
        {
            figure.Draw(g, scale);
        }

        public PointF Start
        {
            get { return figure.Start; }
            set { figure.Start = value; }
        }

        public IList<CurveCoords> Curves
        {
            get { return figure.Curves; }
            set { figure.Curves = value; }
        }

        public string Save()
        {
            return figure.Save();
        }
    }

    public class CurvePathDecorator : CurvePathDecoratorBase
    {
        public CurvePathDecorator(ICurvePath figure) : base(figure) { }

        public override void Draw(Graphics g, float scale)
        {
            PointF prev = Start;

            for (int i = 0; i < Curves.Count; i++)
            {
                g.DrawLine(Pens.Black, prev, Curves[i].P1);
                g.DrawLine(Pens.Black, Curves[i].P2, Curves[i].P);
                prev = Curves[i].P;
            }

            for (int i = 1; i < Curves.Count; i++)
            {
                g.FillRectangle(Brushes.White, Curves[i].P.X - 4, Curves[i].P.Y - 4, 8, 8);
                g.DrawRectangle(Pens.Black, Curves[i].P.X - 4, Curves[i].P.Y - 4, 8, 8);

                g.FillEllipse(Brushes.White, Curves[i].P1.X - 3, Curves[i].P1.Y - 3, 6, 6);
                g.DrawEllipse(Pens.Black, Curves[i].P1.X - 3, Curves[i].P1.Y - 3, 6, 6);

                g.FillEllipse(Brushes.White, Curves[i].P2.X - 3, Curves[i].P2.Y - 3, 6, 6);
                g.DrawEllipse(Pens.Black, Curves[i].P2.X - 3, Curves[i].P2.Y - 3, 6, 6);
            }

            if (Curves[Curves.Count - 1].P != Start)
            {
                g.FillRectangle(Brushes.White, Start.X - 4, Start.Y - 4, 8, 8);
                g.DrawRectangle(Pens.Black, Start.X - 4, Start.Y - 4, 8, 8);
            }
        }
    }
}
