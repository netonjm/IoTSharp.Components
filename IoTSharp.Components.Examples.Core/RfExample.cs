using System;
using System.Threading;
using IoTSharp.Components;

namespace Xamarin.IoT.Components.Examples
{
	public class RfExample
	{
		public RfExample ()
		{
			var transmitter = new IoTRfTransmitter(Connectors.GPIO27);
			var receiver = new IoTRfReceiver(Connectors.GPIO17);
			var recordTimeMS = 3000;
			Console.WriteLine ("Recording {0}s. in RfReceiver...", recordTimeMS / 1000);
			Thread.Sleep (1000);
			receiver.Record (recordTimeMS);

			Console.WriteLine ("Transmitting recorded signal...");
			Thread.Sleep (1000);
			transmitter.Transmit (receiver.Sample);

			transmitter.Dispose();
			receiver.Dispose();
		}
	}
}
