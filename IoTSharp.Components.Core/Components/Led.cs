using System;

namespace IoTSharp.Components
{
	public class Led : IoTComponent, ILed
	{
		readonly IoTPin pin;
		readonly int range;

		int brightness;
		public int Brightness {
			get => brightness;
			set
			{
				if (value < 0 && value > range)
				{
					throw new IndexOutOfRangeException (brightness.ToString());
				}
				brightness = value;
				pin.PwmWrite (value);
			}
		}

		bool enabled;
		public bool Enabled {
			get => enabled;
			set
			{
				if (!value) {
					pin.PwmWrite (0);
				} else {
					pin.PwmWrite (brightness);
				}
				enabled = value;
			}
		}

		public Led(Connectors gpio, bool enabled = true, int brightness = 0, int range = 100)
		{
			if (brightness < 0 && brightness > range) {
				throw new IndexOutOfRangeException (brightness.ToString());
			}

			pin = new IoTPin (gpio);
			pin.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);

			this.enabled = enabled;
			this.range = range;
			this.brightness = brightness;

			pin.PwmCreate (!enabled ? 0 : brightness, range);
		}

		public override void OnDispose()
		{
			pin.Dispose ();
			base.OnDispose ();
		}
	}
}
