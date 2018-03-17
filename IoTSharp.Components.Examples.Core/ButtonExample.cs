using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class ButtonExample
	{
		const int max = 2;
		int count;

		public ButtonExample () 
		{
			var button = new IoTButton (Connectors.GPIO17);
			button.Clicked += delegate {
				count++;
				Console.WriteLine("You clicked the button! {0}/{1}", count, max);
			};

			while (count < max)
			{
				button.Update ();
				Thread.Sleep (250);
			}

			button.Dispose();
		}
	}
}
