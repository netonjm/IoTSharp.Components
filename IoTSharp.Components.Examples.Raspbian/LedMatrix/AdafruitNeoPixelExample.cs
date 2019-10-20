using System;
using System.Threading;
using IoTSharp.Native;

namespace IoTSharp.Components.Examples.Raspbian
{
    class AdafruitNeoPixelExample
    {
        readonly int[] Dotspos = { 0, 1, 2, 3, 4, 5, 6, 7 };
        readonly Ws2811.Led[] Dotcolors = {
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

        public AdafruitNeoPixelExample()
        {
            neopixel = new NeoPixel(Connectors.GPIO18, 8, 8);
            for (int i = 0; i < 100; i++)
            {
                MatrixRaise();
                MatrixBottom();
                neopixel.Render();
                Thread.Sleep(250);
            }
        }

        void MatrixRaise()
        {
            int x, y;

            for (y = 0; y < (neopixel.Height - 1); y++)
            {
                for (x = 0; x < neopixel.Width; x++)
                {
                    neopixel.Matrix[x, y] = neopixel.Matrix[x, y + 1];
                }
            }
        }

        void MatrixBottom()
        {
            int i;

            for (i = 0; i < Dotspos.Length; i++)
            {
                Dotspos[i]++;
                if (Dotspos[i] > (neopixel.Width - 1))
                {
                    Dotspos[i] = 0;
                }
                neopixel.Matrix[Dotspos[i], neopixel.Height - 1] = Dotcolors[i];
            }
        }
    }
}
