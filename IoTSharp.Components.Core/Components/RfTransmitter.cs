namespace IoTSharp.Components
{
	public class RfTransmitter : IoTComponent, IRfTransmitter
	{
		public IRfSample Sample { get; set; }
		readonly IoTPin pin;

		public RfTransmitter (Connectors gpio)
		{
			pin = new IoTPin (gpio);
			pin.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);
		}

		public void Load (string file)
		{
			Sample = new RfSample ();
			Sample.Read (file);
		}

		public void Transmit (IRfSample sample)
		{
			Sample = sample;
			Transmit ();
		}

		public void Transmit ()
		{
			var timer = new SpinTimer ();
			timer.Start ();
			for (int n = 0; n < Sample.Length; n++) {
				pin.Value = (n % 2) == 0;
				timer.WaitUntil (Sample.GetData (n));
			}
		}

		public override void OnDispose ()
		{
			pin.Close ();
			base.OnDispose ();
		}
	}
}
