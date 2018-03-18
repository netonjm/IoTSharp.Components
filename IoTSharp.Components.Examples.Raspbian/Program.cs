using System;
using System.Diagnostics;

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
			var example = new HubExample ();

			Console.WriteLine ("Finished execution.");
		}
	}
}
