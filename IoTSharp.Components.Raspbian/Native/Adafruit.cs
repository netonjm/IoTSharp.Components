using System;
using System.Runtime.InteropServices;
using IoTSharp.Components;

namespace IoTSharp.Native 
{
	public class Ws2811
	{
		static Ws2811 ()
		{
			// Extraction of embedded resources
			EmbeddedResources.Extract (ws2811Library, Standard.UserLibDirectory, executable: true);
		}

		const int RPI_PWM_CHANNELS = 2;
		ws2811_t _ws2811;

		#region ctor overloads

		public Ws2811 (int channel1LedCount, int channel1GpioPin)
			: this (channel1LedCount, channel1GpioPin, 255, false)
		{
		}

		public Ws2811 (int channel1LedCount, int channel1GpioPin, int channel1Brightness, bool channel1Inverted)
			: this (800000, 5, channel1LedCount, channel1GpioPin, channel1Brightness, channel1Inverted)
		{
		}

		#endregion

		public Ws2811 (uint frequency, int dma, int channel1LedCount, int channel1GpioPin, int channel1Brightness, bool channel1Inverted)
		{
			_ws2811 = new ws2811_t () {
				dmanum = 5,
				channel = new ws2811_channel_t [RPI_PWM_CHANNELS],
				freq = frequency
			};
			_ws2811.dmanum = dma;
			_ws2811.freq = frequency;
			_ws2811.channel [0].count = channel1LedCount;
			_ws2811.channel [0].gpionum = channel1GpioPin;
			_ws2811.channel [0].brightness = channel1Brightness;
			_ws2811.channel [0].invert = channel1Inverted ? 1 : 0;
			_ws2811.channel [1].count = 0;
			_ws2811.channel [1].gpionum = 0;
			_ws2811.channel [1].brightness = 0;
			_ws2811.channel [1].invert = 0;

			var res = ws2811_init (ref _ws2811);
			if (res != 0) {
				throw new ExternalException ("Error initializing rpi_ws281x", res);
			}

			Channel1 = new Led [_ws2811.channel [0].count];
		}

		public Led [] Channel1 { get; }

		public void Render ()
		{
			var channel1 = new int [_ws2811.channel [0].count];

			for (var i = 0; i < Channel1.Length; i++) {
				channel1 [i] = Channel1 [i].Color;
			}

			Marshal.Copy (channel1, 0, _ws2811.channel [0].leds, _ws2811.channel [0].count);

			var res = ws2811_render (ref _ws2811);
			if (res != 0) {
				throw new ExternalException ("DMA Error while waiting for previous DMA operation to complete");
			}
		}

		#region IDisposable

		bool _disposed = false;

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (_disposed)
				return;
			if (disposing) {
				//clean managed
			}
			ws2811_fini (ref _ws2811);
			_disposed = true;
			//clean unmanaged
		}

		public void Wait ()
		{
			var res = ws2811_wait (ref _ws2811);
			if (res != 0) {
				throw new ExternalException ("DMA Error while waiting for previous DMA operation to complete");
			}
		}

		#endregion

		#region Static Library

		internal const string ws2811Library = "ws2811.so";

		/// <summary>
		/// This initialises wiringPi and assumes that the calling program is going to be using the wiringPi pin numbering scheme. 
		/// This is a simplified numbering scheme which provides a mapping from virtual pin numbers 0 through 16 to the real underlying Broadcom GPIO pin numbers. 
		/// See the pins page for a table which maps the wiringPi pin number to the Broadcom GPIO pin number to the physical location on the edge connector.
		/// This function needs to be called with root privileges.
		/// </summary>
		/// <returns></returns>
		[DllImport (ws2811Library, CallingConvention = CallingConvention.Cdecl)]
		static extern int ws2811_init (ref ws2811_t ws2811);

		[DllImport (ws2811Library, CallingConvention = CallingConvention.Cdecl)]
		static extern void ws2811_fini (ref ws2811_t ws2811);

		[DllImport (ws2811Library, CallingConvention = CallingConvention.Cdecl)]
		static extern int ws2811_render (ref ws2811_t ws2811);

		[DllImport (ws2811Library, CallingConvention = CallingConvention.Cdecl)]
		static extern int ws2811_wait (ref ws2811_t ws2811);

		#endregion

		[StructLayout (LayoutKind.Sequential)]
		public struct ws2811_channel_t 
		{
			public int gpionum;
			public int invert;
			public int count;
			public int strip_type;
			public IntPtr leds;
			public int brightness;
			public int wshift;
			public int rshift;
			public int gshift;
			public int bshift;
			public IntPtr gamma;
		}

		[StructLayout (LayoutKind.Sequential)]
		public struct ws2811_t 
		{
			public long render_wait_time;
			public IntPtr device;
			public IntPtr rpi_hw;
			public uint freq;
			public int dmanum;

			[MarshalAs (UnmanagedType.ByValArray, SizeConst = RPI_PWM_CHANNELS)]
			public ws2811_channel_t [] channel;
		}

		[StructLayout (LayoutKind.Explicit)]
		public struct Led 
		{
			[FieldOffset (3)]
			public byte A;

			[FieldOffset (1)]
			public byte R;

			[FieldOffset (2)]
			public byte G;

			[FieldOffset (0)]
			public byte B;

			[FieldOffset (0)]
			public int Color;
		}
	}
}
