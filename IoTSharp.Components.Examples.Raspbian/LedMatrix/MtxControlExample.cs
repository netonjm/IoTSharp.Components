using System.Drawing;
using System.Threading;
using IoTSharp.Components.Native;

namespace IoTSharp.Components.Examples.Raspbian
{
    class MtxControlExample : LedSpriteSheetExample
    {
        //this image was generated using mtXcontrol tool
        //you can download from https://github.com/rngtng/mtXcontrol
        public override Bitmap GetBitmap()
        {
            var bmp = new Bitmap(GetFullPath("mtxControl.bmp"));
            return bmp;
        }

        public override void OnLoadedSpriteSheet(LedSpriteSheet spriteSheet)
        {
            var frames = spriteSheet.Bitmap.Width / 8;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < frames; i++)
                {
                    items = spriteSheet.GetLedFrame(i);
                    Render();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
