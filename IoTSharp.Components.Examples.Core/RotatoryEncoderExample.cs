using System.Threading;

namespace IoTSharp.Components.Examples
{
    public class RotatoryEncoderExample
    {
        const int max = 1000;
        int count;

        public RotatoryEncoderExample()
        {
            var rotaryEncoder = new RotaryEncoder3(Connectors.GPIO17, Connectors.GPIO18);

            while (count < max)
            {
                rotaryEncoder.OnUpdate();
                Thread.Sleep(10);
                count++;
            }

            rotaryEncoder.Dispose();
        }
    }
}
