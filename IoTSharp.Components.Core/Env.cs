using System;

namespace IoTSharp
{
	public static class Env
	{
		public readonly static INativeTiming Timing;

		static Env()
		{
			Timing = new NativeTiming();
		}
	}
}