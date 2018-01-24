# .NET Standard 1.6 vs. 1.5

[Overview](netstandard1.6.md) | [Previous](netstandard1.5_diff.md) | [Next](netstandard2.0_diff.md)

```diff
 namespace System {
     public static class AppContext {
+        public static string TargetFrameworkName { get; }
+        public static object GetData(string name);
     }
 }
 namespace System.Linq {
     public static class Enumerable {
+        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element);
+        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element);
     }
 }
 namespace System.Linq.Expressions {
     public sealed class Expression<TDelegate> : LambdaExpression {
+        public new TDelegate Compile(bool preferInterpretation);
     }
     public abstract class LambdaExpression : Expression {
+        public Delegate Compile(bool preferInterpretation);
     }
 }
 namespace System.Security.Cryptography {
+    public struct ECCurve {
+        public enum ECCurveType {
+            Characteristic2 = 4,
+            Implicit = 0,
+            Named = 5,
+            PrimeMontgomery = 3,
+            PrimeShortWeierstrass = 1,
+            PrimeTwistedEdwards = 2,
+        }
+        public static class NamedCurves {
+            public static ECCurve brainpoolP160r1 { get; }
+            public static ECCurve brainpoolP160t1 { get; }
+            public static ECCurve brainpoolP192r1 { get; }
+            public static ECCurve brainpoolP192t1 { get; }
+            public static ECCurve brainpoolP224r1 { get; }
+            public static ECCurve brainpoolP224t1 { get; }
+            public static ECCurve brainpoolP256r1 { get; }
+            public static ECCurve brainpoolP256t1 { get; }
+            public static ECCurve brainpoolP320r1 { get; }
+            public static ECCurve brainpoolP320t1 { get; }
+            public static ECCurve brainpoolP384r1 { get; }
+            public static ECCurve brainpoolP384t1 { get; }
+            public static ECCurve brainpoolP512r1 { get; }
+            public static ECCurve brainpoolP512t1 { get; }
+            public static ECCurve nistP256 { get; }
+            public static ECCurve nistP384 { get; }
+            public static ECCurve nistP521 { get; }
+        }
+        public byte[] A;
+        public byte[] B;
+        public byte[] Cofactor;
+        public ECCurve.ECCurveType CurveType;
+        public ECPoint G;
+        public Nullable<HashAlgorithmName> Hash;
+        public byte[] Order;
+        public byte[] Polynomial;
+        public byte[] Prime;
+        public byte[] Seed;
+        public bool IsCharacteristic2 { get; }
+        public bool IsExplicit { get; }
+        public bool IsNamed { get; }
+        public bool IsPrime { get; }
+        public Oid Oid { get; }
+        public static ECCurve CreateFromFriendlyName(string oidFriendlyName);
+        public static ECCurve CreateFromOid(Oid curveOid);
+        public static ECCurve CreateFromValue(string oidValue);
+        public void Validate();
+    }
     public abstract class ECDsa : AsymmetricAlgorithm {
+        public static ECDsa Create();
+        public static ECDsa Create(ECCurve curve);
+        public static ECDsa Create(ECParameters parameters);
+        public virtual ECParameters ExportExplicitParameters(bool includePrivateParameters);
+        public virtual ECParameters ExportParameters(bool includePrivateParameters);
+        public virtual void GenerateKey(ECCurve curve);
+        public virtual void ImportParameters(ECParameters parameters);
     }
+    public struct ECParameters {
+        public ECCurve Curve;
+        public byte[] D;
+        public ECPoint Q;
+        public void Validate();
+    }
+    public struct ECPoint {
+        public byte[] X;
+        public byte[] Y;
+    }
 }
 namespace System.Text.RegularExpressions {
     public class Regex {
+        protected internal int capsize;
+        protected internal string[] capslist;
+        protected internal RegexRunnerFactory factory;
+        protected internal TimeSpan internalMatchTimeout;
+        protected internal string pattern;
+        protected internal RegexOptions roptions;
+        protected IDictionary CapNames { get; set; }
+        protected IDictionary Caps { get; set; }
+        protected void InitializeReferences();
+        protected internal static void ValidateMatchTimeout(TimeSpan matchTimeout);
     }
+    public abstract class RegexRunner {
+        protected internal int[] runcrawl;
+        protected internal int runcrawlpos;
+        protected internal Match runmatch;
+        protected internal Regex runregex;
+        protected internal int[] runstack;
+        protected internal int runstackpos;
+        protected internal string runtext;
+        protected internal int runtextbeg;
+        protected internal int runtextend;
+        protected internal int runtextpos;
+        protected internal int runtextstart;
+        protected internal int[] runtrack;
+        protected internal int runtrackcount;
+        protected internal int runtrackpos;
+        protected internal RegexRunner();
+        protected void Capture(int capnum, int start, int end);
+        protected static bool CharInClass(char ch, string charClass);
+        protected static bool CharInSet(char ch, string @set, string category);
+        protected void CheckTimeout();
+        protected void Crawl(int i);
+        protected int Crawlpos();
+        protected void DoubleCrawl();
+        protected void DoubleStack();
+        protected void DoubleTrack();
+        protected void EnsureStorage();
+        protected abstract bool FindFirstChar();
+        protected abstract void Go();
+        protected abstract void InitTrackCount();
+        protected bool IsBoundary(int index, int startpos, int endpos);
+        protected bool IsECMABoundary(int index, int startpos, int endpos);
+        protected bool IsMatched(int cap);
+        protected int MatchIndex(int cap);
+        protected int MatchLength(int cap);
+        protected int Popcrawl();
+        protected internal Match Scan(Regex regex, string text, int textbeg, int textend, int textstart, int prevlen, bool quick);
+        protected internal Match Scan(Regex regex, string text, int textbeg, int textend, int textstart, int prevlen, bool quick, TimeSpan timeout);
+        protected void TransferCapture(int capnum, int uncapnum, int start, int end);
+        protected void Uncapture();
+    }
+    public abstract class RegexRunnerFactory {
+        protected RegexRunnerFactory();
+        protected internal abstract RegexRunner CreateInstance();
+    }
 }
```
