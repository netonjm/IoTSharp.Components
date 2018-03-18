using System;
namespace IoTSharp.Components
{
	public interface IRfReceiver : IIoTComponent
	{
		IRfSample Sample { get; }
		void Record (double recTime);
	}
}
