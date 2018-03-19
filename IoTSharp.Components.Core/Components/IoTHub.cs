using System.Threading;
using System.Threading.Tasks;

namespace IoTSharp.Components
{
	public class IoTHub : IoTComponent, IIoTHub
	{
		const int DefaultLoopTime = 100;
		bool stopping;

		public bool Loop { get; private set; }

		public int DelayTime { get; private set; }

		public void Start (int delayTime = DefaultLoopTime, bool loop = false)
		{
			stopping = false;
			Loop = loop;
			DelayTime = delayTime;

			foreach (var item in Components) {
				item.OnInitialize ();
			}
			OnInitialize ();

			//Loop
			while (!stopping) {
				foreach (var item in Components) {
					item.OnUpdate ();
				}
				OnUpdate ();
				Thread.Sleep(DelayTime);
			}
		}

		public async Task StartAsync (int delayTime = DefaultLoopTime, bool loop = false)
		{
			await Task.Run(() => Start(delayTime, loop));
		}

		public void Stop()
		{
			stopping = true;
		}
	}
}
