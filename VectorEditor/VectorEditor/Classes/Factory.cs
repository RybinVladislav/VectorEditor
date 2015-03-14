using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditor.Classes
{
    public interface IFigureFactory {
        ICircle CreateCircle();
        ISquare CreateSquare();
        ICurve CreateCurve();
    }

    public class Factory : IFigureFactory
    {
        public ICircle CreateCircle()
        {
            throw new NotImplementedException();
        }

        public ISquare CreateSquare()
        {
            throw new NotImplementedException();
        }

        public ICurve CreateCurve()
        {
            throw new NotImplementedException();
        }
    }
}
