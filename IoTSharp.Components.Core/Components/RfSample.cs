using System.IO;
using System.Linq;

namespace IoTSharp.Components
{
	public class RfSample : IRfSample
	{
		double [] switchTimes;

		public RfSample (double [] values) : this ()
		{
			this.switchTimes = values;
		}

		public RfSample ()
		{
		}

		public int Length {
			get {
				return switchTimes.Length;
			}
		}

		public double Duration {
			get {
				return switchTimes [switchTimes.Length - 1];
			}
		}

		public double GetData (int index)
		{
			return switchTimes [index];
		}

		public void Save (string file)
		{
			using (var fs = File.OpenWrite (file)) {
				BinaryWriter bw = new BinaryWriter (fs);
				bw.Write (switchTimes.Length);
				for (int n = 0; n < switchTimes.Length; n++)
					bw.Write (switchTimes [n]);
			};
		}

		public void Read (string file)
		{
			using (var fs = File.OpenRead (file)) {
				BinaryReader br = new BinaryReader (fs);
				int len = br.ReadInt32 ();
				switchTimes = new double [len];
				for (int n = 0; n < len; n++)
					switchTimes [n] = br.ReadDouble ();
			};
		}

		public override string ToString ()
		{
			var switchT = string.Join (", ", switchTimes.Select (s => s.ToString ()));
			return $"[RfSample: {switchT} -> DataCount={Length}, Duration={Duration}]";
		}
	}
}
