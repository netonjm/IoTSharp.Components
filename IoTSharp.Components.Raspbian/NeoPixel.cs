using System;
using System.Runtime.InteropServices;

namespace IoTSharp.Components
{
	public class AdafruitNeoPixel
	{
		/*
		 *                """Class to represent a NeoPixel/WS281x LED display.  Num should be the
                number of pixels in the display, and pin should be the GPIO pin connected
                to the display signal line (must be a PWM pin like 18!).  Optional
                parameters are freq, the frequency of the display signal in hertz (default
                800khz), dma, the DMA channel to use (default 10), invert, a boolean
                specifying if the signal line should be inverted (default False), and
                channel, the PWM channel to use (defaults to 0).
		 */

		public class LED_Data
		{
			//Wrapper class which makes a SWIG LED color data array look and feel like a Python list of integers.
			[DllImport(Neopixel, EntryPoint = nameof(__init__), SetLastError = true)]
			static extern int __init__(object self, int channel, int size);
			public void Init (object self, int channel, int size)
			{
				__init__(self, channel, size);
			}

			[DllImport(Neopixel, EntryPoint = nameof(__getitem__), SetLastError = true)]
			static extern int __getitem__(object self, int size);
			public void GetItem (object self, int size) 
			{
				__getitem__(self,size);
			}


			//Set the 24-bit RGB color value at the provided position or slice of positions.
			[DllImport(Neopixel, EntryPoint = nameof(__setitem__), SetLastError = true)]
			static extern int __setitem__(object self, int pos);
			public void SetItem (object self, int pos) 
			{
				__setitem__(self, pos);
			}

			//def __init__(self, channel, size):
			public LED_Data ()
			{
				
			}
		}

		const string Neopixel = "_rpi_ws281x.so";
		const string UserLibDirectory = "/usr/lib";

		//Wrapper class which makes a SWIG LED color data array look and feel like a Python list of integers.
		[DllImport(Neopixel, EntryPoint = nameof(__init__), SetLastError = true)]
		static extern int __init__(object self, int num, int pin, long freq, int dma, bool invert, int brightness,int channel, int strip_type);

		public void Init (object self, int num, int pin, long freq, int dma, bool invert, int brightness, int channel, int strip_type) {
			__init__(self, num, pin, freq, dma, invert, brightness, channel, strip_type);
		}

		public NeoPixel()
		{
		}
	}
}
