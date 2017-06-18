using System;
using Android.App;
using Android.Media;
using Android.Content;

namespace IoTSharp.Components.Monodroid
{
	public class IoTSoundPlayer : IoTComponent, IIoTSoundPlayer
	{
		public event EventHandler Ended;

		readonly MediaPlayer player;
		readonly Context context;

		public IoTSoundPlayer (Context context)
		{
			this.context = context;
			player = new MediaPlayer();
			player.Completion += (sender, e) => {
				Ended?.Invoke (this, EventArgs.Empty);
			};
		}

		public void Play (string file)
		{
			player.Reset();
			player.SetDataSource(file);
			player.Prepare();
			player.Start();
		}

		public void Stop () 
		{
			player.Stop();
		}

		public override void Dispose()
		{
			player.Release();
			base.Dispose();
		} 
	}
}
