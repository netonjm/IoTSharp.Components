namespace IoTSharp.Components
{
	public interface IIoTUltraSonicSensor : IIoTComponent
	{
		double Distance { get; }

		void Start ();
		void Stop ();
	}
}
