# IoTSharp.Components

This library allows user to interact easily with Components connected to GPIO of a device. The library is in a early stage, and right now it only covers Raspberry components, but in a future, the code will be refactored to have a expecific backend for platform (something similar like Xwt or Xamarin.Forms does). 

Also, every component encapsulates the complex logic and makes the code maintainable and easy to read like a normal desktop application. 

## Class structure
- IoTComponent
  - IoTButton
  - IoTSensor
  - IoTRfReceiver
  - IoTRfTransmitter
  - IoTSoundPlayer
  - IoTComponentContainer
  	- IoTHubContainer**
  	- IoTRelay
    	- IoTBlind

## Components

These are the same as describe, your modules, boards, accessories.. it hiddens all complex logic inside it, because a normal user only needs to know the thing he expects:

A) In what IO pin is connected

B) Handling action, set data or check properties

Every other thing like dispose objects, error management, etc... must be managed automatically by the toolkit

### Button

Or push switch.. it allows you detect realworld clicks. It works really same like a Form button, raising actions Down/Up/Clicked and current state button (IsPressed)

![Button](https://www.boxelectronica.com/334-large_default/push-button-12x12x8mm.jpg) 

*Example Code:
https://github.com/netonjm/iotsharp-components/blob/master/IoTSharp.Components.Examples.Core/ButtonTest.cs*

### Sensor

It's detects a presence in the range of the cell. It raises PresenceStatusChanged event and you can get the actual value with HasPresence property

![Proximity Sensor](https://s-media-cache-ak0.pinimg.com/236x/20/c4/3a/20c43a67d0d3a794f99a1601fe16fbec.jpg)

*Example Code:
https://github.com/netonjm/iotsharp-components/blob/master/IoTSharp.Components.Examples.Core/SensorTest.cs*

### Relay

A relay is an electrically operated switch. Many relays use an electromagnet to mechanically operate a switch, but other operating principles are also used, such as solid-state relays. Relays are used where it is necessary to control a circuit by a separate low-power signal, or where several circuits must be controlled by one signal. 

![Relay](http://josehervas.es/sensorizados/wp-content/uploads/2013/11/bannerpng.png)

The use is very simple:

```csharp
var relay = new IoTRelay(Connectors.GPIO17, Connectors.GPIO27);
```

Defines a 2 relay module connected from port 0 (Gpio17) and port 1 (Gpio27)...

```csharp
relay.EnablePin (0, [true|false]);
```

Enables/Disables module 0 (Connected to Gpio17)

```csharp
relay.Toggle (1);
```

Toggles actual value in module 1 (Connected to Gpio27)

*Example Code:
https://github.com/netonjm/iotsharp-components/blob/master/IoTSharp.Components.Examples.Core/RelayTest.cs*

### Blind

This component allows control any kind of motorized projection screen kit, like a custom window blind (or projector screen) with 2 Phases (Up, Down) and neutral wire.

![Blind](http://i01.i.aliimg.com/img/pb/743/301/527/527301743_184.jpg) 

*Example Code:
https://github.com/netonjm/iotsharp-components/blob/master/IoTSharp.Components.Examples.Core/BlindTest.cs*

### Hub

- Ok, now I know what is a component.. but then what is a Hub? -
Have you ever programmed a videogame like #CocosSharp? If yes, you'll surelly you know what is a scene. This is something similat to Hub concept.

A Hub is a logical collection of functionality in your application. These means in essence a place where you can drop Components and generate some logic begin the time.

### How works:

A Hub manages code in 2 states: Initialization and Update methods if you need to do something is here where you have to do it to avoid unwanted NRE and possible bad statements.

- Initialization method

Overriding this method your code will execute 1 time, this perfect to instanciate objects, etc... 

- Update method

Executes the code into a infinite loop every X miliseconds (this could be changed with a parameter calling Start function).

## Code example:

All components inherits from IoTComponent and some of them from IoTComponentContainer. 

This is an example of a simple CustomHub

```csharp
	class SensorExampleHub : IoTHub
	{
		public override void Init ()
		{
			var presence = new IoTSensor (Connectors.GPIO18);
			presence.PresenceStatusChanged += (s) => {
				Console.WriteLine ($"PresenceStatusChanged {s}");
			};
			AddComponent (presence, relay);
		}
	}
```

* THAT'S IT! *

To be continue...

