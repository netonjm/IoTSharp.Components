using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	class ProximitySensorExample
	{
		const int max = 2;
		int count;

		public ProximitySensorExample ()
		{
			var sensor = new ProximitySensor (Connectors.GPIO17);
			sensor.PresenceStatusChanged += (active) => {
				count++;
				Console.WriteLine($"PresenceStatusChanged {3}. {0}/{1}", count, max, active);
			};

			while (count < max) {
				sensor.OnUpdate();
				Thread.Sleep(250);
			}
			sensor.OnDispose ();
		}
	}
}
