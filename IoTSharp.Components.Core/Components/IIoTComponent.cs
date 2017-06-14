using System;
namespace IoTSharp.Components
{
	public interface IIoTComponent : IDisposable
	{
		int DefaultInstructionDelayTime { get; set; }
		void Update ();
	}
}
