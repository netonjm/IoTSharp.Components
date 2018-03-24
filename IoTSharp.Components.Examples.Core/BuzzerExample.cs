namespace IoTSharp.Components.Examples
{
	public class BuzzerExample
	{
		//FREQUENCIES
		const int cL = 129;
		const int cLS = 139;
		const int dL = 146;
		const int dLS = 156;
		const int eL = 163;
		const int fL = 173;
		const int fLS = 185;
		const int gL = 194;
		const int gLS = 207;
		const int aL = 219;
		const int aLS = 228;
		const int bL = 232;
		const int c = 261;
		const int cS = 277;
		const int d = 294;
		const int dS = 311;
		const int e = 329;
		const int f = 349;
		const int fS = 370;
		const int g = 391;
		const int gS = 415;
		const int a = 440;
		const int aS = 455;
		const int b = 466;
		const int cH = 523;
		const int cHS = 554;
		const int dH = 587;
		const int dHS = 622;
		const int eH = 659;
		const int fH = 698;
		const int fHS = 740;
		const int gH = 784;
		const int gHS = 830;
		const int aH = 880;
		const int aHS = 910;
		const int bH = 933;

		//The source code of the Imperial March from Star Wars
		public BuzzerExample()
		{
			var led = new Buzzer(Connectors.GPIO18);
			led.Beep (a, 500);
			led.Beep (a, 500);
			led.Beep (f, 350);
			led.Beep (cH, 150);

			led.Beep (a, 500);
			led.Beep (f, 350);
			led.Beep (cH, 150);
			led.Beep (a, 1000);
			led.Beep (eH, 500);

			led.Beep (eH, 500);
			led.Beep (eH, 500);
			led.Beep (fH, 350);
			led.Beep (cH, 150);
			led.Beep (gS, 500);

			led.Beep (f, 350);
			led.Beep (cH, 150);
			led.Beep (a, 1000);
			led.Beep (aH, 500);
			led.Beep (a, 350);

			led.Beep (a, 150);
			led.Beep (aH, 500);
			led.Beep (gHS, 250);
			led.Beep (gH, 250);
			led.Beep (fHS, 125);

			led.Beep (fH, 125);
			led.Beep (fHS, 250);

			Env.Timing.SleepMilliseconds(250);

			led.Beep (aS, 250);
			led.Beep (dHS, 500);
			led.Beep (dH, 250);
			led.Beep (cHS, 250);
			led.Beep (cH, 125);

			led.Beep (b, 125);
			led.Beep (cH, 250);

			Env.Timing.SleepMilliseconds(250);

			led.Beep (f, 125);
			led.Beep (gS, 500);
			led.Beep (f, 375);
			led.Beep (a, 125);
			led.Beep (cH, 500);

			led.Beep (a, 375);
			led.Beep (cH, 125);
			led.Beep (eH, 1000);
			led.Beep (aH, 500);
			led.Beep (a, 350);

			led.Beep (a, 150);
			led.Beep (aH, 500);
			led.Beep (gHS, 250);
			led.Beep (gH, 250);
			led.Beep (fHS, 125);

			led.Beep (fH, 125);
			led.Beep (fHS, 250);

			Env.Timing.SleepMilliseconds(250);

			led.Beep (aS, 250);
			led.Beep (dHS, 500);
			led.Beep (dH, 250);
			led.Beep (cHS, 250);
			led.Beep (cH, 125);

			led.Beep (b, 125);
			led.Beep (cH, 250);

			Env.Timing.SleepMilliseconds(250);

			led.Beep (f, 250);
			led.Beep (gS, 500);
			led.Beep (f, 375);
			led.Beep (cH, 125);
			led.Beep (a, 500);

			led.Beep (f, 375);
			led.Beep (c, 125);
			led.Beep (a, 1000);
		}
	}
}
