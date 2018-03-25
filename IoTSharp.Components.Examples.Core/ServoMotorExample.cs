using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class ServoMotorExample
	{
		public ServoMotorExample()
		{
			//This parameters works in a TowerPro MicroServo gg
			int milliseconds = 200, min = 5, max = 19;
			var servo = new ServoMotor(Connectors.GPIO18, milliseconds, min, max);
			SetPercentage(servo, 0);
			SetPercentage(servo, 100);
			SetPercentage(servo, 50);
			SetPercentage(servo, 0);
		}

		void SetPercentage (ServoMotor motor, int percent)
		{
			Console.WriteLine(percent);
			motor.Percentage = percent;
			Env.Timing.SleepMilliseconds(1000);
		}
	}
}
