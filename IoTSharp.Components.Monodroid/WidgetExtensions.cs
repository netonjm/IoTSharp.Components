using System;
using IoTSharp.Components;

namespace Android.Widget
{
	public static class WidgetExtensions
	{
		public static void Bind (this IIoTButton sender, Button button)
		{
			sender.Clicked += delegate {
				button.PerformClick ();
			};
		}

		public static void Bind (this Button sender, IIoTRelay relay, int portId)
		{
			sender.Click += delegate {
				relay.Toggle (portId);
			}; 
		}
	}
}
