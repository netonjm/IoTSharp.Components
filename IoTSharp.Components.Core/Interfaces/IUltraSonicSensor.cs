namespace IoTSharp.Components
{
	public interface IUltraSonicSensor : IIoTComponent
	{
		double Distance { get; }

		void Start ();
		void Stop ();
	}
}
