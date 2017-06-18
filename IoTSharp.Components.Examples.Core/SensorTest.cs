using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	class SensorHubTest
	{
		const int max = 2;
		int count;

		public SensorHubTest ()
		{
			var sensor = new IoTSensor(Connectors.GPIO17);
			sensor.PresenceStatusChanged += (active) => {
				count++;
				Console.WriteLine($"PresenceStatusChanged {3}. {0}/{1}", count, max, active);
			};

			while (count < max) {
				sensor.Update();
				Thread.Sleep(250);

			}
			sensor.Dispose ();
		}
	}
}
