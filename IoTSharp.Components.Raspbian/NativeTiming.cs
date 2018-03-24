using IoTSharp.Components;
using Unosquare.RaspberryIO.Native;

namespace IoTSharp
{
	public class NativeTiming : INativeTiming
	{
		/// <summary>
		/// This causes program execution to pause for at least howLong milliseconds. 
		/// Due to the multi-tasking nature of Linux it could be longer. 
		/// Note that the maximum delay is an unsigned 32-bit integer or approximately 49 days.
		/// </summary>
		/// <param name="value">The value.</param>
		public void SleepMilliseconds(int value)
		{
			WiringPi.delay((uint)value);
		}

		/// <summary>
		/// This causes program execution to pause for at least howLong microseconds. 
		/// Due to the multi-tasking nature of Linux it could be longer. 
		/// Note that the maximum delay is an unsigned 32-bit integer microseconds or approximately 71 minutes.
		/// Delays under 100 microseconds are timed using a hard-coded loop continually polling the system time, 
		/// Delays over 100 microseconds are done using the system nanosleep() function – 
		/// You may need to consider the implications of very short delays on the overall performance of the system, 
		/// especially if using threads.
		/// </summary>
		/// <param name="value">The value.</param>
		public void SleepMicroseconds(int value)
		{
			WiringPi.delayMicroseconds((uint)value);
		}

		public void SetThreadPriority(int priority)
		{
			Timing.SetThreadPriority(priority);
		}
	}
}
