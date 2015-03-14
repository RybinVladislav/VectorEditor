using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditor
{
    public interface IFigure {
        IFigure Clone();
    }

    public interface ICircle : IFigure { 
    }

    public interface ISquare : IFigure {
    }

    public interface ICurve : IFigure { 
    }

}
