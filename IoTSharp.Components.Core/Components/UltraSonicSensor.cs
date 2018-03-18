using System;
using System.Threading;
using System.Threading.Tasks;

namespace IoTSharp.Components
{
	public class UltraSonicSensor : IoTComponent, IUltraSonicSensor
	{
		const double SpeedOfSoundCmPerSecond = 34300;
		readonly IoTPin trigger;
		readonly IoTPin echo;

		public double Distance { get; private set; }

		CancellationTokenSource cancellationToken;
		TaskCompletionSource<object> processingCompletion;

		public UltraSonicSensor (Connectors triggerPin, Connectors echoPin)
		{
			trigger = new IoTPin (triggerPin);
			trigger.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);
			echo = new IoTPin (echoPin);
			echo.SetDirection (IoTPinDirection.DirectionIn);
		}

		public double GetSecondsFromWave ()
		{
			// Initialize the sensor's trigger pin to low. If we don't pause
			// after setting it to low, sometimes the sensor doesn't work right.
			trigger.Value = false;
			Thread.Sleep (TimeSpan.FromMilliseconds (500));

			// Triggering the sensor for 10 microseconds will cause it to send out
			// 8 ultrasonic (40Khz) bursts and listen for the echos.
			trigger.Value = true;
			Thread.Sleep (TimeSpan.FromMilliseconds (0.01));
			trigger.Value = false;

			// The sensor will raise the echo pin high for the length of time that it took
			// the ultrasonic bursts to travel round trip.
			while (!echo.Value) { }
			var init = DateTime.Now;
			while (echo.Value) { }
			return DateTime.Now.Subtract (init).TotalSeconds;
		}

		public void Start ()
		{
			Stop ();
			cancellationToken = new CancellationTokenSource ();

			Task.Run (() => {
				processingCompletion = new TaskCompletionSource<object> ();
				while (!cancellationToken.IsCancellationRequested) {
					// multiply with speed of sound (34300 cm/s) and division by two
					Distance = GetSecondsFromWave () * SpeedOfSoundCmPerSecond / 2;
				}
				processingCompletion.TrySetResult (null);
			}, cancellationToken.Token);

		}

		public void Stop ()
		{
			cancellationToken?.Cancel ();
			processingCompletion?.Task.Wait ();
		}

		public override void OnDispose ()
		{
			trigger.Dispose ();
			echo.Dispose ();
			base.OnDispose ();
		}
	}
}
