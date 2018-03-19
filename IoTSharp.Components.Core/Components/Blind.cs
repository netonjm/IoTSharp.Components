
namespace IoTSharp.Components
{
	public class Blind : IoTComponent, IBlind
	{
		public IRelay Relay { get; set; }
		public int RelayPortUp { get; set; }
		public int RelayPortDown { get; set; }

		public Blind (IRelay contentRelay, int relayPortUp, int relayPortDown)
		{
			Relay = contentRelay;
			AddComponent (Relay);
			RelayPortUp = relayPortUp; RelayPortDown = relayPortDown;
		}

		public Blind (Connectors gpioUp, Connectors gpioDown)
		{
			Relay = new Relay (gpioUp, gpioDown);
			AddComponent (Relay);
			RelayPortUp = 0; RelayPortDown = 1;
		}

		public void Up ()
		{
			Relay.EnablePin (RelayPortDown, false);
			Relay.EnablePin (RelayPortUp, true);
		}

		public void Down ()
		{
			Relay.EnablePin (RelayPortUp, false);
			Relay.EnablePin (RelayPortDown, true);
		}

		public void Stop ()
		{
			Relay.EnablePin (RelayPortUp, false);
			Relay.EnablePin (RelayPortDown, false);
		}

		public override void OnDispose ()
		{
			Relay.Dispose ();
			base.OnDispose ();
		}
	}
}
