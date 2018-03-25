using System;
using System.Diagnostics;

namespace IoTSharp.Components
{
	public class ServoMotor : IoTComponent, IServoMotor
	{
		readonly IoTPin pin;

		public int MinimumValue { get; private set; }
		public int MaximumValue { get; private set; }

		int value;
		public int Value {
			get => value;
			set {
				if (value < MinimumValue || value > MaximumValue) {
					throw new IndexOutOfRangeException(value.ToString ());
				}
				this.value = value;
				pin.PwmWrite(value);
			}
		}

		public int Percentage
		{
			get => (100 * (value - MinimumValue) / (MaximumValue - MinimumValue)) + MinimumValue;
			set {
				Value = ((value * (MaximumValue - MinimumValue)) / 100) + MinimumValue;
			}
		}

		public ServoMotor(Connectors gpio, int range, int minimumValue, int maximumValue)
		{
			MinimumValue = minimumValue;
			MaximumValue = maximumValue;

			pin = new IoTPin(gpio);
			pin.SetDirection(IoTPinDirection.DirectionOutInitiallyLow);

			pin.PwmCreate(0, range);
		}

		public override void OnDispose()
		{
			pin.Dispose();
			base.OnDispose();
		}
	}
}
