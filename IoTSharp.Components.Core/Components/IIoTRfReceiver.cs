using System;
namespace IoTSharp.Components
{
	public interface IIoTRfReceiver : IIoTComponent
	{
		IIoTRfSample Sample { get; }
		void Record (double recTime);
	}
}
