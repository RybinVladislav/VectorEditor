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

    public interface ILine : IFigure
    {
        PointF P1 { get; set; }
        PointF P2 { get; set; }
    }

    public interface ICurveCoords
    {
        // control points
        PointF P1 { get; set; }
        PointF P2 { get; set; }

        // end of curve
        PointF P { get; set; }
    }

    public interface ICurve : IFigure 
    {
        PointF Start { get; set; }

        IList<ICurveCoords> Curves { get; set; }
    }

    public interface IPolygon : IFigure 
    {
        IList<PointF> Points { get; set; }
    }

}
