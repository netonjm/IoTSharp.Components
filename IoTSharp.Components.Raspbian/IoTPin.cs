using System;
using Unosquare.RaspberryIO;
using System.Linq;
using Unosquare.RaspberryIO.Gpio;

namespace IoTSharp.Components
{
	public class IoTPin : IIoTPin
	{
		internal GpioPin pin;

		public bool Value {
			get { return pin.Read(); }
			set {
				pin.Write(value);
			}
		}

		public IoTPin (Connectors connector)
		{
			pin = connector.Pin();
		}

		public void SetDirection (IoTPinDirection direction)
		{
			switch (direction) {
			case IoTPinDirection.DirectionOutInitiallyLow:
			case IoTPinDirection.DirectionOutInitiallyHight:
					pin.PinMode = GpioPinDriveMode.Output;
				break;
			case IoTPinDirection.DirectionIn:
					pin.PinMode = GpioPinDriveMode.Input;
				break;
			}
		}

		public void SetActiveType (IoTActiveType activeType)
		{
			//pin.SetActiveType (activeType.ToNative ());
		}

		public void Close ()
		{
		}

		public void Dispose ()
		{
			
		}
	}
}
