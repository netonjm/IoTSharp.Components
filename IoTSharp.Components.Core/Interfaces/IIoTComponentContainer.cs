using System;
using System.Collections.Generic;

namespace IoTSharp.Components
{
	public interface IIoTComponentContainer : IIoTComponent, IDisposable
	{
		List<IIoTComponent> Components { get; set; }
		void AddComponent (params IIoTComponent [] control);
	}
}
