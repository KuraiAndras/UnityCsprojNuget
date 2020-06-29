using UnityEngine;

namespace UnityCsprojNuget.Editor.Utility
{
    public static class LogHelper
    {
        public static void LogDirectoryCreation(string directoryPath) => Debug.Log($"Created Directory {directoryPath}");
        public static void LogFileCreation(string filePath) => Debug.Log($"Created file {filePath}");
    }
}