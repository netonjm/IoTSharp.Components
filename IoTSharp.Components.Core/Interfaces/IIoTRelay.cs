using System;

namespace IoTSharp.Components
{
	public interface IIoTRelay : IIoTComponent
	{
		event EventHandler<RelayChangedEventArgs> PinChanged;

		bool ContainsId (int id);
		void Toggle (int id);
		bool GetPinValue (int id);
		void EnablePin (int id, bool value);
		int Count();
	}
}
