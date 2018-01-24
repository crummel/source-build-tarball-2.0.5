# .NET Standard 1.5 vs. 1.4

[Overview](netstandard1.5.md) | [Previous](netstandard1.4_diff.md) | [Next](netstandard1.6_diff.md)

```diff
 namespace System {
     public static class Activator {
+        public static object CreateInstance(Type type, bool nonPublic);
     }
     public static class Environment {
+        public static string MachineName { get; }
+        public static void Exit(int exitCode);
+        public static string[] GetCommandLineArgs();
     }
     public abstract class Type {
+        public static readonly char Delimiter;
+        public static TypeCode GetTypeCode(Type type);
     }
 }
 namespace System.Diagnostics.Tracing {
+    public class EventCounter {
+        public EventCounter(string name, EventSource eventSource);
+        public void WriteMetric(float value);
+    }
     public class EventSource : IDisposable {
+        public event EventHandler<EventCommandEventArgs> EventCommandExecuted;
     }
 }
 namespace System.IO {
+    public sealed class BufferedStream : Stream {
+        public BufferedStream(Stream stream);
+        public BufferedStream(Stream stream, int bufferSize);
+        public override bool CanRead { get; }
+        public override bool CanSeek { get; }
+        public override bool CanWrite { get; }
+        public override long Length { get; }
+        public override long Position { get; set; }
+        public override void Flush();
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
 }
 namespace System.Reflection {
-    public abstract class Assembly {
+    public abstract class Assembly : ICustomAttributeProvider {
+        public virtual string CodeBase { get; }
+        public virtual MethodInfo EntryPoint { get; }
+        public virtual string ImageRuntimeVersion { get; }
+        public virtual string Location { get; }
+        public object CreateInstance(string typeName);
+        public object CreateInstance(string typeName, bool ignoreCase);
+        public static string CreateQualifiedName(string assemblyName, string typeName);
+        public static Assembly GetEntryAssembly();
+        public virtual Type[] GetExportedTypes();
+        public virtual AssemblyName[] GetReferencedAssemblies();
+        public virtual Type GetType(string name, bool throwOnError);
+        public virtual Type[] GetTypes();
     }
+    public enum BindingFlags {
+        CreateInstance = 512,
+        DeclaredOnly = 2,
+        Default = 0,
+        FlattenHierarchy = 64,
+        GetField = 1024,
+        GetProperty = 4096,
+        IgnoreCase = 1,
+        Instance = 4,
+        InvokeMethod = 256,
+        NonPublic = 32,
+        Public = 16,
+        SetField = 2048,
+        SetProperty = 8192,
+        Static = 8,
+    }
     public abstract class ConstructorInfo : MethodBase {
+        public override MemberTypes MemberType { get; }
     }
     public class CustomAttributeData {
+        public virtual ConstructorInfo Constructor { get; }
+        public static IList<CustomAttributeData> GetCustomAttributes(Assembly target);
+        public static IList<CustomAttributeData> GetCustomAttributes(MemberInfo target);
+        public static IList<CustomAttributeData> GetCustomAttributes(Module target);
+        public static IList<CustomAttributeData> GetCustomAttributes(ParameterInfo target);
     }
     public struct CustomAttributeNamedArgument {
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static bool operator ==(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right);
+        public static bool operator !=(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right);
+        public override string ToString();
     }
     public struct CustomAttributeTypedArgument {
+        public override bool Equals(object obj);
+        public override int GetHashCode();
+        public static bool operator ==(CustomAttributeTypedArgument left, CustomAttributeTypedArgument right);
+        public static bool operator !=(CustomAttributeTypedArgument left, CustomAttributeTypedArgument right);
+        public override string ToString();
     }
     public abstract class EventInfo : MemberInfo {
+        public virtual bool IsMulticast { get; }
+        public override MemberTypes MemberType { get; }
+        public MethodInfo GetAddMethod();
+        public abstract MethodInfo GetAddMethod(bool nonPublic);
+        public MethodInfo GetRaiseMethod();
+        public abstract MethodInfo GetRaiseMethod(bool nonPublic);
+        public MethodInfo GetRemoveMethod();
+        public abstract MethodInfo GetRemoveMethod(bool nonPublic);
     }
     public abstract class FieldInfo : MemberInfo {
+        public override MemberTypes MemberType { get; }
+        public virtual Type[] GetOptionalCustomModifiers();
+        public virtual object GetRawConstantValue();
+        public virtual Type[] GetRequiredCustomModifiers();
     }
+    public interface ICustomAttributeProvider {
+        object[] GetCustomAttributes(bool inherit);
+        object[] GetCustomAttributes(Type attributeType, bool inherit);
+        bool IsDefined(Type attributeType, bool inherit);
+    }
+    public class InvalidFilterCriteriaException : Exception {
+        public InvalidFilterCriteriaException();
+        public InvalidFilterCriteriaException(string message);
+        public InvalidFilterCriteriaException(string message, Exception inner);
+    }
+    public delegate bool MemberFilter(MemberInfo m, object filterCriteria); {
+        public MemberFilter(object @object, IntPtr method);
+        public virtual IAsyncResult BeginInvoke(MemberInfo m, object filterCriteria, AsyncCallback callback, object @object);
+        public virtual bool EndInvoke(IAsyncResult result);
+        public virtual bool Invoke(MemberInfo m, object filterCriteria);
+    }
-    public abstract class MemberInfo {
+    public abstract class MemberInfo : ICustomAttributeProvider {
+        public abstract MemberTypes MemberType { get; }
+        public virtual int MetadataToken { get; }
     }
+    public enum MemberTypes {
+        All = 191,
+        Constructor = 1,
+        Custom = 64,
+        Event = 2,
+        Field = 4,
+        Method = 8,
+        NestedType = 128,
+        Property = 16,
+        TypeInfo = 32,
+    }
     public abstract class MethodBase : MemberInfo {
+        public abstract MethodImplAttributes GetMethodImplementationFlags();
     }
     public abstract class MethodInfo : MethodBase {
+        public override MemberTypes MemberType { get; }
+        public abstract ICustomAttributeProvider ReturnTypeCustomAttributes { get; }
+        public abstract MethodInfo GetBaseDefinition();
     }
-    public abstract class Module {
+    public abstract class Module : ICustomAttributeProvider {
+        public static readonly TypeFilter FilterTypeName;
+        public static readonly TypeFilter FilterTypeNameIgnoreCase;
+        public virtual Guid ModuleVersionId { get; }
+        public virtual string ScopeName { get; }
+        public virtual Type[] FindTypes(TypeFilter filter, object filterCriteria);
+        public FieldInfo GetField(string name);
+        public virtual FieldInfo GetField(string name, BindingFlags bindingAttr);
+        public FieldInfo[] GetFields();
+        public virtual FieldInfo[] GetFields(BindingFlags bindingFlags);
+        public MethodInfo GetMethod(string name);
+        public MethodInfo GetMethod(string name, Type[] types);
+        public MethodInfo[] GetMethods();
+        public virtual MethodInfo[] GetMethods(BindingFlags bindingFlags);
+        public virtual Type GetType(string className);
+        public virtual Type GetType(string className, bool ignoreCase);
+        public virtual Type[] GetTypes();
     }
-    public class ParameterInfo {
+    public class ParameterInfo : ICustomAttributeProvider {
+        public virtual object RawDefaultValue { get; }
+        public virtual Type[] GetOptionalCustomModifiers();
+        public virtual Type[] GetRequiredCustomModifiers();
     }
+    public struct ParameterModifier {
+        public ParameterModifier(int parameterCount);
+        public bool this[int index] { get; set; }
+    }
     public abstract class PropertyInfo : MemberInfo {
+        public override MemberTypes MemberType { get; }
+        public MethodInfo[] GetAccessors();
+        public abstract MethodInfo[] GetAccessors(bool nonPublic);
+        public MethodInfo GetGetMethod();
+        public abstract MethodInfo GetGetMethod(bool nonPublic);
+        public virtual Type[] GetOptionalCustomModifiers();
+        public virtual object GetRawConstantValue();
+        public virtual Type[] GetRequiredCustomModifiers();
+        public MethodInfo GetSetMethod();
+        public abstract MethodInfo GetSetMethod(bool nonPublic);
     }
+    public class TargetException : Exception {
+        public TargetException();
+        public TargetException(string message);
+        public TargetException(string message, Exception inner);
+    }
+    public delegate bool TypeFilter(Type m, object filterCriteria); {
+        public TypeFilter(object @object, IntPtr method);
+        public virtual IAsyncResult BeginInvoke(Type m, object filterCriteria, AsyncCallback callback, object @object);
+        public virtual bool EndInvoke(IAsyncResult result);
+        public virtual bool Invoke(Type m, object filterCriteria);
+    }
     public abstract class TypeInfo : MemberInfo, IReflectableType {
+        public virtual bool IsCOMObject { get; }
+        public override MemberTypes MemberType { get; }
+        public virtual StructLayoutAttribute StructLayoutAttribute { get; }
+        public ConstructorInfo TypeInitializer { get; }
+        public virtual Type UnderlyingSystemType { get; }
+        public virtual Type[] FindInterfaces(TypeFilter filter, object filterCriteria);
+        public virtual MemberInfo[] FindMembers(MemberTypes memberType, BindingFlags bindingAttr, MemberFilter filter, object filterCriteria);
+        public ConstructorInfo GetConstructor(Type[] types);
+        public ConstructorInfo[] GetConstructors();
+        public virtual ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);
+        public virtual MemberInfo[] GetDefaultMembers();
+        public virtual string GetEnumName(object value);
+        public virtual string[] GetEnumNames();
+        public virtual Type GetEnumUnderlyingType();
+        public virtual Array GetEnumValues();
+        public EventInfo GetEvent(string name);
+        public virtual EventInfo GetEvent(string name, BindingFlags bindingAttr);
+        public virtual EventInfo[] GetEvents();
+        public virtual EventInfo[] GetEvents(BindingFlags bindingAttr);
+        public FieldInfo GetField(string name);
+        public virtual FieldInfo GetField(string name, BindingFlags bindingAttr);
+        public FieldInfo[] GetFields();
+        public virtual FieldInfo[] GetFields(BindingFlags bindingAttr);
+        public virtual Type[] GetGenericArguments();
+        public Type GetInterface(string name);
+        public virtual Type GetInterface(string name, bool ignoreCase);
+        public virtual Type[] GetInterfaces();
+        public MemberInfo[] GetMember(string name);
+        public virtual MemberInfo[] GetMember(string name, BindingFlags bindingAttr);
+        public virtual MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr);
+        public MemberInfo[] GetMembers();
+        public virtual MemberInfo[] GetMembers(BindingFlags bindingAttr);
+        public MethodInfo GetMethod(string name);
+        public MethodInfo GetMethod(string name, BindingFlags bindingAttr);
+        public MethodInfo GetMethod(string name, Type[] types);
+        public MethodInfo GetMethod(string name, Type[] types, ParameterModifier[] modifiers);
+        public MethodInfo[] GetMethods();
+        public virtual MethodInfo[] GetMethods(BindingFlags bindingAttr);
+        public Type GetNestedType(string name);
+        public virtual Type GetNestedType(string name, BindingFlags bindingAttr);
+        public Type[] GetNestedTypes();
+        public virtual Type[] GetNestedTypes(BindingFlags bindingAttr);
+        public PropertyInfo[] GetProperties();
+        public virtual PropertyInfo[] GetProperties(BindingFlags bindingAttr);
+        public PropertyInfo GetProperty(string name);
+        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr);
+        public PropertyInfo GetProperty(string name, Type returnType);
+        public PropertyInfo GetProperty(string name, Type returnType, Type[] types);
+        public PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers);
+        public PropertyInfo GetProperty(string name, Type[] types);
+        public virtual bool IsAssignableFrom(Type c);
+        public virtual bool IsEnumDefined(object value);
+        public virtual bool IsEquivalentTo(Type other);
+        public virtual bool IsInstanceOfType(object o);
     }
 }
```
