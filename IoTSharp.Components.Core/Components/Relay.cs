using System;
using System.Diagnostics;
using System.Threading;

namespace IoTSharp.Components
{
	public class Relay : IoTComponent, IRelay
	{
		public int DelayTime { get; set; } = 300;
		static readonly ITracer tracer = Tracer.Get<Relay> ();

		const string ValueNotInRange = "Pin id parameter is not in range";
		public event EventHandler<RelayChangedEventArgs> PinChanged;
		readonly IoTPin [] pins;

		public Relay (params Connectors [] gpio)
		{
			pins = new IoTPin [gpio.Length];
			for (int i = 0; i < gpio.Length; i++) {
				pins [i] = new IoTPin (gpio [i]);
				pins [i].SetDirection (IoTPinDirection.DirectionOutInitiallyLow);
				pins [i].SetActiveType (IoTActiveType.ActiveLow);
			}
		}

		public bool ContainsId (int id)
		{
			return id >= 0 && id < pins.Length;
		}

		public void Toggle (int id)
		{
			if (!ContainsId (id))
				throw new ArgumentException (ValueNotInRange);
			EnablePin (id, !GetPinValue (id));
		}

		public bool GetPinValue (int id)
		{
			if (!ContainsId (id))
				throw new ArgumentException (ValueNotInRange);
			return pins [id].Value;
		}

		public void EnablePin (int id, bool value)
		{
			if (!ContainsId (id))
				throw new ArgumentException (ValueNotInRange);
			
			var selectedPin = pins [id];
			var actualValue = GetPinValue (id);

			tracer.Verbose ($"PIN: {id} FROM '{actualValue}' TO '{value}'");

			if (actualValue == value)
				return;

			selectedPin.Value = value;
			Thread.Sleep (DelayTime);
			OnPinChanged (id, value);
		}

		void OnPinChanged (int port, bool value)
		{
			PinChanged?.Invoke(this, new RelayChangedEventArgs (port, value));
		}

		public override void OnDispose ()
		{
			foreach (var pin in pins) {
				pin.Close ();
			}
		}

		public int Count()
		{
			return pins.Length;
		}
	}
}
