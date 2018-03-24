using System;

namespace IoTSharp.Components
{
	public class RotaryEncoder3 : IoTComponent, IRotaryEncoder3
	{
		public long value;
		public int lastEncoded;

		readonly IoTPin pinA;
		readonly IoTPin pinB;

		public long Value { get; private set; }

		public RotaryEncoder3 (Connectors pinA, Connectors pinB)
		{
			this.pinA = new IoTPin (pinA);
			this.pinA.SetDirection (IoTPinDirection.DirectionIn);

			this.pinB = new IoTPin (pinB);
			this.pinB.SetDirection (IoTPinDirection.DirectionIn);
		}

		public override void OnUpdate ()
		{
			int MSB = Convert.ToInt32 (pinA.Value);
			int LSB = Convert.ToInt32 (pinB.Value);
			int encoded = (MSB << 1) | LSB;
			int sum = (lastEncoded << 2) | encoded;

			if (sum == 0b1101 || sum == 0b0100 || sum == 0b0010 || sum == 0b1011) Value++;
			if (sum == 0b1110 || sum == 0b0111 || sum == 0b0001 || sum == 0b1000) Value--;

			lastEncoded = encoded;
		}

		public override void OnDispose ()
		{
			pinA.Dispose ();
			pinB.Dispose ();
			base.OnDispose ();
		}
	}
}
