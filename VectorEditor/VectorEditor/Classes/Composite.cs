using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VectorEditor
{
    //as soon as we add something to a Component we probably should 
    //promote it to a Composite (or not)
    public interface IComponent
    {
        IComponent Parent { get; set; }
        void Operation();
        void Add(IComponent element);
        void Remove(IComponent element);
    }

    public class Component : IComponent
    {
        public void Operation()
        {
            throw new NotImplementedException();
        }

        public void Add(IComponent element)
        {
            throw new NotImplementedException();
        }

        public void Remove(IComponent element)
        {
            throw new NotImplementedException();
        }

        public IComponent Parent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

    public interface IComposite : IComponent
    {
        new IComponent Parent { get; set; }
        IList<IComponent> Children { get; set; }
        new void Operation();
        new void Add(IComponent element);
        new void Remove(IComponent element);
        IComponent GetChild();
    }

    //some books question the necessity of ILeaf 
    //пока оставлю его на всякий случай
    public interface ILeaf : IComponent
    {
        new void Operation();
    }
}