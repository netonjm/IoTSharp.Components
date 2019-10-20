using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using System;
using System.Drawing;
using IoTSharp.Native;

namespace IoTSharp.Components
{
	public static class Extensions
	{
        public static int ToIntColor(this Color clr, int correction = 0)
        {
            int rgb = Math.Max(0, clr.G + correction);
            rgb = (rgb << 8) + Math.Max(0, clr.R + correction);
            rgb = (rgb << 8) + Math.Max(0, clr.B + correction);
            return rgb;
        }

        public static Ws2811.Led[,] GetNeoPixelsFromBitmap(this Bitmap bitmap, int x, int y, int pixels = 8, int correction = -95)
        {
            Ws2811.Led[,] result = new Ws2811.Led[pixels, pixels];
            for (int i = x; i < pixels + x; i++)
            {
                for (int j = y; j < pixels + y; j++)
                {
                    Color clr = bitmap.GetPixel(i, j);
                    result[i - x, j - y] = new Ws2811.Led { Color = clr.ToIntColor(correction) };
                }
            }
            return result;
        }

        public static GpioPin Pin(this Connectors gpio)
		{
			switch (gpio)
			{
				case Connectors.GPIO2:
					return Pi.Gpio.Pin08;
				case Connectors.GPIO3:
					return Pi.Gpio.Pin09;
				case Connectors.GPIO4:
					return Pi.Gpio.Pin07;
				case Connectors.GPIO5:
					return Pi.Gpio.Pin21;
				case Connectors.GPIO6:
					return Pi.Gpio.Pin22;
				case Connectors.GPIO7:
					return Pi.Gpio.Pin11;
				case Connectors.GPIO8:
					return Pi.Gpio.Pin10;
				case Connectors.GPIO9:
					return Pi.Gpio.Pin13;
				case Connectors.GPIO10:
					return Pi.Gpio.Pin12;
				case Connectors.GPIO11:
					return Pi.Gpio.Pin14;
				case Connectors.GPIO12:
					return Pi.Gpio.Pin26;
				case Connectors.GPIO13:
					return Pi.Gpio.Pin23;
				case Connectors.GPIO14:
					return Pi.Gpio.Pin15;
				case Connectors.GPIO15:
					return Pi.Gpio.Pin16;
				case Connectors.GPIO16:
					return Pi.Gpio.Pin27;
				case Connectors.GPIO17:
					return Pi.Gpio.Pin00;
				case Connectors.GPIO18:
					return Pi.Gpio.Pin01;
				case Connectors.GPIO19:
					return Pi.Gpio.Pin24;
				case Connectors.GPIO20:
					return Pi.Gpio.Pin28;
				case Connectors.GPIO21:
					return Pi.Gpio.Pin29;
				case Connectors.GPIO22:
					return Pi.Gpio.Pin03;
				case Connectors.GPIO23:
					return Pi.Gpio.Pin04;
				case Connectors.GPIO24:
					return Pi.Gpio.Pin05;
				case Connectors.GPIO25:
					return Pi.Gpio.Pin25;
				case Connectors.GPIO26:
					return Pi.Gpio.Pin06;
				case Connectors.GPIO27:
					return Pi.Gpio.Pin02;
			}
			throw new NotImplementedException(gpio.ToString());
		}

	}
}
