using System;
namespace IoTSharp.Components
{
	public interface IIoTComponent : IDisposable
	{
		void OnUpdate ();

		void OnInitialize ();

		void OnDispose ();
	}
}
