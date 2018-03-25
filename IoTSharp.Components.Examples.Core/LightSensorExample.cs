using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class LightSensorExample
	{
		public LightSensorExample()
		{
			var sensor = new LightSensor (Connectors.GPIO17);
			sensor.Start ();
			Console.WriteLine ("Light:");
			for (int i = 0; i < 500; i++)
			{
				Console.WriteLine (sensor.Brightness);
				Thread.Sleep (250);
			}
		}
	}
}