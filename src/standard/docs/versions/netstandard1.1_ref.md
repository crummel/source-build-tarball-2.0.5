# .NET Standard 1.1

[Overview](netstandard1.1.md) | [Previous](netstandard1.0_ref.md) | [Next](netstandard1.2_ref.md)

```C#
 namespace System {
     public delegate void Action(); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke();
     }
     public delegate void Action<in T>(T obj); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T obj, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T obj);
     }
     public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2);
     }
     public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3);
     }
     public delegate void Action<in T1, in T2, in T3, in T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);
     }
     public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16); {
         public Action(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);
     }
     public static class Activator {
         public static T CreateInstance<T>();
         public static object CreateInstance(Type type);
         public static object CreateInstance(Type type, params object[] args);
     }
     public class AggregateException : Exception {
         public AggregateException();
         public AggregateException(params Exception[] innerExceptions);
         public AggregateException(IEnumerable<Exception> innerExceptions);
         public AggregateException(string message);
         public AggregateException(string message, Exception innerException);
         public AggregateException(string message, params Exception[] innerExceptions);
         public AggregateException(string message, IEnumerable<Exception> innerExceptions);
         public ReadOnlyCollection<Exception> InnerExceptions { get; }
         public AggregateException Flatten();
         public override Exception GetBaseException();
         public void Handle(Func<Exception, bool> predicate);
         public override string ToString();
     }
     public class ArgumentException : Exception {
         public ArgumentException();
         public ArgumentException(string message);
         public ArgumentException(string message, Exception innerException);
         public ArgumentException(string message, string paramName);
         public ArgumentException(string message, string paramName, Exception innerException);
         public override string Message { get; }
         public virtual string ParamName { get; }
     }
     public class ArgumentNullException : ArgumentException {
         public ArgumentNullException();
         public ArgumentNullException(string paramName);
         public ArgumentNullException(string message, Exception innerException);
         public ArgumentNullException(string paramName, string message);
     }
     public class ArgumentOutOfRangeException : ArgumentException {
         public ArgumentOutOfRangeException();
         public ArgumentOutOfRangeException(string paramName);
         public ArgumentOutOfRangeException(string message, Exception innerException);
         public ArgumentOutOfRangeException(string paramName, object actualValue, string message);
         public ArgumentOutOfRangeException(string paramName, string message);
         public virtual object ActualValue { get; }
         public override string Message { get; }
     }
     public class ArithmeticException : Exception {
         public ArithmeticException();
         public ArithmeticException(string message);
         public ArithmeticException(string message, Exception innerException);
     }
     public abstract class Array : ICollection, IEnumerable, IList, IStructuralComparable, IStructuralEquatable {
         public int Length { get; }
         public int Rank { get; }
         public static int BinarySearch<T>(T[] array, T value);
         public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer);
         public static int BinarySearch<T>(T[] array, int index, int length, T value);
         public static int BinarySearch<T>(T[] array, int index, int length, T value, IComparer<T> comparer);
         public static int BinarySearch(Array array, int index, int length, object value);
         public static int BinarySearch(Array array, int index, int length, object value, IComparer comparer);
         public static int BinarySearch(Array array, object value);
         public static int BinarySearch(Array array, object value, IComparer comparer);
         public static void Clear(Array array, int index, int length);
         public object Clone();
         public static void ConstrainedCopy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);
         public static void Copy(Array sourceArray, Array destinationArray, int length);
         public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);
         public void CopyTo(Array array, int index);
         public static Array CreateInstance(Type elementType, params int[] lengths);
         public static Array CreateInstance(Type elementType, int[] lengths, int[] lowerBounds);
         public static bool Exists<T>(T[] array, Predicate<T> match);
         public static T Find<T>(T[] array, Predicate<T> match);
         public static T[] FindAll<T>(T[] array, Predicate<T> match);
         public static int FindIndex<T>(T[] array, Predicate<T> match);
         public static int FindIndex<T>(T[] array, int startIndex, Predicate<T> match);
         public static int FindIndex<T>(T[] array, int startIndex, int count, Predicate<T> match);
         public static T FindLast<T>(T[] array, Predicate<T> match);
         public static int FindLastIndex<T>(T[] array, Predicate<T> match);
         public static int FindLastIndex<T>(T[] array, int startIndex, Predicate<T> match);
         public static int FindLastIndex<T>(T[] array, int startIndex, int count, Predicate<T> match);
         public IEnumerator GetEnumerator();
         public int GetLength(int dimension);
         public int GetLowerBound(int dimension);
         public int GetUpperBound(int dimension);
         public object GetValue(params int[] indices);
         public static int IndexOf<T>(T[] array, T value);
         public static int IndexOf<T>(T[] array, T value, int startIndex);
         public static int IndexOf<T>(T[] array, T value, int startIndex, int count);
         public static int IndexOf(Array array, object value);
         public static int IndexOf(Array array, object value, int startIndex);
         public static int IndexOf(Array array, object value, int startIndex, int count);
         public void Initialize();
         public static int LastIndexOf<T>(T[] array, T value);
         public static int LastIndexOf<T>(T[] array, T value, int startIndex);
         public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count);
         public static int LastIndexOf(Array array, object value);
         public static int LastIndexOf(Array array, object value, int startIndex);
         public static int LastIndexOf(Array array, object value, int startIndex, int count);
         public static void Resize<T>(ref T[] array, int newSize);
         public static void Reverse(Array array);
         public static void Reverse(Array array, int index, int length);
         public void SetValue(object value, params int[] indices);
         public static void Sort<T>(T[] array);
         public static void Sort<T>(T[] array, IComparer<T> comparer);
         public static void Sort<T>(T[] array, int index, int length);
         public static void Sort<T>(T[] array, Comparison<T> comparison);
         public static void Sort<T>(T[] array, int index, int length, IComparer<T> comparer);
         public static void Sort(Array array);
         public static void Sort(Array array, IComparer comparer);
         public static void Sort(Array array, int index, int length);
         public static void Sort(Array array, int index, int length, IComparer comparer);
         public static bool TrueForAll<T>(T[] array, Predicate<T> match);
     }
     public struct ArraySegment<T> : ICollection<T>, IEnumerable, IEnumerable<T>, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T> {
         public ArraySegment(T[] array);
         public ArraySegment(T[] array, int offset, int count);
         public T[] Array { get; }
         public int Count { get; }
         public int Offset { get; }
         public bool Equals(ArraySegment<T> obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static bool operator ==(ArraySegment<T> a, ArraySegment<T> b);
         public static bool operator !=(ArraySegment<T> a, ArraySegment<T> b);
     }
     public class ArrayTypeMismatchException : Exception {
         public ArrayTypeMismatchException();
         public ArrayTypeMismatchException(string message);
         public ArrayTypeMismatchException(string message, Exception innerException);
     }
     public delegate void AsyncCallback(IAsyncResult ar); {
         public AsyncCallback(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(IAsyncResult ar, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(IAsyncResult ar);
     }
     public abstract class Attribute {
         protected Attribute();
         public override bool Equals(object obj);
         public override int GetHashCode();
     }
     public enum AttributeTargets {
         All = 32767,
         Assembly = 1,
         Class = 4,
         Constructor = 32,
         Delegate = 4096,
         Enum = 16,
         Event = 512,
         Field = 256,
         GenericParameter = 16384,
         Interface = 1024,
         Method = 64,
         Module = 2,
         Parameter = 2048,
         Property = 128,
         ReturnValue = 8192,
         Struct = 8,
     }
     public sealed class AttributeUsageAttribute : Attribute {
         public AttributeUsageAttribute(AttributeTargets validOn);
         public bool AllowMultiple { get; set; }
         public bool Inherited { get; set; }
         public AttributeTargets ValidOn { get; }
     }
     public class BadImageFormatException : Exception {
         public BadImageFormatException();
         public BadImageFormatException(string message);
         public BadImageFormatException(string message, Exception inner);
         public BadImageFormatException(string message, string fileName);
         public BadImageFormatException(string message, string fileName, Exception inner);
         public string FileName { get; }
         public override string Message { get; }
         public override string ToString();
     }
     public static class BitConverter {
         public static readonly bool IsLittleEndian;
         public static long DoubleToInt64Bits(double value);
         public static byte[] GetBytes(bool value);
         public static byte[] GetBytes(char value);
         public static byte[] GetBytes(double value);
         public static byte[] GetBytes(short value);
         public static byte[] GetBytes(int value);
         public static byte[] GetBytes(long value);
         public static byte[] GetBytes(float value);
         public static byte[] GetBytes(ushort value);
         public static byte[] GetBytes(uint value);
         public static byte[] GetBytes(ulong value);
         public static double Int64BitsToDouble(long value);
         public static bool ToBoolean(byte[] value, int startIndex);
         public static char ToChar(byte[] value, int startIndex);
         public static double ToDouble(byte[] value, int startIndex);
         public static short ToInt16(byte[] value, int startIndex);
         public static int ToInt32(byte[] value, int startIndex);
         public static long ToInt64(byte[] value, int startIndex);
         public static float ToSingle(byte[] value, int startIndex);
         public static string ToString(byte[] value);
         public static string ToString(byte[] value, int startIndex);
         public static string ToString(byte[] value, int startIndex, int length);
         public static ushort ToUInt16(byte[] value, int startIndex);
         public static uint ToUInt32(byte[] value, int startIndex);
         public static ulong ToUInt64(byte[] value, int startIndex);
     }
     public struct Boolean : IComparable, IComparable<bool>, IEquatable<bool> {
         public static readonly string FalseString;
         public static readonly string TrueString;
         public int CompareTo(bool value);
         public bool Equals(bool obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static bool Parse(string value);
         public override string ToString();
         public static bool TryParse(string value, out bool result);
     }
     public static class Buffer {
         public static void BlockCopy(Array src, int srcOffset, Array dst, int dstOffset, int count);
         public static int ByteLength(Array array);
         public static byte GetByte(Array array, int index);
         public static void SetByte(Array array, int index, byte value);
     }
     public struct Byte : IComparable, IComparable<byte>, IEquatable<byte>, IFormattable {
         public const byte MaxValue = (byte)255;
         public const byte MinValue = (byte)0;
         public int CompareTo(byte value);
         public bool Equals(byte obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static byte Parse(string s);
         public static byte Parse(string s, IFormatProvider provider);
         public static byte Parse(string s, NumberStyles style);
         public static byte Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, out byte result);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out byte result);
     }
     public struct Char : IComparable, IComparable<char>, IEquatable<char> {
         public const char MaxValue = '\uFFFF';
         public const char MinValue = '\0';
         public int CompareTo(char value);
         public static string ConvertFromUtf32(int utf32);
         public static int ConvertToUtf32(char highSurrogate, char lowSurrogate);
         public static int ConvertToUtf32(string s, int index);
         public bool Equals(char obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static double GetNumericValue(char c);
         public static double GetNumericValue(string s, int index);
         public static bool IsControl(char c);
         public static bool IsControl(string s, int index);
         public static bool IsDigit(char c);
         public static bool IsDigit(string s, int index);
         public static bool IsHighSurrogate(char c);
         public static bool IsHighSurrogate(string s, int index);
         public static bool IsLetter(char c);
         public static bool IsLetter(string s, int index);
         public static bool IsLetterOrDigit(char c);
         public static bool IsLetterOrDigit(string s, int index);
         public static bool IsLower(char c);
         public static bool IsLower(string s, int index);
         public static bool IsLowSurrogate(char c);
         public static bool IsLowSurrogate(string s, int index);
         public static bool IsNumber(char c);
         public static bool IsNumber(string s, int index);
         public static bool IsPunctuation(char c);
         public static bool IsPunctuation(string s, int index);
         public static bool IsSeparator(char c);
         public static bool IsSeparator(string s, int index);
         public static bool IsSurrogate(char c);
         public static bool IsSurrogate(string s, int index);
         public static bool IsSurrogatePair(char highSurrogate, char lowSurrogate);
         public static bool IsSurrogatePair(string s, int index);
         public static bool IsSymbol(char c);
         public static bool IsSymbol(string s, int index);
         public static bool IsUpper(char c);
         public static bool IsUpper(string s, int index);
         public static bool IsWhiteSpace(char c);
         public static bool IsWhiteSpace(string s, int index);
         public static char ToLower(char c);
         public static char ToLowerInvariant(char c);
         public override string ToString();
         public static string ToString(char c);
         public static char ToUpper(char c);
         public static char ToUpperInvariant(char c);
         public static bool TryParse(string s, out char result);
     }
     public sealed class CLSCompliantAttribute : Attribute {
         public CLSCompliantAttribute(bool isCompliant);
         public bool IsCompliant { get; }
     }
     public delegate int Comparison<in T>(T x, T y); {
         public Comparison(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T x, T y, AsyncCallback callback, object @object);
         public virtual int EndInvoke(IAsyncResult result);
         public virtual int Invoke(T x, T y);
     }
     public static class Convert {
         public static object ChangeType(object value, Type conversionType);
         public static object ChangeType(object value, Type conversionType, IFormatProvider provider);
         public static byte[] FromBase64CharArray(char[] inArray, int offset, int length);
         public static byte[] FromBase64String(string s);
         public static int ToBase64CharArray(byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut);
         public static string ToBase64String(byte[] inArray);
         public static string ToBase64String(byte[] inArray, int offset, int length);
         public static bool ToBoolean(bool value);
         public static bool ToBoolean(byte value);
         public static bool ToBoolean(decimal value);
         public static bool ToBoolean(double value);
         public static bool ToBoolean(short value);
         public static bool ToBoolean(int value);
         public static bool ToBoolean(long value);
         public static bool ToBoolean(object value);
         public static bool ToBoolean(object value, IFormatProvider provider);
         public static bool ToBoolean(sbyte value);
         public static bool ToBoolean(float value);
         public static bool ToBoolean(string value);
         public static bool ToBoolean(string value, IFormatProvider provider);
         public static bool ToBoolean(ushort value);
         public static bool ToBoolean(uint value);
         public static bool ToBoolean(ulong value);
         public static byte ToByte(bool value);
         public static byte ToByte(byte value);
         public static byte ToByte(char value);
         public static byte ToByte(decimal value);
         public static byte ToByte(double value);
         public static byte ToByte(short value);
         public static byte ToByte(int value);
         public static byte ToByte(long value);
         public static byte ToByte(object value);
         public static byte ToByte(object value, IFormatProvider provider);
         public static byte ToByte(sbyte value);
         public static byte ToByte(float value);
         public static byte ToByte(string value);
         public static byte ToByte(string value, IFormatProvider provider);
         public static byte ToByte(string value, int fromBase);
         public static byte ToByte(ushort value);
         public static byte ToByte(uint value);
         public static byte ToByte(ulong value);
         public static char ToChar(byte value);
         public static char ToChar(short value);
         public static char ToChar(int value);
         public static char ToChar(long value);
         public static char ToChar(object value);
         public static char ToChar(object value, IFormatProvider provider);
         public static char ToChar(sbyte value);
         public static char ToChar(string value);
         public static char ToChar(string value, IFormatProvider provider);
         public static char ToChar(ushort value);
         public static char ToChar(uint value);
         public static char ToChar(ulong value);
         public static DateTime ToDateTime(object value);
         public static DateTime ToDateTime(object value, IFormatProvider provider);
         public static DateTime ToDateTime(string value);
         public static DateTime ToDateTime(string value, IFormatProvider provider);
         public static decimal ToDecimal(bool value);
         public static decimal ToDecimal(byte value);
         public static decimal ToDecimal(decimal value);
         public static decimal ToDecimal(double value);
         public static decimal ToDecimal(short value);
         public static decimal ToDecimal(int value);
         public static decimal ToDecimal(long value);
         public static decimal ToDecimal(object value);
         public static decimal ToDecimal(object value, IFormatProvider provider);
         public static decimal ToDecimal(sbyte value);
         public static decimal ToDecimal(float value);
         public static decimal ToDecimal(string value);
         public static decimal ToDecimal(string value, IFormatProvider provider);
         public static decimal ToDecimal(ushort value);
         public static decimal ToDecimal(uint value);
         public static decimal ToDecimal(ulong value);
         public static double ToDouble(bool value);
         public static double ToDouble(byte value);
         public static double ToDouble(decimal value);
         public static double ToDouble(double value);
         public static double ToDouble(short value);
         public static double ToDouble(int value);
         public static double ToDouble(long value);
         public static double ToDouble(object value);
         public static double ToDouble(object value, IFormatProvider provider);
         public static double ToDouble(sbyte value);
         public static double ToDouble(float value);
         public static double ToDouble(string value);
         public static double ToDouble(string value, IFormatProvider provider);
         public static double ToDouble(ushort value);
         public static double ToDouble(uint value);
         public static double ToDouble(ulong value);
         public static short ToInt16(bool value);
         public static short ToInt16(byte value);
         public static short ToInt16(char value);
         public static short ToInt16(decimal value);
         public static short ToInt16(double value);
         public static short ToInt16(short value);
         public static short ToInt16(int value);
         public static short ToInt16(long value);
         public static short ToInt16(object value);
         public static short ToInt16(object value, IFormatProvider provider);
         public static short ToInt16(sbyte value);
         public static short ToInt16(float value);
         public static short ToInt16(string value);
         public static short ToInt16(string value, IFormatProvider provider);
         public static short ToInt16(string value, int fromBase);
         public static short ToInt16(ushort value);
         public static short ToInt16(uint value);
         public static short ToInt16(ulong value);
         public static int ToInt32(bool value);
         public static int ToInt32(byte value);
         public static int ToInt32(char value);
         public static int ToInt32(decimal value);
         public static int ToInt32(double value);
         public static int ToInt32(short value);
         public static int ToInt32(int value);
         public static int ToInt32(long value);
         public static int ToInt32(object value);
         public static int ToInt32(object value, IFormatProvider provider);
         public static int ToInt32(sbyte value);
         public static int ToInt32(float value);
         public static int ToInt32(string value);
         public static int ToInt32(string value, IFormatProvider provider);
         public static int ToInt32(string value, int fromBase);
         public static int ToInt32(ushort value);
         public static int ToInt32(uint value);
         public static int ToInt32(ulong value);
         public static long ToInt64(bool value);
         public static long ToInt64(byte value);
         public static long ToInt64(char value);
         public static long ToInt64(decimal value);
         public static long ToInt64(double value);
         public static long ToInt64(short value);
         public static long ToInt64(int value);
         public static long ToInt64(long value);
         public static long ToInt64(object value);
         public static long ToInt64(object value, IFormatProvider provider);
         public static long ToInt64(sbyte value);
         public static long ToInt64(float value);
         public static long ToInt64(string value);
         public static long ToInt64(string value, IFormatProvider provider);
         public static long ToInt64(string value, int fromBase);
         public static long ToInt64(ushort value);
         public static long ToInt64(uint value);
         public static long ToInt64(ulong value);
         public static sbyte ToSByte(bool value);
         public static sbyte ToSByte(byte value);
         public static sbyte ToSByte(char value);
         public static sbyte ToSByte(decimal value);
         public static sbyte ToSByte(double value);
         public static sbyte ToSByte(short value);
         public static sbyte ToSByte(int value);
         public static sbyte ToSByte(long value);
         public static sbyte ToSByte(object value);
         public static sbyte ToSByte(object value, IFormatProvider provider);
         public static sbyte ToSByte(sbyte value);
         public static sbyte ToSByte(float value);
         public static sbyte ToSByte(string value);
         public static sbyte ToSByte(string value, IFormatProvider provider);
         public static sbyte ToSByte(string value, int fromBase);
         public static sbyte ToSByte(ushort value);
         public static sbyte ToSByte(uint value);
         public static sbyte ToSByte(ulong value);
         public static float ToSingle(bool value);
         public static float ToSingle(byte value);
         public static float ToSingle(decimal value);
         public static float ToSingle(double value);
         public static float ToSingle(short value);
         public static float ToSingle(int value);
         public static float ToSingle(long value);
         public static float ToSingle(object value);
         public static float ToSingle(object value, IFormatProvider provider);
         public static float ToSingle(sbyte value);
         public static float ToSingle(float value);
         public static float ToSingle(string value);
         public static float ToSingle(string value, IFormatProvider provider);
         public static float ToSingle(ushort value);
         public static float ToSingle(uint value);
         public static float ToSingle(ulong value);
         public static string ToString(bool value);
         public static string ToString(bool value, IFormatProvider provider);
         public static string ToString(byte value);
         public static string ToString(byte value, IFormatProvider provider);
         public static string ToString(byte value, int toBase);
         public static string ToString(char value);
         public static string ToString(char value, IFormatProvider provider);
         public static string ToString(DateTime value);
         public static string ToString(DateTime value, IFormatProvider provider);
         public static string ToString(decimal value);
         public static string ToString(decimal value, IFormatProvider provider);
         public static string ToString(double value);
         public static string ToString(double value, IFormatProvider provider);
         public static string ToString(short value);
         public static string ToString(short value, IFormatProvider provider);
         public static string ToString(short value, int toBase);
         public static string ToString(int value);
         public static string ToString(int value, IFormatProvider provider);
         public static string ToString(int value, int toBase);
         public static string ToString(long value);
         public static string ToString(long value, IFormatProvider provider);
         public static string ToString(long value, int toBase);
         public static string ToString(object value);
         public static string ToString(object value, IFormatProvider provider);
         public static string ToString(sbyte value);
         public static string ToString(sbyte value, IFormatProvider provider);
         public static string ToString(float value);
         public static string ToString(float value, IFormatProvider provider);
         public static string ToString(ushort value);
         public static string ToString(ushort value, IFormatProvider provider);
         public static string ToString(uint value);
         public static string ToString(uint value, IFormatProvider provider);
         public static string ToString(ulong value);
         public static string ToString(ulong value, IFormatProvider provider);
         public static ushort ToUInt16(bool value);
         public static ushort ToUInt16(byte value);
         public static ushort ToUInt16(char value);
         public static ushort ToUInt16(decimal value);
         public static ushort ToUInt16(double value);
         public static ushort ToUInt16(short value);
         public static ushort ToUInt16(int value);
         public static ushort ToUInt16(long value);
         public static ushort ToUInt16(object value);
         public static ushort ToUInt16(object value, IFormatProvider provider);
         public static ushort ToUInt16(sbyte value);
         public static ushort ToUInt16(float value);
         public static ushort ToUInt16(string value);
         public static ushort ToUInt16(string value, IFormatProvider provider);
         public static ushort ToUInt16(string value, int fromBase);
         public static ushort ToUInt16(ushort value);
         public static ushort ToUInt16(uint value);
         public static ushort ToUInt16(ulong value);
         public static uint ToUInt32(bool value);
         public static uint ToUInt32(byte value);
         public static uint ToUInt32(char value);
         public static uint ToUInt32(decimal value);
         public static uint ToUInt32(double value);
         public static uint ToUInt32(short value);
         public static uint ToUInt32(int value);
         public static uint ToUInt32(long value);
         public static uint ToUInt32(object value);
         public static uint ToUInt32(object value, IFormatProvider provider);
         public static uint ToUInt32(sbyte value);
         public static uint ToUInt32(float value);
         public static uint ToUInt32(string value);
         public static uint ToUInt32(string value, IFormatProvider provider);
         public static uint ToUInt32(string value, int fromBase);
         public static uint ToUInt32(ushort value);
         public static uint ToUInt32(uint value);
         public static uint ToUInt32(ulong value);
         public static ulong ToUInt64(bool value);
         public static ulong ToUInt64(byte value);
         public static ulong ToUInt64(char value);
         public static ulong ToUInt64(decimal value);
         public static ulong ToUInt64(double value);
         public static ulong ToUInt64(short value);
         public static ulong ToUInt64(int value);
         public static ulong ToUInt64(long value);
         public static ulong ToUInt64(object value);
         public static ulong ToUInt64(object value, IFormatProvider provider);
         public static ulong ToUInt64(sbyte value);
         public static ulong ToUInt64(float value);
         public static ulong ToUInt64(string value);
         public static ulong ToUInt64(string value, IFormatProvider provider);
         public static ulong ToUInt64(string value, int fromBase);
         public static ulong ToUInt64(ushort value);
         public static ulong ToUInt64(uint value);
         public static ulong ToUInt64(ulong value);
     }
     public sealed class DataMisalignedException : Exception {
         public DataMisalignedException();
         public DataMisalignedException(string message);
         public DataMisalignedException(string message, Exception innerException);
     }
     public struct DateTime : IComparable, IComparable<DateTime>, IEquatable<DateTime>, IFormattable {
         public static readonly DateTime MaxValue;
         public static readonly DateTime MinValue;
         public DateTime(int year, int month, int day);
         public DateTime(int year, int month, int day, int hour, int minute, int second);
         public DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind);
         public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);
         public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind);
         public DateTime(long ticks);
         public DateTime(long ticks, DateTimeKind kind);
         public DateTime Date { get; }
         public int Day { get; }
         public DayOfWeek DayOfWeek { get; }
         public int DayOfYear { get; }
         public int Hour { get; }
         public DateTimeKind Kind { get; }
         public int Millisecond { get; }
         public int Minute { get; }
         public int Month { get; }
         public static DateTime Now { get; }
         public int Second { get; }
         public long Ticks { get; }
         public TimeSpan TimeOfDay { get; }
         public static DateTime Today { get; }
         public static DateTime UtcNow { get; }
         public int Year { get; }
         public DateTime Add(TimeSpan value);
         public DateTime AddDays(double value);
         public DateTime AddHours(double value);
         public DateTime AddMilliseconds(double value);
         public DateTime AddMinutes(double value);
         public DateTime AddMonths(int months);
         public DateTime AddSeconds(double value);
         public DateTime AddTicks(long value);
         public DateTime AddYears(int value);
         public static int Compare(DateTime t1, DateTime t2);
         public int CompareTo(DateTime value);
         public static int DaysInMonth(int year, int month);
         public bool Equals(DateTime value);
         public static bool Equals(DateTime t1, DateTime t2);
         public override bool Equals(object value);
         public static DateTime FromBinary(long dateData);
         public static DateTime FromFileTime(long fileTime);
         public static DateTime FromFileTimeUtc(long fileTime);
         public string[] GetDateTimeFormats();
         public string[] GetDateTimeFormats(char format);
         public string[] GetDateTimeFormats(char format, IFormatProvider provider);
         public string[] GetDateTimeFormats(IFormatProvider provider);
         public override int GetHashCode();
         public bool IsDaylightSavingTime();
         public static bool IsLeapYear(int year);
         public static DateTime operator +(DateTime d, TimeSpan t);
         public static bool operator ==(DateTime d1, DateTime d2);
         public static bool operator >(DateTime t1, DateTime t2);
         public static bool operator >=(DateTime t1, DateTime t2);
         public static bool operator !=(DateTime d1, DateTime d2);
         public static bool operator <(DateTime t1, DateTime t2);
         public static bool operator <=(DateTime t1, DateTime t2);
         public static TimeSpan operator -(DateTime d1, DateTime d2);
         public static DateTime operator -(DateTime d, TimeSpan t);
         public static DateTime Parse(string s);
         public static DateTime Parse(string s, IFormatProvider provider);
         public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles);
         public static DateTime ParseExact(string s, string format, IFormatProvider provider);
         public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style);
         public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style);
         public static DateTime SpecifyKind(DateTime value, DateTimeKind kind);
         public TimeSpan Subtract(DateTime value);
         public DateTime Subtract(TimeSpan value);
         public long ToBinary();
         public long ToFileTime();
         public long ToFileTimeUtc();
         public DateTime ToLocalTime();
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public DateTime ToUniversalTime();
         public static bool TryParse(string s, out DateTime result);
         public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result);
         public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result);
         public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result);
     }
     public enum DateTimeKind {
         Local = 2,
         Unspecified = 0,
         Utc = 1,
     }
     public struct DateTimeOffset : IComparable, IComparable<DateTimeOffset>, IEquatable<DateTimeOffset>, IFormattable {
         public static readonly DateTimeOffset MaxValue;
         public static readonly DateTimeOffset MinValue;
         public DateTimeOffset(DateTime dateTime);
         public DateTimeOffset(DateTime dateTime, TimeSpan offset);
         public DateTimeOffset(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeSpan offset);
         public DateTimeOffset(int year, int month, int day, int hour, int minute, int second, TimeSpan offset);
         public DateTimeOffset(long ticks, TimeSpan offset);
         public DateTime Date { get; }
         public DateTime DateTime { get; }
         public int Day { get; }
         public DayOfWeek DayOfWeek { get; }
         public int DayOfYear { get; }
         public int Hour { get; }
         public DateTime LocalDateTime { get; }
         public int Millisecond { get; }
         public int Minute { get; }
         public int Month { get; }
         public static DateTimeOffset Now { get; }
         public TimeSpan Offset { get; }
         public int Second { get; }
         public long Ticks { get; }
         public TimeSpan TimeOfDay { get; }
         public DateTime UtcDateTime { get; }
         public static DateTimeOffset UtcNow { get; }
         public long UtcTicks { get; }
         public int Year { get; }
         public DateTimeOffset Add(TimeSpan timeSpan);
         public DateTimeOffset AddDays(double days);
         public DateTimeOffset AddHours(double hours);
         public DateTimeOffset AddMilliseconds(double milliseconds);
         public DateTimeOffset AddMinutes(double minutes);
         public DateTimeOffset AddMonths(int months);
         public DateTimeOffset AddSeconds(double seconds);
         public DateTimeOffset AddTicks(long ticks);
         public DateTimeOffset AddYears(int years);
         public static int Compare(DateTimeOffset first, DateTimeOffset second);
         public int CompareTo(DateTimeOffset other);
         public bool Equals(DateTimeOffset other);
         public static bool Equals(DateTimeOffset first, DateTimeOffset second);
         public override bool Equals(object obj);
         public bool EqualsExact(DateTimeOffset other);
         public static DateTimeOffset FromFileTime(long fileTime);
         public override int GetHashCode();
         public static DateTimeOffset operator +(DateTimeOffset dateTimeOffset, TimeSpan timeSpan);
         public static bool operator ==(DateTimeOffset left, DateTimeOffset right);
         public static bool operator >(DateTimeOffset left, DateTimeOffset right);
         public static bool operator >=(DateTimeOffset left, DateTimeOffset right);
         public static implicit operator DateTimeOffset (DateTime dateTime);
         public static bool operator !=(DateTimeOffset left, DateTimeOffset right);
         public static bool operator <(DateTimeOffset left, DateTimeOffset right);
         public static bool operator <=(DateTimeOffset left, DateTimeOffset right);
         public static TimeSpan operator -(DateTimeOffset left, DateTimeOffset right);
         public static DateTimeOffset operator -(DateTimeOffset dateTimeOffset, TimeSpan timeSpan);
         public static DateTimeOffset Parse(string input);
         public static DateTimeOffset Parse(string input, IFormatProvider formatProvider);
         public static DateTimeOffset Parse(string input, IFormatProvider formatProvider, DateTimeStyles styles);
         public static DateTimeOffset ParseExact(string input, string format, IFormatProvider formatProvider);
         public static DateTimeOffset ParseExact(string input, string format, IFormatProvider formatProvider, DateTimeStyles styles);
         public static DateTimeOffset ParseExact(string input, string[] formats, IFormatProvider formatProvider, DateTimeStyles styles);
         public TimeSpan Subtract(DateTimeOffset value);
         public DateTimeOffset Subtract(TimeSpan value);
         public long ToFileTime();
         public DateTimeOffset ToLocalTime();
         public DateTimeOffset ToOffset(TimeSpan offset);
         public override string ToString();
         public string ToString(IFormatProvider formatProvider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider formatProvider);
         public DateTimeOffset ToUniversalTime();
         public static bool TryParse(string input, out DateTimeOffset result);
         public static bool TryParse(string input, IFormatProvider formatProvider, DateTimeStyles styles, out DateTimeOffset result);
         public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, DateTimeStyles styles, out DateTimeOffset result);
         public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, DateTimeStyles styles, out DateTimeOffset result);
     }
     public enum DayOfWeek {
         Friday = 5,
         Monday = 1,
         Saturday = 6,
         Sunday = 0,
         Thursday = 4,
         Tuesday = 2,
         Wednesday = 3,
     }
     public struct Decimal : IComparable, IComparable<decimal>, IEquatable<decimal>, IFormattable {
         public static readonly decimal MaxValue;
         public static readonly decimal MinusOne;
         public static readonly decimal MinValue;
         public static readonly decimal One;
         public static readonly decimal Zero;
         public Decimal(double value);
         public Decimal(int value);
         public Decimal(int lo, int mid, int hi, bool isNegative, byte scale);
         public Decimal(int[] bits);
         public Decimal(long value);
         public Decimal(float value);
         public Decimal(uint value);
         public Decimal(ulong value);
         public static decimal Add(decimal d1, decimal d2);
         public static decimal Ceiling(decimal d);
         public static int Compare(decimal d1, decimal d2);
         public int CompareTo(decimal value);
         public static decimal Divide(decimal d1, decimal d2);
         public bool Equals(decimal value);
         public static bool Equals(decimal d1, decimal d2);
         public override bool Equals(object value);
         public static decimal Floor(decimal d);
         public static int[] GetBits(decimal d);
         public override int GetHashCode();
         public static decimal Multiply(decimal d1, decimal d2);
         public static decimal Negate(decimal d);
         public static decimal operator +(decimal d1, decimal d2);
         public static decimal operator --(decimal d);
         public static decimal operator /(decimal d1, decimal d2);
         public static bool operator ==(decimal d1, decimal d2);
         public static explicit operator byte (decimal value);
         public static explicit operator char (decimal value);
         public static explicit operator double (decimal value);
         public static explicit operator short (decimal value);
         public static explicit operator int (decimal value);
         public static explicit operator long (decimal value);
         public static explicit operator sbyte (decimal value);
         public static explicit operator float (decimal value);
         public static explicit operator ushort (decimal value);
         public static explicit operator uint (decimal value);
         public static explicit operator ulong (decimal value);
         public static explicit operator decimal (double value);
         public static explicit operator decimal (float value);
         public static bool operator >(decimal d1, decimal d2);
         public static bool operator >=(decimal d1, decimal d2);
         public static implicit operator decimal (byte value);
         public static implicit operator decimal (char value);
         public static implicit operator decimal (short value);
         public static implicit operator decimal (int value);
         public static implicit operator decimal (long value);
         public static implicit operator decimal (sbyte value);
         public static implicit operator decimal (ushort value);
         public static implicit operator decimal (uint value);
         public static implicit operator decimal (ulong value);
         public static decimal operator ++(decimal d);
         public static bool operator !=(decimal d1, decimal d2);
         public static bool operator <(decimal d1, decimal d2);
         public static bool operator <=(decimal d1, decimal d2);
         public static decimal operator %(decimal d1, decimal d2);
         public static decimal operator *(decimal d1, decimal d2);
         public static decimal operator -(decimal d1, decimal d2);
         public static decimal operator -(decimal d);
         public static decimal operator +(decimal d);
         public static decimal Parse(string s);
         public static decimal Parse(string s, IFormatProvider provider);
         public static decimal Parse(string s, NumberStyles style);
         public static decimal Parse(string s, NumberStyles style, IFormatProvider provider);
         public static decimal Remainder(decimal d1, decimal d2);
         public static decimal Subtract(decimal d1, decimal d2);
         public static byte ToByte(decimal value);
         public static double ToDouble(decimal d);
         public static short ToInt16(decimal value);
         public static int ToInt32(decimal d);
         public static long ToInt64(decimal d);
         public static sbyte ToSByte(decimal value);
         public static float ToSingle(decimal d);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static ushort ToUInt16(decimal value);
         public static uint ToUInt32(decimal d);
         public static ulong ToUInt64(decimal d);
         public static decimal Truncate(decimal d);
         public static bool TryParse(string s, out decimal result);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out decimal result);
     }
     public abstract class Delegate {
         public object Target { get; }
         public static Delegate Combine(Delegate a, Delegate b);
         public static Delegate Combine(params Delegate[] delegates);
         public object DynamicInvoke(params object[] args);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public virtual Delegate[] GetInvocationList();
         public static bool operator ==(Delegate d1, Delegate d2);
         public static bool operator !=(Delegate d1, Delegate d2);
         public static Delegate Remove(Delegate source, Delegate value);
         public static Delegate RemoveAll(Delegate source, Delegate value);
     }
     public class DivideByZeroException : ArithmeticException {
         public DivideByZeroException();
         public DivideByZeroException(string message);
         public DivideByZeroException(string message, Exception innerException);
     }
     public class DllNotFoundException : TypeLoadException {
         public DllNotFoundException();
         public DllNotFoundException(string message);
         public DllNotFoundException(string message, Exception inner);
     }
     public struct Double : IComparable, IComparable<double>, IEquatable<double>, IFormattable {
         public const double Epsilon = 4.94065645841247E-324;
         public const double MaxValue = 1.7976931348623157E+308;
         public const double MinValue = -1.7976931348623157E+308;
         public const double NaN = 0.0 / 0.0;
         public const double NegativeInfinity = -1.0 / 0.0;
         public const double PositiveInfinity = 1.0 / 0.0;
         public int CompareTo(double value);
         public bool Equals(double obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static bool IsInfinity(double d);
         public static bool IsNaN(double d);
         public static bool IsNegativeInfinity(double d);
         public static bool IsPositiveInfinity(double d);
         public static bool operator ==(double left, double right);
         public static bool operator >(double left, double right);
         public static bool operator >=(double left, double right);
         public static bool operator !=(double left, double right);
         public static bool operator <(double left, double right);
         public static bool operator <=(double left, double right);
         public static double Parse(string s);
         public static double Parse(string s, IFormatProvider provider);
         public static double Parse(string s, NumberStyles style);
         public static double Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, out double result);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out double result);
     }
     public abstract class Enum : ValueType, IComparable, IFormattable {
         protected Enum();
         public int CompareTo(object target);
         public override bool Equals(object obj);
         public static string Format(Type enumType, object value, string format);
         public override int GetHashCode();
         public static string GetName(Type enumType, object value);
         public static string[] GetNames(Type enumType);
         public static Type GetUnderlyingType(Type enumType);
         public static Array GetValues(Type enumType);
         public bool HasFlag(Enum flag);
         public static bool IsDefined(Type enumType, object value);
         public static object Parse(Type enumType, string value);
         public static object Parse(Type enumType, string value, bool ignoreCase);
         public static object ToObject(Type enumType, object value);
         public override string ToString();
         public string ToString(string format);
         public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct;
         public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct;
     }
     public static class Environment {
         public static int CurrentManagedThreadId { get; }
         public static bool HasShutdownStarted { get; }
         public static string NewLine { get; }
         public static int ProcessorCount { get; }
         public static int TickCount { get; }
         public static void FailFast(string message);
         public static void FailFast(string message, Exception exception);
     }
     public class EventArgs {
         public static readonly EventArgs Empty;
         public EventArgs();
     }
     public delegate void EventHandler(object sender, EventArgs e); {
         public EventHandler(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(object sender, EventArgs e, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(object sender, EventArgs e);
     }
     public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e); {
         public EventHandler(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(object sender, TEventArgs e, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(object sender, TEventArgs e);
     }
     public class Exception {
         public Exception();
         public Exception(string message);
         public Exception(string message, Exception innerException);
         public virtual IDictionary Data { get; }
         public virtual string HelpLink { get; set; }
         public int HResult { get; protected set; }
         public Exception InnerException { get; }
         public virtual string Message { get; }
         public virtual string Source { get; set; }
         public virtual string StackTrace { get; }
         public virtual Exception GetBaseException();
         public override string ToString();
     }
     public class FlagsAttribute : Attribute {
         public FlagsAttribute();
     }
     public class FormatException : Exception {
         public FormatException();
         public FormatException(string message);
         public FormatException(string message, Exception innerException);
     }
     public delegate TResult Func<out TResult>(); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke();
     }
     public delegate TResult Func<in T, out TResult>(T arg); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T arg, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T arg);
     }
     public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2);
     }
     public delegate TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);
     }
     public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16); {
         public Func(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, AsyncCallback callback, object @object);
         public virtual TResult EndInvoke(IAsyncResult result);
         public virtual TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);
     }
     public static class GC {
         public static int MaxGeneration { get; }
         public static void AddMemoryPressure(long bytesAllocated);
         public static void Collect();
         public static void Collect(int generation);
         public static void Collect(int generation, GCCollectionMode mode);
         public static void Collect(int generation, GCCollectionMode mode, bool blocking);
         public static int CollectionCount(int generation);
         public static long GetTotalMemory(bool forceFullCollection);
         public static void KeepAlive(object obj);
         public static void RemoveMemoryPressure(long bytesAllocated);
         public static void ReRegisterForFinalize(object obj);
         public static void SuppressFinalize(object obj);
         public static void WaitForPendingFinalizers();
     }
     public enum GCCollectionMode {
         Default = 0,
         Forced = 1,
         Optimized = 2,
     }
     public struct Guid : IComparable, IComparable<Guid>, IEquatable<Guid>, IFormattable {
         public static readonly Guid Empty;
         public Guid(byte[] b);
         public Guid(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k);
         public Guid(int a, short b, short c, byte[] d);
         public Guid(string g);
         public int CompareTo(Guid value);
         public bool Equals(Guid g);
         public override bool Equals(object o);
         public override int GetHashCode();
         public static Guid NewGuid();
         public static bool operator ==(Guid a, Guid b);
         public static bool operator !=(Guid a, Guid b);
         public static Guid Parse(string input);
         public static Guid ParseExact(string input, string format);
         public byte[] ToByteArray();
         public override string ToString();
         public string ToString(string format);
         public static bool TryParse(string input, out Guid result);
         public static bool TryParseExact(string input, string format, out Guid result);
     }
     public interface IAsyncResult {
         object AsyncState { get; }
         WaitHandle AsyncWaitHandle { get; }
         bool CompletedSynchronously { get; }
         bool IsCompleted { get; }
     }
     public interface IComparable {
         int CompareTo(object obj);
     }
     public interface IComparable<in T> {
         int CompareTo(T other);
     }
     public interface ICustomFormatter {
         string Format(string format, object arg, IFormatProvider formatProvider);
     }
     public interface IDisposable {
         void Dispose();
     }
     public interface IEquatable<T> {
         bool Equals(T other);
     }
     public interface IFormatProvider {
         object GetFormat(Type formatType);
     }
     public interface IFormattable {
         string ToString(string format, IFormatProvider formatProvider);
     }
     public sealed class IndexOutOfRangeException : Exception {
         public IndexOutOfRangeException();
         public IndexOutOfRangeException(string message);
         public IndexOutOfRangeException(string message, Exception innerException);
     }
     public struct Int16 : IComparable, IComparable<short>, IEquatable<short>, IFormattable {
         public const short MaxValue = (short)32767;
         public const short MinValue = (short)-32768;
         public int CompareTo(short value);
         public bool Equals(short obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static short Parse(string s);
         public static short Parse(string s, IFormatProvider provider);
         public static short Parse(string s, NumberStyles style);
         public static short Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, out short result);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out short result);
     }
     public struct Int32 : IComparable, IComparable<int>, IEquatable<int>, IFormattable {
         public const int MaxValue = 2147483647;
         public const int MinValue = -2147483648;
         public int CompareTo(int value);
         public bool Equals(int obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static int Parse(string s);
         public static int Parse(string s, IFormatProvider provider);
         public static int Parse(string s, NumberStyles style);
         public static int Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, out int result);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out int result);
     }
     public struct Int64 : IComparable, IComparable<long>, IEquatable<long>, IFormattable {
         public const long MaxValue = (long)9223372036854775807;
         public const long MinValue = (long)-9223372036854775808;
         public int CompareTo(long value);
         public bool Equals(long obj);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static long Parse(string s);
         public static long Parse(string s, IFormatProvider provider);
         public static long Parse(string s, NumberStyles style);
         public static long Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, out long result);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out long result);
     }
     public struct IntPtr {
         public static readonly IntPtr Zero;
         public IntPtr(int value);
         public IntPtr(long value);
         public unsafe IntPtr(void* value);
         public static int Size { get; }
         public static IntPtr Add(IntPtr pointer, int offset);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static IntPtr operator +(IntPtr pointer, int offset);
         public static bool operator ==(IntPtr value1, IntPtr value2);
         public static explicit operator IntPtr (int value);
         public static explicit operator IntPtr (long value);
         public static explicit operator int (IntPtr value);
         public static explicit operator long (IntPtr value);
         public unsafe static explicit operator void* (IntPtr value);
         public unsafe static explicit operator IntPtr (void* value);
         public static bool operator !=(IntPtr value1, IntPtr value2);
         public static IntPtr operator -(IntPtr pointer, int offset);
         public static IntPtr Subtract(IntPtr pointer, int offset);
         public int ToInt32();
         public long ToInt64();
         public unsafe void* ToPointer();
         public override string ToString();
         public string ToString(string format);
     }
     public class InvalidCastException : Exception {
         public InvalidCastException();
         public InvalidCastException(string message);
         public InvalidCastException(string message, Exception innerException);
         public InvalidCastException(string message, int errorCode);
     }
     public class InvalidOperationException : Exception {
         public InvalidOperationException();
         public InvalidOperationException(string message);
         public InvalidOperationException(string message, Exception innerException);
     }
     public class InvalidTimeZoneException : Exception {
         public InvalidTimeZoneException();
         public InvalidTimeZoneException(string message);
         public InvalidTimeZoneException(string message, Exception innerException);
     }
     public interface IObservable<out T> {
         IDisposable Subscribe(IObserver<T> observer);
     }
     public interface IObserver<in T> {
         void OnCompleted();
         void OnError(Exception error);
         void OnNext(T value);
     }
     public interface IProgress<in T> {
         void Report(T value);
     }
     public class Lazy<T> {
         public Lazy();
         public Lazy(bool isThreadSafe);
         public Lazy(Func<T> valueFactory);
         public Lazy(Func<T> valueFactory, bool isThreadSafe);
         public Lazy(Func<T> valueFactory, LazyThreadSafetyMode mode);
         public Lazy(LazyThreadSafetyMode mode);
         public bool IsValueCreated { get; }
         public T Value { get; }
         public override string ToString();
     }
     public class Lazy<T, TMetadata> : Lazy<T> {
         public Lazy(Func<T> valueFactory, TMetadata metadata);
         public Lazy(Func<T> valueFactory, TMetadata metadata, bool isThreadSafe);
         public Lazy(Func<T> valueFactory, TMetadata metadata, LazyThreadSafetyMode mode);
         public Lazy(TMetadata metadata);
         public Lazy(TMetadata metadata, bool isThreadSafe);
         public Lazy(TMetadata metadata, LazyThreadSafetyMode mode);
         public TMetadata Metadata { get; }
     }
     public static class Math {
         public const double E = 2.7182818284590451;
         public const double PI = 3.1415926535897931;
         public static decimal Abs(decimal value);
         public static double Abs(double value);
         public static short Abs(short value);
         public static int Abs(int value);
         public static long Abs(long value);
         public static sbyte Abs(sbyte value);
         public static float Abs(float value);
         public static double Acos(double d);
         public static double Asin(double d);
         public static double Atan(double d);
         public static double Atan2(double y, double x);
         public static decimal Ceiling(decimal d);
         public static double Ceiling(double a);
         public static double Cos(double d);
         public static double Cosh(double value);
         public static double Exp(double d);
         public static decimal Floor(decimal d);
         public static double Floor(double d);
         public static double IEEERemainder(double x, double y);
         public static double Log(double d);
         public static double Log(double a, double newBase);
         public static double Log10(double d);
         public static byte Max(byte val1, byte val2);
         public static decimal Max(decimal val1, decimal val2);
         public static double Max(double val1, double val2);
         public static short Max(short val1, short val2);
         public static int Max(int val1, int val2);
         public static long Max(long val1, long val2);
         public static sbyte Max(sbyte val1, sbyte val2);
         public static float Max(float val1, float val2);
         public static ushort Max(ushort val1, ushort val2);
         public static uint Max(uint val1, uint val2);
         public static ulong Max(ulong val1, ulong val2);
         public static byte Min(byte val1, byte val2);
         public static decimal Min(decimal val1, decimal val2);
         public static double Min(double val1, double val2);
         public static short Min(short val1, short val2);
         public static int Min(int val1, int val2);
         public static long Min(long val1, long val2);
         public static sbyte Min(sbyte val1, sbyte val2);
         public static float Min(float val1, float val2);
         public static ushort Min(ushort val1, ushort val2);
         public static uint Min(uint val1, uint val2);
         public static ulong Min(ulong val1, ulong val2);
         public static double Pow(double x, double y);
         public static decimal Round(decimal d);
         public static decimal Round(decimal d, int decimals);
         public static decimal Round(decimal d, int decimals, MidpointRounding mode);
         public static decimal Round(decimal d, MidpointRounding mode);
         public static double Round(double a);
         public static double Round(double value, int digits);
         public static double Round(double value, int digits, MidpointRounding mode);
         public static double Round(double value, MidpointRounding mode);
         public static int Sign(decimal value);
         public static int Sign(double value);
         public static int Sign(short value);
         public static int Sign(int value);
         public static int Sign(long value);
         public static int Sign(sbyte value);
         public static int Sign(float value);
         public static double Sin(double a);
         public static double Sinh(double value);
         public static double Sqrt(double d);
         public static double Tan(double a);
         public static double Tanh(double value);
         public static decimal Truncate(decimal d);
         public static double Truncate(double d);
     }
     public class MemberAccessException : Exception {
         public MemberAccessException();
         public MemberAccessException(string message);
         public MemberAccessException(string message, Exception inner);
     }
     public enum MidpointRounding {
         AwayFromZero = 1,
         ToEven = 0,
     }
     public class MissingMemberException : MemberAccessException {
         public MissingMemberException();
         public MissingMemberException(string message);
         public MissingMemberException(string message, Exception inner);
         public override string Message { get; }
     }
     public sealed class MTAThreadAttribute : Attribute {
         public MTAThreadAttribute();
     }
     public abstract class MulticastDelegate : Delegate {
         public sealed override bool Equals(object obj);
         public sealed override int GetHashCode();
         public sealed override Delegate[] GetInvocationList();
         public static bool operator ==(MulticastDelegate d1, MulticastDelegate d2);
         public static bool operator !=(MulticastDelegate d1, MulticastDelegate d2);
     }
     public class NotImplementedException : Exception {
         public NotImplementedException();
         public NotImplementedException(string message);
         public NotImplementedException(string message, Exception inner);
     }
     public class NotSupportedException : Exception {
         public NotSupportedException();
         public NotSupportedException(string message);
         public NotSupportedException(string message, Exception innerException);
     }
     public static class Nullable {
         public static int Compare<T>(Nullable<T> n1, Nullable<T> n2) where T : struct;
         public static bool Equals<T>(Nullable<T> n1, Nullable<T> n2) where T : struct;
         public static Type GetUnderlyingType(Type nullableType);
     }
     public struct Nullable<T> where T : struct {
         public Nullable(T value);
         public bool HasValue { get; }
         public T Value { get; }
         public override bool Equals(object other);
         public override int GetHashCode();
         public T GetValueOrDefault();
         public T GetValueOrDefault(T defaultValue);
         public static explicit operator T (Nullable<T> value);
         public static implicit operator Nullable<T> (T value);
         public override string ToString();
     }
     public class NullReferenceException : Exception {
         public NullReferenceException();
         public NullReferenceException(string message);
         public NullReferenceException(string message, Exception innerException);
     }
     public class Object {
         public Object();
         public virtual bool Equals(object obj);
         public static bool Equals(object objA, object objB);
         ~Object();
         public virtual int GetHashCode();
         public Type GetType();
         protected object MemberwiseClone();
         public static bool ReferenceEquals(object objA, object objB);
         public virtual string ToString();
     }
     public class ObjectDisposedException : InvalidOperationException {
         public ObjectDisposedException(string objectName);
         public ObjectDisposedException(string message, Exception innerException);
         public ObjectDisposedException(string objectName, string message);
         public override string Message { get; }
         public string ObjectName { get; }
     }
     public sealed class ObsoleteAttribute : Attribute {
         public ObsoleteAttribute();
         public ObsoleteAttribute(string message);
         public ObsoleteAttribute(string message, bool error);
         public bool IsError { get; }
         public string Message { get; }
     }
     public class OperationCanceledException : Exception {
         public OperationCanceledException();
         public OperationCanceledException(CancellationToken token);
         public OperationCanceledException(string message);
         public OperationCanceledException(string message, CancellationToken token);
         public OperationCanceledException(string message, Exception innerException);
         public OperationCanceledException(string message, Exception innerException, CancellationToken token);
         public CancellationToken CancellationToken { get; }
     }
     public class OutOfMemoryException : Exception {
         public OutOfMemoryException();
         public OutOfMemoryException(string message);
         public OutOfMemoryException(string message, Exception innerException);
     }
     public class OverflowException : ArithmeticException {
         public OverflowException();
         public OverflowException(string message);
         public OverflowException(string message, Exception innerException);
     }
     public sealed class ParamArrayAttribute : Attribute {
         public ParamArrayAttribute();
     }
     public class PlatformNotSupportedException : NotSupportedException {
         public PlatformNotSupportedException();
         public PlatformNotSupportedException(string message);
         public PlatformNotSupportedException(string message, Exception inner);
     }
     public delegate bool Predicate<in T>(T obj); {
         public Predicate(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(T obj, AsyncCallback callback, object @object);
         public virtual bool EndInvoke(IAsyncResult result);
         public virtual bool Invoke(T obj);
     }
     public class Progress<T> : IProgress<T> {
         public Progress();
         public Progress(Action<T> handler);
         protected virtual void OnReport(T value);
         public event EventHandler<T> ProgressChanged;
     }
     public class Random {
         public Random();
         public Random(int Seed);
         public virtual int Next();
         public virtual int Next(int maxValue);
         public virtual int Next(int minValue, int maxValue);
         public virtual void NextBytes(byte[] buffer);
         public virtual double NextDouble();
         protected virtual double Sample();
     }
     public class RankException : Exception {
         public RankException();
         public RankException(string message);
         public RankException(string message, Exception innerException);
     }
     public struct RuntimeFieldHandle {
         public override bool Equals(object obj);
         public bool Equals(RuntimeFieldHandle handle);
         public override int GetHashCode();
         public static bool operator ==(RuntimeFieldHandle left, RuntimeFieldHandle right);
         public static bool operator !=(RuntimeFieldHandle left, RuntimeFieldHandle right);
     }
     public struct RuntimeMethodHandle {
         public override bool Equals(object obj);
         public bool Equals(RuntimeMethodHandle handle);
         public override int GetHashCode();
         public static bool operator ==(RuntimeMethodHandle left, RuntimeMethodHandle right);
         public static bool operator !=(RuntimeMethodHandle left, RuntimeMethodHandle right);
     }
     public struct RuntimeTypeHandle {
         public override bool Equals(object obj);
         public bool Equals(RuntimeTypeHandle handle);
         public override int GetHashCode();
         public static bool operator ==(object left, RuntimeTypeHandle right);
         public static bool operator ==(RuntimeTypeHandle left, object right);
         public static bool operator !=(object left, RuntimeTypeHandle right);
         public static bool operator !=(RuntimeTypeHandle left, object right);
     }
     public struct SByte : IComparable, IComparable<sbyte>, IEquatable<sbyte>, IFormattable {
         public const sbyte MaxValue = (sbyte)127;
         public const sbyte MinValue = (sbyte)-128;
         public int CompareTo(sbyte value);
         public override bool Equals(object obj);
         public bool Equals(sbyte obj);
         public override int GetHashCode();
         public static sbyte Parse(string s);
         public static sbyte Parse(string s, IFormatProvider provider);
         public static sbyte Parse(string s, NumberStyles style);
         public static sbyte Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out sbyte result);
         public static bool TryParse(string s, out sbyte result);
     }
     public struct Single : IComparable, IComparable<float>, IEquatable<float>, IFormattable {
         public const float Epsilon = 1.401298E-45f;
         public const float MaxValue = 3.40282347E+38f;
         public const float MinValue = -3.40282347E+38f;
         public const float NaN = 0.0f / 0.0f;
         public const float NegativeInfinity = -1.0f / 0.0f;
         public const float PositiveInfinity = 1.0f / 0.0f;
         public int CompareTo(float value);
         public override bool Equals(object obj);
         public bool Equals(float obj);
         public override int GetHashCode();
         public static bool IsInfinity(float f);
         public static bool IsNaN(float f);
         public static bool IsNegativeInfinity(float f);
         public static bool IsPositiveInfinity(float f);
         public static bool operator ==(float left, float right);
         public static bool operator >(float left, float right);
         public static bool operator >=(float left, float right);
         public static bool operator !=(float left, float right);
         public static bool operator <(float left, float right);
         public static bool operator <=(float left, float right);
         public static float Parse(string s);
         public static float Parse(string s, IFormatProvider provider);
         public static float Parse(string s, NumberStyles style);
         public static float Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out float result);
         public static bool TryParse(string s, out float result);
     }
     public sealed class STAThreadAttribute : Attribute {
         public STAThreadAttribute();
     }
     public sealed class String : IComparable, IComparable<string>, IEnumerable, IEquatable<string> {
         public static readonly string Empty;
         public unsafe String(char* value);
         public unsafe String(char* value, int startIndex, int length);
         public String(char c, int count);
         public String(char[] value);
         public String(char[] value, int startIndex, int length);
         public char this[int index] { get; }
         public int Length { get; }
         public static int Compare(string strA, int indexA, string strB, int indexB, int length);
         public static int Compare(string strA, int indexA, string strB, int indexB, int length, StringComparison comparisonType);
         public static int Compare(string strA, string strB);
         public static int Compare(string strA, string strB, StringComparison comparisonType);
         public static int CompareOrdinal(string strA, int indexA, string strB, int indexB, int length);
         public static int CompareOrdinal(string strA, string strB);
         public int CompareTo(string strB);
         public static string Concat<T>(IEnumerable<T> values);
         public static string Concat(IEnumerable<string> values);
         public static string Concat(object arg0);
         public static string Concat(object arg0, object arg1);
         public static string Concat(object arg0, object arg1, object arg2);
         public static string Concat(params object[] args);
         public static string Concat(string str0, string str1);
         public static string Concat(string str0, string str1, string str2);
         public static string Concat(string str0, string str1, string str2, string str3);
         public static string Concat(params string[] values);
         public bool Contains(string value);
         public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
         public bool EndsWith(string value);
         public bool EndsWith(string value, StringComparison comparisonType);
         public override bool Equals(object obj);
         public bool Equals(string value);
         public static bool Equals(string a, string b);
         public static bool Equals(string a, string b, StringComparison comparisonType);
         public bool Equals(string value, StringComparison comparisonType);
         public static string Format(IFormatProvider provider, string format, params object[] args);
         public static string Format(string format, params object[] args);
         public override int GetHashCode();
         public int IndexOf(char value);
         public int IndexOf(char value, int startIndex);
         public int IndexOf(char value, int startIndex, int count);
         public int IndexOf(string value);
         public int IndexOf(string value, int startIndex);
         public int IndexOf(string value, int startIndex, int count);
         public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType);
         public int IndexOf(string value, int startIndex, StringComparison comparisonType);
         public int IndexOf(string value, StringComparison comparisonType);
         public int IndexOfAny(char[] anyOf);
         public int IndexOfAny(char[] anyOf, int startIndex);
         public int IndexOfAny(char[] anyOf, int startIndex, int count);
         public string Insert(int startIndex, string value);
         public static bool IsNullOrEmpty(string value);
         public static bool IsNullOrWhiteSpace(string value);
         public static string Join<T>(string separator, IEnumerable<T> values);
         public static string Join(string separator, IEnumerable<string> values);
         public static string Join(string separator, params object[] values);
         public static string Join(string separator, params string[] value);
         public static string Join(string separator, string[] value, int startIndex, int count);
         public int LastIndexOf(char value);
         public int LastIndexOf(char value, int startIndex);
         public int LastIndexOf(char value, int startIndex, int count);
         public int LastIndexOf(string value);
         public int LastIndexOf(string value, int startIndex);
         public int LastIndexOf(string value, int startIndex, int count);
         public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType);
         public int LastIndexOf(string value, int startIndex, StringComparison comparisonType);
         public int LastIndexOf(string value, StringComparison comparisonType);
         public int LastIndexOfAny(char[] anyOf);
         public int LastIndexOfAny(char[] anyOf, int startIndex);
         public int LastIndexOfAny(char[] anyOf, int startIndex, int count);
         public static bool operator ==(string a, string b);
         public static bool operator !=(string a, string b);
         public string PadLeft(int totalWidth);
         public string PadLeft(int totalWidth, char paddingChar);
         public string PadRight(int totalWidth);
         public string PadRight(int totalWidth, char paddingChar);
         public string Remove(int startIndex);
         public string Remove(int startIndex, int count);
         public string Replace(char oldChar, char newChar);
         public string Replace(string oldValue, string newValue);
         public string[] Split(params char[] separator);
         public string[] Split(char[] separator, int count);
         public string[] Split(char[] separator, int count, StringSplitOptions options);
         public string[] Split(char[] separator, StringSplitOptions options);
         public string[] Split(string[] separator, int count, StringSplitOptions options);
         public string[] Split(string[] separator, StringSplitOptions options);
         public bool StartsWith(string value);
         public bool StartsWith(string value, StringComparison comparisonType);
         public string Substring(int startIndex);
         public string Substring(int startIndex, int length);
         public char[] ToCharArray();
         public char[] ToCharArray(int startIndex, int length);
         public string ToLower();
         public string ToLowerInvariant();
         public override string ToString();
         public string ToUpper();
         public string ToUpperInvariant();
         public string Trim();
         public string Trim(params char[] trimChars);
         public string TrimEnd(params char[] trimChars);
         public string TrimStart(params char[] trimChars);
     }
     public abstract class StringComparer : IComparer, IComparer<string>, IEqualityComparer, IEqualityComparer<string> {
         protected StringComparer();
         public static StringComparer CurrentCulture { get; }
         public static StringComparer CurrentCultureIgnoreCase { get; }
         public static StringComparer Ordinal { get; }
         public static StringComparer OrdinalIgnoreCase { get; }
         public abstract int Compare(string x, string y);
         public abstract bool Equals(string x, string y);
         public abstract int GetHashCode(string obj);
     }
     public enum StringComparison {
         CurrentCulture = 0,
         CurrentCultureIgnoreCase = 1,
         Ordinal = 4,
         OrdinalIgnoreCase = 5,
     }
     public enum StringSplitOptions {
         None = 0,
         RemoveEmptyEntries = 1,
     }
     public class ThreadStaticAttribute : Attribute {
         public ThreadStaticAttribute();
     }
     public class TimeoutException : Exception {
         public TimeoutException();
         public TimeoutException(string message);
         public TimeoutException(string message, Exception innerException);
     }
     public struct TimeSpan : IComparable, IComparable<TimeSpan>, IEquatable<TimeSpan>, IFormattable {
         public static readonly TimeSpan MaxValue;
         public static readonly TimeSpan MinValue;
         public const long TicksPerDay = (long)864000000000;
         public const long TicksPerHour = (long)36000000000;
         public const long TicksPerMillisecond = (long)10000;
         public const long TicksPerMinute = (long)600000000;
         public const long TicksPerSecond = (long)10000000;
         public static readonly TimeSpan Zero;
         public TimeSpan(int hours, int minutes, int seconds);
         public TimeSpan(int days, int hours, int minutes, int seconds);
         public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);
         public TimeSpan(long ticks);
         public int Days { get; }
         public int Hours { get; }
         public int Milliseconds { get; }
         public int Minutes { get; }
         public int Seconds { get; }
         public long Ticks { get; }
         public double TotalDays { get; }
         public double TotalHours { get; }
         public double TotalMilliseconds { get; }
         public double TotalMinutes { get; }
         public double TotalSeconds { get; }
         public TimeSpan Add(TimeSpan ts);
         public static int Compare(TimeSpan t1, TimeSpan t2);
         public int CompareTo(TimeSpan value);
         public TimeSpan Duration();
         public override bool Equals(object value);
         public bool Equals(TimeSpan obj);
         public static bool Equals(TimeSpan t1, TimeSpan t2);
         public static TimeSpan FromDays(double value);
         public static TimeSpan FromHours(double value);
         public static TimeSpan FromMilliseconds(double value);
         public static TimeSpan FromMinutes(double value);
         public static TimeSpan FromSeconds(double value);
         public static TimeSpan FromTicks(long value);
         public override int GetHashCode();
         public TimeSpan Negate();
         public static TimeSpan operator +(TimeSpan t1, TimeSpan t2);
         public static bool operator ==(TimeSpan t1, TimeSpan t2);
         public static bool operator >(TimeSpan t1, TimeSpan t2);
         public static bool operator >=(TimeSpan t1, TimeSpan t2);
         public static bool operator !=(TimeSpan t1, TimeSpan t2);
         public static bool operator <(TimeSpan t1, TimeSpan t2);
         public static bool operator <=(TimeSpan t1, TimeSpan t2);
         public static TimeSpan operator -(TimeSpan t1, TimeSpan t2);
         public static TimeSpan operator -(TimeSpan t);
         public static TimeSpan operator +(TimeSpan t);
         public static TimeSpan Parse(string s);
         public static TimeSpan Parse(string input, IFormatProvider formatProvider);
         public static TimeSpan ParseExact(string input, string format, IFormatProvider formatProvider);
         public static TimeSpan ParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles);
         public static TimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider);
         public static TimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles);
         public TimeSpan Subtract(TimeSpan ts);
         public override string ToString();
         public string ToString(string format);
         public string ToString(string format, IFormatProvider formatProvider);
         public static bool TryParse(string input, IFormatProvider formatProvider, out TimeSpan result);
         public static bool TryParse(string s, out TimeSpan result);
         public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, out TimeSpan result);
         public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles, out TimeSpan result);
         public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, out TimeSpan result);
         public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles, out TimeSpan result);
     }
     public sealed class TimeZoneInfo : IEquatable<TimeZoneInfo> {
         public TimeSpan BaseUtcOffset { get; }
         public string DaylightName { get; }
         public string DisplayName { get; }
         public static TimeZoneInfo Local { get; }
         public string StandardName { get; }
         public bool SupportsDaylightSavingTime { get; }
         public static TimeZoneInfo Utc { get; }
         public static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo destinationTimeZone);
         public static DateTimeOffset ConvertTime(DateTimeOffset dateTimeOffset, TimeZoneInfo destinationTimeZone);
         public bool Equals(TimeZoneInfo other);
         public TimeSpan[] GetAmbiguousTimeOffsets(DateTime dateTime);
         public TimeSpan[] GetAmbiguousTimeOffsets(DateTimeOffset dateTimeOffset);
         public override int GetHashCode();
         public TimeSpan GetUtcOffset(DateTime dateTime);
         public TimeSpan GetUtcOffset(DateTimeOffset dateTimeOffset);
         public bool IsAmbiguousTime(DateTime dateTime);
         public bool IsAmbiguousTime(DateTimeOffset dateTimeOffset);
         public bool IsDaylightSavingTime(DateTime dateTime);
         public bool IsDaylightSavingTime(DateTimeOffset dateTimeOffset);
         public bool IsInvalidTime(DateTime dateTime);
         public override string ToString();
     }
     public static class Tuple {
         public static Tuple<T1> Create<T1>(T1 item1);
         public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2);
         public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3);
         public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4);
         public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5);
         public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6);
         public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7);
         public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8);
     }
     public class Tuple<T1> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1);
         public T1 Item1 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2, T3> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2, T3 item3);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public T3 Item3 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2, T3, T4> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2, T3 item3, T4 item4);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public T3 Item3 { get; }
         public T4 Item4 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2, T3, T4, T5> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public T3 Item3 { get; }
         public T4 Item4 { get; }
         public T5 Item5 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2, T3, T4, T5, T6> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public T3 Item3 { get; }
         public T4 Item4 { get; }
         public T5 Item5 { get; }
         public T6 Item6 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2, T3, T4, T5, T6, T7> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public T3 Item3 { get; }
         public T4 Item4 { get; }
         public T5 Item5 { get; }
         public T6 Item6 { get; }
         public T7 Item7 { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IComparable, IStructuralComparable, IStructuralEquatable {
         public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest);
         public T1 Item1 { get; }
         public T2 Item2 { get; }
         public T3 Item3 { get; }
         public T4 Item4 { get; }
         public T5 Item5 { get; }
         public T6 Item6 { get; }
         public T7 Item7 { get; }
         public TRest Rest { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public abstract class Type {
         public static readonly object Missing;
         public abstract string AssemblyQualifiedName { get; }
         public abstract Type DeclaringType { get; }
         public abstract string FullName { get; }
         public abstract int GenericParameterPosition { get; }
         public abstract Type[] GenericTypeArguments { get; }
         public bool HasElementType { get; }
         public bool IsArray { get; }
         public bool IsByRef { get; }
         public abstract bool IsConstructedGenericType { get; }
         public abstract bool IsGenericParameter { get; }
         public bool IsNested { get; }
         public bool IsPointer { get; }
         public abstract string Name { get; }
         public abstract string Namespace { get; }
         public virtual RuntimeTypeHandle TypeHandle { get; }
         public override bool Equals(object o);
         public bool Equals(Type o);
         public abstract int GetArrayRank();
         public abstract Type GetElementType();
         public abstract Type GetGenericTypeDefinition();
         public override int GetHashCode();
         public static Type GetType(string typeName);
         public static Type GetType(string typeName, bool throwOnError);
         public static Type GetTypeFromHandle(RuntimeTypeHandle handle);
         public abstract Type MakeArrayType();
         public abstract Type MakeArrayType(int rank);
         public abstract Type MakeByRefType();
         public abstract Type MakeGenericType(params Type[] typeArguments);
         public abstract Type MakePointerType();
         public override string ToString();
     }
     public class TypeAccessException : TypeLoadException {
         public TypeAccessException();
         public TypeAccessException(string message);
         public TypeAccessException(string message, Exception inner);
     }
     public sealed class TypeInitializationException : Exception {
         public TypeInitializationException(string fullTypeName, Exception innerException);
         public string TypeName { get; }
     }
     public class TypeLoadException : Exception {
         public TypeLoadException();
         public TypeLoadException(string message);
         public TypeLoadException(string message, Exception inner);
         public override string Message { get; }
         public string TypeName { get; }
     }
     public struct UInt16 : IComparable, IComparable<ushort>, IEquatable<ushort>, IFormattable {
         public const ushort MaxValue = (ushort)65535;
         public const ushort MinValue = (ushort)0;
         public int CompareTo(ushort value);
         public override bool Equals(object obj);
         public bool Equals(ushort obj);
         public override int GetHashCode();
         public static ushort Parse(string s);
         public static ushort Parse(string s, IFormatProvider provider);
         public static ushort Parse(string s, NumberStyles style);
         public static ushort Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ushort result);
         public static bool TryParse(string s, out ushort result);
     }
     public struct UInt32 : IComparable, IComparable<uint>, IEquatable<uint>, IFormattable {
         public const uint MaxValue = (uint)4294967295;
         public const uint MinValue = (uint)0;
         public int CompareTo(uint value);
         public override bool Equals(object obj);
         public bool Equals(uint obj);
         public override int GetHashCode();
         public static uint Parse(string s);
         public static uint Parse(string s, IFormatProvider provider);
         public static uint Parse(string s, NumberStyles style);
         public static uint Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out uint result);
         public static bool TryParse(string s, out uint result);
     }
     public struct UInt64 : IComparable, IComparable<ulong>, IEquatable<ulong>, IFormattable {
         public const ulong MaxValue = (ulong)18446744073709551615;
         public const ulong MinValue = (ulong)0;
         public int CompareTo(ulong value);
         public override bool Equals(object obj);
         public bool Equals(ulong obj);
         public override int GetHashCode();
         public static ulong Parse(string s);
         public static ulong Parse(string s, IFormatProvider provider);
         public static ulong Parse(string s, NumberStyles style);
         public static ulong Parse(string s, NumberStyles style, IFormatProvider provider);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ulong result);
         public static bool TryParse(string s, out ulong result);
     }
     public struct UIntPtr {
         public static readonly UIntPtr Zero;
         public UIntPtr(uint value);
         public UIntPtr(ulong value);
         public unsafe UIntPtr(void* value);
         public static int Size { get; }
         public static UIntPtr Add(UIntPtr pointer, int offset);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static UIntPtr operator +(UIntPtr pointer, int offset);
         public static bool operator ==(UIntPtr value1, UIntPtr value2);
         public static explicit operator UIntPtr (uint value);
         public static explicit operator UIntPtr (ulong value);
         public static explicit operator uint (UIntPtr value);
         public static explicit operator ulong (UIntPtr value);
         public unsafe static explicit operator void* (UIntPtr value);
         public unsafe static explicit operator UIntPtr (void* value);
         public static bool operator !=(UIntPtr value1, UIntPtr value2);
         public static UIntPtr operator -(UIntPtr pointer, int offset);
         public static UIntPtr Subtract(UIntPtr pointer, int offset);
         public unsafe void* ToPointer();
         public override string ToString();
         public uint ToUInt32();
         public ulong ToUInt64();
     }
     public class UnauthorizedAccessException : Exception {
         public UnauthorizedAccessException();
         public UnauthorizedAccessException(string message);
         public UnauthorizedAccessException(string message, Exception inner);
     }
     public class Uri {
         public Uri(string uriString);
         public Uri(string uriString, UriKind uriKind);
         public Uri(Uri baseUri, string relativeUri);
         public Uri(Uri baseUri, Uri relativeUri);
         public string AbsolutePath { get; }
         public string AbsoluteUri { get; }
         public string Authority { get; }
         public string DnsSafeHost { get; }
         public string Fragment { get; }
         public string Host { get; }
         public UriHostNameType HostNameType { get; }
         public bool IsAbsoluteUri { get; }
         public bool IsDefaultPort { get; }
         public bool IsFile { get; }
         public bool IsLoopback { get; }
         public bool IsUnc { get; }
         public string LocalPath { get; }
         public string OriginalString { get; }
         public string PathAndQuery { get; }
         public int Port { get; }
         public string Query { get; }
         public string Scheme { get; }
         public string[] Segments { get; }
         public bool UserEscaped { get; }
         public string UserInfo { get; }
         public static UriHostNameType CheckHostName(string name);
         public static bool CheckSchemeName(string schemeName);
         public static int Compare(Uri uri1, Uri uri2, UriComponents partsToCompare, UriFormat compareFormat, StringComparison comparisonType);
         public override bool Equals(object comparand);
         public static string EscapeDataString(string stringToEscape);
         public static string EscapeUriString(string stringToEscape);
         public string GetComponents(UriComponents components, UriFormat format);
         public override int GetHashCode();
         public bool IsBaseOf(Uri uri);
         public bool IsWellFormedOriginalString();
         public static bool IsWellFormedUriString(string uriString, UriKind uriKind);
         public Uri MakeRelativeUri(Uri uri);
         public static bool operator ==(Uri uri1, Uri uri2);
         public static bool operator !=(Uri uri1, Uri uri2);
         public override string ToString();
         public static bool TryCreate(string uriString, UriKind uriKind, out Uri result);
         public static bool TryCreate(Uri baseUri, string relativeUri, out Uri result);
         public static bool TryCreate(Uri baseUri, Uri relativeUri, out Uri result);
         public static string UnescapeDataString(string stringToUnescape);
     }
     public class UriBuilder {
         public UriBuilder();
         public UriBuilder(string uri);
         public UriBuilder(string schemeName, string hostName);
         public UriBuilder(string scheme, string host, int portNumber);
         public UriBuilder(string scheme, string host, int port, string pathValue);
         public UriBuilder(string scheme, string host, int port, string path, string extraValue);
         public UriBuilder(Uri uri);
         public string Fragment { get; set; }
         public string Host { get; set; }
         public string Password { get; set; }
         public string Path { get; set; }
         public int Port { get; set; }
         public string Query { get; set; }
         public string Scheme { get; set; }
         public Uri Uri { get; }
         public string UserName { get; set; }
         public override bool Equals(object rparam);
         public override int GetHashCode();
         public override string ToString();
     }
     public enum UriComponents {
         AbsoluteUri = 127,
         Fragment = 64,
         Host = 4,
         HostAndPort = 132,
         HttpRequestUrl = 61,
         KeepDelimiter = 1073741824,
         NormalizedHost = 256,
         Path = 16,
         PathAndQuery = 48,
         Port = 8,
         Query = 32,
         Scheme = 1,
         SchemeAndServer = 13,
         SerializationInfoString = -2147483648,
         StrongAuthority = 134,
         StrongPort = 128,
         UserInfo = 2,
     }
     public enum UriFormat {
         SafeUnescaped = 3,
         Unescaped = 2,
         UriEscaped = 1,
     }
     public enum UriHostNameType {
         Basic = 1,
         Dns = 2,
         IPv4 = 3,
         IPv6 = 4,
         Unknown = 0,
     }
     public enum UriKind {
         Absolute = 1,
         Relative = 2,
         RelativeOrAbsolute = 0,
     }
     public abstract class ValueType {
         protected ValueType();
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public sealed class Version : IComparable, IComparable<Version>, IEquatable<Version> {
         public Version(int major, int minor);
         public Version(int major, int minor, int build);
         public Version(int major, int minor, int build, int revision);
         public Version(string version);
         public int Build { get; }
         public int Major { get; }
         public short MajorRevision { get; }
         public int Minor { get; }
         public short MinorRevision { get; }
         public int Revision { get; }
         public int CompareTo(Version value);
         public override bool Equals(object obj);
         public bool Equals(Version obj);
         public override int GetHashCode();
         public static bool operator ==(Version v1, Version v2);
         public static bool operator >(Version v1, Version v2);
         public static bool operator >=(Version v1, Version v2);
         public static bool operator !=(Version v1, Version v2);
         public static bool operator <(Version v1, Version v2);
         public static bool operator <=(Version v1, Version v2);
         public static Version Parse(string input);
         public override string ToString();
         public string ToString(int fieldCount);
         public static bool TryParse(string input, out Version result);
     }
     public struct Void
     public class WeakReference {
         public WeakReference(object target);
         public WeakReference(object target, bool trackResurrection);
         public virtual bool IsAlive { get; }
         public virtual object Target { get; set; }
         public virtual bool TrackResurrection { get; }
         ~WeakReference();
     }
     public sealed class WeakReference<T> where T : class {
         public WeakReference(T target);
         public WeakReference(T target, bool trackResurrection);
         public void SetTarget(T target);
         public bool TryGetTarget(out T target);
     }
 }
 namespace System.CodeDom.Compiler {
     public sealed class GeneratedCodeAttribute : Attribute {
         public GeneratedCodeAttribute(string tool, string version);
         public string Tool { get; }
         public string Version { get; }
     }
 }
 namespace System.Collections {
     public sealed class BitArray : ICollection, IEnumerable {
         public BitArray(BitArray bits);
         public BitArray(bool[] values);
         public BitArray(byte[] bytes);
         public BitArray(int length);
         public BitArray(int length, bool defaultValue);
         public BitArray(int[] values);
         public bool this[int index] { get; set; }
         public int Length { get; set; }
         public BitArray And(BitArray value);
         public bool Get(int index);
         public IEnumerator GetEnumerator();
         public BitArray Not();
         public BitArray Or(BitArray value);
         public void Set(int index, bool value);
         public void SetAll(bool value);
         public BitArray Xor(BitArray value);
     }
     public struct DictionaryEntry {
         public DictionaryEntry(object key, object value);
         public object Key { get; set; }
         public object Value { get; set; }
     }
     public interface ICollection : IEnumerable {
         int Count { get; }
         bool IsSynchronized { get; }
         object SyncRoot { get; }
         void CopyTo(Array array, int index);
     }
     public interface IComparer {
         int Compare(object x, object y);
     }
     public interface IDictionary : ICollection, IEnumerable {
         bool IsFixedSize { get; }
         bool IsReadOnly { get; }
         object this[object key] { get; set; }
         ICollection Keys { get; }
         ICollection Values { get; }
         void Add(object key, object value);
         void Clear();
         bool Contains(object key);
         new IDictionaryEnumerator GetEnumerator();
         void Remove(object key);
     }
     public interface IDictionaryEnumerator : IEnumerator {
         DictionaryEntry Entry { get; }
         object Key { get; }
         object Value { get; }
     }
     public interface IEnumerable {
         IEnumerator GetEnumerator();
     }
     public interface IEnumerator {
         object Current { get; }
         bool MoveNext();
         void Reset();
     }
     public interface IEqualityComparer {
         bool Equals(object x, object y);
         int GetHashCode(object obj);
     }
     public interface IList : ICollection, IEnumerable {
         bool IsFixedSize { get; }
         bool IsReadOnly { get; }
         object this[int index] { get; set; }
         int Add(object value);
         void Clear();
         bool Contains(object value);
         int IndexOf(object value);
         void Insert(int index, object value);
         void Remove(object value);
         void RemoveAt(int index);
     }
     public interface IStructuralComparable {
         int CompareTo(object other, IComparer comparer);
     }
     public interface IStructuralEquatable {
         bool Equals(object other, IEqualityComparer comparer);
         int GetHashCode(IEqualityComparer comparer);
     }
     public static class StructuralComparisons {
         public static IComparer StructuralComparer { get; }
         public static IEqualityComparer StructuralEqualityComparer { get; }
     }
 }
 namespace System.Collections.Concurrent {
     public class BlockingCollection<T> : ICollection, IDisposable, IEnumerable, IEnumerable<T> {
         public BlockingCollection();
         public BlockingCollection(int boundedCapacity);
         public BlockingCollection(IProducerConsumerCollection<T> collection);
         public BlockingCollection(IProducerConsumerCollection<T> collection, int boundedCapacity);
         public int BoundedCapacity { get; }
         public int Count { get; }
         public bool IsAddingCompleted { get; }
         public bool IsCompleted { get; }
         public void Add(T item);
         public void Add(T item, CancellationToken cancellationToken);
         public static int AddToAny(BlockingCollection<T>[] collections, T item);
         public static int AddToAny(BlockingCollection<T>[] collections, T item, CancellationToken cancellationToken);
         public void CompleteAdding();
         public void CopyTo(T[] array, int index);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public IEnumerable<T> GetConsumingEnumerable();
         public IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken);
         public T Take();
         public T Take(CancellationToken cancellationToken);
         public static int TakeFromAny(BlockingCollection<T>[] collections, out T item);
         public static int TakeFromAny(BlockingCollection<T>[] collections, out T item, CancellationToken cancellationToken);
         public T[] ToArray();
         public bool TryAdd(T item);
         public bool TryAdd(T item, int millisecondsTimeout);
         public bool TryAdd(T item, int millisecondsTimeout, CancellationToken cancellationToken);
         public bool TryAdd(T item, TimeSpan timeout);
         public static int TryAddToAny(BlockingCollection<T>[] collections, T item);
         public static int TryAddToAny(BlockingCollection<T>[] collections, T item, int millisecondsTimeout);
         public static int TryAddToAny(BlockingCollection<T>[] collections, T item, TimeSpan timeout);
         public static int TryAddToAny(BlockingCollection<T>[] collections, T item, int millisecondsTimeout, CancellationToken cancellationToken);
         public bool TryTake(out T item);
         public bool TryTake(out T item, int millisecondsTimeout);
         public bool TryTake(out T item, int millisecondsTimeout, CancellationToken cancellationToken);
         public bool TryTake(out T item, TimeSpan timeout);
         public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item);
         public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, int millisecondsTimeout);
         public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, TimeSpan timeout);
         public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, int millisecondsTimeout, CancellationToken cancellationToken);
     }
     public class ConcurrentBag<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
         public ConcurrentBag();
         public ConcurrentBag(IEnumerable<T> collection);
         public int Count { get; }
         public bool IsEmpty { get; }
         public void Add(T item);
         public void CopyTo(T[] array, int index);
         public IEnumerator<T> GetEnumerator();
         public T[] ToArray();
         public bool TryPeek(out T result);
         public bool TryTake(out T result);
     }
     public class ConcurrentDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> {
         public ConcurrentDictionary();
         public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection);
         public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer);
         public ConcurrentDictionary(IEqualityComparer<TKey> comparer);
         public ConcurrentDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer);
         public ConcurrentDictionary(int concurrencyLevel, int capacity);
         public ConcurrentDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer);
         public int Count { get; }
         public bool IsEmpty { get; }
         public TValue this[TKey key] { get; set; }
         public ICollection<TKey> Keys { get; }
         public ICollection<TValue> Values { get; }
         public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory);
         public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);
         public void Clear();
         public bool ContainsKey(TKey key);
         public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
         public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);
         public TValue GetOrAdd(TKey key, TValue value);
         public KeyValuePair<TKey, TValue>[] ToArray();
         public bool TryAdd(TKey key, TValue value);
         public bool TryGetValue(TKey key, out TValue value);
         public bool TryRemove(TKey key, out TValue value);
         public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);
     }
     public class ConcurrentQueue<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
         public ConcurrentQueue();
         public ConcurrentQueue(IEnumerable<T> collection);
         public int Count { get; }
         public bool IsEmpty { get; }
         public void CopyTo(T[] array, int index);
         public void Enqueue(T item);
         public IEnumerator<T> GetEnumerator();
         public T[] ToArray();
         public bool TryDequeue(out T result);
         public bool TryPeek(out T result);
     }
     public class ConcurrentStack<T> : ICollection, IEnumerable, IEnumerable<T>, IProducerConsumerCollection<T> {
         public ConcurrentStack();
         public ConcurrentStack(IEnumerable<T> collection);
         public int Count { get; }
         public bool IsEmpty { get; }
         public void Clear();
         public void CopyTo(T[] array, int index);
         public IEnumerator<T> GetEnumerator();
         public void Push(T item);
         public void PushRange(T[] items);
         public void PushRange(T[] items, int startIndex, int count);
         public T[] ToArray();
         public bool TryPeek(out T result);
         public bool TryPop(out T result);
         public int TryPopRange(T[] items);
         public int TryPopRange(T[] items, int startIndex, int count);
     }
     public enum EnumerablePartitionerOptions {
         NoBuffering = 1,
         None = 0,
     }
     public interface IProducerConsumerCollection<T> : ICollection, IEnumerable, IEnumerable<T> {
         void CopyTo(T[] array, int index);
         T[] ToArray();
         bool TryAdd(T item);
         bool TryTake(out T item);
     }
     public abstract class OrderablePartitioner<TSource> : Partitioner<TSource> {
         protected OrderablePartitioner(bool keysOrderedInEachPartition, bool keysOrderedAcrossPartitions, bool keysNormalized);
         public bool KeysNormalized { get; }
         public bool KeysOrderedAcrossPartitions { get; }
         public bool KeysOrderedInEachPartition { get; }
         public override IEnumerable<TSource> GetDynamicPartitions();
         public virtual IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions();
         public abstract IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount);
         public override IList<IEnumerator<TSource>> GetPartitions(int partitionCount);
     }
     public static class Partitioner {
         public static OrderablePartitioner<TSource> Create<TSource>(TSource[] array, bool loadBalance);
         public static OrderablePartitioner<TSource> Create<TSource>(IEnumerable<TSource> source);
         public static OrderablePartitioner<TSource> Create<TSource>(IList<TSource> list, bool loadBalance);
         public static OrderablePartitioner<TSource> Create<TSource>(IEnumerable<TSource> source, EnumerablePartitionerOptions partitionerOptions);
         public static OrderablePartitioner<Tuple<int, int>> Create(int fromInclusive, int toExclusive);
         public static OrderablePartitioner<Tuple<int, int>> Create(int fromInclusive, int toExclusive, int rangeSize);
         public static OrderablePartitioner<Tuple<long, long>> Create(long fromInclusive, long toExclusive);
         public static OrderablePartitioner<Tuple<long, long>> Create(long fromInclusive, long toExclusive, long rangeSize);
     }
     public abstract class Partitioner<TSource> {
         protected Partitioner();
         public virtual bool SupportsDynamicPartitions { get; }
         public virtual IEnumerable<TSource> GetDynamicPartitions();
         public abstract IList<IEnumerator<TSource>> GetPartitions(int partitionCount);
     }
 }
 namespace System.Collections.Generic {
     public abstract class Comparer<T> : IComparer, IComparer<T> {
         protected Comparer();
         public static Comparer<T> Default { get; }
         public abstract int Compare(T x, T y);
         public static Comparer<T> Create(Comparison<T> comparison);
     }
     public class Dictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
         public struct Enumerator : IDictionaryEnumerator, IDisposable, IEnumerator, IEnumerator<KeyValuePair<TKey, TValue>> {
             public KeyValuePair<TKey, TValue> Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey> {
             public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey> {
                 public TKey Current { get; }
                 public void Dispose();
                 public bool MoveNext();
             }
             public KeyCollection(Dictionary<TKey, TValue> dictionary);
             public int Count { get; }
             public void CopyTo(TKey[] array, int index);
             public Dictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator();
         }
         public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue> {
             public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue> {
                 public TValue Current { get; }
                 public void Dispose();
                 public bool MoveNext();
             }
             public ValueCollection(Dictionary<TKey, TValue> dictionary);
             public int Count { get; }
             public void CopyTo(TValue[] array, int index);
             public Dictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator();
         }
         public Dictionary();
         public Dictionary(IDictionary<TKey, TValue> dictionary);
         public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer);
         public Dictionary(IEqualityComparer<TKey> comparer);
         public Dictionary(int capacity);
         public Dictionary(int capacity, IEqualityComparer<TKey> comparer);
         public IEqualityComparer<TKey> Comparer { get; }
         public int Count { get; }
         public TValue this[TKey key] { get; set; }
         public Dictionary<TKey, TValue>.KeyCollection Keys { get; }
         public Dictionary<TKey, TValue>.ValueCollection Values { get; }
         public void Add(TKey key, TValue value);
         public void Clear();
         public bool ContainsKey(TKey key);
         public bool ContainsValue(TValue value);
         public Dictionary<TKey, TValue>.Enumerator GetEnumerator();
         public bool Remove(TKey key);
         public bool TryGetValue(TKey key, out TValue value);
     }
     public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T> {
         protected EqualityComparer();
         public static EqualityComparer<T> Default { get; }
         public abstract bool Equals(T x, T y);
         public abstract int GetHashCode(T obj);
     }
     public class HashSet<T> : ICollection<T>, IEnumerable, IEnumerable<T>, ISet<T> {
         public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T> {
             public T Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public HashSet();
         public HashSet(IEnumerable<T> collection);
         public HashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer);
         public HashSet(IEqualityComparer<T> comparer);
         public IEqualityComparer<T> Comparer { get; }
         public int Count { get; }
         public bool Add(T item);
         public void Clear();
         public bool Contains(T item);
         public void CopyTo(T[] array);
         public void CopyTo(T[] array, int arrayIndex);
         public void CopyTo(T[] array, int arrayIndex, int count);
         public void ExceptWith(IEnumerable<T> other);
         public HashSet<T>.Enumerator GetEnumerator();
         public void IntersectWith(IEnumerable<T> other);
         public bool IsProperSubsetOf(IEnumerable<T> other);
         public bool IsProperSupersetOf(IEnumerable<T> other);
         public bool IsSubsetOf(IEnumerable<T> other);
         public bool IsSupersetOf(IEnumerable<T> other);
         public bool Overlaps(IEnumerable<T> other);
         public bool Remove(T item);
         public int RemoveWhere(Predicate<T> match);
         public bool SetEquals(IEnumerable<T> other);
         public void SymmetricExceptWith(IEnumerable<T> other);
         public void TrimExcess();
         public void UnionWith(IEnumerable<T> other);
     }
     public interface ICollection<T> : IEnumerable, IEnumerable<T> {
         int Count { get; }
         bool IsReadOnly { get; }
         void Add(T item);
         void Clear();
         bool Contains(T item);
         void CopyTo(T[] array, int arrayIndex);
         bool Remove(T item);
     }
     public interface IComparer<in T> {
         int Compare(T x, T y);
     }
     public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> {
         TValue this[TKey key] { get; set; }
         ICollection<TKey> Keys { get; }
         ICollection<TValue> Values { get; }
         void Add(TKey key, TValue value);
         bool ContainsKey(TKey key);
         bool Remove(TKey key);
         bool TryGetValue(TKey key, out TValue value);
     }
     public interface IEnumerable<out T> : IEnumerable {
         new IEnumerator<T> GetEnumerator();
     }
     public interface IEnumerator<out T> : IDisposable, IEnumerator {
         new T Current { get; }
     }
     public interface IEqualityComparer<in T> {
         bool Equals(T x, T y);
         int GetHashCode(T obj);
     }
     public interface IList<T> : ICollection<T>, IEnumerable, IEnumerable<T> {
         T this[int index] { get; set; }
         int IndexOf(T item);
         void Insert(int index, T item);
         void RemoveAt(int index);
     }
     public interface IReadOnlyCollection<out T> : IEnumerable, IEnumerable<T> {
         int Count { get; }
     }
     public interface IReadOnlyDictionary<TKey, TValue> : IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>> {
         TValue this[TKey key] { get; }
         IEnumerable<TKey> Keys { get; }
         IEnumerable<TValue> Values { get; }
         bool ContainsKey(TKey key);
         bool TryGetValue(TKey key, out TValue value);
     }
     public interface IReadOnlyList<out T> : IEnumerable, IEnumerable<T>, IReadOnlyCollection<T> {
         T this[int index] { get; }
     }
     public interface ISet<T> : ICollection<T>, IEnumerable, IEnumerable<T> {
         new bool Add(T item);
         void ExceptWith(IEnumerable<T> other);
         void IntersectWith(IEnumerable<T> other);
         bool IsProperSubsetOf(IEnumerable<T> other);
         bool IsProperSupersetOf(IEnumerable<T> other);
         bool IsSubsetOf(IEnumerable<T> other);
         bool IsSupersetOf(IEnumerable<T> other);
         bool Overlaps(IEnumerable<T> other);
         bool SetEquals(IEnumerable<T> other);
         void SymmetricExceptWith(IEnumerable<T> other);
         void UnionWith(IEnumerable<T> other);
     }
     public class KeyNotFoundException : Exception {
         public KeyNotFoundException();
         public KeyNotFoundException(string message);
         public KeyNotFoundException(string message, Exception innerException);
     }
     public struct KeyValuePair<TKey, TValue> {
         public KeyValuePair(TKey key, TValue value);
         public TKey Key { get; }
         public TValue Value { get; }
         public override string ToString();
     }
     public class LinkedList<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T> {
         public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T> {
             public T Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public LinkedList();
         public LinkedList(IEnumerable<T> collection);
         public int Count { get; }
         public LinkedListNode<T> First { get; }
         public LinkedListNode<T> Last { get; }
         public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value);
         public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode);
         public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value);
         public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode);
         public void AddFirst(LinkedListNode<T> node);
         public LinkedListNode<T> AddFirst(T value);
         public void AddLast(LinkedListNode<T> node);
         public LinkedListNode<T> AddLast(T value);
         public void Clear();
         public bool Contains(T value);
         public void CopyTo(T[] array, int index);
         public LinkedListNode<T> Find(T value);
         public LinkedListNode<T> FindLast(T value);
         public LinkedList<T>.Enumerator GetEnumerator();
         public void Remove(LinkedListNode<T> node);
         public bool Remove(T value);
         public void RemoveFirst();
         public void RemoveLast();
     }
     public sealed class LinkedListNode<T> {
         public LinkedListNode(T value);
         public LinkedList<T> List { get; }
         public LinkedListNode<T> Next { get; }
         public LinkedListNode<T> Previous { get; }
         public T Value { get; set; }
     }
     public class List<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, IList, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T> {
         public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T> {
             public T Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public List();
         public List(IEnumerable<T> collection);
         public List(int capacity);
         public int Capacity { get; set; }
         public int Count { get; }
         public T this[int index] { get; set; }
         public void Add(T item);
         public void AddRange(IEnumerable<T> collection);
         public int BinarySearch(int index, int count, T item, IComparer<T> comparer);
         public int BinarySearch(T item);
         public int BinarySearch(T item, IComparer<T> comparer);
         public void Clear();
         public bool Contains(T item);
         public void CopyTo(int index, T[] array, int arrayIndex, int count);
         public void CopyTo(T[] array);
         public void CopyTo(T[] array, int arrayIndex);
         public bool Exists(Predicate<T> match);
         public T Find(Predicate<T> match);
         public List<T> FindAll(Predicate<T> match);
         public int FindIndex(int startIndex, int count, Predicate<T> match);
         public int FindIndex(int startIndex, Predicate<T> match);
         public int FindIndex(Predicate<T> match);
         public T FindLast(Predicate<T> match);
         public int FindLastIndex(int startIndex, int count, Predicate<T> match);
         public int FindLastIndex(int startIndex, Predicate<T> match);
         public int FindLastIndex(Predicate<T> match);
         public List<T>.Enumerator GetEnumerator();
         public List<T> GetRange(int index, int count);
         public int IndexOf(T item);
         public int IndexOf(T item, int index);
         public int IndexOf(T item, int index, int count);
         public void Insert(int index, T item);
         public void InsertRange(int index, IEnumerable<T> collection);
         public int LastIndexOf(T item);
         public int LastIndexOf(T item, int index);
         public int LastIndexOf(T item, int index, int count);
         public bool Remove(T item);
         public int RemoveAll(Predicate<T> match);
         public void RemoveAt(int index);
         public void RemoveRange(int index, int count);
         public void Reverse();
         public void Reverse(int index, int count);
         public void Sort();
         public void Sort(Comparison<T> comparison);
         public void Sort(IComparer<T> comparer);
         public void Sort(int index, int count, IComparer<T> comparer);
         public T[] ToArray();
         public void TrimExcess();
         public bool TrueForAll(Predicate<T> match);
     }
     public class Queue<T> : ICollection, IEnumerable, IEnumerable<T> {
         public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T> {
             public T Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public Queue();
         public Queue(IEnumerable<T> collection);
         public Queue(int capacity);
         public int Count { get; }
         public void Clear();
         public bool Contains(T item);
         public void CopyTo(T[] array, int arrayIndex);
         public T Dequeue();
         public void Enqueue(T item);
         public Queue<T>.Enumerator GetEnumerator();
         public T Peek();
         public T[] ToArray();
         public void TrimExcess();
     }
     public class SortedDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> {
         public struct Enumerator : IDictionaryEnumerator, IDisposable, IEnumerator, IEnumerator<KeyValuePair<TKey, TValue>> {
             public KeyValuePair<TKey, TValue> Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey> {
             public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey> {
                 public TKey Current { get; }
                 public void Dispose();
                 public bool MoveNext();
             }
             public KeyCollection(SortedDictionary<TKey, TValue> dictionary);
             public int Count { get; }
             public void CopyTo(TKey[] array, int index);
             public SortedDictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator();
         }
         public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue> {
             public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue> {
                 public TValue Current { get; }
                 public void Dispose();
                 public bool MoveNext();
             }
             public ValueCollection(SortedDictionary<TKey, TValue> dictionary);
             public int Count { get; }
             public void CopyTo(TValue[] array, int index);
             public SortedDictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator();
         }
         public SortedDictionary();
         public SortedDictionary(IComparer<TKey> comparer);
         public SortedDictionary(IDictionary<TKey, TValue> dictionary);
         public SortedDictionary(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer);
         public IComparer<TKey> Comparer { get; }
         public int Count { get; }
         public TValue this[TKey key] { get; set; }
         public SortedDictionary<TKey, TValue>.KeyCollection Keys { get; }
         public SortedDictionary<TKey, TValue>.ValueCollection Values { get; }
         public void Add(TKey key, TValue value);
         public void Clear();
         public bool ContainsKey(TKey key);
         public bool ContainsValue(TValue value);
         public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index);
         public SortedDictionary<TKey, TValue>.Enumerator GetEnumerator();
         public bool Remove(TKey key);
         public bool TryGetValue(TKey key, out TValue value);
     }
     public class SortedSet<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, ISet<T> {
         public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T> {
             public T Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public SortedSet();
         public SortedSet(IComparer<T> comparer);
         public SortedSet(IEnumerable<T> collection);
         public SortedSet(IEnumerable<T> collection, IComparer<T> comparer);
         public IComparer<T> Comparer { get; }
         public int Count { get; }
         public T Max { get; }
         public T Min { get; }
         public bool Add(T item);
         public virtual void Clear();
         public virtual bool Contains(T item);
         public void CopyTo(T[] array);
         public void CopyTo(T[] array, int index);
         public void CopyTo(T[] array, int index, int count);
         public void ExceptWith(IEnumerable<T> other);
         public SortedSet<T>.Enumerator GetEnumerator();
         public virtual SortedSet<T> GetViewBetween(T lowerValue, T upperValue);
         public virtual void IntersectWith(IEnumerable<T> other);
         public bool IsProperSubsetOf(IEnumerable<T> other);
         public bool IsProperSupersetOf(IEnumerable<T> other);
         public bool IsSubsetOf(IEnumerable<T> other);
         public bool IsSupersetOf(IEnumerable<T> other);
         public bool Overlaps(IEnumerable<T> other);
         public bool Remove(T item);
         public int RemoveWhere(Predicate<T> match);
         public IEnumerable<T> Reverse();
         public bool SetEquals(IEnumerable<T> other);
         public void SymmetricExceptWith(IEnumerable<T> other);
         public void UnionWith(IEnumerable<T> other);
     }
     public class Stack<T> : ICollection, IEnumerable, IEnumerable<T> {
         public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T> {
             public T Current { get; }
             public void Dispose();
             public bool MoveNext();
         }
         public Stack();
         public Stack(IEnumerable<T> collection);
         public Stack(int capacity);
         public int Count { get; }
         public void Clear();
         public bool Contains(T item);
         public void CopyTo(T[] array, int arrayIndex);
         public Stack<T>.Enumerator GetEnumerator();
         public T Peek();
         public T Pop();
         public void Push(T item);
         public T[] ToArray();
         public void TrimExcess();
     }
 }
 namespace System.Collections.ObjectModel {
     public class Collection<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, IList, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T> {
         public Collection();
         public Collection(IList<T> list);
         public int Count { get; }
         protected IList<T> Items { get; }
         public T this[int index] { get; set; }
         public void Add(T item);
         public void Clear();
         protected virtual void ClearItems();
         public bool Contains(T item);
         public void CopyTo(T[] array, int index);
         public IEnumerator<T> GetEnumerator();
         public int IndexOf(T item);
         public void Insert(int index, T item);
         protected virtual void InsertItem(int index, T item);
         public bool Remove(T item);
         public void RemoveAt(int index);
         protected virtual void RemoveItem(int index);
         protected virtual void SetItem(int index, T item);
     }
     public abstract class KeyedCollection<TKey, TItem> : Collection<TItem> {
         protected KeyedCollection();
         protected KeyedCollection(IEqualityComparer<TKey> comparer);
         protected KeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold);
         public IEqualityComparer<TKey> Comparer { get; }
         protected IDictionary<TKey, TItem> Dictionary { get; }
         public TItem this[TKey key] { get; }
         protected void ChangeItemKey(TItem item, TKey newKey);
         protected override void ClearItems();
         public bool Contains(TKey key);
         protected abstract TKey GetKeyForItem(TItem item);
         protected override void InsertItem(int index, TItem item);
         public bool Remove(TKey key);
         protected override void RemoveItem(int index);
         protected override void SetItem(int index, TItem item);
     }
     public class ObservableCollection<T> : Collection<T>, INotifyCollectionChanged, INotifyPropertyChanged {
         public ObservableCollection();
         public ObservableCollection(IEnumerable<T> collection);
         protected IDisposable BlockReentrancy();
         protected void CheckReentrancy();
         protected override void ClearItems();
         protected override void InsertItem(int index, T item);
         public void Move(int oldIndex, int newIndex);
         protected virtual void MoveItem(int oldIndex, int newIndex);
         protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e);
         protected virtual void OnPropertyChanged(PropertyChangedEventArgs e);
         protected override void RemoveItem(int index);
         protected override void SetItem(int index, T item);
         public virtual event NotifyCollectionChangedEventHandler CollectionChanged;
         protected virtual event PropertyChangedEventHandler PropertyChanged;
     }
     public class ReadOnlyCollection<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T>, IList, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T> {
         public ReadOnlyCollection(IList<T> list);
         public int Count { get; }
         protected IList<T> Items { get; }
         public T this[int index] { get; }
         public bool Contains(T value);
         public void CopyTo(T[] array, int index);
         public IEnumerator<T> GetEnumerator();
         public int IndexOf(T value);
     }
     public class ReadOnlyDictionary<TKey, TValue> : ICollection, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, IDictionary<TKey, TValue>, IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue> {
         public sealed class KeyCollection : ICollection, ICollection<TKey>, IEnumerable, IEnumerable<TKey> {
             public int Count { get; }
             public void CopyTo(TKey[] array, int arrayIndex);
             public IEnumerator<TKey> GetEnumerator();
         }
         public sealed class ValueCollection : ICollection, ICollection<TValue>, IEnumerable, IEnumerable<TValue> {
             public int Count { get; }
             public void CopyTo(TValue[] array, int arrayIndex);
             public IEnumerator<TValue> GetEnumerator();
         }
         public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary);
         public int Count { get; }
         protected IDictionary<TKey, TValue> Dictionary { get; }
         public TValue this[TKey key] { get; }
         public ReadOnlyDictionary<TKey, TValue>.KeyCollection Keys { get; }
         public ReadOnlyDictionary<TKey, TValue>.ValueCollection Values { get; }
         public bool ContainsKey(TKey key);
         public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
         public bool TryGetValue(TKey key, out TValue value);
     }
     public class ReadOnlyObservableCollection<T> : ReadOnlyCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged {
         public ReadOnlyObservableCollection(ObservableCollection<T> list);
         protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs args);
         protected virtual void OnPropertyChanged(PropertyChangedEventArgs args);
         protected virtual event NotifyCollectionChangedEventHandler CollectionChanged;
         protected virtual event PropertyChangedEventHandler PropertyChanged;
     }
 }
 namespace System.Collections.Specialized {
     public interface INotifyCollectionChanged {
         event NotifyCollectionChangedEventHandler CollectionChanged;
     }
     public enum NotifyCollectionChangedAction {
         Add = 0,
         Move = 3,
         Remove = 1,
         Replace = 2,
         Reset = 4,
     }
     public class NotifyCollectionChangedEventArgs : EventArgs {
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int startingIndex);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int index, int oldIndex);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index, int oldIndex);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem);
         public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem, int index);
         public NotifyCollectionChangedAction Action { get; }
         public IList NewItems { get; }
         public int NewStartingIndex { get; }
         public IList OldItems { get; }
         public int OldStartingIndex { get; }
     }
     public delegate void NotifyCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e); {
         public NotifyCollectionChangedEventHandler(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(object sender, NotifyCollectionChangedEventArgs e, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(object sender, NotifyCollectionChangedEventArgs e);
     }
 }
 namespace System.ComponentModel {
     public class DataErrorsChangedEventArgs : EventArgs {
         public DataErrorsChangedEventArgs(string propertyName);
         public virtual string PropertyName { get; }
     }
     public class DefaultValueAttribute : Attribute {
         public DefaultValueAttribute(bool value);
         public DefaultValueAttribute(byte value);
         public DefaultValueAttribute(char value);
         public DefaultValueAttribute(double value);
         public DefaultValueAttribute(short value);
         public DefaultValueAttribute(int value);
         public DefaultValueAttribute(long value);
         public DefaultValueAttribute(object value);
         public DefaultValueAttribute(float value);
         public DefaultValueAttribute(string value);
         public DefaultValueAttribute(Type type, string value);
         public virtual object Value { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
     }
     public sealed class EditorBrowsableAttribute : Attribute {
         public EditorBrowsableAttribute(EditorBrowsableState state);
         public EditorBrowsableState State { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
     }
     public enum EditorBrowsableState {
         Advanced = 2,
         Always = 0,
         Never = 1,
     }
     public interface INotifyDataErrorInfo {
         bool HasErrors { get; }
         IEnumerable GetErrors(string propertyName);
         event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
     }
     public interface INotifyPropertyChanged {
         event PropertyChangedEventHandler PropertyChanged;
     }
     public class PropertyChangedEventArgs : EventArgs {
         public PropertyChangedEventArgs(string propertyName);
         public string PropertyName { get; }
     }
     public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e); {
         public PropertyChangedEventHandler(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(object sender, PropertyChangedEventArgs e, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(object sender, PropertyChangedEventArgs e);
     }
 }
 namespace System.Diagnostics {
     public sealed class ConditionalAttribute : Attribute {
         public ConditionalAttribute(string conditionString);
         public string ConditionString { get; }
     }
     public static class Debug {
         public static void Assert(bool condition);
         public static void Assert(bool condition, string message);
         public static void WriteLine(object value);
         public static void WriteLine(string message);
         public static void WriteLine(string format, params object[] args);
         public static void WriteLineIf(bool condition, string message);
     }
     public sealed class DebuggableAttribute : Attribute {
         public enum DebuggingModes {
             Default = 1,
             DisableOptimizations = 256,
             EnableEditAndContinue = 4,
             IgnoreSymbolStoreSequencePoints = 2,
             None = 0,
         }
         public DebuggableAttribute(DebuggableAttribute.DebuggingModes modes);
     }
     public static class Debugger {
         public static bool IsAttached { get; }
         public static void Break();
         public static bool Launch();
     }
     public sealed class DebuggerBrowsableAttribute : Attribute {
         public DebuggerBrowsableAttribute(DebuggerBrowsableState state);
         public DebuggerBrowsableState State { get; }
     }
     public enum DebuggerBrowsableState {
         Collapsed = 2,
         Never = 0,
         RootHidden = 3,
     }
     public sealed class DebuggerDisplayAttribute : Attribute {
         public DebuggerDisplayAttribute(string value);
         public string Name { get; set; }
         public Type Target { get; set; }
         public string TargetTypeName { get; set; }
         public string Type { get; set; }
         public string Value { get; }
     }
     public sealed class DebuggerHiddenAttribute : Attribute {
         public DebuggerHiddenAttribute();
     }
     public sealed class DebuggerNonUserCodeAttribute : Attribute {
         public DebuggerNonUserCodeAttribute();
     }
     public sealed class DebuggerStepThroughAttribute : Attribute {
         public DebuggerStepThroughAttribute();
     }
     public sealed class DebuggerTypeProxyAttribute : Attribute {
         public DebuggerTypeProxyAttribute(string typeName);
         public DebuggerTypeProxyAttribute(Type type);
         public string ProxyTypeName { get; }
         public Type Target { get; set; }
         public string TargetTypeName { get; set; }
     }
     public class Stopwatch {
         public static readonly long Frequency;
         public static readonly bool IsHighResolution;
         public Stopwatch();
         public TimeSpan Elapsed { get; }
         public long ElapsedMilliseconds { get; }
         public long ElapsedTicks { get; }
         public bool IsRunning { get; }
         public static long GetTimestamp();
         public void Reset();
         public void Restart();
         public void Start();
         public static Stopwatch StartNew();
         public void Stop();
     }
 }
 namespace System.Diagnostics.CodeAnalysis {
     public sealed class SuppressMessageAttribute : Attribute {
         public SuppressMessageAttribute(string category, string checkId);
         public string Category { get; }
         public string CheckId { get; }
         public string Justification { get; set; }
         public string MessageId { get; set; }
         public string Scope { get; set; }
         public string Target { get; set; }
     }
 }
 namespace System.Diagnostics.Tracing {
     public sealed class EventAttribute : Attribute {
         public EventAttribute(int eventId);
         public int EventId { get; }
         public EventKeywords Keywords { get; set; }
         public EventLevel Level { get; set; }
         public string Message { get; set; }
         public EventOpcode Opcode { get; set; }
         public EventTask Task { get; set; }
         public byte Version { get; set; }
     }
     public enum EventCommand {
         Disable = -3,
         Enable = -2,
         SendManifest = -1,
         Update = 0,
     }
     public class EventCommandEventArgs : EventArgs {
         public IDictionary<string, string> Arguments { get; }
         public EventCommand Command { get; }
         public bool DisableEvent(int eventId);
         public bool EnableEvent(int eventId);
     }
     public enum EventKeywords : long {
         AuditFailure = (long)4503599627370496,
         AuditSuccess = (long)9007199254740992,
         CorrelationHint = (long)4503599627370496,
         EventLogClassic = (long)36028797018963968,
         None = (long)0,
         Sqm = (long)2251799813685248,
         WdiContext = (long)562949953421312,
         WdiDiagnostic = (long)1125899906842624,
     }
     public enum EventLevel {
         Critical = 1,
         Error = 2,
         Informational = 4,
         LogAlways = 0,
         Verbose = 5,
         Warning = 3,
     }
     public abstract class EventListener : IDisposable {
         protected EventListener();
         public void DisableEvents(EventSource eventSource);
         public virtual void Dispose();
         public void EnableEvents(EventSource eventSource, EventLevel level);
         public void EnableEvents(EventSource eventSource, EventLevel level, EventKeywords matchAnyKeyword);
         public void EnableEvents(EventSource eventSource, EventLevel level, EventKeywords matchAnyKeyword, IDictionary<string, string> arguments);
         protected static int EventSourceIndex(EventSource eventSource);
         protected internal virtual void OnEventSourceCreated(EventSource eventSource);
         protected internal abstract void OnEventWritten(EventWrittenEventArgs eventData);
     }
     public enum EventOpcode {
         DataCollectionStart = 3,
         DataCollectionStop = 4,
         Extension = 5,
         Info = 0,
         Receive = 240,
         Reply = 6,
         Resume = 7,
         Send = 9,
         Start = 1,
         Stop = 2,
         Suspend = 8,
     }
     public class EventSource : IDisposable {
         protected internal struct EventData {
             public IntPtr DataPointer { get; set; }
             public int Size { get; set; }
         }
         protected EventSource();
         protected EventSource(bool throwOnEventWriteErrors);
         public Guid Guid { get; }
         public string Name { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         ~EventSource();
         public static string GenerateManifest(Type eventSourceType, string assemblyPathToIncludeInManifest);
         public static Guid GetGuid(Type eventSourceType);
         public static string GetName(Type eventSourceType);
         public static IEnumerable<EventSource> GetSources();
         public bool IsEnabled();
         public bool IsEnabled(EventLevel level, EventKeywords keywords);
         protected virtual void OnEventCommand(EventCommandEventArgs command);
         public static void SendCommand(EventSource eventSource, EventCommand command, IDictionary<string, string> commandArguments);
         public override string ToString();
         protected void WriteEvent(int eventId);
         protected void WriteEvent(int eventId, int arg1);
         protected void WriteEvent(int eventId, int arg1, int arg2);
         protected void WriteEvent(int eventId, int arg1, int arg2, int arg3);
         protected void WriteEvent(int eventId, long arg1);
         protected void WriteEvent(int eventId, long arg1, long arg2);
         protected void WriteEvent(int eventId, long arg1, long arg2, long arg3);
         protected void WriteEvent(int eventId, params object[] args);
         protected void WriteEvent(int eventId, string arg1);
         protected void WriteEvent(int eventId, string arg1, int arg2);
         protected void WriteEvent(int eventId, string arg1, int arg2, int arg3);
         protected void WriteEvent(int eventId, string arg1, long arg2);
         protected void WriteEvent(int eventId, string arg1, string arg2);
         protected void WriteEvent(int eventId, string arg1, string arg2, string arg3);
         protected unsafe void WriteEventCore(int eventId, int eventDataCount, EventSource.EventData* data);
     }
     public sealed class EventSourceAttribute : Attribute {
         public EventSourceAttribute();
         public string Guid { get; set; }
         public string LocalizationResources { get; set; }
         public string Name { get; set; }
     }
     public class EventSourceException : Exception {
         public EventSourceException();
         public EventSourceException(string message);
         public EventSourceException(string message, Exception innerException);
     }
     public enum EventTask {
         None = 0,
     }
     public class EventWrittenEventArgs : EventArgs {
         public int EventId { get; }
         public EventSource EventSource { get; }
         public EventKeywords Keywords { get; }
         public EventLevel Level { get; }
         public string Message { get; }
         public EventOpcode Opcode { get; }
         public ReadOnlyCollection<object> Payload { get; }
         public EventTask Task { get; }
         public byte Version { get; }
     }
     public sealed class NonEventAttribute : Attribute {
         public NonEventAttribute();
     }
 }
 namespace System.Globalization {
     public abstract class Calendar {
         public const int CurrentEra = 0;
         protected Calendar();
         public abstract int[] Eras { get; }
         public bool IsReadOnly { get; }
         public virtual DateTime MaxSupportedDateTime { get; }
         public virtual DateTime MinSupportedDateTime { get; }
         public virtual int TwoDigitYearMax { get; set; }
         public virtual DateTime AddDays(DateTime time, int days);
         public virtual DateTime AddHours(DateTime time, int hours);
         public virtual DateTime AddMilliseconds(DateTime time, double milliseconds);
         public virtual DateTime AddMinutes(DateTime time, int minutes);
         public abstract DateTime AddMonths(DateTime time, int months);
         public virtual DateTime AddSeconds(DateTime time, int seconds);
         public virtual DateTime AddWeeks(DateTime time, int weeks);
         public abstract DateTime AddYears(DateTime time, int years);
         public abstract int GetDayOfMonth(DateTime time);
         public abstract DayOfWeek GetDayOfWeek(DateTime time);
         public abstract int GetDayOfYear(DateTime time);
         public virtual int GetDaysInMonth(int year, int month);
         public abstract int GetDaysInMonth(int year, int month, int era);
         public virtual int GetDaysInYear(int year);
         public abstract int GetDaysInYear(int year, int era);
         public abstract int GetEra(DateTime time);
         public virtual int GetHour(DateTime time);
         public virtual int GetLeapMonth(int year, int era);
         public virtual double GetMilliseconds(DateTime time);
         public virtual int GetMinute(DateTime time);
         public abstract int GetMonth(DateTime time);
         public virtual int GetMonthsInYear(int year);
         public abstract int GetMonthsInYear(int year, int era);
         public virtual int GetSecond(DateTime time);
         public virtual int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek);
         public abstract int GetYear(DateTime time);
         public virtual bool IsLeapDay(int year, int month, int day);
         public abstract bool IsLeapDay(int year, int month, int day, int era);
         public virtual bool IsLeapMonth(int year, int month);
         public abstract bool IsLeapMonth(int year, int month, int era);
         public virtual bool IsLeapYear(int year);
         public abstract bool IsLeapYear(int year, int era);
         public virtual DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);
         public abstract DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
         public virtual int ToFourDigitYear(int year);
     }
     public enum CalendarWeekRule {
         FirstDay = 0,
         FirstFourDayWeek = 2,
         FirstFullWeek = 1,
     }
     public static class CharUnicodeInfo {
         public static double GetNumericValue(char ch);
         public static double GetNumericValue(string s, int index);
         public static UnicodeCategory GetUnicodeCategory(char ch);
         public static UnicodeCategory GetUnicodeCategory(string s, int index);
     }
     public class CompareInfo {
         public virtual string Name { get; }
         public virtual int Compare(string string1, int offset1, int length1, string string2, int offset2, int length2);
         public virtual int Compare(string string1, int offset1, int length1, string string2, int offset2, int length2, CompareOptions options);
         public virtual int Compare(string string1, int offset1, string string2, int offset2);
         public virtual int Compare(string string1, int offset1, string string2, int offset2, CompareOptions options);
         public virtual int Compare(string string1, string string2);
         public virtual int Compare(string string1, string string2, CompareOptions options);
         public override bool Equals(object value);
         public static CompareInfo GetCompareInfo(string name);
         public override int GetHashCode();
         public virtual int IndexOf(string source, char value);
         public virtual int IndexOf(string source, char value, CompareOptions options);
         public virtual int IndexOf(string source, char value, int startIndex, CompareOptions options);
         public virtual int IndexOf(string source, char value, int startIndex, int count);
         public virtual int IndexOf(string source, char value, int startIndex, int count, CompareOptions options);
         public virtual int IndexOf(string source, string value);
         public virtual int IndexOf(string source, string value, CompareOptions options);
         public virtual int IndexOf(string source, string value, int startIndex, CompareOptions options);
         public virtual int IndexOf(string source, string value, int startIndex, int count);
         public virtual int IndexOf(string source, string value, int startIndex, int count, CompareOptions options);
         public virtual bool IsPrefix(string source, string prefix);
         public virtual bool IsPrefix(string source, string prefix, CompareOptions options);
         public virtual bool IsSuffix(string source, string suffix);
         public virtual bool IsSuffix(string source, string suffix, CompareOptions options);
         public virtual int LastIndexOf(string source, char value);
         public virtual int LastIndexOf(string source, char value, CompareOptions options);
         public virtual int LastIndexOf(string source, char value, int startIndex, CompareOptions options);
         public virtual int LastIndexOf(string source, char value, int startIndex, int count);
         public virtual int LastIndexOf(string source, char value, int startIndex, int count, CompareOptions options);
         public virtual int LastIndexOf(string source, string value);
         public virtual int LastIndexOf(string source, string value, CompareOptions options);
         public virtual int LastIndexOf(string source, string value, int startIndex, CompareOptions options);
         public virtual int LastIndexOf(string source, string value, int startIndex, int count);
         public virtual int LastIndexOf(string source, string value, int startIndex, int count, CompareOptions options);
         public override string ToString();
     }
     public enum CompareOptions {
         IgnoreCase = 1,
         IgnoreKanaType = 8,
         IgnoreNonSpace = 2,
         IgnoreSymbols = 4,
         IgnoreWidth = 16,
         None = 0,
         Ordinal = 1073741824,
         OrdinalIgnoreCase = 268435456,
         StringSort = 536870912,
     }
     public class CultureInfo : IFormatProvider {
         public CultureInfo(string name);
         public virtual Calendar Calendar { get; }
         public virtual CompareInfo CompareInfo { get; }
         public static CultureInfo CurrentCulture { get; }
         public static CultureInfo CurrentUICulture { get; }
         public virtual DateTimeFormatInfo DateTimeFormat { get; set; }
         public static CultureInfo DefaultThreadCurrentCulture { get; set; }
         public static CultureInfo DefaultThreadCurrentUICulture { get; set; }
         public virtual string DisplayName { get; }
         public virtual string EnglishName { get; }
         public static CultureInfo InvariantCulture { get; }
         public virtual bool IsNeutralCulture { get; }
         public bool IsReadOnly { get; }
         public virtual string Name { get; }
         public virtual string NativeName { get; }
         public virtual NumberFormatInfo NumberFormat { get; set; }
         public virtual Calendar[] OptionalCalendars { get; }
         public virtual CultureInfo Parent { get; }
         public virtual TextInfo TextInfo { get; }
         public virtual string TwoLetterISOLanguageName { get; }
         public virtual object Clone();
         public override bool Equals(object value);
         public virtual object GetFormat(Type formatType);
         public override int GetHashCode();
         public static CultureInfo ReadOnly(CultureInfo ci);
         public override string ToString();
     }
     public class CultureNotFoundException : ArgumentException {
         public CultureNotFoundException();
         public CultureNotFoundException(string message);
         public CultureNotFoundException(string message, Exception innerException);
         public CultureNotFoundException(string paramName, string message);
         public CultureNotFoundException(string message, string invalidCultureName, Exception innerException);
         public CultureNotFoundException(string paramName, string invalidCultureName, string message);
         public virtual string InvalidCultureName { get; }
         public override string Message { get; }
     }
     public sealed class DateTimeFormatInfo : IFormatProvider {
         public DateTimeFormatInfo();
         public string[] AbbreviatedDayNames { get; set; }
         public string[] AbbreviatedMonthGenitiveNames { get; set; }
         public string[] AbbreviatedMonthNames { get; set; }
         public string AMDesignator { get; set; }
         public Calendar Calendar { get; set; }
         public CalendarWeekRule CalendarWeekRule { get; set; }
         public static DateTimeFormatInfo CurrentInfo { get; }
         public string[] DayNames { get; set; }
         public DayOfWeek FirstDayOfWeek { get; set; }
         public string FullDateTimePattern { get; set; }
         public static DateTimeFormatInfo InvariantInfo { get; }
         public bool IsReadOnly { get; }
         public string LongDatePattern { get; set; }
         public string LongTimePattern { get; set; }
         public string MonthDayPattern { get; set; }
         public string[] MonthGenitiveNames { get; set; }
         public string[] MonthNames { get; set; }
         public string PMDesignator { get; set; }
         public string RFC1123Pattern { get; }
         public string ShortDatePattern { get; set; }
         public string[] ShortestDayNames { get; set; }
         public string ShortTimePattern { get; set; }
         public string SortableDateTimePattern { get; }
         public string UniversalSortableDateTimePattern { get; }
         public string YearMonthPattern { get; set; }
         public object Clone();
         public string GetAbbreviatedDayName(DayOfWeek dayofweek);
         public string GetAbbreviatedEraName(int era);
         public string GetAbbreviatedMonthName(int month);
         public string GetDayName(DayOfWeek dayofweek);
         public int GetEra(string eraName);
         public string GetEraName(int era);
         public object GetFormat(Type formatType);
         public static DateTimeFormatInfo GetInstance(IFormatProvider provider);
         public string GetMonthName(int month);
         public static DateTimeFormatInfo ReadOnly(DateTimeFormatInfo dtfi);
     }
     public enum DateTimeStyles {
         AdjustToUniversal = 16,
         AllowInnerWhite = 4,
         AllowLeadingWhite = 1,
         AllowTrailingWhite = 2,
         AllowWhiteSpaces = 7,
         AssumeLocal = 32,
         AssumeUniversal = 64,
         NoCurrentDateDefault = 8,
         None = 0,
         RoundtripKind = 128,
     }
     public sealed class NumberFormatInfo : IFormatProvider {
         public NumberFormatInfo();
         public int CurrencyDecimalDigits { get; set; }
         public string CurrencyDecimalSeparator { get; set; }
         public string CurrencyGroupSeparator { get; set; }
         public int[] CurrencyGroupSizes { get; set; }
         public int CurrencyNegativePattern { get; set; }
         public int CurrencyPositivePattern { get; set; }
         public string CurrencySymbol { get; set; }
         public static NumberFormatInfo CurrentInfo { get; }
         public static NumberFormatInfo InvariantInfo { get; }
         public bool IsReadOnly { get; }
         public string NaNSymbol { get; set; }
         public string NegativeInfinitySymbol { get; set; }
         public string NegativeSign { get; set; }
         public int NumberDecimalDigits { get; set; }
         public string NumberDecimalSeparator { get; set; }
         public string NumberGroupSeparator { get; set; }
         public int[] NumberGroupSizes { get; set; }
         public int NumberNegativePattern { get; set; }
         public int PercentDecimalDigits { get; set; }
         public string PercentDecimalSeparator { get; set; }
         public string PercentGroupSeparator { get; set; }
         public int[] PercentGroupSizes { get; set; }
         public int PercentNegativePattern { get; set; }
         public int PercentPositivePattern { get; set; }
         public string PercentSymbol { get; set; }
         public string PerMilleSymbol { get; set; }
         public string PositiveInfinitySymbol { get; set; }
         public string PositiveSign { get; set; }
         public object Clone();
         public object GetFormat(Type formatType);
         public static NumberFormatInfo GetInstance(IFormatProvider formatProvider);
         public static NumberFormatInfo ReadOnly(NumberFormatInfo nfi);
     }
     public enum NumberStyles {
         AllowCurrencySymbol = 256,
         AllowDecimalPoint = 32,
         AllowExponent = 128,
         AllowHexSpecifier = 512,
         AllowLeadingSign = 4,
         AllowLeadingWhite = 1,
         AllowParentheses = 16,
         AllowThousands = 64,
         AllowTrailingSign = 8,
         AllowTrailingWhite = 2,
         Any = 511,
         Currency = 383,
         Float = 167,
         HexNumber = 515,
         Integer = 7,
         None = 0,
         Number = 111,
     }
     public class RegionInfo {
         public RegionInfo(string name);
         public virtual string CurrencySymbol { get; }
         public static RegionInfo CurrentRegion { get; }
         public virtual string DisplayName { get; }
         public virtual string EnglishName { get; }
         public virtual bool IsMetric { get; }
         public virtual string ISOCurrencySymbol { get; }
         public virtual string Name { get; }
         public virtual string NativeName { get; }
         public virtual string TwoLetterISORegionName { get; }
         public override bool Equals(object value);
         public override int GetHashCode();
         public override string ToString();
     }
     public class StringInfo {
         public StringInfo();
         public StringInfo(string value);
         public int LengthInTextElements { get; }
         public string String { get; set; }
         public override bool Equals(object value);
         public override int GetHashCode();
         public static string GetNextTextElement(string str);
         public static string GetNextTextElement(string str, int index);
         public static TextElementEnumerator GetTextElementEnumerator(string str);
         public static TextElementEnumerator GetTextElementEnumerator(string str, int index);
         public static int[] ParseCombiningCharacters(string str);
     }
     public class TextElementEnumerator : IEnumerator {
         public object Current { get; }
         public int ElementIndex { get; }
         public string GetTextElement();
         public bool MoveNext();
         public void Reset();
     }
     public class TextInfo {
         public string CultureName { get; }
         public bool IsReadOnly { get; }
         public virtual string ListSeparator { get; set; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public virtual char ToLower(char c);
         public virtual string ToLower(string str);
         public override string ToString();
         public virtual char ToUpper(char c);
         public virtual string ToUpper(string str);
     }
     public enum TimeSpanStyles {
         AssumeNegative = 1,
         None = 0,
     }
     public enum UnicodeCategory {
         ClosePunctuation = 21,
         ConnectorPunctuation = 18,
         Control = 14,
         CurrencySymbol = 26,
         DashPunctuation = 19,
         DecimalDigitNumber = 8,
         EnclosingMark = 7,
         FinalQuotePunctuation = 23,
         Format = 15,
         InitialQuotePunctuation = 22,
         LetterNumber = 9,
         LineSeparator = 12,
         LowercaseLetter = 1,
         MathSymbol = 25,
         ModifierLetter = 3,
         ModifierSymbol = 27,
         NonSpacingMark = 5,
         OpenPunctuation = 20,
         OtherLetter = 4,
         OtherNotAssigned = 29,
         OtherNumber = 10,
         OtherPunctuation = 24,
         OtherSymbol = 28,
         ParagraphSeparator = 13,
         PrivateUse = 17,
         SpaceSeparator = 11,
         SpacingCombiningMark = 6,
         Surrogate = 16,
         TitlecaseLetter = 2,
         UppercaseLetter = 0,
     }
 }
 namespace System.IO {
     public class BinaryReader : IDisposable {
         public BinaryReader(Stream input);
         public BinaryReader(Stream input, Encoding encoding);
         public BinaryReader(Stream input, Encoding encoding, bool leaveOpen);
         public virtual Stream BaseStream { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         protected virtual void FillBuffer(int numBytes);
         public virtual int PeekChar();
         public virtual int Read();
         public virtual int Read(byte[] buffer, int index, int count);
         public virtual int Read(char[] buffer, int index, int count);
         protected internal int Read7BitEncodedInt();
         public virtual bool ReadBoolean();
         public virtual byte ReadByte();
         public virtual byte[] ReadBytes(int count);
         public virtual char ReadChar();
         public virtual char[] ReadChars(int count);
         public virtual decimal ReadDecimal();
         public virtual double ReadDouble();
         public virtual short ReadInt16();
         public virtual int ReadInt32();
         public virtual long ReadInt64();
         public virtual sbyte ReadSByte();
         public virtual float ReadSingle();
         public virtual string ReadString();
         public virtual ushort ReadUInt16();
         public virtual uint ReadUInt32();
         public virtual ulong ReadUInt64();
     }
     public class BinaryWriter : IDisposable {
         public static readonly BinaryWriter Null;
         protected Stream OutStream;
         protected BinaryWriter();
         public BinaryWriter(Stream output);
         public BinaryWriter(Stream output, Encoding encoding);
         public BinaryWriter(Stream output, Encoding encoding, bool leaveOpen);
         public virtual Stream BaseStream { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public virtual void Flush();
         public virtual long Seek(int offset, SeekOrigin origin);
         public virtual void Write(bool value);
         public virtual void Write(byte value);
         public virtual void Write(byte[] buffer);
         public virtual void Write(byte[] buffer, int index, int count);
         public virtual void Write(char ch);
         public virtual void Write(char[] chars);
         public virtual void Write(char[] chars, int index, int count);
         public virtual void Write(decimal value);
         public virtual void Write(double value);
         public virtual void Write(short value);
         public virtual void Write(int value);
         public virtual void Write(long value);
         public virtual void Write(sbyte value);
         public virtual void Write(float value);
         public virtual void Write(string value);
         public virtual void Write(ushort value);
         public virtual void Write(uint value);
         public virtual void Write(ulong value);
         protected void Write7BitEncodedInt(int value);
     }
     public class EndOfStreamException : IOException {
         public EndOfStreamException();
         public EndOfStreamException(string message);
         public EndOfStreamException(string message, Exception innerException);
     }
     public class FileNotFoundException : IOException {
         public FileNotFoundException();
         public FileNotFoundException(string message);
         public FileNotFoundException(string message, Exception innerException);
         public FileNotFoundException(string message, string fileName);
         public FileNotFoundException(string message, string fileName, Exception innerException);
         public string FileName { get; }
         public override string Message { get; }
         public override string ToString();
     }
     public sealed class InvalidDataException : Exception {
         public InvalidDataException();
         public InvalidDataException(string message);
         public InvalidDataException(string message, Exception innerException);
     }
     public class IOException : Exception {
         public IOException();
         public IOException(string message);
         public IOException(string message, Exception innerException);
         public IOException(string message, int hresult);
     }
     public class MemoryStream : Stream {
         public MemoryStream();
         public MemoryStream(byte[] buffer);
         public MemoryStream(byte[] buffer, bool writable);
         public MemoryStream(byte[] buffer, int index, int count);
         public MemoryStream(byte[] buffer, int index, int count, bool writable);
         public MemoryStream(int capacity);
         public override bool CanRead { get; }
         public override bool CanSeek { get; }
         public override bool CanWrite { get; }
         public virtual int Capacity { get; set; }
         public override long Length { get; }
         public override long Position { get; set; }
         protected override void Dispose(bool disposing);
         public override void Flush();
         public override Task FlushAsync(CancellationToken cancellationToken);
         public override int Read(byte[] buffer, int offset, int count);
         public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
         public override int ReadByte();
         public override long Seek(long offset, SeekOrigin loc);
         public override void SetLength(long value);
         public virtual byte[] ToArray();
         public override void Write(byte[] buffer, int offset, int count);
         public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
         public override void WriteByte(byte value);
         public virtual void WriteTo(Stream stream);
     }
     public static class Path {
         public static string ChangeExtension(string path, string extension);
         public static string Combine(params string[] paths);
         public static string GetDirectoryName(string path);
         public static string GetExtension(string path);
         public static string GetFileName(string path);
         public static string GetFileNameWithoutExtension(string path);
         public static char[] GetInvalidFileNameChars();
         public static char[] GetInvalidPathChars();
         public static string GetPathRoot(string path);
         public static string GetRandomFileName();
         public static bool HasExtension(string path);
         public static bool IsPathRooted(string path);
     }
     public enum SeekOrigin {
         Begin = 0,
         Current = 1,
         End = 2,
     }
     public abstract class Stream : IDisposable {
         public static readonly Stream Null;
         protected Stream();
         public abstract bool CanRead { get; }
         public abstract bool CanSeek { get; }
         public virtual bool CanTimeout { get; }
         public abstract bool CanWrite { get; }
         public abstract long Length { get; }
         public abstract long Position { get; set; }
         public virtual int ReadTimeout { get; set; }
         public virtual int WriteTimeout { get; set; }
         public void CopyTo(Stream destination);
         public void CopyTo(Stream destination, int bufferSize);
         public Task CopyToAsync(Stream destination);
         public Task CopyToAsync(Stream destination, int bufferSize);
         public virtual Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public abstract void Flush();
         public Task FlushAsync();
         public virtual Task FlushAsync(CancellationToken cancellationToken);
         public abstract int Read(byte[] buffer, int offset, int count);
         public Task<int> ReadAsync(byte[] buffer, int offset, int count);
         public virtual Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
         public virtual int ReadByte();
         public abstract long Seek(long offset, SeekOrigin origin);
         public abstract void SetLength(long value);
         public abstract void Write(byte[] buffer, int offset, int count);
         public Task WriteAsync(byte[] buffer, int offset, int count);
         public virtual Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
         public virtual void WriteByte(byte value);
     }
     public class StreamReader : TextReader {
         public static readonly new StreamReader Null;
         public StreamReader(Stream stream);
         public StreamReader(Stream stream, bool detectEncodingFromByteOrderMarks);
         public StreamReader(Stream stream, Encoding encoding);
         public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks);
         public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
         public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen);
         public virtual Stream BaseStream { get; }
         public virtual Encoding CurrentEncoding { get; }
         public bool EndOfStream { get; }
         public void DiscardBufferedData();
         protected override void Dispose(bool disposing);
         public override int Peek();
         public override int Read();
         public override int Read(char[] buffer, int index, int count);
         public override Task<int> ReadAsync(char[] buffer, int index, int count);
         public override int ReadBlock(char[] buffer, int index, int count);
         public override Task<int> ReadBlockAsync(char[] buffer, int index, int count);
         public override string ReadLine();
         public override Task<string> ReadLineAsync();
         public override string ReadToEnd();
         public override Task<string> ReadToEndAsync();
     }
     public class StreamWriter : TextWriter {
         public static readonly new StreamWriter Null;
         public StreamWriter(Stream stream);
         public StreamWriter(Stream stream, Encoding encoding);
         public StreamWriter(Stream stream, Encoding encoding, int bufferSize);
         public StreamWriter(Stream stream, Encoding encoding, int bufferSize, bool leaveOpen);
         public virtual bool AutoFlush { get; set; }
         public virtual Stream BaseStream { get; }
         public override Encoding Encoding { get; }
         protected override void Dispose(bool disposing);
         public override void Flush();
         public override Task FlushAsync();
         public override void Write(char value);
         public override void Write(char[] buffer);
         public override void Write(char[] buffer, int index, int count);
         public override void Write(string value);
         public override Task WriteAsync(char value);
         public override Task WriteAsync(char[] buffer, int index, int count);
         public override Task WriteAsync(string value);
         public override Task WriteLineAsync();
         public override Task WriteLineAsync(char value);
         public override Task WriteLineAsync(char[] buffer, int index, int count);
         public override Task WriteLineAsync(string value);
     }
     public class StringReader : TextReader {
         public StringReader(string s);
         protected override void Dispose(bool disposing);
         public override int Peek();
         public override int Read();
         public override int Read(char[] buffer, int index, int count);
         public override Task<int> ReadAsync(char[] buffer, int index, int count);
         public override Task<int> ReadBlockAsync(char[] buffer, int index, int count);
         public override string ReadLine();
         public override Task<string> ReadLineAsync();
         public override string ReadToEnd();
         public override Task<string> ReadToEndAsync();
     }
     public class StringWriter : TextWriter {
         public StringWriter();
         public StringWriter(IFormatProvider formatProvider);
         public StringWriter(StringBuilder sb);
         public StringWriter(StringBuilder sb, IFormatProvider formatProvider);
         public override Encoding Encoding { get; }
         protected override void Dispose(bool disposing);
         public override Task FlushAsync();
         public virtual StringBuilder GetStringBuilder();
         public override string ToString();
         public override void Write(char value);
         public override void Write(char[] buffer, int index, int count);
         public override void Write(string value);
         public override Task WriteAsync(char value);
         public override Task WriteAsync(char[] buffer, int index, int count);
         public override Task WriteAsync(string value);
         public override Task WriteLineAsync(char value);
         public override Task WriteLineAsync(char[] buffer, int index, int count);
         public override Task WriteLineAsync(string value);
     }
     public abstract class TextReader : IDisposable {
         public static readonly TextReader Null;
         protected TextReader();
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public virtual int Peek();
         public virtual int Read();
         public virtual int Read(char[] buffer, int index, int count);
         public virtual Task<int> ReadAsync(char[] buffer, int index, int count);
         public virtual int ReadBlock(char[] buffer, int index, int count);
         public virtual Task<int> ReadBlockAsync(char[] buffer, int index, int count);
         public virtual string ReadLine();
         public virtual Task<string> ReadLineAsync();
         public virtual string ReadToEnd();
         public virtual Task<string> ReadToEndAsync();
     }
     public abstract class TextWriter : IDisposable {
         protected char[] CoreNewLine;
         public static readonly TextWriter Null;
         protected TextWriter();
         protected TextWriter(IFormatProvider formatProvider);
         public abstract Encoding Encoding { get; }
         public virtual IFormatProvider FormatProvider { get; }
         public virtual string NewLine { get; set; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public virtual void Flush();
         public virtual Task FlushAsync();
         public virtual void Write(bool value);
         public abstract void Write(char value);
         public virtual void Write(char[] buffer);
         public virtual void Write(char[] buffer, int index, int count);
         public virtual void Write(decimal value);
         public virtual void Write(double value);
         public virtual void Write(int value);
         public virtual void Write(long value);
         public virtual void Write(object value);
         public virtual void Write(float value);
         public virtual void Write(string value);
         public virtual void Write(string format, params object[] arg);
         public virtual void Write(uint value);
         public virtual void Write(ulong value);
         public virtual Task WriteAsync(char value);
         public Task WriteAsync(char[] buffer);
         public virtual Task WriteAsync(char[] buffer, int index, int count);
         public virtual Task WriteAsync(string value);
         public virtual void WriteLine();
         public virtual void WriteLine(bool value);
         public virtual void WriteLine(char value);
         public virtual void WriteLine(char[] buffer);
         public virtual void WriteLine(char[] buffer, int index, int count);
         public virtual void WriteLine(decimal value);
         public virtual void WriteLine(double value);
         public virtual void WriteLine(int value);
         public virtual void WriteLine(long value);
         public virtual void WriteLine(object value);
         public virtual void WriteLine(float value);
         public virtual void WriteLine(string value);
         public virtual void WriteLine(string format, params object[] arg);
         public virtual void WriteLine(uint value);
         public virtual void WriteLine(ulong value);
         public virtual Task WriteLineAsync();
         public virtual Task WriteLineAsync(char value);
         public Task WriteLineAsync(char[] buffer);
         public virtual Task WriteLineAsync(char[] buffer, int index, int count);
         public virtual Task WriteLineAsync(string value);
     }
 }
 namespace System.IO.Compression {
     public enum CompressionLevel {
         Fastest = 1,
         NoCompression = 2,
         Optimal = 0,
     }
     public enum CompressionMode {
         Compress = 1,
         Decompress = 0,
     }
     public class DeflateStream : Stream {
         public DeflateStream(Stream stream, CompressionLevel compressionLevel);
         public DeflateStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen);
         public DeflateStream(Stream stream, CompressionMode mode);
         public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen);
         public Stream BaseStream { get; }
         public override bool CanRead { get; }
         public override bool CanSeek { get; }
         public override bool CanWrite { get; }
         public override long Length { get; }
         public override long Position { get; set; }
         protected override void Dispose(bool disposing);
         public override void Flush();
         public override int Read(byte[] array, int offset, int count);
         public override long Seek(long offset, SeekOrigin origin);
         public override void SetLength(long value);
         public override void Write(byte[] array, int offset, int count);
     }
     public class GZipStream : Stream {
         public GZipStream(Stream stream, CompressionLevel compressionLevel);
         public GZipStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen);
         public GZipStream(Stream stream, CompressionMode mode);
         public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen);
         public Stream BaseStream { get; }
         public override bool CanRead { get; }
         public override bool CanSeek { get; }
         public override bool CanWrite { get; }
         public override long Length { get; }
         public override long Position { get; set; }
         protected override void Dispose(bool disposing);
         public override void Flush();
         public override int Read(byte[] array, int offset, int count);
         public override long Seek(long offset, SeekOrigin origin);
         public override void SetLength(long value);
         public override void Write(byte[] array, int offset, int count);
     }
     public class ZipArchive : IDisposable {
         public ZipArchive(Stream stream);
         public ZipArchive(Stream stream, ZipArchiveMode mode);
         public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen);
         public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen, Encoding entryNameEncoding);
         public ReadOnlyCollection<ZipArchiveEntry> Entries { get; }
         public ZipArchiveMode Mode { get; }
         public ZipArchiveEntry CreateEntry(string entryName);
         public ZipArchiveEntry CreateEntry(string entryName, CompressionLevel compressionLevel);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public ZipArchiveEntry GetEntry(string entryName);
     }
     public class ZipArchiveEntry {
         public ZipArchive Archive { get; }
         public long CompressedLength { get; }
         public string FullName { get; }
         public DateTimeOffset LastWriteTime { get; set; }
         public long Length { get; }
         public string Name { get; }
         public void Delete();
         public Stream Open();
         public override string ToString();
     }
     public enum ZipArchiveMode {
         Create = 1,
         Read = 0,
         Update = 2,
     }
 }
 namespace System.Linq {
     public static class Enumerable {
         public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);
         public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);
         public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);
         public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static bool Any<TSource>(this IEnumerable<TSource> source);
         public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source);
         public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
         public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
         public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
         public static Nullable<double> Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector);
         public static Nullable<double> Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector);
         public static float Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
         public static decimal Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
         public static Nullable<double> Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector);
         public static Nullable<float> Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector);
         public static Nullable<decimal> Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector);
         public static double Average(this IEnumerable<int> source);
         public static double Average(this IEnumerable<long> source);
         public static double Average(this IEnumerable<double> source);
         public static Nullable<double> Average(this IEnumerable<Nullable<int>> source);
         public static Nullable<double> Average(this IEnumerable<Nullable<long>> source);
         public static float Average(this IEnumerable<float> source);
         public static decimal Average(this IEnumerable<decimal> source);
         public static Nullable<double> Average(this IEnumerable<Nullable<double>> source);
         public static Nullable<float> Average(this IEnumerable<Nullable<float>> source);
         public static Nullable<decimal> Average(this IEnumerable<Nullable<decimal>> source);
         public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source);
         public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
         public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);
         public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
         public static int Count<TSource>(this IEnumerable<TSource> source);
         public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source);
         public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue);
         public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source);
         public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer);
         public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index);
         public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index);
         public static IEnumerable<TResult> Empty<TResult>();
         public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
         public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
         public static TSource First<TSource>(this IEnumerable<TSource> source);
         public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source);
         public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
         public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
         public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector);
         public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
         public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer);
         public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector);
         public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer);
         public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);
         public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer);
         public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
         public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
         public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector);
         public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer);
         public static TSource Last<TSource>(this IEnumerable<TSource> source);
         public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source);
         public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static long LongCount<TSource>(this IEnumerable<TSource> source);
         public static long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static TSource Max<TSource>(this IEnumerable<TSource> source);
         public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
         public static long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
         public static double Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
         public static Nullable<int> Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector);
         public static Nullable<long> Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector);
         public static float Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
         public static decimal Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
         public static Nullable<double> Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector);
         public static Nullable<float> Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector);
         public static Nullable<decimal> Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector);
         public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
         public static int Max(this IEnumerable<int> source);
         public static long Max(this IEnumerable<long> source);
         public static double Max(this IEnumerable<double> source);
         public static Nullable<int> Max(this IEnumerable<Nullable<int>> source);
         public static Nullable<long> Max(this IEnumerable<Nullable<long>> source);
         public static float Max(this IEnumerable<float> source);
         public static decimal Max(this IEnumerable<decimal> source);
         public static Nullable<double> Max(this IEnumerable<Nullable<double>> source);
         public static Nullable<float> Max(this IEnumerable<Nullable<float>> source);
         public static Nullable<decimal> Max(this IEnumerable<Nullable<decimal>> source);
         public static TSource Min<TSource>(this IEnumerable<TSource> source);
         public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
         public static long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
         public static double Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
         public static Nullable<int> Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector);
         public static Nullable<long> Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector);
         public static float Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
         public static decimal Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
         public static Nullable<double> Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector);
         public static Nullable<float> Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector);
         public static Nullable<decimal> Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector);
         public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
         public static int Min(this IEnumerable<int> source);
         public static long Min(this IEnumerable<long> source);
         public static double Min(this IEnumerable<double> source);
         public static Nullable<int> Min(this IEnumerable<Nullable<int>> source);
         public static Nullable<long> Min(this IEnumerable<Nullable<long>> source);
         public static float Min(this IEnumerable<float> source);
         public static decimal Min(this IEnumerable<decimal> source);
         public static Nullable<double> Min(this IEnumerable<Nullable<double>> source);
         public static Nullable<float> Min(this IEnumerable<Nullable<float>> source);
         public static Nullable<decimal> Min(this IEnumerable<Nullable<decimal>> source);
         public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source);
         public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
         public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
         public static IEnumerable<int> Range(int start, int count);
         public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count);
         public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source);
         public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
         public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
         public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
         public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
         public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
         public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
         public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
         public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
         public static TSource Single<TSource>(this IEnumerable<TSource> source);
         public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source);
         public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);
         public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
         public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
         public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
         public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
         public static Nullable<int> Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<int>> selector);
         public static Nullable<long> Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<long>> selector);
         public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
         public static decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
         public static Nullable<double> Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<double>> selector);
         public static Nullable<float> Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<float>> selector);
         public static Nullable<decimal> Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Nullable<decimal>> selector);
         public static int Sum(this IEnumerable<int> source);
         public static long Sum(this IEnumerable<long> source);
         public static double Sum(this IEnumerable<double> source);
         public static Nullable<int> Sum(this IEnumerable<Nullable<int>> source);
         public static Nullable<long> Sum(this IEnumerable<Nullable<long>> source);
         public static float Sum(this IEnumerable<float> source);
         public static decimal Sum(this IEnumerable<decimal> source);
         public static Nullable<double> Sum(this IEnumerable<Nullable<double>> source);
         public static Nullable<float> Sum(this IEnumerable<Nullable<float>> source);
         public static Nullable<decimal> Sum(this IEnumerable<Nullable<decimal>> source);
         public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count);
         public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
         public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
         public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
         public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source);
         public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
         public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
         public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
         public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source);
         public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
         public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
         public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
         public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
         public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
         public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
         public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
         public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
         public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector);
     }
     public interface IGrouping<out TKey, out TElement> : IEnumerable, IEnumerable<TElement> {
         TKey Key { get; }
     }
     public interface ILookup<TKey, TElement> : IEnumerable, IEnumerable<IGrouping<TKey, TElement>> {
         int Count { get; }
         IEnumerable<TElement> this[TKey key] { get; }
         bool Contains(TKey key);
     }
     public interface IOrderedEnumerable<TElement> : IEnumerable, IEnumerable<TElement> {
         IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
     }
     public interface IOrderedQueryable : IEnumerable, IQueryable
     public interface IOrderedQueryable<out T> : IEnumerable, IEnumerable<T>, IOrderedQueryable, IQueryable, IQueryable<T>
     public interface IQueryable : IEnumerable {
         Type ElementType { get; }
         Expression Expression { get; }
         IQueryProvider Provider { get; }
     }
     public interface IQueryable<out T> : IEnumerable, IEnumerable<T>, IQueryable
     public interface IQueryProvider {
         IQueryable<TElement> CreateQuery<TElement>(Expression expression);
         IQueryable CreateQuery(Expression expression);
         TResult Execute<TResult>(Expression expression);
         object Execute(Expression expression);
     }
     public class Lookup<TKey, TElement> : IEnumerable, IEnumerable<IGrouping<TKey, TElement>>, ILookup<TKey, TElement> {
         public int Count { get; }
         public IEnumerable<TElement> this[TKey key] { get; }
         public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IEnumerable<TElement>, TResult> resultSelector);
         public bool Contains(TKey key);
         public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator();
     }
 }
 namespace System.Linq.Expressions {
     public class BinaryExpression : Expression {
         public override bool CanReduce { get; }
         public LambdaExpression Conversion { get; }
         public bool IsLifted { get; }
         public bool IsLiftedToNull { get; }
         public Expression Left { get; }
         public MethodInfo Method { get; }
         public Expression Right { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public override Expression Reduce();
         public BinaryExpression Update(Expression left, LambdaExpression conversion, Expression right);
     }
     public class BlockExpression : Expression {
         public ReadOnlyCollection<Expression> Expressions { get; }
         public sealed override ExpressionType NodeType { get; }
         public Expression Result { get; }
         public override Type Type { get; }
         public ReadOnlyCollection<ParameterExpression> Variables { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public BlockExpression Update(IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions);
     }
     public sealed class CatchBlock {
         public Expression Body { get; }
         public Expression Filter { get; }
         public Type Test { get; }
         public ParameterExpression Variable { get; }
         public override string ToString();
         public CatchBlock Update(ParameterExpression variable, Expression filter, Expression body);
     }
     public class ConditionalExpression : Expression {
         public Expression IfFalse { get; }
         public Expression IfTrue { get; }
         public sealed override ExpressionType NodeType { get; }
         public Expression Test { get; }
         public override Type Type { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public ConditionalExpression Update(Expression test, Expression ifTrue, Expression ifFalse);
     }
     public class ConstantExpression : Expression {
         public sealed override ExpressionType NodeType { get; }
         public override Type Type { get; }
         public object Value { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
     }
     public class DebugInfoExpression : Expression {
         public SymbolDocumentInfo Document { get; }
         public virtual int EndColumn { get; }
         public virtual int EndLine { get; }
         public virtual bool IsClear { get; }
         public sealed override ExpressionType NodeType { get; }
         public virtual int StartColumn { get; }
         public virtual int StartLine { get; }
         public sealed override Type Type { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
     }
     public sealed class DefaultExpression : Expression {
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
     }
     public sealed class ElementInit {
         public MethodInfo AddMethod { get; }
         public ReadOnlyCollection<Expression> Arguments { get; }
         public override string ToString();
         public ElementInit Update(IEnumerable<Expression> arguments);
     }
     public abstract class Expression {
         protected Expression();
         public virtual bool CanReduce { get; }
         public virtual ExpressionType NodeType { get; }
         public virtual Type Type { get; }
         protected internal virtual Expression Accept(ExpressionVisitor visitor);
         public static BinaryExpression Add(Expression left, Expression right);
         public static BinaryExpression Add(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression AddAssign(Expression left, Expression right);
         public static BinaryExpression AddAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression AddAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression AddAssignChecked(Expression left, Expression right);
         public static BinaryExpression AddAssignChecked(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression AddAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression AddChecked(Expression left, Expression right);
         public static BinaryExpression AddChecked(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression And(Expression left, Expression right);
         public static BinaryExpression And(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression AndAlso(Expression left, Expression right);
         public static BinaryExpression AndAlso(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression AndAssign(Expression left, Expression right);
         public static BinaryExpression AndAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression AndAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static IndexExpression ArrayAccess(Expression array, params Expression[] indexes);
         public static IndexExpression ArrayAccess(Expression array, IEnumerable<Expression> indexes);
         public static BinaryExpression ArrayIndex(Expression array, Expression index);
         public static MethodCallExpression ArrayIndex(Expression array, params Expression[] indexes);
         public static MethodCallExpression ArrayIndex(Expression array, IEnumerable<Expression> indexes);
         public static UnaryExpression ArrayLength(Expression array);
         public static BinaryExpression Assign(Expression left, Expression right);
         public static MemberAssignment Bind(MemberInfo member, Expression expression);
         public static MemberAssignment Bind(MethodInfo propertyAccessor, Expression expression);
         public static BlockExpression Block(Expression arg0, Expression arg1);
         public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2);
         public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2, Expression arg3);
         public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4);
         public static BlockExpression Block(params Expression[] expressions);
         public static BlockExpression Block(IEnumerable<Expression> expressions);
         public static BlockExpression Block(IEnumerable<ParameterExpression> variables, params Expression[] expressions);
         public static BlockExpression Block(IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions);
         public static BlockExpression Block(Type type, params Expression[] expressions);
         public static BlockExpression Block(Type type, IEnumerable<Expression> expressions);
         public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, params Expression[] expressions);
         public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions);
         public static GotoExpression Break(LabelTarget target);
         public static GotoExpression Break(LabelTarget target, Expression value);
         public static GotoExpression Break(LabelTarget target, Expression value, Type type);
         public static GotoExpression Break(LabelTarget target, Type type);
         public static MethodCallExpression Call(Expression instance, MethodInfo method);
         public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1);
         public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2);
         public static MethodCallExpression Call(Expression instance, MethodInfo method, params Expression[] arguments);
         public static MethodCallExpression Call(Expression instance, MethodInfo method, IEnumerable<Expression> arguments);
         public static MethodCallExpression Call(Expression instance, string methodName, Type[] typeArguments, params Expression[] arguments);
         public static MethodCallExpression Call(MethodInfo method, Expression arg0);
         public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1);
         public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2);
         public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3);
         public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4);
         public static MethodCallExpression Call(MethodInfo method, params Expression[] arguments);
         public static MethodCallExpression Call(MethodInfo method, IEnumerable<Expression> arguments);
         public static MethodCallExpression Call(Type type, string methodName, Type[] typeArguments, params Expression[] arguments);
         public static CatchBlock Catch(ParameterExpression variable, Expression body);
         public static CatchBlock Catch(ParameterExpression variable, Expression body, Expression filter);
         public static CatchBlock Catch(Type type, Expression body);
         public static CatchBlock Catch(Type type, Expression body, Expression filter);
         public static DebugInfoExpression ClearDebugInfo(SymbolDocumentInfo document);
         public static BinaryExpression Coalesce(Expression left, Expression right);
         public static BinaryExpression Coalesce(Expression left, Expression right, LambdaExpression conversion);
         public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse);
         public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse, Type type);
         public static ConstantExpression Constant(object value);
         public static ConstantExpression Constant(object value, Type type);
         public static GotoExpression Continue(LabelTarget target);
         public static GotoExpression Continue(LabelTarget target, Type type);
         public static UnaryExpression Convert(Expression expression, Type type);
         public static UnaryExpression Convert(Expression expression, Type type, MethodInfo method);
         public static UnaryExpression ConvertChecked(Expression expression, Type type);
         public static UnaryExpression ConvertChecked(Expression expression, Type type, MethodInfo method);
         public static DebugInfoExpression DebugInfo(SymbolDocumentInfo document, int startLine, int startColumn, int endLine, int endColumn);
         public static UnaryExpression Decrement(Expression expression);
         public static UnaryExpression Decrement(Expression expression, MethodInfo method);
         public static DefaultExpression Default(Type type);
         public static BinaryExpression Divide(Expression left, Expression right);
         public static BinaryExpression Divide(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression DivideAssign(Expression left, Expression right);
         public static BinaryExpression DivideAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression DivideAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static ElementInit ElementInit(MethodInfo addMethod, params Expression[] arguments);
         public static ElementInit ElementInit(MethodInfo addMethod, IEnumerable<Expression> arguments);
         public static DefaultExpression Empty();
         public static BinaryExpression Equal(Expression left, Expression right);
         public static BinaryExpression Equal(Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static BinaryExpression ExclusiveOr(Expression left, Expression right);
         public static BinaryExpression ExclusiveOr(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right);
         public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static MemberExpression Field(Expression expression, FieldInfo field);
         public static MemberExpression Field(Expression expression, string fieldName);
         public static MemberExpression Field(Expression expression, Type type, string fieldName);
         public static Type GetActionType(params Type[] typeArgs);
         public static Type GetDelegateType(params Type[] typeArgs);
         public static Type GetFuncType(params Type[] typeArgs);
         public static GotoExpression Goto(LabelTarget target);
         public static GotoExpression Goto(LabelTarget target, Expression value);
         public static GotoExpression Goto(LabelTarget target, Expression value, Type type);
         public static GotoExpression Goto(LabelTarget target, Type type);
         public static BinaryExpression GreaterThan(Expression left, Expression right);
         public static BinaryExpression GreaterThan(Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right);
         public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static ConditionalExpression IfThen(Expression test, Expression ifTrue);
         public static ConditionalExpression IfThenElse(Expression test, Expression ifTrue, Expression ifFalse);
         public static UnaryExpression Increment(Expression expression);
         public static UnaryExpression Increment(Expression expression, MethodInfo method);
         public static InvocationExpression Invoke(Expression expression, params Expression[] arguments);
         public static InvocationExpression Invoke(Expression expression, IEnumerable<Expression> arguments);
         public static UnaryExpression IsFalse(Expression expression);
         public static UnaryExpression IsFalse(Expression expression, MethodInfo method);
         public static UnaryExpression IsTrue(Expression expression);
         public static UnaryExpression IsTrue(Expression expression, MethodInfo method);
         public static LabelTarget Label();
         public static LabelExpression Label(LabelTarget target);
         public static LabelExpression Label(LabelTarget target, Expression defaultValue);
         public static LabelTarget Label(string name);
         public static LabelTarget Label(Type type);
         public static LabelTarget Label(Type type, string name);
         public static Expression<TDelegate> Lambda<TDelegate>(Expression body, params ParameterExpression[] parameters);
         public static Expression<TDelegate> Lambda<TDelegate>(Expression body, bool tailCall, params ParameterExpression[] parameters);
         public static Expression<TDelegate> Lambda<TDelegate>(Expression body, IEnumerable<ParameterExpression> parameters);
         public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, IEnumerable<ParameterExpression> parameters);
         public static Expression<TDelegate> Lambda<TDelegate>(Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
         public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Expression body, bool tailCall, params ParameterExpression[] parameters);
         public static LambdaExpression Lambda(Expression body, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Expression body, params ParameterExpression[] parameters);
         public static LambdaExpression Lambda(Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Expression body, string name, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Type delegateType, Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Type delegateType, Expression body, bool tailCall, params ParameterExpression[] parameters);
         public static LambdaExpression Lambda(Type delegateType, Expression body, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Type delegateType, Expression body, params ParameterExpression[] parameters);
         public static LambdaExpression Lambda(Type delegateType, Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
         public static LambdaExpression Lambda(Type delegateType, Expression body, string name, IEnumerable<ParameterExpression> parameters);
         public static BinaryExpression LeftShift(Expression left, Expression right);
         public static BinaryExpression LeftShift(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression LeftShiftAssign(Expression left, Expression right);
         public static BinaryExpression LeftShiftAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression LeftShiftAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression LessThan(Expression left, Expression right);
         public static BinaryExpression LessThan(Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static BinaryExpression LessThanOrEqual(Expression left, Expression right);
         public static BinaryExpression LessThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static MemberListBinding ListBind(MemberInfo member, params ElementInit[] initializers);
         public static MemberListBinding ListBind(MemberInfo member, IEnumerable<ElementInit> initializers);
         public static MemberListBinding ListBind(MethodInfo propertyAccessor, params ElementInit[] initializers);
         public static MemberListBinding ListBind(MethodInfo propertyAccessor, IEnumerable<ElementInit> initializers);
         public static ListInitExpression ListInit(NewExpression newExpression, params ElementInit[] initializers);
         public static ListInitExpression ListInit(NewExpression newExpression, params Expression[] initializers);
         public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<Expression> initializers);
         public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<ElementInit> initializers);
         public static ListInitExpression ListInit(NewExpression newExpression, MethodInfo addMethod, params Expression[] initializers);
         public static ListInitExpression ListInit(NewExpression newExpression, MethodInfo addMethod, IEnumerable<Expression> initializers);
         public static LoopExpression Loop(Expression body);
         public static LoopExpression Loop(Expression body, LabelTarget @break);
         public static LoopExpression Loop(Expression body, LabelTarget @break, LabelTarget @continue);
         public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right);
         public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method, LambdaExpression conversion);
         public static CatchBlock MakeCatchBlock(Type type, ParameterExpression variable, Expression body, Expression filter);
         public static GotoExpression MakeGoto(GotoExpressionKind kind, LabelTarget target, Expression value, Type type);
         public static IndexExpression MakeIndex(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments);
         public static MemberExpression MakeMemberAccess(Expression expression, MemberInfo member);
         public static TryExpression MakeTry(Type type, Expression body, Expression @finally, Expression fault, IEnumerable<CatchBlock> handlers);
         public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type);
         public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type, MethodInfo method);
         public static MemberMemberBinding MemberBind(MemberInfo member, IEnumerable<MemberBinding> bindings);
         public static MemberMemberBinding MemberBind(MemberInfo member, params MemberBinding[] bindings);
         public static MemberMemberBinding MemberBind(MethodInfo propertyAccessor, IEnumerable<MemberBinding> bindings);
         public static MemberMemberBinding MemberBind(MethodInfo propertyAccessor, params MemberBinding[] bindings);
         public static MemberInitExpression MemberInit(NewExpression newExpression, IEnumerable<MemberBinding> bindings);
         public static MemberInitExpression MemberInit(NewExpression newExpression, params MemberBinding[] bindings);
         public static BinaryExpression Modulo(Expression left, Expression right);
         public static BinaryExpression Modulo(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression ModuloAssign(Expression left, Expression right);
         public static BinaryExpression ModuloAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression ModuloAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression Multiply(Expression left, Expression right);
         public static BinaryExpression Multiply(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression MultiplyAssign(Expression left, Expression right);
         public static BinaryExpression MultiplyAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression MultiplyAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right);
         public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression MultiplyChecked(Expression left, Expression right);
         public static BinaryExpression MultiplyChecked(Expression left, Expression right, MethodInfo method);
         public static UnaryExpression Negate(Expression expression);
         public static UnaryExpression Negate(Expression expression, MethodInfo method);
         public static UnaryExpression NegateChecked(Expression expression);
         public static UnaryExpression NegateChecked(Expression expression, MethodInfo method);
         public static NewExpression New(ConstructorInfo constructor);
         public static NewExpression New(ConstructorInfo constructor, params Expression[] arguments);
         public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> arguments);
         public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> arguments, params MemberInfo[] members);
         public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> arguments, IEnumerable<MemberInfo> members);
         public static NewExpression New(Type type);
         public static NewArrayExpression NewArrayBounds(Type type, params Expression[] bounds);
         public static NewArrayExpression NewArrayBounds(Type type, IEnumerable<Expression> bounds);
         public static NewArrayExpression NewArrayInit(Type type, params Expression[] initializers);
         public static NewArrayExpression NewArrayInit(Type type, IEnumerable<Expression> initializers);
         public static UnaryExpression Not(Expression expression);
         public static UnaryExpression Not(Expression expression, MethodInfo method);
         public static BinaryExpression NotEqual(Expression left, Expression right);
         public static BinaryExpression NotEqual(Expression left, Expression right, bool liftToNull, MethodInfo method);
         public static UnaryExpression OnesComplement(Expression expression);
         public static UnaryExpression OnesComplement(Expression expression, MethodInfo method);
         public static BinaryExpression Or(Expression left, Expression right);
         public static BinaryExpression Or(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression OrAssign(Expression left, Expression right);
         public static BinaryExpression OrAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression OrAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression OrElse(Expression left, Expression right);
         public static BinaryExpression OrElse(Expression left, Expression right, MethodInfo method);
         public static ParameterExpression Parameter(Type type);
         public static ParameterExpression Parameter(Type type, string name);
         public static UnaryExpression PostDecrementAssign(Expression expression);
         public static UnaryExpression PostDecrementAssign(Expression expression, MethodInfo method);
         public static UnaryExpression PostIncrementAssign(Expression expression);
         public static UnaryExpression PostIncrementAssign(Expression expression, MethodInfo method);
         public static BinaryExpression Power(Expression left, Expression right);
         public static BinaryExpression Power(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression PowerAssign(Expression left, Expression right);
         public static BinaryExpression PowerAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression PowerAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static UnaryExpression PreDecrementAssign(Expression expression);
         public static UnaryExpression PreDecrementAssign(Expression expression, MethodInfo method);
         public static UnaryExpression PreIncrementAssign(Expression expression);
         public static UnaryExpression PreIncrementAssign(Expression expression, MethodInfo method);
         public static MemberExpression Property(Expression expression, MethodInfo propertyAccessor);
         public static MemberExpression Property(Expression expression, PropertyInfo property);
         public static IndexExpression Property(Expression instance, PropertyInfo indexer, params Expression[] arguments);
         public static IndexExpression Property(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments);
         public static MemberExpression Property(Expression expression, string propertyName);
         public static IndexExpression Property(Expression instance, string propertyName, params Expression[] arguments);
         public static MemberExpression Property(Expression expression, Type type, string propertyName);
         public static MemberExpression PropertyOrField(Expression expression, string propertyOrFieldName);
         public static UnaryExpression Quote(Expression expression);
         public virtual Expression Reduce();
         public Expression ReduceAndCheck();
         public Expression ReduceExtensions();
         public static BinaryExpression ReferenceEqual(Expression left, Expression right);
         public static BinaryExpression ReferenceNotEqual(Expression left, Expression right);
         public static UnaryExpression Rethrow();
         public static UnaryExpression Rethrow(Type type);
         public static GotoExpression Return(LabelTarget target);
         public static GotoExpression Return(LabelTarget target, Expression value);
         public static GotoExpression Return(LabelTarget target, Expression value, Type type);
         public static GotoExpression Return(LabelTarget target, Type type);
         public static BinaryExpression RightShift(Expression left, Expression right);
         public static BinaryExpression RightShift(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression RightShiftAssign(Expression left, Expression right);
         public static BinaryExpression RightShiftAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression RightShiftAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static RuntimeVariablesExpression RuntimeVariables(IEnumerable<ParameterExpression> variables);
         public static RuntimeVariablesExpression RuntimeVariables(params ParameterExpression[] variables);
         public static BinaryExpression Subtract(Expression left, Expression right);
         public static BinaryExpression Subtract(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression SubtractAssign(Expression left, Expression right);
         public static BinaryExpression SubtractAssign(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression SubtractAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression SubtractAssignChecked(Expression left, Expression right);
         public static BinaryExpression SubtractAssignChecked(Expression left, Expression right, MethodInfo method);
         public static BinaryExpression SubtractAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
         public static BinaryExpression SubtractChecked(Expression left, Expression right);
         public static BinaryExpression SubtractChecked(Expression left, Expression right, MethodInfo method);
         public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, MethodInfo comparison, IEnumerable<SwitchCase> cases);
         public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, MethodInfo comparison, params SwitchCase[] cases);
         public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, params SwitchCase[] cases);
         public static SwitchExpression Switch(Expression switchValue, params SwitchCase[] cases);
         public static SwitchExpression Switch(Type type, Expression switchValue, Expression defaultBody, MethodInfo comparison, IEnumerable<SwitchCase> cases);
         public static SwitchExpression Switch(Type type, Expression switchValue, Expression defaultBody, MethodInfo comparison, params SwitchCase[] cases);
         public static SwitchCase SwitchCase(Expression body, params Expression[] testValues);
         public static SwitchCase SwitchCase(Expression body, IEnumerable<Expression> testValues);
         public static SymbolDocumentInfo SymbolDocument(string fileName);
         public static SymbolDocumentInfo SymbolDocument(string fileName, Guid language);
         public static SymbolDocumentInfo SymbolDocument(string fileName, Guid language, Guid languageVendor);
         public static SymbolDocumentInfo SymbolDocument(string fileName, Guid language, Guid languageVendor, Guid documentType);
         public static UnaryExpression Throw(Expression value);
         public static UnaryExpression Throw(Expression value, Type type);
         public override string ToString();
         public static TryExpression TryCatch(Expression body, params CatchBlock[] handlers);
         public static TryExpression TryCatchFinally(Expression body, Expression @finally, params CatchBlock[] handlers);
         public static TryExpression TryFault(Expression body, Expression fault);
         public static TryExpression TryFinally(Expression body, Expression @finally);
         public static bool TryGetActionType(Type[] typeArgs, out Type actionType);
         public static bool TryGetFuncType(Type[] typeArgs, out Type funcType);
         public static UnaryExpression TypeAs(Expression expression, Type type);
         public static TypeBinaryExpression TypeEqual(Expression expression, Type type);
         public static TypeBinaryExpression TypeIs(Expression expression, Type type);
         public static UnaryExpression UnaryPlus(Expression expression);
         public static UnaryExpression UnaryPlus(Expression expression, MethodInfo method);
         public static UnaryExpression Unbox(Expression expression, Type type);
         public static ParameterExpression Variable(Type type);
         public static ParameterExpression Variable(Type type, string name);
         protected internal virtual Expression VisitChildren(ExpressionVisitor visitor);
     }
     public sealed class Expression<TDelegate> : LambdaExpression {
         public new TDelegate Compile();
         public Expression<TDelegate> Update(Expression body, IEnumerable<ParameterExpression> parameters);
     }
     public enum ExpressionType {
         Add = 0,
         AddAssign = 63,
         AddAssignChecked = 74,
         AddChecked = 1,
         And = 2,
         AndAlso = 3,
         AndAssign = 64,
         ArrayIndex = 5,
         ArrayLength = 4,
         Assign = 46,
         Block = 47,
         Call = 6,
         Coalesce = 7,
         Conditional = 8,
         Constant = 9,
         Convert = 10,
         ConvertChecked = 11,
         DebugInfo = 48,
         Decrement = 49,
         Default = 51,
         Divide = 12,
         DivideAssign = 65,
         Dynamic = 50,
         Equal = 13,
         ExclusiveOr = 14,
         ExclusiveOrAssign = 66,
         Extension = 52,
         Goto = 53,
         GreaterThan = 15,
         GreaterThanOrEqual = 16,
         Increment = 54,
         Index = 55,
         Invoke = 17,
         IsFalse = 84,
         IsTrue = 83,
         Label = 56,
         Lambda = 18,
         LeftShift = 19,
         LeftShiftAssign = 67,
         LessThan = 20,
         LessThanOrEqual = 21,
         ListInit = 22,
         Loop = 58,
         MemberAccess = 23,
         MemberInit = 24,
         Modulo = 25,
         ModuloAssign = 68,
         Multiply = 26,
         MultiplyAssign = 69,
         MultiplyAssignChecked = 75,
         MultiplyChecked = 27,
         Negate = 28,
         NegateChecked = 30,
         New = 31,
         NewArrayBounds = 33,
         NewArrayInit = 32,
         Not = 34,
         NotEqual = 35,
         OnesComplement = 82,
         Or = 36,
         OrAssign = 70,
         OrElse = 37,
         Parameter = 38,
         PostDecrementAssign = 80,
         PostIncrementAssign = 79,
         Power = 39,
         PowerAssign = 71,
         PreDecrementAssign = 78,
         PreIncrementAssign = 77,
         Quote = 40,
         RightShift = 41,
         RightShiftAssign = 72,
         RuntimeVariables = 57,
         Subtract = 42,
         SubtractAssign = 73,
         SubtractAssignChecked = 76,
         SubtractChecked = 43,
         Switch = 59,
         Throw = 60,
         Try = 61,
         TypeAs = 44,
         TypeEqual = 81,
         TypeIs = 45,
         UnaryPlus = 29,
         Unbox = 62,
     }
     public abstract class ExpressionVisitor {
         protected ExpressionVisitor();
         public static ReadOnlyCollection<T> Visit<T>(ReadOnlyCollection<T> nodes, Func<T, T> elementVisitor);
         public virtual Expression Visit(Expression node);
         public ReadOnlyCollection<Expression> Visit(ReadOnlyCollection<Expression> nodes);
         public T VisitAndConvert<T>(T node, string callerName) where T : Expression;
         public ReadOnlyCollection<T> VisitAndConvert<T>(ReadOnlyCollection<T> nodes, string callerName) where T : Expression;
         protected internal virtual Expression VisitBinary(BinaryExpression node);
         protected internal virtual Expression VisitBlock(BlockExpression node);
         protected virtual CatchBlock VisitCatchBlock(CatchBlock node);
         protected internal virtual Expression VisitConditional(ConditionalExpression node);
         protected internal virtual Expression VisitConstant(ConstantExpression node);
         protected internal virtual Expression VisitDebugInfo(DebugInfoExpression node);
         protected internal virtual Expression VisitDefault(DefaultExpression node);
         protected virtual ElementInit VisitElementInit(ElementInit node);
         protected internal virtual Expression VisitExtension(Expression node);
         protected internal virtual Expression VisitGoto(GotoExpression node);
         protected internal virtual Expression VisitIndex(IndexExpression node);
         protected internal virtual Expression VisitInvocation(InvocationExpression node);
         protected internal virtual Expression VisitLabel(LabelExpression node);
         protected virtual LabelTarget VisitLabelTarget(LabelTarget node);
         protected internal virtual Expression VisitLambda<T>(Expression<T> node);
         protected internal virtual Expression VisitListInit(ListInitExpression node);
         protected internal virtual Expression VisitLoop(LoopExpression node);
         protected internal virtual Expression VisitMember(MemberExpression node);
         protected virtual MemberAssignment VisitMemberAssignment(MemberAssignment node);
         protected virtual MemberBinding VisitMemberBinding(MemberBinding node);
         protected internal virtual Expression VisitMemberInit(MemberInitExpression node);
         protected virtual MemberListBinding VisitMemberListBinding(MemberListBinding node);
         protected virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node);
         protected internal virtual Expression VisitMethodCall(MethodCallExpression node);
         protected internal virtual Expression VisitNew(NewExpression node);
         protected internal virtual Expression VisitNewArray(NewArrayExpression node);
         protected internal virtual Expression VisitParameter(ParameterExpression node);
         protected internal virtual Expression VisitRuntimeVariables(RuntimeVariablesExpression node);
         protected internal virtual Expression VisitSwitch(SwitchExpression node);
         protected virtual SwitchCase VisitSwitchCase(SwitchCase node);
         protected internal virtual Expression VisitTry(TryExpression node);
         protected internal virtual Expression VisitTypeBinary(TypeBinaryExpression node);
         protected internal virtual Expression VisitUnary(UnaryExpression node);
     }
     public sealed class GotoExpression : Expression {
         public GotoExpressionKind Kind { get; }
         public sealed override ExpressionType NodeType { get; }
         public LabelTarget Target { get; }
         public sealed override Type Type { get; }
         public Expression Value { get; }
         public GotoExpression Update(LabelTarget target, Expression value);
     }
     public enum GotoExpressionKind {
         Break = 2,
         Continue = 3,
         Goto = 0,
         Return = 1,
     }
     public sealed class IndexExpression : Expression {
         public ReadOnlyCollection<Expression> Arguments { get; }
         public PropertyInfo Indexer { get; }
         public sealed override ExpressionType NodeType { get; }
         public Expression Object { get; }
         public sealed override Type Type { get; }
         public IndexExpression Update(Expression @object, IEnumerable<Expression> arguments);
     }
     public sealed class InvocationExpression : Expression {
         public ReadOnlyCollection<Expression> Arguments { get; }
         public Expression Expression { get; }
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public InvocationExpression Update(Expression expression, IEnumerable<Expression> arguments);
     }
     public sealed class LabelExpression : Expression {
         public Expression DefaultValue { get; }
         public sealed override ExpressionType NodeType { get; }
         public LabelTarget Target { get; }
         public sealed override Type Type { get; }
         public LabelExpression Update(LabelTarget target, Expression defaultValue);
     }
     public sealed class LabelTarget {
         public string Name { get; }
         public Type Type { get; }
         public override string ToString();
     }
     public abstract class LambdaExpression : Expression {
         public Expression Body { get; }
         public string Name { get; }
         public sealed override ExpressionType NodeType { get; }
         public ReadOnlyCollection<ParameterExpression> Parameters { get; }
         public Type ReturnType { get; }
         public bool TailCall { get; }
         public sealed override Type Type { get; }
         public Delegate Compile();
     }
     public sealed class ListInitExpression : Expression {
         public override bool CanReduce { get; }
         public ReadOnlyCollection<ElementInit> Initializers { get; }
         public NewExpression NewExpression { get; }
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public override Expression Reduce();
         public ListInitExpression Update(NewExpression newExpression, IEnumerable<ElementInit> initializers);
     }
     public sealed class LoopExpression : Expression {
         public Expression Body { get; }
         public LabelTarget BreakLabel { get; }
         public LabelTarget ContinueLabel { get; }
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public LoopExpression Update(LabelTarget breakLabel, LabelTarget continueLabel, Expression body);
     }
     public sealed class MemberAssignment : MemberBinding {
         public Expression Expression { get; }
         public MemberAssignment Update(Expression expression);
     }
     public abstract class MemberBinding {
         public MemberBindingType BindingType { get; }
         public MemberInfo Member { get; }
         public override string ToString();
     }
     public enum MemberBindingType {
         Assignment = 0,
         ListBinding = 2,
         MemberBinding = 1,
     }
     public class MemberExpression : Expression {
         public Expression Expression { get; }
         public MemberInfo Member { get; }
         public sealed override ExpressionType NodeType { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public MemberExpression Update(Expression expression);
     }
     public sealed class MemberInitExpression : Expression {
         public ReadOnlyCollection<MemberBinding> Bindings { get; }
         public override bool CanReduce { get; }
         public NewExpression NewExpression { get; }
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public override Expression Reduce();
         public MemberInitExpression Update(NewExpression newExpression, IEnumerable<MemberBinding> bindings);
     }
     public sealed class MemberListBinding : MemberBinding {
         public ReadOnlyCollection<ElementInit> Initializers { get; }
         public MemberListBinding Update(IEnumerable<ElementInit> initializers);
     }
     public sealed class MemberMemberBinding : MemberBinding {
         public ReadOnlyCollection<MemberBinding> Bindings { get; }
         public MemberMemberBinding Update(IEnumerable<MemberBinding> bindings);
     }
     public class MethodCallExpression : Expression {
         public ReadOnlyCollection<Expression> Arguments { get; }
         public MethodInfo Method { get; }
         public sealed override ExpressionType NodeType { get; }
         public Expression Object { get; }
         public sealed override Type Type { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public MethodCallExpression Update(Expression @object, IEnumerable<Expression> arguments);
     }
     public class NewArrayExpression : Expression {
         public ReadOnlyCollection<Expression> Expressions { get; }
         public sealed override Type Type { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public NewArrayExpression Update(IEnumerable<Expression> expressions);
     }
     public class NewExpression : Expression {
         public ReadOnlyCollection<Expression> Arguments { get; }
         public ConstructorInfo Constructor { get; }
         public ReadOnlyCollection<MemberInfo> Members { get; }
         public sealed override ExpressionType NodeType { get; }
         public override Type Type { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
         public NewExpression Update(IEnumerable<Expression> arguments);
     }
     public class ParameterExpression : Expression {
         public bool IsByRef { get; }
         public string Name { get; }
         public sealed override ExpressionType NodeType { get; }
         public override Type Type { get; }
         protected internal override Expression Accept(ExpressionVisitor visitor);
     }
     public sealed class RuntimeVariablesExpression : Expression {
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public ReadOnlyCollection<ParameterExpression> Variables { get; }
         public RuntimeVariablesExpression Update(IEnumerable<ParameterExpression> variables);
     }
     public sealed class SwitchCase {
         public Expression Body { get; }
         public ReadOnlyCollection<Expression> TestValues { get; }
         public override string ToString();
         public SwitchCase Update(IEnumerable<Expression> testValues, Expression body);
     }
     public sealed class SwitchExpression : Expression {
         public ReadOnlyCollection<SwitchCase> Cases { get; }
         public MethodInfo Comparison { get; }
         public Expression DefaultBody { get; }
         public sealed override ExpressionType NodeType { get; }
         public Expression SwitchValue { get; }
         public sealed override Type Type { get; }
         public SwitchExpression Update(Expression switchValue, IEnumerable<SwitchCase> cases, Expression defaultBody);
     }
     public class SymbolDocumentInfo {
         public virtual Guid DocumentType { get; }
         public string FileName { get; }
         public virtual Guid Language { get; }
         public virtual Guid LanguageVendor { get; }
     }
     public sealed class TryExpression : Expression {
         public Expression Body { get; }
         public Expression Fault { get; }
         public Expression Finally { get; }
         public ReadOnlyCollection<CatchBlock> Handlers { get; }
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public TryExpression Update(Expression body, IEnumerable<CatchBlock> handlers, Expression @finally, Expression fault);
     }
     public sealed class TypeBinaryExpression : Expression {
         public Expression Expression { get; }
         public sealed override ExpressionType NodeType { get; }
         public sealed override Type Type { get; }
         public Type TypeOperand { get; }
         public TypeBinaryExpression Update(Expression expression);
     }
     public sealed class UnaryExpression : Expression {
         public override bool CanReduce { get; }
         public bool IsLifted { get; }
         public bool IsLiftedToNull { get; }
         public MethodInfo Method { get; }
         public sealed override ExpressionType NodeType { get; }
         public Expression Operand { get; }
         public sealed override Type Type { get; }
         public override Expression Reduce();
         public UnaryExpression Update(Expression operand);
     }
 }
 namespace System.Net {
     public enum AuthenticationSchemes {
         Anonymous = 32768,
         Basic = 8,
         Digest = 1,
         IntegratedWindowsAuthentication = 6,
         Negotiate = 2,
         None = 0,
         Ntlm = 4,
     }
     public sealed class Cookie {
         public Cookie();
         public Cookie(string name, string value);
         public Cookie(string name, string value, string path);
         public Cookie(string name, string value, string path, string domain);
         public string Comment { get; set; }
         public Uri CommentUri { get; set; }
         public bool Discard { get; set; }
         public string Domain { get; set; }
         public bool Expired { get; set; }
         public DateTime Expires { get; set; }
         public bool HttpOnly { get; set; }
         public string Name { get; set; }
         public string Path { get; set; }
         public string Port { get; set; }
         public bool Secure { get; set; }
         public DateTime TimeStamp { get; }
         public string Value { get; set; }
         public int Version { get; set; }
         public override bool Equals(object comparand);
         public override int GetHashCode();
         public override string ToString();
     }
     public class CookieCollection : ICollection, IEnumerable {
         public CookieCollection();
         public int Count { get; }
         public Cookie this[string name] { get; }
         public void Add(Cookie cookie);
         public void Add(CookieCollection cookies);
         public IEnumerator GetEnumerator();
     }
     public class CookieContainer {
         public const int DefaultCookieLengthLimit = 4096;
         public const int DefaultCookieLimit = 300;
         public const int DefaultPerDomainCookieLimit = 20;
         public CookieContainer();
         public int Capacity { get; set; }
         public int Count { get; }
         public int MaxCookieSize { get; set; }
         public int PerDomainCapacity { get; set; }
         public void Add(Uri uri, Cookie cookie);
         public void Add(Uri uri, CookieCollection cookies);
         public string GetCookieHeader(Uri uri);
         public CookieCollection GetCookies(Uri uri);
         public void SetCookies(Uri uri, string cookieHeader);
     }
     public class CookieException : FormatException {
         public CookieException();
     }
     public class CredentialCache : ICredentials, ICredentialsByHost, IEnumerable {
         public CredentialCache();
         public static ICredentials DefaultCredentials { get; }
         public static NetworkCredential DefaultNetworkCredentials { get; }
         public void Add(string host, int port, string authenticationType, NetworkCredential credential);
         public void Add(Uri uriPrefix, string authType, NetworkCredential cred);
         public NetworkCredential GetCredential(string host, int port, string authenticationType);
         public NetworkCredential GetCredential(Uri uriPrefix, string authType);
         public IEnumerator GetEnumerator();
         public void Remove(string host, int port, string authenticationType);
         public void Remove(Uri uriPrefix, string authType);
     }
     public enum DecompressionMethods {
         Deflate = 2,
         GZip = 1,
         None = 0,
     }
     public enum HttpStatusCode {
         Accepted = 202,
         Ambiguous = 300,
         BadGateway = 502,
         BadRequest = 400,
         Conflict = 409,
         Continue = 100,
         Created = 201,
         ExpectationFailed = 417,
         Forbidden = 403,
         Found = 302,
         GatewayTimeout = 504,
         Gone = 410,
         HttpVersionNotSupported = 505,
         InternalServerError = 500,
         LengthRequired = 411,
         MethodNotAllowed = 405,
         Moved = 301,
         MovedPermanently = 301,
         MultipleChoices = 300,
         NoContent = 204,
         NonAuthoritativeInformation = 203,
         NotAcceptable = 406,
         NotFound = 404,
         NotImplemented = 501,
         NotModified = 304,
         OK = 200,
         PartialContent = 206,
         PaymentRequired = 402,
         PreconditionFailed = 412,
         ProxyAuthenticationRequired = 407,
         Redirect = 302,
         RedirectKeepVerb = 307,
         RedirectMethod = 303,
         RequestedRangeNotSatisfiable = 416,
         RequestEntityTooLarge = 413,
         RequestTimeout = 408,
         RequestUriTooLong = 414,
         ResetContent = 205,
         SeeOther = 303,
         ServiceUnavailable = 503,
         SwitchingProtocols = 101,
         TemporaryRedirect = 307,
         Unauthorized = 401,
         UnsupportedMediaType = 415,
         Unused = 306,
         UpgradeRequired = 426,
         UseProxy = 305,
     }
     public interface ICredentials {
         NetworkCredential GetCredential(Uri uri, string authType);
     }
     public interface ICredentialsByHost {
         NetworkCredential GetCredential(string host, int port, string authenticationType);
     }
     public interface IWebProxy {
         ICredentials Credentials { get; set; }
         Uri GetProxy(Uri destination);
         bool IsBypassed(Uri host);
     }
     public class NetworkCredential : ICredentials, ICredentialsByHost {
         public NetworkCredential();
         public NetworkCredential(string userName, string password);
         public NetworkCredential(string userName, string password, string domain);
         public string Domain { get; set; }
         public string Password { get; set; }
         public string UserName { get; set; }
         public NetworkCredential GetCredential(string host, int port, string authenticationType);
         public NetworkCredential GetCredential(Uri uri, string authType);
     }
     public abstract class TransportContext {
     }
     public static class WebUtility {
         public static string HtmlDecode(string value);
         public static string HtmlEncode(string value);
         public static string UrlDecode(string encodedValue);
         public static byte[] UrlDecodeToBytes(byte[] encodedValue, int offset, int count);
         public static string UrlEncode(string value);
         public static byte[] UrlEncodeToBytes(byte[] value, int offset, int count);
     }
 }
 namespace System.Net.Http {
     public class ByteArrayContent : HttpContent {
         public ByteArrayContent(byte[] content);
         public ByteArrayContent(byte[] content, int offset, int count);
         protected override Task<Stream> CreateContentReadStreamAsync();
         protected override Task SerializeToStreamAsync(Stream stream, TransportContext context);
         protected internal override bool TryComputeLength(out long length);
     }
     public enum ClientCertificateOption {
         Automatic = 1,
         Manual = 0,
     }
     public abstract class DelegatingHandler : HttpMessageHandler {
         protected DelegatingHandler();
         protected DelegatingHandler(HttpMessageHandler innerHandler);
         public HttpMessageHandler InnerHandler { get; set; }
         protected override void Dispose(bool disposing);
         protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
     }
     public class FormUrlEncodedContent : ByteArrayContent {
         public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection);
     }
     public class HttpClient : HttpMessageInvoker {
         public HttpClient();
         public HttpClient(HttpMessageHandler handler);
         public HttpClient(HttpMessageHandler handler, bool disposeHandler);
         public Uri BaseAddress { get; set; }
         public HttpRequestHeaders DefaultRequestHeaders { get; }
         public long MaxResponseContentBufferSize { get; set; }
         public TimeSpan Timeout { get; set; }
         public void CancelPendingRequests();
         public Task<HttpResponseMessage> DeleteAsync(string requestUri);
         public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> DeleteAsync(Uri requestUri);
         public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken);
         protected override void Dispose(bool disposing);
         public Task<HttpResponseMessage> GetAsync(string requestUri);
         public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption);
         public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> GetAsync(Uri requestUri);
         public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption);
         public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
         public Task<byte[]> GetByteArrayAsync(string requestUri);
         public Task<byte[]> GetByteArrayAsync(Uri requestUri);
         public Task<Stream> GetStreamAsync(string requestUri);
         public Task<Stream> GetStreamAsync(Uri requestUri);
         public Task<string> GetStringAsync(string requestUri);
         public Task<string> GetStringAsync(Uri requestUri);
         public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
         public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
         public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
         public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
         public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
         public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
         public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption);
         public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken);
     }
     public class HttpClientHandler : HttpMessageHandler {
         public HttpClientHandler();
         public bool AllowAutoRedirect { get; set; }
         public DecompressionMethods AutomaticDecompression { get; set; }
         public ClientCertificateOption ClientCertificateOptions { get; set; }
         public CookieContainer CookieContainer { get; set; }
         public ICredentials Credentials { get; set; }
         public int MaxAutomaticRedirections { get; set; }
         public long MaxRequestContentBufferSize { get; set; }
         public bool PreAuthenticate { get; set; }
         public IWebProxy Proxy { get; set; }
         public virtual bool SupportsAutomaticDecompression { get; }
         public virtual bool SupportsProxy { get; }
         public virtual bool SupportsRedirectConfiguration { get; }
         public bool UseCookies { get; set; }
         public bool UseDefaultCredentials { get; set; }
         public bool UseProxy { get; set; }
         protected override void Dispose(bool disposing);
         protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
     }
     public enum HttpCompletionOption {
         ResponseContentRead = 0,
         ResponseHeadersRead = 1,
     }
     public abstract class HttpContent : IDisposable {
         protected HttpContent();
         public HttpContentHeaders Headers { get; }
         public Task CopyToAsync(Stream stream);
         public Task CopyToAsync(Stream stream, TransportContext context);
         protected virtual Task<Stream> CreateContentReadStreamAsync();
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public Task LoadIntoBufferAsync();
         public Task LoadIntoBufferAsync(long maxBufferSize);
         public Task<byte[]> ReadAsByteArrayAsync();
         public Task<Stream> ReadAsStreamAsync();
         public Task<string> ReadAsStringAsync();
         protected abstract Task SerializeToStreamAsync(Stream stream, TransportContext context);
         protected internal abstract bool TryComputeLength(out long length);
     }
     public abstract class HttpMessageHandler : IDisposable {
         protected HttpMessageHandler();
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
     }
     public class HttpMessageInvoker : IDisposable {
         public HttpMessageInvoker(HttpMessageHandler handler);
         public HttpMessageInvoker(HttpMessageHandler handler, bool disposeHandler);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
     }
     public class HttpMethod : IEquatable<HttpMethod> {
         public HttpMethod(string method);
         public static HttpMethod Delete { get; }
         public static HttpMethod Get { get; }
         public static HttpMethod Head { get; }
         public string Method { get; }
         public static HttpMethod Options { get; }
         public static HttpMethod Post { get; }
         public static HttpMethod Put { get; }
         public static HttpMethod Trace { get; }
         public bool Equals(HttpMethod other);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static bool operator ==(HttpMethod left, HttpMethod right);
         public static bool operator !=(HttpMethod left, HttpMethod right);
         public override string ToString();
     }
     public class HttpRequestException : Exception {
         public HttpRequestException();
         public HttpRequestException(string message);
         public HttpRequestException(string message, Exception inner);
     }
     public class HttpRequestMessage : IDisposable {
         public HttpRequestMessage();
         public HttpRequestMessage(HttpMethod method, string requestUri);
         public HttpRequestMessage(HttpMethod method, Uri requestUri);
         public HttpContent Content { get; set; }
         public HttpRequestHeaders Headers { get; }
         public HttpMethod Method { get; set; }
         public IDictionary<string, object> Properties { get; }
         public Uri RequestUri { get; set; }
         public Version Version { get; set; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public override string ToString();
     }
     public class HttpResponseMessage : IDisposable {
         public HttpResponseMessage();
         public HttpResponseMessage(HttpStatusCode statusCode);
         public HttpContent Content { get; set; }
         public HttpResponseHeaders Headers { get; }
         public bool IsSuccessStatusCode { get; }
         public string ReasonPhrase { get; set; }
         public HttpRequestMessage RequestMessage { get; set; }
         public HttpStatusCode StatusCode { get; set; }
         public Version Version { get; set; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public HttpResponseMessage EnsureSuccessStatusCode();
         public override string ToString();
     }
     public abstract class MessageProcessingHandler : DelegatingHandler {
         protected MessageProcessingHandler();
         protected MessageProcessingHandler(HttpMessageHandler innerHandler);
         protected abstract HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken);
         protected abstract HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken);
         protected internal sealed override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
     }
     public class MultipartContent : HttpContent, IEnumerable, IEnumerable<HttpContent> {
         public MultipartContent();
         public MultipartContent(string subtype);
         public MultipartContent(string subtype, string boundary);
         public virtual void Add(HttpContent content);
         protected override void Dispose(bool disposing);
         public IEnumerator<HttpContent> GetEnumerator();
         protected override Task SerializeToStreamAsync(Stream stream, TransportContext context);
         protected internal override bool TryComputeLength(out long length);
     }
     public class MultipartFormDataContent : MultipartContent {
         public MultipartFormDataContent();
         public MultipartFormDataContent(string boundary);
         public override void Add(HttpContent content);
         public void Add(HttpContent content, string name);
         public void Add(HttpContent content, string name, string fileName);
     }
     public class StreamContent : HttpContent {
         public StreamContent(Stream content);
         public StreamContent(Stream content, int bufferSize);
         protected override Task<Stream> CreateContentReadStreamAsync();
         protected override void Dispose(bool disposing);
         protected override Task SerializeToStreamAsync(Stream stream, TransportContext context);
         protected internal override bool TryComputeLength(out long length);
     }
     public class StringContent : ByteArrayContent {
         public StringContent(string content);
         public StringContent(string content, Encoding encoding);
         public StringContent(string content, Encoding encoding, string mediaType);
     }
 }
 namespace System.Net.Http.Headers {
     public class AuthenticationHeaderValue {
         public AuthenticationHeaderValue(string scheme);
         public AuthenticationHeaderValue(string scheme, string parameter);
         public string Parameter { get; }
         public string Scheme { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static AuthenticationHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out AuthenticationHeaderValue parsedValue);
     }
     public class CacheControlHeaderValue {
         public CacheControlHeaderValue();
         public ICollection<NameValueHeaderValue> Extensions { get; }
         public Nullable<TimeSpan> MaxAge { get; set; }
         public bool MaxStale { get; set; }
         public Nullable<TimeSpan> MaxStaleLimit { get; set; }
         public Nullable<TimeSpan> MinFresh { get; set; }
         public bool MustRevalidate { get; set; }
         public bool NoCache { get; set; }
         public ICollection<string> NoCacheHeaders { get; }
         public bool NoStore { get; set; }
         public bool NoTransform { get; set; }
         public bool OnlyIfCached { get; set; }
         public bool Private { get; set; }
         public ICollection<string> PrivateHeaders { get; }
         public bool ProxyRevalidate { get; set; }
         public bool Public { get; set; }
         public Nullable<TimeSpan> SharedMaxAge { get; set; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static CacheControlHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out CacheControlHeaderValue parsedValue);
     }
     public class ContentDispositionHeaderValue {
         protected ContentDispositionHeaderValue(ContentDispositionHeaderValue source);
         public ContentDispositionHeaderValue(string dispositionType);
         public Nullable<DateTimeOffset> CreationDate { get; set; }
         public string DispositionType { get; set; }
         public string FileName { get; set; }
         public string FileNameStar { get; set; }
         public Nullable<DateTimeOffset> ModificationDate { get; set; }
         public string Name { get; set; }
         public ICollection<NameValueHeaderValue> Parameters { get; }
         public Nullable<DateTimeOffset> ReadDate { get; set; }
         public Nullable<long> Size { get; set; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static ContentDispositionHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out ContentDispositionHeaderValue parsedValue);
     }
     public class ContentRangeHeaderValue {
         public ContentRangeHeaderValue(long length);
         public ContentRangeHeaderValue(long from, long to);
         public ContentRangeHeaderValue(long from, long to, long length);
         public Nullable<long> From { get; }
         public bool HasLength { get; }
         public bool HasRange { get; }
         public Nullable<long> Length { get; }
         public Nullable<long> To { get; }
         public string Unit { get; set; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static ContentRangeHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out ContentRangeHeaderValue parsedValue);
     }
     public class EntityTagHeaderValue {
         public EntityTagHeaderValue(string tag);
         public EntityTagHeaderValue(string tag, bool isWeak);
         public static EntityTagHeaderValue Any { get; }
         public bool IsWeak { get; }
         public string Tag { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static EntityTagHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out EntityTagHeaderValue parsedValue);
     }
     public sealed class HttpContentHeaders : HttpHeaders {
         public ICollection<string> Allow { get; }
         public ContentDispositionHeaderValue ContentDisposition { get; set; }
         public ICollection<string> ContentEncoding { get; }
         public ICollection<string> ContentLanguage { get; }
         public Nullable<long> ContentLength { get; set; }
         public Uri ContentLocation { get; set; }
         public byte[] ContentMD5 { get; set; }
         public ContentRangeHeaderValue ContentRange { get; set; }
         public MediaTypeHeaderValue ContentType { get; set; }
         public Nullable<DateTimeOffset> Expires { get; set; }
         public Nullable<DateTimeOffset> LastModified { get; set; }
     }
     public abstract class HttpHeaders : IEnumerable, IEnumerable<KeyValuePair<string, IEnumerable<string>>> {
         protected HttpHeaders();
         public void Add(string name, IEnumerable<string> values);
         public void Add(string name, string value);
         public void Clear();
         public bool Contains(string name);
         public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator();
         public IEnumerable<string> GetValues(string name);
         public bool Remove(string name);
         public override string ToString();
         public bool TryAddWithoutValidation(string name, IEnumerable<string> values);
         public bool TryAddWithoutValidation(string name, string value);
         public bool TryGetValues(string name, out IEnumerable<string> values);
     }
     public sealed class HttpHeaderValueCollection<T> : ICollection<T>, IEnumerable, IEnumerable<T> where T : class {
         public int Count { get; }
         public bool IsReadOnly { get; }
         public void Add(T item);
         public void Clear();
         public bool Contains(T item);
         public void CopyTo(T[] array, int arrayIndex);
         public IEnumerator<T> GetEnumerator();
         public void ParseAdd(string input);
         public bool Remove(T item);
         public override string ToString();
         public bool TryParseAdd(string input);
     }
     public sealed class HttpRequestHeaders : HttpHeaders {
         public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept { get; }
         public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset { get; }
         public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding { get; }
         public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage { get; }
         public AuthenticationHeaderValue Authorization { get; set; }
         public CacheControlHeaderValue CacheControl { get; set; }
         public HttpHeaderValueCollection<string> Connection { get; }
         public Nullable<bool> ConnectionClose { get; set; }
         public Nullable<DateTimeOffset> Date { get; set; }
         public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect { get; }
         public Nullable<bool> ExpectContinue { get; set; }
         public string From { get; set; }
         public string Host { get; set; }
         public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch { get; }
         public Nullable<DateTimeOffset> IfModifiedSince { get; set; }
         public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch { get; }
         public RangeConditionHeaderValue IfRange { get; set; }
         public Nullable<DateTimeOffset> IfUnmodifiedSince { get; set; }
         public Nullable<int> MaxForwards { get; set; }
         public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get; }
         public AuthenticationHeaderValue ProxyAuthorization { get; set; }
         public RangeHeaderValue Range { get; set; }
         public Uri Referrer { get; set; }
         public HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE { get; }
         public HttpHeaderValueCollection<string> Trailer { get; }
         public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get; }
         public Nullable<bool> TransferEncodingChunked { get; set; }
         public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get; }
         public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent { get; }
         public HttpHeaderValueCollection<ViaHeaderValue> Via { get; }
         public HttpHeaderValueCollection<WarningHeaderValue> Warning { get; }
     }
     public sealed class HttpResponseHeaders : HttpHeaders {
         public HttpHeaderValueCollection<string> AcceptRanges { get; }
         public Nullable<TimeSpan> Age { get; set; }
         public CacheControlHeaderValue CacheControl { get; set; }
         public HttpHeaderValueCollection<string> Connection { get; }
         public Nullable<bool> ConnectionClose { get; set; }
         public Nullable<DateTimeOffset> Date { get; set; }
         public EntityTagHeaderValue ETag { get; set; }
         public Uri Location { get; set; }
         public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get; }
         public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate { get; }
         public RetryConditionHeaderValue RetryAfter { get; set; }
         public HttpHeaderValueCollection<ProductInfoHeaderValue> Server { get; }
         public HttpHeaderValueCollection<string> Trailer { get; }
         public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get; }
         public Nullable<bool> TransferEncodingChunked { get; set; }
         public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get; }
         public HttpHeaderValueCollection<string> Vary { get; }
         public HttpHeaderValueCollection<ViaHeaderValue> Via { get; }
         public HttpHeaderValueCollection<WarningHeaderValue> Warning { get; }
         public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate { get; }
     }
     public class MediaTypeHeaderValue {
         protected MediaTypeHeaderValue(MediaTypeHeaderValue source);
         public MediaTypeHeaderValue(string mediaType);
         public string CharSet { get; set; }
         public string MediaType { get; set; }
         public ICollection<NameValueHeaderValue> Parameters { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static MediaTypeHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out MediaTypeHeaderValue parsedValue);
     }
     public sealed class MediaTypeWithQualityHeaderValue : MediaTypeHeaderValue {
         public MediaTypeWithQualityHeaderValue(string mediaType);
         public MediaTypeWithQualityHeaderValue(string mediaType, double quality);
         public Nullable<double> Quality { get; set; }
         public static new MediaTypeWithQualityHeaderValue Parse(string input);
         public static bool TryParse(string input, out MediaTypeWithQualityHeaderValue parsedValue);
     }
     public class NameValueHeaderValue {
         protected NameValueHeaderValue(NameValueHeaderValue source);
         public NameValueHeaderValue(string name);
         public NameValueHeaderValue(string name, string value);
         public string Name { get; }
         public string Value { get; set; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static NameValueHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out NameValueHeaderValue parsedValue);
     }
     public class NameValueWithParametersHeaderValue : NameValueHeaderValue {
         protected NameValueWithParametersHeaderValue(NameValueWithParametersHeaderValue source);
         public NameValueWithParametersHeaderValue(string name);
         public NameValueWithParametersHeaderValue(string name, string value);
         public ICollection<NameValueHeaderValue> Parameters { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static new NameValueWithParametersHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out NameValueWithParametersHeaderValue parsedValue);
     }
     public class ProductHeaderValue {
         public ProductHeaderValue(string name);
         public ProductHeaderValue(string name, string version);
         public string Name { get; }
         public string Version { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static ProductHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out ProductHeaderValue parsedValue);
     }
     public class ProductInfoHeaderValue {
         public ProductInfoHeaderValue(ProductHeaderValue product);
         public ProductInfoHeaderValue(string comment);
         public ProductInfoHeaderValue(string productName, string productVersion);
         public string Comment { get; }
         public ProductHeaderValue Product { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static ProductInfoHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out ProductInfoHeaderValue parsedValue);
     }
     public class RangeConditionHeaderValue {
         public RangeConditionHeaderValue(DateTimeOffset date);
         public RangeConditionHeaderValue(EntityTagHeaderValue entityTag);
         public RangeConditionHeaderValue(string entityTag);
         public Nullable<DateTimeOffset> Date { get; }
         public EntityTagHeaderValue EntityTag { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static RangeConditionHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out RangeConditionHeaderValue parsedValue);
     }
     public class RangeHeaderValue {
         public RangeHeaderValue();
         public RangeHeaderValue(Nullable<long> from, Nullable<long> to);
         public ICollection<RangeItemHeaderValue> Ranges { get; }
         public string Unit { get; set; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static RangeHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out RangeHeaderValue parsedValue);
     }
     public class RangeItemHeaderValue {
         public RangeItemHeaderValue(Nullable<long> from, Nullable<long> to);
         public Nullable<long> From { get; }
         public Nullable<long> To { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public override string ToString();
     }
     public class RetryConditionHeaderValue {
         public RetryConditionHeaderValue(DateTimeOffset date);
         public RetryConditionHeaderValue(TimeSpan delta);
         public Nullable<DateTimeOffset> Date { get; }
         public Nullable<TimeSpan> Delta { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static RetryConditionHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out RetryConditionHeaderValue parsedValue);
     }
     public class StringWithQualityHeaderValue {
         public StringWithQualityHeaderValue(string value);
         public StringWithQualityHeaderValue(string value, double quality);
         public Nullable<double> Quality { get; }
         public string Value { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static StringWithQualityHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out StringWithQualityHeaderValue parsedValue);
     }
     public class TransferCodingHeaderValue {
         public TransferCodingHeaderValue(string value);
         protected TransferCodingHeaderValue(TransferCodingHeaderValue source);
         public ICollection<NameValueHeaderValue> Parameters { get; }
         public string Value { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static TransferCodingHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out TransferCodingHeaderValue parsedValue);
     }
     public sealed class TransferCodingWithQualityHeaderValue : TransferCodingHeaderValue {
         public TransferCodingWithQualityHeaderValue(string value);
         public TransferCodingWithQualityHeaderValue(string value, double quality);
         public Nullable<double> Quality { get; set; }
         public static new TransferCodingWithQualityHeaderValue Parse(string input);
         public static bool TryParse(string input, out TransferCodingWithQualityHeaderValue parsedValue);
     }
     public class ViaHeaderValue {
         public ViaHeaderValue(string protocolVersion, string receivedBy);
         public ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName);
         public ViaHeaderValue(string protocolVersion, string receivedBy, string protocolName, string comment);
         public string Comment { get; }
         public string ProtocolName { get; }
         public string ProtocolVersion { get; }
         public string ReceivedBy { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static ViaHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out ViaHeaderValue parsedValue);
     }
     public class WarningHeaderValue {
         public WarningHeaderValue(int code, string agent, string text);
         public WarningHeaderValue(int code, string agent, string text, DateTimeOffset date);
         public string Agent { get; }
         public int Code { get; }
         public Nullable<DateTimeOffset> Date { get; }
         public string Text { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static WarningHeaderValue Parse(string input);
         public override string ToString();
         public static bool TryParse(string input, out WarningHeaderValue parsedValue);
     }
 }
 namespace System.Numerics {
     public struct BigInteger : IComparable, IComparable<BigInteger>, IEquatable<BigInteger>, IFormattable {
         public BigInteger(byte[] value);
         public BigInteger(decimal value);
         public BigInteger(double value);
         public BigInteger(int value);
         public BigInteger(long value);
         public BigInteger(float value);
         public BigInteger(uint value);
         public BigInteger(ulong value);
         public bool IsEven { get; }
         public bool IsOne { get; }
         public bool IsPowerOfTwo { get; }
         public bool IsZero { get; }
         public static BigInteger MinusOne { get; }
         public static BigInteger One { get; }
         public int Sign { get; }
         public static BigInteger Zero { get; }
         public static BigInteger Abs(BigInteger value);
         public static BigInteger Add(BigInteger left, BigInteger right);
         public static int Compare(BigInteger left, BigInteger right);
         public int CompareTo(BigInteger other);
         public int CompareTo(long other);
         public int CompareTo(ulong other);
         public static BigInteger Divide(BigInteger dividend, BigInteger divisor);
         public static BigInteger DivRem(BigInteger dividend, BigInteger divisor, out BigInteger remainder);
         public bool Equals(BigInteger other);
         public bool Equals(long other);
         public override bool Equals(object obj);
         public bool Equals(ulong other);
         public override int GetHashCode();
         public static BigInteger GreatestCommonDivisor(BigInteger left, BigInteger right);
         public static double Log(BigInteger value);
         public static double Log(BigInteger value, double baseValue);
         public static double Log10(BigInteger value);
         public static BigInteger Max(BigInteger left, BigInteger right);
         public static BigInteger Min(BigInteger left, BigInteger right);
         public static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus);
         public static BigInteger Multiply(BigInteger left, BigInteger right);
         public static BigInteger Negate(BigInteger value);
         public static BigInteger operator +(BigInteger left, BigInteger right);
         public static BigInteger operator &(BigInteger left, BigInteger right);
         public static BigInteger operator |(BigInteger left, BigInteger right);
         public static BigInteger operator --(BigInteger value);
         public static BigInteger operator /(BigInteger dividend, BigInteger divisor);
         public static bool operator ==(BigInteger left, BigInteger right);
         public static bool operator ==(BigInteger left, long right);
         public static bool operator ==(BigInteger left, ulong right);
         public static bool operator ==(long left, BigInteger right);
         public static bool operator ==(ulong left, BigInteger right);
         public static BigInteger operator ^(BigInteger left, BigInteger right);
         public static explicit operator byte (BigInteger value);
         public static explicit operator decimal (BigInteger value);
         public static explicit operator double (BigInteger value);
         public static explicit operator short (BigInteger value);
         public static explicit operator int (BigInteger value);
         public static explicit operator long (BigInteger value);
         public static explicit operator sbyte (BigInteger value);
         public static explicit operator float (BigInteger value);
         public static explicit operator ushort (BigInteger value);
         public static explicit operator uint (BigInteger value);
         public static explicit operator ulong (BigInteger value);
         public static explicit operator BigInteger (decimal value);
         public static explicit operator BigInteger (double value);
         public static explicit operator BigInteger (float value);
         public static bool operator >(BigInteger left, BigInteger right);
         public static bool operator >(BigInteger left, long right);
         public static bool operator >(BigInteger left, ulong right);
         public static bool operator >(long left, BigInteger right);
         public static bool operator >(ulong left, BigInteger right);
         public static bool operator >=(BigInteger left, BigInteger right);
         public static bool operator >=(BigInteger left, long right);
         public static bool operator >=(BigInteger left, ulong right);
         public static bool operator >=(long left, BigInteger right);
         public static bool operator >=(ulong left, BigInteger right);
         public static implicit operator BigInteger (byte value);
         public static implicit operator BigInteger (short value);
         public static implicit operator BigInteger (int value);
         public static implicit operator BigInteger (long value);
         public static implicit operator BigInteger (sbyte value);
         public static implicit operator BigInteger (ushort value);
         public static implicit operator BigInteger (uint value);
         public static implicit operator BigInteger (ulong value);
         public static BigInteger operator ++(BigInteger value);
         public static bool operator !=(BigInteger left, BigInteger right);
         public static bool operator !=(BigInteger left, long right);
         public static bool operator !=(BigInteger left, ulong right);
         public static bool operator !=(long left, BigInteger right);
         public static bool operator !=(ulong left, BigInteger right);
         public static BigInteger operator <<(BigInteger value, int shift);
         public static bool operator <(BigInteger left, BigInteger right);
         public static bool operator <(BigInteger left, long right);
         public static bool operator <(BigInteger left, ulong right);
         public static bool operator <(long left, BigInteger right);
         public static bool operator <(ulong left, BigInteger right);
         public static bool operator <=(BigInteger left, BigInteger right);
         public static bool operator <=(BigInteger left, long right);
         public static bool operator <=(BigInteger left, ulong right);
         public static bool operator <=(long left, BigInteger right);
         public static bool operator <=(ulong left, BigInteger right);
         public static BigInteger operator %(BigInteger dividend, BigInteger divisor);
         public static BigInteger operator *(BigInteger left, BigInteger right);
         public static BigInteger operator ~(BigInteger value);
         public static BigInteger operator >>(BigInteger value, int shift);
         public static BigInteger operator -(BigInteger left, BigInteger right);
         public static BigInteger operator -(BigInteger value);
         public static BigInteger operator +(BigInteger value);
         public static BigInteger Parse(string value);
         public static BigInteger Parse(string value, IFormatProvider provider);
         public static BigInteger Parse(string value, NumberStyles style);
         public static BigInteger Parse(string value, NumberStyles style, IFormatProvider provider);
         public static BigInteger Pow(BigInteger value, int exponent);
         public static BigInteger Remainder(BigInteger dividend, BigInteger divisor);
         public static BigInteger Subtract(BigInteger left, BigInteger right);
         public byte[] ToByteArray();
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
         public static bool TryParse(string value, out BigInteger result);
         public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out BigInteger result);
     }
     public struct Complex : IEquatable<Complex>, IFormattable {
         public static readonly Complex ImaginaryOne;
         public static readonly Complex One;
         public static readonly Complex Zero;
         public Complex(double real, double imaginary);
         public double Imaginary { get; }
         public double Magnitude { get; }
         public double Phase { get; }
         public double Real { get; }
         public static double Abs(Complex value);
         public static Complex Acos(Complex value);
         public static Complex Add(Complex left, Complex right);
         public static Complex Asin(Complex value);
         public static Complex Atan(Complex value);
         public static Complex Conjugate(Complex value);
         public static Complex Cos(Complex value);
         public static Complex Cosh(Complex value);
         public static Complex Divide(Complex dividend, Complex divisor);
         public bool Equals(Complex value);
         public override bool Equals(object obj);
         public static Complex Exp(Complex value);
         public static Complex FromPolarCoordinates(double magnitude, double phase);
         public override int GetHashCode();
         public static Complex Log(Complex value);
         public static Complex Log(Complex value, double baseValue);
         public static Complex Log10(Complex value);
         public static Complex Multiply(Complex left, Complex right);
         public static Complex Negate(Complex value);
         public static Complex operator +(Complex left, Complex right);
         public static Complex operator /(Complex left, Complex right);
         public static bool operator ==(Complex left, Complex right);
         public static explicit operator Complex (BigInteger value);
         public static explicit operator Complex (decimal value);
         public static implicit operator Complex (byte value);
         public static implicit operator Complex (double value);
         public static implicit operator Complex (short value);
         public static implicit operator Complex (int value);
         public static implicit operator Complex (long value);
         public static implicit operator Complex (sbyte value);
         public static implicit operator Complex (float value);
         public static implicit operator Complex (ushort value);
         public static implicit operator Complex (uint value);
         public static implicit operator Complex (ulong value);
         public static bool operator !=(Complex left, Complex right);
         public static Complex operator *(Complex left, Complex right);
         public static Complex operator -(Complex left, Complex right);
         public static Complex operator -(Complex value);
         public static Complex Pow(Complex value, Complex power);
         public static Complex Pow(Complex value, double power);
         public static Complex Reciprocal(Complex value);
         public static Complex Sin(Complex value);
         public static Complex Sinh(Complex value);
         public static Complex Sqrt(Complex value);
         public static Complex Subtract(Complex left, Complex right);
         public static Complex Tan(Complex value);
         public static Complex Tanh(Complex value);
         public override string ToString();
         public string ToString(IFormatProvider provider);
         public string ToString(string format);
         public string ToString(string format, IFormatProvider provider);
     }
 }
 namespace System.Reflection {
     public sealed class AmbiguousMatchException : Exception {
         public AmbiguousMatchException();
         public AmbiguousMatchException(string message);
         public AmbiguousMatchException(string message, Exception inner);
     }
     public abstract class Assembly {
         public virtual IEnumerable<CustomAttributeData> CustomAttributes { get; }
         public abstract IEnumerable<TypeInfo> DefinedTypes { get; }
         public virtual IEnumerable<Type> ExportedTypes { get; }
         public virtual string FullName { get; }
         public virtual bool IsDynamic { get; }
         public virtual Module ManifestModule { get; }
         public abstract IEnumerable<Module> Modules { get; }
         public override bool Equals(object o);
         public override int GetHashCode();
         public virtual ManifestResourceInfo GetManifestResourceInfo(string resourceName);
         public virtual string[] GetManifestResourceNames();
         public virtual Stream GetManifestResourceStream(string name);
         public virtual AssemblyName GetName();
         public virtual Type GetType(string name);
         public static Assembly Load(AssemblyName assemblyRef);
         public override string ToString();
     }
     public sealed class AssemblyCompanyAttribute : Attribute {
         public AssemblyCompanyAttribute(string company);
         public string Company { get; }
     }
     public sealed class AssemblyConfigurationAttribute : Attribute {
         public AssemblyConfigurationAttribute(string configuration);
         public string Configuration { get; }
     }
     public enum AssemblyContentType {
         Default = 0,
         WindowsRuntime = 1,
     }
     public sealed class AssemblyCopyrightAttribute : Attribute {
         public AssemblyCopyrightAttribute(string copyright);
         public string Copyright { get; }
     }
     public sealed class AssemblyCultureAttribute : Attribute {
         public AssemblyCultureAttribute(string culture);
         public string Culture { get; }
     }
     public sealed class AssemblyDefaultAliasAttribute : Attribute {
         public AssemblyDefaultAliasAttribute(string defaultAlias);
         public string DefaultAlias { get; }
     }
     public sealed class AssemblyDelaySignAttribute : Attribute {
         public AssemblyDelaySignAttribute(bool delaySign);
         public bool DelaySign { get; }
     }
     public sealed class AssemblyDescriptionAttribute : Attribute {
         public AssemblyDescriptionAttribute(string description);
         public string Description { get; }
     }
     public sealed class AssemblyFileVersionAttribute : Attribute {
         public AssemblyFileVersionAttribute(string version);
         public string Version { get; }
     }
     public sealed class AssemblyFlagsAttribute : Attribute {
         public AssemblyFlagsAttribute(AssemblyNameFlags assemblyFlags);
         public int AssemblyFlags { get; }
     }
     public sealed class AssemblyInformationalVersionAttribute : Attribute {
         public AssemblyInformationalVersionAttribute(string informationalVersion);
         public string InformationalVersion { get; }
     }
     public sealed class AssemblyKeyFileAttribute : Attribute {
         public AssemblyKeyFileAttribute(string keyFile);
         public string KeyFile { get; }
     }
     public sealed class AssemblyKeyNameAttribute : Attribute {
         public AssemblyKeyNameAttribute(string keyName);
         public string KeyName { get; }
     }
     public sealed class AssemblyMetadataAttribute : Attribute {
         public AssemblyMetadataAttribute(string key, string value);
         public string Key { get; }
         public string Value { get; }
     }
     public sealed class AssemblyName {
         public AssemblyName();
         public AssemblyName(string assemblyName);
         public AssemblyContentType ContentType { get; set; }
         public string CultureName { get; }
         public AssemblyNameFlags Flags { get; set; }
         public string FullName { get; }
         public string Name { get; set; }
         public Version Version { get; set; }
         public byte[] GetPublicKey();
         public byte[] GetPublicKeyToken();
         public void SetPublicKey(byte[] publicKey);
         public void SetPublicKeyToken(byte[] publicKeyToken);
         public override string ToString();
     }
     public enum AssemblyNameFlags {
         None = 0,
         PublicKey = 1,
         Retargetable = 256,
     }
     public sealed class AssemblyProductAttribute : Attribute {
         public AssemblyProductAttribute(string product);
         public string Product { get; }
     }
     public sealed class AssemblySignatureKeyAttribute : Attribute {
         public AssemblySignatureKeyAttribute(string publicKey, string countersignature);
         public string Countersignature { get; }
         public string PublicKey { get; }
     }
     public sealed class AssemblyTitleAttribute : Attribute {
         public AssemblyTitleAttribute(string title);
         public string Title { get; }
     }
     public sealed class AssemblyTrademarkAttribute : Attribute {
         public AssemblyTrademarkAttribute(string trademark);
         public string Trademark { get; }
     }
     public sealed class AssemblyVersionAttribute : Attribute {
         public AssemblyVersionAttribute(string version);
         public string Version { get; }
     }
     public enum CallingConventions {
         Any = 3,
         ExplicitThis = 64,
         HasThis = 32,
         Standard = 1,
         VarArgs = 2,
     }
     public abstract class ConstructorInfo : MethodBase {
         public static readonly string ConstructorName;
         public static readonly string TypeConstructorName;
         public override bool Equals(object obj);
         public override int GetHashCode();
         public object Invoke(object[] parameters);
     }
     public class CustomAttributeData {
         public Type AttributeType { get; }
         public virtual IList<CustomAttributeTypedArgument> ConstructorArguments { get; }
         public virtual IList<CustomAttributeNamedArgument> NamedArguments { get; }
     }
     public static class CustomAttributeExtensions {
         public static T GetCustomAttribute<T>(this Module element) where T : Attribute;
         public static T GetCustomAttribute<T>(this Assembly element) where T : Attribute;
         public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute;
         public static T GetCustomAttribute<T>(this ParameterInfo element) where T : Attribute;
         public static T GetCustomAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute;
         public static T GetCustomAttribute<T>(this ParameterInfo element, bool inherit) where T : Attribute;
         public static Attribute GetCustomAttribute(this Assembly element, Type attributeType);
         public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType);
         public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, bool inherit);
         public static Attribute GetCustomAttribute(this Module element, Type attributeType);
         public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType);
         public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType, bool inherit);
         public static IEnumerable<T> GetCustomAttributes<T>(this Module element) where T : Attribute;
         public static IEnumerable<T> GetCustomAttributes<T>(this Assembly element) where T : Attribute;
         public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element) where T : Attribute;
         public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element) where T : Attribute;
         public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element, bool inherit) where T : Attribute;
         public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element, bool inherit) where T : Attribute;
         public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element);
         public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element, Type attributeType);
         public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element);
         public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, bool inherit);
         public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType);
         public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType, bool inherit);
         public static IEnumerable<Attribute> GetCustomAttributes(this Module element);
         public static IEnumerable<Attribute> GetCustomAttributes(this Module element, Type attributeType);
         public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element);
         public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, bool inherit);
         public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType);
         public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType, bool inherit);
         public static bool IsDefined(this Assembly element, Type attributeType);
         public static bool IsDefined(this MemberInfo element, Type attributeType);
         public static bool IsDefined(this MemberInfo element, Type attributeType, bool inherit);
         public static bool IsDefined(this Module element, Type attributeType);
         public static bool IsDefined(this ParameterInfo element, Type attributeType);
         public static bool IsDefined(this ParameterInfo element, Type attributeType, bool inherit);
     }
     public struct CustomAttributeNamedArgument {
         public bool IsField { get; }
         public string MemberName { get; }
         public CustomAttributeTypedArgument TypedValue { get; }
     }
     public struct CustomAttributeTypedArgument {
         public Type ArgumentType { get; }
         public object Value { get; }
     }
     public sealed class DefaultMemberAttribute : Attribute {
         public DefaultMemberAttribute(string memberName);
         public string MemberName { get; }
     }
     public enum EventAttributes {
         None = 0,
         RTSpecialName = 1024,
         SpecialName = 512,
     }
     public abstract class EventInfo : MemberInfo {
         public virtual MethodInfo AddMethod { get; }
         public abstract EventAttributes Attributes { get; }
         public virtual Type EventHandlerType { get; }
         public bool IsSpecialName { get; }
         public virtual MethodInfo RaiseMethod { get; }
         public virtual MethodInfo RemoveMethod { get; }
         public virtual void AddEventHandler(object target, Delegate handler);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public virtual void RemoveEventHandler(object target, Delegate handler);
     }
     public enum FieldAttributes {
         Assembly = 3,
         FamANDAssem = 2,
         Family = 4,
         FamORAssem = 5,
         FieldAccessMask = 7,
         HasDefault = 32768,
         HasFieldMarshal = 4096,
         HasFieldRVA = 256,
         InitOnly = 32,
         Literal = 64,
         NotSerialized = 128,
         PinvokeImpl = 8192,
         Private = 1,
         PrivateScope = 0,
         Public = 6,
         RTSpecialName = 1024,
         SpecialName = 512,
         Static = 16,
     }
     public abstract class FieldInfo : MemberInfo {
         public abstract FieldAttributes Attributes { get; }
         public abstract Type FieldType { get; }
         public bool IsAssembly { get; }
         public bool IsFamily { get; }
         public bool IsFamilyAndAssembly { get; }
         public bool IsFamilyOrAssembly { get; }
         public bool IsInitOnly { get; }
         public bool IsLiteral { get; }
         public bool IsPrivate { get; }
         public bool IsPublic { get; }
         public bool IsSpecialName { get; }
         public bool IsStatic { get; }
         public override bool Equals(object obj);
         public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle);
         public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle, RuntimeTypeHandle declaringType);
         public override int GetHashCode();
         public abstract object GetValue(object obj);
         public void SetValue(object obj, object value);
     }
     public enum GenericParameterAttributes {
         Contravariant = 2,
         Covariant = 1,
         DefaultConstructorConstraint = 16,
         None = 0,
         NotNullableValueTypeConstraint = 8,
         ReferenceTypeConstraint = 4,
         SpecialConstraintMask = 28,
         VarianceMask = 3,
     }
     public struct InterfaceMapping {
         public MethodInfo[] InterfaceMethods;
         public Type InterfaceType;
         public MethodInfo[] TargetMethods;
         public Type TargetType;
     }
     public static class IntrospectionExtensions {
         public static TypeInfo GetTypeInfo(this Type type);
     }
     public interface IReflectableType {
         TypeInfo GetTypeInfo();
     }
     public class LocalVariableInfo {
         protected LocalVariableInfo();
         public virtual bool IsPinned { get; }
         public virtual int LocalIndex { get; }
         public virtual Type LocalType { get; }
         public override string ToString();
     }
     public class ManifestResourceInfo {
         public ManifestResourceInfo(Assembly containingAssembly, string containingFileName, ResourceLocation resourceLocation);
         public virtual string FileName { get; }
         public virtual Assembly ReferencedAssembly { get; }
         public virtual ResourceLocation ResourceLocation { get; }
     }
     public abstract class MemberInfo {
         public virtual IEnumerable<CustomAttributeData> CustomAttributes { get; }
         public abstract Type DeclaringType { get; }
         public virtual Module Module { get; }
         public abstract string Name { get; }
         public override bool Equals(object obj);
         public override int GetHashCode();
     }
     public enum MethodAttributes {
         Abstract = 1024,
         Assembly = 3,
         CheckAccessOnOverride = 512,
         FamANDAssem = 2,
         Family = 4,
         FamORAssem = 5,
         Final = 32,
         HasSecurity = 16384,
         HideBySig = 128,
         MemberAccessMask = 7,
         NewSlot = 256,
         PinvokeImpl = 8192,
         Private = 1,
         PrivateScope = 0,
         Public = 6,
         RequireSecObject = 32768,
         ReuseSlot = 0,
         RTSpecialName = 4096,
         SpecialName = 2048,
         Static = 16,
         UnmanagedExport = 8,
         Virtual = 64,
         VtableLayoutMask = 256,
     }
     public abstract class MethodBase : MemberInfo {
         public abstract MethodAttributes Attributes { get; }
         public virtual CallingConventions CallingConvention { get; }
         public virtual bool ContainsGenericParameters { get; }
         public bool IsAbstract { get; }
         public bool IsAssembly { get; }
         public bool IsConstructor { get; }
         public bool IsFamily { get; }
         public bool IsFamilyAndAssembly { get; }
         public bool IsFamilyOrAssembly { get; }
         public bool IsFinal { get; }
         public virtual bool IsGenericMethod { get; }
         public virtual bool IsGenericMethodDefinition { get; }
         public bool IsHideBySig { get; }
         public bool IsPrivate { get; }
         public bool IsPublic { get; }
         public bool IsSpecialName { get; }
         public bool IsStatic { get; }
         public bool IsVirtual { get; }
         public abstract MethodImplAttributes MethodImplementationFlags { get; }
         public override bool Equals(object obj);
         public virtual Type[] GetGenericArguments();
         public override int GetHashCode();
         public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle);
         public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle, RuntimeTypeHandle declaringType);
         public abstract ParameterInfo[] GetParameters();
         public object Invoke(object obj, object[] parameters);
     }
     public enum MethodImplAttributes {
         AggressiveInlining = 256,
         CodeTypeMask = 3,
         ForwardRef = 16,
         IL = 0,
         InternalCall = 4096,
         Managed = 0,
         ManagedMask = 4,
         Native = 1,
         NoInlining = 8,
         NoOptimization = 64,
         OPTIL = 2,
         PreserveSig = 128,
         Runtime = 3,
         Synchronized = 32,
         Unmanaged = 4,
     }
     public abstract class MethodInfo : MethodBase {
         public virtual ParameterInfo ReturnParameter { get; }
         public virtual Type ReturnType { get; }
         public virtual Delegate CreateDelegate(Type delegateType);
         public virtual Delegate CreateDelegate(Type delegateType, object target);
         public override bool Equals(object obj);
         public override Type[] GetGenericArguments();
         public virtual MethodInfo GetGenericMethodDefinition();
         public override int GetHashCode();
         public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments);
     }
     public sealed class Missing {
         public static readonly Missing Value;
     }
     public abstract class Module {
         public virtual Assembly Assembly { get; }
         public virtual IEnumerable<CustomAttributeData> CustomAttributes { get; }
         public virtual string FullyQualifiedName { get; }
         public virtual string Name { get; }
         public override bool Equals(object o);
         public override int GetHashCode();
         public override string ToString();
     }
     public enum ParameterAttributes {
         HasDefault = 4096,
         HasFieldMarshal = 8192,
         In = 1,
         Lcid = 4,
         None = 0,
         Optional = 16,
         Out = 2,
         Retval = 8,
     }
     public class ParameterInfo {
         public virtual ParameterAttributes Attributes { get; }
         public virtual IEnumerable<CustomAttributeData> CustomAttributes { get; }
         public virtual object DefaultValue { get; }
         public virtual bool HasDefaultValue { get; }
         public bool IsIn { get; }
         public bool IsOptional { get; }
         public bool IsOut { get; }
         public bool IsRetval { get; }
         public virtual MemberInfo Member { get; }
         public virtual string Name { get; }
         public virtual Type ParameterType { get; }
         public virtual int Position { get; }
     }
     public enum PropertyAttributes {
         HasDefault = 4096,
         None = 0,
         RTSpecialName = 1024,
         SpecialName = 512,
     }
     public abstract class PropertyInfo : MemberInfo {
         public abstract PropertyAttributes Attributes { get; }
         public abstract bool CanRead { get; }
         public abstract bool CanWrite { get; }
         public virtual MethodInfo GetMethod { get; }
         public bool IsSpecialName { get; }
         public abstract Type PropertyType { get; }
         public virtual MethodInfo SetMethod { get; }
         public override bool Equals(object obj);
         public virtual object GetConstantValue();
         public override int GetHashCode();
         public abstract ParameterInfo[] GetIndexParameters();
         public object GetValue(object obj);
         public virtual object GetValue(object obj, object[] index);
         public void SetValue(object obj, object value);
         public virtual void SetValue(object obj, object value, object[] index);
     }
     public abstract class ReflectionContext {
         protected ReflectionContext();
         public virtual TypeInfo GetTypeForObject(object value);
         public abstract Assembly MapAssembly(Assembly assembly);
         public abstract TypeInfo MapType(TypeInfo type);
     }
     public sealed class ReflectionTypeLoadException : Exception {
         public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions);
         public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions, string message);
         public Exception[] LoaderExceptions { get; }
         public Type[] Types { get; }
     }
     public enum ResourceLocation {
         ContainedInAnotherAssembly = 2,
         ContainedInManifestFile = 4,
         Embedded = 1,
     }
     public static class RuntimeReflectionExtensions {
         public static MethodInfo GetMethodInfo(this Delegate del);
         public static MethodInfo GetRuntimeBaseDefinition(this MethodInfo method);
         public static EventInfo GetRuntimeEvent(this Type type, string name);
         public static IEnumerable<EventInfo> GetRuntimeEvents(this Type type);
         public static FieldInfo GetRuntimeField(this Type type, string name);
         public static IEnumerable<FieldInfo> GetRuntimeFields(this Type type);
         public static InterfaceMapping GetRuntimeInterfaceMap(this TypeInfo typeInfo, Type interfaceType);
         public static MethodInfo GetRuntimeMethod(this Type type, string name, Type[] parameters);
         public static IEnumerable<MethodInfo> GetRuntimeMethods(this Type type);
         public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type type);
         public static PropertyInfo GetRuntimeProperty(this Type type, string name);
     }
     public sealed class TargetInvocationException : Exception {
         public TargetInvocationException(Exception inner);
         public TargetInvocationException(string message, Exception inner);
     }
     public sealed class TargetParameterCountException : Exception {
         public TargetParameterCountException();
         public TargetParameterCountException(string message);
         public TargetParameterCountException(string message, Exception inner);
     }
     public enum TypeAttributes {
         Abstract = 128,
         AnsiClass = 0,
         AutoClass = 131072,
         AutoLayout = 0,
         BeforeFieldInit = 1048576,
         Class = 0,
         ClassSemanticsMask = 32,
         CustomFormatClass = 196608,
         CustomFormatMask = 12582912,
         ExplicitLayout = 16,
         HasSecurity = 262144,
         Import = 4096,
         Interface = 32,
         LayoutMask = 24,
         NestedAssembly = 5,
         NestedFamANDAssem = 6,
         NestedFamily = 4,
         NestedFamORAssem = 7,
         NestedPrivate = 3,
         NestedPublic = 2,
         NotPublic = 0,
         Public = 1,
         RTSpecialName = 2048,
         Sealed = 256,
         SequentialLayout = 8,
         Serializable = 8192,
         SpecialName = 1024,
         StringFormatMask = 196608,
         UnicodeClass = 65536,
         VisibilityMask = 7,
         WindowsRuntime = 16384,
     }
     public abstract class TypeInfo : MemberInfo, IReflectableType {
         public abstract Assembly Assembly { get; }
         public abstract string AssemblyQualifiedName { get; }
         public abstract TypeAttributes Attributes { get; }
         public abstract Type BaseType { get; }
         public abstract bool ContainsGenericParameters { get; }
         public virtual IEnumerable<ConstructorInfo> DeclaredConstructors { get; }
         public virtual IEnumerable<EventInfo> DeclaredEvents { get; }
         public virtual IEnumerable<FieldInfo> DeclaredFields { get; }
         public virtual IEnumerable<MemberInfo> DeclaredMembers { get; }
         public virtual IEnumerable<MethodInfo> DeclaredMethods { get; }
         public virtual IEnumerable<TypeInfo> DeclaredNestedTypes { get; }
         public virtual IEnumerable<PropertyInfo> DeclaredProperties { get; }
         public abstract MethodBase DeclaringMethod { get; }
         public abstract string FullName { get; }
         public abstract GenericParameterAttributes GenericParameterAttributes { get; }
         public abstract int GenericParameterPosition { get; }
         public abstract Type[] GenericTypeArguments { get; }
         public virtual Type[] GenericTypeParameters { get; }
         public abstract Guid GUID { get; }
         public bool HasElementType { get; }
         public virtual IEnumerable<Type> ImplementedInterfaces { get; }
         public bool IsAbstract { get; }
         public bool IsAnsiClass { get; }
         public bool IsArray { get; }
         public bool IsAutoClass { get; }
         public bool IsAutoLayout { get; }
         public bool IsByRef { get; }
         public bool IsClass { get; }
         public abstract bool IsEnum { get; }
         public bool IsExplicitLayout { get; }
         public abstract bool IsGenericParameter { get; }
         public abstract bool IsGenericType { get; }
         public abstract bool IsGenericTypeDefinition { get; }
         public bool IsImport { get; }
         public bool IsInterface { get; }
         public bool IsLayoutSequential { get; }
         public bool IsMarshalByRef { get; }
         public bool IsNested { get; }
         public bool IsNestedAssembly { get; }
         public bool IsNestedFamANDAssem { get; }
         public bool IsNestedFamily { get; }
         public bool IsNestedFamORAssem { get; }
         public bool IsNestedPrivate { get; }
         public bool IsNestedPublic { get; }
         public bool IsNotPublic { get; }
         public bool IsPointer { get; }
         public bool IsPrimitive { get; }
         public bool IsPublic { get; }
         public bool IsSealed { get; }
         public abstract bool IsSerializable { get; }
         public bool IsSpecialName { get; }
         public bool IsUnicodeClass { get; }
         public bool IsValueType { get; }
         public bool IsVisible { get; }
         public abstract string Namespace { get; }
         public virtual Type AsType();
         public abstract int GetArrayRank();
         public virtual EventInfo GetDeclaredEvent(string name);
         public virtual FieldInfo GetDeclaredField(string name);
         public virtual MethodInfo GetDeclaredMethod(string name);
         public virtual IEnumerable<MethodInfo> GetDeclaredMethods(string name);
         public virtual TypeInfo GetDeclaredNestedType(string name);
         public virtual PropertyInfo GetDeclaredProperty(string name);
         public abstract Type GetElementType();
         public abstract Type[] GetGenericParameterConstraints();
         public abstract Type GetGenericTypeDefinition();
         public virtual bool IsAssignableFrom(TypeInfo typeInfo);
         public virtual bool IsSubclassOf(Type c);
         public abstract Type MakeArrayType();
         public abstract Type MakeArrayType(int rank);
         public abstract Type MakeByRefType();
         public abstract Type MakeGenericType(params Type[] typeArguments);
         public abstract Type MakePointerType();
     }
 }
 namespace System.Reflection.Emit {
     public enum FlowControl {
         Branch = 0,
         Break = 1,
         Call = 2,
         Cond_Branch = 3,
         Meta = 4,
         Next = 5,
         Return = 7,
         Throw = 8,
     }
     public struct OpCode {
         public FlowControl FlowControl { get; }
         public string Name { get; }
         public OpCodeType OpCodeType { get; }
         public OperandType OperandType { get; }
         public int Size { get; }
         public StackBehaviour StackBehaviourPop { get; }
         public StackBehaviour StackBehaviourPush { get; }
         public short Value { get; }
         public override bool Equals(object obj);
         public bool Equals(OpCode obj);
         public override int GetHashCode();
         public static bool operator ==(OpCode a, OpCode b);
         public static bool operator !=(OpCode a, OpCode b);
         public override string ToString();
     }
     public class OpCodes {
         public static readonly OpCode Add;
         public static readonly OpCode Add_Ovf;
         public static readonly OpCode Add_Ovf_Un;
         public static readonly OpCode And;
         public static readonly OpCode Arglist;
         public static readonly OpCode Beq;
         public static readonly OpCode Beq_S;
         public static readonly OpCode Bge;
         public static readonly OpCode Bge_S;
         public static readonly OpCode Bge_Un;
         public static readonly OpCode Bge_Un_S;
         public static readonly OpCode Bgt;
         public static readonly OpCode Bgt_S;
         public static readonly OpCode Bgt_Un;
         public static readonly OpCode Bgt_Un_S;
         public static readonly OpCode Ble;
         public static readonly OpCode Ble_S;
         public static readonly OpCode Ble_Un;
         public static readonly OpCode Ble_Un_S;
         public static readonly OpCode Blt;
         public static readonly OpCode Blt_S;
         public static readonly OpCode Blt_Un;
         public static readonly OpCode Blt_Un_S;
         public static readonly OpCode Bne_Un;
         public static readonly OpCode Bne_Un_S;
         public static readonly OpCode Box;
         public static readonly OpCode Br;
         public static readonly OpCode Break;
         public static readonly OpCode Brfalse;
         public static readonly OpCode Brfalse_S;
         public static readonly OpCode Brtrue;
         public static readonly OpCode Brtrue_S;
         public static readonly OpCode Br_S;
         public static readonly OpCode Call;
         public static readonly OpCode Calli;
         public static readonly OpCode Callvirt;
         public static readonly OpCode Castclass;
         public static readonly OpCode Ceq;
         public static readonly OpCode Cgt;
         public static readonly OpCode Cgt_Un;
         public static readonly OpCode Ckfinite;
         public static readonly OpCode Clt;
         public static readonly OpCode Clt_Un;
         public static readonly OpCode Constrained;
         public static readonly OpCode Conv_I;
         public static readonly OpCode Conv_I1;
         public static readonly OpCode Conv_I2;
         public static readonly OpCode Conv_I4;
         public static readonly OpCode Conv_I8;
         public static readonly OpCode Conv_Ovf_I;
         public static readonly OpCode Conv_Ovf_I1;
         public static readonly OpCode Conv_Ovf_I1_Un;
         public static readonly OpCode Conv_Ovf_I2;
         public static readonly OpCode Conv_Ovf_I2_Un;
         public static readonly OpCode Conv_Ovf_I4;
         public static readonly OpCode Conv_Ovf_I4_Un;
         public static readonly OpCode Conv_Ovf_I8;
         public static readonly OpCode Conv_Ovf_I8_Un;
         public static readonly OpCode Conv_Ovf_I_Un;
         public static readonly OpCode Conv_Ovf_U;
         public static readonly OpCode Conv_Ovf_U1;
         public static readonly OpCode Conv_Ovf_U1_Un;
         public static readonly OpCode Conv_Ovf_U2;
         public static readonly OpCode Conv_Ovf_U2_Un;
         public static readonly OpCode Conv_Ovf_U4;
         public static readonly OpCode Conv_Ovf_U4_Un;
         public static readonly OpCode Conv_Ovf_U8;
         public static readonly OpCode Conv_Ovf_U8_Un;
         public static readonly OpCode Conv_Ovf_U_Un;
         public static readonly OpCode Conv_R4;
         public static readonly OpCode Conv_R8;
         public static readonly OpCode Conv_R_Un;
         public static readonly OpCode Conv_U;
         public static readonly OpCode Conv_U1;
         public static readonly OpCode Conv_U2;
         public static readonly OpCode Conv_U4;
         public static readonly OpCode Conv_U8;
         public static readonly OpCode Cpblk;
         public static readonly OpCode Cpobj;
         public static readonly OpCode Div;
         public static readonly OpCode Div_Un;
         public static readonly OpCode Dup;
         public static readonly OpCode Endfilter;
         public static readonly OpCode Endfinally;
         public static readonly OpCode Initblk;
         public static readonly OpCode Initobj;
         public static readonly OpCode Isinst;
         public static readonly OpCode Jmp;
         public static readonly OpCode Ldarg;
         public static readonly OpCode Ldarga;
         public static readonly OpCode Ldarga_S;
         public static readonly OpCode Ldarg_0;
         public static readonly OpCode Ldarg_1;
         public static readonly OpCode Ldarg_2;
         public static readonly OpCode Ldarg_3;
         public static readonly OpCode Ldarg_S;
         public static readonly OpCode Ldc_I4;
         public static readonly OpCode Ldc_I4_0;
         public static readonly OpCode Ldc_I4_1;
         public static readonly OpCode Ldc_I4_2;
         public static readonly OpCode Ldc_I4_3;
         public static readonly OpCode Ldc_I4_4;
         public static readonly OpCode Ldc_I4_5;
         public static readonly OpCode Ldc_I4_6;
         public static readonly OpCode Ldc_I4_7;
         public static readonly OpCode Ldc_I4_8;
         public static readonly OpCode Ldc_I4_M1;
         public static readonly OpCode Ldc_I4_S;
         public static readonly OpCode Ldc_I8;
         public static readonly OpCode Ldc_R4;
         public static readonly OpCode Ldc_R8;
         public static readonly OpCode Ldelem;
         public static readonly OpCode Ldelema;
         public static readonly OpCode Ldelem_I;
         public static readonly OpCode Ldelem_I1;
         public static readonly OpCode Ldelem_I2;
         public static readonly OpCode Ldelem_I4;
         public static readonly OpCode Ldelem_I8;
         public static readonly OpCode Ldelem_R4;
         public static readonly OpCode Ldelem_R8;
         public static readonly OpCode Ldelem_Ref;
         public static readonly OpCode Ldelem_U1;
         public static readonly OpCode Ldelem_U2;
         public static readonly OpCode Ldelem_U4;
         public static readonly OpCode Ldfld;
         public static readonly OpCode Ldflda;
         public static readonly OpCode Ldftn;
         public static readonly OpCode Ldind_I;
         public static readonly OpCode Ldind_I1;
         public static readonly OpCode Ldind_I2;
         public static readonly OpCode Ldind_I4;
         public static readonly OpCode Ldind_I8;
         public static readonly OpCode Ldind_R4;
         public static readonly OpCode Ldind_R8;
         public static readonly OpCode Ldind_Ref;
         public static readonly OpCode Ldind_U1;
         public static readonly OpCode Ldind_U2;
         public static readonly OpCode Ldind_U4;
         public static readonly OpCode Ldlen;
         public static readonly OpCode Ldloc;
         public static readonly OpCode Ldloca;
         public static readonly OpCode Ldloca_S;
         public static readonly OpCode Ldloc_0;
         public static readonly OpCode Ldloc_1;
         public static readonly OpCode Ldloc_2;
         public static readonly OpCode Ldloc_3;
         public static readonly OpCode Ldloc_S;
         public static readonly OpCode Ldnull;
         public static readonly OpCode Ldobj;
         public static readonly OpCode Ldsfld;
         public static readonly OpCode Ldsflda;
         public static readonly OpCode Ldstr;
         public static readonly OpCode Ldtoken;
         public static readonly OpCode Ldvirtftn;
         public static readonly OpCode Leave;
         public static readonly OpCode Leave_S;
         public static readonly OpCode Localloc;
         public static readonly OpCode Mkrefany;
         public static readonly OpCode Mul;
         public static readonly OpCode Mul_Ovf;
         public static readonly OpCode Mul_Ovf_Un;
         public static readonly OpCode Neg;
         public static readonly OpCode Newarr;
         public static readonly OpCode Newobj;
         public static readonly OpCode Nop;
         public static readonly OpCode Not;
         public static readonly OpCode Or;
         public static readonly OpCode Pop;
         public static readonly OpCode Prefix1;
         public static readonly OpCode Prefix2;
         public static readonly OpCode Prefix3;
         public static readonly OpCode Prefix4;
         public static readonly OpCode Prefix5;
         public static readonly OpCode Prefix6;
         public static readonly OpCode Prefix7;
         public static readonly OpCode Prefixref;
         public static readonly OpCode Readonly;
         public static readonly OpCode Refanytype;
         public static readonly OpCode Refanyval;
         public static readonly OpCode Rem;
         public static readonly OpCode Rem_Un;
         public static readonly OpCode Ret;
         public static readonly OpCode Rethrow;
         public static readonly OpCode Shl;
         public static readonly OpCode Shr;
         public static readonly OpCode Shr_Un;
         public static readonly OpCode Sizeof;
         public static readonly OpCode Starg;
         public static readonly OpCode Starg_S;
         public static readonly OpCode Stelem;
         public static readonly OpCode Stelem_I;
         public static readonly OpCode Stelem_I1;
         public static readonly OpCode Stelem_I2;
         public static readonly OpCode Stelem_I4;
         public static readonly OpCode Stelem_I8;
         public static readonly OpCode Stelem_R4;
         public static readonly OpCode Stelem_R8;
         public static readonly OpCode Stelem_Ref;
         public static readonly OpCode Stfld;
         public static readonly OpCode Stind_I;
         public static readonly OpCode Stind_I1;
         public static readonly OpCode Stind_I2;
         public static readonly OpCode Stind_I4;
         public static readonly OpCode Stind_I8;
         public static readonly OpCode Stind_R4;
         public static readonly OpCode Stind_R8;
         public static readonly OpCode Stind_Ref;
         public static readonly OpCode Stloc;
         public static readonly OpCode Stloc_0;
         public static readonly OpCode Stloc_1;
         public static readonly OpCode Stloc_2;
         public static readonly OpCode Stloc_3;
         public static readonly OpCode Stloc_S;
         public static readonly OpCode Stobj;
         public static readonly OpCode Stsfld;
         public static readonly OpCode Sub;
         public static readonly OpCode Sub_Ovf;
         public static readonly OpCode Sub_Ovf_Un;
         public static readonly OpCode Switch;
         public static readonly OpCode Tailcall;
         public static readonly OpCode Throw;
         public static readonly OpCode Unaligned;
         public static readonly OpCode Unbox;
         public static readonly OpCode Unbox_Any;
         public static readonly OpCode Volatile;
         public static readonly OpCode Xor;
         public static bool TakesSingleByteArgument(OpCode inst);
     }
     public enum OpCodeType {
         Macro = 1,
         Nternal = 2,
         Objmodel = 3,
         Prefix = 4,
         Primitive = 5,
     }
     public enum OperandType {
         InlineBrTarget = 0,
         InlineField = 1,
         InlineI = 2,
         InlineI8 = 3,
         InlineMethod = 4,
         InlineNone = 5,
         InlineR = 7,
         InlineSig = 9,
         InlineString = 10,
         InlineSwitch = 11,
         InlineTok = 12,
         InlineType = 13,
         InlineVar = 14,
         ShortInlineBrTarget = 15,
         ShortInlineI = 16,
         ShortInlineR = 17,
         ShortInlineVar = 18,
     }
     public enum PackingSize {
         Size1 = 1,
         Size128 = 128,
         Size16 = 16,
         Size2 = 2,
         Size32 = 32,
         Size4 = 4,
         Size64 = 64,
         Size8 = 8,
         Unspecified = 0,
     }
     public enum StackBehaviour {
         Pop0 = 0,
         Pop1 = 1,
         Pop1_pop1 = 2,
         Popi = 3,
         Popi_pop1 = 4,
         Popi_popi = 5,
         Popi_popi8 = 6,
         Popi_popi_popi = 7,
         Popi_popr4 = 8,
         Popi_popr8 = 9,
         Popref = 10,
         Popref_pop1 = 11,
         Popref_popi = 12,
         Popref_popi_pop1 = 28,
         Popref_popi_popi = 13,
         Popref_popi_popi8 = 14,
         Popref_popi_popr4 = 15,
         Popref_popi_popr8 = 16,
         Popref_popi_popref = 17,
         Push0 = 18,
         Push1 = 19,
         Push1_push1 = 20,
         Pushi = 21,
         Pushi8 = 22,
         Pushr4 = 23,
         Pushr8 = 24,
         Pushref = 25,
         Varpop = 26,
         Varpush = 27,
     }
 }
 namespace System.Resources {
     public class MissingManifestResourceException : Exception {
         public MissingManifestResourceException();
         public MissingManifestResourceException(string message);
         public MissingManifestResourceException(string message, Exception inner);
     }
     public sealed class NeutralResourcesLanguageAttribute : Attribute {
         public NeutralResourcesLanguageAttribute(string cultureName);
         public string CultureName { get; }
     }
     public class ResourceManager {
         public ResourceManager(string baseName, Assembly assembly);
         public ResourceManager(Type resourceSource);
         public string GetString(string name);
         public virtual string GetString(string name, CultureInfo culture);
     }
     public sealed class SatelliteContractVersionAttribute : Attribute {
         public SatelliteContractVersionAttribute(string version);
         public string Version { get; }
     }
 }
 namespace System.Runtime {
     public enum GCLatencyMode {
         Batch = 0,
         Interactive = 1,
         LowLatency = 2,
         SustainedLowLatency = 3,
     }
     public static class GCSettings {
         public static bool IsServerGC { get; }
         public static GCLatencyMode LatencyMode { get; set; }
     }
 }
 namespace System.Runtime.CompilerServices {
     public sealed class AccessedThroughPropertyAttribute : Attribute {
         public AccessedThroughPropertyAttribute(string propertyName);
         public string PropertyName { get; }
     }
     public sealed class AsyncStateMachineAttribute : StateMachineAttribute {
         public AsyncStateMachineAttribute(Type stateMachineType);
     }
     public struct AsyncTaskMethodBuilder {
         public Task Task { get; }
         public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;
         public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;
         public static AsyncTaskMethodBuilder Create();
         public void SetException(Exception exception);
         public void SetResult();
         public void SetStateMachine(IAsyncStateMachine stateMachine);
         public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
     }
     public struct AsyncTaskMethodBuilder<TResult> {
         public Task<TResult> Task { get; }
         public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;
         public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;
         public static AsyncTaskMethodBuilder<TResult> Create();
         public void SetException(Exception exception);
         public void SetResult(TResult result);
         public void SetStateMachine(IAsyncStateMachine stateMachine);
         public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
     }
     public struct AsyncVoidMethodBuilder {
         public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;
         public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;
         public static AsyncVoidMethodBuilder Create();
         public void SetException(Exception exception);
         public void SetResult();
         public void SetStateMachine(IAsyncStateMachine stateMachine);
         public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
     }
     public sealed class CallerFilePathAttribute : Attribute {
         public CallerFilePathAttribute();
     }
     public sealed class CallerLineNumberAttribute : Attribute {
         public CallerLineNumberAttribute();
     }
     public sealed class CallerMemberNameAttribute : Attribute {
         public CallerMemberNameAttribute();
     }
     public class CompilationRelaxationsAttribute : Attribute {
         public CompilationRelaxationsAttribute(int relaxations);
         public int CompilationRelaxations { get; }
     }
     public sealed class CompilerGeneratedAttribute : Attribute {
         public CompilerGeneratedAttribute();
     }
     public struct ConfiguredTaskAwaitable {
         public struct ConfiguredTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion {
             public bool IsCompleted { get; }
             public void GetResult();
             public void OnCompleted(Action continuation);
             public void UnsafeOnCompleted(Action continuation);
         }
         public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter();
     }
     public struct ConfiguredTaskAwaitable<TResult> {
         public struct ConfiguredTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion {
             public bool IsCompleted { get; }
             public TResult GetResult();
             public void OnCompleted(Action continuation);
             public void UnsafeOnCompleted(Action continuation);
         }
         public ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter GetAwaiter();
     }
     public abstract class CustomConstantAttribute : Attribute {
         protected CustomConstantAttribute();
         public abstract object Value { get; }
     }
     public sealed class DateTimeConstantAttribute : CustomConstantAttribute {
         public DateTimeConstantAttribute(long ticks);
         public override object Value { get; }
     }
     public sealed class DecimalConstantAttribute : Attribute {
         public DecimalConstantAttribute(byte scale, byte sign, int hi, int mid, int low);
         public DecimalConstantAttribute(byte scale, byte sign, uint hi, uint mid, uint low);
         public decimal Value { get; }
     }
     public sealed class ExtensionAttribute : Attribute {
         public ExtensionAttribute();
     }
     public sealed class FixedBufferAttribute : Attribute {
         public FixedBufferAttribute(Type elementType, int length);
         public Type ElementType { get; }
         public int Length { get; }
     }
     public interface IAsyncStateMachine {
         void MoveNext();
         void SetStateMachine(IAsyncStateMachine stateMachine);
     }
     public interface ICriticalNotifyCompletion : INotifyCompletion {
         void UnsafeOnCompleted(Action continuation);
     }
     public sealed class IndexerNameAttribute : Attribute {
         public IndexerNameAttribute(string indexerName);
     }
     public interface INotifyCompletion {
         void OnCompleted(Action continuation);
     }
     public sealed class InternalsVisibleToAttribute : Attribute {
         public InternalsVisibleToAttribute(string assemblyName);
         public string AssemblyName { get; }
     }
     public interface IStrongBox {
         object Value { get; set; }
     }
     public static class IsVolatile
     public sealed class IteratorStateMachineAttribute : StateMachineAttribute {
         public IteratorStateMachineAttribute(Type stateMachineType);
     }
     public sealed class MethodImplAttribute : Attribute {
         public MethodImplAttribute(MethodImplOptions methodImplOptions);
         public MethodImplOptions Value { get; }
     }
     public enum MethodImplOptions {
         AggressiveInlining = 256,
         NoInlining = 8,
         NoOptimization = 64,
         PreserveSig = 128,
     }
     public sealed class ReferenceAssemblyAttribute : Attribute {
         public ReferenceAssemblyAttribute();
         public ReferenceAssemblyAttribute(string description);
         public string Description { get; }
     }
     public sealed class RuntimeCompatibilityAttribute : Attribute {
         public RuntimeCompatibilityAttribute();
         public bool WrapNonExceptionThrows { get; set; }
     }
     public static class RuntimeHelpers {
         public static int OffsetToStringData { get; }
         public static int GetHashCode(object o);
         public static object GetObjectValue(object obj);
         public static void InitializeArray(Array array, RuntimeFieldHandle fldHandle);
         public static void RunClassConstructor(RuntimeTypeHandle type);
     }
     public class StateMachineAttribute : Attribute {
         public StateMachineAttribute(Type stateMachineType);
         public Type StateMachineType { get; }
     }
     public class StrongBox<T> : IStrongBox {
         public T Value;
         public StrongBox();
         public StrongBox(T value);
     }
     public struct TaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion {
         public bool IsCompleted { get; }
         public void GetResult();
         public void OnCompleted(Action continuation);
         public void UnsafeOnCompleted(Action continuation);
     }
     public struct TaskAwaiter<TResult> : ICriticalNotifyCompletion, INotifyCompletion {
         public bool IsCompleted { get; }
         public TResult GetResult();
         public void OnCompleted(Action continuation);
         public void UnsafeOnCompleted(Action continuation);
     }
     public sealed class TypeForwardedFromAttribute : Attribute {
         public TypeForwardedFromAttribute(string assemblyFullName);
         public string AssemblyFullName { get; }
     }
     public sealed class TypeForwardedToAttribute : Attribute {
         public TypeForwardedToAttribute(Type destination);
         public Type Destination { get; }
     }
     public sealed class UnsafeValueTypeAttribute : Attribute {
         public UnsafeValueTypeAttribute();
     }
     public struct YieldAwaitable {
         public struct YieldAwaiter : ICriticalNotifyCompletion, INotifyCompletion {
             public bool IsCompleted { get; }
             public void GetResult();
             public void OnCompleted(Action continuation);
             public void UnsafeOnCompleted(Action continuation);
         }
         public YieldAwaitable.YieldAwaiter GetAwaiter();
     }
 }
 namespace System.Runtime.ExceptionServices {
     public sealed class ExceptionDispatchInfo {
         public Exception SourceException { get; }
         public static ExceptionDispatchInfo Capture(Exception source);
         public void Throw();
     }
 }
 namespace System.Runtime.InteropServices {
     public enum Architecture {
         Arm = 2,
         Arm64 = 3,
         X64 = 1,
         X86 = 0,
     }
     public struct ArrayWithOffset {
         public ArrayWithOffset(object array, int offset);
         public bool Equals(ArrayWithOffset obj);
         public override bool Equals(object obj);
         public object GetArray();
         public override int GetHashCode();
         public int GetOffset();
         public static bool operator ==(ArrayWithOffset a, ArrayWithOffset b);
         public static bool operator !=(ArrayWithOffset a, ArrayWithOffset b);
     }
     public sealed class BestFitMappingAttribute : Attribute {
         public bool ThrowOnUnmappableChar;
         public BestFitMappingAttribute(bool BestFitMapping);
         public bool BestFitMapping { get; }
     }
     public sealed class BStrWrapper {
         public BStrWrapper(object value);
         public BStrWrapper(string value);
         public string WrappedObject { get; }
     }
     public enum CallingConvention {
         Cdecl = 2,
         StdCall = 3,
         ThisCall = 4,
         Winapi = 1,
     }
     public enum CharSet {
         Ansi = 2,
         Unicode = 3,
     }
     public sealed class ClassInterfaceAttribute : Attribute {
         public ClassInterfaceAttribute(ClassInterfaceType classInterfaceType);
         public ClassInterfaceAttribute(short classInterfaceType);
         public ClassInterfaceType Value { get; }
     }
     public enum ClassInterfaceType {
         AutoDispatch = 1,
         AutoDual = 2,
         None = 0,
     }
     public sealed class CoClassAttribute : Attribute {
         public CoClassAttribute(Type coClass);
         public Type CoClass { get; }
     }
     public class ComAwareEventInfo : EventInfo {
         public ComAwareEventInfo(Type type, string eventName);
         public override EventAttributes Attributes { get; }
         public override Type DeclaringType { get; }
         public override string Name { get; }
         public override void AddEventHandler(object target, Delegate handler);
         public override void RemoveEventHandler(object target, Delegate handler);
     }
     public sealed class ComDefaultInterfaceAttribute : Attribute {
         public ComDefaultInterfaceAttribute(Type defaultInterface);
         public Type Value { get; }
     }
     public sealed class ComEventInterfaceAttribute : Attribute {
         public ComEventInterfaceAttribute(Type SourceInterface, Type EventProvider);
         public Type EventProvider { get; }
         public Type SourceInterface { get; }
     }
     public static class ComEventsHelper {
         public static void Combine(object rcw, Guid iid, int dispid, Delegate d);
         public static Delegate Remove(object rcw, Guid iid, int dispid, Delegate d);
     }
     public class COMException : Exception {
         public COMException();
         public COMException(string message);
         public COMException(string message, Exception inner);
         public COMException(string message, int errorCode);
     }
     public sealed class ComImportAttribute : Attribute {
         public ComImportAttribute();
     }
     public enum ComInterfaceType {
         InterfaceIsDual = 0,
         InterfaceIsIDispatch = 2,
         InterfaceIsIInspectable = 3,
         InterfaceIsIUnknown = 1,
     }
     public enum ComMemberType {
         Method = 0,
         PropGet = 1,
         PropSet = 2,
     }
     public sealed class ComSourceInterfacesAttribute : Attribute {
         public ComSourceInterfacesAttribute(string sourceInterfaces);
         public ComSourceInterfacesAttribute(Type sourceInterface);
         public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2);
         public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2, Type sourceInterface3);
         public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2, Type sourceInterface3, Type sourceInterface4);
         public string Value { get; }
     }
     public sealed class ComVisibleAttribute : Attribute {
         public ComVisibleAttribute(bool visibility);
         public bool Value { get; }
     }
     public abstract class CriticalHandle : IDisposable {
         protected IntPtr handle;
         protected CriticalHandle(IntPtr invalidHandleValue);
         public bool IsClosed { get; }
         public abstract bool IsInvalid { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         ~CriticalHandle();
         protected abstract bool ReleaseHandle();
         protected void SetHandle(IntPtr handle);
         public void SetHandleAsInvalid();
     }
     public sealed class CurrencyWrapper {
         public CurrencyWrapper(decimal obj);
         public CurrencyWrapper(object obj);
         public decimal WrappedObject { get; }
     }
     public enum CustomQueryInterfaceMode {
         Allow = 1,
         Ignore = 0,
     }
     public enum CustomQueryInterfaceResult {
         Failed = 2,
         Handled = 0,
         NotHandled = 1,
     }
     public sealed class DefaultCharSetAttribute : Attribute {
         public DefaultCharSetAttribute(CharSet charSet);
         public CharSet CharSet { get; }
     }
     public sealed class DefaultDllImportSearchPathsAttribute : Attribute {
         public DefaultDllImportSearchPathsAttribute(DllImportSearchPath paths);
         public DllImportSearchPath Paths { get; }
     }
     public sealed class DefaultParameterValueAttribute : Attribute {
         public DefaultParameterValueAttribute(object value);
         public object Value { get; }
     }
     public sealed class DispatchWrapper {
         public DispatchWrapper(object obj);
         public object WrappedObject { get; }
     }
     public sealed class DispIdAttribute : Attribute {
         public DispIdAttribute(int dispId);
         public int Value { get; }
     }
     public sealed class DllImportAttribute : Attribute {
         public bool BestFitMapping;
         public CallingConvention CallingConvention;
         public CharSet CharSet;
         public string EntryPoint;
         public bool ExactSpelling;
         public bool PreserveSig;
         public bool SetLastError;
         public bool ThrowOnUnmappableChar;
         public DllImportAttribute(string dllName);
         public string Value { get; }
     }
     public enum DllImportSearchPath {
         ApplicationDirectory = 512,
         AssemblyDirectory = 2,
         LegacyBehavior = 0,
         SafeDirectories = 4096,
         System32 = 2048,
         UseDllDirectoryForDependencies = 256,
         UserDirectories = 1024,
     }
     public sealed class ErrorWrapper {
         public ErrorWrapper(Exception e);
         public ErrorWrapper(int errorCode);
         public ErrorWrapper(object errorCode);
         public int ErrorCode { get; }
     }
     public sealed class FieldOffsetAttribute : Attribute {
         public FieldOffsetAttribute(int offset);
         public int Value { get; }
     }
     public struct GCHandle {
         public bool IsAllocated { get; }
         public object Target { get; set; }
         public IntPtr AddrOfPinnedObject();
         public static GCHandle Alloc(object value);
         public static GCHandle Alloc(object value, GCHandleType type);
         public override bool Equals(object o);
         public void Free();
         public static GCHandle FromIntPtr(IntPtr value);
         public override int GetHashCode();
         public static bool operator ==(GCHandle a, GCHandle b);
         public static explicit operator IntPtr (GCHandle value);
         public static explicit operator GCHandle (IntPtr value);
         public static bool operator !=(GCHandle a, GCHandle b);
         public static IntPtr ToIntPtr(GCHandle value);
     }
     public enum GCHandleType {
         Normal = 2,
         Pinned = 3,
         Weak = 0,
         WeakTrackResurrection = 1,
     }
     public sealed class GuidAttribute : Attribute {
         public GuidAttribute(string guid);
         public string Value { get; }
     }
     public sealed class HandleCollector {
         public HandleCollector(string name, int initialThreshold);
         public HandleCollector(string name, int initialThreshold, int maximumThreshold);
         public int Count { get; }
         public int InitialThreshold { get; }
         public int MaximumThreshold { get; }
         public string Name { get; }
         public void Add();
         public void Remove();
     }
     public interface ICustomAdapter {
         object GetUnderlyingObject();
     }
     public interface ICustomQueryInterface {
         CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv);
     }
     public sealed class InAttribute : Attribute {
         public InAttribute();
     }
     public sealed class InterfaceTypeAttribute : Attribute {
         public InterfaceTypeAttribute(ComInterfaceType interfaceType);
         public InterfaceTypeAttribute(short interfaceType);
         public ComInterfaceType Value { get; }
     }
     public class InvalidComObjectException : Exception {
         public InvalidComObjectException();
         public InvalidComObjectException(string message);
         public InvalidComObjectException(string message, Exception inner);
     }
     public class InvalidOleVariantTypeException : Exception {
         public InvalidOleVariantTypeException();
         public InvalidOleVariantTypeException(string message);
         public InvalidOleVariantTypeException(string message, Exception inner);
     }
     public enum LayoutKind {
         Auto = 3,
         Explicit = 2,
         Sequential = 0,
     }
     public static class Marshal {
         public static readonly int SystemDefaultCharSize;
         public static readonly int SystemMaxDBCSCharSize;
         public static int AddRef(IntPtr pUnk);
         public static IntPtr AllocCoTaskMem(int cb);
         public static IntPtr AllocHGlobal(int cb);
         public static IntPtr AllocHGlobal(IntPtr cb);
         public static bool AreComObjectsAvailableForCleanup();
         public static void Copy(byte[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(char[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(double[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(short[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(int[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(long[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(IntPtr source, byte[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, char[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, double[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, short[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, int[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, long[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, IntPtr[] destination, int startIndex, int length);
         public static void Copy(IntPtr source, float[] destination, int startIndex, int length);
         public static void Copy(IntPtr[] source, int startIndex, IntPtr destination, int length);
         public static void Copy(float[] source, int startIndex, IntPtr destination, int length);
         public static IntPtr CreateAggregatedObject(IntPtr pOuter, object o);
         public static object CreateWrapperOfType(object o, Type t);
         public static void DestroyStructure(IntPtr ptr, Type structuretype);
         public static int FinalReleaseComObject(object o);
         public static void FreeBSTR(IntPtr ptr);
         public static void FreeCoTaskMem(IntPtr ptr);
         public static void FreeHGlobal(IntPtr hglobal);
         public static IntPtr GetComInterfaceForObject(object o, Type T);
         public static IntPtr GetComInterfaceForObject(object o, Type T, CustomQueryInterfaceMode mode);
         public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t);
         public static int GetExceptionCode();
         public static Exception GetExceptionForHR(int errorCode);
         public static Exception GetExceptionForHR(int errorCode, IntPtr errorInfo);
         public static IntPtr GetFunctionPointerForDelegate(Delegate d);
         public static int GetHRForException(Exception e);
         public static int GetHRForLastWin32Error();
         public static IntPtr GetIUnknownForObject(object o);
         public static int GetLastWin32Error();
         public static void GetNativeVariantForObject(object obj, IntPtr pDstNativeVariant);
         public static object GetObjectForIUnknown(IntPtr pUnk);
         public static object GetObjectForNativeVariant(IntPtr pSrcNativeVariant);
         public static object[] GetObjectsForNativeVariants(IntPtr aSrcNativeVariant, int cVars);
         public static int GetStartComSlot(Type t);
         public static Type GetTypeFromCLSID(Guid clsid);
         public static string GetTypeInfoName(ITypeInfo typeInfo);
         public static object GetUniqueObjectForIUnknown(IntPtr unknown);
         public static bool IsComObject(object o);
         public static IntPtr OffsetOf(Type t, string fieldName);
         public static string PtrToStringAnsi(IntPtr ptr);
         public static string PtrToStringAnsi(IntPtr ptr, int len);
         public static string PtrToStringBSTR(IntPtr ptr);
         public static string PtrToStringUni(IntPtr ptr);
         public static string PtrToStringUni(IntPtr ptr, int len);
         public static void PtrToStructure(IntPtr ptr, object structure);
         public static object PtrToStructure(IntPtr ptr, Type structureType);
         public static int QueryInterface(IntPtr pUnk, ref Guid iid, out IntPtr ppv);
         public static byte ReadByte(IntPtr ptr);
         public static byte ReadByte(IntPtr ptr, int ofs);
         public static byte ReadByte(object ptr, int ofs);
         public static short ReadInt16(IntPtr ptr);
         public static short ReadInt16(IntPtr ptr, int ofs);
         public static short ReadInt16(object ptr, int ofs);
         public static int ReadInt32(IntPtr ptr);
         public static int ReadInt32(IntPtr ptr, int ofs);
         public static int ReadInt32(object ptr, int ofs);
         public static long ReadInt64(IntPtr ptr);
         public static long ReadInt64(IntPtr ptr, int ofs);
         public static long ReadInt64(object ptr, int ofs);
         public static IntPtr ReadIntPtr(IntPtr ptr);
         public static IntPtr ReadIntPtr(IntPtr ptr, int ofs);
         public static IntPtr ReadIntPtr(object ptr, int ofs);
         public static IntPtr ReAllocCoTaskMem(IntPtr pv, int cb);
         public static IntPtr ReAllocHGlobal(IntPtr pv, IntPtr cb);
         public static int Release(IntPtr pUnk);
         public static int ReleaseComObject(object o);
         public static int SizeOf(object structure);
         public static int SizeOf(Type t);
         public static IntPtr StringToBSTR(string s);
         public static IntPtr StringToCoTaskMemAnsi(string s);
         public static IntPtr StringToCoTaskMemUni(string s);
         public static IntPtr StringToHGlobalAnsi(string s);
         public static IntPtr StringToHGlobalUni(string s);
         public static void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld);
         public static void ThrowExceptionForHR(int errorCode);
         public static void ThrowExceptionForHR(int errorCode, IntPtr errorInfo);
         public static IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index);
         public static void WriteByte(IntPtr ptr, byte val);
         public static void WriteByte(IntPtr ptr, int ofs, byte val);
         public static void WriteByte(object ptr, int ofs, byte val);
         public static void WriteInt16(IntPtr ptr, char val);
         public static void WriteInt16(IntPtr ptr, short val);
         public static void WriteInt16(IntPtr ptr, int ofs, char val);
         public static void WriteInt16(IntPtr ptr, int ofs, short val);
         public static void WriteInt16(object ptr, int ofs, char val);
         public static void WriteInt16(object ptr, int ofs, short val);
         public static void WriteInt32(IntPtr ptr, int val);
         public static void WriteInt32(IntPtr ptr, int ofs, int val);
         public static void WriteInt32(object ptr, int ofs, int val);
         public static void WriteInt64(IntPtr ptr, int ofs, long val);
         public static void WriteInt64(IntPtr ptr, long val);
         public static void WriteInt64(object ptr, int ofs, long val);
         public static void WriteIntPtr(IntPtr ptr, int ofs, IntPtr val);
         public static void WriteIntPtr(IntPtr ptr, IntPtr val);
         public static void WriteIntPtr(object ptr, int ofs, IntPtr val);
         public static void ZeroFreeBSTR(IntPtr s);
         public static void ZeroFreeCoTaskMemAnsi(IntPtr s);
         public static void ZeroFreeCoTaskMemUnicode(IntPtr s);
         public static void ZeroFreeGlobalAllocAnsi(IntPtr s);
         public static void ZeroFreeGlobalAllocUnicode(IntPtr s);
     }
     public sealed class MarshalAsAttribute : Attribute {
         public UnmanagedType ArraySubType;
         public int IidParameterIndex;
         public string MarshalCookie;
         public string MarshalType;
         public Type MarshalTypeRef;
         public VarEnum SafeArraySubType;
         public Type SafeArrayUserDefinedSubType;
         public int SizeConst;
         public short SizeParamIndex;
         public MarshalAsAttribute(short unmanagedType);
         public MarshalAsAttribute(UnmanagedType unmanagedType);
         public UnmanagedType Value { get; }
     }
     public class MarshalDirectiveException : Exception {
         public MarshalDirectiveException();
         public MarshalDirectiveException(string message);
         public MarshalDirectiveException(string message, Exception inner);
     }
     public sealed class OptionalAttribute : Attribute {
         public OptionalAttribute();
     }
     public struct OSPlatform : IEquatable<OSPlatform> {
         public static OSPlatform Linux { get; }
         public static OSPlatform OSX { get; }
         public static OSPlatform Windows { get; }
         public static OSPlatform Create(string osPlatform);
         public override bool Equals(object obj);
         public bool Equals(OSPlatform other);
         public override int GetHashCode();
         public static bool operator ==(OSPlatform left, OSPlatform right);
         public static bool operator !=(OSPlatform left, OSPlatform right);
         public override string ToString();
     }
     public sealed class OutAttribute : Attribute {
         public OutAttribute();
     }
     public sealed class PreserveSigAttribute : Attribute {
         public PreserveSigAttribute();
     }
     public static class RuntimeInformation {
         public static string FrameworkDescription { get; }
         public static Architecture OSArchitecture { get; }
         public static string OSDescription { get; }
         public static Architecture ProcessArchitecture { get; }
         public static bool IsOSPlatform(OSPlatform osPlatform);
     }
     public class SafeArrayRankMismatchException : Exception {
         public SafeArrayRankMismatchException();
         public SafeArrayRankMismatchException(string message);
         public SafeArrayRankMismatchException(string message, Exception inner);
     }
     public class SafeArrayTypeMismatchException : Exception {
         public SafeArrayTypeMismatchException();
         public SafeArrayTypeMismatchException(string message);
         public SafeArrayTypeMismatchException(string message, Exception inner);
     }
     public abstract class SafeBuffer : SafeHandle {
         protected SafeBuffer(bool ownsHandle);
         public ulong ByteLength { get; }
         public override bool IsInvalid { get; }
         public unsafe void AcquirePointer(ref byte* pointer);
         public void Initialize<T>(uint numElements) where T : struct;
         public void Initialize(uint numElements, uint sizeOfEachElement);
         public void Initialize(ulong numBytes);
         public T Read<T>(ulong byteOffset) where T : struct;
         public void ReadArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct;
         public void ReleasePointer();
         public void Write<T>(ulong byteOffset, T value) where T : struct;
         public void WriteArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct;
     }
     public abstract class SafeHandle : IDisposable {
         protected IntPtr handle;
         protected SafeHandle(IntPtr invalidHandleValue, bool ownsHandle);
         public bool IsClosed { get; }
         public abstract bool IsInvalid { get; }
         public void DangerousAddRef(ref bool success);
         public IntPtr DangerousGetHandle();
         public void DangerousRelease();
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         ~SafeHandle();
         protected abstract bool ReleaseHandle();
         protected void SetHandle(IntPtr handle);
         public void SetHandleAsInvalid();
     }
     public class SEHException : Exception {
         public SEHException();
         public SEHException(string message);
         public SEHException(string message, Exception inner);
         public virtual bool CanResume();
     }
     public sealed class StructLayoutAttribute : Attribute {
         public CharSet CharSet;
         public int Pack;
         public int Size;
         public StructLayoutAttribute(LayoutKind layoutKind);
         public LayoutKind Value { get; }
     }
     public sealed class TypeIdentifierAttribute : Attribute {
         public TypeIdentifierAttribute();
         public TypeIdentifierAttribute(string scope, string identifier);
         public string Identifier { get; }
         public string Scope { get; }
     }
     public sealed class UnknownWrapper {
         public UnknownWrapper(object obj);
         public object WrappedObject { get; }
     }
     public sealed class UnmanagedFunctionPointerAttribute : Attribute {
         public bool BestFitMapping;
         public CharSet CharSet;
         public bool SetLastError;
         public bool ThrowOnUnmappableChar;
         public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention);
         public CallingConvention CallingConvention { get; }
     }
     public enum UnmanagedType {
         AnsiBStr = 35,
         AsAny = 40,
         Bool = 2,
         BStr = 19,
         ByValArray = 30,
         ByValTStr = 23,
         Currency = 15,
         Error = 45,
         FunctionPtr = 38,
         HString = 47,
         I1 = 3,
         I2 = 5,
         I4 = 7,
         I8 = 9,
         IDispatch = 26,
         IInspectable = 46,
         Interface = 28,
         IUnknown = 25,
         LPArray = 42,
         LPStr = 20,
         LPStruct = 43,
         LPTStr = 22,
         LPWStr = 21,
         R4 = 11,
         R8 = 12,
         SafeArray = 29,
         Struct = 27,
         SysInt = 31,
         SysUInt = 32,
         TBStr = 36,
         U1 = 4,
         U2 = 6,
         U4 = 8,
         U8 = 10,
         VariantBool = 37,
         VBByRefStr = 34,
     }
     public enum VarEnum {
         VT_ARRAY = 8192,
         VT_BLOB = 65,
         VT_BLOB_OBJECT = 70,
         VT_BOOL = 11,
         VT_BSTR = 8,
         VT_BYREF = 16384,
         VT_CARRAY = 28,
         VT_CF = 71,
         VT_CLSID = 72,
         VT_CY = 6,
         VT_DATE = 7,
         VT_DECIMAL = 14,
         VT_DISPATCH = 9,
         VT_EMPTY = 0,
         VT_ERROR = 10,
         VT_FILETIME = 64,
         VT_HRESULT = 25,
         VT_I1 = 16,
         VT_I2 = 2,
         VT_I4 = 3,
         VT_I8 = 20,
         VT_INT = 22,
         VT_LPSTR = 30,
         VT_LPWSTR = 31,
         VT_NULL = 1,
         VT_PTR = 26,
         VT_R4 = 4,
         VT_R8 = 5,
         VT_RECORD = 36,
         VT_SAFEARRAY = 27,
         VT_STORAGE = 67,
         VT_STORED_OBJECT = 69,
         VT_STREAM = 66,
         VT_STREAMED_OBJECT = 68,
         VT_UI1 = 17,
         VT_UI2 = 18,
         VT_UI4 = 19,
         VT_UI8 = 21,
         VT_UINT = 23,
         VT_UNKNOWN = 13,
         VT_USERDEFINED = 29,
         VT_VARIANT = 12,
         VT_VECTOR = 4096,
         VT_VOID = 24,
     }
     public sealed class VariantWrapper {
         public VariantWrapper(object obj);
         public object WrappedObject { get; }
     }
 }
 namespace System.Runtime.InteropServices.ComTypes {
     public enum ADVF {
         ADVFCACHE_FORCEBUILTIN = 16,
         ADVFCACHE_NOHANDLER = 8,
         ADVFCACHE_ONSAVE = 32,
         ADVF_DATAONSTOP = 64,
         ADVF_NODATA = 1,
         ADVF_ONLYONCE = 4,
         ADVF_PRIMEFIRST = 2,
     }
     public struct BINDPTR {
         public IntPtr lpfuncdesc;
         public IntPtr lptcomp;
         public IntPtr lpvardesc;
     }
     public struct BIND_OPTS {
         public int cbStruct;
         public int dwTickCountDeadline;
         public int grfFlags;
         public int grfMode;
     }
     public enum CALLCONV {
         CC_CDECL = 1,
         CC_MACPASCAL = 3,
         CC_MAX = 9,
         CC_MPWCDECL = 7,
         CC_MPWPASCAL = 8,
         CC_MSCPASCAL = 2,
         CC_PASCAL = 2,
         CC_RESERVED = 5,
         CC_STDCALL = 4,
         CC_SYSCALL = 6,
     }
     public struct CONNECTDATA {
         public int dwCookie;
         public object pUnk;
     }
     public enum DATADIR {
         DATADIR_GET = 1,
         DATADIR_SET = 2,
     }
     public enum DESCKIND {
         DESCKIND_FUNCDESC = 1,
         DESCKIND_IMPLICITAPPOBJ = 4,
         DESCKIND_MAX = 5,
         DESCKIND_NONE = 0,
         DESCKIND_TYPECOMP = 3,
         DESCKIND_VARDESC = 2,
     }
     public struct DISPPARAMS {
         public int cArgs;
         public int cNamedArgs;
         public IntPtr rgdispidNamedArgs;
         public IntPtr rgvarg;
     }
     public enum DVASPECT {
         DVASPECT_CONTENT = 1,
         DVASPECT_DOCPRINT = 8,
         DVASPECT_ICON = 4,
         DVASPECT_THUMBNAIL = 2,
     }
     public struct ELEMDESC {
         public struct DESCUNION {
             public IDLDESC idldesc;
             public PARAMDESC paramdesc;
         }
         public ELEMDESC.DESCUNION desc;
         public TYPEDESC tdesc;
     }
     public struct EXCEPINFO {
         public string bstrDescription;
         public string bstrHelpFile;
         public string bstrSource;
         public int dwHelpContext;
         public IntPtr pfnDeferredFillIn;
         public IntPtr pvReserved;
         public int scode;
         public short wCode;
         public short wReserved;
     }
     public struct FILETIME {
         public int dwHighDateTime;
         public int dwLowDateTime;
     }
     public struct FORMATETC {
         public short cfFormat;
         public DVASPECT dwAspect;
         public int lindex;
         public IntPtr ptd;
         public TYMED tymed;
     }
     public struct FUNCDESC {
         public CALLCONV callconv;
         public short cParams;
         public short cParamsOpt;
         public short cScodes;
         public ELEMDESC elemdescFunc;
         public FUNCKIND funckind;
         public INVOKEKIND invkind;
         public IntPtr lprgelemdescParam;
         public IntPtr lprgscode;
         public int memid;
         public short oVft;
         public short wFuncFlags;
     }
     public enum FUNCFLAGS : short {
         FUNCFLAG_FBINDABLE = (short)4,
         FUNCFLAG_FDEFAULTBIND = (short)32,
         FUNCFLAG_FDEFAULTCOLLELEM = (short)256,
         FUNCFLAG_FDISPLAYBIND = (short)16,
         FUNCFLAG_FHIDDEN = (short)64,
         FUNCFLAG_FIMMEDIATEBIND = (short)4096,
         FUNCFLAG_FNONBROWSABLE = (short)1024,
         FUNCFLAG_FREPLACEABLE = (short)2048,
         FUNCFLAG_FREQUESTEDIT = (short)8,
         FUNCFLAG_FRESTRICTED = (short)1,
         FUNCFLAG_FSOURCE = (short)2,
         FUNCFLAG_FUIDEFAULT = (short)512,
         FUNCFLAG_FUSESGETLASTERROR = (short)128,
     }
     public enum FUNCKIND {
         FUNC_DISPATCH = 4,
         FUNC_NONVIRTUAL = 2,
         FUNC_PUREVIRTUAL = 1,
         FUNC_STATIC = 3,
         FUNC_VIRTUAL = 0,
     }
     public interface IAdviseSink {
         void OnClose();
         void OnDataChange(ref FORMATETC format, ref STGMEDIUM stgmedium);
         void OnRename(IMoniker moniker);
         void OnSave();
         void OnViewChange(int aspect, int index);
     }
     public interface IBindCtx {
         void EnumObjectParam(out IEnumString ppenum);
         void GetBindOptions(ref BIND_OPTS pbindopts);
         void GetObjectParam(string pszKey, out object ppunk);
         void GetRunningObjectTable(out IRunningObjectTable pprot);
         void RegisterObjectBound(object punk);
         void RegisterObjectParam(string pszKey, object punk);
         void ReleaseBoundObjects();
         void RevokeObjectBound(object punk);
         int RevokeObjectParam(string pszKey);
         void SetBindOptions(ref BIND_OPTS pbindopts);
     }
     public interface IConnectionPoint {
         void Advise(object pUnkSink, out int pdwCookie);
         void EnumConnections(out IEnumConnections ppEnum);
         void GetConnectionInterface(out Guid pIID);
         void GetConnectionPointContainer(out IConnectionPointContainer ppCPC);
         void Unadvise(int dwCookie);
     }
     public interface IConnectionPointContainer {
         void EnumConnectionPoints(out IEnumConnectionPoints ppEnum);
         void FindConnectionPoint(ref Guid riid, out IConnectionPoint ppCP);
     }
     public struct IDLDESC {
         public IntPtr dwReserved;
         public IDLFLAG wIDLFlags;
     }
     public enum IDLFLAG : short {
         IDLFLAG_FIN = (short)1,
         IDLFLAG_FLCID = (short)4,
         IDLFLAG_FOUT = (short)2,
         IDLFLAG_FRETVAL = (short)8,
         IDLFLAG_NONE = (short)0,
     }
     public interface IEnumConnectionPoints {
         void Clone(out IEnumConnectionPoints ppenum);
         int Next(int celt, IConnectionPoint[] rgelt, IntPtr pceltFetched);
         void Reset();
         int Skip(int celt);
     }
     public interface IEnumConnections {
         void Clone(out IEnumConnections ppenum);
         int Next(int celt, CONNECTDATA[] rgelt, IntPtr pceltFetched);
         void Reset();
         int Skip(int celt);
     }
     public interface IEnumFORMATETC {
         void Clone(out IEnumFORMATETC newEnum);
         int Next(int celt, FORMATETC[] rgelt, int[] pceltFetched);
         int Reset();
         int Skip(int celt);
     }
     public interface IEnumMoniker {
         void Clone(out IEnumMoniker ppenum);
         int Next(int celt, IMoniker[] rgelt, IntPtr pceltFetched);
         void Reset();
         int Skip(int celt);
     }
     public interface IEnumString {
         void Clone(out IEnumString ppenum);
         int Next(int celt, string[] rgelt, IntPtr pceltFetched);
         void Reset();
         int Skip(int celt);
     }
     public interface IEnumVARIANT {
         IEnumVARIANT Clone();
         int Next(int celt, object[] rgVar, IntPtr pceltFetched);
         int Reset();
         int Skip(int celt);
     }
     public interface IMoniker {
         void BindToObject(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riidResult, out object ppvResult);
         void BindToStorage(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riid, out object ppvObj);
         void CommonPrefixWith(IMoniker pmkOther, out IMoniker ppmkPrefix);
         void ComposeWith(IMoniker pmkRight, bool fOnlyIfNotGeneric, out IMoniker ppmkComposite);
         void Enum(bool fForward, out IEnumMoniker ppenumMoniker);
         void GetClassID(out Guid pClassID);
         void GetDisplayName(IBindCtx pbc, IMoniker pmkToLeft, out string ppszDisplayName);
         void GetSizeMax(out long pcbSize);
         void GetTimeOfLastChange(IBindCtx pbc, IMoniker pmkToLeft, out FILETIME pFileTime);
         void Hash(out int pdwHash);
         void Inverse(out IMoniker ppmk);
         int IsDirty();
         int IsEqual(IMoniker pmkOtherMoniker);
         int IsRunning(IBindCtx pbc, IMoniker pmkToLeft, IMoniker pmkNewlyRunning);
         int IsSystemMoniker(out int pdwMksys);
         void Load(IStream pStm);
         void ParseDisplayName(IBindCtx pbc, IMoniker pmkToLeft, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut);
         void Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker ppmkToLeft, out IMoniker ppmkReduced);
         void RelativePathTo(IMoniker pmkOther, out IMoniker ppmkRelPath);
         void Save(IStream pStm, bool fClearDirty);
     }
     public enum IMPLTYPEFLAGS {
         IMPLTYPEFLAG_FDEFAULT = 1,
         IMPLTYPEFLAG_FDEFAULTVTABLE = 8,
         IMPLTYPEFLAG_FRESTRICTED = 4,
         IMPLTYPEFLAG_FSOURCE = 2,
     }
     public enum INVOKEKIND {
         INVOKE_FUNC = 1,
         INVOKE_PROPERTYGET = 2,
         INVOKE_PROPERTYPUT = 4,
         INVOKE_PROPERTYPUTREF = 8,
     }
     public interface IPersistFile {
         void GetClassID(out Guid pClassID);
         void GetCurFile(out string ppszFileName);
         int IsDirty();
         void Load(string pszFileName, int dwMode);
         void Save(string pszFileName, bool fRemember);
         void SaveCompleted(string pszFileName);
     }
     public interface IRunningObjectTable {
         void EnumRunning(out IEnumMoniker ppenumMoniker);
         int GetObject(IMoniker pmkObjectName, out object ppunkObject);
         int GetTimeOfLastChange(IMoniker pmkObjectName, out FILETIME pfiletime);
         int IsRunning(IMoniker pmkObjectName);
         void NoteChangeTime(int dwRegister, ref FILETIME pfiletime);
         int Register(int grfFlags, object punkObject, IMoniker pmkObjectName);
         void Revoke(int dwRegister);
     }
     public interface IStream {
         void Clone(out IStream ppstm);
         void Commit(int grfCommitFlags);
         void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);
         void LockRegion(long libOffset, long cb, int dwLockType);
         void Read(byte[] pv, int cb, IntPtr pcbRead);
         void Revert();
         void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);
         void SetSize(long libNewSize);
         void Stat(out STATSTG pstatstg, int grfStatFlag);
         void UnlockRegion(long libOffset, long cb, int dwLockType);
         void Write(byte[] pv, int cb, IntPtr pcbWritten);
     }
     public interface ITypeComp {
         void Bind(string szName, int lHashVal, short wFlags, out ITypeInfo ppTInfo, out DESCKIND pDescKind, out BINDPTR pBindPtr);
         void BindType(string szName, int lHashVal, out ITypeInfo ppTInfo, out ITypeComp ppTComp);
     }
     public interface ITypeInfo {
         void AddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv);
         void CreateInstance(object pUnkOuter, ref Guid riid, out object ppvObj);
         void GetContainingTypeLib(out ITypeLib ppTLB, out int pIndex);
         void GetDllEntry(int memid, INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);
         void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
         void GetFuncDesc(int index, out IntPtr ppFuncDesc);
         void GetIDsOfNames(string[] rgszNames, int cNames, int[] pMemId);
         void GetImplTypeFlags(int index, out IMPLTYPEFLAGS pImplTypeFlags);
         void GetMops(int memid, out string pBstrMops);
         void GetNames(int memid, string[] rgBstrNames, int cMaxNames, out int pcNames);
         void GetRefTypeInfo(int hRef, out ITypeInfo ppTI);
         void GetRefTypeOfImplType(int index, out int href);
         void GetTypeAttr(out IntPtr ppTypeAttr);
         void GetTypeComp(out ITypeComp ppTComp);
         void GetVarDesc(int index, out IntPtr ppVarDesc);
         void Invoke(object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);
         void ReleaseFuncDesc(IntPtr pFuncDesc);
         void ReleaseTypeAttr(IntPtr pTypeAttr);
         void ReleaseVarDesc(IntPtr pVarDesc);
     }
     public interface ITypeInfo2 : ITypeInfo {
         new void AddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv);
         new void CreateInstance(object pUnkOuter, ref Guid riid, out object ppvObj);
         void GetAllCustData(IntPtr pCustData);
         void GetAllFuncCustData(int index, IntPtr pCustData);
         void GetAllImplTypeCustData(int index, IntPtr pCustData);
         void GetAllParamCustData(int indexFunc, int indexParam, IntPtr pCustData);
         void GetAllVarCustData(int index, IntPtr pCustData);
         new void GetContainingTypeLib(out ITypeLib ppTLB, out int pIndex);
         void GetCustData(ref Guid guid, out object pVarVal);
         new void GetDllEntry(int memid, INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);
         new void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
         void GetDocumentation2(int memid, out string pbstrHelpString, out int pdwHelpStringContext, out string pbstrHelpStringDll);
         void GetFuncCustData(int index, ref Guid guid, out object pVarVal);
         new void GetFuncDesc(int index, out IntPtr ppFuncDesc);
         void GetFuncIndexOfMemId(int memid, INVOKEKIND invKind, out int pFuncIndex);
         new void GetIDsOfNames(string[] rgszNames, int cNames, int[] pMemId);
         void GetImplTypeCustData(int index, ref Guid guid, out object pVarVal);
         new void GetImplTypeFlags(int index, out IMPLTYPEFLAGS pImplTypeFlags);
         new void GetMops(int memid, out string pBstrMops);
         new void GetNames(int memid, string[] rgBstrNames, int cMaxNames, out int pcNames);
         void GetParamCustData(int indexFunc, int indexParam, ref Guid guid, out object pVarVal);
         new void GetRefTypeInfo(int hRef, out ITypeInfo ppTI);
         new void GetRefTypeOfImplType(int index, out int href);
         new void GetTypeAttr(out IntPtr ppTypeAttr);
         new void GetTypeComp(out ITypeComp ppTComp);
         void GetTypeFlags(out int pTypeFlags);
         void GetTypeKind(out TYPEKIND pTypeKind);
         void GetVarCustData(int index, ref Guid guid, out object pVarVal);
         new void GetVarDesc(int index, out IntPtr ppVarDesc);
         void GetVarIndexOfMemId(int memid, out int pVarIndex);
         new void Invoke(object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);
         new void ReleaseFuncDesc(IntPtr pFuncDesc);
         new void ReleaseTypeAttr(IntPtr pTypeAttr);
         new void ReleaseVarDesc(IntPtr pVarDesc);
     }
     public interface ITypeLib {
         void FindName(string szNameBuf, int lHashVal, ITypeInfo[] ppTInfo, int[] rgMemId, ref short pcFound);
         void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
         void GetLibAttr(out IntPtr ppTLibAttr);
         void GetTypeComp(out ITypeComp ppTComp);
         void GetTypeInfo(int index, out ITypeInfo ppTI);
         int GetTypeInfoCount();
         void GetTypeInfoOfGuid(ref Guid guid, out ITypeInfo ppTInfo);
         void GetTypeInfoType(int index, out TYPEKIND pTKind);
         bool IsName(string szNameBuf, int lHashVal);
         void ReleaseTLibAttr(IntPtr pTLibAttr);
     }
     public interface ITypeLib2 : ITypeLib {
         new void FindName(string szNameBuf, int lHashVal, ITypeInfo[] ppTInfo, int[] rgMemId, ref short pcFound);
         void GetAllCustData(IntPtr pCustData);
         void GetCustData(ref Guid guid, out object pVarVal);
         new void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
         void GetDocumentation2(int index, out string pbstrHelpString, out int pdwHelpStringContext, out string pbstrHelpStringDll);
         new void GetLibAttr(out IntPtr ppTLibAttr);
         void GetLibStatistics(IntPtr pcUniqueNames, out int pcchUniqueNames);
         new void GetTypeComp(out ITypeComp ppTComp);
         new void GetTypeInfo(int index, out ITypeInfo ppTI);
         new int GetTypeInfoCount();
         new void GetTypeInfoOfGuid(ref Guid guid, out ITypeInfo ppTInfo);
         new void GetTypeInfoType(int index, out TYPEKIND pTKind);
         new bool IsName(string szNameBuf, int lHashVal);
         new void ReleaseTLibAttr(IntPtr pTLibAttr);
     }
     public enum LIBFLAGS : short {
         LIBFLAG_FCONTROL = (short)2,
         LIBFLAG_FHASDISKIMAGE = (short)8,
         LIBFLAG_FHIDDEN = (short)4,
         LIBFLAG_FRESTRICTED = (short)1,
     }
     public struct PARAMDESC {
         public IntPtr lpVarValue;
         public PARAMFLAG wParamFlags;
     }
     public enum PARAMFLAG : short {
         PARAMFLAG_FHASCUSTDATA = (short)64,
         PARAMFLAG_FHASDEFAULT = (short)32,
         PARAMFLAG_FIN = (short)1,
         PARAMFLAG_FLCID = (short)4,
         PARAMFLAG_FOPT = (short)16,
         PARAMFLAG_FOUT = (short)2,
         PARAMFLAG_FRETVAL = (short)8,
         PARAMFLAG_NONE = (short)0,
     }
     public struct STATDATA {
         public ADVF advf;
         public IAdviseSink advSink;
         public int connection;
         public FORMATETC formatetc;
     }
     public struct STATSTG {
         public FILETIME atime;
         public long cbSize;
         public Guid clsid;
         public FILETIME ctime;
         public int grfLocksSupported;
         public int grfMode;
         public int grfStateBits;
         public FILETIME mtime;
         public string pwcsName;
         public int reserved;
         public int type;
     }
     public struct STGMEDIUM {
         public object pUnkForRelease;
         public TYMED tymed;
         public IntPtr unionmember;
     }
     public enum SYSKIND {
         SYS_MAC = 2,
         SYS_WIN16 = 0,
         SYS_WIN32 = 1,
         SYS_WIN64 = 3,
     }
     public enum TYMED {
         TYMED_ENHMF = 64,
         TYMED_FILE = 2,
         TYMED_GDI = 16,
         TYMED_HGLOBAL = 1,
         TYMED_ISTORAGE = 8,
         TYMED_ISTREAM = 4,
         TYMED_MFPICT = 32,
         TYMED_NULL = 0,
     }
     public struct TYPEATTR {
         public short cbAlignment;
         public int cbSizeInstance;
         public short cbSizeVft;
         public short cFuncs;
         public short cImplTypes;
         public short cVars;
         public int dwReserved;
         public Guid guid;
         public IDLDESC idldescType;
         public int lcid;
         public IntPtr lpstrSchema;
         public const int MEMBER_ID_NIL = -1;
         public int memidConstructor;
         public int memidDestructor;
         public TYPEDESC tdescAlias;
         public TYPEKIND typekind;
         public short wMajorVerNum;
         public short wMinorVerNum;
         public TYPEFLAGS wTypeFlags;
     }
     public struct TYPEDESC {
         public IntPtr lpValue;
         public short vt;
     }
     public enum TYPEFLAGS : short {
         TYPEFLAG_FAGGREGATABLE = (short)1024,
         TYPEFLAG_FAPPOBJECT = (short)1,
         TYPEFLAG_FCANCREATE = (short)2,
         TYPEFLAG_FCONTROL = (short)32,
         TYPEFLAG_FDISPATCHABLE = (short)4096,
         TYPEFLAG_FDUAL = (short)64,
         TYPEFLAG_FHIDDEN = (short)16,
         TYPEFLAG_FLICENSED = (short)4,
         TYPEFLAG_FNONEXTENSIBLE = (short)128,
         TYPEFLAG_FOLEAUTOMATION = (short)256,
         TYPEFLAG_FPREDECLID = (short)8,
         TYPEFLAG_FPROXY = (short)16384,
         TYPEFLAG_FREPLACEABLE = (short)2048,
         TYPEFLAG_FRESTRICTED = (short)512,
         TYPEFLAG_FREVERSEBIND = (short)8192,
     }
     public enum TYPEKIND {
         TKIND_ALIAS = 6,
         TKIND_COCLASS = 5,
         TKIND_DISPATCH = 4,
         TKIND_ENUM = 0,
         TKIND_INTERFACE = 3,
         TKIND_MAX = 8,
         TKIND_MODULE = 2,
         TKIND_RECORD = 1,
         TKIND_UNION = 7,
     }
     public struct TYPELIBATTR {
         public Guid guid;
         public int lcid;
         public SYSKIND syskind;
         public LIBFLAGS wLibFlags;
         public short wMajorVerNum;
         public short wMinorVerNum;
     }
     public struct VARDESC {
         public struct DESCUNION {
             public IntPtr lpvarValue;
             public int oInst;
         }
         public VARDESC.DESCUNION desc;
         public ELEMDESC elemdescVar;
         public string lpstrSchema;
         public int memid;
         public VARKIND varkind;
         public short wVarFlags;
     }
     public enum VARFLAGS : short {
         VARFLAG_FBINDABLE = (short)4,
         VARFLAG_FDEFAULTBIND = (short)32,
         VARFLAG_FDEFAULTCOLLELEM = (short)256,
         VARFLAG_FDISPLAYBIND = (short)16,
         VARFLAG_FHIDDEN = (short)64,
         VARFLAG_FIMMEDIATEBIND = (short)4096,
         VARFLAG_FNONBROWSABLE = (short)1024,
         VARFLAG_FREADONLY = (short)1,
         VARFLAG_FREPLACEABLE = (short)2048,
         VARFLAG_FREQUESTEDIT = (short)8,
         VARFLAG_FRESTRICTED = (short)128,
         VARFLAG_FSOURCE = (short)2,
         VARFLAG_FUIDEFAULT = (short)512,
     }
     public enum VARKIND {
         VAR_CONST = 2,
         VAR_DISPATCH = 3,
         VAR_PERINSTANCE = 0,
         VAR_STATIC = 1,
     }
 }
 namespace System.Runtime.Versioning {
     public sealed class TargetFrameworkAttribute : Attribute {
         public TargetFrameworkAttribute(string frameworkName);
         public string FrameworkDisplayName { get; set; }
         public string FrameworkName { get; }
     }
 }
 namespace System.Security {
     public sealed class AllowPartiallyTrustedCallersAttribute : Attribute {
         public AllowPartiallyTrustedCallersAttribute();
     }
     public sealed class SecurityCriticalAttribute : Attribute {
         public SecurityCriticalAttribute();
     }
     public class SecurityException : Exception {
         public SecurityException();
         public SecurityException(string message);
         public SecurityException(string message, Exception inner);
         public override string ToString();
     }
     public sealed class SecuritySafeCriticalAttribute : Attribute {
         public SecuritySafeCriticalAttribute();
     }
     public sealed class SecurityTransparentAttribute : Attribute {
         public SecurityTransparentAttribute();
     }
     public class VerificationException : Exception {
         public VerificationException();
         public VerificationException(string message);
         public VerificationException(string message, Exception innerException);
     }
 }
 namespace System.Text {
     public abstract class Decoder {
         protected Decoder();
         public virtual void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed);
         public abstract int GetCharCount(byte[] bytes, int index, int count);
         public virtual int GetCharCount(byte[] bytes, int index, int count, bool flush);
         public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
         public virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush);
         public virtual void Reset();
     }
     public sealed class DecoderFallbackException : ArgumentException {
         public DecoderFallbackException();
         public DecoderFallbackException(string message);
         public DecoderFallbackException(string message, byte[] bytesUnknown, int index);
         public DecoderFallbackException(string message, Exception innerException);
         public byte[] BytesUnknown { get; }
         public int Index { get; }
     }
     public abstract class Encoder {
         protected Encoder();
         public virtual void Convert(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed);
         public abstract int GetByteCount(char[] chars, int index, int count, bool flush);
         public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush);
     }
     public sealed class EncoderFallbackException : ArgumentException {
         public EncoderFallbackException();
         public EncoderFallbackException(string message);
         public EncoderFallbackException(string message, Exception innerException);
         public char CharUnknown { get; }
         public char CharUnknownHigh { get; }
         public char CharUnknownLow { get; }
         public int Index { get; }
     }
     public abstract class Encoding {
         protected Encoding();
         public static Encoding BigEndianUnicode { get; }
         public static Encoding Unicode { get; }
         public static Encoding UTF8 { get; }
         public virtual string WebName { get; }
         public static byte[] Convert(Encoding srcEncoding, Encoding dstEncoding, byte[] bytes);
         public static byte[] Convert(Encoding srcEncoding, Encoding dstEncoding, byte[] bytes, int index, int count);
         public override bool Equals(object value);
         public virtual int GetByteCount(char[] chars);
         public abstract int GetByteCount(char[] chars, int index, int count);
         public virtual int GetByteCount(string s);
         public virtual byte[] GetBytes(char[] chars);
         public virtual byte[] GetBytes(char[] chars, int index, int count);
         public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
         public virtual byte[] GetBytes(string s);
         public virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
         public virtual int GetCharCount(byte[] bytes);
         public abstract int GetCharCount(byte[] bytes, int index, int count);
         public virtual char[] GetChars(byte[] bytes);
         public virtual char[] GetChars(byte[] bytes, int index, int count);
         public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
         public virtual Decoder GetDecoder();
         public virtual Encoder GetEncoder();
         public static Encoding GetEncoding(string name);
         public override int GetHashCode();
         public abstract int GetMaxByteCount(int charCount);
         public abstract int GetMaxCharCount(int byteCount);
         public virtual byte[] GetPreamble();
         public virtual string GetString(byte[] bytes, int index, int count);
     }
     public sealed class StringBuilder {
         public StringBuilder();
         public StringBuilder(int capacity);
         public StringBuilder(int capacity, int maxCapacity);
         public StringBuilder(string value);
         public StringBuilder(string value, int capacity);
         public StringBuilder(string value, int startIndex, int length, int capacity);
         public int Capacity { get; set; }
         public char this[int index] { get; set; }
         public int Length { get; set; }
         public int MaxCapacity { get; }
         public StringBuilder Append(bool value);
         public StringBuilder Append(byte value);
         public StringBuilder Append(char value);
         public StringBuilder Append(char value, int repeatCount);
         public StringBuilder Append(char[] value);
         public StringBuilder Append(char[] value, int startIndex, int charCount);
         public StringBuilder Append(decimal value);
         public StringBuilder Append(double value);
         public StringBuilder Append(short value);
         public StringBuilder Append(int value);
         public StringBuilder Append(long value);
         public StringBuilder Append(object value);
         public StringBuilder Append(sbyte value);
         public StringBuilder Append(float value);
         public StringBuilder Append(string value);
         public StringBuilder Append(string value, int startIndex, int count);
         public StringBuilder Append(ushort value);
         public StringBuilder Append(uint value);
         public StringBuilder Append(ulong value);
         public StringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args);
         public StringBuilder AppendFormat(string format, params object[] args);
         public StringBuilder AppendLine();
         public StringBuilder AppendLine(string value);
         public StringBuilder Clear();
         public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
         public int EnsureCapacity(int capacity);
         public bool Equals(StringBuilder sb);
         public StringBuilder Insert(int index, bool value);
         public StringBuilder Insert(int index, byte value);
         public StringBuilder Insert(int index, char value);
         public StringBuilder Insert(int index, char[] value);
         public StringBuilder Insert(int index, char[] value, int startIndex, int charCount);
         public StringBuilder Insert(int index, decimal value);
         public StringBuilder Insert(int index, double value);
         public StringBuilder Insert(int index, short value);
         public StringBuilder Insert(int index, int value);
         public StringBuilder Insert(int index, long value);
         public StringBuilder Insert(int index, object value);
         public StringBuilder Insert(int index, sbyte value);
         public StringBuilder Insert(int index, float value);
         public StringBuilder Insert(int index, string value);
         public StringBuilder Insert(int index, string value, int count);
         public StringBuilder Insert(int index, ushort value);
         public StringBuilder Insert(int index, uint value);
         public StringBuilder Insert(int index, ulong value);
         public StringBuilder Remove(int startIndex, int length);
         public StringBuilder Replace(char oldChar, char newChar);
         public StringBuilder Replace(char oldChar, char newChar, int startIndex, int count);
         public StringBuilder Replace(string oldValue, string newValue);
         public StringBuilder Replace(string oldValue, string newValue, int startIndex, int count);
         public override string ToString();
         public string ToString(int startIndex, int length);
     }
     public class UnicodeEncoding : Encoding {
         public UnicodeEncoding();
         public UnicodeEncoding(bool bigEndian, bool byteOrderMark);
         public UnicodeEncoding(bool bigEndian, bool byteOrderMark, bool throwOnInvalidBytes);
         public override bool Equals(object value);
         public override int GetByteCount(char[] chars, int index, int count);
         public override int GetByteCount(string s);
         public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
         public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
         public override int GetCharCount(byte[] bytes, int index, int count);
         public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
         public override Decoder GetDecoder();
         public override Encoder GetEncoder();
         public override int GetHashCode();
         public override int GetMaxByteCount(int charCount);
         public override int GetMaxCharCount(int byteCount);
         public override byte[] GetPreamble();
         public override string GetString(byte[] bytes, int index, int count);
     }
     public class UTF8Encoding : Encoding {
         public UTF8Encoding();
         public UTF8Encoding(bool encoderShouldEmitUTF8Identifier);
         public UTF8Encoding(bool encoderShouldEmitUTF8Identifier, bool throwOnInvalidBytes);
         public override bool Equals(object value);
         public override int GetByteCount(char[] chars, int index, int count);
         public override int GetByteCount(string chars);
         public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
         public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
         public override int GetCharCount(byte[] bytes, int index, int count);
         public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
         public override Decoder GetDecoder();
         public override Encoder GetEncoder();
         public override int GetHashCode();
         public override int GetMaxByteCount(int charCount);
         public override int GetMaxCharCount(int byteCount);
         public override byte[] GetPreamble();
         public override string GetString(byte[] bytes, int index, int count);
     }
 }
 namespace System.Text.RegularExpressions {
     public class Capture {
         public int Index { get; }
         public int Length { get; }
         public string Value { get; }
         public override string ToString();
     }
     public class CaptureCollection : ICollection, IEnumerable {
         public int Count { get; }
         public Capture this[int i] { get; }
         public IEnumerator GetEnumerator();
     }
     public class Group : Capture {
         public CaptureCollection Captures { get; }
         public bool Success { get; }
     }
     public class GroupCollection : ICollection, IEnumerable {
         public int Count { get; }
         public Group this[int groupnum] { get; }
         public Group this[string groupname] { get; }
         public IEnumerator GetEnumerator();
     }
     public class Match : Group {
         public static Match Empty { get; }
         public virtual GroupCollection Groups { get; }
         public Match NextMatch();
         public virtual string Result(string replacement);
     }
     public class MatchCollection : ICollection, IEnumerable {
         public int Count { get; }
         public virtual Match this[int i] { get; }
         public IEnumerator GetEnumerator();
     }
     public delegate string MatchEvaluator(Match match); {
         public MatchEvaluator(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(Match match, AsyncCallback callback, object @object);
         public virtual string EndInvoke(IAsyncResult result);
         public virtual string Invoke(Match match);
     }
     public class Regex {
         public static readonly TimeSpan InfiniteMatchTimeout;
         protected Regex();
         public Regex(string pattern);
         public Regex(string pattern, RegexOptions options);
         public Regex(string pattern, RegexOptions options, TimeSpan matchTimeout);
         public TimeSpan MatchTimeout { get; }
         public RegexOptions Options { get; }
         public bool RightToLeft { get; }
         public static string Escape(string str);
         public string[] GetGroupNames();
         public int[] GetGroupNumbers();
         public string GroupNameFromNumber(int i);
         public int GroupNumberFromName(string name);
         public bool IsMatch(string input);
         public bool IsMatch(string input, int startat);
         public static bool IsMatch(string input, string pattern);
         public static bool IsMatch(string input, string pattern, RegexOptions options);
         public static bool IsMatch(string input, string pattern, RegexOptions options, TimeSpan matchTimeout);
         public Match Match(string input);
         public Match Match(string input, int startat);
         public Match Match(string input, int beginning, int length);
         public static Match Match(string input, string pattern);
         public static Match Match(string input, string pattern, RegexOptions options);
         public static Match Match(string input, string pattern, RegexOptions options, TimeSpan matchTimeout);
         public MatchCollection Matches(string input);
         public MatchCollection Matches(string input, int startat);
         public static MatchCollection Matches(string input, string pattern);
         public static MatchCollection Matches(string input, string pattern, RegexOptions options);
         public static MatchCollection Matches(string input, string pattern, RegexOptions options, TimeSpan matchTimeout);
         public string Replace(string input, MatchEvaluator evaluator);
         public string Replace(string input, MatchEvaluator evaluator, int count);
         public string Replace(string input, MatchEvaluator evaluator, int count, int startat);
         public string Replace(string input, string replacement);
         public string Replace(string input, string replacement, int count);
         public string Replace(string input, string replacement, int count, int startat);
         public static string Replace(string input, string pattern, MatchEvaluator evaluator);
         public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options);
         public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options, TimeSpan matchTimeout);
         public static string Replace(string input, string pattern, string replacement);
         public static string Replace(string input, string pattern, string replacement, RegexOptions options);
         public static string Replace(string input, string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout);
         public string[] Split(string input);
         public string[] Split(string input, int count);
         public string[] Split(string input, int count, int startat);
         public static string[] Split(string input, string pattern);
         public static string[] Split(string input, string pattern, RegexOptions options);
         public static string[] Split(string input, string pattern, RegexOptions options, TimeSpan matchTimeout);
         public override string ToString();
         public static string Unescape(string str);
     }
     public class RegexMatchTimeoutException : TimeoutException {
         public RegexMatchTimeoutException();
         public RegexMatchTimeoutException(string message);
         public RegexMatchTimeoutException(string message, Exception inner);
         public RegexMatchTimeoutException(string regexInput, string regexPattern, TimeSpan matchTimeout);
         public string Input { get; }
         public TimeSpan MatchTimeout { get; }
         public string Pattern { get; }
     }
     public enum RegexOptions {
         CultureInvariant = 512,
         ECMAScript = 256,
         ExplicitCapture = 4,
         IgnoreCase = 1,
         IgnorePatternWhitespace = 32,
         Multiline = 2,
         None = 0,
         RightToLeft = 64,
         Singleline = 16,
     }
 }
 namespace System.Threading {
     public class AbandonedMutexException : Exception {
         public AbandonedMutexException();
         public AbandonedMutexException(int location, WaitHandle handle);
         public AbandonedMutexException(string message);
         public AbandonedMutexException(string message, Exception inner);
         public AbandonedMutexException(string message, Exception inner, int location, WaitHandle handle);
         public AbandonedMutexException(string message, int location, WaitHandle handle);
         public Mutex Mutex { get; }
         public int MutexIndex { get; }
     }
     public sealed class AutoResetEvent : EventWaitHandle {
         public AutoResetEvent(bool initialState);
     }
     public class Barrier : IDisposable {
         public Barrier(int participantCount);
         public Barrier(int participantCount, Action<Barrier> postPhaseAction);
         public long CurrentPhaseNumber { get; }
         public int ParticipantCount { get; }
         public int ParticipantsRemaining { get; }
         public long AddParticipant();
         public long AddParticipants(int participantCount);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public void RemoveParticipant();
         public void RemoveParticipants(int participantCount);
         public void SignalAndWait();
         public void SignalAndWait(CancellationToken cancellationToken);
         public bool SignalAndWait(int millisecondsTimeout);
         public bool SignalAndWait(int millisecondsTimeout, CancellationToken cancellationToken);
         public bool SignalAndWait(TimeSpan timeout);
         public bool SignalAndWait(TimeSpan timeout, CancellationToken cancellationToken);
     }
     public class BarrierPostPhaseException : Exception {
         public BarrierPostPhaseException();
         public BarrierPostPhaseException(Exception innerException);
         public BarrierPostPhaseException(string message);
         public BarrierPostPhaseException(string message, Exception innerException);
     }
     public struct CancellationToken {
         public CancellationToken(bool canceled);
         public bool CanBeCanceled { get; }
         public bool IsCancellationRequested { get; }
         public static CancellationToken None { get; }
         public WaitHandle WaitHandle { get; }
         public bool Equals(CancellationToken other);
         public override bool Equals(object other);
         public override int GetHashCode();
         public static bool operator ==(CancellationToken left, CancellationToken right);
         public static bool operator !=(CancellationToken left, CancellationToken right);
         public CancellationTokenRegistration Register(Action<object> callback, object state);
         public CancellationTokenRegistration Register(Action<object> callback, object state, bool useSynchronizationContext);
         public CancellationTokenRegistration Register(Action callback);
         public CancellationTokenRegistration Register(Action callback, bool useSynchronizationContext);
         public void ThrowIfCancellationRequested();
     }
     public struct CancellationTokenRegistration : IDisposable, IEquatable<CancellationTokenRegistration> {
         public void Dispose();
         public bool Equals(CancellationTokenRegistration other);
         public override bool Equals(object obj);
         public override int GetHashCode();
         public static bool operator ==(CancellationTokenRegistration left, CancellationTokenRegistration right);
         public static bool operator !=(CancellationTokenRegistration left, CancellationTokenRegistration right);
     }
     public class CancellationTokenSource : IDisposable {
         public CancellationTokenSource();
         public CancellationTokenSource(int millisecondsDelay);
         public CancellationTokenSource(TimeSpan delay);
         public bool IsCancellationRequested { get; }
         public CancellationToken Token { get; }
         public void Cancel();
         public void Cancel(bool throwOnFirstException);
         public void CancelAfter(int millisecondsDelay);
         public void CancelAfter(TimeSpan delay);
         public static CancellationTokenSource CreateLinkedTokenSource(CancellationToken token1, CancellationToken token2);
         public static CancellationTokenSource CreateLinkedTokenSource(params CancellationToken[] tokens);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
     }
     public class CountdownEvent : IDisposable {
         public CountdownEvent(int initialCount);
         public int CurrentCount { get; }
         public int InitialCount { get; }
         public bool IsSet { get; }
         public WaitHandle WaitHandle { get; }
         public void AddCount();
         public void AddCount(int signalCount);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public void Reset();
         public void Reset(int count);
         public bool Signal();
         public bool Signal(int signalCount);
         public bool TryAddCount();
         public bool TryAddCount(int signalCount);
         public void Wait();
         public void Wait(CancellationToken cancellationToken);
         public bool Wait(int millisecondsTimeout);
         public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
         public bool Wait(TimeSpan timeout);
         public bool Wait(TimeSpan timeout, CancellationToken cancellationToken);
     }
     public enum EventResetMode {
         AutoReset = 0,
         ManualReset = 1,
     }
     public class EventWaitHandle : WaitHandle {
         public EventWaitHandle(bool initialState, EventResetMode mode);
         public EventWaitHandle(bool initialState, EventResetMode mode, string name);
         public EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew);
         public static EventWaitHandle OpenExisting(string name);
         public bool Reset();
         public bool Set();
         public static bool TryOpenExisting(string name, out EventWaitHandle result);
     }
     public static class Interlocked {
         public static int Add(ref int location1, int value);
         public static long Add(ref long location1, long value);
         public static T CompareExchange<T>(ref T location1, T value, T comparand) where T : class;
         public static double CompareExchange(ref double location1, double value, double comparand);
         public static int CompareExchange(ref int location1, int value, int comparand);
         public static long CompareExchange(ref long location1, long value, long comparand);
         public static IntPtr CompareExchange(ref IntPtr location1, IntPtr value, IntPtr comparand);
         public static object CompareExchange(ref object location1, object value, object comparand);
         public static float CompareExchange(ref float location1, float value, float comparand);
         public static int Decrement(ref int location);
         public static long Decrement(ref long location);
         public static T Exchange<T>(ref T location1, T value) where T : class;
         public static double Exchange(ref double location1, double value);
         public static int Exchange(ref int location1, int value);
         public static long Exchange(ref long location1, long value);
         public static IntPtr Exchange(ref IntPtr location1, IntPtr value);
         public static object Exchange(ref object location1, object value);
         public static float Exchange(ref float location1, float value);
         public static int Increment(ref int location);
         public static long Increment(ref long location);
         public static void MemoryBarrier();
         public static long Read(ref long location);
     }
     public static class LazyInitializer {
         public static T EnsureInitialized<T>(ref T target) where T : class;
         public static T EnsureInitialized<T>(ref T target, Func<T> valueFactory) where T : class;
         public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock);
         public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory);
     }
     public enum LazyThreadSafetyMode {
         ExecutionAndPublication = 2,
         None = 0,
         PublicationOnly = 1,
     }
     public class LockRecursionException : Exception {
         public LockRecursionException();
         public LockRecursionException(string message);
         public LockRecursionException(string message, Exception innerException);
     }
     public enum LockRecursionPolicy {
         NoRecursion = 0,
         SupportsRecursion = 1,
     }
     public sealed class ManualResetEvent : EventWaitHandle {
         public ManualResetEvent(bool initialState);
     }
     public class ManualResetEventSlim : IDisposable {
         public ManualResetEventSlim();
         public ManualResetEventSlim(bool initialState);
         public ManualResetEventSlim(bool initialState, int spinCount);
         public bool IsSet { get; }
         public int SpinCount { get; }
         public WaitHandle WaitHandle { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public void Reset();
         public void Set();
         public void Wait();
         public void Wait(CancellationToken cancellationToken);
         public bool Wait(int millisecondsTimeout);
         public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
         public bool Wait(TimeSpan timeout);
         public bool Wait(TimeSpan timeout, CancellationToken cancellationToken);
     }
     public static class Monitor {
         public static void Enter(object obj);
         public static void Enter(object obj, ref bool lockTaken);
         public static void Exit(object obj);
         public static bool IsEntered(object obj);
         public static void Pulse(object obj);
         public static void PulseAll(object obj);
         public static bool TryEnter(object obj);
         public static void TryEnter(object obj, ref bool lockTaken);
         public static bool TryEnter(object obj, int millisecondsTimeout);
         public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken);
         public static bool TryEnter(object obj, TimeSpan timeout);
         public static void TryEnter(object obj, TimeSpan timeout, ref bool lockTaken);
         public static bool Wait(object obj);
         public static bool Wait(object obj, int millisecondsTimeout);
         public static bool Wait(object obj, TimeSpan timeout);
     }
     public sealed class Mutex : WaitHandle {
         public Mutex();
         public Mutex(bool initiallyOwned);
         public Mutex(bool initiallyOwned, string name);
         public Mutex(bool initiallyOwned, string name, out bool createdNew);
         public static Mutex OpenExisting(string name);
         public void ReleaseMutex();
         public static bool TryOpenExisting(string name, out Mutex result);
     }
     public class ReaderWriterLockSlim : IDisposable {
         public ReaderWriterLockSlim();
         public ReaderWriterLockSlim(LockRecursionPolicy recursionPolicy);
         public int CurrentReadCount { get; }
         public bool IsReadLockHeld { get; }
         public bool IsUpgradeableReadLockHeld { get; }
         public bool IsWriteLockHeld { get; }
         public LockRecursionPolicy RecursionPolicy { get; }
         public int RecursiveReadCount { get; }
         public int RecursiveUpgradeCount { get; }
         public int RecursiveWriteCount { get; }
         public int WaitingReadCount { get; }
         public int WaitingUpgradeCount { get; }
         public int WaitingWriteCount { get; }
         public void Dispose();
         public void EnterReadLock();
         public void EnterUpgradeableReadLock();
         public void EnterWriteLock();
         public void ExitReadLock();
         public void ExitUpgradeableReadLock();
         public void ExitWriteLock();
         public bool TryEnterReadLock(int millisecondsTimeout);
         public bool TryEnterReadLock(TimeSpan timeout);
         public bool TryEnterUpgradeableReadLock(int millisecondsTimeout);
         public bool TryEnterUpgradeableReadLock(TimeSpan timeout);
         public bool TryEnterWriteLock(int millisecondsTimeout);
         public bool TryEnterWriteLock(TimeSpan timeout);
     }
     public sealed class Semaphore : WaitHandle {
         public Semaphore(int initialCount, int maximumCount);
         public Semaphore(int initialCount, int maximumCount, string name);
         public Semaphore(int initialCount, int maximumCount, string name, out bool createdNew);
         public static Semaphore OpenExisting(string name);
         public int Release();
         public int Release(int releaseCount);
         public static bool TryOpenExisting(string name, out Semaphore result);
     }
     public class SemaphoreFullException : Exception {
         public SemaphoreFullException();
         public SemaphoreFullException(string message);
         public SemaphoreFullException(string message, Exception innerException);
     }
     public class SemaphoreSlim : IDisposable {
         public SemaphoreSlim(int initialCount);
         public SemaphoreSlim(int initialCount, int maxCount);
         public WaitHandle AvailableWaitHandle { get; }
         public int CurrentCount { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public int Release();
         public int Release(int releaseCount);
         public void Wait();
         public void Wait(CancellationToken cancellationToken);
         public bool Wait(int millisecondsTimeout);
         public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
         public bool Wait(TimeSpan timeout);
         public bool Wait(TimeSpan timeout, CancellationToken cancellationToken);
         public Task WaitAsync();
         public Task WaitAsync(CancellationToken cancellationToken);
         public Task<bool> WaitAsync(int millisecondsTimeout);
         public Task<bool> WaitAsync(int millisecondsTimeout, CancellationToken cancellationToken);
         public Task<bool> WaitAsync(TimeSpan timeout);
         public Task<bool> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken);
     }
     public delegate void SendOrPostCallback(object state); {
         public SendOrPostCallback(object @object, IntPtr method);
         public virtual IAsyncResult BeginInvoke(object state, AsyncCallback callback, object @object);
         public virtual void EndInvoke(IAsyncResult result);
         public virtual void Invoke(object state);
     }
     public struct SpinLock {
         public SpinLock(bool enableThreadOwnerTracking);
         public bool IsHeld { get; }
         public bool IsHeldByCurrentThread { get; }
         public bool IsThreadOwnerTrackingEnabled { get; }
         public void Enter(ref bool lockTaken);
         public void Exit();
         public void Exit(bool useMemoryBarrier);
         public void TryEnter(ref bool lockTaken);
         public void TryEnter(int millisecondsTimeout, ref bool lockTaken);
         public void TryEnter(TimeSpan timeout, ref bool lockTaken);
     }
     public struct SpinWait {
         public int Count { get; }
         public bool NextSpinWillYield { get; }
         public void Reset();
         public void SpinOnce();
         public static void SpinUntil(Func<bool> condition);
         public static bool SpinUntil(Func<bool> condition, int millisecondsTimeout);
         public static bool SpinUntil(Func<bool> condition, TimeSpan timeout);
     }
     public class SynchronizationContext {
         public SynchronizationContext();
         public static SynchronizationContext Current { get; }
         public virtual SynchronizationContext CreateCopy();
         public virtual void OperationCompleted();
         public virtual void OperationStarted();
         public virtual void Post(SendOrPostCallback d, object state);
         public virtual void Send(SendOrPostCallback d, object state);
         public static void SetSynchronizationContext(SynchronizationContext syncContext);
     }
     public class SynchronizationLockException : Exception {
         public SynchronizationLockException();
         public SynchronizationLockException(string message);
         public SynchronizationLockException(string message, Exception innerException);
     }
     public class ThreadLocal<T> : IDisposable {
         public ThreadLocal();
         public ThreadLocal(bool trackAllValues);
         public ThreadLocal(Func<T> valueFactory);
         public ThreadLocal(Func<T> valueFactory, bool trackAllValues);
         public bool IsValueCreated { get; }
         public T Value { get; set; }
         public IList<T> Values { get; }
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         ~ThreadLocal();
         public override string ToString();
     }
     public static class Timeout {
         public const int Infinite = -1;
         public static readonly TimeSpan InfiniteTimeSpan;
     }
     public static class Volatile {
         public static T Read<T>(ref T location) where T : class;
         public static bool Read(ref bool location);
         public static byte Read(ref byte location);
         public static double Read(ref double location);
         public static short Read(ref short location);
         public static int Read(ref int location);
         public static long Read(ref long location);
         public static IntPtr Read(ref IntPtr location);
         public static sbyte Read(ref sbyte location);
         public static float Read(ref float location);
         public static ushort Read(ref ushort location);
         public static uint Read(ref uint location);
         public static ulong Read(ref ulong location);
         public static UIntPtr Read(ref UIntPtr location);
         public static void Write<T>(ref T location, T value) where T : class;
         public static void Write(ref bool location, bool value);
         public static void Write(ref byte location, byte value);
         public static void Write(ref double location, double value);
         public static void Write(ref short location, short value);
         public static void Write(ref int location, int value);
         public static void Write(ref long location, long value);
         public static void Write(ref IntPtr location, IntPtr value);
         public static void Write(ref sbyte location, sbyte value);
         public static void Write(ref float location, float value);
         public static void Write(ref ushort location, ushort value);
         public static void Write(ref uint location, uint value);
         public static void Write(ref ulong location, ulong value);
         public static void Write(ref UIntPtr location, UIntPtr value);
     }
     public abstract class WaitHandle : IDisposable {
         protected static readonly IntPtr InvalidHandle;
         public const int WaitTimeout = 258;
         protected WaitHandle();
         public void Dispose();
         protected virtual void Dispose(bool explicitDisposing);
         public static bool WaitAll(WaitHandle[] waitHandles);
         public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout);
         public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout);
         public static int WaitAny(WaitHandle[] waitHandles);
         public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout);
         public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout);
         public virtual bool WaitOne();
         public virtual bool WaitOne(int millisecondsTimeout);
         public virtual bool WaitOne(TimeSpan timeout);
     }
     public class WaitHandleCannotBeOpenedException : Exception {
         public WaitHandleCannotBeOpenedException();
         public WaitHandleCannotBeOpenedException(string message);
         public WaitHandleCannotBeOpenedException(string message, Exception innerException);
     }
 }
 namespace System.Threading.Tasks {
     public class ConcurrentExclusiveSchedulerPair {
         public ConcurrentExclusiveSchedulerPair();
         public ConcurrentExclusiveSchedulerPair(TaskScheduler taskScheduler);
         public ConcurrentExclusiveSchedulerPair(TaskScheduler taskScheduler, int maxConcurrencyLevel);
         public ConcurrentExclusiveSchedulerPair(TaskScheduler taskScheduler, int maxConcurrencyLevel, int maxItemsPerTask);
         public Task Completion { get; }
         public TaskScheduler ConcurrentScheduler { get; }
         public TaskScheduler ExclusiveScheduler { get; }
         public void Complete();
     }
     public class Task : IAsyncResult {
         public Task(Action<object> action, object state);
         public Task(Action<object> action, object state, CancellationToken cancellationToken);
         public Task(Action<object> action, object state, TaskCreationOptions creationOptions);
         public Task(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
         public Task(Action action);
         public Task(Action action, CancellationToken cancellationToken);
         public Task(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
         public Task(Action action, TaskCreationOptions creationOptions);
         public object AsyncState { get; }
         public TaskCreationOptions CreationOptions { get; }
         public static Nullable<int> CurrentId { get; }
         public AggregateException Exception { get; }
         public static TaskFactory Factory { get; }
         public int Id { get; }
         public bool IsCanceled { get; }
         public bool IsCompleted { get; }
         public bool IsFaulted { get; }
         public TaskStatus Status { get; }
         public ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext);
         public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction);
         public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, TaskScheduler scheduler);
         public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state);
         public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, TaskScheduler scheduler);
         public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, CancellationToken cancellationToken);
         public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task> continuationAction);
         public Task ContinueWith(Action<Task> continuationAction, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task, object> continuationAction, object state);
         public Task ContinueWith(Action<Task> continuationAction, CancellationToken cancellationToken);
         public Task ContinueWith(Action<Task> continuationAction, TaskContinuationOptions continuationOptions);
         public Task ContinueWith(Action<Task, object> continuationAction, object state, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task, object> continuationAction, object state, CancellationToken cancellationToken);
         public Task ContinueWith(Action<Task, object> continuationAction, object state, TaskContinuationOptions continuationOptions);
         public Task ContinueWith(Action<Task> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public static Task Delay(int millisecondsDelay);
         public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken);
         public static Task Delay(TimeSpan delay);
         public static Task Delay(TimeSpan delay, CancellationToken cancellationToken);
         public static Task<TResult> FromResult<TResult>(TResult result);
         public TaskAwaiter GetAwaiter();
         public static Task<TResult> Run<TResult>(Func<TResult> function);
         public static Task<TResult> Run<TResult>(Func<Task<TResult>> function);
         public static Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken);
         public static Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken);
         public static Task Run(Action action);
         public static Task Run(Action action, CancellationToken cancellationToken);
         public static Task Run(Func<Task> function);
         public static Task Run(Func<Task> function, CancellationToken cancellationToken);
         public void RunSynchronously();
         public void RunSynchronously(TaskScheduler scheduler);
         public void Start();
         public void Start(TaskScheduler scheduler);
         public void Wait();
         public void Wait(CancellationToken cancellationToken);
         public bool Wait(int millisecondsTimeout);
         public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
         public bool Wait(TimeSpan timeout);
         public static void WaitAll(params Task[] tasks);
         public static void WaitAll(Task[] tasks, CancellationToken cancellationToken);
         public static bool WaitAll(Task[] tasks, int millisecondsTimeout);
         public static bool WaitAll(Task[] tasks, int millisecondsTimeout, CancellationToken cancellationToken);
         public static bool WaitAll(Task[] tasks, TimeSpan timeout);
         public static int WaitAny(params Task[] tasks);
         public static int WaitAny(Task[] tasks, CancellationToken cancellationToken);
         public static int WaitAny(Task[] tasks, int millisecondsTimeout);
         public static int WaitAny(Task[] tasks, int millisecondsTimeout, CancellationToken cancellationToken);
         public static int WaitAny(Task[] tasks, TimeSpan timeout);
         public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);
         public static Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks);
         public static Task WhenAll(IEnumerable<Task> tasks);
         public static Task WhenAll(params Task[] tasks);
         public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);
         public static Task<Task<TResult>> WhenAny<TResult>(IEnumerable<Task<TResult>> tasks);
         public static Task<Task> WhenAny(IEnumerable<Task> tasks);
         public static Task<Task> WhenAny(params Task[] tasks);
         public static YieldAwaitable Yield();
     }
     public class Task<TResult> : Task {
         public Task(Func<TResult> function);
         public Task(Func<object, TResult> function, object state);
         public Task(Func<TResult> function, CancellationToken cancellationToken);
         public Task(Func<TResult> function, TaskCreationOptions creationOptions);
         public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken);
         public Task(Func<object, TResult> function, object state, TaskCreationOptions creationOptions);
         public Task(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
         public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
         public static new TaskFactory<TResult> Factory { get; }
         public TResult Result { get; }
         public new ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task<TResult>> continuationAction);
         public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state);
         public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken);
         public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskContinuationOptions continuationOptions);
         public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken);
         public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskContinuationOptions continuationOptions);
         public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public new TaskAwaiter<TResult> GetAwaiter();
     }
     public class TaskCanceledException : OperationCanceledException {
         public TaskCanceledException();
         public TaskCanceledException(string message);
         public TaskCanceledException(string message, Exception innerException);
         public TaskCanceledException(Task task);
         public Task Task { get; }
     }
     public class TaskCompletionSource<TResult> {
         public TaskCompletionSource();
         public TaskCompletionSource(object state);
         public TaskCompletionSource(object state, TaskCreationOptions creationOptions);
         public TaskCompletionSource(TaskCreationOptions creationOptions);
         public Task<TResult> Task { get; }
         public void SetCanceled();
         public void SetException(Exception exception);
         public void SetException(IEnumerable<Exception> exceptions);
         public void SetResult(TResult result);
         public bool TrySetCanceled();
         public bool TrySetException(Exception exception);
         public bool TrySetException(IEnumerable<Exception> exceptions);
         public bool TrySetResult(TResult result);
     }
     public enum TaskContinuationOptions {
         AttachedToParent = 4,
         DenyChildAttach = 8,
         ExecuteSynchronously = 524288,
         HideScheduler = 16,
         LazyCancellation = 32,
         LongRunning = 2,
         None = 0,
         NotOnCanceled = 262144,
         NotOnFaulted = 131072,
         NotOnRanToCompletion = 65536,
         OnlyOnCanceled = 196608,
         OnlyOnFaulted = 327680,
         OnlyOnRanToCompletion = 393216,
         PreferFairness = 1,
     }
     public enum TaskCreationOptions {
         AttachedToParent = 4,
         DenyChildAttach = 8,
         HideScheduler = 16,
         LongRunning = 2,
         None = 0,
         PreferFairness = 1,
     }
     public static class TaskExtensions {
         public static Task<TResult> Unwrap<TResult>(this Task<Task<TResult>> task);
         public static Task Unwrap(this Task<Task> task);
     }
     public class TaskFactory {
         public TaskFactory();
         public TaskFactory(CancellationToken cancellationToken);
         public TaskFactory(CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions);
         public TaskFactory(TaskScheduler scheduler);
         public CancellationToken CancellationToken { get; }
         public TaskContinuationOptions ContinuationOptions { get; }
         public TaskCreationOptions CreationOptions { get; }
         public TaskScheduler Scheduler { get; }
         public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction);
         public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction);
         public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction);
         public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction, CancellationToken cancellationToken);
         public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction);
         public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction, CancellationToken cancellationToken);
         public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction, TaskContinuationOptions continuationOptions);
         public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction);
         public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction);
         public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction);
         public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction, CancellationToken cancellationToken);
         public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction);
         public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction, CancellationToken cancellationToken);
         public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction, TaskContinuationOptions continuationOptions);
         public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod);
         public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task<TResult> FromAsync<TResult>(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state);
         public Task FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state);
         public Task<TResult> FromAsync<TResult>(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TArg1, TResult>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state);
         public Task FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);
         public Task FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state);
         public Task<TResult> FromAsync<TArg1, TResult>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TArg1, TArg2, TResult>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state);
         public Task FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);
         public Task FromAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);
         public Task<TResult> FromAsync<TArg1, TArg2, TResult>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);
         public Task FromAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);
         public Task FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, object state);
         public Task FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, object state, TaskCreationOptions creationOptions);
         public Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod);
         public Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions);
         public Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task<TResult> StartNew<TResult>(Func<TResult> function);
         public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state);
         public Task<TResult> StartNew<TResult>(Func<TResult> function, CancellationToken cancellationToken);
         public Task<TResult> StartNew<TResult>(Func<TResult> function, TaskCreationOptions creationOptions);
         public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, CancellationToken cancellationToken);
         public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, TaskCreationOptions creationOptions);
         public Task<TResult> StartNew<TResult>(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task StartNew(Action<object> action, object state);
         public Task StartNew(Action<object> action, object state, CancellationToken cancellationToken);
         public Task StartNew(Action<object> action, object state, TaskCreationOptions creationOptions);
         public Task StartNew(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task StartNew(Action action);
         public Task StartNew(Action action, CancellationToken cancellationToken);
         public Task StartNew(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task StartNew(Action action, TaskCreationOptions creationOptions);
     }
     public class TaskFactory<TResult> {
         public TaskFactory();
         public TaskFactory(CancellationToken cancellationToken);
         public TaskFactory(CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions);
         public TaskFactory(TaskScheduler scheduler);
         public CancellationToken CancellationToken { get; }
         public TaskContinuationOptions ContinuationOptions { get; }
         public TaskCreationOptions CreationOptions { get; }
         public TaskScheduler Scheduler { get; }
         public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction);
         public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWhenAll(Task[] tasks, Func<Task[], TResult> continuationFunction);
         public Task<TResult> ContinueWhenAll(Task[] tasks, Func<Task[], TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAll(Task[] tasks, Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWhenAll(Task[] tasks, Func<Task[], TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction);
         public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> ContinueWhenAny(Task[] tasks, Func<Task, TResult> continuationFunction);
         public Task<TResult> ContinueWhenAny(Task[] tasks, Func<Task, TResult> continuationFunction, CancellationToken cancellationToken);
         public Task<TResult> ContinueWhenAny(Task[] tasks, Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);
         public Task<TResult> ContinueWhenAny(Task[] tasks, Func<Task, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
         public Task<TResult> FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state);
         public Task<TResult> FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state);
         public Task<TResult> FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);
         public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state);
         public Task<TResult> FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod);
         public Task<TResult> FromAsync(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions);
         public Task<TResult> FromAsync(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task<TResult> StartNew(Func<TResult> function);
         public Task<TResult> StartNew(Func<object, TResult> function, object state);
         public Task<TResult> StartNew(Func<TResult> function, CancellationToken cancellationToken);
         public Task<TResult> StartNew(Func<TResult> function, TaskCreationOptions creationOptions);
         public Task<TResult> StartNew(Func<object, TResult> function, object state, CancellationToken cancellationToken);
         public Task<TResult> StartNew(Func<object, TResult> function, object state, TaskCreationOptions creationOptions);
         public Task<TResult> StartNew(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
         public Task<TResult> StartNew(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
     }
     public abstract class TaskScheduler {
         protected TaskScheduler();
         public static TaskScheduler Current { get; }
         public static TaskScheduler Default { get; }
         public int Id { get; }
         public virtual int MaximumConcurrencyLevel { get; }
         public static TaskScheduler FromCurrentSynchronizationContext();
         protected abstract IEnumerable<Task> GetScheduledTasks();
         protected internal abstract void QueueTask(Task task);
         protected internal virtual bool TryDequeue(Task task);
         protected bool TryExecuteTask(Task task);
         protected abstract bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued);
         public static event EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException;
     }
     public class TaskSchedulerException : Exception {
         public TaskSchedulerException();
         public TaskSchedulerException(Exception innerException);
         public TaskSchedulerException(string message);
         public TaskSchedulerException(string message, Exception innerException);
     }
     public enum TaskStatus {
         Canceled = 6,
         Created = 0,
         Faulted = 7,
         RanToCompletion = 5,
         Running = 3,
         WaitingForActivation = 1,
         WaitingForChildrenToComplete = 4,
         WaitingToRun = 2,
     }
     public class UnobservedTaskExceptionEventArgs : EventArgs {
         public UnobservedTaskExceptionEventArgs(AggregateException exception);
         public AggregateException Exception { get; }
         public bool Observed { get; }
         public void SetObserved();
     }
 }
 namespace System.Windows.Input {
     public interface ICommand {
         bool CanExecute(object parameter);
         void Execute(object parameter);
         event EventHandler CanExecuteChanged;
     }
 }
 namespace System.Xml {
     public enum ConformanceLevel {
         Auto = 0,
         Document = 2,
         Fragment = 1,
     }
     public enum DtdProcessing {
         Ignore = 1,
         Prohibit = 0,
     }
     public interface IXmlLineInfo {
         int LineNumber { get; }
         int LinePosition { get; }
         bool HasLineInfo();
     }
     public interface IXmlNamespaceResolver {
         IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope);
         string LookupNamespace(string prefix);
         string LookupPrefix(string namespaceName);
     }
     public enum NamespaceHandling {
         Default = 0,
         OmitDuplicates = 1,
     }
     public class NameTable : XmlNameTable {
         public NameTable();
         public override string Add(char[] key, int start, int len);
         public override string Add(string key);
         public override string Get(char[] key, int start, int len);
         public override string Get(string value);
     }
     public enum NewLineHandling {
         Entitize = 1,
         None = 2,
         Replace = 0,
     }
     public enum ReadState {
         Closed = 4,
         EndOfFile = 3,
         Error = 2,
         Initial = 0,
         Interactive = 1,
     }
     public enum WriteState {
         Attribute = 3,
         Closed = 5,
         Content = 4,
         Element = 2,
         Error = 6,
         Prolog = 1,
         Start = 0,
     }
     public static class XmlConvert {
         public static string DecodeName(string name);
         public static string EncodeLocalName(string name);
         public static string EncodeName(string name);
         public static string EncodeNmToken(string name);
         public static bool ToBoolean(string s);
         public static byte ToByte(string s);
         public static char ToChar(string s);
         public static DateTimeOffset ToDateTimeOffset(string s);
         public static DateTimeOffset ToDateTimeOffset(string s, string format);
         public static DateTimeOffset ToDateTimeOffset(string s, string[] formats);
         public static decimal ToDecimal(string s);
         public static double ToDouble(string s);
         public static Guid ToGuid(string s);
         public static short ToInt16(string s);
         public static int ToInt32(string s);
         public static long ToInt64(string s);
         public static sbyte ToSByte(string s);
         public static float ToSingle(string s);
         public static string ToString(bool value);
         public static string ToString(char value);
         public static string ToString(DateTimeOffset value);
         public static string ToString(DateTimeOffset value, string format);
         public static string ToString(decimal value);
         public static string ToString(double value);
         public static string ToString(Guid value);
         public static string ToString(short value);
         public static string ToString(int value);
         public static string ToString(long value);
         public static string ToString(sbyte value);
         public static string ToString(float value);
         public static string ToString(TimeSpan value);
         public static string ToString(uint value);
         public static string ToString(ulong value);
         public static TimeSpan ToTimeSpan(string s);
         public static ushort ToUInt16(string s);
         public static uint ToUInt32(string s);
         public static ulong ToUInt64(string s);
         public static string VerifyName(string name);
         public static string VerifyNCName(string name);
         public static string VerifyNMTOKEN(string name);
         public static string VerifyPublicId(string publicId);
         public static string VerifyWhitespace(string content);
         public static string VerifyXmlChars(string content);
     }
     public class XmlException : Exception {
         public XmlException();
         public XmlException(string message);
         public XmlException(string message, Exception innerException);
         public XmlException(string message, Exception innerException, int lineNumber, int linePosition);
         public int LineNumber { get; }
         public int LinePosition { get; }
         public override string Message { get; }
     }
     public class XmlNamespaceManager : IEnumerable, IXmlNamespaceResolver {
         public XmlNamespaceManager(XmlNameTable nameTable);
         public virtual string DefaultNamespace { get; }
         public virtual XmlNameTable NameTable { get; }
         public virtual void AddNamespace(string prefix, string uri);
         public virtual IEnumerator GetEnumerator();
         public virtual IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope);
         public virtual bool HasNamespace(string prefix);
         public virtual string LookupNamespace(string prefix);
         public virtual string LookupPrefix(string uri);
         public virtual bool PopScope();
         public virtual void PushScope();
         public virtual void RemoveNamespace(string prefix, string uri);
     }
     public enum XmlNamespaceScope {
         All = 0,
         ExcludeXml = 1,
         Local = 2,
     }
     public abstract class XmlNameTable {
         protected XmlNameTable();
         public abstract string Add(char[] array, int offset, int length);
         public abstract string Add(string array);
         public abstract string Get(char[] array, int offset, int length);
         public abstract string Get(string array);
     }
     public enum XmlNodeType {
         Attribute = 2,
         CDATA = 4,
         Comment = 8,
         Document = 9,
         DocumentFragment = 11,
         DocumentType = 10,
         Element = 1,
         EndElement = 15,
         EndEntity = 16,
         Entity = 6,
         EntityReference = 5,
         None = 0,
         Notation = 12,
         ProcessingInstruction = 7,
         SignificantWhitespace = 14,
         Text = 3,
         Whitespace = 13,
         XmlDeclaration = 17,
     }
     public class XmlParserContext {
         public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace);
         public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace, Encoding enc);
         public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string xmlLang, XmlSpace xmlSpace);
         public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string xmlLang, XmlSpace xmlSpace, Encoding enc);
         public string BaseURI { get; set; }
         public string DocTypeName { get; set; }
         public Encoding Encoding { get; set; }
         public string InternalSubset { get; set; }
         public XmlNamespaceManager NamespaceManager { get; set; }
         public XmlNameTable NameTable { get; set; }
         public string PublicId { get; set; }
         public string SystemId { get; set; }
         public string XmlLang { get; set; }
         public XmlSpace XmlSpace { get; set; }
     }
     public class XmlQualifiedName {
         public static readonly XmlQualifiedName Empty;
         public XmlQualifiedName();
         public XmlQualifiedName(string name);
         public XmlQualifiedName(string name, string ns);
         public bool IsEmpty { get; }
         public string Name { get; }
         public string Namespace { get; }
         public override bool Equals(object other);
         public override int GetHashCode();
         public static bool operator ==(XmlQualifiedName a, XmlQualifiedName b);
         public static bool operator !=(XmlQualifiedName a, XmlQualifiedName b);
         public override string ToString();
         public static string ToString(string name, string ns);
     }
     public abstract class XmlReader : IDisposable {
         protected XmlReader();
         public abstract int AttributeCount { get; }
         public abstract string BaseURI { get; }
         public virtual bool CanReadBinaryContent { get; }
         public virtual bool CanReadValueChunk { get; }
         public virtual bool CanResolveEntity { get; }
         public abstract int Depth { get; }
         public abstract bool EOF { get; }
         public virtual bool HasAttributes { get; }
         public virtual bool HasValue { get; }
         public virtual bool IsDefault { get; }
         public abstract bool IsEmptyElement { get; }
         public virtual string this[int i] { get; }
         public virtual string this[string name, string namespaceURI] { get; }
         public virtual string this[string name] { get; }
         public abstract string LocalName { get; }
         public virtual string Name { get; }
         public abstract string NamespaceURI { get; }
         public abstract XmlNameTable NameTable { get; }
         public abstract XmlNodeType NodeType { get; }
         public abstract string Prefix { get; }
         public abstract ReadState ReadState { get; }
         public virtual XmlReaderSettings Settings { get; }
         public abstract string Value { get; }
         public virtual Type ValueType { get; }
         public virtual string XmlLang { get; }
         public virtual XmlSpace XmlSpace { get; }
         public static XmlReader Create(Stream input);
         public static XmlReader Create(Stream input, XmlReaderSettings settings);
         public static XmlReader Create(Stream input, XmlReaderSettings settings, XmlParserContext inputContext);
         public static XmlReader Create(string inputUri);
         public static XmlReader Create(string inputUri, XmlReaderSettings settings);
         public static XmlReader Create(TextReader input);
         public static XmlReader Create(TextReader input, XmlReaderSettings settings);
         public static XmlReader Create(TextReader input, XmlReaderSettings settings, XmlParserContext inputContext);
         public static XmlReader Create(XmlReader reader, XmlReaderSettings settings);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public abstract string GetAttribute(int i);
         public abstract string GetAttribute(string name);
         public abstract string GetAttribute(string name, string namespaceURI);
         public virtual Task<string> GetValueAsync();
         public static bool IsName(string str);
         public static bool IsNameToken(string str);
         public virtual bool IsStartElement();
         public virtual bool IsStartElement(string name);
         public virtual bool IsStartElement(string localname, string ns);
         public abstract string LookupNamespace(string prefix);
         public virtual void MoveToAttribute(int i);
         public abstract bool MoveToAttribute(string name);
         public abstract bool MoveToAttribute(string name, string ns);
         public virtual XmlNodeType MoveToContent();
         public virtual Task<XmlNodeType> MoveToContentAsync();
         public abstract bool MoveToElement();
         public abstract bool MoveToFirstAttribute();
         public abstract bool MoveToNextAttribute();
         public abstract bool Read();
         public virtual Task<bool> ReadAsync();
         public abstract bool ReadAttributeValue();
         public virtual object ReadContentAs(Type returnType, IXmlNamespaceResolver namespaceResolver);
         public virtual Task<object> ReadContentAsAsync(Type returnType, IXmlNamespaceResolver namespaceResolver);
         public virtual int ReadContentAsBase64(byte[] buffer, int index, int count);
         public virtual Task<int> ReadContentAsBase64Async(byte[] buffer, int index, int count);
         public virtual int ReadContentAsBinHex(byte[] buffer, int index, int count);
         public virtual Task<int> ReadContentAsBinHexAsync(byte[] buffer, int index, int count);
         public virtual bool ReadContentAsBoolean();
         public virtual DateTimeOffset ReadContentAsDateTimeOffset();
         public virtual decimal ReadContentAsDecimal();
         public virtual double ReadContentAsDouble();
         public virtual float ReadContentAsFloat();
         public virtual int ReadContentAsInt();
         public virtual long ReadContentAsLong();
         public virtual object ReadContentAsObject();
         public virtual Task<object> ReadContentAsObjectAsync();
         public virtual string ReadContentAsString();
         public virtual Task<string> ReadContentAsStringAsync();
         public virtual object ReadElementContentAs(Type returnType, IXmlNamespaceResolver namespaceResolver);
         public virtual object ReadElementContentAs(Type returnType, IXmlNamespaceResolver namespaceResolver, string localName, string namespaceURI);
         public virtual Task<object> ReadElementContentAsAsync(Type returnType, IXmlNamespaceResolver namespaceResolver);
         public virtual int ReadElementContentAsBase64(byte[] buffer, int index, int count);
         public virtual Task<int> ReadElementContentAsBase64Async(byte[] buffer, int index, int count);
         public virtual int ReadElementContentAsBinHex(byte[] buffer, int index, int count);
         public virtual Task<int> ReadElementContentAsBinHexAsync(byte[] buffer, int index, int count);
         public virtual bool ReadElementContentAsBoolean();
         public virtual bool ReadElementContentAsBoolean(string localName, string namespaceURI);
         public virtual decimal ReadElementContentAsDecimal();
         public virtual decimal ReadElementContentAsDecimal(string localName, string namespaceURI);
         public virtual double ReadElementContentAsDouble();
         public virtual double ReadElementContentAsDouble(string localName, string namespaceURI);
         public virtual float ReadElementContentAsFloat();
         public virtual float ReadElementContentAsFloat(string localName, string namespaceURI);
         public virtual int ReadElementContentAsInt();
         public virtual int ReadElementContentAsInt(string localName, string namespaceURI);
         public virtual long ReadElementContentAsLong();
         public virtual long ReadElementContentAsLong(string localName, string namespaceURI);
         public virtual object ReadElementContentAsObject();
         public virtual object ReadElementContentAsObject(string localName, string namespaceURI);
         public virtual Task<object> ReadElementContentAsObjectAsync();
         public virtual string ReadElementContentAsString();
         public virtual string ReadElementContentAsString(string localName, string namespaceURI);
         public virtual Task<string> ReadElementContentAsStringAsync();
         public virtual void ReadEndElement();
         public virtual string ReadInnerXml();
         public virtual Task<string> ReadInnerXmlAsync();
         public virtual string ReadOuterXml();
         public virtual Task<string> ReadOuterXmlAsync();
         public virtual void ReadStartElement();
         public virtual void ReadStartElement(string name);
         public virtual void ReadStartElement(string localname, string ns);
         public virtual XmlReader ReadSubtree();
         public virtual bool ReadToDescendant(string name);
         public virtual bool ReadToDescendant(string localName, string namespaceURI);
         public virtual bool ReadToFollowing(string name);
         public virtual bool ReadToFollowing(string localName, string namespaceURI);
         public virtual bool ReadToNextSibling(string name);
         public virtual bool ReadToNextSibling(string localName, string namespaceURI);
         public virtual int ReadValueChunk(char[] buffer, int index, int count);
         public virtual Task<int> ReadValueChunkAsync(char[] buffer, int index, int count);
         public abstract void ResolveEntity();
         public virtual void Skip();
         public virtual Task SkipAsync();
     }
     public sealed class XmlReaderSettings {
         public XmlReaderSettings();
         public bool Async { get; set; }
         public bool CheckCharacters { get; set; }
         public bool CloseInput { get; set; }
         public ConformanceLevel ConformanceLevel { get; set; }
         public DtdProcessing DtdProcessing { get; set; }
         public bool IgnoreComments { get; set; }
         public bool IgnoreProcessingInstructions { get; set; }
         public bool IgnoreWhitespace { get; set; }
         public int LineNumberOffset { get; set; }
         public int LinePositionOffset { get; set; }
         public long MaxCharactersFromEntities { get; set; }
         public long MaxCharactersInDocument { get; set; }
         public XmlNameTable NameTable { get; set; }
         public XmlReaderSettings Clone();
         public void Reset();
     }
     public enum XmlSpace {
         Default = 1,
         None = 0,
         Preserve = 2,
     }
     public abstract class XmlWriter : IDisposable {
         protected XmlWriter();
         public virtual XmlWriterSettings Settings { get; }
         public abstract WriteState WriteState { get; }
         public virtual string XmlLang { get; }
         public virtual XmlSpace XmlSpace { get; }
         public static XmlWriter Create(Stream output);
         public static XmlWriter Create(Stream output, XmlWriterSettings settings);
         public static XmlWriter Create(StringBuilder output);
         public static XmlWriter Create(StringBuilder output, XmlWriterSettings settings);
         public static XmlWriter Create(TextWriter output);
         public static XmlWriter Create(TextWriter output, XmlWriterSettings settings);
         public static XmlWriter Create(XmlWriter output);
         public static XmlWriter Create(XmlWriter output, XmlWriterSettings settings);
         public void Dispose();
         protected virtual void Dispose(bool disposing);
         public abstract void Flush();
         public virtual Task FlushAsync();
         public abstract string LookupPrefix(string ns);
         public virtual void WriteAttributes(XmlReader reader, bool defattr);
         public virtual Task WriteAttributesAsync(XmlReader reader, bool defattr);
         public void WriteAttributeString(string localName, string value);
         public void WriteAttributeString(string localName, string ns, string value);
         public void WriteAttributeString(string prefix, string localName, string ns, string value);
         public Task WriteAttributeStringAsync(string prefix, string localName, string ns, string value);
         public abstract void WriteBase64(byte[] buffer, int index, int count);
         public virtual Task WriteBase64Async(byte[] buffer, int index, int count);
         public virtual void WriteBinHex(byte[] buffer, int index, int count);
         public virtual Task WriteBinHexAsync(byte[] buffer, int index, int count);
         public abstract void WriteCData(string text);
         public virtual Task WriteCDataAsync(string text);
         public abstract void WriteCharEntity(char ch);
         public virtual Task WriteCharEntityAsync(char ch);
         public abstract void WriteChars(char[] buffer, int index, int count);
         public virtual Task WriteCharsAsync(char[] buffer, int index, int count);
         public abstract void WriteComment(string text);
         public virtual Task WriteCommentAsync(string text);
         public abstract void WriteDocType(string name, string pubid, string sysid, string subset);
         public virtual Task WriteDocTypeAsync(string name, string pubid, string sysid, string subset);
         public void WriteElementString(string localName, string value);
         public void WriteElementString(string localName, string ns, string value);
         public void WriteElementString(string prefix, string localName, string ns, string value);
         public Task WriteElementStringAsync(string prefix, string localName, string ns, string value);
         public abstract void WriteEndAttribute();
         protected internal virtual Task WriteEndAttributeAsync();
         public abstract void WriteEndDocument();
         public virtual Task WriteEndDocumentAsync();
         public abstract void WriteEndElement();
         public virtual Task WriteEndElementAsync();
         public abstract void WriteEntityRef(string name);
         public virtual Task WriteEntityRefAsync(string name);
         public abstract void WriteFullEndElement();
         public virtual Task WriteFullEndElementAsync();
         public virtual void WriteName(string name);
         public virtual Task WriteNameAsync(string name);
         public virtual void WriteNmToken(string name);
         public virtual Task WriteNmTokenAsync(string name);
         public virtual void WriteNode(XmlReader reader, bool defattr);
         public virtual Task WriteNodeAsync(XmlReader reader, bool defattr);
         public abstract void WriteProcessingInstruction(string name, string text);
         public virtual Task WriteProcessingInstructionAsync(string name, string text);
         public virtual void WriteQualifiedName(string localName, string ns);
         public virtual Task WriteQualifiedNameAsync(string localName, string ns);
         public abstract void WriteRaw(char[] buffer, int index, int count);
         public abstract void WriteRaw(string data);
         public virtual Task WriteRawAsync(char[] buffer, int index, int count);
         public virtual Task WriteRawAsync(string data);
         public void WriteStartAttribute(string localName);
         public void WriteStartAttribute(string localName, string ns);
         public abstract void WriteStartAttribute(string prefix, string localName, string ns);
         protected internal virtual Task WriteStartAttributeAsync(string prefix, string localName, string ns);
         public abstract void WriteStartDocument();
         public abstract void WriteStartDocument(bool standalone);
         public virtual Task WriteStartDocumentAsync();
         public virtual Task WriteStartDocumentAsync(bool standalone);
         public void WriteStartElement(string localName);
         public void WriteStartElement(string localName, string ns);
         public abstract void WriteStartElement(string prefix, string localName, string ns);
         public virtual Task WriteStartElementAsync(string prefix, string localName, string ns);
         public abstract void WriteString(string text);
         public virtual Task WriteStringAsync(string text);
         public abstract void WriteSurrogateCharEntity(char lowChar, char highChar);
         public virtual Task WriteSurrogateCharEntityAsync(char lowChar, char highChar);
         public virtual void WriteValue(bool value);
         public virtual void WriteValue(DateTimeOffset value);
         public virtual void WriteValue(decimal value);
         public virtual void WriteValue(double value);
         public virtual void WriteValue(int value);
         public virtual void WriteValue(long value);
         public virtual void WriteValue(object value);
         public virtual void WriteValue(float value);
         public virtual void WriteValue(string value);
         public abstract void WriteWhitespace(string ws);
         public virtual Task WriteWhitespaceAsync(string ws);
     }
     public sealed class XmlWriterSettings {
         public XmlWriterSettings();
         public bool Async { get; set; }
         public bool CheckCharacters { get; set; }
         public bool CloseOutput { get; set; }
         public ConformanceLevel ConformanceLevel { get; set; }
         public Encoding Encoding { get; set; }
         public bool Indent { get; set; }
         public string IndentChars { get; set; }
         public NamespaceHandling NamespaceHandling { get; set; }
         public string NewLineChars { get; set; }
         public NewLineHandling NewLineHandling { get; set; }
         public bool NewLineOnAttributes { get; set; }
         public bool OmitXmlDeclaration { get; set; }
         public bool WriteEndDocumentOnClose { get; set; }
         public XmlWriterSettings Clone();
         public void Reset();
     }
 }
 namespace System.Xml.Linq {
     public static class Extensions {
         public static IEnumerable<XElement> Ancestors<T>(this IEnumerable<T> source) where T : XNode;
         public static IEnumerable<XElement> Ancestors<T>(this IEnumerable<T> source, XName name) where T : XNode;
         public static IEnumerable<XElement> AncestorsAndSelf(this IEnumerable<XElement> source);
         public static IEnumerable<XElement> AncestorsAndSelf(this IEnumerable<XElement> source, XName name);
         public static IEnumerable<XAttribute> Attributes(this IEnumerable<XElement> source);
         public static IEnumerable<XAttribute> Attributes(this IEnumerable<XElement> source, XName name);
         public static IEnumerable<XNode> DescendantNodes<T>(this IEnumerable<T> source) where T : XContainer;
         public static IEnumerable<XNode> DescendantNodesAndSelf(this IEnumerable<XElement> source);
         public static IEnumerable<XElement> Descendants<T>(this IEnumerable<T> source) where T : XContainer;
         public static IEnumerable<XElement> Descendants<T>(this IEnumerable<T> source, XName name) where T : XContainer;
         public static IEnumerable<XElement> DescendantsAndSelf(this IEnumerable<XElement> source);
         public static IEnumerable<XElement> DescendantsAndSelf(this IEnumerable<XElement> source, XName name);
         public static IEnumerable<XElement> Elements<T>(this IEnumerable<T> source) where T : XContainer;
         public static IEnumerable<XElement> Elements<T>(this IEnumerable<T> source, XName name) where T : XContainer;
         public static IEnumerable<T> InDocumentOrder<T>(this IEnumerable<T> source) where T : XNode;
         public static IEnumerable<XNode> Nodes<T>(this IEnumerable<T> source) where T : XContainer;
         public static void Remove<T>(this IEnumerable<T> source) where T : XNode;
         public static void Remove(this IEnumerable<XAttribute> source);
     }
     public enum LoadOptions {
         None = 0,
         PreserveWhitespace = 1,
         SetBaseUri = 2,
         SetLineInfo = 4,
     }
     public enum ReaderOptions {
         None = 0,
         OmitDuplicateNamespaces = 1,
     }
     public enum SaveOptions {
         DisableFormatting = 1,
         None = 0,
         OmitDuplicateNamespaces = 2,
     }
     public class XAttribute : XObject {
         public XAttribute(XAttribute other);
         public XAttribute(XName name, object value);
         public static IEnumerable<XAttribute> EmptySequence { get; }
         public bool IsNamespaceDeclaration { get; }
         public XName Name { get; }
         public XAttribute NextAttribute { get; }
         public override XmlNodeType NodeType { get; }
         public XAttribute PreviousAttribute { get; }
         public string Value { get; set; }
         public static explicit operator bool (XAttribute attribute);
         public static explicit operator DateTime (XAttribute attribute);
         public static explicit operator DateTimeOffset (XAttribute attribute);
         public static explicit operator decimal (XAttribute attribute);
         public static explicit operator double (XAttribute attribute);
         public static explicit operator Guid (XAttribute attribute);
         public static explicit operator int (XAttribute attribute);
         public static explicit operator long (XAttribute attribute);
         public static explicit operator Nullable<bool> (XAttribute attribute);
         public static explicit operator Nullable<DateTime> (XAttribute attribute);
         public static explicit operator Nullable<DateTimeOffset> (XAttribute attribute);
         public static explicit operator Nullable<decimal> (XAttribute attribute);
         public static explicit operator Nullable<double> (XAttribute attribute);
         public static explicit operator Nullable<Guid> (XAttribute attribute);
         public static explicit operator Nullable<int> (XAttribute attribute);
         public static explicit operator Nullable<long> (XAttribute attribute);
         public static explicit operator Nullable<float> (XAttribute attribute);
         public static explicit operator Nullable<TimeSpan> (XAttribute attribute);
         public static explicit operator Nullable<uint> (XAttribute attribute);
         public static explicit operator Nullable<ulong> (XAttribute attribute);
         public static explicit operator float (XAttribute attribute);
         public static explicit operator string (XAttribute attribute);
         public static explicit operator TimeSpan (XAttribute attribute);
         public static explicit operator uint (XAttribute attribute);
         public static explicit operator ulong (XAttribute attribute);
         public void Remove();
         public void SetValue(object value);
         public override string ToString();
     }
     public class XCData : XText {
         public XCData(string value);
         public XCData(XCData other);
         public override XmlNodeType NodeType { get; }
         public override void WriteTo(XmlWriter writer);
     }
     public class XComment : XNode {
         public XComment(string value);
         public XComment(XComment other);
         public override XmlNodeType NodeType { get; }
         public string Value { get; set; }
         public override void WriteTo(XmlWriter writer);
     }
     public abstract class XContainer : XNode {
         public XNode FirstNode { get; }
         public XNode LastNode { get; }
         public void Add(object content);
         public void Add(params object[] content);
         public void AddFirst(object content);
         public void AddFirst(params object[] content);
         public XmlWriter CreateWriter();
         public IEnumerable<XNode> DescendantNodes();
         public IEnumerable<XElement> Descendants();
         public IEnumerable<XElement> Descendants(XName name);
         public XElement Element(XName name);
         public IEnumerable<XElement> Elements();
         public IEnumerable<XElement> Elements(XName name);
         public IEnumerable<XNode> Nodes();
         public void RemoveNodes();
         public void ReplaceNodes(object content);
         public void ReplaceNodes(params object[] content);
     }
     public class XDeclaration {
         public XDeclaration(string version, string encoding, string standalone);
         public XDeclaration(XDeclaration other);
         public string Encoding { get; set; }
         public string Standalone { get; set; }
         public string Version { get; set; }
         public override string ToString();
     }
     public class XDocument : XContainer {
         public XDocument();
         public XDocument(params object[] content);
         public XDocument(XDeclaration declaration, params object[] content);
         public XDocument(XDocument other);
         public XDeclaration Declaration { get; set; }
         public XDocumentType DocumentType { get; }
         public override XmlNodeType NodeType { get; }
         public XElement Root { get; }
         public static XDocument Load(Stream stream);
         public static XDocument Load(Stream stream, LoadOptions options);
         public static XDocument Load(string uri);
         public static XDocument Load(string uri, LoadOptions options);
         public static XDocument Load(TextReader textReader);
         public static XDocument Load(TextReader textReader, LoadOptions options);
         public static XDocument Load(XmlReader reader);
         public static XDocument Load(XmlReader reader, LoadOptions options);
         public static XDocument Parse(string text);
         public static XDocument Parse(string text, LoadOptions options);
         public void Save(Stream stream);
         public void Save(Stream stream, SaveOptions options);
         public void Save(TextWriter textWriter);
         public void Save(TextWriter textWriter, SaveOptions options);
         public void Save(XmlWriter writer);
         public override void WriteTo(XmlWriter writer);
     }
     public class XDocumentType : XNode {
         public XDocumentType(string name, string publicId, string systemId, string internalSubset);
         public XDocumentType(XDocumentType other);
         public string InternalSubset { get; set; }
         public string Name { get; set; }
         public override XmlNodeType NodeType { get; }
         public string PublicId { get; set; }
         public string SystemId { get; set; }
         public override void WriteTo(XmlWriter writer);
     }
     public class XElement : XContainer {
         public XElement(XElement other);
         public XElement(XName name);
         public XElement(XName name, object content);
         public XElement(XName name, params object[] content);
         public XElement(XStreamingElement other);
         public static IEnumerable<XElement> EmptySequence { get; }
         public XAttribute FirstAttribute { get; }
         public bool HasAttributes { get; }
         public bool HasElements { get; }
         public bool IsEmpty { get; }
         public XAttribute LastAttribute { get; }
         public XName Name { get; set; }
         public override XmlNodeType NodeType { get; }
         public string Value { get; set; }
         public IEnumerable<XElement> AncestorsAndSelf();
         public IEnumerable<XElement> AncestorsAndSelf(XName name);
         public XAttribute Attribute(XName name);
         public IEnumerable<XAttribute> Attributes();
         public IEnumerable<XAttribute> Attributes(XName name);
         public IEnumerable<XNode> DescendantNodesAndSelf();
         public IEnumerable<XElement> DescendantsAndSelf();
         public IEnumerable<XElement> DescendantsAndSelf(XName name);
         public XNamespace GetDefaultNamespace();
         public XNamespace GetNamespaceOfPrefix(string prefix);
         public string GetPrefixOfNamespace(XNamespace ns);
         public static XElement Load(Stream stream);
         public static XElement Load(Stream stream, LoadOptions options);
         public static XElement Load(string uri);
         public static XElement Load(string uri, LoadOptions options);
         public static XElement Load(TextReader textReader);
         public static XElement Load(TextReader textReader, LoadOptions options);
         public static XElement Load(XmlReader reader);
         public static XElement Load(XmlReader reader, LoadOptions options);
         public static explicit operator bool (XElement element);
         public static explicit operator DateTime (XElement element);
         public static explicit operator DateTimeOffset (XElement element);
         public static explicit operator decimal (XElement element);
         public static explicit operator double (XElement element);
         public static explicit operator Guid (XElement element);
         public static explicit operator int (XElement element);
         public static explicit operator long (XElement element);
         public static explicit operator Nullable<bool> (XElement element);
         public static explicit operator Nullable<DateTime> (XElement element);
         public static explicit operator Nullable<DateTimeOffset> (XElement element);
         public static explicit operator Nullable<decimal> (XElement element);
         public static explicit operator Nullable<double> (XElement element);
         public static explicit operator Nullable<Guid> (XElement element);
         public static explicit operator Nullable<int> (XElement element);
         public static explicit operator Nullable<long> (XElement element);
         public static explicit operator Nullable<float> (XElement element);
         public static explicit operator Nullable<TimeSpan> (XElement element);
         public static explicit operator Nullable<uint> (XElement element);
         public static explicit operator Nullable<ulong> (XElement element);
         public static explicit operator float (XElement element);
         public static explicit operator string (XElement element);
         public static explicit operator TimeSpan (XElement element);
         public static explicit operator uint (XElement element);
         public static explicit operator ulong (XElement element);
         public static XElement Parse(string text);
         public static XElement Parse(string text, LoadOptions options);
         public void RemoveAll();
         public void RemoveAttributes();
         public void ReplaceAll(object content);
         public void ReplaceAll(params object[] content);
         public void ReplaceAttributes(object content);
         public void ReplaceAttributes(params object[] content);
         public void Save(Stream stream);
         public void Save(Stream stream, SaveOptions options);
         public void Save(TextWriter textWriter);
         public void Save(TextWriter textWriter, SaveOptions options);
         public void Save(XmlWriter writer);
         public void SetAttributeValue(XName name, object value);
         public void SetElementValue(XName name, object value);
         public void SetValue(object value);
         public override void WriteTo(XmlWriter writer);
     }
     public sealed class XName : IEquatable<XName> {
         public string LocalName { get; }
         public XNamespace Namespace { get; }
         public string NamespaceName { get; }
         public override bool Equals(object obj);
         public static XName Get(string expandedName);
         public static XName Get(string localName, string namespaceName);
         public override int GetHashCode();
         public static bool operator ==(XName left, XName right);
         public static implicit operator XName (string expandedName);
         public static bool operator !=(XName left, XName right);
         public override string ToString();
     }
     public sealed class XNamespace {
         public string NamespaceName { get; }
         public static XNamespace None { get; }
         public static XNamespace Xml { get; }
         public static XNamespace Xmlns { get; }
         public override bool Equals(object obj);
         public static XNamespace Get(string namespaceName);
         public override int GetHashCode();
         public XName GetName(string localName);
         public static XName operator +(XNamespace ns, string localName);
         public static bool operator ==(XNamespace left, XNamespace right);
         public static implicit operator XNamespace (string namespaceName);
         public static bool operator !=(XNamespace left, XNamespace right);
         public override string ToString();
     }
     public abstract class XNode : XObject {
         public static XNodeDocumentOrderComparer DocumentOrderComparer { get; }
         public static XNodeEqualityComparer EqualityComparer { get; }
         public XNode NextNode { get; }
         public XNode PreviousNode { get; }
         public void AddAfterSelf(object content);
         public void AddAfterSelf(params object[] content);
         public void AddBeforeSelf(object content);
         public void AddBeforeSelf(params object[] content);
         public IEnumerable<XElement> Ancestors();
         public IEnumerable<XElement> Ancestors(XName name);
         public static int CompareDocumentOrder(XNode n1, XNode n2);
         public XmlReader CreateReader();
         public XmlReader CreateReader(ReaderOptions readerOptions);
         public static bool DeepEquals(XNode n1, XNode n2);
         public IEnumerable<XElement> ElementsAfterSelf();
         public IEnumerable<XElement> ElementsAfterSelf(XName name);
         public IEnumerable<XElement> ElementsBeforeSelf();
         public IEnumerable<XElement> ElementsBeforeSelf(XName name);
         public bool IsAfter(XNode node);
         public bool IsBefore(XNode node);
         public IEnumerable<XNode> NodesAfterSelf();
         public IEnumerable<XNode> NodesBeforeSelf();
         public static XNode ReadFrom(XmlReader reader);
         public void Remove();
         public void ReplaceWith(object content);
         public void ReplaceWith(params object[] content);
         public override string ToString();
         public string ToString(SaveOptions options);
         public abstract void WriteTo(XmlWriter writer);
     }
     public sealed class XNodeDocumentOrderComparer : IComparer, IComparer<XNode> {
         public XNodeDocumentOrderComparer();
         public int Compare(XNode x, XNode y);
     }
     public sealed class XNodeEqualityComparer : IEqualityComparer, IEqualityComparer<XNode> {
         public XNodeEqualityComparer();
         public bool Equals(XNode x, XNode y);
         public int GetHashCode(XNode obj);
     }
     public abstract class XObject : IXmlLineInfo {
         public string BaseUri { get; }
         public XDocument Document { get; }
         public abstract XmlNodeType NodeType { get; }
         public XElement Parent { get; }
         public void AddAnnotation(object annotation);
         public T Annotation<T>() where T : class;
         public object Annotation(Type type);
         public IEnumerable<T> Annotations<T>() where T : class;
         public IEnumerable<object> Annotations(Type type);
         public void RemoveAnnotations<T>() where T : class;
         public void RemoveAnnotations(Type type);
         public event EventHandler<XObjectChangeEventArgs> Changed;
         public event EventHandler<XObjectChangeEventArgs> Changing;
     }
     public enum XObjectChange {
         Add = 0,
         Name = 2,
         Remove = 1,
         Value = 3,
     }
     public class XObjectChangeEventArgs : EventArgs {
         public static readonly XObjectChangeEventArgs Add;
         public static readonly XObjectChangeEventArgs Name;
         public static readonly XObjectChangeEventArgs Remove;
         public static readonly XObjectChangeEventArgs Value;
         public XObjectChangeEventArgs(XObjectChange objectChange);
         public XObjectChange ObjectChange { get; }
     }
     public class XProcessingInstruction : XNode {
         public XProcessingInstruction(string target, string data);
         public XProcessingInstruction(XProcessingInstruction other);
         public string Data { get; set; }
         public override XmlNodeType NodeType { get; }
         public string Target { get; set; }
         public override void WriteTo(XmlWriter writer);
     }
     public class XStreamingElement {
         public XStreamingElement(XName name);
         public XStreamingElement(XName name, object content);
         public XStreamingElement(XName name, params object[] content);
         public XName Name { get; set; }
         public void Add(object content);
         public void Add(params object[] content);
         public void Save(Stream stream);
         public void Save(Stream stream, SaveOptions options);
         public void Save(TextWriter textWriter);
         public void Save(TextWriter textWriter, SaveOptions options);
         public void Save(XmlWriter writer);
         public override string ToString();
         public string ToString(SaveOptions options);
         public void WriteTo(XmlWriter writer);
     }
     public class XText : XNode {
         public XText(string value);
         public XText(XText other);
         public override XmlNodeType NodeType { get; }
         public string Value { get; set; }
         public override void WriteTo(XmlWriter writer);
     }
 }
 namespace System.Xml.Schema {
     public class XmlSchema {
     }
     public enum XmlSchemaForm {
         None = 0,
         Qualified = 1,
         Unqualified = 2,
     }
 }
```
