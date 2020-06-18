using UnityEngine;

namespace UnityCsprojNuget.Editor
{
    internal static class LogHelper
    {
        internal static void LogDirectoryCreation(string directoryPath) => Debug.Log($"Created Directory {directoryPath}");
        internal static void LogFileCreation(string filePath) => Debug.Log($"Created file {filePath}");
    }
}