using System;

namespace IoTSharp.Components
{
	public interface IIoTProximitySensor : IIoTComponent
	{
		event Action<bool> PresenceStatusChanged;
		bool HasPresence { get; }
	}
}
