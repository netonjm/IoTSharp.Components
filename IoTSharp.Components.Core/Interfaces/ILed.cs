namespace IoTSharp.Components
{
	interface ILed
	{
		bool Enabled { get; set; }
		int Brightness { get; set; }
	}
}
