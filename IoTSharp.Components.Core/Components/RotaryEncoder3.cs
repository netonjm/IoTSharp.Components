using System;

namespace IoTSharp.Components
{
	public class RotaryEncoder3 : IoTComponent, IRotaryEncoder3
	{
		bool clkLastState;

		readonly IoTPin clockPin;
		readonly IoTPin dtPin;

		public long Value { get; private set; }

		public RotaryEncoder3 (Connectors clockConnector, Connectors dtConnector)
		{
			this.clockPin = new IoTPin (clockConnector);
			this.clockPin.SetDirection (IoTPinDirection.DirectionIn);

			this.dtPin = new IoTPin (dtConnector);
			this.dtPin.SetDirection (IoTPinDirection.DirectionIn);
			Value = 0;
			clkLastState = this.clockPin.Value;
		}

		public override void OnUpdate ()
		{

			var clkState = clockPin.Value;
		    var dtState =  dtPin.Value;
			if (clkState != clkLastState) {
				if (dtState != clkState)
					Value += 1;
				else
					Value -= 1;
				Console.WriteLine(Value);
			}

			clkLastState = clkState;
		}

		public override void OnDispose ()
		{
			clockPin.Dispose ();
			dtPin.Dispose ();
			base.OnDispose ();
		}
	}
}
