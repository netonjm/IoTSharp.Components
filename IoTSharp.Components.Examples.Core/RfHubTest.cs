using System;
using System.Threading;
using IoTSharp.Components;

namespace Xamarin.IoT.Components.Examples
{
	public class RfHubTest : IoTHubContainer
	{
		public void Configure (IIoTRfTransmitter transmitter, IIoTRfReceiver receiver)
		{
			AddComponent (receiver, transmitter);

			var recordTimeMS = 3000;
			Console.WriteLine ("Recording {0}s. in RfReceiver...", recordTimeMS / 1000);
			Thread.Sleep (1000);
			receiver.Record (recordTimeMS);

			Console.WriteLine ("Transmitting recorded signal...");
			Thread.Sleep (1000);
			transmitter.Transmit (receiver.Sample);
		}
	}
}
