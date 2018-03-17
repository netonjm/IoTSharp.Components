using System;
namespace IoTSharp.Components
{
	public abstract class IoTComponent : IIoTComponent, IDisposable
	{
		public virtual void Initialize ()
		{
			//Needs override
		}

		public virtual void Update () 
		{
			//all components can handle a update logic
		}

		public virtual void Dispose ()
		{
			
		}
	}
}
