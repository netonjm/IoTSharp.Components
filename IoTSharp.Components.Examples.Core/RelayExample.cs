using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class RelayExample
	{
		const int max = 10;
		int count;

		public RelayExample ()
		{
			var relay = new Relay(Connectors.GPIO17, Connectors.GPIO27);

			while (count < max) {
				relay.Toggle(0);

				if (count%2 == 0) {
					var pinValue = relay.GetPinValue(1);
					relay.EnablePin(1, !pinValue);
				}
				
				relay.OnUpdate();

				Thread.Sleep (500);
				count++;
			}

			relay.OnDispose();
		}
	}
}
