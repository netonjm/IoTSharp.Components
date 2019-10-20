using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using IoTSharp.Components.Native;
using IoTSharp.Native;

namespace IoTSharp.Components.Examples.Raspbian
{
    abstract class LedSpriteSheetExample : IDisposable
    {
        protected string GetFullPath(string file)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return Path.Combine(path, file);
        }

        readonly NeoPixel neopixel;
        public LedSpriteSheetExample ()
        {
            neopixel = new NeoPixel(Connectors.GPIO18, 8, 8);

            OnInitialize(neopixel);
            OnUpdate(neopixel);
        }

        protected Ws2811.Led[,] items = new Ws2811.Led[8, 8];
        Bitmap bitmap;

        public abstract Bitmap GetBitmap();
        public abstract void OnLoadedSpriteSheet(LedSpriteSheet spriteSheet);

        public virtual void OnInitialize(NeoPixel neoPixel)
        {
            bitmap = GetBitmap();
            var ledSpriteSheet = new LedSpriteSheet(bitmap);
            OnLoadedSpriteSheet(ledSpriteSheet);
        }

        public virtual void OnUpdate(NeoPixel neopixel)
        {
            for (int y = 0; y < neopixel.Height; y++)
            {
                for (int x = 0; x < neopixel.Width; x++)
                {
                    neopixel.Matrix[x, y] = items[x, y];
                }
            }
        }

        protected void Render()
        {
            for (int y = 0; y < neopixel.Height; y++)
            {
                for (int x = 0; x < neopixel.Width; x++)
                {
                    neopixel.Matrix[x, y] = items[x, y];
                }
            }
            neopixel.Render();
        }

        public virtual void Dispose()
        {
            bitmap.Dispose();
        }
    }
}
