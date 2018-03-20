using IoTSharp.Components;

namespace HapSharp.Accessories
{
	public interface IDhtSensor : IIoTComponent
	{
		int Humidity { get; }
		int Temperature { get; }
	}
}
