using System;
#if !THROW_OBJECT_EXCEPTIONS
using System.Runtime.InteropServices;
#endif

namespace SkiaSharp
{
#if THROW_OBJECT_EXCEPTIONS
	using GCHandle = GCHandleProxy;
#endif

	internal partial struct GRVkBackendContextNative
	{
		public static GRVkBackendContextNative FromManaged (ref GRVkBackendContext managed, out GCHandle gch, out IntPtr ctx) =>
			new GRVkBackendContextNative {
				fInstance = managed.VkInstance,
				fPhysicalDevice = managed.VkPhysicalDevice,
				fDevice = managed.VkDevice,
				fQueue = managed.VkQueue,
				fGraphicsQueueIndex = managed.GraphicsQueueIndex,
				fMaxAPIVersion = managed.MaxAPIVersion,
				fVkExtensions = managed.Extensions.Handle,
				fDeviceFeatures = managed.VkDeviceFeatures,
				fDeviceFeatures2 = managed.VkDeviceFeatures2,
				fGetProc = DelegateProxies.Create (managed.GetProc, DelegateProxies.GRVkGetProcDelegateProxy, out gch, out ctx),
				fProtectedContext = managed.ProtectedContext ? (byte)1 : (byte)0,
			};
	}

	public unsafe partial struct GRVkBackendContext : IEquatable<GRVkBackendContext>
	{
		public IntPtr VkInstance { readonly get; set; }

		public IntPtr VkPhysicalDevice { readonly get; set; }

		public IntPtr VkDevice { readonly get; set; }

		public IntPtr VkQueue { readonly get; set; }

		public UInt32 GraphicsQueueIndex { readonly get; set; }

		public UInt32 MaxAPIVersion { readonly get; set; }

		public GRVkExtensions Extensions { readonly get; set; }

		public IntPtr VkDeviceFeatures { readonly get; set; }

		public IntPtr VkDeviceFeatures2 { readonly get; set; }

		public GRVkGetProcDelegate GetProc { readonly get; set; }

		public bool ProtectedContext { readonly get; set; }

		public readonly bool Equals (GRVkBackendContext obj) =>
			VkInstance == obj.VkInstance &&
			VkPhysicalDevice == obj.VkPhysicalDevice &&
			VkDevice == obj.VkDevice &&
			VkQueue == obj.VkQueue &&
			GraphicsQueueIndex == obj.GraphicsQueueIndex &&
			MaxAPIVersion == obj.MaxAPIVersion &&
			Extensions == obj.Extensions &&
			VkDeviceFeatures == obj.VkDeviceFeatures &&
			VkDeviceFeatures2 == obj.VkDeviceFeatures2 &&
			GetProc == obj.GetProc &&
			ProtectedContext == obj.ProtectedContext;

		public readonly override bool Equals (object obj) =>
			obj is GRVkBackendContext f && Equals (f);

		public static bool operator == (GRVkBackendContext left, GRVkBackendContext right) =>
			left.Equals (right);

		public static bool operator != (GRVkBackendContext left, GRVkBackendContext right) =>
			!left.Equals (right);

		public readonly override int GetHashCode ()
		{
			var hash = new HashCode ();
			hash.Add (VkInstance);
			hash.Add (VkPhysicalDevice);
			hash.Add (VkDevice);
			hash.Add (VkQueue);
			hash.Add (GraphicsQueueIndex);
			hash.Add (MaxAPIVersion);
			hash.Add (Extensions);
			hash.Add (VkDeviceFeatures);
			hash.Add (VkDeviceFeatures2);
			hash.Add (GetProc);
			hash.Add (ProtectedContext);
			return hash.ToHashCode ();
		}
	}
}
