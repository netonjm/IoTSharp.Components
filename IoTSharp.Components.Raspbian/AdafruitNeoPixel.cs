using System;
using System.Threading;
using System.Threading.Tasks;
using IoTSharp.Native;

namespace IoTSharp.Components 
{
	public class NeoPixel : IoTComponent
	{
		public int WIDTH { get; set; }
		public int HEIGHT { get; set; }

		public readonly Ws2811.Led [,] Matrix;
		readonly Ws2811 _ws2811;

		CancellationTokenSource cancellationToken;
		TaskCompletionSource<object> processingCompletion;

		public NeoPixel (Connectors connector, int width, int height)
		{
			WIDTH = width;
			HEIGHT = height;

			Matrix = new Ws2811.Led [width, height];
			_ws2811 = new Ws2811 (width * height, (int) connector);
		}

		public void Start (EventHandler updateHandler, int delay = 66) 
		{
			Stop ();
			cancellationToken = new CancellationTokenSource ();

			Task.Run (() => {
				processingCompletion = new TaskCompletionSource<object> ();
				while (!cancellationToken.IsCancellationRequested) {
					updateHandler?.Invoke (this, EventArgs.Empty);
					Render ();
					_ws2811.Render ();
					Thread.Sleep (delay);
				}
				processingCompletion.TrySetResult (null);
			}, cancellationToken.Token);
		}

		public void Stop ()
		{
			cancellationToken?.Cancel ();
			processingCompletion?.Task.Wait ();
		}

		void Render ()
		{
			int x, y;
			for (x = 0; x < WIDTH; x++) {
				for (y = 0; y < HEIGHT; y++) {
					_ws2811.Channel1 [(y * WIDTH) + x] = Matrix [x, y];
				}
			}
		}

		public override void OnDispose ()
		{
			_ws2811.Dispose ();
			base.OnDispose ();
		}
	}
}
