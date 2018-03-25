using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using IoTSharp.Native;

namespace IoTSharp.Components
{
	internal static class EmbeddedResources
	{
		/// <summary>
		/// Initializes static members of the <see cref="EmbeddedResources"/> class.
		/// </summary>
		static EmbeddedResources ()
		{
			ResourceNames =
				new ReadOnlyCollection<string> (typeof (EmbeddedResources).Assembly.GetManifestResourceNames ());
		}

		/// <summary>
		/// Gets the resource names.
		/// </summary>
		/// <value>
		/// The resource names.
		/// </value>
		public static ReadOnlyCollection<string> ResourceNames { get; }

		/// <summary>
		/// Extracts all the file resources to the specified base path.
		/// </summary>
		/// <param name="basePath">The base path.</param>
		public static void Extract (string resource, string basePath = null, bool replace = false, bool executable = false)
		{
			if (string.IsNullOrWhiteSpace (basePath))
				basePath = Path.GetDirectoryName (Assembly.GetEntryAssembly ().Location);

			var targetPath = Path.Combine (basePath, resource);

			if (!replace && File.Exists (targetPath)) {
				return;
			}

			using (var stream = typeof (EmbeddedResources).Assembly
			       .GetManifestResourceStream (resource)) {
				using (var outputStream = File.OpenWrite (targetPath)) {
					stream?.CopyTo (outputStream);
				}

				if (executable) {
					try {
						var executablePermissions = Standard.StringToInteger ("0777", IntPtr.Zero, 8);
						Standard.Chmod (targetPath, (uint)executablePermissions);
					} catch {
						/* Ignore */
					}
				}
			}
		}
	}
}
