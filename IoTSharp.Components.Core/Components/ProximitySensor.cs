using System;
using System.Diagnostics;

namespace IoTSharp.Components
{
	public class ProximitySensor : IoTComponent, IProximitySensor
	{
		static readonly ITracer tracer = Tracer.Get<ProximitySensor> ();
		public event Action<bool> PresenceStatusChanged;
		readonly IoTPin pin;

		public bool HasPresence {
			get; private set;
		}

		public ProximitySensor (Connectors gpio)
		{
			pin = new IoTPin (gpio);
			pin.SetDirection (IoTPinDirection.DirectionIn);
			HasPresence = pin.Value;
			tracer.Verbose ("Initial value: " + HasPresence);
		}

		public override void OnUpdate ()
		{
			var presence = pin.Value;
			if (presence == HasPresence)
				return;
			HasPresence = presence;
			tracer.Verbose ("Detected presence: " + HasPresence);
			PresenceStatusChanged?.Invoke (presence);
		}

		public override void OnDispose ()
		{
			pin.Close ();
		}
	}
}
