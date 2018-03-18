using System;

namespace IoTSharp.Components
{
	public interface ISoundPlayer : IIoTComponent
	{
		event EventHandler Ended;
		void Play (string file);
		void Stop ();
	}
}
