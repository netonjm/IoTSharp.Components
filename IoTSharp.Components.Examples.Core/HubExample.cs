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
			IIoTHub hub = new MyCustomHub();

			hub.Add (new MyCustomComponent("Component1"));
			hub.Add (new MyCustomComponent("Component2"));

			hub.Start (1000, true);
			hub.OnDispose ();
		}
	}

	public class MyCustomComponent : IoTComponent
	{
		public string Name { get; private set; }

		public MyCustomComponent (string name)
		{
			Name = name;
		}

		public override void OnInitialize()
		{
			Console.WriteLine ("{0}: OnInitialize", Name);
		}

		public override void OnUpdate()
		{
			Console.WriteLine ("{0}: OnUpdate", Name);
		}
	}

	class MyCustomHub : IoTHub
	{
		int counter;
		const int Max = 10;
		const string Name = "Hub";

		public override void OnInitialize ()
		{
			Console.WriteLine("{0}: OnInitialize", Name);
			counter = 5;
		}

		public override void OnUpdate ()
		{
			Console.WriteLine("{0}: OnUpdate", Name);

			if (counter == Max) {
				Stop ();
				Console.WriteLine("{0}: Finished! {1}/{2}", Name, counter, Max);
				return;
			}

			counter++;
			Console.WriteLine("{0}: Loop {1}/{2}", Name, counter, Max);
		}
	}
}
