using System;
using System.Diagnostics;

namespace IoTSharp.Components
{
	public class BuzzerNote
	{
		public int Value { get; private set; }
		public int Duration { get; private set; }

		public BuzzerNote (int value, int duration)
		{
			this.Value = value;
			this.Duration = duration;
		}
	}

	public class Buzzer : IoTComponent
	{
		readonly IoTPin pin;

		public Buzzer(Connectors gpio)
		{
			pin = new IoTPin(gpio);
			pin.SetDirection(IoTPinDirection.DirectionOutInitiallyLow);
		}

		public void Beep (BuzzerNote note)
		{
			Beep (note.Value, note.Duration);
		}

		//This function generates the square wave that makes the piezo speaker sound at a determinated frequency.
		public void Beep(int note, int duration)
		{
			//This is the semiperiod of each note.
			int beepDelay = (int)(1000000f / note);
			//This is how much time we need to spend on the note.
			int time = (int)((duration * 1000) / (beepDelay * 2));
			for (int i = 0; i < time; i++)
			{
				//1st semiperiod
				pin.Value = true;
				Env.Timing.SleepMicroseconds(beepDelay);
				//2nd semiperiod
				pin.Value = false;
				Env.Timing.SleepMicroseconds(beepDelay);
			}

			//Add a little delay to separate the single notes
			pin.Value = false;
			Env.Timing.SleepMilliseconds(20);
		}
	}
}
