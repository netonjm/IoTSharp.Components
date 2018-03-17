// HubExample.cs
// =================================================================================
// This example shows how works the IoTHubContainer class (MyCustomComponentsHub)
// It includes an example of a IoTComponent (MyCustomComponent)
// Every IoTHubContainer is an special component with children hierarchy
// There are 2 importants methods to override Initialize () and Update ()
// You can handle your logic for initialization (called 1 time) and the Update loop
// this could be configured when we call hub.Start ()
// This class also propragates initialization and disposing events to children

using System;

namespace IoTSharp.Components.Examples
{
	public class HubExample
	{
		public HubExample()
		{
			var component = new MyCustomComponent ();

			var hub = new MyCustomComponentsHub ();
			hub.AddComponent (component);

			hub.Start (1000, true);
			hub.Dispose();
		}
	}

	public class MyCustomComponent : IoTComponent
	{
		public override void Initialize()
		{
			Console.WriteLine("MyCustomComponent: Init");
		}

		public override void Update()
		{
			Console.WriteLine("MyCustomComponent: Update");
		}
	}

	class MyCustomComponentsHub : IoTHubContainer
	{
		int counter;
		const int Max = 10;

		public override void Initialize ()
		{
			counter = 5;
		}

		public override void Update ()
		{
			if (counter == Max) {
				Stop ();
				Console.WriteLine("Finished!");
				return;
			}
			Console.WriteLine(counter);
			counter++;
		}
	}
}
