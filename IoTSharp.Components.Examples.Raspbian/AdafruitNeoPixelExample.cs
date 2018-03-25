using System;
using System.Threading;
using IoTSharp.Native;

namespace IoTSharp.Components.Examples.Raspbian
{
	class AdafruitNeoPixelExample
	{
		readonly int [] Dotspos = { 0, 1, 2, 3, 4, 5, 6, 7 };
		readonly Ws2811.Led [] Dotcolors = {
			new Ws2811.Led{Color = 0x000000},
			new Ws2811.Led{Color = 0x201000},
			new Ws2811.Led{Color = 0x202000},
			new Ws2811.Led{Color = 0x002000},
			new Ws2811.Led{Color = 0x002020},
			new Ws2811.Led{Color = 0x000020},
			new Ws2811.Led{Color = 0x100010},
			new Ws2811.Led{Color = 0x200010}
		};

		readonly NeoPixel neopixel;

		public AdafruitNeoPixelExample ()
		{
			neopixel = new NeoPixel (Connectors.GPIO18, 8, 8);
			neopixel.Start (UpdateHandler, 1000 / 15);

			while (true) {
				Thread.Sleep (1000);
			}
		}

		void UpdateHandler (object sender, EventArgs args)
		{
			MatrixRaise ();
			MatrixBottom ();
		}

		void MatrixRaise ()
		{
			int x, y;

			for (y = 0; y < (neopixel.HEIGHT - 1); y++) {
				for (x = 0; x < neopixel.WIDTH; x++) {
					neopixel.Matrix [x, y] = neopixel.Matrix [x, y + 1];
				}
			}
		}

		void MatrixBottom ()
		{
			int i;

			for (i = 0; i < Dotspos.Length; i++) {
				Dotspos [i]++;
				if (Dotspos [i] > (neopixel.WIDTH - 1)) {
					Dotspos [i] = 0;
				}
				neopixel.Matrix [Dotspos [i], neopixel.HEIGHT - 1] = Dotcolors [i];
			}
		}
	}
}
