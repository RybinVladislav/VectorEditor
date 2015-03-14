using System;

namespace VectorEditor
{
	public interface IComponent
	{
		void Operation();
		void Add(IComponent element);
		void Remove(IComponent element);
	}

	public interface IComposite : IComponent
	{
		new void Operation();
		new void Add(IComponent element);
		new void Remove(IComponent element);
	}
	public interface ILeaf : IComponent
	{
		new void Operation ();
	}
}

