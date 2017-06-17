namespace IoTSharp.Components
{
	public class IoTRfTransmitter : IoTComponent, IIoTRfTransmitter
	{
		public IIoTRfSample Sample { get; set; }
		readonly IoTPin pin;

		public IoTRfTransmitter (Connectors gpio)
		{
			pin = new IoTPin (gpio);
			pin.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);
			pin.SetActiveType (IoTActiveType.ActiveLow);
		}

		public void Load (string file)
		{
			Sample = new IoTRfSample ();
			Sample.Read (file);
		}

		public void Transmit (IIoTRfSample sample)
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

		public override void Dispose ()
		{
			pin.Close ();
			base.Dispose ();
		}
	}
}
