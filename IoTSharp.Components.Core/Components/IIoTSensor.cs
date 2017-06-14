using System;

namespace IoTSharp.Components
{
	public interface IIoTSensor : IIoTComponent
	{
		event Action<bool> PresenceStatusChanged;
		bool HasPresence { get; }
	}
}
