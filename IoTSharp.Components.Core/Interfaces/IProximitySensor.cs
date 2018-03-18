using System;

namespace IoTSharp.Components
{
	public interface IProximitySensor : IIoTComponent
	{
		event Action<bool> PresenceStatusChanged;
		bool HasPresence { get; }
	}
}
