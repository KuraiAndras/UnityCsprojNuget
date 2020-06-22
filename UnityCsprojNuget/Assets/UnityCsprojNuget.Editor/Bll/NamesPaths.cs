using System.IO;

namespace UnityCsprojNuget.Editor.Bll
{
    public static class NamesPaths
    {
        public const string BaseFolder = ".nuget";

        // ReSharper disable once AssignNullToNotNullAttribute
        public static string CreateCsprojPathFromAsmDefPath(string asmdefPath) =>
            Path.Combine(
                Path.Combine(new FileInfo(asmdefPath).DirectoryName, BaseFolder),
                Path.GetFileNameWithoutExtension(new FileInfo(asmdefPath).FullName) + ".Nuget.csproj");
    }
}