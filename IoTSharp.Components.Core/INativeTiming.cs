using System;
namespace IoTSharp
{
	public interface INativeTiming
	{
		void SleepMilliseconds(int value);
		void SleepMicroseconds(int value);
		void SetThreadPriority(int priority);
	}
}
