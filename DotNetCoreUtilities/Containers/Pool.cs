using DotNetCoreUtilities.CodeGeneration;
using System.Collections.Generic;
using System;

namespace DotNetCoreUtilities.Containers
{
	public class Pool<T>
	{
		private readonly List<T> _elements;
		private readonly Func<T> _factory;

		public Pool()
		{
			_elements = new List<T>();
			_factory = Constructor<T>.Ctor;
		}
		
		public Pool(Func<T> factory)
		{
			_elements = new List<T>();
			_factory = factory;
		}

		public void Add(T element) => _elements.Add(element);
		
		public void AddChecked(T element)
		{
			if(!_elements.Contains(element))
				_elements.Add(element);
		}

		public T Take()
		{
			if (_elements.Count == 0) 
				return _factory.Invoke();

			var obj = _elements[^1];
			_elements.RemoveAt(_elements.Count - 1);
			return obj;
		}
	}
	
	public class ConcurrentPool<T>
	{
		private List<T> _elements;
		private Func<T> _factory;

		public ConcurrentPool()
		{
			_elements = new List<T>();
			_factory = Constructor<T>.Ctor;
		}
		
		public ConcurrentPool(Func<T> factory)
		{
			_elements = new List<T>();
			_factory = factory;
		}

		public void Add(T element)
		{
			lock (_elements) _elements.Add(element);
		}

		public void AddChecked(T element)
		{
			lock (_elements)
			{
				if(!_elements.Contains(element))
					_elements.Add(element);
			}
		}

		public T Take()
		{
			if (_elements.Count == 0)
				return _factory.Invoke();
			
			lock (_elements)
			{
				var obj = _elements[^1];
				_elements.RemoveAt(_elements.Count - 1);
				return obj;
			}
		}
	}
}