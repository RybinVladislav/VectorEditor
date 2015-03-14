using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VectorEditor.Classes
{
    public interface IFigureFactory {
        IEllipse CreateEllipse();
        IRectangle CreateRectangle();
        ILine CreateLine();
        ICurve CreateCurve();
        IPolygon CreatePolygon();
    }

    public class Factory : IFigureFactory
    {
        public IEllipse CreateEllipse()
        {
            throw new NotImplementedException();
        }

        public IRectangle CreateRectangle()
        {
            throw new NotImplementedException();
        }

        public ILine CreateLine()
        {
            throw new NotImplementedException();
        }

        public ICurve CreateCurve()
        {
            throw new NotImplementedException();
        }

        public IPolygon CreatePolygon()
        {
            throw new NotImplementedException();
        }
    }
}
