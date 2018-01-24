# .NET Standard 1.1 vs. 1.0

[Overview](netstandard1.1.md) | [Next](netstandard1.2_diff.md)

```diff
 namespace System {
+    public sealed class DataMisalignedException : Exception {
+        public DataMisalignedException();
+        public DataMisalignedException(string message);
+        public DataMisalignedException(string message, Exception innerException);
+    }
+    public class DllNotFoundException : TypeLoadException {
+        public DllNotFoundException();
+        public DllNotFoundException(string message);
+        public DllNotFoundException(string message, Exception inner);
+    }
 }
+namespace System.Collections.Concurrent {
+    public class BlockingCollection<T> : ICollection, IDisposable, IEnumerable, IEnumerable<T> {
+        public BlockingCollection();
+        public BlockingCollection(int boundedCapacity);
+        public BlockingCollection(IProducerConsumerCollection<T> collection);
+        public BlockingCollection(IProducerConsumerCollection<T> collection, int boundedCapacity);
+        public int BoundedCapacity { get; }
+        public int Count { get; }
+        public bool IsAddingCompleted { get; }
+        public bool IsCompleted { get; }
+        public void Add(T item);
+        public void Add(T item, CancellationToken cancellationToken);
+        public static int AddToAny(BlockingCollection<T>[] collections, T item);
+        public static int AddToAny(BlockingCollection<T>[] collections, T item, CancellationToken cancellationToken);
+        public void CompleteAdding();
+        public void CopyTo(T[] array, int index);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public IEnumerable<T> GetConsumingEnumerable();
+        public IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken);
+        public T Take();
+        public T Take(CancellationToken cancellationToken);
+        public static int TakeFromAny(BlockingCollection<T>[] collections, out T item);
+        public static int TakeFromAny(BlockingCollection<T>[] collections, out T item, CancellationToken cancellationToken);
+        public T[] ToArray();
+        public bool TryAdd(T item);
+        public bool TryAdd(T item, int millisecondsTimeout);
+        public bool TryAdd(T item, int millisecondsTimeout, CancellationToken cancellationToken);
+        public bool TryAdd(T item, TimeSpan timeout);
+        public static int TryAddToAny(BlockingCollection<T>[] collections, T item);
+        public static int TryAddToAny(BlockingCollection<T>[] collections, T item, int millisecondsTimeout);
+        public static int TryAddToAny(BlockingCollection<T>[] collections, T item, TimeSpan timeout);
+        public static int TryAddToAny(BlockingCollection<T>[] collections, T item, int millisecondsTimeout, CancellationToken cancellationToken);
+        public bool TryTake(out T item);
+        public bool TryTake(out T item, int millisecondsTimeout);
+        public bool TryTake(out T item, int millisecondsTimeout, CancellationToken cancellationToken);
+        public bool TryTake(out T item, TimeSpan timeout);
+        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item);
+        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, int millisecondsTimeout);
+        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, TimeSpan timeout);
+        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, int millisecondsTimeout, CancellationToken cancellationToken);
+    }
+    public class ConcurrentBag<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
+        public ConcurrentBag();
+        public ConcurrentBag(IEnumerable<T> collection);
+        public int Count { get; }
+        public bool IsEmpty { get; }
+        public void Add(T item);
+        public void CopyTo(T[] array, int index);
+        public IEnumerator<T> GetEnumerator();
+        public T[] ToArray();
+        public bool TryPeek(out T result);
+        public bool TryTake(out T result);
+    }
+    public class ConcurrentDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> {
+        public ConcurrentDictionary();
+        public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection);
+        public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer);
+        public ConcurrentDictionary(IEqualityComparer<TKey> comparer);
+        public ConcurrentDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer);
+        public ConcurrentDictionary(int concurrencyLevel, int capacity);
+        public ConcurrentDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer);
+        public int Count { get; }
+        public bool IsEmpty { get; }
+        public TValue this[TKey key] { get; set; }
+        public ICollection<TKey> Keys { get; }
+        public ICollection<TValue> Values { get; }
+        public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory);
+        public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);
+        public void Clear();
+        public bool ContainsKey(TKey key);
+        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
+        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);
+        public TValue GetOrAdd(TKey key, TValue value);
+        public KeyValuePair<TKey, TValue>[] ToArray();
+        public bool TryAdd(TKey key, TValue value);
+        public bool TryGetValue(TKey key, out TValue value);
+        public bool TryRemove(TKey key, out TValue value);
+        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);
+    }
+    public class ConcurrentQueue<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
+        public ConcurrentQueue();
+        public ConcurrentQueue(IEnumerable<T> collection);
+        public int Count { get; }
+        public bool IsEmpty { get; }
+        public void CopyTo(T[] array, int index);
+        public void Enqueue(T item);
+        public IEnumerator<T> GetEnumerator();
+        public T[] ToArray();
+        public bool TryDequeue(out T result);
+        public bool TryPeek(out T result);
+    }
+    public class ConcurrentStack<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
+        public ConcurrentStack();
+        public ConcurrentStack(IEnumerable<T> collection);
+        public int Count { get; }
+        public bool IsEmpty { get; }
+        public void Clear();
+        public void CopyTo(T[] array, int index);
+        public IEnumerator<T> GetEnumerator();
+        public void Push(T item);
+        public void PushRange(T[] items);
+        public void PushRange(T[] items, int startIndex, int count);
+        public T[] ToArray();
+        public bool TryPeek(out T result);
+        public bool TryPop(out T result);
+        public int TryPopRange(T[] items);
+        public int TryPopRange(T[] items, int startIndex, int count);
+    }
+    public enum EnumerablePartitionerOptions {
+        NoBuffering = 1,
+        None = 0,
+    }
+    public interface IProducerConsumerCollection<T> : ICollection, IEnumerable, IEnumerable<T> {
+        void CopyTo(T[] array, int index);
+        T[] ToArray();
+        bool TryAdd(T item);
+        bool TryTake(out T item);
+    }
+    public abstract class OrderablePartitioner<TSource> : Partitioner<TSource> {
+        protected OrderablePartitioner(bool keysOrderedInEachPartition, bool keysOrderedAcrossPartitions, bool keysNormalized);
+        public bool KeysNormalized { get; }
+        public bool KeysOrderedAcrossPartitions { get; }
+        public bool KeysOrderedInEachPartition { get; }
+        public override IEnumerable<TSource> GetDynamicPartitions();
+        public virtual IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions();
+        public abstract IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount);
+        public override IList<IEnumerator<TSource>> GetPartitions(int partitionCount);
+    }
+    public static class Partitioner {
+        public static OrderablePartitioner<TSource> Create<TSource>(TSource[] array, bool loadBalance);
+        public static OrderablePartitioner<TSource> Create<TSource>(IEnumerable<TSource> source);
+        public static OrderablePartitioner<TSource> Create<TSource>(IList<TSource> list, bool loadBalance);
+        public static OrderablePartitioner<TSource> Create<TSource>(IEnumerable<TSource> source, EnumerablePartitionerOptions partitionerOptions);
+        public static OrderablePartitioner<Tuple<int, int>> Create(int fromInclusive, int toExclusive);
+        public static OrderablePartitioner<Tuple<int, int>> Create(int fromInclusive, int toExclusive, int rangeSize);
+        public static OrderablePartitioner<Tuple<long, long>> Create(long fromInclusive, long toExclusive);
+        public static OrderablePartitioner<Tuple<long, long>> Create(long fromInclusive, long toExclusive, long rangeSize);
+    }
+    public abstract class Partitioner<TSource> {
+        protected Partitioner();
+        public virtual bool SupportsDynamicPartitions { get; }
+        public virtual IEnumerable<TSource> GetDynamicPartitions();
+        public abstract IList<IEnumerator<TSource>> GetPartitions(int partitionCount);
+    }
+}
+namespace System.Diagnostics.Tracing {
+    public sealed class EventAttribute : Attribute {
+        public EventAttribute(int eventId);
+        public int EventId { get; }
+        public EventKeywords Keywords { get; set; }
+        public EventLevel Level { get; set; }
+        public string Message { get; set; }
+        public EventOpcode Opcode { get; set; }
+        public EventTask Task { get; set; }
+        public byte Version { get; set; }
+    }
+    public enum EventCommand {
+        Disable = -3,
+        Enable = -2,
+        SendManifest = -1,
+        Update = 0,
+    }
+    public class EventCommandEventArgs : EventArgs {
+        public IDictionary<string, string> Arguments { get; }
+        public EventCommand Command { get; }
+        public bool DisableEvent(int eventId);
+        public bool EnableEvent(int eventId);
+    }
+    public enum EventKeywords : long {
+        AuditFailure = (long)4503599627370496,
+        AuditSuccess = (long)9007199254740992,
+        CorrelationHint = (long)4503599627370496,
+        EventLogClassic = (long)36028797018963968,
+        None = (long)0,
+        Sqm = (long)2251799813685248,
+        WdiContext = (long)562949953421312,
+        WdiDiagnostic = (long)1125899906842624,
+    }
+    public enum EventLevel {
+        Critical = 1,
+        Error = 2,
+        Informational = 4,
+        LogAlways = 0,
+        Verbose = 5,
+        Warning = 3,
+    }
+    public abstract class EventListener : IDisposable {
+        protected EventListener();
+        public void DisableEvents(EventSource eventSource);
+        public virtual void Dispose();
+        public void EnableEvents(EventSource eventSource, EventLevel level);
+        public void EnableEvents(EventSource eventSource, EventLevel level, EventKeywords matchAnyKeyword);
+        public void EnableEvents(EventSource eventSource, EventLevel level, EventKeywords matchAnyKeyword, IDictionary<string, string> arguments);
+        protected static int EventSourceIndex(EventSource eventSource);
+        protected internal virtual void OnEventSourceCreated(EventSource eventSource);
+        protected internal abstract void OnEventWritten(EventWrittenEventArgs eventData);
+    }
+    public enum EventOpcode {
+        DataCollectionStart = 3,
+        DataCollectionStop = 4,
+        Extension = 5,
+        Info = 0,
+        Receive = 240,
+        Reply = 6,
+        Resume = 7,
+        Send = 9,
+        Start = 1,
+        Stop = 2,
+        Suspend = 8,
+    }
+    public class EventSource : IDisposable {
+        protected internal struct EventData {
+            public IntPtr DataPointer { get; set; }
+            public int Size { get; set; }
+        }
+        protected EventSource();
+        protected EventSource(bool throwOnEventWriteErrors);
+        public Guid Guid { get; }
+        public string Name { get; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        ~EventSource();
+        public static string GenerateManifest(Type eventSourceType, string assemblyPathToIncludeInManifest);
+        public static Guid GetGuid(Type eventSourceType);
+        public static string GetName(Type eventSourceType);
+        public static IEnumerable<EventSource> GetSources();
+        public bool IsEnabled();
+        public bool IsEnabled(EventLevel level, EventKeywords keywords);
+        protected virtual void OnEventCommand(EventCommandEventArgs command);
+        public static void SendCommand(EventSource eventSource, EventCommand command, IDictionary<string, string> commandArguments);
+        public override string ToString();
+        protected void WriteEvent(int eventId);
+        protected void WriteEvent(int eventId, int arg1);
+        protected void WriteEvent(int eventId, int arg1, int arg2);
+        protected void WriteEvent(int eventId, int arg1, int arg2, int arg3);
+        protected void WriteEvent(int eventId, long arg1);
+        protected void WriteEvent(int eventId, long arg1, long arg2);
+        protected void WriteEvent(int eventId, long arg1, long arg2, long arg3);
+        protected void WriteEvent(int eventId, params object[] args);
+        protected void WriteEvent(int eventId, string arg1);
+        protected void WriteEvent(int eventId, string arg1, int arg2);
+        protected void WriteEvent(int eventId, string arg1, int arg2, int arg3);
+        protected void WriteEvent(int eventId, string arg1, long arg2);
+        protected void WriteEvent(int eventId, string arg1, string arg2);
+        protected void WriteEvent(int eventId, string arg1, string arg2, string arg3);
+        protected unsafe void WriteEventCore(int eventId, int eventDataCount, EventSource.EventData* data);
+    }
+    public sealed class EventSourceAttribute : Attribute {
+        public EventSourceAttribute();
+        public string Guid { get; set; }
+        public string LocalizationResources { get; set; }
+        public string Name { get; set; }
+    }
+    public class EventSourceException : Exception {
+        public EventSourceException();
+        public EventSourceException(string message);
+        public EventSourceException(string message, Exception innerException);
+    }
+    public enum EventTask {
+        None = 0,
+    }
+    public class EventWrittenEventArgs : EventArgs {
+        public int EventId { get; }
+        public EventSource EventSource { get; }
+        public EventKeywords Keywords { get; }
+        public EventLevel Level { get; }
+        public string Message { get; }
+        public EventOpcode Opcode { get; }
+        public ReadOnlyCollection<object> Payload { get; }
+        public EventTask Task { get; }
+        public byte Version { get; }
+    }
+    public sealed class NonEventAttribute : Attribute {
+        public NonEventAttribute();
+    }
+}
+namespace System.IO.Compression {
+    public enum CompressionLevel {
+        Fastest = 1,
+        NoCompression = 2,
+        Optimal = 0,
+    }
+    public enum CompressionMode {
+        Compress = 1,
+        Decompress = 0,
+    }
+    public class DeflateStream : Stream {
+        public DeflateStream(Stream stream, CompressionLevel compressionLevel);
+        public DeflateStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen);
+        public DeflateStream(Stream stream, CompressionMode mode);
+        public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen);
+        public Stream BaseStream { get; }
+        public override bool CanRead { get; }
+        public override bool CanSeek { get; }
+        public override bool CanWrite { get; }
+        public override long Length { get; }
+        public override long Position { get; set; }
+        protected override void Dispose(bool disposing);
+        public override void Flush();
+        public override int Read(byte[] array, int offset, int count);
+        public override long Seek(long offset, SeekOrigin origin);
+        public override void SetLength(long value);
+        public override void Write(byte[] array, int offset, int count);
+    }
+    public class GZipStream : Stream {
+        public GZipStream(Stream stream, CompressionLevel compressionLevel);
+        public GZipStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen);
+        public GZipStream(Stream stream, CompressionMode mode);
+        public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen);
+        public Stream BaseStream { get; }
+        public override bool CanRead { get; }
+        public override bool CanSeek { get; }
+        public override bool CanWrite { get; }
+        public override long Length { get; }
+        public override long Position { get; set; }
+        protected override void Dispose(bool disposing);
+        public override void Flush();
+        public override int Read(byte[] array, int offset, int count);
+        public override long Seek(long offset, SeekOrigin origin);
+        public override void SetLength(long value);
+        public override void Write(byte[] array, int offset, int count);
+    }
+    public class ZipArchive : IDisposable {
+        public ZipArchive(Stream stream);
+        public ZipArchive(Stream stream, ZipArchiveMode mode);
+        public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen);
+        public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen, Encoding entryNameEncoding);
+        public ReadOnlyCollection<ZipArchiveEntry> Entries { get; }
+        public ZipArchiveMode Mode { get; }
+        public ZipArchiveEntry CreateEntry(string entryName);
+        public ZipArchiveEntry CreateEntry(string entryName, CompressionLevel compressionLevel);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public ZipArchiveEntry GetEntry(string entryName);
+    }
+    public class ZipArchiveEntry {
+        public ZipArchive Archive { get; }
+        public long CompressedLength { get; }
+        public string FullName { get; }
+        public DateTimeOffset LastWriteTime { get; set; }
+        public long Length { get; }
+        public string Name { get; }
+        public void Delete();
+        public Stream Open();
+        public override string ToString();
+    }
+    public enum ZipArchiveMode {
+        Create = 1,
+        Read = 0,
+        Update = 2,
+    }
+}
 namespace System.Net {
+    public enum AuthenticationSchemes {
+        Anonymous = 32768,
+        Basic = 8,
+        Digest = 1,
+        IntegratedWindowsAuthentication = 6,
+        Negotiate = 2,
+        None = 0,
+        Ntlm = 4,
+    }
-    public sealed class CookieCollection : ICollection, IEnumerable {
+    public class CookieCollection : ICollection, IEnumerable {
     }
-    public sealed class CookieContainer {
+    public class CookieContainer {
-        public int Capacity { get; }
+        public int Capacity { get; set; }
-        public int MaxCookieSize { get; }
+        public int MaxCookieSize { get; set; }
-        public int PerDomainCapacity { get; }
+        public int PerDomainCapacity { get; set; }
     }
+    public class CredentialCache : ICredentials, ICredentialsByHost, IEnumerable {
+        public CredentialCache();
+        public static ICredentials DefaultCredentials { get; }
+        public static NetworkCredential DefaultNetworkCredentials { get; }
+        public void Add(string host, int port, string authenticationType, NetworkCredential credential);
+        public void Add(Uri uriPrefix, string authType, NetworkCredential cred);
+        public NetworkCredential GetCredential(string host, int port, string authenticationType);
+        public NetworkCredential GetCredential(Uri uriPrefix, string authType);
+        public IEnumerator GetEnumerator();
+        public void Remove(string host, int port, string authenticationType);
+        public void Remove(Uri uriPrefix, string authType);
+    }
+    public enum DecompressionMethods {
+        Deflate = 2,
+        GZip = 1,
+        None = 0,
+    }
     public enum HttpStatusCode {
+        UpgradeRequired = 426,
     }
+    public interface ICredentialsByHost {
+        NetworkCredential GetCredential(string host, int port, string authenticationType);
+    }
+    public interface IWebProxy {
+        ICredentials Credentials { get; set; }
+        Uri GetProxy(Uri destination);
+        bool IsBypassed(Uri host);
+    }
-    public class NetworkCredential : ICredentials {
+    public class NetworkCredential : ICredentials, ICredentialsByHost {
+        public NetworkCredential GetCredential(string host, int port, string authenticationType);
     }
+    public abstract class TransportContext {
+    }
 }
+namespace System.Net.Http {
+    public class ByteArrayContent : HttpContent {
+        public ByteArrayContent(byte[] content);
+        public ByteArrayContent(byte[] content, int offset, int count);
+        protected override Task<Stream> CreateContentReadStreamAsync();
+        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context);
+        protected internal override bool TryComputeLength(out long length);
+    }
+    public enum ClientCertificateOption {
+        Automatic = 1,
+        Manual = 0,
+    }
+    public abstract class DelegatingHandler : HttpMessageHandler {
+        protected DelegatingHandler();
+        protected DelegatingHandler(HttpMessageHandler innerHandler);
+        public HttpMessageHandler InnerHandler { get; set; }
+        protected override void Dispose(bool disposing);
+        protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
+    }
+    public class FormUrlEncodedContent : ByteArrayContent {
+        public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection);
+    }
+    public class HttpClient : HttpMessageInvoker {
+        public HttpClient();
+        public HttpClient(HttpMessageHandler handler);
+        public HttpClient(HttpMessageHandler handler, bool disposeHandler);
+        public Uri BaseAddress { get; set; }
+        public HttpRequestHeaders DefaultRequestHeaders { get; }
+        public long MaxResponseContentBufferSize { get; set; }
+        public TimeSpan Timeout { get; set; }
+        public void CancelPendingRequests();
+        public Task<HttpResponseMessage> DeleteAsync(string requestUri);
+        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri);
+        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken);
+        protected override void Dispose(bool disposing);
+        public Task<HttpResponseMessage> GetAsync(string requestUri);
+        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption);
+        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> GetAsync(Uri requestUri);
+        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption);
+        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
+        public Task<byte[]> GetByteArrayAsync(string requestUri);
+        public Task<byte[]> GetByteArrayAsync(Uri requestUri);
+        public Task<Stream> GetStreamAsync(string requestUri);
+        public Task<Stream> GetStreamAsync(Uri requestUri);
+        public Task<string> GetStringAsync(string requestUri);
+        public Task<string> GetStringAsync(Uri requestUri);
+        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
+        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
+        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
+        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
+        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
+        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
+        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption);
+        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken);
+    }
+    public class HttpClientHandler : HttpMessageHandler {
+        public HttpClientHandler();
+        public bool AllowAutoRedirect { get; set; }
+        public DecompressionMethods AutomaticDecompression { get; set; }
+        public ClientCertificateOption ClientCertificateOptions { get; set; }
+        public CookieContainer CookieContainer { get; set; }
+        public ICredentials Credentials { get; set; }
+        public int MaxAutomaticRedirections { get; set; }
+        public long MaxRequestContentBufferSize { get; set; }
+        public bool PreAuthenticate { get; set; }
+        public IWebProxy Proxy { get; set; }
+        public virtual bool SupportsAutomaticDecompression { get; }
+        public virtual bool SupportsProxy { get; }
+        public virtual bool SupportsRedirectConfiguration { get; }
+        public bool UseCookies { get; set; }
+        public bool UseDefaultCredentials { get; set; }
+        public bool UseProxy { get; set; }
+        protected override void Dispose(bool disposing);
+        protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
+    }
+    public enum HttpCompletionOption {
+        ResponseContentRead = 0,
+        ResponseHeadersRead = 1,
+    }
+    public abstract class HttpContent : IDisposable {
+        protected HttpContent();
+        public HttpContentHeaders Headers { get; }
+        public Task CopyToAsync(Stream stream);
+        public Task CopyToAsync(Stream stream, TransportContext context);
+        protected virtual Task<Stream> CreateContentReadStreamAsync();
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public Task LoadIntoBufferAsync();
+        public Task LoadIntoBufferAsync(long maxBufferSize);
+        public Task<byte[]> ReadAsByteArrayAsync();
+        public Task<Stream> ReadAsStreamAsync();
+        public Task<string> ReadAsStringAsync();
+        protected abstract Task SerializeToStreamAsync(Stream stream, TransportContext context);
+        protected internal abstract bool TryComputeLength(out long length);
+    }
+    public abstract class HttpMessageHandler : IDisposable {
+        protected HttpMessageHandler();
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
+    }
+    public class HttpMessageInvoker : IDisposable {
+        public HttpMessageInvoker(HttpMessageHandler handler);
+        public HttpMessageInvoker(HttpMessageHandler handler, bool disposeHandler);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
+    }
+    public class HttpMethod : IEquatable<HttpMethod> {
+        public HttpMethod(string method);
+        public static HttpMethod Delete { get; }
+        public static HttpMethod Get { get; }
+        public static HttpMethod Head { get; }
+        public string Method { get; }
+        public static HttpMethod Options { get; }
+        public static HttpMethod Post { get; }
+        public static HttpMethod Put { get; }
+        public static HttpMethod Trace { get; }
+        public bool Equals(HttpMethod other);
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static bool operator ==(HttpMethod left, HttpMethod right);
+        public static bool operator !=(HttpMethod left, HttpMethod right);
+        public override string ToString();
+    }
+    public class HttpRequestException : Exception {
+        public HttpRequestException();
+        public HttpRequestException(string message);
+        public HttpRequestException(string message, Exception inner);
+    }
+    public class HttpRequestMessage : IDisposable {
+        public HttpRequestMessage();
+        public HttpRequestMessage(HttpMethod method, string requestUri);
+        public HttpRequestMessage(HttpMethod method, Uri requestUri);
+        public HttpContent Content { get; set; }
+        public HttpRequestHeaders Headers { get; }
+        public HttpMethod Method { get; set; }
+        public IDictionary<string, object> Properties { get; }
+        public Uri RequestUri { get; set; }
+        public Version Version { get; set; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public override string ToString();
+    }
+    public class HttpResponseMessage : IDisposable {
+        public HttpResponseMessage();
+        public HttpResponseMessage(HttpStatusCode statusCode);
+        public HttpContent Content { get; set; }
+        public HttpResponseHeaders Headers { get; }
+        public bool IsSuccessStatusCode { get; }
+        public string ReasonPhrase { get; set; }
+        public HttpRequestMessage RequestMessage { get; set; }
+        public HttpStatusCode StatusCode { get; set; }
+        public Version Version { get; set; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public HttpResponseMessage EnsureSuccessStatusCode();
+        public override string ToString();
+    }
+    public abstract class MessageProcessingHandler : DelegatingHandler {
+        protected MessageProcessingHandler();
+        protected MessageProcessingHandler(HttpMessageHandler innerHandler);
+        protected abstract HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken);
+        protected abstract HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken);
+        protected internal sealed override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
+    }
+    public class MultipartContent : HttpContent, IEnumerable, IEnumerable<HttpContent> {
+        public MultipartContent();
+        public MultipartContent(string subtype);
+        public MultipartContent(string subtype, string boundary);
+        public virtual void Add(HttpContent content);
+        protected override void Dispose(bool disposing);
+        public IEnumerator<HttpContent> GetEnumerator();
+        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context);
+        protected internal override bool TryComputeLength(out long length);
+    }
+    public class MultipartFormDataContent : MultipartContent {
+        public MultipartFormDataContent();
+        public MultipartFormDataContent(string boundary);
+        public override void Add(HttpContent content);
+        public void Add(HttpContent content, string name);
+        public void Add(HttpContent content, string name, string fileName);
+    }
+    public class StreamContent : HttpContent {
+        public StreamContent(Stream content);
+        public StreamContent(Stream content, int bufferSize);
+        protected override Task<Stream> CreateContentReadStreamAsync();
+        protected override void Dispose(bool disposing);
+        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context);
+        protected internal override bool TryComputeLength(out long length);
+    }
+    public class StringContent : ByteArrayContent {
+        public StringContent(string content);
+        public StringContent(string content, Encoding encoding);
+        public StringContent(string content, Encoding encoding, string mediaType);
+    }
+}
+namespace System.Net.Http.Headers {
+    public class AuthenticationHeaderValue {
+        public AuthenticationHeaderValue(string scheme);
+        public AuthenticationHeaderValue(string scheme, string parameter);
+        public string Parameter { get; }
+        public string Scheme { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static AuthenticationHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out AuthenticationHeaderValue parsedValue);
+    }
+    public class CacheControlHeaderValue {
+        public CacheControlHeaderValue();
+        public ICollection<NameValueHeaderValue> Extensions { get; }
+        public Nullable<TimeSpan> MaxAge { get; set; }
+        public bool MaxStale { get; set; }
+        public Nullable<TimeSpan> MaxStaleLimit { get; set; }
+        public Nullable<TimeSpan> MinFresh { get; set; }
+        public bool MustRevalidate { get; set; }
+        public bool NoCache { get; set; }
+        public ICollection<string> NoCacheHeaders { get; }
+        public bool NoStore { get; set; }
+        public bool NoTransform { get; set; }
+        public bool OnlyIfCached { get; set; }
+        public bool Private { get; set; }
+        public ICollection<string> PrivateHeaders { get; }
+        public bool ProxyRevalidate { get; set; }
+        public bool Public { get; set; }
+        public Nullable<TimeSpan> SharedMaxAge { get; set; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static CacheControlHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out CacheControlHeaderValue parsedValue);
+    }
+    public class ContentDispositionHeaderValue {
+        protected ContentDispositionHeaderValue(ContentDispositionHeaderValue source);
+        public ContentDispositionHeaderValue(string dispositionType);
+        public Nullable<DateTimeOffset> CreationDate { get; set; }
+        public string DispositionType { get; set; }
+        public string FileName { get; set; }
+        public string FileNameStar { get; set; }
+        public Nullable<DateTimeOffset> ModificationDate { get; set; }
+        public string Name { get; set; }
+        public ICollection<NameValueHeaderValue> Parameters { get; }
+        public Nullable<DateTimeOffset> ReadDate { get; set; }
+        public Nullable<long> Size { get; set; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static ContentDispositionHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out ContentDispositionHeaderValue parsedValue);
+    }
+    public class ContentRangeHeaderValue {
+        public ContentRangeHeaderValue(long length);
+        public ContentRangeHeaderValue(long from, long to);
+        public ContentRangeHeaderValue(long from, long to, long length);
+        public Nullable<long> From { get; }
+        public bool HasLength { get; }
+        public bool HasRange { get; }
+        public Nullable<long> Length { get; }
+        public Nullable<long> To { get; }
+        public string Unit { get; set; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static ContentRangeHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out ContentRangeHeaderValue parsedValue);
+    }
+    public class EntityTagHeaderValue {
+        public EntityTagHeaderValue(string tag);
+        public EntityTagHeaderValue(string tag, bool isWeak);
+        public static EntityTagHeaderValue Any { get; }
+        public bool IsWeak { get; }
+        public string Tag { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static EntityTagHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out EntityTagHeaderValue parsedValue);
+    }
+    public sealed class HttpContentHeaders : HttpHeaders {
+        public ICollection<string> Allow { get; }
+        public ContentDispositionHeaderValue ContentDisposition { get; set; }
+        public ICollection<string> ContentEncoding { get; }
+        public ICollection<string> ContentLanguage { get; }
+        public Nullable<long> ContentLength { get; set; }
+        public Uri ContentLocation { get; set; }
+        public byte[] ContentMD5 { get; set; }
+        public ContentRangeHeaderValue ContentRange { get; set; }
+        public MediaTypeHeaderValue ContentType { get; set; }
+        public Nullable<DateTimeOffset> Expires { get; set; }
+        public Nullable<DateTimeOffset> LastModified { get; set; }
+    }
+    public abstract class HttpHeaders : IEnumerable, IEnumerable<KeyValuePair<string, IEnumerable<string>>> {
+        protected HttpHeaders();
+        public void Add(string name, IEnumerable<string> values);
+        public void Add(string name, string value);
+        public void Clear();
+        public bool Contains(string name);
+        public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator();
+        public IEnumerable<string> GetValues(string name);
+        public bool Remove(string name);
+        public override string ToString();
+        public bool TryAddWithoutValidation(string name, IEnumerable<string> values);
+        public bool TryAddWithoutValidation(string name, string value);
+        public bool TryGetValues(string name, out IEnumerable<string> values);
+    }
+    public sealed class HttpHeaderValueCollection<T> : ICollection<T>, IEnumerable, IEnumerable<T> where T : class {
+        public int Count { get; }
+        public bool IsReadOnly { get; }
+        public void Add(T item);
+        public void Clear();
+        public bool Contains(T item);
+        public void CopyTo(T[] array, int arrayIndex);
+        public IEnumerator<T> GetEnumerator();
+        public void ParseAdd(string input);
+        public bool Remove(T item);
+        public override string ToString();
+        public bool TryParseAdd(string input);
+    }
+    public sealed class HttpRequestHeaders : HttpHeaders {
+        public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept { get; }
+        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset { get; }
+        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding { get; }
+        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage { get; }
+        public AuthenticationHeaderValue Authorization { get; set; }
+        public CacheControlHeaderValue CacheControl { get; set; }
+        public HttpHeaderValueCollection<string> Connection { get; }
+        public Nullable<bool> ConnectionClose { get; set; }
+        public Nullable<DateTimeOffset> Date { get; set; }
+        public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect { get; }
+        public Nullable<bool> ExpectContinue { get; set; }
+        public string From { get; set; }
+        public string Host { get; set; }
+        public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch { get; }
+        public Nullable<DateTimeOffset> IfModifiedSince { get; set; }
+        public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch { get; }
+        public RangeConditionHeaderValue IfRange { get; set; }
+        public Nullable<DateTimeOffset> IfUnmodifiedSince { get; set; }
+        public Nullable<int> MaxForwards { get; set; }
+        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get; }
+        public AuthenticationHeaderValue ProxyAuthorization { get; set; }
+        public RangeHeaderValue Range { get; set; }
+        public Uri Referrer { get; set; }
+        public HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE { get; }
+        public HttpHeaderValueCollection<string> Trailer { get; }
+        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get; }
+        public Nullable<bool> TransferEncodingChunked { get; set; }
+        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get; }
+        public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent { get; }
+        public HttpHeaderValueCollection<ViaHeaderValue> Via { get; }
+        public HttpHeaderValueCollection<WarningHeaderValue> Warning { get; }
+    }
+    public sealed class HttpResponseHeaders : HttpHeaders {
+        public HttpHeaderValueCollection<string> AcceptRanges { get; }
+        public Nullable<TimeSpan> Age { get; set; }
+        public CacheControlHeaderValue CacheControl { get; set; }
+        public HttpHeaderValueCollection<string> Connection { get; }
+        public Nullable<bool> ConnectionClose { get; set; }
+        public Nullable<DateTimeOffset> Date { get; set; }
+        public EntityTagHeaderValue ETag { get; set; }
+        public Uri Location { get; set; }
+        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get; }
+        public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate { get; }
+        public RetryConditionHeaderValue RetryAfter { get; set; }
+        public HttpHeaderValueCollection<ProductInfoHeaderValue> Server { get; }
+        public HttpHeaderValueCollection<string> Trailer { get; }
+        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get; }
+        public Nullable<bool> TransferEncodingChunked { get; set; }
+        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get; }
+        public HttpHeaderValueCollection<string> Vary { get; }
+        public HttpHeaderValueCollection<ViaHeaderValue> Via { get; }
+        public HttpHeaderValueCollection<WarningHeaderValue> Warning { get; }
+        public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate { get; }
+    }
+    public class MediaTypeHeaderValue {
+        protected MediaTypeHeaderValue(MediaTypeHeaderValue source);
+        public MediaTypeHeaderValue(string mediaType);
+        public string CharSet { get; set; }
+        public string MediaType { get; set; }
+        public ICollection<NameValueHeaderValue> Parameters { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static MediaTypeHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out MediaTypeHeaderValue parsedValue);
+    }
+    public sealed class MediaTypeWithQualityHeaderValue : MediaTypeHeaderValue {
+        public MediaTypeWithQualityHeaderValue(string mediaType);
+        public MediaTypeWithQualityHeaderValue(string mediaType, double quality);
+        public Nullable<double> Quality { get; set; }
+        public static new MediaTypeWithQualityHeaderValue Parse(string input);
+        public static bool TryParse(string input, out MediaTypeWithQualityHeaderValue parsedValue);
+    }
+    public class NameValueHeaderValue {
+        protected NameValueHeaderValue(NameValueHeaderValue source);
+        public NameValueHeaderValue(string name);
+        public NameValueHeaderValue(string name, string value);
+        public string Name { get; }
+        public string Value { get; set; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static NameValueHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out NameValueHeaderValue parsedValue);
+    }
+    public class NameValueWithParametersHeaderValue : NameValueHeaderValue {
+        protected NameValueWithParametersHeaderValue(NameValueWithParametersHeaderValue source);
+        public NameValueWithParametersHeaderValue(string name);
+        public NameValueWithParametersHeaderValue(string name, string value);
+        public ICollection<NameValueHeaderValue> Parameters { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static new NameValueWithParametersHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out NameValueWithParametersHeaderValue parsedValue);
+    }
+    public class ProductHeaderValue {
+        public ProductHeaderValue(string name);
+        public ProductHeaderValue(string name, string version);
+        public string Name { get; }
+        public string Version { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static ProductHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out ProductHeaderValue parsedValue);
+    }
+    public class ProductInfoHeaderValue {
+        public ProductInfoHeaderValue(ProductHeaderValue product);
+        public ProductInfoHeaderValue(string comment);
+        public ProductInfoHeaderValue(string productName, string productVersion);
+        public string Comment { get; }
+        public ProductHeaderValue Product { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static ProductInfoHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out ProductInfoHeaderValue parsedValue);
+    }
+    public class RangeConditionHeaderValue {
+        public RangeConditionHeaderValue(DateTimeOffset date);
+        public RangeConditionHeaderValue(EntityTagHeaderValue entityTag);
+        public RangeConditionHeaderValue(string entityTag);
+        public Nullable<DateTimeOffset> Date { get; }
+        public EntityTagHeaderValue EntityTag { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static RangeConditionHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out RangeConditionHeaderValue parsedValue);
+    }
+    public class RangeHeaderValue {
+        public RangeHeaderValue();
+        public RangeHeaderValue(Nullable<long> from, Nullable<long> to);
+        public ICollection<RangeItemHeaderValue> Ranges { get; }
+        public string Unit { get; set; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static RangeHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out RangeHeaderValue parsedValue);
+    }
+    public class RangeItemHeaderValue {
+        public RangeItemHeaderValue(Nullable<long> from, Nullable<long> to);
+        public Nullable<long> From { get; }
+        public Nullable<long> To { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public override string ToString();
+    }
+    public class RetryConditionHeaderValue {
+        public RetryConditionHeaderValue(DateTimeOffset date);
+        public RetryConditionHeaderValue(TimeSpan delta);
+        public Nullable<DateTimeOffset> Date { get; }
+        public Nullable<TimeSpan> Delta { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static RetryConditionHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out RetryConditionHeaderValue parsedValue);
+    }
+    public class StringWithQualityHeaderValue {
+        public StringWithQualityHeaderValue(string value);
+        public StringWithQualityHeaderValue(string value, double quality);
+        public Nullable<double> Quality { get; }
+        public string Value { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static StringWithQualityHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out StringWithQualityHeaderValue parsedValue);
+    }
+    public class TransferCodingHeaderValue {
+        public TransferCodingHeaderValue(string value);
+        protected TransferCodingHeaderValue(TransferCodingHeaderValue source);
+        public ICollection<NameValueHeaderValue> Parameters { get; }
+        public string Value { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static TransferCodingHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out TransferCodingHeaderValue parsedValue);
+    }
+    public sealed class TransferCodingWithQualityHeaderValue : TransferCodingHeaderValue {
+        public TransferCodingWithQualityHeaderValue(string value);
+        public TransferCodingWithQualityHeaderValue(string value, double quality);
+        public Nullable<double> Quality { get; set; }
+        public static new TransferCodingWithQualityHeaderValue Parse(string input);
+        public static bool TryParse(string input, out TransferCodingWithQualityHeaderValue parsedValue);
+    }
+    public class ViaHeaderValue {
+        public ViaHeaderValue(string protocolVersion, string receivedBy);
+        public ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName);
+        public ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName, string comment);
+        public string Comment { get; }
+        public string ProtocolName { get; }
+        public string ProtocolVersion { get; }
+        public string ReceivedBy { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static ViaHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out ViaHeaderValue parsedValue);
+    }
+    public class WarningHeaderValue {
+        public WarningHeaderValue(int code, string agent, string text);
+        public WarningHeaderValue(int code, string agent, string text, DateTimeOffset date);
+        public string Agent { get; }
+        public int Code { get; }
+        public Nullable<DateTimeOffset> Date { get; }
+        public string Text { get; }
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static WarningHeaderValue Parse(string input);
+        public override string ToString();
+        public static bool TryParse(string input, out WarningHeaderValue parsedValue);
+    }
+}
+namespace System.Numerics {
+    public struct BigInteger : IComparable, IComparable<BigInteger>, IEquatable<BigInteger>, IFormattable {
+        public BigInteger(byte[] value);
+        public BigInteger(decimal value);
+        public BigInteger(double value);
+        public BigInteger(int value);
+        public BigInteger(long value);
+        public BigInteger(float value);
+        public BigInteger(uint value);
+        public BigInteger(ulong value);
+        public bool IsEven { get; }
+        public bool IsOne { get; }
+        public bool IsPowerOfTwo { get; }
+        public bool IsZero { get; }
+        public static BigInteger MinusOne { get; }
+        public static BigInteger One { get; }
+        public int Sign { get; }
+        public static BigInteger Zero { get; }
+        public static BigInteger Abs(BigInteger value);
+        public static BigInteger Add(BigInteger left, BigInteger right);
+        public static int Compare(BigInteger left, BigInteger right);
+        public int CompareTo(BigInteger other);
+        public int CompareTo(long other);
+        public int CompareTo(ulong other);
+        public static BigInteger Divide(BigInteger dividend, BigInteger divisor);
+        public static BigInteger DivRem(BigInteger dividend, BigInteger divisor, out BigInteger remainder);
+        public bool Equals(BigInteger other);
+        public bool Equals(long other);
+        public override bool Equals(object obj);
+        public bool Equals(ulong other);
+        public override int GetHashCode();
+        public static BigInteger GreatestCommonDivisor(BigInteger left, BigInteger right);
+        public static double Log(BigInteger value);
+        public static double Log(BigInteger value, double baseValue);
+        public static double Log10(BigInteger value);
+        public static BigInteger Max(BigInteger left, BigInteger right);
+        public static BigInteger Min(BigInteger left, BigInteger right);
+        public static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus);
+        public static BigInteger Multiply(BigInteger left, BigInteger right);
+        public static BigInteger Negate(BigInteger value);
+        public static BigInteger operator +(BigInteger left, BigInteger right);
+        public static BigInteger operator &(BigInteger left, BigInteger right);
+        public static BigInteger operator |(BigInteger left, BigInteger right);
+        public static BigInteger operator --(BigInteger value);
+        public static BigInteger operator /(BigInteger dividend, BigInteger divisor);
+        public static bool operator ==(BigInteger left, BigInteger right);
+        public static bool operator ==(BigInteger left, long right);
+        public static bool operator ==(BigInteger left, ulong right);
+        public static bool operator ==(long left, BigInteger right);
+        public static bool operator ==(ulong left, BigInteger right);
+        public static BigInteger operator ^(BigInteger left, BigInteger right);
+        public static explicit operator byte (BigInteger value);
+        public static explicit operator decimal (BigInteger value);
+        public static explicit operator double (BigInteger value);
+        public static explicit operator short (BigInteger value);
+        public static explicit operator int (BigInteger value);
+        public static explicit operator long (BigInteger value);
+        public static explicit operator sbyte (BigInteger value);
+        public static explicit operator float (BigInteger value);
+        public static explicit operator ushort (BigInteger value);
+        public static explicit operator uint (BigInteger value);
+        public static explicit operator ulong (BigInteger value);
+        public static explicit operator BigInteger (decimal value);
+        public static explicit operator BigInteger (double value);
+        public static explicit operator BigInteger (float value);
+        public static bool operator >(BigInteger left, BigInteger right);
+        public static bool operator >(BigInteger left, long right);
+        public static bool operator >(BigInteger left, ulong right);
+        public static bool operator >(long left, BigInteger right);
+        public static bool operator >(ulong left, BigInteger right);
+        public static bool operator >=(BigInteger left, BigInteger right);
+        public static bool operator >=(BigInteger left, long right);
+        public static bool operator >=(BigInteger left, ulong right);
+        public static bool operator >=(long left, BigInteger right);
+        public static bool operator >=(ulong left, BigInteger right);
+        public static implicit operator BigInteger (byte value);
+        public static implicit operator BigInteger (short value);
+        public static implicit operator BigInteger (int value);
+        public static implicit operator BigInteger (long value);
+        public static implicit operator BigInteger (sbyte value);
+        public static implicit operator BigInteger (ushort value);
+        public static implicit operator BigInteger (uint value);
+        public static implicit operator BigInteger (ulong value);
+        public static BigInteger operator ++(BigInteger value);
+        public static bool operator !=(BigInteger left, BigInteger right);
+        public static bool operator !=(BigInteger left, long right);
+        public static bool operator !=(BigInteger left, ulong right);
+        public static bool operator !=(long left, BigInteger right);
+        public static bool operator !=(ulong left, BigInteger right);
+        public static BigInteger operator <<(BigInteger value, int shift);
+        public static bool operator <(BigInteger left, BigInteger right);
+        public static bool operator <(BigInteger left, long right);
+        public static bool operator <(BigInteger left, ulong right);
+        public static bool operator <(long left, BigInteger right);
+        public static bool operator <(ulong left, BigInteger right);
+        public static bool operator <=(BigInteger left, BigInteger right);
+        public static bool operator <=(BigInteger left, long right);
+        public static bool operator <=(BigInteger left, ulong right);
+        public static bool operator <=(long left, BigInteger right);
+        public static bool operator <=(ulong left, BigInteger right);
+        public static BigInteger operator %(BigInteger dividend, BigInteger divisor);
+        public static BigInteger operator *(BigInteger left, BigInteger right);
+        public static BigInteger operator ~(BigInteger value);
+        public static BigInteger operator >>(BigInteger value, int shift);
+        public static BigInteger operator -(BigInteger left, BigInteger right);
+        public static BigInteger operator -(BigInteger value);
+        public static BigInteger operator +(BigInteger value);
+        public static BigInteger Parse(string value);
+        public static BigInteger Parse(string value, IFormatProvider provider);
+        public static BigInteger Parse(string value, NumberStyles style);
+        public static BigInteger Parse(string value, NumberStyles style, IFormatProvider provider);
+        public static BigInteger Pow(BigInteger value, int exponent);
+        public static BigInteger Remainder(BigInteger dividend, BigInteger divisor);
+        public static BigInteger Subtract(BigInteger left, BigInteger right);
+        public byte[] ToByteArray();
+        public override string ToString();
+        public string ToString(IFormatProvider provider);
+        public string ToString(string format);
+        public string ToString(string format, IFormatProvider provider);
+        public static bool TryParse(string value, out BigInteger result);
+        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out BigInteger result);
+    }
+    public struct Complex : IEquatable<Complex>, IFormattable {
+        public static readonly Complex ImaginaryOne;
+        public static readonly Complex One;
+        public static readonly Complex Zero;
+        public Complex(double real, double imaginary);
+        public double Imaginary { get; }
+        public double Magnitude { get; }
+        public double Phase { get; }
+        public double Real { get; }
+        public static double Abs(Complex value);
+        public static Complex Acos(Complex value);
+        public static Complex Add(Complex left, Complex right);
+        public static Complex Asin(Complex value);
+        public static Complex Atan(Complex value);
+        public static Complex Conjugate(Complex value);
+        public static Complex Cos(Complex value);
+        public static Complex Cosh(Complex value);
+        public static Complex Divide(Complex dividend, Complex divisor);
+        public bool Equals(Complex value);
+        public override bool Equals(object obj);
+        public static Complex Exp(Complex value);
+        public static Complex FromPolarCoordinates(double magnitude, double phase);
+        public override int GetHashCode();
+        public static Complex Log(Complex value);
+        public static Complex Log(Complex value, double baseValue);
+        public static Complex Log10(Complex value);
+        public static Complex Multiply(Complex left, Complex right);
+        public static Complex Negate(Complex value);
+        public static Complex operator +(Complex left, Complex right);
+        public static Complex operator /(Complex left, Complex right);
+        public static bool operator ==(Complex left, Complex right);
+        public static explicit operator Complex (BigInteger value);
+        public static explicit operator Complex (decimal value);
+        public static implicit operator Complex (byte value);
+        public static implicit operator Complex (double value);
+        public static implicit operator Complex (short value);
+        public static implicit operator Complex (int value);
+        public static implicit operator Complex (long value);
+        public static implicit operator Complex (sbyte value);
+        public static implicit operator Complex (float value);
+        public static implicit operator Complex (ushort value);
+        public static implicit operator Complex (uint value);
+        public static implicit operator Complex (ulong value);
+        public static bool operator !=(Complex left, Complex right);
+        public static Complex operator *(Complex left, Complex right);
+        public static Complex operator -(Complex left, Complex right);
+        public static Complex operator -(Complex value);
+        public static Complex Pow(Complex value, Complex power);
+        public static Complex Pow(Complex value, double power);
+        public static Complex Reciprocal(Complex value);
+        public static Complex Sin(Complex value);
+        public static Complex Sinh(Complex value);
+        public static Complex Sqrt(Complex value);
+        public static Complex Subtract(Complex left, Complex right);
+        public static Complex Tan(Complex value);
+        public static Complex Tanh(Complex value);
+        public override string ToString();
+        public string ToString(IFormatProvider provider);
+        public string ToString(string format);
+        public string ToString(string format, IFormatProvider provider);
+    }
+}
 namespace System.Reflection {
+    public sealed class Missing {
+        public static readonly Missing Value;
+    }
 }
 namespace System.Runtime.InteropServices {
+    public enum Architecture {
+        Arm = 2,
+        Arm64 = 3,
+        X64 = 1,
+        X86 = 0,
+    }
+    public struct ArrayWithOffset {
+        public ArrayWithOffset(object array, int offset);
+        public bool Equals(ArrayWithOffset obj);
+        public override bool Equals(object obj);
+        public object GetArray();
+        public override int GetHashCode();
+        public int GetOffset();
+        public static bool operator ==(ArrayWithOffset a, ArrayWithOffset b);
+        public static bool operator !=(ArrayWithOffset a, ArrayWithOffset b);
+    }
+    public sealed class BestFitMappingAttribute : Attribute {
+        public bool ThrowOnUnmappableChar;
+        public BestFitMappingAttribute(bool BestFitMapping);
+        public bool BestFitMapping { get; }
+    }
+    public sealed class BStrWrapper {
+        public BStrWrapper(object value);
+        public BStrWrapper(string value);
+        public string WrappedObject { get; }
+    }
+    public enum CallingConvention {
+        Cdecl = 2,
+        StdCall = 3,
+        ThisCall = 4,
+        Winapi = 1,
+    }
+    public sealed class ClassInterfaceAttribute : Attribute {
+        public ClassInterfaceAttribute(ClassInterfaceType classInterfaceType);
+        public ClassInterfaceAttribute(short classInterfaceType);
+        public ClassInterfaceType Value { get; }
+    }
+    public enum ClassInterfaceType {
+        AutoDispatch = 1,
+        AutoDual = 2,
+        None = 0,
+    }
+    public sealed class CoClassAttribute : Attribute {
+        public CoClassAttribute(Type coClass);
+        public Type CoClass { get; }
+    }
+    public class ComAwareEventInfo : EventInfo {
+        public ComAwareEventInfo(Type type, string eventName);
+        public override EventAttributes Attributes { get; }
+        public override Type DeclaringType { get; }
+        public override string Name { get; }
+        public override void AddEventHandler(object target, Delegate handler);
+        public override void RemoveEventHandler(object target, Delegate handler);
+    }
+    public sealed class ComDefaultInterfaceAttribute : Attribute {
+        public ComDefaultInterfaceAttribute(Type defaultInterface);
+        public Type Value { get; }
+    }
+    public sealed class ComEventInterfaceAttribute : Attribute {
+        public ComEventInterfaceAttribute(Type SourceInterface, Type EventProvider);
+        public Type EventProvider { get; }
+        public Type SourceInterface { get; }
+    }
+    public static class ComEventsHelper {
+        public static void Combine(object rcw, Guid iid, int dispid, Delegate d);
+        public static Delegate Remove(object rcw, Guid iid, int dispid, Delegate d);
+    }
+    public class COMException : Exception {
+        public COMException();
+        public COMException(string message);
+        public COMException(string message, Exception inner);
+        public COMException(string message, int errorCode);
+    }
+    public sealed class ComImportAttribute : Attribute {
+        public ComImportAttribute();
+    }
+    public enum ComInterfaceType {
+        InterfaceIsDual = 0,
+        InterfaceIsIDispatch = 2,
+        InterfaceIsIInspectable = 3,
+        InterfaceIsIUnknown = 1,
+    }
+    public enum ComMemberType {
+        Method = 0,
+        PropGet = 1,
+        PropSet = 2,
+    }
+    public sealed class ComSourceInterfacesAttribute : Attribute {
+        public ComSourceInterfacesAttribute(string sourceInterfaces);
+        public ComSourceInterfacesAttribute(Type sourceInterface);
+        public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2);
+        public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2, Type sourceInterface3);
+        public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2, Type sourceInterface3, Type sourceInterface4);
+        public string Value { get; }
+    }
+    public abstract class CriticalHandle : IDisposable {
+        protected IntPtr handle;
+        protected CriticalHandle(IntPtr invalidHandleValue);
+        public bool IsClosed { get; }
+        public abstract bool IsInvalid { get; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        ~CriticalHandle();
+        protected abstract bool ReleaseHandle();
+        protected void SetHandle(IntPtr handle);
+        public void SetHandleAsInvalid();
+    }
+    public sealed class CurrencyWrapper {
+        public CurrencyWrapper(decimal obj);
+        public CurrencyWrapper(object obj);
+        public decimal WrappedObject { get; }
+    }
+    public enum CustomQueryInterfaceMode {
+        Allow = 1,
+        Ignore = 0,
+    }
+    public enum CustomQueryInterfaceResult {
+        Failed = 2,
+        Handled = 0,
+        NotHandled = 1,
+    }
+    public sealed class DefaultCharSetAttribute : Attribute {
+        public DefaultCharSetAttribute(CharSet charSet);
+        public CharSet CharSet { get; }
+    }
+    public sealed class DefaultDllImportSearchPathsAttribute : Attribute {
+        public DefaultDllImportSearchPathsAttribute(DllImportSearchPath paths);
+        public DllImportSearchPath Paths { get; }
+    }
+    public sealed class DefaultParameterValueAttribute : Attribute {
+        public DefaultParameterValueAttribute(object value);
+        public object Value { get; }
+    }
+    public sealed class DispatchWrapper {
+        public DispatchWrapper(object obj);
+        public object WrappedObject { get; }
+    }
+    public sealed class DispIdAttribute : Attribute {
+        public DispIdAttribute(int dispId);
+        public int Value { get; }
+    }
+    public sealed class DllImportAttribute : Attribute {
+        public bool BestFitMapping;
+        public CallingConvention CallingConvention;
+        public CharSet CharSet;
+        public string EntryPoint;
+        public bool ExactSpelling;
+        public bool PreserveSig;
+        public bool SetLastError;
+        public bool ThrowOnUnmappableChar;
+        public DllImportAttribute(string dllName);
+        public string Value { get; }
+    }
+    public enum DllImportSearchPath {
+        ApplicationDirectory = 512,
+        AssemblyDirectory = 2,
+        LegacyBehavior = 0,
+        SafeDirectories = 4096,
+        System32 = 2048,
+        UseDllDirectoryForDependencies = 256,
+        UserDirectories = 1024,
+    }
+    public sealed class ErrorWrapper {
+        public ErrorWrapper(Exception e);
+        public ErrorWrapper(int errorCode);
+        public ErrorWrapper(object errorCode);
+        public int ErrorCode { get; }
+    }
+    public struct GCHandle {
+        public bool IsAllocated { get; }
+        public object Target { get; set; }
+        public IntPtr AddrOfPinnedObject();
+        public static GCHandle Alloc(object value);
+        public static GCHandle Alloc(object value, GCHandleType type);
+        public override bool Equals(object o);
+        public void Free();
+        public static GCHandle FromIntPtr(IntPtr value);
+        public override int GetHashCode();
+        public static bool operator ==(GCHandle a, GCHandle b);
+        public static explicit operator IntPtr (GCHandle value);
+        public static explicit operator GCHandle (IntPtr value);
+        public static bool operator !=(GCHandle a, GCHandle b);
+        public static IntPtr ToIntPtr(GCHandle value);
+    }
+    public enum GCHandleType {
+        Normal = 2,
+        Pinned = 3,
+        Weak = 0,
+        WeakTrackResurrection = 1,
+    }
+    public sealed class GuidAttribute : Attribute {
+        public GuidAttribute(string guid);
+        public string Value { get; }
+    }
+    public sealed class HandleCollector {
+        public HandleCollector(string name, int initialThreshold);
+        public HandleCollector(string name, int initialThreshold, int maximumThreshold);
+        public int Count { get; }
+        public int InitialThreshold { get; }
+        public int MaximumThreshold { get; }
+        public string Name { get; }
+        public void Add();
+        public void Remove();
+    }
+    public interface ICustomAdapter {
+        object GetUnderlyingObject();
+    }
+    public interface ICustomQueryInterface {
+        CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv);
+    }
+    public sealed class InAttribute : Attribute {
+        public InAttribute();
+    }
+    public sealed class InterfaceTypeAttribute : Attribute {
+        public InterfaceTypeAttribute(ComInterfaceType interfaceType);
+        public InterfaceTypeAttribute(short interfaceType);
+        public ComInterfaceType Value { get; }
+    }
+    public class InvalidComObjectException : Exception {
+        public InvalidComObjectException();
+        public InvalidComObjectException(string message);
+        public InvalidComObjectException(string message, Exception inner);
+    }
+    public class InvalidOleVariantTypeException : Exception {
+        public InvalidOleVariantTypeException();
+        public InvalidOleVariantTypeException(string message);
+        public InvalidOleVariantTypeException(string message, Exception inner);
+    }
+    public static class Marshal {
+        public static readonly int SystemDefaultCharSize;
+        public static readonly int SystemMaxDBCSCharSize;
+        public static int AddRef(IntPtr pUnk);
+        public static IntPtr AllocCoTaskMem(int cb);
+        public static IntPtr AllocHGlobal(int cb);
+        public static IntPtr AllocHGlobal(IntPtr cb);
+        public static bool AreComObjectsAvailableForCleanup();
+        public static void Copy(byte[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(char[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(double[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(short[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(int[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(long[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(IntPtr source, byte[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, char[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, double[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, short[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, int[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, long[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, IntPtr[] destination, int startIndex, int length);
+        public static void Copy(IntPtr source, float[] destination, int startIndex, int length);
+        public static void Copy(IntPtr[] source, int startIndex, IntPtr destination, int length);
+        public static void Copy(float[] source, int startIndex, IntPtr destination, int length);
+        public static IntPtr CreateAggregatedObject(IntPtr pOuter, object o);
+        public static object CreateWrapperOfType(object o, Type t);
+        public static void DestroyStructure(IntPtr ptr, Type structuretype);
+        public static int FinalReleaseComObject(object o);
+        public static void FreeBSTR(IntPtr ptr);
+        public static void FreeCoTaskMem(IntPtr ptr);
+        public static void FreeHGlobal(IntPtr hglobal);
+        public static IntPtr GetComInterfaceForObject(object o, Type T);
+        public static IntPtr GetComInterfaceForObject(object o, Type T, CustomQueryInterfaceMode mode);
+        public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t);
+        public static int GetExceptionCode();
+        public static Exception GetExceptionForHR(int errorCode);
+        public static Exception GetExceptionForHR(int errorCode, IntPtr errorInfo);
+        public static IntPtr GetFunctionPointerForDelegate(Delegate d);
+        public static int GetHRForException(Exception e);
+        public static int GetHRForLastWin32Error();
+        public static IntPtr GetIUnknownForObject(object o);
+        public static int GetLastWin32Error();
+        public static void GetNativeVariantForObject(object obj, IntPtr pDstNativeVariant);
+        public static object GetObjectForIUnknown(IntPtr pUnk);
+        public static object GetObjectForNativeVariant(IntPtr pSrcNativeVariant);
+        public static object[] GetObjectsForNativeVariants(IntPtr aSrcNativeVariant, int cVars);
+        public static int GetStartComSlot(Type t);
+        public static Type GetTypeFromCLSID(Guid clsid);
+        public static string GetTypeInfoName(ITypeInfo typeInfo);
+        public static object GetUniqueObjectForIUnknown(IntPtr unknown);
+        public static bool IsComObject(object o);
+        public static IntPtr OffsetOf(Type t, string fieldName);
+        public static string PtrToStringAnsi(IntPtr ptr);
+        public static string PtrToStringAnsi(IntPtr ptr, int len);
+        public static string PtrToStringBSTR(IntPtr ptr);
+        public static string PtrToStringUni(IntPtr ptr);
+        public static string PtrToStringUni(IntPtr ptr, int len);
+        public static void PtrToStructure(IntPtr ptr, object structure);
+        public static object PtrToStructure(IntPtr ptr, Type structureType);
+        public static int QueryInterface(IntPtr pUnk, ref Guid iid, out IntPtr ppv);
+        public static byte ReadByte(IntPtr ptr);
+        public static byte ReadByte(IntPtr ptr, int ofs);
+        public static byte ReadByte(object ptr, int ofs);
+        public static short ReadInt16(IntPtr ptr);
+        public static short ReadInt16(IntPtr ptr, int ofs);
+        public static short ReadInt16(object ptr, int ofs);
+        public static int ReadInt32(IntPtr ptr);
+        public static int ReadInt32(IntPtr ptr, int ofs);
+        public static int ReadInt32(object ptr, int ofs);
+        public static long ReadInt64(IntPtr ptr);
+        public static long ReadInt64(IntPtr ptr, int ofs);
+        public static long ReadInt64(object ptr, int ofs);
+        public static IntPtr ReadIntPtr(IntPtr ptr);
+        public static IntPtr ReadIntPtr(IntPtr ptr, int ofs);
+        public static IntPtr ReadIntPtr(object ptr, int ofs);
+        public static IntPtr ReAllocCoTaskMem(IntPtr pv, int cb);
+        public static IntPtr ReAllocHGlobal(IntPtr pv, IntPtr cb);
+        public static int Release(IntPtr pUnk);
+        public static int ReleaseComObject(object o);
+        public static int SizeOf(object structure);
+        public static int SizeOf(Type t);
+        public static IntPtr StringToBSTR(string s);
+        public static IntPtr StringToCoTaskMemAnsi(string s);
+        public static IntPtr StringToCoTaskMemUni(string s);
+        public static IntPtr StringToHGlobalAnsi(string s);
+        public static IntPtr StringToHGlobalUni(string s);
+        public static void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld);
+        public static void ThrowExceptionForHR(int errorCode);
+        public static void ThrowExceptionForHR(int errorCode, IntPtr errorInfo);
+        public static IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index);
+        public static void WriteByte(IntPtr ptr, byte val);
+        public static void WriteByte(IntPtr ptr, int ofs, byte val);
+        public static void WriteByte(object ptr, int ofs, byte val);
+        public static void WriteInt16(IntPtr ptr, char val);
+        public static void WriteInt16(IntPtr ptr, short val);
+        public static void WriteInt16(IntPtr ptr, int ofs, char val);
+        public static void WriteInt16(IntPtr ptr, int ofs, short val);
+        public static void WriteInt16(object ptr, int ofs, char val);
+        public static void WriteInt16(object ptr, int ofs, short val);
+        public static void WriteInt32(IntPtr ptr, int val);
+        public static void WriteInt32(IntPtr ptr, int ofs, int val);
+        public static void WriteInt32(object ptr, int ofs, int val);
+        public static void WriteInt64(IntPtr ptr, int ofs, long val);
+        public static void WriteInt64(IntPtr ptr, long val);
+        public static void WriteInt64(object ptr, int ofs, long val);
+        public static void WriteIntPtr(IntPtr ptr, int ofs, IntPtr val);
+        public static void WriteIntPtr(IntPtr ptr, IntPtr val);
+        public static void WriteIntPtr(object ptr, int ofs, IntPtr val);
+        public static void ZeroFreeBSTR(IntPtr s);
+        public static void ZeroFreeCoTaskMemAnsi(IntPtr s);
+        public static void ZeroFreeCoTaskMemUnicode(IntPtr s);
+        public static void ZeroFreeGlobalAllocAnsi(IntPtr s);
+        public static void ZeroFreeGlobalAllocUnicode(IntPtr s);
+    }
+    public sealed class MarshalAsAttribute : Attribute {
+        public UnmanagedType ArraySubType;
+        public int IidParameterIndex;
+        public string MarshalCookie;
+        public string MarshalType;
+        public Type MarshalTypeRef;
+        public VarEnum SafeArraySubType;
+        public Type SafeArrayUserDefinedSubType;
+        public int SizeConst;
+        public short SizeParamIndex;
+        public MarshalAsAttribute(short unmanagedType);
+        public MarshalAsAttribute(UnmanagedType unmanagedType);
+        public UnmanagedType Value { get; }
+    }
+    public class MarshalDirectiveException : Exception {
+        public MarshalDirectiveException();
+        public MarshalDirectiveException(string message);
+        public MarshalDirectiveException(string message, Exception inner);
+    }
+    public sealed class OptionalAttribute : Attribute {
+        public OptionalAttribute();
+    }
+    public struct OSPlatform : IEquatable<OSPlatform> {
+        public static OSPlatform Linux { get; }
+        public static OSPlatform OSX { get; }
+        public static OSPlatform Windows { get; }
+        public static OSPlatform Create(string osPlatform);
+        public override bool Equals(object obj);
+        public bool Equals(OSPlatform other);
+        public override int GetHashCode();
+        public static bool operator ==(OSPlatform left, OSPlatform right);
+        public static bool operator !=(OSPlatform left, OSPlatform right);
+        public override string ToString();
+    }
+    public sealed class PreserveSigAttribute : Attribute {
+        public PreserveSigAttribute();
+    }
+    public static class RuntimeInformation {
+        public static string FrameworkDescription { get; }
+        public static Architecture OSArchitecture { get; }
+        public static string OSDescription { get; }
+        public static Architecture ProcessArchitecture { get; }
+        public static bool IsOSPlatform(OSPlatform osPlatform);
+    }
+    public class SafeArrayRankMismatchException : Exception {
+        public SafeArrayRankMismatchException();
+        public SafeArrayRankMismatchException(string message);
+        public SafeArrayRankMismatchException(string message, Exception inner);
+    }
+    public class SafeArrayTypeMismatchException : Exception {
+        public SafeArrayTypeMismatchException();
+        public SafeArrayTypeMismatchException(string message);
+        public SafeArrayTypeMismatchException(string message, Exception inner);
+    }
+    public abstract class SafeBuffer : SafeHandle {
+        protected SafeBuffer(bool ownsHandle);
+        public ulong ByteLength { get; }
+        public override bool IsInvalid { get; }
+        public unsafe void AcquirePointer(ref byte* pointer);
+        public void Initialize<T>(uint numElements) where T : struct;
+        public void Initialize(uint numElements, uint sizeOfEachElement);
+        public void Initialize(ulong numBytes);
+        public T Read<T>(ulong byteOffset) where T : struct;
+        public void ReadArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct;
+        public void ReleasePointer();
+        public void Write<T>(ulong byteOffset, T value) where T : struct;
+        public void WriteArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct;
+    }
+    public abstract class SafeHandle : IDisposable {
+        protected IntPtr handle;
+        protected SafeHandle(IntPtr invalidHandleValue, bool ownsHandle);
+        public bool IsClosed { get; }
+        public abstract bool IsInvalid { get; }
+        public void DangerousAddRef(ref bool success);
+        public IntPtr DangerousGetHandle();
+        public void DangerousRelease();
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        ~SafeHandle();
+        protected abstract bool ReleaseHandle();
+        protected void SetHandle(IntPtr handle);
+        public void SetHandleAsInvalid();
+    }
+    public class SEHException : Exception {
+        public SEHException();
+        public SEHException(string message);
+        public SEHException(string message, Exception inner);
+        public virtual bool CanResume();
+    }
+    public sealed class TypeIdentifierAttribute : Attribute {
+        public TypeIdentifierAttribute();
+        public TypeIdentifierAttribute(string scope, string identifier);
+        public string Identifier { get; }
+        public string Scope { get; }
+    }
+    public sealed class UnknownWrapper {
+        public UnknownWrapper(object obj);
+        public object WrappedObject { get; }
+    }
+    public sealed class UnmanagedFunctionPointerAttribute : Attribute {
+        public bool BestFitMapping;
+        public CharSet CharSet;
+        public bool SetLastError;
+        public bool ThrowOnUnmappableChar;
+        public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention);
+        public CallingConvention CallingConvention { get; }
+    }
+    public enum UnmanagedType {
+        AnsiBStr = 35,
+        AsAny = 40,
+        Bool = 2,
+        BStr = 19,
+        ByValArray = 30,
+        ByValTStr = 23,
+        Currency = 15,
+        Error = 45,
+        FunctionPtr = 38,
+        HString = 47,
+        I1 = 3,
+        I2 = 5,
+        I4 = 7,
+        I8 = 9,
+        IDispatch = 26,
+        IInspectable = 46,
+        Interface = 28,
+        IUnknown = 25,
+        LPArray = 42,
+        LPStr = 20,
+        LPStruct = 43,
+        LPTStr = 22,
+        LPWStr = 21,
+        R4 = 11,
+        R8 = 12,
+        SafeArray = 29,
+        Struct = 27,
+        SysInt = 31,
+        SysUInt = 32,
+        TBStr = 36,
+        U1 = 4,
+        U2 = 6,
+        U4 = 8,
+        U8 = 10,
+        VariantBool = 37,
+        VBByRefStr = 34,
+    }
+    public enum VarEnum {
+        VT_ARRAY = 8192,
+        VT_BLOB = 65,
+        VT_BLOB_OBJECT = 70,
+        VT_BOOL = 11,
+        VT_BSTR = 8,
+        VT_BYREF = 16384,
+        VT_CARRAY = 28,
+        VT_CF = 71,
+        VT_CLSID = 72,
+        VT_CY = 6,
+        VT_DATE = 7,
+        VT_DECIMAL = 14,
+        VT_DISPATCH = 9,
+        VT_EMPTY = 0,
+        VT_ERROR = 10,
+        VT_FILETIME = 64,
+        VT_HRESULT = 25,
+        VT_I1 = 16,
+        VT_I2 = 2,
+        VT_I4 = 3,
+        VT_I8 = 20,
+        VT_INT = 22,
+        VT_LPSTR = 30,
+        VT_LPWSTR = 31,
+        VT_NULL = 1,
+        VT_PTR = 26,
+        VT_R4 = 4,
+        VT_R8 = 5,
+        VT_RECORD = 36,
+        VT_SAFEARRAY = 27,
+        VT_STORAGE = 67,
+        VT_STORED_OBJECT = 69,
+        VT_STREAM = 66,
+        VT_STREAMED_OBJECT = 68,
+        VT_UI1 = 17,
+        VT_UI2 = 18,
+        VT_UI4 = 19,
+        VT_UI8 = 21,
+        VT_UINT = 23,
+        VT_UNKNOWN = 13,
+        VT_USERDEFINED = 29,
+        VT_VARIANT = 12,
+        VT_VECTOR = 4096,
+        VT_VOID = 24,
+    }
+    public sealed class VariantWrapper {
+        public VariantWrapper(object obj);
+        public object WrappedObject { get; }
+    }
 }
+namespace System.Runtime.InteropServices.ComTypes {
+    public enum ADVF {
+        ADVFCACHE_FORCEBUILTIN = 16,
+        ADVFCACHE_NOHANDLER = 8,
+        ADVFCACHE_ONSAVE = 32,
+        ADVF_DATAONSTOP = 64,
+        ADVF_NODATA = 1,
+        ADVF_ONLYONCE = 4,
+        ADVF_PRIMEFIRST = 2,
+    }
+    public struct BINDPTR {
+        public IntPtr lpfuncdesc;
+        public IntPtr lptcomp;
+        public IntPtr lpvardesc;
+    }
+    public struct BIND_OPTS {
+        public int cbStruct;
+        public int dwTickCountDeadline;
+        public int grfFlags;
+        public int grfMode;
+    }
+    public enum CALLCONV {
+        CC_CDECL = 1,
+        CC_MACPASCAL = 3,
+        CC_MAX = 9,
+        CC_MPWCDECL = 7,
+        CC_MPWPASCAL = 8,
+        CC_MSCPASCAL = 2,
+        CC_PASCAL = 2,
+        CC_RESERVED = 5,
+        CC_STDCALL = 4,
+        CC_SYSCALL = 6,
+    }
+    public struct CONNECTDATA {
+        public int dwCookie;
+        public object pUnk;
+    }
+    public enum DATADIR {
+        DATADIR_GET = 1,
+        DATADIR_SET = 2,
+    }
+    public enum DESCKIND {
+        DESCKIND_FUNCDESC = 1,
+        DESCKIND_IMPLICITAPPOBJ = 4,
+        DESCKIND_MAX = 5,
+        DESCKIND_NONE = 0,
+        DESCKIND_TYPECOMP = 3,
+        DESCKIND_VARDESC = 2,
+    }
+    public struct DISPPARAMS {
+        public int cArgs;
+        public int cNamedArgs;
+        public IntPtr rgdispidNamedArgs;
+        public IntPtr rgvarg;
+    }
+    public enum DVASPECT {
+        DVASPECT_CONTENT = 1,
+        DVASPECT_DOCPRINT = 8,
+        DVASPECT_ICON = 4,
+        DVASPECT_THUMBNAIL = 2,
+    }
+    public struct ELEMDESC {
+        public struct DESCUNION {
+            public IDLDESC idldesc;
+            public PARAMDESC paramdesc;
+        }
+        public ELEMDESC.DESCUNION desc;
+        public TYPEDESC tdesc;
+    }
+    public struct EXCEPINFO {
+        public string bstrDescription;
+        public string bstrHelpFile;
+        public string bstrSource;
+        public int dwHelpContext;
+        public IntPtr pfnDeferredFillIn;
+        public IntPtr pvReserved;
+        public int scode;
+        public short wCode;
+        public short wReserved;
+    }
+    public struct FILETIME {
+        public int dwHighDateTime;
+        public int dwLowDateTime;
+    }
+    public struct FORMATETC {
+        public short cfFormat;
+        public DVASPECT dwAspect;
+        public int lindex;
+        public IntPtr ptd;
+        public TYMED tymed;
+    }
+    public struct FUNCDESC {
+        public CALLCONV callconv;
+        public short cParams;
+        public short cParamsOpt;
+        public short cScodes;
+        public ELEMDESC elemdescFunc;
+        public FUNCKIND funckind;
+        public INVOKEKIND invkind;
+        public IntPtr lprgelemdescParam;
+        public IntPtr lprgscode;
+        public int memid;
+        public short oVft;
+        public short wFuncFlags;
+    }
+    public enum FUNCFLAGS : short {
+        FUNCFLAG_FBINDABLE = (short)4,
+        FUNCFLAG_FDEFAULTBIND = (short)32,
+        FUNCFLAG_FDEFAULTCOLLELEM = (short)256,
+        FUNCFLAG_FDISPLAYBIND = (short)16,
+        FUNCFLAG_FHIDDEN = (short)64,
+        FUNCFLAG_FIMMEDIATEBIND = (short)4096,
+        FUNCFLAG_FNONBROWSABLE = (short)1024,
+        FUNCFLAG_FREPLACEABLE = (short)2048,
+        FUNCFLAG_FREQUESTEDIT = (short)8,
+        FUNCFLAG_FRESTRICTED = (short)1,
+        FUNCFLAG_FSOURCE = (short)2,
+        FUNCFLAG_FUIDEFAULT = (short)512,
+        FUNCFLAG_FUSESGETLASTERROR = (short)128,
+    }
+    public enum FUNCKIND {
+        FUNC_DISPATCH = 4,
+        FUNC_NONVIRTUAL = 2,
+        FUNC_PUREVIRTUAL = 1,
+        FUNC_STATIC = 3,
+        FUNC_VIRTUAL = 0,
+    }
+    public interface IAdviseSink {
+        void OnClose();
+        void OnDataChange(ref FORMATETC format, ref STGMEDIUM stgmedium);
+        void OnRename(IMoniker moniker);
+        void OnSave();
+        void OnViewChange(int aspect, int index);
+    }
+    public interface IBindCtx {
+        void EnumObjectParam(out IEnumString ppenum);
+        void GetBindOptions(ref BIND_OPTS pbindopts);
+        void GetObjectParam(string pszKey, out object ppunk);
+        void GetRunningObjectTable(out IRunningObjectTable pprot);
+        void RegisterObjectBound(object punk);
+        void RegisterObjectParam(string pszKey, object punk);
+        void ReleaseBoundObjects();
+        void RevokeObjectBound(object punk);
+        int RevokeObjectParam(string pszKey);
+        void SetBindOptions(ref BIND_OPTS pbindopts);
+    }
+    public interface IConnectionPoint {
+        void Advise(object pUnkSink, out int pdwCookie);
+        void EnumConnections(out IEnumConnections ppEnum);
+        void GetConnectionInterface(out Guid pIID);
+        void GetConnectionPointContainer(out IConnectionPointContainer ppCPC);
+        void Unadvise(int dwCookie);
+    }
+    public interface IConnectionPointContainer {
+        void EnumConnectionPoints(out IEnumConnectionPoints ppEnum);
+        void FindConnectionPoint(ref Guid riid, out IConnectionPoint ppCP);
+    }
+    public struct IDLDESC {
+        public IntPtr dwReserved;
+        public IDLFLAG wIDLFlags;
+    }
+    public enum IDLFLAG : short {
+        IDLFLAG_FIN = (short)1,
+        IDLFLAG_FLCID = (short)4,
+        IDLFLAG_FOUT = (short)2,
+        IDLFLAG_FRETVAL = (short)8,
+        IDLFLAG_NONE = (short)0,
+    }
+    public interface IEnumConnectionPoints {
+        void Clone(out IEnumConnectionPoints ppenum);
+        int Next(int celt, IConnectionPoint[] rgelt, IntPtr pceltFetched);
+        void Reset();
+        int Skip(int celt);
+    }
+    public interface IEnumConnections {
+        void Clone(out IEnumConnections ppenum);
+        int Next(int celt, CONNECTDATA[] rgelt, IntPtr pceltFetched);
+        void Reset();
+        int Skip(int celt);
+    }
+    public interface IEnumFORMATETC {
+        void Clone(out IEnumFORMATETC newEnum);
+        int Next(int celt, FORMATETC[] rgelt, int[] pceltFetched);
+        int Reset();
+        int Skip(int celt);
+    }
+    public interface IEnumMoniker {
+        void Clone(out IEnumMoniker ppenum);
+        int Next(int celt, IMoniker[] rgelt, IntPtr pceltFetched);
+        void Reset();
+        int Skip(int celt);
+    }
+    public interface IEnumString {
+        void Clone(out IEnumString ppenum);
+        int Next(int celt, string[] rgelt, IntPtr pceltFetched);
+        void Reset();
+        int Skip(int celt);
+    }
+    public interface IEnumVARIANT {
+        IEnumVARIANT Clone();
+        int Next(int celt, object[] rgVar, IntPtr pceltFetched);
+        int Reset();
+        int Skip(int celt);
+    }
+    public interface IMoniker {
+        void BindToObject(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riidResult, out object ppvResult);
+        void BindToStorage(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riid, out object ppvObj);
+        void CommonPrefixWith(IMoniker pmkOther, out IMoniker ppmkPrefix);
+        void ComposeWith(IMoniker pmkRight, bool fOnlyIfNotGeneric, out IMoniker ppmkComposite);
+        void Enum(bool fForward, out IEnumMoniker ppenumMoniker);
+        void GetClassID(out Guid pClassID);
+        void GetDisplayName(IBindCtx pbc, IMoniker pmkToLeft, out string ppszDisplayName);
+        void GetSizeMax(out long pcbSize);
+        void GetTimeOfLastChange(IBindCtx pbc, IMoniker pmkToLeft, out FILETIME pFileTime);
+        void Hash(out int pdwHash);
+        void Inverse(out IMoniker ppmk);
+        int IsDirty();
+        int IsEqual(IMoniker pmkOtherMoniker);
+        int IsRunning(IBindCtx pbc, IMoniker pmkToLeft, IMoniker pmkNewlyRunning);
+        int IsSystemMoniker(out int pdwMksys);
+        void Load(IStream pStm);
+        void ParseDisplayName(IBindCtx pbc, IMoniker pmkToLeft, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut);
+        void Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker ppmkToLeft, out IMoniker ppmkReduced);
+        void RelativePathTo(IMoniker pmkOther, out IMoniker ppmkRelPath);
+        void Save(IStream pStm, bool fClearDirty);
+    }
+    public enum IMPLTYPEFLAGS {
+        IMPLTYPEFLAG_FDEFAULT = 1,
+        IMPLTYPEFLAG_FDEFAULTVTABLE = 8,
+        IMPLTYPEFLAG_FRESTRICTED = 4,
+        IMPLTYPEFLAG_FSOURCE = 2,
+    }
+    public enum INVOKEKIND {
+        INVOKE_FUNC = 1,
+        INVOKE_PROPERTYGET = 2,
+        INVOKE_PROPERTYPUT = 4,
+        INVOKE_PROPERTYPUTREF = 8,
+    }
+    public interface IPersistFile {
+        void GetClassID(out Guid pClassID);
+        void GetCurFile(out string ppszFileName);
+        int IsDirty();
+        void Load(string pszFileName, int dwMode);
+        void Save(string pszFileName, bool fRemember);
+        void SaveCompleted(string pszFileName);
+    }
+    public interface IRunningObjectTable {
+        void EnumRunning(out IEnumMoniker ppenumMoniker);
+        int GetObject(IMoniker pmkObjectName, out object ppunkObject);
+        int GetTimeOfLastChange(IMoniker pmkObjectName, out FILETIME pfiletime);
+        int IsRunning(IMoniker pmkObjectName);
+        void NoteChangeTime(int dwRegister, ref FILETIME pfiletime);
+        int Register(int grfFlags, object punkObject, IMoniker pmkObjectName);
+        void Revoke(int dwRegister);
+    }
+    public interface IStream {
+        void Clone(out IStream ppstm);
+        void Commit(int grfCommitFlags);
+        void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);
+        void LockRegion(long libOffset, long cb, int dwLockType);
+        void Read(byte[] pv, int cb, IntPtr pcbRead);
+        void Revert();
+        void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);
+        void SetSize(long libNewSize);
+        void Stat(out STATSTG pstatstg, int grfStatFlag);
+        void UnlockRegion(long libOffset, long cb, int dwLockType);
+        void Write(byte[] pv, int cb, IntPtr pcbWritten);
+    }
+    public interface ITypeComp {
+        void Bind(string szName, int lHashVal, short wFlags, out ITypeInfo ppTInfo, out DESCKIND pDescKind, out BINDPTR pBindPtr);
+        void BindType(string szName, int lHashVal, out ITypeInfo ppTInfo, out ITypeComp ppTComp);
+    }
+    public interface ITypeInfo {
+        void AddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv);
+        void CreateInstance(object pUnkOuter, ref Guid riid, out object ppvObj);
+        void GetContainingTypeLib(out ITypeLib ppTLB, out int pIndex);
+        void GetDllEntry(int memid, INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);
+        void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
+        void GetFuncDesc(int index, out IntPtr ppFuncDesc);
+        void GetIDsOfNames(string[] rgszNames, int cNames, int[] pMemId);
+        void GetImplTypeFlags(int index, out IMPLTYPEFLAGS pImplTypeFlags);
+        void GetMops(int memid, out string pBstrMops);
+        void GetNames(int memid, string[] rgBstrNames, int cMaxNames, out int pcNames);
+        void GetRefTypeInfo(int hRef, out ITypeInfo ppTI);
+        void GetRefTypeOfImplType(int index, out int href);
+        void GetTypeAttr(out IntPtr ppTypeAttr);
+        void GetTypeComp(out ITypeComp ppTComp);
+        void GetVarDesc(int index, out IntPtr ppVarDesc);
+        void Invoke(object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);
+        void ReleaseFuncDesc(IntPtr pFuncDesc);
+        void ReleaseTypeAttr(IntPtr pTypeAttr);
+        void ReleaseVarDesc(IntPtr pVarDesc);
+    }
+    public interface ITypeInfo2 : ITypeInfo {
+        new void AddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv);
+        new void CreateInstance(object pUnkOuter, ref Guid riid, out object ppvObj);
+        void GetAllCustData(IntPtr pCustData);
+        void GetAllFuncCustData(int index, IntPtr pCustData);
+        void GetAllImplTypeCustData(int index, IntPtr pCustData);
+        void GetAllParamCustData(int indexFunc, int indexParam, IntPtr pCustData);
+        void GetAllVarCustData(int index, IntPtr pCustData);
+        new void GetContainingTypeLib(out ITypeLib ppTLB, out int pIndex);
+        void GetCustData(ref Guid guid, out object pVarVal);
+        new void GetDllEntry(int memid, INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);
+        new void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
+        void GetDocumentation2(int memid, out string pbstrHelpString, out int pdwHelpStringContext, out string pbstrHelpStringDll);
+        void GetFuncCustData(int index, ref Guid guid, out object pVarVal);
+        new void GetFuncDesc(int index, out IntPtr ppFuncDesc);
+        void GetFuncIndexOfMemId(int memid, INVOKEKIND invKind, out int pFuncIndex);
+        new void GetIDsOfNames(string[] rgszNames, int cNames, int[] pMemId);
+        void GetImplTypeCustData(int index, ref Guid guid, out object pVarVal);
+        new void GetImplTypeFlags(int index, out IMPLTYPEFLAGS pImplTypeFlags);
+        new void GetMops(int memid, out string pBstrMops);
+        new void GetNames(int memid, string[] rgBstrNames, int cMaxNames, out int pcNames);
+        void GetParamCustData(int indexFunc, int indexParam, ref Guid guid, out object pVarVal);
+        new void GetRefTypeInfo(int hRef, out ITypeInfo ppTI);
+        new void GetRefTypeOfImplType(int index, out int href);
+        new void GetTypeAttr(out IntPtr ppTypeAttr);
+        new void GetTypeComp(out ITypeComp ppTComp);
+        void GetTypeFlags(out int pTypeFlags);
+        void GetTypeKind(out TYPEKIND pTypeKind);
+        void GetVarCustData(int index, ref Guid guid, out object pVarVal);
+        new void GetVarDesc(int index, out IntPtr ppVarDesc);
+        void GetVarIndexOfMemId(int memid, out int pVarIndex);
+        new void Invoke(object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);
+        new void ReleaseFuncDesc(IntPtr pFuncDesc);
+        new void ReleaseTypeAttr(IntPtr pTypeAttr);
+        new void ReleaseVarDesc(IntPtr pVarDesc);
+    }
+    public interface ITypeLib {
+        void FindName(string szNameBuf, int lHashVal, ITypeInfo[] ppTInfo, int[] rgMemId, ref short pcFound);
+        void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
+        void GetLibAttr(out IntPtr ppTLibAttr);
+        void GetTypeComp(out ITypeComp ppTComp);
+        void GetTypeInfo(int index, out ITypeInfo ppTI);
+        int GetTypeInfoCount();
+        void GetTypeInfoOfGuid(ref Guid guid, out ITypeInfo ppTInfo);
+        void GetTypeInfoType(int index, out TYPEKIND pTKind);
+        bool IsName(string szNameBuf, int lHashVal);
+        void ReleaseTLibAttr(IntPtr pTLibAttr);
+    }
+    public interface ITypeLib2 : ITypeLib {
+        new void FindName(string szNameBuf, int lHashVal, ITypeInfo[] ppTInfo, int[] rgMemId, ref short pcFound);
+        void GetAllCustData(IntPtr pCustData);
+        void GetCustData(ref Guid guid, out object pVarVal);
+        new void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
+        void GetDocumentation2(int index, out string pbstrHelpString, out int pdwHelpStringContext, out string pbstrHelpStringDll);
+        new void GetLibAttr(out IntPtr ppTLibAttr);
+        void GetLibStatistics(IntPtr pcUniqueNames, out int pcchUniqueNames);
+        new void GetTypeComp(out ITypeComp ppTComp);
+        new void GetTypeInfo(int index, out ITypeInfo ppTI);
+        new int GetTypeInfoCount();
+        new void GetTypeInfoOfGuid(ref Guid guid, out ITypeInfo ppTInfo);
+        new void GetTypeInfoType(int index, out TYPEKIND pTKind);
+        new bool IsName(string szNameBuf, int lHashVal);
+        new void ReleaseTLibAttr(IntPtr pTLibAttr);
+    }
+    public enum LIBFLAGS : short {
+        LIBFLAG_FCONTROL = (short)2,
+        LIBFLAG_FHASDISKIMAGE = (short)8,
+        LIBFLAG_FHIDDEN = (short)4,
+        LIBFLAG_FRESTRICTED = (short)1,
+    }
+    public struct PARAMDESC {
+        public IntPtr lpVarValue;
+        public PARAMFLAG wParamFlags;
+    }
+    public enum PARAMFLAG : short {
+        PARAMFLAG_FHASCUSTDATA = (short)64,
+        PARAMFLAG_FHASDEFAULT = (short)32,
+        PARAMFLAG_FIN = (short)1,
+        PARAMFLAG_FLCID = (short)4,
+        PARAMFLAG_FOPT = (short)16,
+        PARAMFLAG_FOUT = (short)2,
+        PARAMFLAG_FRETVAL = (short)8,
+        PARAMFLAG_NONE = (short)0,
+    }
+    public struct STATDATA {
+        public ADVF advf;
+        public IAdviseSink advSink;
+        public int connection;
+        public FORMATETC formatetc;
+    }
+    public struct STATSTG {
+        public FILETIME atime;
+        public long cbSize;
+        public Guid clsid;
+        public FILETIME ctime;
+        public int grfLocksSupported;
+        public int grfMode;
+        public int grfStateBits;
+        public FILETIME mtime;
+        public string pwcsName;
+        public int reserved;
+        public int type;
+    }
+    public struct STGMEDIUM {
+        public object pUnkForRelease;
+        public TYMED tymed;
+        public IntPtr unionmember;
+    }
+    public enum SYSKIND {
+        SYS_MAC = 2,
+        SYS_WIN16 = 0,
+        SYS_WIN32 = 1,
+        SYS_WIN64 = 3,
+    }
+    public enum TYMED {
+        TYMED_ENHMF = 64,
+        TYMED_FILE = 2,
+        TYMED_GDI = 16,
+        TYMED_HGLOBAL = 1,
+        TYMED_ISTORAGE = 8,
+        TYMED_ISTREAM = 4,
+        TYMED_MFPICT = 32,
+        TYMED_NULL = 0,
+    }
+    public struct TYPEATTR {
+        public short cbAlignment;
+        public int cbSizeInstance;
+        public short cbSizeVft;
+        public short cFuncs;
+        public short cImplTypes;
+        public short cVars;
+        public int dwReserved;
+        public Guid guid;
+        public IDLDESC idldescType;
+        public int lcid;
+        public IntPtr lpstrSchema;
+        public const int MEMBER_ID_NIL = -1;
+        public int memidConstructor;
+        public int memidDestructor;
+        public TYPEDESC tdescAlias;
+        public TYPEKIND typekind;
+        public short wMajorVerNum;
+        public short wMinorVerNum;
+        public TYPEFLAGS wTypeFlags;
+    }
+    public struct TYPEDESC {
+        public IntPtr lpValue;
+        public short vt;
+    }
+    public enum TYPEFLAGS : short {
+        TYPEFLAG_FAGGREGATABLE = (short)1024,
+        TYPEFLAG_FAPPOBJECT = (short)1,
+        TYPEFLAG_FCANCREATE = (short)2,
+        TYPEFLAG_FCONTROL = (short)32,
+        TYPEFLAG_FDISPATCHABLE = (short)4096,
+        TYPEFLAG_FDUAL = (short)64,
+        TYPEFLAG_FHIDDEN = (short)16,
+        TYPEFLAG_FLICENSED = (short)4,
+        TYPEFLAG_FNONEXTENSIBLE = (short)128,
+        TYPEFLAG_FOLEAUTOMATION = (short)256,
+        TYPEFLAG_FPREDECLID = (short)8,
+        TYPEFLAG_FPROXY = (short)16384,
+        TYPEFLAG_FREPLACEABLE = (short)2048,
+        TYPEFLAG_FRESTRICTED = (short)512,
+        TYPEFLAG_FREVERSEBIND = (short)8192,
+    }
+    public enum TYPEKIND {
+        TKIND_ALIAS = 6,
+        TKIND_COCLASS = 5,
+        TKIND_DISPATCH = 4,
+        TKIND_ENUM = 0,
+        TKIND_INTERFACE = 3,
+        TKIND_MAX = 8,
+        TKIND_MODULE = 2,
+        TKIND_RECORD = 1,
+        TKIND_UNION = 7,
+    }
+    public struct TYPELIBATTR {
+        public Guid guid;
+        public int lcid;
+        public SYSKIND syskind;
+        public LIBFLAGS wLibFlags;
+        public short wMajorVerNum;
+        public short wMinorVerNum;
+    }
+    public struct VARDESC {
+        public struct DESCUNION {
+            public IntPtr lpvarValue;
+            public int oInst;
+        }
+        public VARDESC.DESCUNION desc;
+        public ELEMDESC elemdescVar;
+        public string lpstrSchema;
+        public int memid;
+        public VARKIND varkind;
+        public short wVarFlags;
+    }
+    public enum VARFLAGS : short {
+        VARFLAG_FBINDABLE = (short)4,
+        VARFLAG_FDEFAULTBIND = (short)32,
+        VARFLAG_FDEFAULTCOLLELEM = (short)256,
+        VARFLAG_FDISPLAYBIND = (short)16,
+        VARFLAG_FHIDDEN = (short)64,
+        VARFLAG_FIMMEDIATEBIND = (short)4096,
+        VARFLAG_FNONBROWSABLE = (short)1024,
+        VARFLAG_FREADONLY = (short)1,
+        VARFLAG_FREPLACEABLE = (short)2048,
+        VARFLAG_FREQUESTEDIT = (short)8,
+        VARFLAG_FRESTRICTED = (short)128,
+        VARFLAG_FSOURCE = (short)2,
+        VARFLAG_FUIDEFAULT = (short)512,
+    }
+    public enum VARKIND {
+        VAR_CONST = 2,
+        VAR_DISPATCH = 3,
+        VAR_PERINSTANCE = 0,
+        VAR_STATIC = 1,
+    }
+}
```
