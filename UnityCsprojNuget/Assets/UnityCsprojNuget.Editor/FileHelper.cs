using System.IO;

namespace UnityCsprojNuget.Editor
{
    internal static class FileHelper
    {
        public static void CreateFolderStructure(string baseDirectory)
        {
            EnsureDirectoryCreated(Path.Combine(baseDirectory, RelativeDirectoryPaths.BaseFolder));
        }

        public static void CreateDefaultFiles(string baseDirectory, string asmdefName)
        {
            var nugetBase = Path.Combine(baseDirectory, RelativeDirectoryPaths.BaseFolder);

            EnsureFileCreated(Path.Combine(nugetBase, asmdefName + ".Nuget.csproj"), FileResources.DefaultCsproj);
            EnsureFileCreated(Path.Combine(nugetBase, ".gitignore"), FileResources.DefaultGitIgnore);
        }

        private static void EnsureDirectoryCreated(string path)
        {
            if (Directory.Exists(path)) return;

            Directory.CreateDirectory(path);
            LogHelper.LogDirectoryCreation(path);
        }

        private static void EnsureFileCreated(string path, string defaultContent = null)
        {
            if (File.Exists(path)) return;

            File.WriteAllText(path, defaultContent ?? string.Empty);
            LogHelper.LogFileCreation(path);
        }
    }
}
