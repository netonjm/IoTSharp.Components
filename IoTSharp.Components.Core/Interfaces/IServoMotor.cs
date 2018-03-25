namespace IoTSharp.Components
{
	public interface IServoMotor : IIoTComponent
	{
		int Value { get; set; }
		int Percentage { get; set; }
		int MinimumValue { get; }
		int MaximumValue { get; }
	}
}
