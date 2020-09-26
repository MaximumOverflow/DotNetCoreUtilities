using DotNetCoreUtilities.CodeGeneration;

namespace DotNetCoreUtilities.Structures
{
	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T> where T : new()
	{
		private T _value;
		private bool _hasValue;
		
		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = new T();
				_hasValue = true;
				return _value;
			}
		}
		
		public static implicit operator T(in Deferred<T> def) => def.Value;
		public override string ToString() => Value.ToString();
	}
	
	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;

		public Deferred(in TArg0 arg0) : this()
			=> (_arg0) = (arg0);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0>.New(_arg0);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;

		public Deferred(in TArg0 arg0, in TArg1 arg1) : this()
			=> (_arg0, _arg1) = (arg0, arg1);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1>.New(_arg0, _arg1);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2) : this()
			=> (_arg0, _arg1, _arg2) = (arg0, arg1, arg2);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2>.New(_arg0, _arg1, _arg2);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3) : this()
			=> (_arg0, _arg1, _arg2, _arg3) = (arg0, arg1, arg2, arg3);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3>.New(_arg0, _arg1, _arg2, _arg3);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4) = (arg0, arg1, arg2, arg3, arg4);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4>.New(_arg0, _arg1, _arg2, _arg3, _arg4);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5) = (arg0, arg1, arg2, arg3, arg4, arg5);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;
		private readonly TArg10 _arg10;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;
		private readonly TArg10 _arg10;
		private readonly TArg11 _arg11;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;
		private readonly TArg10 _arg10;
		private readonly TArg11 _arg11;
		private readonly TArg12 _arg12;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;
		private readonly TArg10 _arg10;
		private readonly TArg11 _arg11;
		private readonly TArg12 _arg12;
		private readonly TArg13 _arg13;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12, _arg13) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12, _arg13);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;
		private readonly TArg10 _arg10;
		private readonly TArg11 _arg11;
		private readonly TArg12 _arg12;
		private readonly TArg13 _arg13;
		private readonly TArg14 _arg14;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12, _arg13, _arg14) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12, _arg13, _arg14);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> def) => def.Value;
		public override string ToString() => Value.ToString();
	}

	/// <summary>Represents a tpe with a deferred instantiation</summary>
	/// <typeparam name="T">The type to instantiate</typeparam>
	public struct Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
	{
		private T _value;
		private bool _hasValue;
		private readonly TArg0 _arg0;
		private readonly TArg1 _arg1;
		private readonly TArg2 _arg2;
		private readonly TArg3 _arg3;
		private readonly TArg4 _arg4;
		private readonly TArg5 _arg5;
		private readonly TArg6 _arg6;
		private readonly TArg7 _arg7;
		private readonly TArg8 _arg8;
		private readonly TArg9 _arg9;
		private readonly TArg10 _arg10;
		private readonly TArg11 _arg11;
		private readonly TArg12 _arg12;
		private readonly TArg13 _arg13;
		private readonly TArg14 _arg14;
		private readonly TArg15 _arg15;

		public Deferred(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15) : this()
			=> (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12, _arg13, _arg14, _arg15) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

		public T Value
		{
			get
			{
				if (_hasValue) return _value;
				_value = Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>.New(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11, _arg12, _arg13, _arg14, _arg15);
				_hasValue = true;
				return _value;
			}
		}

		public static implicit operator T(in Deferred<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> def) => def.Value;
		public override string ToString() => Value.ToString();
	}
}