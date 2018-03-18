using System;

namespace IoTSharp.Components.Examples
{
	public class BlindExample
	{
		public BlindExample () 
		{
			var blind = new Blind(Connectors.GPIO17, Connectors.GPIO17);
			Console.WriteLine ("Blind is closing..");
			blind.Down ();

			Console.WriteLine ("Blind is opening..");
			blind.Up ();

			blind.Stop ();
			Console.WriteLine ("Blind stop.");

			blind.OnDispose ();
		}
	}
}
