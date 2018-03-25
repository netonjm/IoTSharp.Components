using System.Runtime.InteropServices;
using System;
using System.Threading.Tasks;
using IoTSharp.Native;

namespace IoTSharp.Components
{
	public enum DhtModel
	{
		Dht11 = 11, Dht22 = 22
	}

	public class DhtSensor : IoTComponent
	{
		const string DhtDriver = "DhtDriver.so";
	
		[DllImport(DhtDriver)]
		static extern int pi_2_dht_read(int sensor, int pin, out float humidity, out float temperature);
		static object obj = new object();

		Task Initialization { get; set; }

		bool finished = false;
		const int DefaultDelay = 5000;

		int Sensor; //DHT11
		readonly int pin;

		public int Humidity { get; private set; }
		public int Temperature { get; private set; }
		public bool IsRunning { get; private set; }

		static DhtSensor ()
		{
			// Extraction of embedded resources
			EmbeddedResources.Extract (DhtDriver, Standard.UserLibDirectory, executable:true);
		}

		public DhtSensor (Connectors connector, DhtModel model) 
		{
			pin = (int)connector;
			Sensor = (int)model;
		}

		public void Start () 
		{
			lock (obj) {
				if (IsRunning) {
					return;
				}
				IsRunning = true;
				Initialization = InitializeAsync(); 	
			}
		}

		async Task InitializeAsync()
		{
			while (!finished)
			{
				try
				{
					float hum, temp;
					pi_2_dht_read(Sensor, pin, out hum, out temp);

					if (hum != 0) {
						Humidity = (int)hum;
					}

					if (temp != 0) {
						Temperature = (int)temp;
					}
				}
				catch (Exception ex) {
					Console.WriteLine(ex.ToString ());
				}
				// Asynchronously initialize this instance.
				await Task.Delay(DefaultDelay);
			}
		}

		public void Cancel ()
		{
			finished = true;
		}

		public override void OnDispose ()
		{
			Cancel ();
			base.OnDispose ();
		}
	}
}
