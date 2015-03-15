using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VectorEditor
{
    public interface IFigure 
    {
        Color FillColor { get; set; }
        Color StrokeColor { get; set; }

        float StrokeWidth { get; set; }

        IFigure Clone();
    }

    public interface IEllipse : IFigure 
    {
        PointF Center { get; set; }

        float RadiusX { get; set; }
        float RadiusY { get; set; }

    }

    public interface IRectangle : IFigure 
    {
        float Top { get; set; }
        float Left { get; set; }
   
        float Width { get; set; }
        float Height { get; set; }
    }

    public struct CurveCoords
    {
        public PointF P1;
        public PointF P2;
        public PointF P;

        public CurveCoords(PointF p1, PointF p2, PointF p)
        {
            P1 = p1;
            P2 = p2;
            P = p;
        }
    }

    public interface ICurvePath : IFigure 
    {
        PointF Start { get; set; }

        IList<CurveCoords> Curves { get; set; }
    }

    public interface IPolygon : IFigure 
    {
        IList<PointF> Points { get; set; }
    }

}
