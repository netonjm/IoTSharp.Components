using System;

namespace IoTSharp.Components.Examples
{
	public class LedExample
	{
		public LedExample()
		{
			var led = new Led (Connectors.GPIO27);
			int counter = 0;

			while (counter < 3) {
				// fade LED to fully ON
				for (int i = 0; i <= 100; i++) {
					// softPwmWrite(int pin, int value)
					// This updates the PWM value on the given pin. The value is
					// checked to be in-range and pins
					// that haven't previously been initialized via softPwmCreate
					// will be silently ignored.
					led.Brightness = i;
					Env.Timing.SleepMilliseconds(25); 
				}
				// fade LED to fully OFF
				for (int i = 100; i >= 0; i--)
				{
					led.Brightness = i;
					Env.Timing.SleepMilliseconds(25); 
				}
				counter++;
			}

		}
	}
}
