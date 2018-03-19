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
		void AddComponent (params IIoTComponent[] control);
		void RemoveComponent (params IIoTComponent[] control);
	}
}
