using System;
namespace IoTSharp.Components
{
	public interface IIoTComponent : IDisposable
	{
		void Update ();

		void Initialize ();
	}
}
