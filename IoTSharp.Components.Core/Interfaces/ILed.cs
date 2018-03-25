namespace IoTSharp.Components
{
	interface ILed : IIoTComponent
	{
		bool Enabled { get; set; }
		int Brightness { get; set; }
	}
}
