using System;

namespace IoTSharp.Components.Examples.Raspbian
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Raspberry Extensions tests");

			//var example = new BlindExample ();
			//var example = new ButtonExample ();
			//var example = new RfExample ();
			//var example = new RelayExample ();
			//var example = new ProximitySensorExample ();
			//var example = new UltraSonicSensorExample ();
			//var example = new HubExample ();
			//var example = new DhtSensorExample ();
			//var example = new LedExample ();
			//var example = new BuzzerExample();
			var example = new LightSensorExample ();
		}
	}
}
