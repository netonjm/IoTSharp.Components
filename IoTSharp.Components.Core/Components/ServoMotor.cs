using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace IoTSharp.Components
{
	public class ServoMotor : IoTComponent
	{
		readonly IoTPin pin;

		public ServoMotor(Connectors gpio)
		{
			pin = new IoTPin(gpio);
			pin.SetDirection(IoTPinDirection.DirectionOutInitiallyLow);
		}

		/// <summary>
		/// Create a cycle XX ms long made up of XXXX steps (20 ms as 200 * 100 = 20000 microseconds).
		/// </summary>
		/// <param name="microseconds">Microseconds.</param>
		/// <param name="initial">Initial.</param>
		public void PwmCreate (int microseconds, int initial = 0) 
		{
			pin.PwmCreate (microseconds, initial);
		}

		/// <summary>
		/// Keep the pulse high for XX ms in every 20 ms cycle (18.5 ms as 185 * 100 = 18500 microseconds). 
		/// That is way too long. Servos nominally respond to 1 ms - 2 ms pulses. So you should choose values 10 - 20.
		public int DutyCycle {
			get => pin.PwmDutyCycle;
			set => pin.PwmDutyCycle = value;
		}

		public int Clock {
			get => pin.PwmClock;
			set => pin.PwmClock = value;
		}

		public override void OnDispose()
		{
			pin.Dispose();
			base.OnDispose();
		}
	}
}
