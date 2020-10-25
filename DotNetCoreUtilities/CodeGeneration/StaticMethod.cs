using DotNetCoreUtilities.Miscellaneous;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace DotNetCoreUtilities.CodeGeneration
{
	public static class StaticMethod<T, TOut>
	{
		public delegate TOut MethodDelegate();
		private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();

		public static TOut Call(string name) => Get(name).Invoke();

		public static MethodDelegate Get(string name)
		{
			if (_delegates.TryGetValue(name, out var method))
				return method;

			lock (_delegates)
			{
				var type = TypeInfo<T>.Type;
				var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
				if (methodInfo == null) throw new MissingMethodException();
				
				method = methodInfo.CreateDelegate<MethodDelegate>();
				_delegates.Add(name, method);
			}

			return method;
		}
	}
	
    public static class StaticMethod<T, TOut, TIn0>
    {
        public delegate TOut MethodDelegate(TIn0 arg0);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0) => Get(name).Invoke(arg0);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1) => Get(name).Invoke(arg0, arg1);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2) => Get(name).Invoke(arg0, arg1, arg2);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3) => Get(name).Invoke(arg0, arg1, arg2, arg3);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var inType13 = TypeInfo<TIn13>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12, inType13}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var inType13 = TypeInfo<TIn13>.Type;
                var inType14 = TypeInfo<TIn14>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12, inType13, inType14}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticMethod<T, TOut, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>
    {
        public delegate TOut MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14, TIn15 arg15);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static TOut Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14, TIn15 arg15) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var inType13 = TypeInfo<TIn13>.Type;
                var inType14 = TypeInfo<TIn14>.Type;
                var inType15 = TypeInfo<TIn15>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12, inType13, inType14, inType15}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }
    
    public static class StaticVoidMethod<T>
    {
        public delegate void MethodDelegate();
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();

        public static void Call(string name) => Get(name).Invoke();

        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method))
                return method;

            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }

            return method;
        }
    }
    
    public static class StaticVoidMethod<T, TIn0>
    {
        public delegate void MethodDelegate(TIn0 arg0);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0) => Get(name).Invoke(arg0);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1) => Get(name).Invoke(arg0, arg1);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2) => Get(name).Invoke(arg0, arg1, arg2);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3) => Get(name).Invoke(arg0, arg1, arg2, arg3);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var inType13 = TypeInfo<TIn13>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12, inType13}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var inType13 = TypeInfo<TIn13>.Type;
                var inType14 = TypeInfo<TIn14>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12, inType13, inType14}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

    public static class StaticVoidMethod<T, TIn0, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>
    {
        public delegate void MethodDelegate(TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14, TIn15 arg15);
        private static Dictionary<string, MethodDelegate> _delegates = new Dictionary<string, MethodDelegate>();
        
        public static void Call(string name, TIn0 arg0, TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5, TIn6 arg6, TIn7 arg7, TIn8 arg8, TIn9 arg9, TIn10 arg10, TIn11 arg11, TIn12 arg12, TIn13 arg13, TIn14 arg14, TIn15 arg15) => Get(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        
        public static MethodDelegate Get(string name)
        {
            if (_delegates.TryGetValue(name, out var method)) return method;
            
            lock (_delegates)
            {
                var type = TypeInfo<T>.Type;
                var inType0 = TypeInfo<TIn0>.Type;
                var inType1 = TypeInfo<TIn1>.Type;
                var inType2 = TypeInfo<TIn2>.Type;
                var inType3 = TypeInfo<TIn3>.Type;
                var inType4 = TypeInfo<TIn4>.Type;
                var inType5 = TypeInfo<TIn5>.Type;
                var inType6 = TypeInfo<TIn6>.Type;
                var inType7 = TypeInfo<TIn7>.Type;
                var inType8 = TypeInfo<TIn8>.Type;
                var inType9 = TypeInfo<TIn9>.Type;
                var inType10 = TypeInfo<TIn10>.Type;
                var inType11 = TypeInfo<TIn11>.Type;
                var inType12 = TypeInfo<TIn12>.Type;
                var inType13 = TypeInfo<TIn13>.Type;
                var inType14 = TypeInfo<TIn14>.Type;
                var inType15 = TypeInfo<TIn15>.Type;
                var methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, 
                    null, CallingConventions.Any, 
                    new []{inType0, inType1, inType2, inType3, inType4, inType5, inType6, inType7, inType8, inType9, inType10, inType11, inType12, inType13, inType14, inType15}, null);
                if (methodInfo == null) throw new MissingMethodException();
                
                method = methodInfo.CreateDelegate<MethodDelegate>();
                _delegates.Add(name, method);
            }
            
            return method;
        }
    }

}