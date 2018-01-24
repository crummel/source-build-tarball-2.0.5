# .NET Standard 1.3 vs. 1.2

[Overview](netstandard1.3.md) | [Previous](netstandard1.2_diff.md) | [Next](netstandard1.4_diff.md)

```diff
 namespace System {
+    public static class AppContext {
+        public static string BaseDirectory { get; }
+        public static void SetSwitch(string switchName, bool isEnabled);
+        public static bool TryGetSwitch(string switchName, out bool isEnabled);
+    }
     public abstract class Array : ICollection, IEnumerable, IList, IStructuralComparable, IStructuralEquatable {
+        public static Array CreateInstance(Type elementType, int length);
+        public static T[] Empty<T>();
+        public object GetValue(int index);
+        public void SetValue(object value, int index);
+        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items);
+        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length);
+        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer);
+        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer);
+        public static void Sort(Array keys, Array items);
+        public static void Sort(Array keys, Array items, IComparer comparer);
+        public static void Sort(Array keys, Array items, int index, int length);
+        public static void Sort(Array keys, Array items, int index, int length, IComparer comparer);
     }
-    public struct Boolean : IComparable, IComparable<bool>, IEquatable<bool> {
+    public struct Boolean : IComparable, IComparable<bool>, IConvertible, IEquatable<bool> {
     }
     public static class Buffer {
+        public unsafe static void MemoryCopy(void* source, void* destination, long destinationSizeInBytes, long sourceBytesToCopy);
+        public unsafe static void MemoryCopy(void* source, void* destination, ulong destinationSizeInBytes, ulong sourceBytesToCopy);
     }
-    public struct Byte : IComparable, IComparable<byte>, IEquatable<byte>, IFormattable {
+    public struct Byte : IComparable, IComparable<byte>, IConvertible, IEquatable<byte>, IFormattable {
     }
-    public struct Char : IComparable, IComparable<char>, IEquatable<char> {
+    public struct Char : IComparable, IComparable<char>, IConvertible, IEquatable<char> {
+        public static char Parse(string s);
     }
+    public static class Console {
+        public static ConsoleColor BackgroundColor { get; set; }
+        public static int BufferHeight { get; set; }
+        public static int BufferWidth { get; set; }
+        public static bool CapsLock { get; }
+        public static int CursorLeft { get; set; }
+        public static int CursorSize { get; set; }
+        public static int CursorTop { get; set; }
+        public static bool CursorVisible { get; set; }
+        public static TextWriter Error { get; }
+        public static ConsoleColor ForegroundColor { get; set; }
+        public static TextReader In { get; }
+        public static Encoding InputEncoding { get; set; }
+        public static bool IsErrorRedirected { get; }
+        public static bool IsInputRedirected { get; }
+        public static bool IsOutputRedirected { get; }
+        public static bool KeyAvailable { get; }
+        public static int LargestWindowHeight { get; }
+        public static int LargestWindowWidth { get; }
+        public static bool NumberLock { get; }
+        public static TextWriter Out { get; }
+        public static Encoding OutputEncoding { get; set; }
+        public static string Title { get; set; }
+        public static bool TreatControlCAsInput { get; set; }
+        public static int WindowHeight { get; set; }
+        public static int WindowLeft { get; set; }
+        public static int WindowTop { get; set; }
+        public static int WindowWidth { get; set; }
+        public static void Beep();
+        public static void Beep(int frequency, int duration);
+        public static void Clear();
+        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);
+        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);
+        public static Stream OpenStandardError();
+        public static Stream OpenStandardInput();
+        public static Stream OpenStandardOutput();
+        public static int Read();
+        public static ConsoleKeyInfo ReadKey();
+        public static ConsoleKeyInfo ReadKey(bool intercept);
+        public static string ReadLine();
+        public static void ResetColor();
+        public static void SetBufferSize(int width, int height);
+        public static void SetCursorPosition(int left, int top);
+        public static void SetError(TextWriter newError);
+        public static void SetIn(TextReader newIn);
+        public static void SetOut(TextWriter newOut);
+        public static void SetWindowPosition(int left, int top);
+        public static void SetWindowSize(int width, int height);
+        public static void Write(bool value);
+        public static void Write(char value);
+        public static void Write(char[] buffer);
+        public static void Write(char[] buffer, int index, int count);
+        public static void Write(decimal value);
+        public static void Write(double value);
+        public static void Write(int value);
+        public static void Write(long value);
+        public static void Write(object value);
+        public static void Write(float value);
+        public static void Write(string value);
+        public static void Write(string format, object arg0);
+        public static void Write(string format, object arg0, object arg1);
+        public static void Write(string format, object arg0, object arg1, object arg2);
+        public static void Write(string format, params object[] arg);
+        public static void Write(uint value);
+        public static void Write(ulong value);
+        public static void WriteLine();
+        public static void WriteLine(bool value);
+        public static void WriteLine(char value);
+        public static void WriteLine(char[] buffer);
+        public static void WriteLine(char[] buffer, int index, int count);
+        public static void WriteLine(decimal value);
+        public static void WriteLine(double value);
+        public static void WriteLine(int value);
+        public static void WriteLine(long value);
+        public static void WriteLine(object value);
+        public static void WriteLine(float value);
+        public static void WriteLine(string value);
+        public static void WriteLine(string format, object arg0);
+        public static void WriteLine(string format, object arg0, object arg1);
+        public static void WriteLine(string format, object arg0, object arg1, object arg2);
+        public static void WriteLine(string format, params object[] arg);
+        public static void WriteLine(uint value);
+        public static void WriteLine(ulong value);
+        public static event ConsoleCancelEventHandler CancelKeyPress;
+    }
+    public sealed class ConsoleCancelEventArgs : EventArgs {
+        public bool Cancel { get; set; }
+        public ConsoleSpecialKey SpecialKey { get; }
+    }
+    public delegate void ConsoleCancelEventHandler(object sender, ConsoleCancelEventArgs e); {
+        public ConsoleCancelEventHandler(object @object, IntPtr method);
+        public virtual IAsyncResult BeginInvoke(object sender, ConsoleCancelEventArgs e, AsyncCallback callback, object @object);
+        public virtual void EndInvoke(IAsyncResult result);
+        public virtual void Invoke(object sender, ConsoleCancelEventArgs e);
+    }
+    public enum ConsoleColor {
+        Black = 0,
+        Blue = 9,
+        Cyan = 11,
+        DarkBlue = 1,
+        DarkCyan = 3,
+        DarkGray = 8,
+        DarkGreen = 2,
+        DarkMagenta = 5,
+        DarkRed = 4,
+        DarkYellow = 6,
+        Gray = 7,
+        Green = 10,
+        Magenta = 13,
+        Red = 12,
+        White = 15,
+        Yellow = 14,
+    }
+    public enum ConsoleKey {
+        A = 65,
+        Add = 107,
+        B = 66,
+        Backspace = 8,
+        C = 67,
+        Clear = 12,
+        D = 68,
+        D0 = 48,
+        D1 = 49,
+        D2 = 50,
+        D3 = 51,
+        D4 = 52,
+        D5 = 53,
+        D6 = 54,
+        D7 = 55,
+        D8 = 56,
+        D9 = 57,
+        Decimal = 110,
+        Delete = 46,
+        Divide = 111,
+        DownArrow = 40,
+        E = 69,
+        End = 35,
+        Enter = 13,
+        Escape = 27,
+        Execute = 43,
+        F = 70,
+        F1 = 112,
+        F10 = 121,
+        F11 = 122,
+        F12 = 123,
+        F13 = 124,
+        F14 = 125,
+        F15 = 126,
+        F16 = 127,
+        F17 = 128,
+        F18 = 129,
+        F19 = 130,
+        F2 = 113,
+        F20 = 131,
+        F21 = 132,
+        F22 = 133,
+        F23 = 134,
+        F24 = 135,
+        F3 = 114,
+        F4 = 115,
+        F5 = 116,
+        F6 = 117,
+        F7 = 118,
+        F8 = 119,
+        F9 = 120,
+        G = 71,
+        H = 72,
+        Help = 47,
+        Home = 36,
+        I = 73,
+        Insert = 45,
+        J = 74,
+        K = 75,
+        L = 76,
+        LeftArrow = 37,
+        M = 77,
+        Multiply = 106,
+        N = 78,
+        NumPad0 = 96,
+        NumPad1 = 97,
+        NumPad2 = 98,
+        NumPad3 = 99,
+        NumPad4 = 100,
+        NumPad5 = 101,
+        NumPad6 = 102,
+        NumPad7 = 103,
+        NumPad8 = 104,
+        NumPad9 = 105,
+        O = 79,
+        Oem1 = 186,
+        Oem2 = 191,
+        Oem3 = 192,
+        Oem4 = 219,
+        Oem5 = 220,
+        Oem6 = 221,
+        Oem7 = 222,
+        Oem8 = 223,
+        OemClear = 254,
+        OemComma = 188,
+        OemMinus = 189,
+        OemPeriod = 190,
+        OemPlus = 187,
+        P = 80,
+        PageDown = 34,
+        PageUp = 33,
+        Pause = 19,
+        Print = 42,
+        PrintScreen = 44,
+        Q = 81,
+        R = 82,
+        RightArrow = 39,
+        S = 83,
+        Select = 41,
+        Separator = 108,
+        Sleep = 95,
+        Spacebar = 32,
+        Subtract = 109,
+        T = 84,
+        Tab = 9,
+        U = 85,
+        UpArrow = 38,
+        V = 86,
+        W = 87,
+        X = 88,
+        Y = 89,
+        Z = 90,
+    }
+    public struct ConsoleKeyInfo {
+        public ConsoleKeyInfo(char keyChar, ConsoleKey key, bool shift, bool alt, bool control);
+        public ConsoleKey Key { get; }
+        public char KeyChar { get; }
+        public ConsoleModifiers Modifiers { get; }
+        public bool Equals(ConsoleKeyInfo obj);
+        public override bool Equals(object value);
+        public override int GetHashCode();
+        public static bool operator ==(ConsoleKeyInfo a, ConsoleKeyInfo b);
+        public static bool operator !=(ConsoleKeyInfo a, ConsoleKeyInfo b);
+    }
+    public enum ConsoleModifiers {
+        Alt = 1,
+        Control = 4,
+        Shift = 2,
+    }
+    public enum ConsoleSpecialKey {
+        ControlBreak = 1,
+        ControlC = 0,
+    }
     public static class Convert {
+        public static object ChangeType(object value, TypeCode typeCode, IFormatProvider provider);
+        public static TypeCode GetTypeCode(object value);
     }
-    public struct DateTime : IComparable, IComparable<DateTime>, IEquatable<DateTime>, IFormattable {
+    public struct DateTime : IComparable, IComparable<DateTime>, IConvertible, IEquatable<DateTime>, IFormattable {
     }
     public struct DateTimeOffset : IComparable, IComparable<DateTimeOffset>, IEquatable<DateTimeOffset>, IFormattable {
+        public static DateTimeOffset FromUnixTimeMilliseconds(long milliseconds);
+        public static DateTimeOffset FromUnixTimeSeconds(long seconds);
+        public long ToUnixTimeMilliseconds();
+        public long ToUnixTimeSeconds();
     }
-    public struct Decimal : IComparable, IComparable<decimal>, IEquatable<decimal>, IFormattable {
+    public struct Decimal : IComparable, IComparable<decimal>, IConvertible, IEquatable<decimal>, IFormattable {
     }
-    public struct Double : IComparable, IComparable<double>, IEquatable<double>, IFormattable {
+    public struct Double : IComparable, IComparable<double>, IConvertible, IEquatable<double>, IFormattable {
     }
-    public abstract class Enum : ValueType, IComparable, IFormattable {
+    public abstract class Enum : ValueType, IComparable, IConvertible, IFormattable {
     }
     public static class Environment {
+        public static string StackTrace { get; }
+        public static string ExpandEnvironmentVariables(string name);
+        public static string GetEnvironmentVariable(string variable);
+        public static IDictionary GetEnvironmentVariables();
+        public static void SetEnvironmentVariable(string variable, string value);
     }
+    public class FieldAccessException : MemberAccessException {
+        public FieldAccessException();
+        public FieldAccessException(string message);
+        public FieldAccessException(string message, Exception inner);
+    }
+    public abstract class FormattableString : IFormattable {
+        protected FormattableString();
+        public abstract int ArgumentCount { get; }
+        public abstract string Format { get; }
+        public abstract object GetArgument(int index);
+        public abstract object[] GetArguments();
+        public static string Invariant(FormattableString formattable);
+        public override string ToString();
+        public abstract string ToString(IFormatProvider formatProvider);
+    }
     public static class GC {
+        public static int GetGeneration(object obj);
     }
     public struct Guid : IComparable, IComparable<Guid>, IEquatable<Guid>, IFormattable {
+        public Guid(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k);
     }
+    public interface IConvertible {
+        TypeCode GetTypeCode();
+        bool ToBoolean(IFormatProvider provider);
+        byte ToByte(IFormatProvider provider);
+        char ToChar(IFormatProvider provider);
+        DateTime ToDateTime(IFormatProvider provider);
+        decimal ToDecimal(IFormatProvider provider);
+        double ToDouble(IFormatProvider provider);
+        short ToInt16(IFormatProvider provider);
+        int ToInt32(IFormatProvider provider);
+        long ToInt64(IFormatProvider provider);
+        sbyte ToSByte(IFormatProvider provider);
+        float ToSingle(IFormatProvider provider);
+        string ToString(IFormatProvider provider);
+        object ToType(Type conversionType, IFormatProvider provider);
+        ushort ToUInt16(IFormatProvider provider);
+        uint ToUInt32(IFormatProvider provider);
+        ulong ToUInt64(IFormatProvider provider);
+    }
+    public sealed class InsufficientExecutionStackException : Exception {
+        public InsufficientExecutionStackException();
+        public InsufficientExecutionStackException(string message);
+        public InsufficientExecutionStackException(string message, Exception innerException);
+    }
-    public struct Int16 : IComparable, IComparable<short>, IEquatable<short>, IFormattable {
+    public struct Int16 : IComparable, IComparable<short>, IConvertible, IEquatable<short>, IFormattable {
     }
-    public struct Int32 : IComparable, IComparable<int>, IEquatable<int>, IFormattable {
+    public struct Int32 : IComparable, IComparable<int>, IConvertible, IEquatable<int>, IFormattable {
     }
-    public struct Int64 : IComparable, IComparable<long>, IEquatable<long>, IFormattable {
+    public struct Int64 : IComparable, IComparable<long>, IConvertible, IEquatable<long>, IFormattable {
     }
+    public sealed class InvalidProgramException : Exception {
+        public InvalidProgramException();
+        public InvalidProgramException(string message);
+        public InvalidProgramException(string message, Exception inner);
+    }
+    public class MethodAccessException : MemberAccessException {
+        public MethodAccessException();
+        public MethodAccessException(string message);
+        public MethodAccessException(string message, Exception inner);
+    }
+    public class MissingFieldException : MissingMemberException {
+        public MissingFieldException();
+        public MissingFieldException(string message);
+        public MissingFieldException(string message, Exception inner);
+        public override string Message { get; }
+    }
+    public class MissingMethodException : MissingMemberException {
+        public MissingMethodException();
+        public MissingMethodException(string message);
+        public MissingMethodException(string message, Exception inner);
+        public override string Message { get; }
+    }
-    public struct SByte : IComparable, IComparable<sbyte>, IEquatable<sbyte>, IFormattable {
+    public struct SByte : IComparable, IComparable<sbyte>, IConvertible, IEquatable<sbyte>, IFormattable {
     }
-    public struct Single : IComparable, IComparable<float>, IEquatable<float>, IFormattable {
+    public struct Single : IComparable, IComparable<float>, IConvertible, IEquatable<float>, IFormattable {
     }
-    public sealed class String : IComparable, IComparable<string>, IEnumerable, IEnumerable<char>, IEquatable<string> {
+    public sealed class String : IComparable, IComparable<string>, IConvertible, IEnumerable, IEnumerable<char>, IEquatable<string> {
+        public static int Compare(string strA, string strB, bool ignoreCase);
+        public static string Format(IFormatProvider provider, string format, object arg0);
+        public static string Format(IFormatProvider provider, string format, object arg0, object arg1);
+        public static string Format(IFormatProvider provider, string format, object arg0, object arg1, object arg2);
+        public static string Format(string format, object arg0);
+        public static string Format(string format, object arg0, object arg1);
+        public static string Format(string format, object arg0, object arg1, object arg2);
     }
     public sealed class TimeZoneInfo : IEquatable<TimeZoneInfo> {
+        public string Id { get; }
+        public static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone);
+        public static TimeZoneInfo FindSystemTimeZoneById(string id);
+        public static ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones();
     }
     public abstract class Type {
+        public static readonly Type[] EmptyTypes;
-        public bool IsArray { get; }
+        public virtual bool IsArray { get; }
-        public bool IsByRef { get; }
+        public virtual bool IsByRef { get; }
-        public bool IsPointer { get; }
+        public virtual bool IsPointer { get; }
+        public static Type GetType(string typeName, bool throwOnError, bool ignoreCase);
     }
+    public enum TypeCode {
+        Boolean = 3,
+        Byte = 6,
+        Char = 4,
+        DateTime = 16,
+        Decimal = 15,
+        Double = 14,
+        Empty = 0,
+        Int16 = 7,
+        Int32 = 9,
+        Int64 = 11,
+        Object = 1,
+        SByte = 5,
+        Single = 13,
+        String = 18,
+        UInt16 = 8,
+        UInt32 = 10,
+        UInt64 = 12,
+    }
-    public struct UInt16 : IComparable, IComparable<ushort>, IEquatable<ushort>, IFormattable {
+    public struct UInt16 : IComparable, IComparable<ushort>, IConvertible, IEquatable<ushort>, IFormattable {
     }
-    public struct UInt32 : IComparable, IComparable<uint>, IEquatable<uint>, IFormattable {
+    public struct UInt32 : IComparable, IComparable<uint>, IConvertible, IEquatable<uint>, IFormattable {
     }
-    public struct UInt64 : IComparable, IComparable<ulong>, IEquatable<ulong>, IFormattable {
+    public struct UInt64 : IComparable, IComparable<ulong>, IConvertible, IEquatable<ulong>, IFormattable {
     }
     public class Uri {
+        public string IdnHost { get; }
     }
+    public class UriFormatException : FormatException {
+        public UriFormatException();
+        public UriFormatException(string textString);
+        public UriFormatException(string textString, Exception e);
+    }
 }
 namespace System.Collections.Concurrent {
-    public class BlockingCollection<T> : ICollection, IDisposable, IEnumerable, IEnumerable<T> {
+    public class BlockingCollection<T> : ICollection, IDisposable, IEnumerable, IEnumerable<T>, IReadOnlyCollection<T> {
     }
-    public class ConcurrentBag<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
+    public class ConcurrentBag<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T>, IReadOnlyCollection<T> {
     }
-    public class ConcurrentDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> {
+    public class ConcurrentDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
     }
-    public class ConcurrentQueue<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
+    public class ConcurrentQueue<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T>, IReadOnlyCollection<T> {
     }
-    public class ConcurrentStack<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
+    public class ConcurrentStack<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T>, IReadOnlyCollection<T> {
     }
 }
 namespace System.Collections.Generic {
     public class Dictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
-        public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey> {
+        public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey>, IReadOnlyCollection<TKey> {
         }
-        public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue> {
+        public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue>, IReadOnlyCollection<TValue> {
         }
     }
-    public class HashSet<T> : ICollection<T>, IEnumerable, IEnumerable<T>, ISet<T> {
+    public class HashSet<T> : ICollection<T>, IEnumerable, IEnumerable<T>, IReadOnlyCollection<T>, ISet<T> {
     }
-    public class LinkedList<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T> {
+    public class LinkedList<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, IReadOnlyCollection<T> {
     }
     public class List<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, IList, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T> {
+        public ReadOnlyCollection<T> AsReadOnly();
+        public void ForEach(Action<T> action);
     }
-    public class Queue<T> : ICollection, IEnumerable, IEnumerable<T> {
+    public class Queue<T> : ICollection, IEnumerable, IEnumerable<T>, IReadOnlyCollection<T> {
     }
-    public class SortedDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> {
+    public class SortedDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
-        public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey> {
+        public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey>, IReadOnlyCollection<TKey> {
         }
-        public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue> {
+        public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue>, IReadOnlyCollection<TValue> {
         }
     }
+    public class SortedList<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
+        public SortedList();
+        public SortedList(IComparer<TKey> comparer);
+        public SortedList(IDictionary<TKey, TValue> dictionary);
+        public SortedList(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer);
+        public SortedList(int capacity);
+        public SortedList(int capacity, IComparer<TKey> comparer);
+        public int Capacity { get; set; }
+        public IComparer<TKey> Comparer { get; }
+        public int Count { get; }
+        public TValue this[TKey key] { get; set; }
+        public IList<TKey> Keys { get; }
+        public IList<TValue> Values { get; }
+        public void Add(TKey key, TValue value);
+        public void Clear();
+        public bool ContainsKey(TKey key);
+        public bool ContainsValue(TValue value);
+        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
+        public int IndexOfKey(TKey key);
+        public int IndexOfValue(TValue value);
+        public bool Remove(TKey key);
+        public void RemoveAt(int index);
+        public void TrimExcess();
+        public bool TryGetValue(TKey key, out TValue value);
+    }
-    public class SortedSet<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, ISet<T> {
+    public class SortedSet<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, IReadOnlyCollection<T>, ISet<T> {
     }
-    public class Stack<T> : ICollection, IEnumerable, IEnumerable<T> {
+    public class Stack<T> : ICollection, IEnumerable, IEnumerable<T>, IReadOnlyCollection<T> {
     }
 }
 namespace System.Collections.ObjectModel {
     public class ReadOnlyDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
-        public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey> {
+        public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey>, IReadOnlyCollection<TKey> {
         }
-        public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue> {
+        public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue>, IReadOnlyCollection<TValue> {
         }
     }
 }
 namespace System.ComponentModel {
+    public interface INotifyPropertyChanging {
+        event PropertyChangingEventHandler PropertyChanging;
+    }
     public class PropertyChangedEventArgs : EventArgs {
-        public string PropertyName { get; }
+        public virtual string PropertyName { get; }
     }
+    public class PropertyChangingEventArgs : EventArgs {
+        public PropertyChangingEventArgs(string propertyName);
+        public virtual string PropertyName { get; }
+    }
+    public delegate void PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e); {
+        public PropertyChangingEventHandler(object @object, IntPtr method);
+        public virtual IAsyncResult BeginInvoke(object sender, PropertyChangingEventArgs e, AsyncCallback callback, object @object);
+        public virtual void EndInvoke(IAsyncResult result);
+        public virtual void Invoke(object sender, PropertyChangingEventArgs e);
+    }
+    public class Win32Exception : Exception {
+        public Win32Exception();
+        public Win32Exception(int error);
+        public Win32Exception(int error, string message);
+        public Win32Exception(string message);
+        public Win32Exception(string message, Exception innerException);
+        public int NativeErrorCode { get; }
+    }
 }
 namespace System.Diagnostics {
     public static class Debug {
+        public static void Assert(bool condition, string message, string detailMessage);
+        public static void Assert(bool condition, string message, string detailMessageFormat, params object[] args);
+        public static void Fail(string message);
+        public static void Fail(string message, string detailMessage);
+        public static void Write(object value);
+        public static void Write(object value, string category);
+        public static void Write(string message);
+        public static void Write(string message, string category);
+        public static void WriteIf(bool condition, object value);
+        public static void WriteIf(bool condition, object value, string category);
+        public static void WriteIf(bool condition, string message);
+        public static void WriteIf(bool condition, string message, string category);
+        public static void WriteLine(object value, string category);
+        public static void WriteLine(string message, string category);
+        public static void WriteLineIf(bool condition, object value);
+        public static void WriteLineIf(bool condition, object value, string category);
+        public static void WriteLineIf(bool condition, string message, string category);
     }
 }
 namespace System.Diagnostics.Tracing {
+    public enum EventActivityOptions {
+        Detachable = 8,
+        Disable = 2,
+        None = 0,
+        Recursive = 4,
+    }
     public sealed class EventAttribute : Attribute {
+        public EventActivityOptions ActivityOptions { get; set; }
+        public EventChannel Channel { get; set; }
+        public EventTags Tags { get; set; }
     }
+    public enum EventChannel : byte {
+        Admin = (byte)16,
+        Analytic = (byte)18,
+        Debug = (byte)19,
+        None = (byte)0,
+        Operational = (byte)17,
+    }
+    public class EventDataAttribute : Attribute {
+        public EventDataAttribute();
+        public string Name { get; set; }
+    }
+    public class EventFieldAttribute : Attribute {
+        public EventFieldAttribute();
+        public EventFieldFormat Format { get; set; }
+        public EventFieldTags Tags { get; set; }
+    }
+    public enum EventFieldFormat {
+        Boolean = 3,
+        Default = 0,
+        Hexadecimal = 4,
+        HResult = 15,
+        Json = 12,
+        String = 2,
+        Xml = 11,
+    }
+    public enum EventFieldTags {
+        None = 0,
+    }
+    public class EventIgnoreAttribute : Attribute {
+        public EventIgnoreAttribute();
+    }
     public enum EventKeywords : long {
+        All = (long)-1,
     }
+    public enum EventManifestOptions {
+        AllCultures = 2,
+        AllowEventSourceOverride = 8,
+        None = 0,
+        OnlyIfNeededForRegistration = 4,
+        Strict = 1,
+    }
     public class EventSource : IDisposable {
+        protected EventSource(EventSourceSettings settings);
+        protected EventSource(EventSourceSettings settings, params string[] traits);
+        public EventSource(string eventSourceName);
+        public EventSource(string eventSourceName, EventSourceSettings config);
+        public EventSource(string eventSourceName, EventSourceSettings config, params string[] traits);
+        public EventSourceSettings Settings { get; }
+        public static string GenerateManifest(Type eventSourceType, string assemblyPathToIncludeInManifest, EventManifestOptions flags);
+        public string GetTrait(string key);
+        public bool IsEnabled(EventLevel level, EventKeywords keywords, EventChannel channel);
+        public void Write<T>(string eventName, T data);
+        public void Write<T>(string eventName, EventSourceOptions options, T data);
+        public void Write<T>(string eventName, ref EventSourceOptions options, ref T data);
+        public void Write<T>(string eventName, ref EventSourceOptions options, ref Guid activityId, ref Guid relatedActivityId, ref T data);
+        public void Write(string eventName);
+        public void Write(string eventName, EventSourceOptions options);
+        protected void WriteEvent(int eventId, byte[] arg1);
+        protected void WriteEvent(int eventId, int arg1, string arg2);
+        protected void WriteEvent(int eventId, long arg1, byte[] arg2);
+        protected void WriteEvent(int eventId, long arg1, string arg2);
-        protected void WriteEventWithRelatedActivityId(int eventId, Guid childActivityID, params object[] args);
+        protected void WriteEventWithRelatedActivityId(int eventId, Guid relatedActivityId, params object[] args);
-        protected unsafe void WriteEventWithRelatedActivityIdCore(int eventId, Guid* childActivityID, int eventDataCount, EventSource.EventData* data);
+        protected unsafe void WriteEventWithRelatedActivityIdCore(int eventId, Guid* relatedActivityId, int eventDataCount, EventSource.EventData* data);
     }
+    public struct EventSourceOptions {
+        public EventActivityOptions ActivityOptions { get; set; }
+        public EventKeywords Keywords { get; set; }
+        public EventLevel Level { get; set; }
+        public EventOpcode Opcode { get; set; }
+        public EventTags Tags { get; set; }
+    }
+    public enum EventSourceSettings {
+        Default = 0,
+        EtwManifestEventFormat = 4,
+        EtwSelfDescribingEventFormat = 8,
+        ThrowOnEventWriteErrors = 1,
+    }
+    public enum EventTags {
+        None = 0,
+    }
     public class EventWrittenEventArgs : EventArgs {
+        public EventChannel Channel { get; }
+        public string EventName { get; }
+        public ReadOnlyCollection<string> PayloadNames { get; }
+        public EventTags Tags { get; }
     }
 }
 namespace System.Globalization {
+    public class ChineseLunisolarCalendar : EastAsianLunisolarCalendar {
+        public ChineseLunisolarCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int GetEra(DateTime time);
+    }
     public class CompareInfo {
+        public virtual int GetHashCode(string source, CompareOptions options);
     }
     public class CultureInfo : IFormatProvider {
-        public static CultureInfo CurrentCulture { get; }
+        public static CultureInfo CurrentCulture { get; set; }
-        public static CultureInfo CurrentUICulture { get; }
+        public static CultureInfo CurrentUICulture { get; set; }
     }
+    public abstract class EastAsianLunisolarCalendar : Calendar {
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public int GetCelestialStem(int sexagenaryYear);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public virtual int GetSexagenaryYear(DateTime time);
+        public int GetTerrestrialBranch(int sexagenaryYear);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class GregorianCalendar : Calendar {
+        public GregorianCalendar();
+        public GregorianCalendar(GregorianCalendarTypes type);
+        public virtual GregorianCalendarTypes CalendarType { get; set; }
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public enum GregorianCalendarTypes {
+        Arabic = 10,
+        Localized = 1,
+        MiddleEastFrench = 9,
+        TransliteratedEnglish = 11,
+        TransliteratedFrench = 12,
+        USEnglish = 2,
+    }
+    public class HebrewCalendar : Calendar {
+        public HebrewCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class HijriCalendar : Calendar {
+        public HijriCalendar();
+        public override int[] Eras { get; }
+        public int HijriAdjustment { get; set; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class JapaneseCalendar : Calendar {
+        public JapaneseCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class JapaneseLunisolarCalendar : EastAsianLunisolarCalendar {
+        public JapaneseLunisolarCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int GetEra(DateTime time);
+    }
+    public class JulianCalendar : Calendar {
+        public JulianCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class KoreanCalendar : Calendar {
+        public KoreanCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class KoreanLunisolarCalendar : EastAsianLunisolarCalendar {
+        public KoreanLunisolarCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int GetEra(DateTime time);
+    }
+    public class PersianCalendar : Calendar {
+        public PersianCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class TaiwanCalendar : Calendar {
+        public TaiwanCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class TaiwanLunisolarCalendar : EastAsianLunisolarCalendar {
+        public TaiwanLunisolarCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int GetEra(DateTime time);
+    }
     public class TextInfo {
+        public bool IsRightToLeft { get; }
     }
+    public class ThaiBuddhistCalendar : Calendar {
+        public ThaiBuddhistCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
+    public class UmAlQuraCalendar : Calendar {
+        public UmAlQuraCalendar();
+        public override int[] Eras { get; }
+        public override DateTime MaxSupportedDateTime { get; }
+        public override DateTime MinSupportedDateTime { get; }
+        public override int TwoDigitYearMax { get; set; }
+        public override DateTime AddMonths(DateTime time, int months);
+        public override DateTime AddYears(DateTime time, int years);
+        public override int GetDayOfMonth(DateTime time);
+        public override DayOfWeek GetDayOfWeek(DateTime time);
+        public override int GetDayOfYear(DateTime time);
+        public override int GetDaysInMonth(int year, int month, int era);
+        public override int GetDaysInYear(int year, int era);
+        public override int GetEra(DateTime time);
+        public override int GetLeapMonth(int year, int era);
+        public override int GetMonth(DateTime time);
+        public override int GetMonthsInYear(int year, int era);
+        public override int GetYear(DateTime time);
+        public override bool IsLeapDay(int year, int month, int day, int era);
+        public override bool IsLeapMonth(int year, int month, int era);
+        public override bool IsLeapYear(int year, int era);
+        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
+        public override int ToFourDigitYear(int year);
+    }
 }
 namespace System.IO {
+    public static class Directory {
+        public static DirectoryInfo CreateDirectory(string path);
+        public static void Delete(string path);
+        public static void Delete(string path, bool recursive);
+        public static IEnumerable<string> EnumerateDirectories(string path);
+        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
+        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
+        public static IEnumerable<string> EnumerateFiles(string path);
+        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern);
+        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
+        public static IEnumerable<string> EnumerateFileSystemEntries(string path);
+        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
+        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
+        public static bool Exists(string path);
+        public static DateTime GetCreationTime(string path);
+        public static DateTime GetCreationTimeUtc(string path);
+        public static string GetCurrentDirectory();
+        public static string[] GetDirectories(string path);
+        public static string[] GetDirectories(string path, string searchPattern);
+        public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
+        public static string GetDirectoryRoot(string path);
+        public static string[] GetFiles(string path);
+        public static string[] GetFiles(string path, string searchPattern);
+        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
+        public static string[] GetFileSystemEntries(string path);
+        public static string[] GetFileSystemEntries(string path, string searchPattern);
+        public static string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
+        public static DateTime GetLastAccessTime(string path);
+        public static DateTime GetLastAccessTimeUtc(string path);
+        public static DateTime GetLastWriteTime(string path);
+        public static DateTime GetLastWriteTimeUtc(string path);
+        public static DirectoryInfo GetParent(string path);
+        public static void Move(string sourceDirName, string destDirName);
+        public static void SetCreationTime(string path, DateTime creationTime);
+        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
+        public static void SetCurrentDirectory(string path);
+        public static void SetLastAccessTime(string path, DateTime lastAccessTime);
+        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
+        public static void SetLastWriteTime(string path, DateTime lastWriteTime);
+        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
+    }
+    public sealed class DirectoryInfo : FileSystemInfo {
+        public DirectoryInfo(string path);
+        public override bool Exists { get; }
+        public override string Name { get; }
+        public DirectoryInfo Parent { get; }
+        public DirectoryInfo Root { get; }
+        public void Create();
+        public DirectoryInfo CreateSubdirectory(string path);
+        public override void Delete();
+        public void Delete(bool recursive);
+        public IEnumerable<DirectoryInfo> EnumerateDirectories();
+        public IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern);
+        public IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption);
+        public IEnumerable<FileInfo> EnumerateFiles();
+        public IEnumerable<FileInfo> EnumerateFiles(string searchPattern);
+        public IEnumerable<FileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption);
+        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos();
+        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern);
+        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption);
+        public DirectoryInfo[] GetDirectories();
+        public DirectoryInfo[] GetDirectories(string searchPattern);
+        public DirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption);
+        public FileInfo[] GetFiles();
+        public FileInfo[] GetFiles(string searchPattern);
+        public FileInfo[] GetFiles(string searchPattern, SearchOption searchOption);
+        public FileSystemInfo[] GetFileSystemInfos();
+        public FileSystemInfo[] GetFileSystemInfos(string searchPattern);
+        public FileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption);
+        public void MoveTo(string destDirName);
+        public override string ToString();
+    }
+    public class DirectoryNotFoundException : IOException {
+        public DirectoryNotFoundException();
+        public DirectoryNotFoundException(string message);
+        public DirectoryNotFoundException(string message, Exception innerException);
+    }
+    public static class File {
+        public static void AppendAllLines(string path, IEnumerable<string> contents);
+        public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
+        public static void AppendAllText(string path, string contents);
+        public static void AppendAllText(string path, string contents, Encoding encoding);
+        public static StreamWriter AppendText(string path);
+        public static void Copy(string sourceFileName, string destFileName);
+        public static void Copy(string sourceFileName, string destFileName, bool overwrite);
+        public static FileStream Create(string path);
+        public static FileStream Create(string path, int bufferSize);
+        public static FileStream Create(string path, int bufferSize, FileOptions options);
+        public static StreamWriter CreateText(string path);
+        public static void Delete(string path);
+        public static bool Exists(string path);
+        public static FileAttributes GetAttributes(string path);
+        public static DateTime GetCreationTime(string path);
+        public static DateTime GetCreationTimeUtc(string path);
+        public static DateTime GetLastAccessTime(string path);
+        public static DateTime GetLastAccessTimeUtc(string path);
+        public static DateTime GetLastWriteTime(string path);
+        public static DateTime GetLastWriteTimeUtc(string path);
+        public static void Move(string sourceFileName, string destFileName);
+        public static FileStream Open(string path, FileMode mode);
+        public static FileStream Open(string path, FileMode mode, FileAccess access);
+        public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share);
+        public static FileStream OpenRead(string path);
+        public static StreamReader OpenText(string path);
+        public static FileStream OpenWrite(string path);
+        public static byte[] ReadAllBytes(string path);
+        public static string[] ReadAllLines(string path);
+        public static string[] ReadAllLines(string path, Encoding encoding);
+        public static string ReadAllText(string path);
+        public static string ReadAllText(string path, Encoding encoding);
+        public static IEnumerable<string> ReadLines(string path);
+        public static IEnumerable<string> ReadLines(string path, Encoding encoding);
+        public static void SetAttributes(string path, FileAttributes fileAttributes);
+        public static void SetCreationTime(string path, DateTime creationTime);
+        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
+        public static void SetLastAccessTime(string path, DateTime lastAccessTime);
+        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
+        public static void SetLastWriteTime(string path, DateTime lastWriteTime);
+        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
+        public static void WriteAllBytes(string path, byte[] bytes);
+        public static void WriteAllLines(string path, IEnumerable<string> contents);
+        public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
+        public static void WriteAllText(string path, string contents);
+        public static void WriteAllText(string path, string contents, Encoding encoding);
+    }
+    public enum FileAccess {
+        Read = 1,
+        ReadWrite = 3,
+        Write = 2,
+    }
+    public enum FileAttributes {
+        Archive = 32,
+        Compressed = 2048,
+        Device = 64,
+        Directory = 16,
+        Encrypted = 16384,
+        Hidden = 2,
+        IntegrityStream = 32768,
+        Normal = 128,
+        NoScrubData = 131072,
+        NotContentIndexed = 8192,
+        Offline = 4096,
+        ReadOnly = 1,
+        ReparsePoint = 1024,
+        SparseFile = 512,
+        System = 4,
+        Temporary = 256,
+    }
+    public sealed class FileInfo : FileSystemInfo {
+        public FileInfo(string fileName);
+        public DirectoryInfo Directory { get; }
+        public string DirectoryName { get; }
+        public override bool Exists { get; }
+        public bool IsReadOnly { get; set; }
+        public long Length { get; }
+        public override string Name { get; }
+        public StreamWriter AppendText();
+        public FileInfo CopyTo(string destFileName);
+        public FileInfo CopyTo(string destFileName, bool overwrite);
+        public FileStream Create();
+        public StreamWriter CreateText();
+        public override void Delete();
+        public void MoveTo(string destFileName);
+        public FileStream Open(FileMode mode);
+        public FileStream Open(FileMode mode, FileAccess access);
+        public FileStream Open(FileMode mode, FileAccess access, FileShare share);
+        public FileStream OpenRead();
+        public StreamReader OpenText();
+        public FileStream OpenWrite();
+        public override string ToString();
+    }
+    public class FileLoadException : IOException {
+        public FileLoadException();
+        public FileLoadException(string message);
+        public FileLoadException(string message, Exception inner);
+        public FileLoadException(string message, string fileName);
+        public FileLoadException(string message, string fileName, Exception inner);
+        public string FileName { get; }
+        public override string Message { get; }
+        public override string ToString();
+    }
+    public enum FileMode {
+        Append = 6,
+        Create = 2,
+        CreateNew = 1,
+        Open = 3,
+        OpenOrCreate = 4,
+        Truncate = 5,
+    }
+    public enum FileOptions {
+        Asynchronous = 1073741824,
+        DeleteOnClose = 67108864,
+        Encrypted = 16384,
+        None = 0,
+        RandomAccess = 268435456,
+        SequentialScan = 134217728,
+        WriteThrough = -2147483648,
+    }
+    public enum FileShare {
+        Delete = 4,
+        Inheritable = 16,
+        None = 0,
+        Read = 1,
+        ReadWrite = 3,
+        Write = 2,
+    }
+    public class FileStream : Stream {
+        public FileStream(SafeFileHandle handle, FileAccess access);
+        public FileStream(SafeFileHandle handle, FileAccess access, int bufferSize);
+        public FileStream(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync);
+        public FileStream(string path, FileMode mode);
+        public FileStream(string path, FileMode mode, FileAccess access);
+        public FileStream(string path, FileMode mode, FileAccess access, FileShare share);
+        public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize);
+        public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync);
+        public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options);
+        public override bool CanRead { get; }
+        public override bool CanSeek { get; }
+        public override bool CanWrite { get; }
+        public virtual bool IsAsync { get; }
+        public override long Length { get; }
+        public string Name { get; }
+        public override long Position { get; set; }
+        public virtual SafeFileHandle SafeFileHandle { get; }
+        protected override void Dispose(bool disposing);
+        ~FileStream();
+        public override void Flush();
+        public virtual void Flush(bool flushToDisk);
+        public override Task FlushAsync(CancellationToken cancellationToken);
+        public override int Read(byte[] array, int offset, int count);
+        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
+        public override int ReadByte();
+        public override long Seek(long offset, SeekOrigin origin);
+        public override void SetLength(long value);
+        public override void Write(byte[] array, int offset, int count);
+        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
+        public override void WriteByte(byte value);
+    }
+    public abstract class FileSystemInfo {
+        protected string FullPath;
+        protected string OriginalPath;
+        protected FileSystemInfo();
+        public FileAttributes Attributes { get; set; }
+        public DateTime CreationTime { get; set; }
+        public DateTime CreationTimeUtc { get; set; }
+        public abstract bool Exists { get; }
+        public string Extension { get; }
+        public virtual string FullName { get; }
+        public DateTime LastAccessTime { get; set; }
+        public DateTime LastAccessTimeUtc { get; set; }
+        public DateTime LastWriteTime { get; set; }
+        public DateTime LastWriteTimeUtc { get; set; }
+        public abstract string Name { get; }
+        public abstract void Delete();
+        public void Refresh();
+    }
+    public enum HandleInheritability {
+        Inheritable = 1,
+        None = 0,
+    }
     public class MemoryStream : Stream {
+        public MemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible);
+        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken);
+        public virtual bool TryGetBuffer(out ArraySegment<byte> buffer);
     }
     public static class Path {
+        public static readonly char AltDirectorySeparatorChar;
+        public static readonly char DirectorySeparatorChar;
+        public static readonly char PathSeparator;
+        public static readonly char VolumeSeparatorChar;
+        public static string Combine(string path1, string path2);
+        public static string Combine(string path1, string path2, string path3);
+        public static string GetFullPath(string path);
+        public static string GetTempFileName();
+        public static string GetTempPath();
     }
+    public class PathTooLongException : IOException {
+        public PathTooLongException();
+        public PathTooLongException(string message);
+        public PathTooLongException(string message, Exception innerException);
+    }
+    public enum SearchOption {
+        AllDirectories = 1,
+        TopDirectoryOnly = 0,
+    }
     public abstract class TextWriter : IDisposable {
+        public virtual void Write(string format, object arg0);
+        public virtual void Write(string format, object arg0, object arg1);
+        public virtual void Write(string format, object arg0, object arg1, object arg2);
+        public virtual void WriteLine(string format, object arg0);
+        public virtual void WriteLine(string format, object arg0, object arg1);
+        public virtual void WriteLine(string format, object arg0, object arg1, object arg2);
     }
 }
 namespace System.IO.Compression {
     public class DeflateStream : Stream {
+        public override Task<int> ReadAsync(byte[] array, int offset, int count, CancellationToken cancellationToken);
+        public override Task WriteAsync(byte[] array, int offset, int count, CancellationToken cancellationToken);
     }
     public class GZipStream : Stream {
+        public override Task<int> ReadAsync(byte[] array, int offset, int count, CancellationToken cancellationToken);
+        public override Task WriteAsync(byte[] array, int offset, int count, CancellationToken cancellationToken);
     }
+    public static class ZipFile {
+        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName);
+        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory);
+        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory, Encoding entryNameEncoding);
+        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName);
+        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding entryNameEncoding);
+        public static ZipArchive Open(string archiveFileName, ZipArchiveMode mode);
+        public static ZipArchive Open(string archiveFileName, ZipArchiveMode mode, Encoding entryNameEncoding);
+        public static ZipArchive OpenRead(string archiveFileName);
+    }
+    public static class ZipFileExtensions {
+        public static ZipArchiveEntry CreateEntryFromFile(this ZipArchive destination, string sourceFileName, string entryName);
+        public static ZipArchiveEntry CreateEntryFromFile(this ZipArchive destination, string sourceFileName, string entryName, CompressionLevel compressionLevel);
+        public static void ExtractToDirectory(this ZipArchive source, string destinationDirectoryName);
+        public static void ExtractToFile(this ZipArchiveEntry source, string destinationFileName);
+        public static void ExtractToFile(this ZipArchiveEntry source, string destinationFileName, bool overwrite);
+    }
 }
 namespace System.Linq.Expressions {
-    public sealed class ElementInit {
+    public sealed class ElementInit : IArgumentProvider {
     }
+    public interface IArgumentProvider {
+        int ArgumentCount { get; }
+        Expression GetArgument(int index);
+    }
+    public interface IDynamicExpression : IArgumentProvider {
+        Type DelegateType { get; }
+        object CreateCallSite();
+        Expression Rewrite(Expression[] args);
+    }
-    public sealed class IndexExpression : Expression {
+    public sealed class IndexExpression : Expression, IArgumentProvider {
     }
-    public sealed class InvocationExpression : Expression {
+    public sealed class InvocationExpression : Expression, IArgumentProvider {
     }
-    public class MethodCallExpression : Expression {
+    public class MethodCallExpression : Expression, IArgumentProvider {
     }
-    public class NewExpression : Expression {
+    public class NewExpression : Expression, IArgumentProvider {
     }
 }
 namespace System.Net {
+    public class DnsEndPoint : EndPoint {
+        public DnsEndPoint(string host, int port);
+        public DnsEndPoint(string host, int port, AddressFamily addressFamily);
+        public override AddressFamily AddressFamily { get; }
+        public string Host { get; }
+        public int Port { get; }
+        public override bool Equals(object comparand);
+        public override int GetHashCode();
+        public override string ToString();
+    }
+    public abstract class EndPoint {
+        protected EndPoint();
+        public virtual AddressFamily AddressFamily { get; }
+        public virtual EndPoint Create(SocketAddress socketAddress);
+        public virtual SocketAddress Serialize();
+    }
+    public class IPAddress {
+        public static readonly IPAddress Any;
+        public static readonly IPAddress Broadcast;
+        public static readonly IPAddress IPv6Any;
+        public static readonly IPAddress IPv6Loopback;
+        public static readonly IPAddress IPv6None;
+        public static readonly IPAddress Loopback;
+        public static readonly IPAddress None;
+        public IPAddress(byte[] address);
+        public IPAddress(byte[] address, long scopeid);
+        public IPAddress(long newAddress);
+        public AddressFamily AddressFamily { get; }
+        public bool IsIPv4MappedToIPv6 { get; }
+        public bool IsIPv6LinkLocal { get; }
+        public bool IsIPv6Multicast { get; }
+        public bool IsIPv6SiteLocal { get; }
+        public bool IsIPv6Teredo { get; }
+        public long ScopeId { get; set; }
+        public override bool Equals(object comparand);
+        public byte[] GetAddressBytes();
+        public override int GetHashCode();
+        public static short HostToNetworkOrder(short host);
+        public static int HostToNetworkOrder(int host);
+        public static long HostToNetworkOrder(long host);
+        public static bool IsLoopback(IPAddress address);
+        public IPAddress MapToIPv4();
+        public IPAddress MapToIPv6();
+        public static short NetworkToHostOrder(short network);
+        public static int NetworkToHostOrder(int network);
+        public static long NetworkToHostOrder(long network);
+        public static IPAddress Parse(string ipString);
+        public override string ToString();
+        public static bool TryParse(string ipString, out IPAddress address);
+    }
+    public class IPEndPoint : EndPoint {
+        public const int MaxPort = 65535;
+        public const int MinPort = 0;
+        public IPEndPoint(long address, int port);
+        public IPEndPoint(IPAddress address, int port);
+        public IPAddress Address { get; set; }
+        public override AddressFamily AddressFamily { get; }
+        public int Port { get; set; }
+        public override EndPoint Create(SocketAddress socketAddress);
+        public override bool Equals(object comparand);
+        public override int GetHashCode();
+        public override SocketAddress Serialize();
+        public override string ToString();
+    }
+    public class SocketAddress {
+        public SocketAddress(AddressFamily family);
+        public SocketAddress(AddressFamily family, int size);
+        public AddressFamily Family { get; }
+        public byte this[int offset] { get; set; }
+        public int Size { get; }
+        public override bool Equals(object comparand);
+        public override int GetHashCode();
+        public override string ToString();
+    }
     public abstract class TransportContext {
+        protected TransportContext();
+        public abstract ChannelBinding GetChannelBinding(ChannelBindingKind kind);
     }
 }
 namespace System.Net.Http {
     public class HttpClientHandler : HttpMessageHandler {
+        public bool CheckCertificateRevocationList { get; set; }
+        public X509CertificateCollection ClientCertificates { get; }
+        public ICredentials DefaultProxyCredentials { get; set; }
+        public int MaxConnectionsPerServer { get; set; }
+        public int MaxResponseHeadersLength { get; set; }
+        public IDictionary<string, object> Properties { get; }
+        public Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> ServerCertificateCustomValidationCallback { get; set; }
+        public SslProtocols SslProtocols { get; set; }
     }
 }
+namespace System.Net.NetworkInformation {
+    public class IPAddressCollection : ICollection<IPAddress>, IEnumerable, IEnumerable<IPAddress> {
+        protected internal IPAddressCollection();
+        public virtual int Count { get; }
+        public virtual bool IsReadOnly { get; }
+        public virtual IPAddress this[int index] { get; }
+        public virtual void Add(IPAddress address);
+        public virtual void Clear();
+        public virtual bool Contains(IPAddress address);
+        public virtual void CopyTo(IPAddress[] array, int offset);
+        public virtual IEnumerator<IPAddress> GetEnumerator();
+        public virtual bool Remove(IPAddress address);
+    }
+}
+namespace System.Net.Security {
+    public enum AuthenticationLevel {
+        MutualAuthRequested = 1,
+        MutualAuthRequired = 2,
+        None = 0,
+    }
+    public enum SslPolicyErrors {
+        None = 0,
+        RemoteCertificateChainErrors = 4,
+        RemoteCertificateNameMismatch = 2,
+        RemoteCertificateNotAvailable = 1,
+    }
+}
+namespace System.Net.Sockets {
+    public enum AddressFamily {
+        AppleTalk = 16,
+        Atm = 22,
+        Banyan = 21,
+        Ccitt = 10,
+        Chaos = 5,
+        Cluster = 24,
+        DataKit = 9,
+        DataLink = 13,
+        DecNet = 12,
+        Ecma = 8,
+        FireFox = 19,
+        HyperChannel = 15,
+        Ieee12844 = 25,
+        ImpLink = 3,
+        InterNetwork = 2,
+        InterNetworkV6 = 23,
+        Ipx = 6,
+        Irda = 26,
+        Iso = 7,
+        Lat = 14,
+        NetBios = 17,
+        NetworkDesigners = 28,
+        NS = 6,
+        Osi = 7,
+        Pup = 4,
+        Sna = 11,
+        Unix = 1,
+        Unknown = -1,
+        Unspecified = 0,
+        VoiceView = 18,
+    }
+    public enum IOControlCode : long {
+        AbsorbRouterAlert = (long)2550136837,
+        AddMulticastGroupOnInterface = (long)2550136842,
+        AddressListChange = (long)671088663,
+        AddressListQuery = (long)1207959574,
+        AddressListSort = (long)3355443225,
+        AssociateHandle = (long)2281701377,
+        AsyncIO = (long)2147772029,
+        BindToInterface = (long)2550136840,
+        DataToRead = (long)1074030207,
+        DeleteMulticastGroupFromInterface = (long)2550136843,
+        EnableCircularQueuing = (long)671088642,
+        Flush = (long)671088644,
+        GetBroadcastAddress = (long)1207959557,
+        GetExtensionFunctionPointer = (long)3355443206,
+        GetGroupQos = (long)3355443208,
+        GetQos = (long)3355443207,
+        KeepAliveValues = (long)2550136836,
+        LimitBroadcasts = (long)2550136839,
+        MulticastInterface = (long)2550136841,
+        MulticastScope = (long)2281701386,
+        MultipointLoopback = (long)2281701385,
+        NamespaceChange = (long)2281701401,
+        NonBlockingIO = (long)2147772030,
+        OobDataRead = (long)1074033415,
+        QueryTargetPnpHandle = (long)1207959576,
+        ReceiveAll = (long)2550136833,
+        ReceiveAllIgmpMulticast = (long)2550136835,
+        ReceiveAllMulticast = (long)2550136834,
+        RoutingInterfaceChange = (long)2281701397,
+        RoutingInterfaceQuery = (long)3355443220,
+        SetGroupQos = (long)2281701388,
+        SetQos = (long)2281701387,
+        TranslateHandle = (long)3355443213,
+        UnicastInterface = (long)2550136838,
+    }
+    public struct IPPacketInformation {
+        public IPAddress Address { get; }
+        public int Interface { get; }
+        public override bool Equals(object comparand);
+        public override int GetHashCode();
+        public static bool operator ==(IPPacketInformation packetInformation1, IPPacketInformation packetInformation2);
+        public static bool operator !=(IPPacketInformation packetInformation1, IPPacketInformation packetInformation2);
+    }
+    public enum IPProtectionLevel {
+        EdgeRestricted = 20,
+        Restricted = 30,
+        Unrestricted = 10,
+        Unspecified = -1,
+    }
+    public class IPv6MulticastOption {
+        public IPv6MulticastOption(IPAddress group);
+        public IPv6MulticastOption(IPAddress group, long ifindex);
+        public IPAddress Group { get; set; }
+        public long InterfaceIndex { get; set; }
+    }
+    public class LingerOption {
+        public LingerOption(bool enable, int seconds);
+        public bool Enabled { get; set; }
+        public int LingerTime { get; set; }
+    }
+    public class MulticastOption {
+        public MulticastOption(IPAddress group);
+        public MulticastOption(IPAddress group, int interfaceIndex);
+        public MulticastOption(IPAddress group, IPAddress mcint);
+        public IPAddress Group { get; set; }
+        public int InterfaceIndex { get; set; }
+        public IPAddress LocalAddress { get; set; }
+    }
+    public class NetworkStream : Stream {
+        public NetworkStream(Socket socket);
+        public NetworkStream(Socket socket, bool ownsSocket);
+        public override bool CanRead { get; }
+        public override bool CanSeek { get; }
+        public override bool CanTimeout { get; }
+        public override bool CanWrite { get; }
+        public virtual bool DataAvailable { get; }
+        public override long Length { get; }
+        public override long Position { get; set; }
+        public override int ReadTimeout { get; set; }
+        public override int WriteTimeout { get; set; }
+        protected override void Dispose(bool disposing);
+        ~NetworkStream();
+        public override void Flush();
+        public override Task FlushAsync(CancellationToken cancellationToken);
+        public override int Read(byte[] buffer, int offset, int size);
+        public override Task<int> ReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken);
+        public override long Seek(long offset, SeekOrigin origin);
+        public override void SetLength(long value);
+        public override void Write(byte[] buffer, int offset, int size);
+        public override Task WriteAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken);
+    }
+    public enum ProtocolType {
+        Ggp = 3,
+        Icmp = 1,
+        IcmpV6 = 58,
+        Idp = 22,
+        Igmp = 2,
+        IP = 0,
+        IPSecAuthenticationHeader = 51,
+        IPSecEncapsulatingSecurityPayload = 50,
+        IPv4 = 4,
+        IPv6 = 41,
+        IPv6DestinationOptions = 60,
+        IPv6FragmentHeader = 44,
+        IPv6HopByHopOptions = 0,
+        IPv6NoNextHeader = 59,
+        IPv6RoutingHeader = 43,
+        Ipx = 1000,
+        ND = 77,
+        Pup = 12,
+        Raw = 255,
+        Spx = 1256,
+        SpxII = 1257,
+        Tcp = 6,
+        Udp = 17,
+        Unknown = -1,
+        Unspecified = 0,
+    }
+    public enum SelectMode {
+        SelectError = 2,
+        SelectRead = 0,
+        SelectWrite = 1,
+    }
+    public class SendPacketsElement {
+        public SendPacketsElement(byte[] buffer);
+        public SendPacketsElement(byte[] buffer, int offset, int count);
+        public SendPacketsElement(byte[] buffer, int offset, int count, bool endOfPacket);
+        public SendPacketsElement(string filepath);
+        public SendPacketsElement(string filepath, int offset, int count);
+        public SendPacketsElement(string filepath, int offset, int count, bool endOfPacket);
+        public byte[] Buffer { get; }
+        public int Count { get; }
+        public bool EndOfPacket { get; }
+        public string FilePath { get; }
+        public int Offset { get; }
+    }
+    public class Socket : IDisposable {
+        public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType);
+        public Socket(SocketType socketType, ProtocolType protocolType);
+        public AddressFamily AddressFamily { get; }
+        public int Available { get; }
+        public bool Blocking { get; set; }
+        public bool Connected { get; }
+        public bool DontFragment { get; set; }
+        public bool DualMode { get; set; }
+        public bool EnableBroadcast { get; set; }
+        public bool ExclusiveAddressUse { get; set; }
+        public bool IsBound { get; }
+        public LingerOption LingerState { get; set; }
+        public EndPoint LocalEndPoint { get; }
+        public bool MulticastLoopback { get; set; }
+        public bool NoDelay { get; set; }
+        public static bool OSSupportsIPv4 { get; }
+        public static bool OSSupportsIPv6 { get; }
+        public ProtocolType ProtocolType { get; }
+        public int ReceiveBufferSize { get; set; }
+        public int ReceiveTimeout { get; set; }
+        public EndPoint RemoteEndPoint { get; }
+        public int SendBufferSize { get; set; }
+        public int SendTimeout { get; set; }
+        public SocketType SocketType { get; }
+        public short Ttl { get; set; }
+        public Socket Accept();
+        public bool AcceptAsync(SocketAsyncEventArgs e);
+        public void Bind(EndPoint localEP);
+        public static void CancelConnectAsync(SocketAsyncEventArgs e);
+        public void Connect(EndPoint remoteEP);
+        public void Connect(IPAddress address, int port);
+        public void Connect(IPAddress[] addresses, int port);
+        public void Connect(string host, int port);
+        public bool ConnectAsync(SocketAsyncEventArgs e);
+        public static bool ConnectAsync(SocketType socketType, ProtocolType protocolType, SocketAsyncEventArgs e);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        ~Socket();
+        public object GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName);
+        public void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue);
+        public byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength);
+        public int IOControl(int ioControlCode, byte[] optionInValue, byte[] optionOutValue);
+        public int IOControl(IOControlCode ioControlCode, byte[] optionInValue, byte[] optionOutValue);
+        public void Listen(int backlog);
+        public bool Poll(int microSeconds, SelectMode mode);
+        public int Receive(byte[] buffer);
+        public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);
+        public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode);
+        public int Receive(byte[] buffer, int size, SocketFlags socketFlags);
+        public int Receive(byte[] buffer, SocketFlags socketFlags);
+        public int Receive(IList<ArraySegment<byte>> buffers);
+        public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);
+        public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode);
+        public bool ReceiveAsync(SocketAsyncEventArgs e);
+        public int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP);
+        public int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP);
+        public int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP);
+        public int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP);
+        public bool ReceiveFromAsync(SocketAsyncEventArgs e);
+        public int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation);
+        public bool ReceiveMessageFromAsync(SocketAsyncEventArgs e);
+        public static void Select(IList checkRead, IList checkWrite, IList checkError, int microSeconds);
+        public int Send(byte[] buffer);
+        public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags);
+        public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode);
+        public int Send(byte[] buffer, int size, SocketFlags socketFlags);
+        public int Send(byte[] buffer, SocketFlags socketFlags);
+        public int Send(IList<ArraySegment<byte>> buffers);
+        public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);
+        public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode);
+        public bool SendAsync(SocketAsyncEventArgs e);
+        public bool SendPacketsAsync(SocketAsyncEventArgs e);
+        public int SendTo(byte[] buffer, EndPoint remoteEP);
+        public int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP);
+        public int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP);
+        public int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP);
+        public bool SendToAsync(SocketAsyncEventArgs e);
+        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue);
+        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue);
+        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue);
+        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue);
+        public void Shutdown(SocketShutdown how);
+    }
+    public class SocketAsyncEventArgs : EventArgs, IDisposable {
+        public SocketAsyncEventArgs();
+        public Socket AcceptSocket { get; set; }
+        public byte[] Buffer { get; }
+        public IList<ArraySegment<byte>> BufferList { get; set; }
+        public int BytesTransferred { get; }
+        public Exception ConnectByNameError { get; }
+        public Socket ConnectSocket { get; }
+        public int Count { get; }
+        public SocketAsyncOperation LastOperation { get; }
+        public int Offset { get; }
+        public IPPacketInformation ReceiveMessageFromPacketInfo { get; }
+        public EndPoint RemoteEndPoint { get; set; }
+        public SendPacketsElement[] SendPacketsElements { get; set; }
+        public int SendPacketsSendSize { get; set; }
+        public SocketError SocketError { get; set; }
+        public SocketFlags SocketFlags { get; set; }
+        public object UserToken { get; set; }
+        public void Dispose();
+        ~SocketAsyncEventArgs();
+        protected virtual void OnCompleted(SocketAsyncEventArgs e);
+        public void SetBuffer(byte[] buffer, int offset, int count);
+        public void SetBuffer(int offset, int count);
+        public event EventHandler<SocketAsyncEventArgs> Completed;
+    }
+    public enum SocketAsyncOperation {
+        Accept = 1,
+        Connect = 2,
+        Disconnect = 3,
+        None = 0,
+        Receive = 4,
+        ReceiveFrom = 5,
+        ReceiveMessageFrom = 6,
+        Send = 7,
+        SendPackets = 8,
+        SendTo = 9,
+    }
+    public enum SocketError {
+        AccessDenied = 10013,
+        AddressAlreadyInUse = 10048,
+        AddressFamilyNotSupported = 10047,
+        AddressNotAvailable = 10049,
+        AlreadyInProgress = 10037,
+        ConnectionAborted = 10053,
+        ConnectionRefused = 10061,
+        ConnectionReset = 10054,
+        DestinationAddressRequired = 10039,
+        Disconnecting = 10101,
+        Fault = 10014,
+        HostDown = 10064,
+        HostNotFound = 11001,
+        HostUnreachable = 10065,
+        InProgress = 10036,
+        Interrupted = 10004,
+        InvalidArgument = 10022,
+        IOPending = 997,
+        IsConnected = 10056,
+        MessageSize = 10040,
+        NetworkDown = 10050,
+        NetworkReset = 10052,
+        NetworkUnreachable = 10051,
+        NoBufferSpaceAvailable = 10055,
+        NoData = 11004,
+        NoRecovery = 11003,
+        NotConnected = 10057,
+        NotInitialized = 10093,
+        NotSocket = 10038,
+        OperationAborted = 995,
+        OperationNotSupported = 10045,
+        ProcessLimit = 10067,
+        ProtocolFamilyNotSupported = 10046,
+        ProtocolNotSupported = 10043,
+        ProtocolOption = 10042,
+        ProtocolType = 10041,
+        Shutdown = 10058,
+        SocketError = -1,
+        SocketNotSupported = 10044,
+        Success = 0,
+        SystemNotReady = 10091,
+        TimedOut = 10060,
+        TooManyOpenSockets = 10024,
+        TryAgain = 11002,
+        TypeNotFound = 10109,
+        VersionNotSupported = 10092,
+        WouldBlock = 10035,
+    }
+    public class SocketException : Exception {
+        public SocketException();
+        public SocketException(int errorCode);
+        public override string Message { get; }
+        public SocketError SocketErrorCode { get; }
+    }
+    public enum SocketFlags {
+        Broadcast = 1024,
+        ControlDataTruncated = 512,
+        DontRoute = 4,
+        Multicast = 2048,
+        None = 0,
+        OutOfBand = 1,
+        Partial = 32768,
+        Peek = 2,
+        Truncated = 256,
+    }
+    public enum SocketOptionLevel {
+        IP = 0,
+        IPv6 = 41,
+        Socket = 65535,
+        Tcp = 6,
+        Udp = 17,
+    }
+    public enum SocketOptionName {
+        AcceptConnection = 2,
+        AddMembership = 12,
+        AddSourceMembership = 15,
+        BlockSource = 17,
+        Broadcast = 32,
+        BsdUrgent = 2,
+        ChecksumCoverage = 20,
+        Debug = 1,
+        DontFragment = 14,
+        DontLinger = -129,
+        DontRoute = 16,
+        DropMembership = 13,
+        DropSourceMembership = 16,
+        Error = 4103,
+        ExclusiveAddressUse = -5,
+        Expedited = 2,
+        HeaderIncluded = 2,
+        HopLimit = 21,
+        IPOptions = 1,
+        IPProtectionLevel = 23,
+        IpTimeToLive = 4,
+        IPv6Only = 27,
+        KeepAlive = 8,
+        Linger = 128,
+        MaxConnections = 2147483647,
+        MulticastInterface = 9,
+        MulticastLoopback = 11,
+        MulticastTimeToLive = 10,
+        NoChecksum = 1,
+        NoDelay = 1,
+        OutOfBandInline = 256,
+        PacketInformation = 19,
+        ReceiveBuffer = 4098,
+        ReceiveLowWater = 4100,
+        ReceiveTimeout = 4102,
+        ReuseAddress = 4,
+        ReuseUnicastPort = 12295,
+        SendBuffer = 4097,
+        SendLowWater = 4099,
+        SendTimeout = 4101,
+        Type = 4104,
+        TypeOfService = 3,
+        UnblockSource = 18,
+        UpdateAcceptContext = 28683,
+        UpdateConnectContext = 28688,
+        UseLoopback = 64,
+    }
+    public struct SocketReceiveFromResult {
+        public int ReceivedBytes;
+        public EndPoint RemoteEndPoint;
+    }
+    public struct SocketReceiveMessageFromResult {
+        public IPPacketInformation PacketInformation;
+        public int ReceivedBytes;
+        public EndPoint RemoteEndPoint;
+        public SocketFlags SocketFlags;
+    }
+    public enum SocketShutdown {
+        Both = 2,
+        Receive = 0,
+        Send = 1,
+    }
+    public static class SocketTaskExtensions {
+        public static Task<Socket> AcceptAsync(this Socket socket);
+        public static Task<Socket> AcceptAsync(this Socket socket, Socket acceptSocket);
+        public static Task ConnectAsync(this Socket socket, EndPoint remoteEP);
+        public static Task ConnectAsync(this Socket socket, IPAddress address, int port);
+        public static Task ConnectAsync(this Socket socket, IPAddress[] addresses, int port);
+        public static Task ConnectAsync(this Socket socket, string host, int port);
+        public static Task<int> ReceiveAsync(this Socket socket, ArraySegment<byte> buffer, SocketFlags socketFlags);
+        public static Task<int> ReceiveAsync(this Socket socket, IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);
+        public static Task<SocketReceiveFromResult> ReceiveFromAsync(this Socket socket, ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint);
+        public static Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(this Socket socket, ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint);
+        public static Task<int> SendAsync(this Socket socket, ArraySegment<byte> buffer, SocketFlags socketFlags);
+        public static Task<int> SendAsync(this Socket socket, IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);
+        public static Task<int> SendToAsync(this Socket socket, ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP);
+    }
+    public enum SocketType {
+        Dgram = 2,
+        Raw = 3,
+        Rdm = 4,
+        Seqpacket = 5,
+        Stream = 1,
+        Unknown = -1,
+    }
+    public class TcpClient : IDisposable {
+        public TcpClient();
+        public TcpClient(AddressFamily family);
+        protected bool Active { get; set; }
+        public int Available { get; }
+        public Socket Client { get; set; }
+        public bool Connected { get; }
+        public bool ExclusiveAddressUse { get; set; }
+        public LingerOption LingerState { get; set; }
+        public bool NoDelay { get; set; }
+        public int ReceiveBufferSize { get; set; }
+        public int ReceiveTimeout { get; set; }
+        public int SendBufferSize { get; set; }
+        public int SendTimeout { get; set; }
+        public Task ConnectAsync(IPAddress address, int port);
+        public Task ConnectAsync(IPAddress[] addresses, int port);
+        public Task ConnectAsync(string host, int port);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        ~TcpClient();
+        public NetworkStream GetStream();
+    }
+    public class TcpListener {
+        public TcpListener(IPAddress localaddr, int port);
+        public TcpListener(IPEndPoint localEP);
+        protected bool Active { get; }
+        public bool ExclusiveAddressUse { get; set; }
+        public EndPoint LocalEndpoint { get; }
+        public Socket Server { get; }
+        public Task<Socket> AcceptSocketAsync();
+        public Task<TcpClient> AcceptTcpClientAsync();
+        public bool Pending();
+        public void Start();
+        public void Start(int backlog);
+        public void Stop();
+    }
+    public class UdpClient : IDisposable {
+        public UdpClient();
+        public UdpClient(AddressFamily family);
+        public UdpClient(int port);
+        public UdpClient(int port, AddressFamily family);
+        public UdpClient(IPEndPoint localEP);
+        protected bool Active { get; set; }
+        public int Available { get; }
+        public Socket Client { get; set; }
+        public bool DontFragment { get; set; }
+        public bool EnableBroadcast { get; set; }
+        public bool ExclusiveAddressUse { get; set; }
+        public bool MulticastLoopback { get; set; }
+        public short Ttl { get; set; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public void DropMulticastGroup(IPAddress multicastAddr);
+        public void DropMulticastGroup(IPAddress multicastAddr, int ifindex);
+        public void JoinMulticastGroup(int ifindex, IPAddress multicastAddr);
+        public void JoinMulticastGroup(IPAddress multicastAddr);
+        public void JoinMulticastGroup(IPAddress multicastAddr, int timeToLive);
+        public void JoinMulticastGroup(IPAddress multicastAddr, IPAddress localAddress);
+        public Task<UdpReceiveResult> ReceiveAsync();
+        public Task<int> SendAsync(byte[] datagram, int bytes, IPEndPoint endPoint);
+        public Task<int> SendAsync(byte[] datagram, int bytes, string hostname, int port);
+    }
+    public struct UdpReceiveResult : IEquatable<UdpReceiveResult> {
+        public UdpReceiveResult(byte[] buffer, IPEndPoint remoteEndPoint);
+        public byte[] Buffer { get; }
+        public IPEndPoint RemoteEndPoint { get; }
+        public override bool Equals(object obj);
+        public bool Equals(UdpReceiveResult other);
+        public override int GetHashCode();
+        public static bool operator ==(UdpReceiveResult left, UdpReceiveResult right);
+        public static bool operator !=(UdpReceiveResult left, UdpReceiveResult right);
+    }
+}
 namespace System.Reflection {
     public abstract class Assembly {
+        public virtual Type GetType(string name, bool throwOnError, bool ignoreCase);
     }
     public sealed class AssemblyName {
-        public string CultureName { get; }
+        public string CultureName { get; set; }
+        public ProcessorArchitecture ProcessorArchitecture { get; set; }
     }
     public abstract class ConstructorInfo : MethodBase {
-        public object Invoke(object[] parameters);
+        public virtual object Invoke(object[] parameters);
     }
     public class CustomAttributeData {
-        public Type AttributeType { get; }
+        public virtual Type AttributeType { get; }
     }
     public abstract class FieldInfo : MemberInfo {
-        public void SetValue(object obj, object value);
+        public virtual void SetValue(object obj, object value);
     }
     public abstract class MethodBase : MemberInfo {
-        public object Invoke(object obj, object[] parameters);
+        public virtual object Invoke(object obj, object[] parameters);
     }
     public abstract class Module {
+        public virtual Type GetType(string className, bool throwOnError, bool ignoreCase);
     }
+    public enum ProcessorArchitecture {
+        Amd64 = 4,
+        Arm = 5,
+        IA64 = 3,
+        MSIL = 1,
+        None = 0,
+        X86 = 2,
+    }
     public abstract class TypeInfo : MemberInfo, IReflectableType {
-        public bool IsPrimitive { get; }
+        public virtual bool IsPrimitive { get; }
-        public bool IsValueType { get; }
+        public virtual bool IsValueType { get; }
     }
 }
 namespace System.Runtime.CompilerServices {
+    public sealed class ConditionalWeakTable<TKey, TValue> where TKey : class where TValue : class {
+        public delegate TValue CreateValueCallback(TKey key); {
+            public CreateValueCallback(object @object, IntPtr method);
+            public virtual IAsyncResult BeginInvoke(TKey key, AsyncCallback callback, object @object);
+            public virtual TValue EndInvoke(IAsyncResult result);
+            public virtual TValue Invoke(TKey key);
+        }
+        public ConditionalWeakTable();
+        public void Add(TKey key, TValue value);
+        public TValue GetOrCreateValue(TKey key);
+        public TValue GetValue(TKey key, ConditionalWeakTable<TKey, TValue>.CreateValueCallback createValueCallback);
+        public bool Remove(TKey key);
+        public bool TryGetValue(TKey key, out TValue value);
+    }
+    public sealed class DisablePrivateReflectionAttribute : Attribute {
+        public DisablePrivateReflectionAttribute();
+    }
+    public static class FormattableStringFactory {
+        public static FormattableString Create(string format, params object[] arguments);
+    }
+    public static class IsConst
     public static class RuntimeHelpers {
+        public static void EnsureSufficientExecutionStack();
     }
 }
 namespace System.Runtime.Versioning {
+    public sealed class FrameworkName : IEquatable<FrameworkName> {
+        public FrameworkName(string frameworkName);
+        public FrameworkName(string identifier, Version version);
+        public FrameworkName(string identifier, Version version, string profile);
+        public string FullName { get; }
+        public string Identifier { get; }
+        public string Profile { get; }
+        public Version Version { get; }
+        public bool Equals(FrameworkName other);
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static bool operator ==(FrameworkName left, FrameworkName right);
+        public static bool operator !=(FrameworkName left, FrameworkName right);
+        public override string ToString();
+    }
 }
+namespace System.Security.Authentication {
+    public enum CipherAlgorithmType {
+        Aes = 26129,
+        Aes128 = 26126,
+        Aes192 = 26127,
+        Aes256 = 26128,
+        Des = 26113,
+        None = 0,
+        Null = 24576,
+        Rc2 = 26114,
+        Rc4 = 26625,
+        TripleDes = 26115,
+    }
+    public enum ExchangeAlgorithmType {
+        DiffieHellman = 43522,
+        None = 0,
+        RsaKeyX = 41984,
+        RsaSign = 9216,
+    }
+    public enum HashAlgorithmType {
+        Md5 = 32771,
+        None = 0,
+        Sha1 = 32772,
+    }
+    public enum SslProtocols {
+        None = 0,
+        Ssl2 = 12,
+        Ssl3 = 48,
+        Tls = 192,
+        Tls11 = 768,
+        Tls12 = 3072,
+    }
+}
+namespace System.Security.Authentication.ExtendedProtection {
+    public abstract class ChannelBinding : SafeHandle {
+        protected ChannelBinding();
+        protected ChannelBinding(bool ownsHandle);
+        public abstract int Size { get; }
+    }
+    public enum ChannelBindingKind {
+        Endpoint = 26,
+        Unique = 25,
+        Unknown = 0,
+    }
+}
+namespace System.Security.Cryptography {
+    public abstract class Aes : SymmetricAlgorithm {
+        protected Aes();
+        public override KeySizes[] LegalBlockSizes { get; }
+        public override KeySizes[] LegalKeySizes { get; }
+        public static Aes Create();
+    }
+    public class AsnEncodedData {
+        protected AsnEncodedData();
+        public AsnEncodedData(AsnEncodedData asnEncodedData);
+        public AsnEncodedData(byte[] rawData);
+        public AsnEncodedData(Oid oid, byte[] rawData);
+        public AsnEncodedData(string oid, byte[] rawData);
+        public Oid Oid { get; set; }
+        public byte[] RawData { get; set; }
+        public virtual void CopyFrom(AsnEncodedData asnEncodedData);
+        public virtual string Format(bool multiLine);
+    }
+    public sealed class AsnEncodedDataCollection : ICollection, IEnumerable {
+        public AsnEncodedDataCollection();
+        public AsnEncodedDataCollection(AsnEncodedData asnEncodedData);
+        public int Count { get; }
+        public AsnEncodedData this[int index] { get; }
+        public int Add(AsnEncodedData asnEncodedData);
+        public void CopyTo(AsnEncodedData[] array, int index);
+        public AsnEncodedDataEnumerator GetEnumerator();
+        public void Remove(AsnEncodedData asnEncodedData);
+    }
+    public sealed class AsnEncodedDataEnumerator : IEnumerator {
+        public AsnEncodedData Current { get; }
+        public bool MoveNext();
+        public void Reset();
+    }
+    public abstract class AsymmetricAlgorithm : IDisposable {
+        protected int KeySizeValue;
+        protected KeySizes[] LegalKeySizesValue;
+        protected AsymmetricAlgorithm();
+        public virtual int KeySize { get; set; }
+        public virtual KeySizes[] LegalKeySizes { get; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+    }
+    public enum CipherMode {
+        CBC = 1,
+        CTS = 5,
+        ECB = 2,
+    }
+    public class CryptographicException : Exception {
+        public CryptographicException();
+        public CryptographicException(int hr);
+        public CryptographicException(string message);
+        public CryptographicException(string message, Exception inner);
+        public CryptographicException(string format, string insert);
+    }
+    public class CryptoStream : Stream, IDisposable {
+        public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode);
+        public override bool CanRead { get; }
+        public override bool CanSeek { get; }
+        public override bool CanWrite { get; }
+        public bool HasFlushedFinalBlock { get; }
+        public override long Length { get; }
+        public override long Position { get; set; }
+        protected override void Dispose(bool disposing);
+        public override void Flush();
+        public override Task FlushAsync(CancellationToken cancellationToken);
+        public void FlushFinalBlock();
+        public override int Read(byte[] buffer, int offset, int count);
+        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
+        public override long Seek(long offset, SeekOrigin origin);
+        public override void SetLength(long value);
+        public override void Write(byte[] buffer, int offset, int count);
+        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
+    }
+    public enum CryptoStreamMode {
+        Read = 0,
+        Write = 1,
+    }
+    public abstract class DeriveBytes : IDisposable {
+        protected DeriveBytes();
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public abstract byte[] GetBytes(int cb);
+        public abstract void Reset();
+    }
+    public abstract class HashAlgorithm : IDisposable {
+        protected HashAlgorithm();
+        public virtual int HashSize { get; }
+        public byte[] ComputeHash(byte[] buffer);
+        public byte[] ComputeHash(byte[] buffer, int offset, int count);
+        public byte[] ComputeHash(Stream inputStream);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        protected abstract void HashCore(byte[] array, int ibStart, int cbSize);
+        protected abstract byte[] HashFinal();
+        public abstract void Initialize();
+    }
+    public struct HashAlgorithmName : IEquatable<HashAlgorithmName> {
+        public HashAlgorithmName(string name);
+        public static HashAlgorithmName MD5 { get; }
+        public string Name { get; }
+        public static HashAlgorithmName SHA1 { get; }
+        public static HashAlgorithmName SHA256 { get; }
+        public static HashAlgorithmName SHA384 { get; }
+        public static HashAlgorithmName SHA512 { get; }
+        public bool Equals(HashAlgorithmName other);
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static bool operator ==(HashAlgorithmName left, HashAlgorithmName right);
+        public static bool operator !=(HashAlgorithmName left, HashAlgorithmName right);
+        public override string ToString();
+    }
+    public abstract class HMAC : KeyedHashAlgorithm {
+        protected HMAC();
+        public string HashName { get; set; }
+        public override byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+        protected override void HashCore(byte[] rgb, int ib, int cb);
+        protected override byte[] HashFinal();
+        public override void Initialize();
+    }
+    public class HMACMD5 : HMAC {
+        public HMACMD5();
+        public HMACMD5(byte[] key);
+        public override int HashSize { get; }
+        public override byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+        protected override void HashCore(byte[] rgb, int ib, int cb);
+        protected override byte[] HashFinal();
+        public override void Initialize();
+    }
+    public class HMACSHA1 : HMAC {
+        public HMACSHA1();
+        public HMACSHA1(byte[] key);
+        public override int HashSize { get; }
+        public override byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+        protected override void HashCore(byte[] rgb, int ib, int cb);
+        protected override byte[] HashFinal();
+        public override void Initialize();
+    }
+    public class HMACSHA256 : HMAC {
+        public HMACSHA256();
+        public HMACSHA256(byte[] key);
+        public override int HashSize { get; }
+        public override byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+        protected override void HashCore(byte[] rgb, int ib, int cb);
+        protected override byte[] HashFinal();
+        public override void Initialize();
+    }
+    public class HMACSHA384 : HMAC {
+        public HMACSHA384();
+        public HMACSHA384(byte[] key);
+        public override int HashSize { get; }
+        public override byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+        protected override void HashCore(byte[] rgb, int ib, int cb);
+        protected override byte[] HashFinal();
+        public override void Initialize();
+    }
+    public class HMACSHA512 : HMAC {
+        public HMACSHA512();
+        public HMACSHA512(byte[] key);
+        public override int HashSize { get; }
+        public override byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+        protected override void HashCore(byte[] rgb, int ib, int cb);
+        protected override byte[] HashFinal();
+        public override void Initialize();
+    }
+    public interface ICryptoTransform : IDisposable {
+        bool CanReuseTransform { get; }
+        bool CanTransformMultipleBlocks { get; }
+        int InputBlockSize { get; }
+        int OutputBlockSize { get; }
+        int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);
+        byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount);
+    }
+    public sealed class IncrementalHash : IDisposable {
+        public HashAlgorithmName AlgorithmName { get; }
+        public void AppendData(byte[] data);
+        public void AppendData(byte[] data, int offset, int count);
+        public static IncrementalHash CreateHash(HashAlgorithmName hashAlgorithm);
+        public static IncrementalHash CreateHMAC(HashAlgorithmName hashAlgorithm, byte[] key);
+        public void Dispose();
+        public byte[] GetHashAndReset();
+    }
+    public abstract class KeyedHashAlgorithm : HashAlgorithm {
+        protected KeyedHashAlgorithm();
+        public virtual byte[] Key { get; set; }
+        protected override void Dispose(bool disposing);
+    }
+    public sealed class KeySizes {
+        public KeySizes(int minSize, int maxSize, int skipSize);
+        public int MaxSize { get; }
+        public int MinSize { get; }
+        public int SkipSize { get; }
+    }
+    public abstract class MD5 : HashAlgorithm {
+        protected MD5();
+        public static MD5 Create();
+    }
+    public sealed class Oid {
+        public Oid(Oid oid);
+        public Oid(string oid);
+        public Oid(string value, string friendlyName);
+        public string FriendlyName { get; set; }
+        public string Value { get; set; }
+        public static Oid FromFriendlyName(string friendlyName, OidGroup group);
+        public static Oid FromOidValue(string oidValue, OidGroup group);
+    }
+    public sealed class OidCollection : ICollection, IEnumerable {
+        public OidCollection();
+        public int Count { get; }
+        public Oid this[int index] { get; }
+        public Oid this[string oid] { get; }
+        public int Add(Oid oid);
+        public void CopyTo(Oid[] array, int index);
+        public OidEnumerator GetEnumerator();
+    }
+    public sealed class OidEnumerator : IEnumerator {
+        public Oid Current { get; }
+        public bool MoveNext();
+        public void Reset();
+    }
+    public enum OidGroup {
+        All = 0,
+        Attribute = 5,
+        EncryptionAlgorithm = 2,
+        EnhancedKeyUsage = 7,
+        ExtensionOrAttribute = 6,
+        HashAlgorithm = 1,
+        KeyDerivationFunction = 10,
+        Policy = 8,
+        PublicKeyAlgorithm = 3,
+        SignatureAlgorithm = 4,
+        Template = 9,
+    }
+    public enum PaddingMode {
+        None = 1,
+        PKCS7 = 2,
+        Zeros = 3,
+    }
+    public abstract class RandomNumberGenerator : IDisposable {
+        protected RandomNumberGenerator();
+        public static RandomNumberGenerator Create();
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public abstract void GetBytes(byte[] data);
+    }
+    public class Rfc2898DeriveBytes : DeriveBytes {
+        public Rfc2898DeriveBytes(byte[] password, byte[] salt, int iterations);
+        public Rfc2898DeriveBytes(string password, byte[] salt);
+        public Rfc2898DeriveBytes(string password, byte[] salt, int iterations);
+        public Rfc2898DeriveBytes(string password, int saltSize);
+        public Rfc2898DeriveBytes(string password, int saltSize, int iterations);
+        public int IterationCount { get; set; }
+        public byte[] Salt { get; set; }
+        protected override void Dispose(bool disposing);
+        public override byte[] GetBytes(int cb);
+        public override void Reset();
+    }
+    public abstract class RSA : AsymmetricAlgorithm {
+        protected RSA();
+        public static RSA Create();
+        public abstract byte[] Decrypt(byte[] data, RSAEncryptionPadding padding);
+        public abstract byte[] Encrypt(byte[] data, RSAEncryptionPadding padding);
+        public abstract RSAParameters ExportParameters(bool includePrivateParameters);
+        protected abstract byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm);
+        protected abstract byte[] HashData(Stream data, HashAlgorithmName hashAlgorithm);
+        public abstract void ImportParameters(RSAParameters parameters);
+        public byte[] SignData(byte[] data, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public virtual byte[] SignData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public virtual byte[] SignData(Stream data, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public abstract byte[] SignHash(byte[] hash, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public bool VerifyData(byte[] data, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public virtual bool VerifyData(byte[] data, int offset, int count, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public bool VerifyData(Stream data, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+        public abstract bool VerifyHash(byte[] hash, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding);
+    }
+    public sealed class RSAEncryptionPadding : IEquatable<RSAEncryptionPadding> {
+        public RSAEncryptionPaddingMode Mode { get; }
+        public HashAlgorithmName OaepHashAlgorithm { get; }
+        public static RSAEncryptionPadding OaepSHA1 { get; }
+        public static RSAEncryptionPadding OaepSHA256 { get; }
+        public static RSAEncryptionPadding OaepSHA384 { get; }
+        public static RSAEncryptionPadding OaepSHA512 { get; }
+        public static RSAEncryptionPadding Pkcs1 { get; }
+        public static RSAEncryptionPadding CreateOaep(HashAlgorithmName hashAlgorithm);
+        public override bool Equals(object obj);
+        public bool Equals(RSAEncryptionPadding other);
+        public override int GetHashCode();
+        public static bool operator ==(RSAEncryptionPadding left, RSAEncryptionPadding right);
+        public static bool operator !=(RSAEncryptionPadding left, RSAEncryptionPadding right);
+        public override string ToString();
+    }
+    public enum RSAEncryptionPaddingMode {
+        Oaep = 1,
+        Pkcs1 = 0,
+    }
+    public struct RSAParameters {
+        public byte[] D;
+        public byte[] DP;
+        public byte[] DQ;
+        public byte[] Exponent;
+        public byte[] InverseQ;
+        public byte[] Modulus;
+        public byte[] P;
+        public byte[] Q;
+    }
+    public sealed class RSASignaturePadding : IEquatable<RSASignaturePadding> {
+        public RSASignaturePaddingMode Mode { get; }
+        public static RSASignaturePadding Pkcs1 { get; }
+        public static RSASignaturePadding Pss { get; }
+        public override bool Equals(object obj);
+        public bool Equals(RSASignaturePadding other);
+        public override int GetHashCode();
+        public static bool operator ==(RSASignaturePadding left, RSASignaturePadding right);
+        public static bool operator !=(RSASignaturePadding left, RSASignaturePadding right);
+        public override string ToString();
+    }
+    public enum RSASignaturePaddingMode {
+        Pkcs1 = 0,
+        Pss = 1,
+    }
+    public abstract class SHA1 : HashAlgorithm {
+        protected SHA1();
+        public static SHA1 Create();
+    }
+    public abstract class SHA256 : HashAlgorithm {
+        protected SHA256();
+        public static SHA256 Create();
+    }
+    public abstract class SHA384 : HashAlgorithm {
+        protected SHA384();
+        public static SHA384 Create();
+    }
+    public abstract class SHA512 : HashAlgorithm {
+        protected SHA512();
+        public static SHA512 Create();
+    }
+    public abstract class SymmetricAlgorithm : IDisposable {
+        protected int BlockSizeValue;
+        protected byte[] IVValue;
+        protected int KeySizeValue;
+        protected byte[] KeyValue;
+        protected KeySizes[] LegalBlockSizesValue;
+        protected KeySizes[] LegalKeySizesValue;
+        protected CipherMode ModeValue;
+        protected PaddingMode PaddingValue;
+        protected SymmetricAlgorithm();
+        public virtual int BlockSize { get; set; }
+        public virtual byte[] IV { get; set; }
+        public virtual byte[] Key { get; set; }
+        public virtual int KeySize { get; set; }
+        public virtual KeySizes[] LegalBlockSizes { get; }
+        public virtual KeySizes[] LegalKeySizes { get; }
+        public virtual CipherMode Mode { get; set; }
+        public virtual PaddingMode Padding { get; set; }
+        public virtual ICryptoTransform CreateDecryptor();
+        public abstract ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV);
+        public virtual ICryptoTransform CreateEncryptor();
+        public abstract ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public abstract void GenerateIV();
+        public abstract void GenerateKey();
+    }
+    public abstract class TripleDES : SymmetricAlgorithm {
+        protected TripleDES();
+        public override byte[] Key { get; set; }
+        public override KeySizes[] LegalBlockSizes { get; }
+        public override KeySizes[] LegalKeySizes { get; }
+        public static TripleDES Create();
+        public static bool IsWeakKey(byte[] rgbKey);
+    }
+}
+namespace System.Security.Cryptography.X509Certificates {
+    public enum OpenFlags {
+        IncludeArchived = 8,
+        MaxAllowed = 2,
+        OpenExistingOnly = 4,
+        ReadOnly = 0,
+        ReadWrite = 1,
+    }
+    public sealed class PublicKey {
+        public PublicKey(Oid oid, AsnEncodedData parameters, AsnEncodedData keyValue);
+        public AsnEncodedData EncodedKeyValue { get; }
+        public AsnEncodedData EncodedParameters { get; }
+        public Oid Oid { get; }
+    }
+    public static class RSACertificateExtensions {
+        public static RSA GetRSAPrivateKey(this X509Certificate2 certificate);
+        public static RSA GetRSAPublicKey(this X509Certificate2 certificate);
+    }
+    public enum StoreLocation {
+        CurrentUser = 1,
+        LocalMachine = 2,
+    }
+    public enum StoreName {
+        AddressBook = 1,
+        AuthRoot = 2,
+        CertificateAuthority = 3,
+        Disallowed = 4,
+        My = 5,
+        Root = 6,
+        TrustedPeople = 7,
+        TrustedPublisher = 8,
+    }
+    public sealed class X500DistinguishedName : AsnEncodedData {
+        public X500DistinguishedName(AsnEncodedData encodedDistinguishedName);
+        public X500DistinguishedName(byte[] encodedDistinguishedName);
+        public X500DistinguishedName(string distinguishedName);
+        public X500DistinguishedName(string distinguishedName, X500DistinguishedNameFlags flag);
+        public X500DistinguishedName(X500DistinguishedName distinguishedName);
+        public string Name { get; }
+        public string Decode(X500DistinguishedNameFlags flag);
+        public override string Format(bool multiLine);
+    }
+    public enum X500DistinguishedNameFlags {
+        DoNotUsePlusSign = 32,
+        DoNotUseQuotes = 64,
+        ForceUTF8Encoding = 16384,
+        None = 0,
+        Reversed = 1,
+        UseCommas = 128,
+        UseNewLines = 256,
+        UseSemicolons = 16,
+        UseT61Encoding = 8192,
+        UseUTF8Encoding = 4096,
+    }
+    public sealed class X509BasicConstraintsExtension : X509Extension {
+        public X509BasicConstraintsExtension();
+        public X509BasicConstraintsExtension(AsnEncodedData encodedBasicConstraints, bool critical);
+        public X509BasicConstraintsExtension(bool certificateAuthority, bool hasPathLengthConstraint, int pathLengthConstraint, bool critical);
+        public bool CertificateAuthority { get; }
+        public bool HasPathLengthConstraint { get; }
+        public int PathLengthConstraint { get; }
+        public override void CopyFrom(AsnEncodedData asnEncodedData);
+    }
+    public class X509Certificate : IDisposable {
+        public X509Certificate();
+        public X509Certificate(byte[] data);
+        public X509Certificate(byte[] rawData, string password);
+        public X509Certificate(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags);
+        public X509Certificate(IntPtr handle);
+        public X509Certificate(string fileName);
+        public X509Certificate(string fileName, string password);
+        public X509Certificate(string fileName, string password, X509KeyStorageFlags keyStorageFlags);
+        public IntPtr Handle { get; }
+        public string Issuer { get; }
+        public string Subject { get; }
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+        public override bool Equals(object obj);
+        public virtual bool Equals(X509Certificate other);
+        public virtual byte[] Export(X509ContentType contentType);
+        public virtual byte[] Export(X509ContentType contentType, string password);
+        public virtual byte[] GetCertHash();
+        public virtual string GetFormat();
+        public override int GetHashCode();
+        public virtual string GetKeyAlgorithm();
+        public virtual byte[] GetKeyAlgorithmParameters();
+        public virtual string GetKeyAlgorithmParametersString();
+        public virtual byte[] GetPublicKey();
+        public virtual byte[] GetSerialNumber();
+        public override string ToString();
+        public virtual string ToString(bool fVerbose);
+    }
+    public class X509Certificate2 : X509Certificate {
+        public X509Certificate2();
+        public X509Certificate2(byte[] rawData);
+        public X509Certificate2(byte[] rawData, string password);
+        public X509Certificate2(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags);
+        public X509Certificate2(IntPtr handle);
+        public X509Certificate2(string fileName);
+        public X509Certificate2(string fileName, string password);
+        public X509Certificate2(string fileName, string password, X509KeyStorageFlags keyStorageFlags);
+        public bool Archived { get; set; }
+        public X509ExtensionCollection Extensions { get; }
+        public string FriendlyName { get; set; }
+        public bool HasPrivateKey { get; }
+        public X500DistinguishedName IssuerName { get; }
+        public DateTime NotAfter { get; }
+        public DateTime NotBefore { get; }
+        public PublicKey PublicKey { get; }
+        public byte[] RawData { get; }
+        public string SerialNumber { get; }
+        public Oid SignatureAlgorithm { get; }
+        public X500DistinguishedName SubjectName { get; }
+        public string Thumbprint { get; }
+        public int Version { get; }
+        public static X509ContentType GetCertContentType(byte[] rawData);
+        public static X509ContentType GetCertContentType(string fileName);
+        public string GetNameInfo(X509NameType nameType, bool forIssuer);
+        public override string ToString();
+        public override string ToString(bool verbose);
+    }
+    public class X509Certificate2Collection : X509CertificateCollection {
+        public X509Certificate2Collection();
+        public X509Certificate2Collection(X509Certificate2 certificate);
+        public X509Certificate2Collection(X509Certificate2Collection certificates);
+        public X509Certificate2Collection(X509Certificate2[] certificates);
+        public new X509Certificate2 this[int index] { get; set; }
+        public int Add(X509Certificate2 certificate);
+        public void AddRange(X509Certificate2Collection certificates);
+        public void AddRange(X509Certificate2[] certificates);
+        public bool Contains(X509Certificate2 certificate);
+        public byte[] Export(X509ContentType contentType);
+        public byte[] Export(X509ContentType contentType, string password);
+        public X509Certificate2Collection Find(X509FindType findType, object findValue, bool validOnly);
+        public new X509Certificate2Enumerator GetEnumerator();
+        public void Import(byte[] rawData);
+        public void Import(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags);
+        public void Import(string fileName);
+        public void Import(string fileName, string password, X509KeyStorageFlags keyStorageFlags);
+        public void Insert(int index, X509Certificate2 certificate);
+        public void Remove(X509Certificate2 certificate);
+        public void RemoveRange(X509Certificate2Collection certificates);
+        public void RemoveRange(X509Certificate2[] certificates);
+    }
+    public sealed class X509Certificate2Enumerator : IEnumerator {
+        public X509Certificate2 Current { get; }
+        public bool MoveNext();
+        public void Reset();
+    }
+    public class X509CertificateCollection : ICollection, IEnumerable, IList {
+        public class X509CertificateEnumerator : IEnumerator {
+            public X509CertificateEnumerator(X509CertificateCollection mappings);
+            public X509Certificate Current { get; }
+            public bool MoveNext();
+            public void Reset();
+        }
+        public X509CertificateCollection();
+        public X509CertificateCollection(X509CertificateCollection value);
+        public X509CertificateCollection(X509Certificate[] value);
+        public int Count { get; }
+        public X509Certificate this[int index] { get; set; }
+        public int Add(X509Certificate value);
+        public void AddRange(X509CertificateCollection value);
+        public void AddRange(X509Certificate[] value);
+        public void Clear();
+        public bool Contains(X509Certificate value);
+        public void CopyTo(X509Certificate[] array, int index);
+        public X509CertificateCollection.X509CertificateEnumerator GetEnumerator();
+        public override int GetHashCode();
+        public int IndexOf(X509Certificate value);
+        public void Insert(int index, X509Certificate value);
+        public void Remove(X509Certificate value);
+        public void RemoveAt(int index);
+    }
+    public class X509Chain : IDisposable {
+        public X509Chain();
+        public X509ChainElementCollection ChainElements { get; }
+        public X509ChainPolicy ChainPolicy { get; set; }
+        public X509ChainStatus[] ChainStatus { get; }
+        public SafeX509ChainHandle SafeHandle { get; }
+        public bool Build(X509Certificate2 certificate);
+        public void Dispose();
+        protected virtual void Dispose(bool disposing);
+    }
+    public class X509ChainElement {
+        public X509Certificate2 Certificate { get; }
+        public X509ChainStatus[] ChainElementStatus { get; }
+        public string Information { get; }
+    }
+    public sealed class X509ChainElementCollection : ICollection, IEnumerable {
+        public int Count { get; }
+        public X509ChainElement this[int index] { get; }
+        public void CopyTo(X509ChainElement[] array, int index);
+        public X509ChainElementEnumerator GetEnumerator();
+    }
+    public sealed class X509ChainElementEnumerator : IEnumerator {
+        public X509ChainElement Current { get; }
+        public bool MoveNext();
+        public void Reset();
+    }
+    public sealed class X509ChainPolicy {
+        public X509ChainPolicy();
+        public OidCollection ApplicationPolicy { get; }
+        public OidCollection CertificatePolicy { get; }
+        public X509Certificate2Collection ExtraStore { get; }
+        public X509RevocationFlag RevocationFlag { get; set; }
+        public X509RevocationMode RevocationMode { get; set; }
+        public TimeSpan UrlRetrievalTimeout { get; set; }
+        public X509VerificationFlags VerificationFlags { get; set; }
+        public DateTime VerificationTime { get; set; }
+        public void Reset();
+    }
+    public struct X509ChainStatus {
+        public X509ChainStatusFlags Status { get; set; }
+        public string StatusInformation { get; set; }
+    }
+    public enum X509ChainStatusFlags {
+        CtlNotSignatureValid = 262144,
+        CtlNotTimeValid = 131072,
+        CtlNotValidForUsage = 524288,
+        Cyclic = 128,
+        HasExcludedNameConstraint = 32768,
+        HasNotDefinedNameConstraint = 8192,
+        HasNotPermittedNameConstraint = 16384,
+        HasNotSupportedNameConstraint = 4096,
+        InvalidBasicConstraints = 1024,
+        InvalidExtension = 256,
+        InvalidNameConstraints = 2048,
+        InvalidPolicyConstraints = 512,
+        NoError = 0,
+        NoIssuanceChainPolicy = 33554432,
+        NotSignatureValid = 8,
+        NotTimeNested = 2,
+        NotTimeValid = 1,
+        NotValidForUsage = 16,
+        OfflineRevocation = 16777216,
+        PartialChain = 65536,
+        RevocationStatusUnknown = 64,
+        Revoked = 4,
+        UntrustedRoot = 32,
+    }
+    public enum X509ContentType {
+        Authenticode = 6,
+        Cert = 1,
+        Pfx = 3,
+        Pkcs12 = 3,
+        Pkcs7 = 5,
+        SerializedCert = 2,
+        SerializedStore = 4,
+        Unknown = 0,
+    }
+    public sealed class X509EnhancedKeyUsageExtension : X509Extension {
+        public X509EnhancedKeyUsageExtension();
+        public X509EnhancedKeyUsageExtension(AsnEncodedData encodedEnhancedKeyUsages, bool critical);
+        public X509EnhancedKeyUsageExtension(OidCollection enhancedKeyUsages, bool critical);
+        public OidCollection EnhancedKeyUsages { get; }
+        public override void CopyFrom(AsnEncodedData asnEncodedData);
+    }
+    public class X509Extension : AsnEncodedData {
+        protected X509Extension();
+        public X509Extension(AsnEncodedData encodedExtension, bool critical);
+        public X509Extension(Oid oid, byte[] rawData, bool critical);
+        public X509Extension(string oid, byte[] rawData, bool critical);
+        public bool Critical { get; set; }
+        public override void CopyFrom(AsnEncodedData asnEncodedData);
+    }
+    public sealed class X509ExtensionCollection : ICollection, IEnumerable {
+        public X509ExtensionCollection();
+        public int Count { get; }
+        public X509Extension this[int index] { get; }
+        public X509Extension this[string oid] { get; }
+        public int Add(X509Extension extension);
+        public void CopyTo(X509Extension[] array, int index);
+        public X509ExtensionEnumerator GetEnumerator();
+    }
+    public sealed class X509ExtensionEnumerator : IEnumerator {
+        public X509Extension Current { get; }
+        public bool MoveNext();
+        public void Reset();
+    }
+    public enum X509FindType {
+        FindByApplicationPolicy = 10,
+        FindByCertificatePolicy = 11,
+        FindByExtension = 12,
+        FindByIssuerDistinguishedName = 4,
+        FindByIssuerName = 3,
+        FindByKeyUsage = 13,
+        FindBySerialNumber = 5,
+        FindBySubjectDistinguishedName = 2,
+        FindBySubjectKeyIdentifier = 14,
+        FindBySubjectName = 1,
+        FindByTemplateName = 9,
+        FindByThumbprint = 0,
+        FindByTimeExpired = 8,
+        FindByTimeNotYetValid = 7,
+        FindByTimeValid = 6,
+    }
+    public enum X509KeyStorageFlags {
+        DefaultKeySet = 0,
+        Exportable = 4,
+        MachineKeySet = 2,
+        PersistKeySet = 16,
+        UserKeySet = 1,
+        UserProtected = 8,
+    }
+    public sealed class X509KeyUsageExtension : X509Extension {
+        public X509KeyUsageExtension();
+        public X509KeyUsageExtension(AsnEncodedData encodedKeyUsage, bool critical);
+        public X509KeyUsageExtension(X509KeyUsageFlags keyUsages, bool critical);
+        public X509KeyUsageFlags KeyUsages { get; }
+        public override void CopyFrom(AsnEncodedData asnEncodedData);
+    }
+    public enum X509KeyUsageFlags {
+        CrlSign = 2,
+        DataEncipherment = 16,
+        DecipherOnly = 32768,
+        DigitalSignature = 128,
+        EncipherOnly = 1,
+        KeyAgreement = 8,
+        KeyCertSign = 4,
+        KeyEncipherment = 32,
+        None = 0,
+        NonRepudiation = 64,
+    }
+    public enum X509NameType {
+        DnsFromAlternativeName = 4,
+        DnsName = 3,
+        EmailName = 1,
+        SimpleName = 0,
+        UpnName = 2,
+        UrlName = 5,
+    }
+    public enum X509RevocationFlag {
+        EndCertificateOnly = 0,
+        EntireChain = 1,
+        ExcludeRoot = 2,
+    }
+    public enum X509RevocationMode {
+        NoCheck = 0,
+        Offline = 2,
+        Online = 1,
+    }
+    public sealed class X509Store : IDisposable {
+        public X509Store();
+        public X509Store(StoreName storeName, StoreLocation storeLocation);
+        public X509Store(string storeName, StoreLocation storeLocation);
+        public X509Certificate2Collection Certificates { get; }
+        public StoreLocation Location { get; }
+        public string Name { get; }
+        public void Add(X509Certificate2 certificate);
+        public void Dispose();
+        public void Open(OpenFlags flags);
+        public void Remove(X509Certificate2 certificate);
+    }
+    public sealed class X509SubjectKeyIdentifierExtension : X509Extension {
+        public X509SubjectKeyIdentifierExtension();
+        public X509SubjectKeyIdentifierExtension(AsnEncodedData encodedSubjectKeyIdentifier, bool critical);
+        public X509SubjectKeyIdentifierExtension(byte[] subjectKeyIdentifier, bool critical);
+        public X509SubjectKeyIdentifierExtension(PublicKey key, bool critical);
+        public X509SubjectKeyIdentifierExtension(PublicKey key, X509SubjectKeyIdentifierHashAlgorithm algorithm, bool critical);
+        public X509SubjectKeyIdentifierExtension(string subjectKeyIdentifier, bool critical);
+        public string SubjectKeyIdentifier { get; }
+        public override void CopyFrom(AsnEncodedData asnEncodedData);
+    }
+    public enum X509SubjectKeyIdentifierHashAlgorithm {
+        CapiSha1 = 2,
+        Sha1 = 0,
+        ShortSha1 = 1,
+    }
+    public enum X509VerificationFlags {
+        AllFlags = 4095,
+        AllowUnknownCertificateAuthority = 16,
+        IgnoreCertificateAuthorityRevocationUnknown = 1024,
+        IgnoreCtlNotTimeValid = 2,
+        IgnoreCtlSignerRevocationUnknown = 512,
+        IgnoreEndRevocationUnknown = 256,
+        IgnoreInvalidBasicConstraints = 8,
+        IgnoreInvalidName = 64,
+        IgnoreInvalidPolicy = 128,
+        IgnoreNotTimeNested = 4,
+        IgnoreNotTimeValid = 1,
+        IgnoreRootRevocationUnknown = 2048,
+        IgnoreWrongUsage = 32,
+        NoFlag = 0,
+    }
+}
 namespace System.Text {
+    public class ASCIIEncoding : Encoding {
+        public ASCIIEncoding();
+        public override bool IsSingleByte { get; }
+        public unsafe override int GetByteCount(char* chars, int count);
+        public override int GetByteCount(char[] chars, int index, int count);
+        public override int GetByteCount(string chars);
+        public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount);
+        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
+        public override int GetBytes(string chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
+        public unsafe override int GetCharCount(byte* bytes, int count);
+        public override int GetCharCount(byte[] bytes, int index, int count);
+        public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount);
+        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
+        public override Decoder GetDecoder();
+        public override Encoder GetEncoder();
+        public override int GetMaxByteCount(int charCount);
+        public override int GetMaxCharCount(int byteCount);
+        public override string GetString(byte[] bytes, int byteIndex, int byteCount);
+    }
     public abstract class Decoder {
+        public DecoderFallback Fallback { get; set; }
+        public DecoderFallbackBuffer FallbackBuffer { get; }
     }
+    public sealed class DecoderExceptionFallback : DecoderFallback {
+        public DecoderExceptionFallback();
+        public override int MaxCharCount { get; }
+        public override DecoderFallbackBuffer CreateFallbackBuffer();
+        public override bool Equals(object value);
+        public override int GetHashCode();
+    }
+    public abstract class DecoderFallback {
+        protected DecoderFallback();
+        public static DecoderFallback ExceptionFallback { get; }
+        public abstract int MaxCharCount { get; }
+        public static DecoderFallback ReplacementFallback { get; }
+        public abstract DecoderFallbackBuffer CreateFallbackBuffer();
+    }
+    public abstract class DecoderFallbackBuffer {
+        protected DecoderFallbackBuffer();
+        public abstract int Remaining { get; }
+        public abstract bool Fallback(byte[] bytesUnknown, int index);
+        public abstract char GetNextChar();
+        public abstract bool MovePrevious();
+        public virtual void Reset();
+    }
+    public sealed class DecoderReplacementFallback : DecoderFallback {
+        public DecoderReplacementFallback();
+        public DecoderReplacementFallback(string replacement);
+        public string DefaultString { get; }
+        public override int MaxCharCount { get; }
+        public override DecoderFallbackBuffer CreateFallbackBuffer();
+        public override bool Equals(object value);
+        public override int GetHashCode();
+    }
     public abstract class Encoder {
+        public EncoderFallback Fallback { get; set; }
+        public EncoderFallbackBuffer FallbackBuffer { get; }
+        public virtual void Reset();
     }
+    public sealed class EncoderExceptionFallback : EncoderFallback {
+        public EncoderExceptionFallback();
+        public override int MaxCharCount { get; }
+        public override EncoderFallbackBuffer CreateFallbackBuffer();
+        public override bool Equals(object value);
+        public override int GetHashCode();
+    }
+    public abstract class EncoderFallback {
+        protected EncoderFallback();
+        public static EncoderFallback ExceptionFallback { get; }
+        public abstract int MaxCharCount { get; }
+        public static EncoderFallback ReplacementFallback { get; }
+        public abstract EncoderFallbackBuffer CreateFallbackBuffer();
+    }
+    public abstract class EncoderFallbackBuffer {
+        protected EncoderFallbackBuffer();
+        public abstract int Remaining { get; }
+        public abstract bool Fallback(char charUnknownHigh, char charUnknownLow, int index);
+        public abstract bool Fallback(char charUnknown, int index);
+        public abstract char GetNextChar();
+        public abstract bool MovePrevious();
+        public virtual void Reset();
+    }
     public sealed class EncoderFallbackException : ArgumentException {
+        public bool IsUnknownSurrogate();
     }
+    public sealed class EncoderReplacementFallback : EncoderFallback {
+        public EncoderReplacementFallback();
+        public EncoderReplacementFallback(string replacement);
+        public string DefaultString { get; }
+        public override int MaxCharCount { get; }
+        public override EncoderFallbackBuffer CreateFallbackBuffer();
+        public override bool Equals(object value);
+        public override int GetHashCode();
+    }
     public abstract class Encoding {
+        protected Encoding(int codePage);
+        protected Encoding(int codePage, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
+        public static Encoding ASCII { get; }
+        public virtual int CodePage { get; }
+        public DecoderFallback DecoderFallback { get; }
+        public EncoderFallback EncoderFallback { get; }
+        public virtual string EncodingName { get; }
+        public virtual bool IsSingleByte { get; }
+        public static Encoding UTF32 { get; }
+        public static Encoding UTF7 { get; }
+        public virtual object Clone();
+        public unsafe virtual int GetByteCount(char* chars, int count);
+        public unsafe virtual int GetBytes(char* chars, int charCount, byte* bytes, int byteCount);
+        public unsafe virtual int GetCharCount(byte* bytes, int count);
+        public unsafe virtual int GetChars(byte* bytes, int byteCount, char* chars, int charCount);
+        public static Encoding GetEncoding(int codepage);
+        public static Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
+        public static Encoding GetEncoding(string name, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
+        public unsafe string GetString(byte* bytes, int byteCount);
+        public virtual string GetString(byte[] bytes);
+        public static void RegisterProvider(EncodingProvider provider);
     }
+    public abstract class EncodingProvider {
+        public EncodingProvider();
+        public abstract Encoding GetEncoding(int codepage);
+        public virtual Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
+        public abstract Encoding GetEncoding(string name);
+        public virtual Encoding GetEncoding(string name, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
+    }
     public sealed class StringBuilder {
+        public unsafe StringBuilder Append(char* value, int valueCount);
+        public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0);
+        public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1);
+        public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1, object arg2);
+        public StringBuilder AppendFormat(string format, object arg0);
+        public StringBuilder AppendFormat(string format, object arg0, object arg1);
+        public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2);
     }
+    public sealed class UTF32Encoding : Encoding {
+        public UTF32Encoding();
+        public UTF32Encoding(bool bigEndian, bool byteOrderMark);
+        public UTF32Encoding(bool bigEndian, bool byteOrderMark, bool throwOnInvalidCharacters);
+        public override bool Equals(object value);
+        public unsafe override int GetByteCount(char* chars, int count);
+        public override int GetByteCount(char[] chars, int index, int count);
+        public override int GetByteCount(string s);
+        public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount);
+        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
+        public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
+        public unsafe override int GetCharCount(byte* bytes, int count);
+        public override int GetCharCount(byte[] bytes, int index, int count);
+        public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount);
+        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
+        public override Decoder GetDecoder();
+        public override Encoder GetEncoder();
+        public override int GetHashCode();
+        public override int GetMaxByteCount(int charCount);
+        public override int GetMaxCharCount(int byteCount);
+        public override byte[] GetPreamble();
+        public override string GetString(byte[] bytes, int index, int count);
+    }
+    public class UTF7Encoding : Encoding {
+        public UTF7Encoding();
+        public UTF7Encoding(bool allowOptionals);
+        public override bool Equals(object value);
+        public unsafe override int GetByteCount(char* chars, int count);
+        public override int GetByteCount(char[] chars, int index, int count);
+        public override int GetByteCount(string s);
+        public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount);
+        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
+        public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
+        public unsafe override int GetCharCount(byte* bytes, int count);
+        public override int GetCharCount(byte[] bytes, int index, int count);
+        public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount);
+        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
+        public override Decoder GetDecoder();
+        public override Encoder GetEncoder();
+        public override int GetHashCode();
+        public override int GetMaxByteCount(int charCount);
+        public override int GetMaxCharCount(int byteCount);
+        public override string GetString(byte[] bytes, int index, int count);
+    }
     public class UTF8Encoding : Encoding {
+        public unsafe override int GetByteCount(char* chars, int count);
+        public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount);
+        public unsafe override int GetCharCount(byte* bytes, int count);
+        public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount);
     }
 }
 namespace System.Text.RegularExpressions {
     public class Regex {
+        public static int CacheSize { get; set; }
     }
     public enum RegexOptions {
+        Compiled = 8,
     }
 }
 namespace System.Threading {
+    public sealed class AsyncLocal<T> {
+        public AsyncLocal();
+        public AsyncLocal(Action<AsyncLocalValueChangedArgs<T>> valueChangedHandler);
+        public T Value { get; set; }
+    }
+    public struct AsyncLocalValueChangedArgs<T> {
+        public T CurrentValue { get; }
+        public T PreviousValue { get; }
+        public bool ThreadContextChanged { get; }
+    }
+    public delegate void ContextCallback(object state); {
+        public ContextCallback(object @object, IntPtr method);
+        public virtual IAsyncResult BeginInvoke(object state, AsyncCallback callback, object @object);
+        public virtual void EndInvoke(IAsyncResult result);
+        public virtual void Invoke(object state);
+    }
+    public sealed class ExecutionContext {
+        public static ExecutionContext Capture();
+        public static void Run(ExecutionContext executionContext, ContextCallback callback, object state);
+    }
+    public static class WaitHandleExtensions {
+        public static SafeWaitHandle GetSafeWaitHandle(this WaitHandle waitHandle);
+        public static void SetSafeWaitHandle(this WaitHandle waitHandle, SafeWaitHandle value);
+    }
 }
 namespace System.Threading.Tasks {
     public class Task : IAsyncResult {
+        public static Task CompletedTask { get; }
+        public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken);
+        public static Task FromCanceled(CancellationToken cancellationToken);
+        public static Task<TResult> FromException<TResult>(Exception exception);
+        public static Task FromException(Exception exception);
     }
     public class TaskCompletionSource<TResult> {
+        public bool TrySetCanceled(CancellationToken cancellationToken);
     }
     public enum TaskContinuationOptions {
+        RunContinuationsAsynchronously = 64,
     }
     public enum TaskCreationOptions {
+        RunContinuationsAsynchronously = 64,
     }
 }
 namespace System.Xml {
     public static class XmlConvert {
+        public static DateTime ToDateTime(string s, XmlDateTimeSerializationMode dateTimeOption);
+        public static string ToString(byte value);
+        public static string ToString(DateTime value, XmlDateTimeSerializationMode dateTimeOption);
+        public static string ToString(ushort value);
     }
+    public enum XmlDateTimeSerializationMode {
+        Local = 0,
+        RoundtripKind = 3,
+        Unspecified = 2,
+        Utc = 1,
+    }
 }
 namespace System.Xml.Linq {
-    public class XElement : XContainer {
+    public class XElement : XContainer, IXmlSerializable {
     }
 }
+namespace System.Xml.Serialization {
+    public interface IXmlSerializable {
+        XmlSchema GetSchema();
+        void ReadXml(XmlReader reader);
+        void WriteXml(XmlWriter writer);
+    }
+    public sealed class XmlSchemaProviderAttribute : Attribute {
+        public XmlSchemaProviderAttribute(string methodName);
+        public bool IsAny { get; set; }
+        public string MethodName { get; }
+    }
+}
+namespace Microsoft.Win32.SafeHandles {
+    public sealed class SafeFileHandle : SafeHandle {
+        public SafeFileHandle(IntPtr preexistingHandle, bool ownsHandle);
+        public override bool IsInvalid { get; }
+    }
+    public sealed class SafeWaitHandle : SafeHandle {
+        public SafeWaitHandle(IntPtr existingHandle, bool ownsHandle);
+        public override bool IsInvalid { get; }
+    }
+    public sealed class SafeX509ChainHandle : SafeHandle {
+        public override bool IsInvalid { get; }
+    }
+}
```
