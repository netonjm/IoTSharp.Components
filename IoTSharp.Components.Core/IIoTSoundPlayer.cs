using System;

namespace IoTSharp.Components
{
	public interface IIoTSoundPlayer : IIoTComponent
	{
		event EventHandler Ended;
		void Play (string file);
		void Stop ();
	}
}
