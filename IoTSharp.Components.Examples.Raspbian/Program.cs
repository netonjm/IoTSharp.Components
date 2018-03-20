using System;
using System.Diagnostics;
using System.Threading;

namespace IoTSharp.Components.Examples.Raspbian
{
	class Program
	{
		const int maxCount = 4;
		const int delayTime = 150;
		static int count;

		static void Main (string [] args)
		{
			Console.WriteLine ("Welcome to Raspberry Extensions tests");

			//var example = new BlindExample ();
			//var example = new ButtonExample ();
			//var example = new RfExample ();
			//var example = new RelayExample ();
			//var example = new ProximitySensorExample ();
			//var example = new UltraSonicSensorExample ();
			//var example = new HubExample ();
			var example = new DhtSensorExample ();
		
			Console.WriteLine ("Finished execution.");
		}
	}
}
