using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class DhtSensorExample
	{
		public DhtSensorExample ()
		{
			var dht = new DhtSensor (Connectors.GPIO4, DhtModel.Dht11);
			dht.Start ();
			while (true) {
				Console.WriteLine ("Humidity: {0} Temperature: {1}", dht.Humidity, dht.Temperature);
				Thread.Sleep (1000);
			}
		}
	}
}