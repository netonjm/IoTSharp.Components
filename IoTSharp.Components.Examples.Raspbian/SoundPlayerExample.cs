using System.IO;
using System.Reflection;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class SoundPlayerExample
	{
		const int max = 4;
		int count;

		public SoundPlayerExample()
		{
			var musicPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			var button = new IoTButton(Connectors.GPIO27);
			var soundPlayer = new IoTSoundPlayer ();

			button.Clicked += delegate {
				count++;
				soundPlayer.Play(Path.Combine(musicPath, $"sound{count}.wav"));
			};

			while (count < max) {
				button.Update();
				Thread.Sleep(250);
			}

			button.Dispose();
		}
	}
}
