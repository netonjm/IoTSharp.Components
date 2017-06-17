using System.Diagnostics;

namespace IoTSharp.Components
{
	public class SpinTimer
	{
		Stopwatch watch;

		public void Start ()
		{
			watch = Stopwatch.StartNew ();
		}

		public long ElapsedMilliseconds {
			get {
				return watch.ElapsedMilliseconds;
			}
		}

		public void Wait (double ms)
		{
			var t = (long)(ms * (double)Stopwatch.Frequency / 1000d);
			var lastTick = watch.ElapsedTicks;
			while ((watch.ElapsedTicks - lastTick) < t) {
			}
		}

		public void WaitUntil (double ms)
		{
			var t = (long)(ms * (double)Stopwatch.Frequency / 1000d);
			var lastTick = watch.ElapsedTicks;
			while (watch.ElapsedTicks < t) {
			}
		}

		public bool Reached (double ms)
		{
			var t = (long)(ms * (double)Stopwatch.Frequency / 1000d);
			return watch.ElapsedTicks >= t;
		}
	}
}
