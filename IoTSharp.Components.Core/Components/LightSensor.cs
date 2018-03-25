using System.Threading;
using System.Threading.Tasks;

namespace IoTSharp.Components
{
	public class LightSensor : IoTComponent, ILightSensor
	{
		CancellationTokenSource cancellationToken;
		TaskCompletionSource<object> processingCompletion;

		readonly IoTPin pin;

		public int Brightness { get; private set; }
		public bool Value => pin.Value;

		public LightSensor (Connectors gpio)
		{
			pin = new IoTPin (gpio);
		}

		public void Start ()
		{
			Stop();
			cancellationToken = new CancellationTokenSource ();

			Task.Run(() =>
			{
				processingCompletion = new TaskCompletionSource<object> ();

				while (!cancellationToken.IsCancellationRequested)
				{
					// multiply with speed of sound (34300 cm/s) and division by two
					pin.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);
					Brightness = 0;
					Env.Timing.SleepMilliseconds (1000);
					pin.SetDirection (IoTPinDirection.DirectionIn);
					while (!pin.Value) {
						Brightness++;
					}
				}
				processingCompletion.TrySetResult (null);
			}, cancellationToken.Token);
		}

		public void Stop ()
		{
			cancellationToken?.Cancel ();
			processingCompletion?.Task.Wait ();
		}

		public override void OnDispose()
		{
			pin.Dispose ();
			base.OnDispose ();
		}
	}
}
