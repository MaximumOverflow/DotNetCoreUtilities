using System;

namespace DotNetCoreUtilities.Structures
{
	/// <summary>An allocation free version of the Stopwatch class in System.Diagnostics</summary>
	public struct Stopwatch
	{
		private DateTime _start;
		private DateTime _stop;
		private TimeSpan _elapsed;
		public bool IsRunning { get; private set; }

		public void Start()
		{
			_start = DateTime.Now;
			IsRunning = true;
		}

		public void Restart()
		{
			_start = DateTime.Now;
			_elapsed = new TimeSpan();
			IsRunning = true;
		}

		public void Stop()
		{
			_stop = DateTime.Now;
			_elapsed += _stop - _start;
			IsRunning = false;
		}

		public long ElapsedTicks => Elapsed.Ticks;
		public long ElapsedMilliseconds => (long) Elapsed.TotalMilliseconds;

		public TimeSpan Elapsed => IsRunning
			? DateTime.Now.Subtract(_start)
			: _elapsed;

		public static Stopwatch StartNew()
		{
			var sw = new Stopwatch();
			sw.Start();
			return sw;
		}
	}
}