using System.Drawing;
using System.Threading;
using IoTSharp.Components;
using IoTSharp.Components.Native;

namespace IoTSharp.Components.Examples.Raspbian
{
    class GameFrameExample : LedSpriteSheetExample
    {
        int[] frames = {
            7, 1, 2, 1, 5, 4, 4, 4, 3, 4, 4, 8, 5, 4
        };

        public override Bitmap GetBitmap()
        {
            var bmp = new Bitmap(GetFullPath("game.png"));
            return bmp;
        }

        public override void OnLoadedSpriteSheet(LedSpriteSheet spriteSheet)
        {
            for (int i = 0; i < frames.Length; i++)
            {
                spriteSheet.TopOffset = 8 * i;
                for (int j = 0; j < frames[i]; j++)
                {
                    items = spriteSheet.GetLedFrame(j);
                    Render();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
