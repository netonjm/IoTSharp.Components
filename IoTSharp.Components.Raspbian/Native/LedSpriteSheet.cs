using System;
using System.Drawing;
using IoTSharp.Native;

namespace IoTSharp.Components.Native
{
    class LedSpriteSheet
    {
        public Bitmap Bitmap { get; }

        public int Correction { get; set; } = -95;
        public int TopOffset { get; set; }
        public int LeftOffset { get; set; }

        public int ImagePixel { get; set; } = 8;

        public LedSpriteSheet(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
        }

        public Ws2811.Led[,] GetLedFrame(int i)
        {
            return Bitmap.GetNeoPixelsFromBitmap(LeftOffset + (i * ImagePixel), TopOffset, ImagePixel, Correction);
        }
    }

}