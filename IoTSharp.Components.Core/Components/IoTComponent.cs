using System;
using System.Collections.Generic;
using System.Linq;

namespace IoTSharp.Components
{
	public abstract class IoTComponent : IIoTComponent, IDisposable
	{
		public List<IIoTComponent> Components { get; private set; } = new List<IIoTComponent>();

		public virtual void OnInitialize ()
		{
			//Needs override
		}

		public virtual void OnUpdate () 
		{
			//all components can handle a update logic
		}

		public void Add(params IIoTComponent[] control)
		{
			foreach (var item in control)
			{
				if (!Components.Exists(s => s == item))
				{
					Components.Add(item);
				}
			}
		}

		public void Remove(params IIoTComponent[] control)
		{
			var toRemove = new List<IIoTComponent>();
			foreach (var item in control)
			{
				if (!Components.Exists(s => s == item))
				{
					toRemove.Add(item);
				}
			}

			foreach (var item in toRemove)
			{
				Components.Remove(item);
			}
		}

		#region Component Locator

		public IEnumerable<T> GetComponents<T>()
		{
			try {
				return Components.Where(s => typeof(T).IsAssignableFrom(s.GetType())).Select(s => (T)s);
			} catch (Exception) {
				throw new Exception($"there is no type implementing '{typeof(T).ToString()}' in instances array");
			}
		}

		public T GetComponent<T>()
		{
			return GetComponents<T>().FirstOrDefault();
		}

		#endregion

		public virtual void OnDispose()
		{

		}

		public void Dispose()
		{
			OnDispose ();
			foreach (var item in Components) {
				item.OnDispose ();
			}
		}
	}
}
