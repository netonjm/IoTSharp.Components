using System;
using System.Diagnostics;

namespace IoTSharp.Components
{
	public class IoTSoundPlayer : IIoTSoundPlayer
	{
		public event EventHandler Ended;

		public void Play (string file)
		{
			ExecuteProcess ("aplay", $"-N -t wav {file}");
		}

		public void Stop()
		{
			ExecuteProcess("amixer", "set PCM mute");
		}

		void ExecuteProcess (string filename, string arguments)
		{
			using (var proc = new Process ()) {
				proc.EnableRaisingEvents = false;
				proc.StartInfo.FileName = filename;
				proc.StartInfo.Arguments = arguments;
				proc.Start ();
				proc.WaitForExit ();
			};
			Ended?.Invoke (this, EventArgs.Empty);
		}
	}
}
