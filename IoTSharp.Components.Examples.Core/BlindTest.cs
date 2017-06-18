namespace IoTSharp.Components.Examples
{
	public class BlindHubTest
	{
		public BlindHubTest () 
		{
			using (var blind = new IoTBlind (Connectors.GPIO17, Connectors.GPIO17)) {
				blind.Down();
				blind.Up();
				blind.Stop();
			};
		}
	}
}
