using System;
namespace IoTSharp.Components
{
	public abstract class IoTComponent : IIoTComponent, IDisposable
	{
		public virtual void OnInitialize ()
		{
			//Needs override
		}

		public virtual void OnUpdate () 
		{
			//all components can handle a update logic
		}

		public virtual void OnDispose()
		{
			//all components can handle a update logic
		}

		public void Dispose()
		{
			OnDispose ();
		}
	}
}
