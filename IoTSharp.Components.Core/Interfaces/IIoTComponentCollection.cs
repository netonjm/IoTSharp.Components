using System;
using System.Collections.Generic;

namespace IoTSharp.Components
{
	public interface IIoTComponentCollection : IIoTComponent, IDisposable
	{
		List<IIoTComponent> Components { get; set; }
		void Add (params IIoTComponent [] control);
	}
}
