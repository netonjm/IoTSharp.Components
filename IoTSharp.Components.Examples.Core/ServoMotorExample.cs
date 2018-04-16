using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class ServoMotorExample
	{
		public ServoMotorExample()
		{
			//This parameters works in a TowerPro MicroServo gg
			int milliseconds = 200;
			var servo = new ServoMotor(Connectors.GPIO18);
			servo.PwmCreate (milliseconds);

			for (int i = 13; i < 30; i+=2) {
				Console.WriteLine (i);
				servo.DutyCycle = i;
				Thread.Sleep (500);
			}

			for (int i = 30; i >= 13; i -= 2) {
				Console.WriteLine (i);
				servo.DutyCycle = i;
				Thread.Sleep (500);
			}

			//servo.DutyCycle = 35;

			//while (true) {
			//	for (int i = 0; i < 100; i+=5) {
			Console.WriteLine ("End");
			//	}
			//}

			//SetPercentage(servo, 0);
			//SetPercentage(servo, 100);
			//SetPercentage(servo, 50);
			//SetPercentage(servo, 0);
		}

		//void SetPercentage (ServoMotor motor, int percent)
		//{
		//	Console.WriteLine(percent);
		//	motor.Value = percent;
		//	Env.Timing.SleepMilliseconds(1000);
		//}
	}
}
