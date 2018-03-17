using System;
using System.Threading;
using IoTSharp.Components;

namespace Xamarin.IoT.Components.Examples
{
	class UltraSonicSensorExample
	{
		public UltraSonicSensorExample ()
		{
			IIoTUltraSonicSensor encoder = new IoTUltraSonicSensor (Connectors.GPIO23, Connectors.GPIO24);
			encoder.Start ();

			while (true) {
				Console.WriteLine ("Distance: {0} cm", encoder.Distance.ToString ("0.##"));
				Thread.Sleep (1000);
			}
		}
	}
}