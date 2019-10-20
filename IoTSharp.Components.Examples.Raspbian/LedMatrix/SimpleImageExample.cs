using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using IoTSharp.Components;
using IoTSharp.Components.Native;

namespace IoTSharp.Components.Examples.Raspbian
{
    class SimpleImageExample : LedSpriteSheetExample
    {
        public override Bitmap GetBitmap()
        {
            var bmp = new Bitmap(GetFullPath("image.png"));
            return bmp;
        }

        public override void OnLoadedSpriteSheet(LedSpriteSheet spriteSheet)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    items = spriteSheet.GetLedFrame(i);
                    Render();
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
