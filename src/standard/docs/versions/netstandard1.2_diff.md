# .NET Standard 1.2 vs. 1.1

[Overview](netstandard1.2.md) | [Previous](netstandard1.1_diff.md) | [Next](netstandard1.3_diff.md)

```diff
 namespace System {
-    public sealed class String : IComparable, IComparable<string>, IEnumerable, IEquatable<string> {
+    public sealed class String : IComparable, IComparable<string>, IEnumerable, IEnumerable<char>, IEquatable<string> {
     }
 }
 namespace System.Diagnostics.Tracing {
     public class EventSource : IDisposable {
+        public Exception ConstructionException { get; }
+        public static Guid CurrentThreadActivityId { get; }
+        public static void SetCurrentThreadActivityId(Guid activityId);
+        public static void SetCurrentThreadActivityId(Guid activityId, out Guid oldActivityThatWillContinue);
+        protected void WriteEventWithRelatedActivityId(int eventId, Guid childActivityID, params object[] args);
+        protected unsafe void WriteEventWithRelatedActivityIdCore(int eventId, Guid* childActivityID, int eventDataCount, EventSource.EventData* data);
     }
     public class EventWrittenEventArgs : EventArgs {
+        public Guid ActivityId { get; }
+        public Guid RelatedActivityId { get; }
     }
 }
 namespace System.Runtime {
+    public enum GCLargeObjectHeapCompactionMode {
+        CompactOnce = 2,
+        Default = 1,
+    }
     public static class GCSettings {
+        public static GCLargeObjectHeapCompactionMode LargeObjectHeapCompactionMode { get; set; }
     }
 }
 namespace System.Runtime.InteropServices {
     public static class Marshal {
+        public static IntPtr CreateAggregatedObject<T>(IntPtr pOuter, T o);
+        public static TWrapper CreateWrapperOfType<T, TWrapper>(T o);
+        public static void DestroyStructure<T>(IntPtr ptr);
+        public static IntPtr GetComInterfaceForObject<T, TInterface>(T o);
+        public static TDelegate GetDelegateForFunctionPointer<TDelegate>(IntPtr ptr);
+        public static IntPtr GetFunctionPointerForDelegate<TDelegate>(TDelegate d);
+        public static void GetNativeVariantForObject<T>(T obj, IntPtr pDstNativeVariant);
+        public static T GetObjectForNativeVariant<T>(IntPtr pSrcNativeVariant);
+        public static T[] GetObjectsForNativeVariants<T>(IntPtr aSrcNativeVariant, int cVars);
+        public static IntPtr OffsetOf<T>(string fieldName);
+        public static T PtrToStructure<T>(IntPtr ptr);
+        public static void PtrToStructure<T>(IntPtr ptr, T structure);
+        public static int SizeOf<T>();
+        public static int SizeOf<T>(T structure);
+        public static void StructureToPtr<T>(T structure, IntPtr ptr, bool fDeleteOld);
+        public static IntPtr UnsafeAddrOfPinnedArrayElement<T>(T[] arr, int index);
     }
 }
 namespace System.Threading {
+    public sealed class Timer : IDisposable {
+        public Timer(TimerCallback callback, object state, int dueTime, int period);
+        public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period);
+        public bool Change(int dueTime, int period);
+        public bool Change(TimeSpan dueTime, TimeSpan period);
+        public void Dispose();
+    }
+    public delegate void TimerCallback(object state); {
+        public TimerCallback(object @object, IntPtr method);
+        public virtual IAsyncResult BeginInvoke(object state, AsyncCallback callback, object @object);
+        public virtual void EndInvoke(IAsyncResult result);
+        public virtual void Invoke(object state);
+    }
 }
```
