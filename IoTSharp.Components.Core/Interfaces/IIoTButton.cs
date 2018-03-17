using System;

namespace IoTSharp.Components
{
	public interface IIoTButton : IIoTComponent
	{
		event Action ButtonDown;
		event Action ButtonUp;
		event Action Clicked;

		bool IsPressed { get; }
	}
}
