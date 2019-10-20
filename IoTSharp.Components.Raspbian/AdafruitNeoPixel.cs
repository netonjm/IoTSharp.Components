using System;
using System.Threading;
using System.Threading.Tasks;
using IoTSharp.Native;

namespace IoTSharp.Components 
{
	public class NeoPixel : IoTComponent
	{
        public int Width => Matrix.GetLength(0);
        public int Height => Matrix.GetLength(1);

        public readonly Ws2811.Led [,] Matrix;
		readonly Ws2811 _ws2811;

		CancellationTokenSource cancellationToken;
		TaskCompletionSource<object> processingCompletion;

		public NeoPixel (Connectors connector, int width, int height)
		{
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

		public void Render ()
		{
			int x, y;
			for (x = 0; x < Width; x++) {
				for (y = 0; y < Height; y++) {
					_ws2811.Channel1 [(y * Width) + x] = Matrix [x, y];
				}
			}
            _ws2811.Render();
        }

		public override void OnDispose ()
		{
			_ws2811.Dispose ();
			base.OnDispose ();
		}
	}
}
