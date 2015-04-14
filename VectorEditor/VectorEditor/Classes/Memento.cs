using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditor
{
    public class Memento
    {
        private IList<IFigure> figures;

        public Memento(IList<IFigure> figures)
        {
            this.figures = new List<IFigure>(figures);
        }

        public IList<IFigure> State
        {
            get { return figures; }
        }
    } 

    public class Caretaker
    {
        private Memento memento;

        // Gets or sets memento
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }
}
