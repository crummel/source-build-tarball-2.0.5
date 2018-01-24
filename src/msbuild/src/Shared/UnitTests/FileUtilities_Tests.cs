// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using System.Text;

using Microsoft.Build.Shared;
using System.IO;
using System.Collections.Generic;
using Microsoft.Build.Evaluation;
using Xunit;

namespace Microsoft.Build.UnitTests
{
    public class FileUtilities_Tests
    {
        /// <summary>
        /// Exercises FileUtilities.ItemSpecModifiers.GetItemSpecModifier
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void GetItemSpecModifier()
        {
            TestGetItemSpecModifier(Directory.GetCurrentDirectory());
            TestGetItemSpecModifier(null);
        }

        private static void TestGetItemSpecModifier(string currentDirectory)
        {
            string cache = null;
            string modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, "foo", String.Empty, FileUtilities.ItemSpecModifiers.RecursiveDir, ref cache);
            Assert.Equal(String.Empty, modifier);

            cache = null;
            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, "foo", String.Empty, FileUtilities.ItemSpecModifiers.ModifiedTime, ref cache);
            Assert.Equal(String.Empty, modifier);

            cache = null;
            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, @"foo\goo", String.Empty, FileUtilities.ItemSpecModifiers.RelativeDir, ref cache);
            Assert.Equal(@"foo" + Path.DirectorySeparatorChar, modifier);

            // confirm we get the same thing back the second time
            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, @"foo\goo", String.Empty, FileUtilities.ItemSpecModifiers.RelativeDir, ref cache);
            Assert.Equal(@"foo" + Path.DirectorySeparatorChar, modifier);

            cache = null;
            string itemSpec = NativeMethodsShared.IsWindows ? @"c:\foo.txt" : "/foo.txt";
            string itemSpecDir = NativeMethodsShared.IsWindows ? @"c:\" : "/";
            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, String.Empty, FileUtilities.ItemSpecModifiers.FullPath, ref cache);
            Assert.Equal(itemSpec, modifier);
            Assert.Equal(itemSpec, cache);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, String.Empty, FileUtilities.ItemSpecModifiers.RootDir, ref cache);
            Assert.Equal(itemSpecDir, modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, String.Empty, FileUtilities.ItemSpecModifiers.Filename, ref cache);
            Assert.Equal(@"foo", modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, String.Empty, FileUtilities.ItemSpecModifiers.Extension, ref cache);
            Assert.Equal(@".txt", modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, String.Empty, FileUtilities.ItemSpecModifiers.Directory, ref cache);
            Assert.Equal(String.Empty, modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, String.Empty, FileUtilities.ItemSpecModifiers.Identity, ref cache);
            Assert.Equal(itemSpec, modifier);

            string projectPath = NativeMethodsShared.IsWindows ? @"c:\abc\goo.proj" : @"/abc/goo.proj";
            string projectPathDir = NativeMethodsShared.IsWindows ? @"c:\abc\" : @"/abc/";
            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, projectPath, FileUtilities.ItemSpecModifiers.DefiningProjectDirectory, ref cache);
            Assert.Equal(projectPathDir, modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, projectPath, FileUtilities.ItemSpecModifiers.DefiningProjectExtension, ref cache);
            Assert.Equal(@".proj", modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, projectPath, FileUtilities.ItemSpecModifiers.DefiningProjectFullPath, ref cache);
            Assert.Equal(projectPath, modifier);

            modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, itemSpec, projectPath, FileUtilities.ItemSpecModifiers.DefiningProjectName, ref cache);
            Assert.Equal(@"goo", modifier);
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void MakeRelativeTests()
        {
            if (NativeMethodsShared.IsWindows)
            {
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"c:\abc\def", @"c:\abc\def\foo.cpp"));
                Assert.Equal(@"def\foo.cpp", FileUtilities.MakeRelative(@"c:\abc\", @"c:\abc\def\foo.cpp"));
                Assert.Equal(@"..\foo.cpp", FileUtilities.MakeRelative(@"c:\abc\def\xyz", @"c:\abc\def\foo.cpp"));
                Assert.Equal(@"..\ttt\foo.cpp", FileUtilities.MakeRelative(@"c:\abc\def\xyz\", @"c:\abc\def\ttt\foo.cpp"));
                Assert.Equal(@"e:\abc\def\foo.cpp", FileUtilities.MakeRelative(@"c:\abc\def", @"e:\abc\def\foo.cpp"));
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"\\aaa\abc\def", @"\\aaa\abc\def\foo.cpp"));
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"c:\abc\def", @"foo.cpp"));
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"c:\abc\def", @"..\def\foo.cpp"));
                Assert.Equal(@"\\host\path\file", FileUtilities.MakeRelative(@"c:\abc\def", @"\\host\path\file"));
                Assert.Equal(@"\\host\d$\file", FileUtilities.MakeRelative(@"c:\abc\def", @"\\host\d$\file"));
            }
            else
            {
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"/abc/def", @"/abc/def/foo.cpp"));
                Assert.Equal(@"def/foo.cpp", FileUtilities.MakeRelative(@"/abc/", @"/abc/def/foo.cpp"));
                Assert.Equal(@"..\foo.cpp", FileUtilities.MakeRelative(@"/abc/def/xyz", @"/abc/def/foo.cpp"));
                Assert.Equal(@"..\ttt\foo.cpp", FileUtilities.MakeRelative(@"/abc/def/xyz/", @"/abc/def/ttt/foo.cpp"));
                Assert.Equal(@"/abc/def/foo.cpp", FileUtilities.MakeRelative(@"/abc/def", @"/abc/def/foo.cpp"));
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"/abc/def", @"foo.cpp"));
                Assert.Equal(@"foo.cpp", FileUtilities.MakeRelative(@"/abc/def", @"../def/foo.cpp"));
            }
        }

        /// <summary>
        /// Exercises FileUtilities.ItemSpecModifiers.GetItemSpecModifier on a bad path.
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void GetItemSpecModifierOnBadPath()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                TestGetItemSpecModifierOnBadPath(Directory.GetCurrentDirectory());
            }
           );
        }
        /// <summary>
        /// Exercises FileUtilities.ItemSpecModifiers.GetItemSpecModifier on a bad path.
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void GetItemSpecModifierOnBadPath2()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                TestGetItemSpecModifierOnBadPath(null);
            }
           );
        }
        private static void TestGetItemSpecModifierOnBadPath(string currentDirectory)
        {
            try
            {
                string cache = null;
                string modifier = FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, @"http://www.microsoft.com", String.Empty, FileUtilities.ItemSpecModifiers.RootDir, ref cache);
            }
            catch (Exception e)
            {
                // so I can see the exception message in NUnit's "Standard Out" window
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [Fact]
        public void GetFileInfoNoThrowBasic()
        {
            string file = null;
            try
            {
                file = FileUtilities.GetTemporaryFile();
                FileInfo info = FileUtilities.GetFileInfoNoThrow(file);
                Assert.Equal(info.LastWriteTime, new FileInfo(file).LastWriteTime);
            }
            finally
            {
                if (file != null) File.Delete(file);
            }
        }

        [Fact]
        public void GetFileInfoNoThrowNonexistent()
        {
            FileInfo info = FileUtilities.GetFileInfoNoThrow("this_file_is_nonexistent");
            Assert.Null(info);
        }

        /// <summary>
        /// Exercises FileUtilities.EndsWithSlash
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void EndsWithSlash()
        {
            Assert.True(FileUtilities.EndsWithSlash(@"C:\foo\"));
            Assert.True(FileUtilities.EndsWithSlash(@"C:\"));
            Assert.True(FileUtilities.EndsWithSlash(@"\"));

            Assert.True(FileUtilities.EndsWithSlash(@"http://www.microsoft.com/"));
            Assert.True(FileUtilities.EndsWithSlash(@"//server/share/"));
            Assert.True(FileUtilities.EndsWithSlash(@"/"));

            Assert.False(FileUtilities.EndsWithSlash(@"C:\foo"));
            Assert.False(FileUtilities.EndsWithSlash(@"C:"));
            Assert.False(FileUtilities.EndsWithSlash(@"foo"));

            // confirm that empty string doesn't barf
            Assert.False(FileUtilities.EndsWithSlash(String.Empty));
        }

        /// <summary>
        /// Exercises FileUtilities.GetDirectory
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void GetDirectoryWithTrailingSlash()
        {
            Assert.Equal(NativeMethodsShared.IsWindows ? @"c:\" : "/", FileUtilities.GetDirectory(NativeMethodsShared.IsWindows ? @"c:\" : "/"));
            Assert.Equal(NativeMethodsShared.IsWindows ? @"c:\" : "/", FileUtilities.GetDirectory(NativeMethodsShared.IsWindows ? @"c:\foo" : "/foo"));
            Assert.Equal(NativeMethodsShared.IsWindows ? @"c:" : "/", FileUtilities.GetDirectory(NativeMethodsShared.IsWindows ? @"c:" : "/"));
            Assert.Equal(FileUtilities.FixFilePath(@"\"), FileUtilities.GetDirectory(@"\"));
            Assert.Equal(FileUtilities.FixFilePath(@"\"), FileUtilities.GetDirectory(@"\foo"));
            Assert.Equal(FileUtilities.FixFilePath(@"..\"), FileUtilities.GetDirectory(@"..\foo"));
            Assert.Equal(FileUtilities.FixFilePath(@"\foo\"), FileUtilities.GetDirectory(@"\foo\"));
            Assert.Equal(FileUtilities.FixFilePath(@"\\server\share"), FileUtilities.GetDirectory(@"\\server\share"));
            Assert.Equal(FileUtilities.FixFilePath(@"\\server\share\"), FileUtilities.GetDirectory(@"\\server\share\"));
            Assert.Equal(FileUtilities.FixFilePath(@"\\server\share\"), FileUtilities.GetDirectory(@"\\server\share\file"));
            Assert.Equal(FileUtilities.FixFilePath(@"\\server\share\directory\"), FileUtilities.GetDirectory(@"\\server\share\directory\"));
            Assert.Equal(FileUtilities.FixFilePath(@"foo\"), FileUtilities.GetDirectory(@"foo\bar"));
            Assert.Equal(FileUtilities.FixFilePath(@"\foo\bar\"), FileUtilities.GetDirectory(@"\foo\bar\"));
            Assert.Equal(String.Empty, FileUtilities.GetDirectory("foo"));
        }

        /// <summary>
        /// Exercises FileUtilities.HasExtension
        /// </summary>
        [Fact]
        public void HasExtension()
        {
            Assert.True(FileUtilities.HasExtension("foo.txt", new string[] { ".EXE", ".TXT" })); // "test 1"
            Assert.False(FileUtilities.HasExtension("foo.txt", new string[] { ".EXE", ".DLL" })); // "test 2"
        }

        /// <summary>
        /// Exercises FileUtilities.EnsureTrailingSlash
        /// </summary>
        [Fact]
        public void EnsureTrailingSlash()
        {
            // Doesn't have a trailing slash to start with.
            Assert.Equal(FileUtilities.FixFilePath(@"foo\bar\"), FileUtilities.EnsureTrailingSlash(@"foo\bar")); // "test 1"
            Assert.Equal(FileUtilities.FixFilePath(@"foo/bar\"), FileUtilities.EnsureTrailingSlash(@"foo/bar")); // "test 2"

            // Already has a trailing slash to start with.
            Assert.Equal(FileUtilities.FixFilePath(@"foo/bar/"), FileUtilities.EnsureTrailingSlash(@"foo/bar/")); //test 3"
            Assert.Equal(FileUtilities.FixFilePath(@"foo\bar\"), FileUtilities.EnsureTrailingSlash(@"foo\bar\")); //test 4"
            Assert.Equal(FileUtilities.FixFilePath(@"foo/bar\"), FileUtilities.EnsureTrailingSlash(@"foo/bar\")); //test 5"
            Assert.Equal(FileUtilities.FixFilePath(@"foo\bar/"), FileUtilities.EnsureTrailingSlash(@"foo\bar/")); //"test 5"
        }

        /// <summary>
        /// Exercises FileUtilities.ItemSpecModifiers.IsItemSpecModifier
        /// </summary>
        [Fact]
        public void IsItemSpecModifier()
        {
            // Positive matches using exact case.
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("FullPath")); // "test 1"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("RootDir")); // "test 2"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Filename")); // "test 3"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Extension")); // "test 4"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("RelativeDir")); // "test 5"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Directory")); // "test 6"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("RecursiveDir")); // "test 7"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Identity")); // "test 8"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("ModifiedTime")); // "test 9"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("CreatedTime")); // "test 10"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("AccessedTime")); // "test 11"

            // Positive matches using different case.
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("fullPath")); // "test 21"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("rootDir")); // "test 22"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("filename")); // "test 23"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("extension")); // "test 24"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("relativeDir")); // "test 25"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("directory")); // "test 26"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("recursiveDir")); // "test 27"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("identity")); // "test 28"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("modifiedTime")); // "test 29"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("createdTime")); // "test 30"
            Assert.True(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("accessedTime")); // "test 31"

            // Negative tests to get maximum code coverage inside the many different branches
            // of FileUtilities.ItemSpecModifiers.IsItemSpecModifier.
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("rootxxx")); // "test 41"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Rootxxx")); // "test 42"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("xxxxxxx")); // "test 43"

            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("filexxxx")); // "test 44"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Filexxxx")); // "test 45"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("idenxxxx")); // "test 46"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Idenxxxx")); // "test 47"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("xxxxxxxx")); // "test 48"

            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("extenxxxx")); // "test 49"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Extenxxxx")); // "test 50"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("direcxxxx")); // "test 51"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Direcxxxx")); // "test 52"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("xxxxxxxxx")); // "test 53"

            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("xxxxxxxxxx")); // "test 54"

            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("relativexxx")); // "test 55"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Relativexxx")); // "test 56"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("createdxxxx")); // "test 57"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Createdxxxx")); // "test 58"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("xxxxxxxxxxx")); // "test 59"

            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("recursivexxx")); // "test 60"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Recursivexxx")); // "test 61"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("accessedxxxx")); // "test 62"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Accessedxxxx")); // "test 63"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("modifiedxxxx")); // "test 64"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("Modifiedxxxx")); // "test 65"
            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier("xxxxxxxxxxxx")); // "test 66"

            Assert.False(FileUtilities.ItemSpecModifiers.IsItemSpecModifier(null)); // "test 67"
        }

        [Fact]
        public void CheckDerivableItemSpecModifiers()
        {
            Assert.True(FileUtilities.ItemSpecModifiers.IsDerivableItemSpecModifier("Filename"));
            Assert.False(FileUtilities.ItemSpecModifiers.IsDerivableItemSpecModifier("RecursiveDir"));
            Assert.False(FileUtilities.ItemSpecModifiers.IsDerivableItemSpecModifier("recursivedir"));
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathThatFitsIntoMaxPath()
        {
            string currentDirectory = @"c:\aardvark\aardvark\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890";
            string filePath = @"..\..\..\..\..\..\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\a.cs";
            string fullPath = @"c:\aardvark\aardvark\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\a.cs";

            Assert.Equal(fullPath, FileUtilities.NormalizePath(Path.Combine(currentDirectory, filePath)));
        }

#if FEATURE_LEGACY_GETFULLPATH
        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathThatDoesntFitIntoMaxPath()
        {
            Assert.Throws<PathTooLongException>(() =>
            {
                string currentDirectory = @"c:\aardvark\aardvark\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890";
                string filePath = @"..\..\..\..\..\..\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\a.cs";

                // This path ends up over 420 characters long
                string fullPath = @"c:\aardvark\aardvark\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\a.cs";

                Assert.Equal(fullPath, FileUtilities.NormalizePath(Path.Combine(currentDirectory, filePath)));
            }
           );
        }
#endif

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void GetItemSpecModifierRootDirThatFitsIntoMaxPath()
        {
            string currentDirectory = @"c:\aardvark\aardvark\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890";
            string fullPath = @"c:\aardvark\aardvark\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\1234567890\a.cs";
            string cache = fullPath;

            Assert.Equal(@"c:\", FileUtilities.ItemSpecModifiers.GetItemSpecModifier(currentDirectory, fullPath, String.Empty, FileUtilities.ItemSpecModifiers.RootDir, ref cache));
        }

        [Fact]
        public void NormalizePathNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Assert.Equal(null, FileUtilities.NormalizePath(null));
            }
           );
        }

        [Fact]
        public void NormalizePathEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Assert.Equal(null, FileUtilities.NormalizePath(String.Empty));
            }
           );
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathBadUNC1()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Assert.Equal(null, FileUtilities.NormalizePath(@"\\"));
            }
           );
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathBadUNC2()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Assert.Equal(null, FileUtilities.NormalizePath(@"\\XXX\"));
            }
           );
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathBadUNC3()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Assert.Equal(@"\\localhost", FileUtilities.NormalizePath(@"\\localhost"));
            }
           );
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathGoodUNC()
        {
            Assert.Equal(@"\\localhost\share", FileUtilities.NormalizePath(@"\\localhost\share"));
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathTooLongWithDots()
        {
            string longPart = new string('x', 300);
            Assert.Equal(@"c:\abc\def", FileUtilities.NormalizePath(@"c:\abc\" + longPart + @"\..\def"));
        }

#if FEATURE_LEGACY_GETFULLPATH
        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathBadGlobalroot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                /*
                 From Path.cs
                   // Check for \\?\Globalroot, an internal mechanism to the kernel
                   // that provides aliases for drives and other undocumented stuff.
                   // The kernel team won't even describe the full set of what
                   // is available here - we don't want managed apps mucking
                   // with this for security reasons.
                 * */
                Assert.Equal(null, FileUtilities.NormalizePath(@"\\?\globalroot\XXX"));
            }
           );
        }
#endif

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void NormalizePathInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string filePath = @"c:\aardvark\|||";
                Assert.Equal(null, FileUtilities.NormalizePath(filePath));
            }
           );
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void FileOrDirectoryExistsNoThrow()
        {
            Assert.Equal(false, FileUtilities.FileOrDirectoryExistsNoThrow("||"));
            Assert.Equal(false, FileUtilities.FileOrDirectoryExistsNoThrow("c:\\doesnot_exist"));
            Assert.Equal(true, FileUtilities.FileOrDirectoryExistsNoThrow("c:\\"));
            Assert.Equal(true, FileUtilities.FileOrDirectoryExistsNoThrow(Path.GetTempPath()));

            string path = null;

            try
            {
                path = FileUtilities.GetTemporaryFile();
                Assert.Equal(true, FileUtilities.FileOrDirectoryExistsNoThrow(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

#if FEATURE_ENVIRONMENT_SYSTEMDIRECTORY
        // These tests will need to be redesigned for Linux

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void FileOrDirectoryExistsNoThrowTooLongWithDots()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3)).Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = Environment.SystemDirectory + @"\" + longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3);
            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists
            Assert.Equal(true, FileUtilities.FileOrDirectoryExistsNoThrow(inputPath));
            Assert.Equal(false, FileUtilities.FileOrDirectoryExistsNoThrow(inputPath.Replace('\\', 'X')));
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void FileOrDirectoryExistsNoThrowTooLongWithDotsRelative()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3)).Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3);
            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists

            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(Environment.SystemDirectory);

                Assert.Equal(true, FileUtilities.FileOrDirectoryExistsNoThrow(inputPath));
                Assert.Equal(false, FileUtilities.FileOrDirectoryExistsNoThrow(inputPath.Replace('\\', 'X')));
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }

        [Fact]
        public void DirectoryExistsNoThrowTooLongWithDots()
        {
            string path = Path.Combine(Environment.SystemDirectory, "..", "..", "..") + Path.DirectorySeparatorChar;
            if (NativeMethodsShared.IsWindows)
            {
                path += Environment.SystemDirectory.Substring(3);
            }

            int length = path.Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = Path.Combine(new[] { Environment.SystemDirectory, longPart, "..", "..", ".." })
                               + Path.DirectorySeparatorChar;
            if (NativeMethodsShared.IsWindows)
            {
                path += Environment.SystemDirectory.Substring(3);
            }

            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists
            Assert.Equal(true, FileUtilities.DirectoryExistsNoThrow(inputPath));
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void DirectoryExistsNoThrowTooLongWithDotsRelative()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3)).Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3);
            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists

            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(Environment.SystemDirectory);

                Assert.Equal(true, FileUtilities.DirectoryExistsNoThrow(inputPath));
                Assert.Equal(false, FileUtilities.DirectoryExistsNoThrow(inputPath.Replace('\\', 'X')));
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void FileExistsNoThrowTooLongWithDots()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe").Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = Environment.SystemDirectory + @"\" + longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe";
            Console.WriteLine(inputPath.Length);
            Console.WriteLine(inputPath);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists
            Assert.Equal(true, FileUtilities.FileExistsNoThrow(inputPath));
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void FileExistsNoThrowTooLongWithDotsRelative()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe").Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe";
            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists

            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(Environment.SystemDirectory);

                Assert.Equal(true, FileUtilities.FileExistsNoThrow(inputPath));
                Assert.Equal(false, FileUtilities.FileExistsNoThrow(inputPath.Replace('\\', 'X')));
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void GetFileInfoNoThrowTooLongWithDots()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe").Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = Environment.SystemDirectory + @"\" + longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe";
            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists
            Assert.Equal(true, FileUtilities.GetFileInfoNoThrow(inputPath) != null);
            Assert.Equal(false, FileUtilities.GetFileInfoNoThrow(inputPath.Replace('\\', 'X')) != null);
        }

        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void GetFileInfoNoThrowTooLongWithDotsRelative()
        {
            int length = (Environment.SystemDirectory + @"\" + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe").Length;

            string longPart = new string('x', 260 - length); // We want the shortest that is > max path.

            string inputPath = longPart + @"\..\..\..\" + Environment.SystemDirectory.Substring(3) + @"\..\explorer.exe";
            Console.WriteLine(inputPath.Length);

            // "c:\windows\system32\<verylong>\..\..\windows\system32" exists

            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(Environment.SystemDirectory);

                Assert.Equal(true, FileUtilities.GetFileInfoNoThrow(inputPath) != null);
                Assert.Equal(false, FileUtilities.GetFileInfoNoThrow(inputPath.Replace('\\', 'X')) != null);
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }
#endif

        /// <summary>
        /// Simple test, neither the base file nor retry files exist
        /// </summary>
        [Fact]
        public void GenerateTempFileNameSimple()
        {
            string path = null;

            try
            {
                path = FileUtilities.GetTemporaryFile();

                Assert.Equal(true, path.EndsWith(".tmp"));
                Assert.Equal(true, File.Exists(path));
                Assert.Equal(true, path.StartsWith(Path.GetTempPath()));
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Choose an extension
        /// </summary>
        [Fact]
        public void GenerateTempFileNameWithExtension()
        {
            string path = null;

            try
            {
                path = Shared.FileUtilities.GetTemporaryFile(".bat");

                Assert.Equal(true, path.EndsWith(".bat"));
                Assert.Equal(true, File.Exists(path));
                Assert.Equal(true, path.StartsWith(Path.GetTempPath()));
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Choose a (missing) directory and extension
        /// </summary>
        [Fact]
        public void GenerateTempFileNameWithDirectoryAndExtension()
        {
            string path = null;
#if FEATURE_SPECIAL_FOLDERS
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "subfolder");
#else
            string directory = Path.Combine(FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.ApplicationData), "subfolder");
#endif

            try
            {
                path = Shared.FileUtilities.GetTemporaryFile(directory, ".bat");

                Assert.Equal(true, path.EndsWith(".bat"));
                Assert.Equal(true, File.Exists(path));
                Assert.Equal(true, path.StartsWith(directory));
            }
            finally
            {
                File.Delete(path);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Extension without a period
        /// </summary>
        [Fact]
        public void GenerateTempFileNameWithExtensionNoPeriod()
        {
            string path = null;

            try
            {
                path = Shared.FileUtilities.GetTemporaryFile("bat");

                Assert.Equal(true, path.EndsWith(".bat"));
                Assert.Equal(true, File.Exists(path));
                Assert.Equal(true, path.StartsWith(Path.GetTempPath()));
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Extension is invalid
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void GenerateTempBatchFileWithBadExtension()
        {
            Assert.Throws<IOException>(() =>
            {
                Shared.FileUtilities.GetTemporaryFile("|");
            }
           );
        }
        /// <summary>
        /// No extension is given
        /// </summary>
        [Fact]
        public void GenerateTempBatchFileWithEmptyExtension()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shared.FileUtilities.GetTemporaryFile(String.Empty);
            }
           );
        }
        /// <summary>
        /// Directory is invalid
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void GenerateTempBatchFileWithBadDirectory()
        {
            Assert.Throws<IOException>(() =>
            {
                Shared.FileUtilities.GetTemporaryFile("|", ".tmp");
            }
           );
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.AnyUnix)]
        public void AbsolutePathLooksLikeUnixPathOnUnix()
        {
            var secondSlash = SystemSpecificAbsolutePath.Substring(1).IndexOf(Path.DirectorySeparatorChar) + 1;
            var rootLevelPath = SystemSpecificAbsolutePath.Substring(0, secondSlash);

            Assert.True(FileUtilities.LooksLikeUnixFilePath(SystemSpecificAbsolutePath));
            Assert.True(FileUtilities.LooksLikeUnixFilePath(rootLevelPath));
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]
        public void PathDoesNotLookLikeUnixPathOnWindows()
        {
            Assert.False(FileUtilities.LooksLikeUnixFilePath(SystemSpecificAbsolutePath));
            Assert.False(FileUtilities.LooksLikeUnixFilePath("/path/that/looks/unixy"));
            Assert.False(FileUtilities.LooksLikeUnixFilePath("/root"));
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.AnyUnix)]
        public void RelativePathLooksLikeUnixPathOnUnixWithBaseDirectory()
        {
            string filePath = ObjectModelHelpers.CreateFileInTempProjectDirectory("first/second/file.txt", String.Empty);
            string oldCWD = Directory.GetCurrentDirectory();

            try
            {
                // <tmp_dir>/first
                string firstDirectory = Path.GetDirectoryName(Path.GetDirectoryName(filePath));
                string tmpDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(filePath)));

                Directory.SetCurrentDirectory(tmpDirectory);

                // We are in <tmp_dir> and second is not under that, so this will be false
                Assert.False(FileUtilities.LooksLikeUnixFilePath("second/file.txt"));

                // .. but if we have baseDirectory:firstDirectory, then it will be true
                Assert.True(FileUtilities.LooksLikeUnixFilePath("second/file.txt", firstDirectory));
            }
            finally
            {
                if (filePath != null)
                {
                    File.Delete(filePath);
                }
                Directory.SetCurrentDirectory(oldCWD);
            }
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.AnyUnix)]
        public void RelativePathMaybeAdjustFilePathWithBaseDirectory()
        {
            // <tmp_dir>/first/second/file.txt
            string filePath = ObjectModelHelpers.CreateFileInTempProjectDirectory("first/second/file.txt", String.Empty);
            string oldCWD = Directory.GetCurrentDirectory();

            try
            {
                // <tmp_dir>/first
                string firstDirectory = Path.GetDirectoryName(Path.GetDirectoryName(filePath));
                string tmpDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(filePath)));

                Directory.SetCurrentDirectory(tmpDirectory);

                // We are in <tmp_dir> and second is not under that, so this won't convert
                Assert.Equal("second\\file.txt", FileUtilities.MaybeAdjustFilePath("second\\file.txt"));

                // .. but if we have baseDirectory:firstDirectory, then it will
                Assert.Equal("second/file.txt", FileUtilities.MaybeAdjustFilePath("second\\file.txt", firstDirectory));
            }
            finally
            {
                if (filePath != null)
                {
                    File.Delete(filePath);
                }
                Directory.SetCurrentDirectory(oldCWD);
            }
        }

        private static string SystemSpecificAbsolutePath => FileUtilities.ExecutingAssemblyPath;


        [Fact]
        public void GetFolderAboveTest()
        {
            string root = NativeMethodsShared.IsWindows ? @"c:\" : "/";
            string path = Path.Combine(root, "1", "2", "3", "4", "5");

            Assert.Equal(Path.Combine(root, "1", "2", "3", "4", "5"), FileUtilities.GetFolderAbove(path, 0));
            Assert.Equal(Path.Combine(root, "1", "2", "3", "4"), FileUtilities.GetFolderAbove(path));
            Assert.Equal(Path.Combine(root, "1", "2", "3"), FileUtilities.GetFolderAbove(path, 2));
            Assert.Equal(Path.Combine(root, "1", "2"), FileUtilities.GetFolderAbove(path, 3));
            Assert.Equal(Path.Combine(root, "1"), FileUtilities.GetFolderAbove(path, 4));
            Assert.Equal(root, FileUtilities.GetFolderAbove(path, 5));
            Assert.Equal(root, FileUtilities.GetFolderAbove(path, 99));

            Assert.Equal(root, FileUtilities.GetFolderAbove(root, 99));
        }

        [Fact]
        public void CombinePathsTest()
        {
            // These tests run in .NET 4+, so we can cheat
            var root = @"c:\";

            Assert.Equal(
                Path.Combine(root, "path1"),
                FileUtilities.CombinePaths(root, "path1"));

            Assert.Equal(
                Path.Combine(root, "path1", "path2", "file.txt"),
                FileUtilities.CombinePaths(root, "path1", "path2", "file.txt"));
        }
    }
}
