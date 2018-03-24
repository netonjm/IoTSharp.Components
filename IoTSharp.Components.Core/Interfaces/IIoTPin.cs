using System;

namespace IoTSharp.Components
{
	public interface IIoTPin : IDisposable
	{
		bool Value { get; set; }

		void SetDirection (IoTPinDirection direction);
		void Close ();
	}
}
