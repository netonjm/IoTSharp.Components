using System.Threading;
using System.Threading.Tasks;

namespace IoTSharp.Components
{
	public abstract class IoTHubContainer : IoTComponentContainer, IIoTComponentContainer 
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

			//Initializes all components
			OnInitialize ();

			//Loop
			while (!stopping) {
				foreach (var item in Components) {
					item.Update ();
				}
				Update ();
				Thread.Sleep (DelayTime);
			}
		}

		protected void OnInitialize ()
		{
			Initialize();

			foreach (var item in Components) {
				item.Initialize();
			}
		}

		public async Task StartAsync (int delayTime = DefaultLoopTime, bool loop = false)
		{
			await Task.Run (() => {
				Start (delayTime, loop);
			});
		}

		public void Stop ()
		{
			stopping = true;
		}
	}
}
