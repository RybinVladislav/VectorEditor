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
		void Operation();
		void Add(IComponent element);
		void Remove(IComponent element);
	}
	public interface ILeaf : IComponent
	{
		void Operation ();
	}
}

