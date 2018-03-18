using System;
using System.Collections.Generic;

namespace IoTSharp.Components
{
	public interface IIoTComponent : IDisposable
	{
		void OnUpdate ();

		void OnInitialize ();

		void OnDispose ();

		List<IIoTComponent> Components { get; }
		void Add(params IIoTComponent[] control);
	}
}
