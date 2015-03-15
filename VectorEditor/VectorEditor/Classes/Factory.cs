using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VectorEditor
{
    public interface IFigureFactory {
		IEllipse CreateEllipse(PointF center, float radiusX, float radiusY, Color fillColor, Color strokeColor, float strokeWidth);
		IRectangle CreateRectangle(float top, float left, float width, float height, Color fillColor, Color strokeColor, float strokeWidth);
		ICurvePath CreateCurvePath(PointF start, IList<CurveCoords> curves, Color fillColor, Color strokeColor, float strokeWidth);
		IPolygon CreatePolygon(IList<PointF> points, Color fillColor, Color strokeColor, float strokeWidth);
    }

	public class Factory : IFigureFactory
    {

        public IEllipse CreateEllipse(PointF center, float radiusX, float radiusY, Color fillColor, Color strokeColor, float strokeWidth)
        {
            return new Ellipse(center, radiusX, radiusY, fillColor, strokeColor, strokeWidth);
        }

        public IRectangle CreateRectangle(float top, float left, float width, float height, Color fillColor, Color strokeColor, float strokeWidth)
        {
            return new Rectangle(top, left, width, height, fillColor, strokeColor, strokeWidth);
        }

        public ICurvePath CreateCurvePath(PointF start, IList<CurveCoords> curves, Color fillColor, Color strokeColor, float strokeWidth)
        {
            return new CurvePath(start, curves, fillColor, strokeColor, strokeWidth);
        }

        public IPolygon CreatePolygon(IList<PointF> points, Color fillColor, Color strokeColor, float strokeWidth)
        {
            try
			{
            	return new Polygon(points, fillColor, strokeColor, strokeWidth);
			}
			catch (ArgumentException)
			{
                return null;
			}
        }
    }
}
