using System;
using Unosquare.RaspberryIO.Gpio;

namespace IoTSharp.Components
{
	public class IoTPin : IIoTPin
	{
		internal GpioPin pin;

		public bool Value {
			get { return pin.Read (); }
			set {
				pin.Write (value);
			}
		}

		public IoTPin (Connectors connector)
		{
			pin = connector.Pin();
		}

		public void PwmCreate (int range, int initialValue = 0)
		{
			pin.StartSoftPwm (initialValue, range);
		}

		public int PwmClock {
			get => pin.PwmClockDivisor;
			set {
				pin.PwmClockDivisor = value;
			}
		}

		public int PwmDutyCycle {
			get => pin.SoftPwmValue;
			set {
				pin.SoftPwmValue = value;
			}
		}


		public int PulseIn (bool state)
		{
			return pin.PulseIn (state);
		}

		public void SetDirection (IoTPinDirection direction)
		{
			switch (direction) {
			case IoTPinDirection.DirectionOutInitiallyLow:
					pin.PinMode = GpioPinDriveMode.Output;
				break;
			case IoTPinDirection.DirectionOutInitiallyHigh:
					pin.PinMode = GpioPinDriveMode.Output;
					pin.Write (GpioPinValue.High);
				break;
			case IoTPinDirection.DirectionIn:
					pin.PinMode = GpioPinDriveMode.Input;
				break;
			case IoTPinDirection.PwmOutput:
					pin.PinMode = GpioPinDriveMode.PwmOutput;
				break;
			}
		}

		public void Close ()
		{
		}

		public void Dispose ()
		{
			
		}
	}
}
