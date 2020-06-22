using System.IO;

namespace UnityCsprojNuget.Editor.Utility
{
    public static class FileHelper
    {
        public static void EnsureDirectoryCreated(string path, bool overwrite = false)
        {
            var directoryExists = Directory.Exists(path);

            if (overwrite && directoryExists) Directory.Delete(path, true);

            if (directoryExists) return;

            Directory.CreateDirectory(path);
            LogHelper.LogDirectoryCreation(path);
        }

        public static void EnsureFileCreated(string path, string defaultContent = null, bool overwrite = false)
        {
            if (overwrite) File.Delete(path);

            if (File.Exists(path)) return;

            File.WriteAllText(path, defaultContent ?? string.Empty);
            LogHelper.LogFileCreation(path);
        }
    }
}
