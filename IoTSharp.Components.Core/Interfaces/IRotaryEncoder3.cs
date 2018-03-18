using System;

namespace IoTSharp.Components
{
	public interface IRotaryEncoder3 : IIoTComponent
	{
		long Value { get; }
	}
}
