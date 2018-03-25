namespace IoTSharp.Components
{
	public interface ILightSensor : IIoTComponent
	{
		int Brightness { get; }
		bool Value { get; }
		void Start();
		void Stop();
	}
}
