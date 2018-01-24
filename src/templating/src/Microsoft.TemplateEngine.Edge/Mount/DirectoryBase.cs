﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.TemplateEngine.Abstractions.Mount;

namespace Microsoft.TemplateEngine.Edge.Mount
{
    public abstract class DirectoryBase : FileSystemInfoBase, IDirectory
    {
        protected DirectoryBase(IMountPoint mountPoint, string fullPath, string name)
            : base(mountPoint, fullPath, name, FileSystemInfoKind.Directory)
        {
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string pattern, SearchOption searchOption)
        {
            return EnumerateFileSystemInfos(pattern, searchOption).OfType<IDirectory>();
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string pattern, SearchOption searchOption)
        {
            return EnumerateFileSystemInfos(pattern, searchOption).OfType<IFile>();
        }

        public abstract IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string pattern, SearchOption searchOption);
    }
}
