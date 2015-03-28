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
            //figure.Draw(g, scale);
            g.FillRectangle(Brushes.White, Center.X - RadiusX - 4, Center.Y - 4, 8, 8);
            g.DrawRectangle(Pens.Black, Center.X - RadiusX - 4, Center.Y - 4, 8, 8);
            g.FillRectangle(Brushes.White, Center.X - 4, Center.Y - RadiusY - 4, 8, 8);
            g.DrawRectangle(Pens.Black, Center.X - 4, Center.Y - RadiusY - 4, 8, 8);
        }
    }
}
