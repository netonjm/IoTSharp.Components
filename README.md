# IoTSharp.Components

Using an abstraction library to access IoT Components in your Raspberry using Raspbian/AndroidThings.

## Status:

| Gitter Chat 
|---|
|  [![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/mono/mono-iot?utm_campaign=pr-badge&utm_content=badge&utm_medium=badge&utm_source=badge) |


## Overview


The world of home automation is something really fascinating, every day that I learn new things, I realize all the possibilities and opportunities of business that it has.


For a few years, Raspberry has entered as a hurricane in the market, creating an amazing hardware ecosystem accessible for anyone, including students... and probably this was the secret of its popularity. 


Nowadays there are many distributions available to download, but focusing in .Net ecosystem we have:


| OS                          | Runtime                   | Backend                |
| --------------------------- | ------------------------- | ---------------------- |
| Raspbian (Basada en Debian) | Mono/.Net Core            | [Raspbery.IO](https://unosquare.github.io/raspberryio/)            |
| AndroidThings               | Mono                      | [Xamarin.Android.Things](https://developer.android.com/things/index.html) |
| Windows 10 IoT              | Net Framework / .Net Core | Not implemented        |
| Ubuntu Mate                 | Mono/.Net Core            | Not implemented        |


Each OS may have different requirements, so I recommend you visit the installation section before continuing.


The basic idea of this library is to simplify in a natural way the access to iot components with .Net unify the code in all the platforms with a single API.


## Introducing Components / Modules


But the thing that differentiates a Raspberry from a normal device/laptop/computer are the GPIO ports. Thanks to these I/O pins, we can connect one or several hardware components and read and change their states. I strongly recommend you read some technical documentation to understand how they work.

Note: There are variations in the numbering and ordering of the pins depending on the model you have.


<img src="https://github.com/netonjm/IoTSharp.Components/raw/master/images/leaf.jpg" height="300" />


Tip: You can download and print a Pinout leaf and stamp it in your model to save time and avoid errors when connecting components.
https://github.com/splitbrain/rpibplusleaf


Currently there are many manufacturers and types of modules available on the market: sensors, switches, LEDs, analog signals ... and you can buy different initiation sets at a very low price.


## Using the API


As we have talk before, we have different backends for each platform. Each backend uses some bindings/libraries to access the GPIO port.

All this ends in different implementations of the IoTPin implementing IIoTPin interface.
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Interfaces/IIoTPin.cs

**IoTPin** class is the model that independently defines each GPIO, with methods to indicate the direction and properties to obtain and change its current state.

Here we have the code of a simple example to make a led blink 20 times:

```csharp
// Pin initialization
var pin = new IoTPin (Connectors.GPIO17);

//We set the direction (IN/OUT) and the initial state
pin.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);

//We change the value of the Pin On/Off in each loop
while (true) {
    pin.Value = !pin.Value;
    System.Threading.Thread.Sleep (500);
}
```

## Reusing our code


The truth is that the abstraction has already removed some noise in the code, but if we also had a more complex logic that is repeated using this same code in different GPIO ports, we could do:

```csharp
public class CustomLed
{
       readonly IoTPin pin;        
        public CustomLed (Connectors connector) 
        {
		// Pin initialization
                pin = new IoTPin (connector);
		//We set the direction (IN/OUT) and the initial state
                pin.SetDirection (IoTPinDirection.DirectionOutInitiallyLow);          
        }
        
        public void Toggle () 
        {
              //Obtenemos y seteamos el valor contrario al actual
              pin.Value = !pin.Value;
        }
}
```

So the call in our main main would be:

```csharp
public class Program
{
       static void Main (string [] args) 
       {
           var led = new CustomLed (Connectors.GPIO17);
           while (true) {
                led.Toggle ();
                System.Threading.Thread.Sleep (500);
           }
       }
}
```

## Components

A total of 8 components are currently available, in addition to the IoT special base classes (marked in bold that we will explain later).

- **[IoTComponent](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/IoTComponent.cs)**
  - [Button](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/Button.cs)
  - [ProximitySensor](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/ProximitySensor.cs)
  - [Relay](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/Relay.cs)
  - [RfReceiver](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/RfReceiver.cs)
  - [RfTransmitter](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/RfTransmitter.cs)
  - [RotatoryEncoder3](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/RotaryEncoder3.cs)
  - [UltraSonicSensor](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/UltraSonicSensor.cs)
  - [SoundPlayer](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Raspbian/SoundPlayer.cs)
  - **[IoTHub](https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/IoTHub.cs)**

### Button

Also called push switch. It allows you detect realworld clicks and it works in the same way like a normal application Button.
It raises some actions (Down/Up/Clicked) also stores his current state

<img src="https://www.boxelectronica.com/334-large_default/push-button-12x12x8mm.jpg" height="100">

*Example Code:
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/ButtonExample.cs*


[Schematic](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-button.png)

### Proximity Sensor

This sensor detects the presence in the range of the cell, then it raises a PresenceStatusChanged event.

<img src="https://s-media-cache-ak0.pinimg.com/236x/20/c4/3a/20c43a67d0d3a794f99a1601fe16fbec.jpg" height="100">

*Example Code:
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/ProximitySensorExample.cs*

[Schematic](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-button.png)

### Relay

A relay is an electrically operated switch. It is normally used to turn on/off lights

<img src="http://josehervas.es/sensorizados/wp-content/uploads/2013/11/bannerpng.png" height="100">

The use is very simple:

```csharp
var relay = new Relay (Connectors.GPIO17, Connectors.GPIO27);
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
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/RelayExample.cs*

[Schematic](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-relay1.png)

### Blind

This component allows control any kind of motorized projection screen kit, like a custom window blind (or projector screen) with 2 Phases (Up, Down) and neutral wire.

<img src="http://i01.i.aliimg.com/img/pb/743/301/527/527301743_184.jpg" height="300" />

*Example Code:
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/BlindExample.cs*


[Schematic](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-relay2.png)

### RfReceiver

RF Module is a cheap wireless communication module for low cost application. RF Module comprises of a transmitter and a receiver that operate at a radio frequency range. Usually, the frequency at which these modules communicate will be 315 MHz or 433 MHz.

This module listen for this signals and stores in a byte array all data, which can be stored in a file or processed by a Transmitter generating a RfSample.  

<img src="https://goo.gl/c6S2B8" height="100">


[Schematic](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-rf.png)

### RfTransmitter

Sends and transmits a loaded byte array data processed.

<img src="https://goo.gl/UBGWB7" height="100" />

*Example Code:
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/RfExample.cs*


### UltraSonicSensor

An Ultrasonic sensor is a device that can measure the distance to an object by using sound waves. It measures distance by sending out a sound wave at a specific frequency and listening for that sound wave to bounce back. By recording the elapsed time between the sound wave being generated and the sound wave bouncing back, it is possible to calculate the distance between the sonar sensor and the object.

<img src="https://www.makerlab-electronics.com/my_uploads/2016/05/ultrasonic-sensor-HCSR04-1.jpg" height="100">

*Example Code:
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/UltraSonicSensorExample.cs*

[Schematic](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-ultrasoundsensor.png)

### RotatoryEncoder3

A rotary encoder, also called a shaft encoder, is an electro-mechanical device that converts the angular position or motion of a shaft or axle to an analog or digital signal.

<img src="https://pandaelectronicsbd.com/wp-content/uploads/2017/07/sku_310402_2.jpg" height="100">

### DhtSensor (DHT11/DHT22)

The DHT11/22 is a basic, ultra low-cost digital temperature and humidity sensor. It uses a capacitive humidity sensor and a thermistor to measure the surrounding air, and spits out a digital signal on the data pin (no analog input pins needed). Its fairly simple to use, but requires careful timing to grab data. The only real downside of this sensor is you can only get new data from it once every 2 seconds, so when using our library, sensor readings can be up to 2 seconds old.

<img src="https://github.com/netonjm/IoTSharp.Components/raw/master/images/comp-dht11.jpg" height="100">

*Example Code:
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Examples.Core/DhtSensorExample.cs*

[Schematic without resistor](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-DHT11.png)
[Schematic with resistor](https://github.com/netonjm/IoTSharp.Components/raw/master/images/setup-DHT11-resistor.png)

## Improving the current API

In the previous example, we have learned how to use a **IoTPin** and encapsulated the code for a better reuse, but ... how could we improve the API a bit more?

I'm sure you've noticed, looking at the class hierarchy, that there are things we have not talked about yet ... you are right, **IoTComponent** and **IoTHub**.

Why we need them? It depends your context, they offer you a features very interesting, and maybe it could be usefull in some point of your project.

What they do?

- Centralizes the way of Initialize and Dispose components, perfect in cases when you deal with too many components or avoid unwanted disposing states.
- It creates a hierarchy of components and it allows centralize the Update of all of them in a loop process easily.

In essence, we add all our IoTComponents into a IoTHub, which will be responsible for starting this loop. 


* **IoTComponent:** Represents a basic class of a component.

It has methods to manage and obtain elements of its collection of children components.

There are two methods to overwrite:

- OnInitialize: It must include code referring to the initialization (only runs once in a session)

- OnUpdate: It must include code that we want to repeat in each iteration of the general loop, such as status updates, variables, etc.

**Note: The component are only added to the hierarchy if we add it using AddComponent in your IoTHab. If not this methods never be called**

https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/IoTComponent.cs

* **IoTHub:** This class inherits from **IoTComponent**, and has a Start method to start the update service.

Once executed, the initialization phase is first launched, and then an infinite loop with a delay begins, where the OnUpdate methods of all the cascaded child components are called.

Start: Starts the state update process
Stop: Stops the status update process.
https://github.com/netonjm/IoTSharp.Components/blob/master/IoTSharp.Components.Core/Components/IoTHub.cs


## Creating our first Hub

As we have explained before, the Hub is responsible for starting the loop process with all the components that we add.

If we wanted to use our CustomLed, we should only inherit from IoTComponent.


```cs
public class CustomLed : IoTComponent
```

Now we can add the component to our first Hub:

```cs
class MyCustomHub : IoTHub
{
        readonly CustomLed led;
        
        public MyCustomHub () 
        {
              led = new CustomLed (Connectors.GPIO17);
        }
        
        public override void OnUpdate ()
        {
              led.Toggle ();
        }
}
```

You just have to initialize it in the Program class

```cs
public class Program
{
       static void Main (string [] args) 
       {
            var hub = new MyCustomHub ();
            hub.Start (500, true);
       }
} 
```

And that's it!

## Other interesting projects related:

**HapSharp:** https://github.com/netonjm/HapSharp
Using the .NET Bridge Accessory Server for HomeKit to control your home appliances and IOT devices.
