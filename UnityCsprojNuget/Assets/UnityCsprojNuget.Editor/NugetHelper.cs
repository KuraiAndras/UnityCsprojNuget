using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor
{
    public sealed class InitializeWindow : EditorWindow
    {
        private string _fileName = string.Empty;

        [MenuItem("Unity Csproj")]
        public static void OpenWindow() => GetWindow<InitializeWindow>();

        private void OnGUI()
        {
            GUILayout.Label(_fileName);

            if (GUILayout.Button("Select you asmdef file")) _fileName = EditorUtility.OpenFilePanel("Select project", Directory.GetCurrentDirectory(), "asmdef");

            if (File.Exists(_fileName) && GUILayout.Button("Initialize")) InitializeProject();
        }

        private void InitializeProject()
        {
            var baseDirectory = new FileInfo(_fileName).DirectoryName;

            FileHelper.CreateFolderStructure(baseDirectory);
            FileHelper.CreateDefaultFiles(baseDirectory, Path.GetFileNameWithoutExtension(new FileInfo(_fileName).FullName));
        }
    }
}
