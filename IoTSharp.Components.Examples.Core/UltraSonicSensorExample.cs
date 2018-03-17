﻿using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class UltraSonicSensorExample
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