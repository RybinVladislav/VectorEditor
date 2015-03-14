using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditor
{
    public class Circle : ICircle 
    {
        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }

    public class Square : ISquare 
    {
        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }

    public class Curve : ICurve 
    {
        public IFigure Clone()
        {
            throw new NotImplementedException();
        }
    }
}
