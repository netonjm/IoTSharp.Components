using System.IO;

namespace IoTSharp.Components.Examples.Core
{
	public class MediaPlayerHubTest : IoTHubContainer
	{
		int count;

		public void Configure(IIoTButton button, IIoTSoundPlayer soundPlayer, string musicPath)
		{
			AddComponent(button, soundPlayer);
			button.Clicked += delegate {
				count++;
				soundPlayer.Play(Path.Combine(musicPath, $"sound{count}.wav"));
			};
		}
	}
}
