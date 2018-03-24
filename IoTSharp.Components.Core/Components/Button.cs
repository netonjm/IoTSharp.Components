using System;
using System.Diagnostics;

namespace IoTSharp.Components
{
	public class Button : IoTComponent, IButton
	{
		static readonly ITracer tracer = Tracer.Get<Button> ();

		public event Action ButtonDown;
		public event Action ButtonUp;
		public event Action Clicked;

		public bool IsPressed { get; private set; }
		readonly IoTPin pin;

		public Button (Connectors gpio)
		{
			pin = new IoTPin (gpio);
			pin.SetDirection (IoTPinDirection.DirectionIn);
            IsPressed = false;
			tracer.Verbose ("Initial value: " + IsPressed);
		}

		public override void OnUpdate ()
		{
			var value = !pin.Value ;
			if (IsPressed == value)
				return;
			IsPressed = value;
			if (IsPressed) {
				tracer.Verbose ("Buton Down");
				ButtonDown?.Invoke ();
			} else {
                tracer.Verbose ("Buton Up");
				ButtonUp?.Invoke ();
				Clicked?.Invoke ();
			}
		}

		public override void OnDispose ()
		{
			pin.Close ();
		}
	}
}
