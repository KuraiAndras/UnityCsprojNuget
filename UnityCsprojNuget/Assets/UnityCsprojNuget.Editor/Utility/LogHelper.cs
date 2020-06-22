using UnityEngine;

namespace UnityCsprojNuget.Editor.Utility
{
    internal static class LogHelper
    {
        internal static void LogDirectoryCreation(string directoryPath) => Debug.Log($"Created Directory {directoryPath}");
        internal static void LogFileCreation(string filePath) => Debug.Log($"Created file {filePath}");
    }
}