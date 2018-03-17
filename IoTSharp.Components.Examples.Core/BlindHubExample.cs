namespace IoTSharp.Components.Examples
{
	public class BlindHubExample
	{
		public BlindHubExample () 
		{
			using (var blind = new IoTBlind (Connectors.GPIO17, Connectors.GPIO17)) {
				blind.Down();
				blind.Up();
				blind.Stop();
			};
		}
	}
}
