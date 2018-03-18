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
			var button = new Button(Connectors.GPIO27);
			var soundPlayer = new SoundPlayer ();

			button.Clicked += delegate {
				count++;
				soundPlayer.Play(Path.Combine(musicPath, $"sound{count}.wav"));
			};

			while (count < max) {
				button.OnUpdate();
				Thread.Sleep(250);
			}

			button.OnDispose();
		}
	}
}
