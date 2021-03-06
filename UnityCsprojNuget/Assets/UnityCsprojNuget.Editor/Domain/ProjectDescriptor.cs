﻿using System.IO;

namespace UnityCsprojNuget.Editor.Domain
{
    public sealed class ProjectDescriptor
    {
        public ProjectDescriptor(string asmdefPath, bool overWrite)
        {
            AsmdefPath = asmdefPath;
            OverWrite = overWrite;
        }

        public string AsmdefPath { get; set; }
        public bool OverWrite { get; set; }

        public string ProjectName => Path.GetFileNameWithoutExtension(AsmdefPath);

        public static ProjectDescriptor Default(string path = null) => new ProjectDescriptor(path ?? string.Empty, false);
        public bool IsDefault() => AsmdefPath == string.Empty;
    }
}