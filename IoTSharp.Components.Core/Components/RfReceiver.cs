using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IoTSharp.Components
{
	public class RfReceiver : IoTComponent, IRfReceiver
	{
		public IRfSample Sample { get; private set; }
		readonly IoTPin pin;

		public RfReceiver (Connectors gpio)
		{
			pin = new IoTPin (gpio);
			pin.SetDirection (IoTPinDirection.DirectionIn);
			pin.SetActiveType (IoTActiveType.ActiveLow);
		}

		public void Record (double recTime)
		{
			var switchTimes = new List<double> (10000);
			long loops = 0;
			try {
				bool current = false;
				long lastReport = -1;
				Console.WriteLine ("Recording... ");
				var tm = Stopwatch.StartNew ();
				long startTime = tm.ElapsedTicks;
				while (tm.Elapsed.TotalSeconds < recTime) {
					var v = pin.Value;

					if (current != v) {
						var t = tm.ElapsedTicks;
						if (!current && switchTimes.Count == 0) {
							current = v;
							startTime = t;
							continue;
						}
						switchTimes.Add (((double)(t - startTime) * 1000d) / (double)Stopwatch.Frequency);
						current = v;
					}

					if (tm.ElapsedMilliseconds - lastReport > 1000) {
						lastReport = tm.ElapsedMilliseconds;
						Console.WriteLine ("* " + switchTimes.Count);
					}
					loops++;
				}
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}

			Sample = new RfSample (switchTimes.ToArray ());
		}

		public override void OnDispose ()
		{
			pin.Close ();
			base.OnDispose ();
		}
	}
}
