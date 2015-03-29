using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditor
{    
    public class FigureDecoratorBase : IFigure
    {
        protected readonly IFigure figure;

        public FigureDecoratorBase(IFigure figure)
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
    }

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
}
