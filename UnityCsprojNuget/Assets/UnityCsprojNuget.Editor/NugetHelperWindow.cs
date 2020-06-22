using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor
{
    public sealed class NugetHelperWindow : EditorWindow
    {
        private string _fileName = string.Empty;
        private bool _overwrite = false;


        [MenuItem("Unity Csproj / Open Window")]
        public static void OpenWindow() => GetWindow<NugetHelperWindow>();

        private static IProjectCreator CreateProjectCreator() => new ProjectCreator();

        private void OnGUI()
        {
            GUILayout.Label(_fileName);

            if (GUILayout.Button("Select you asmdef file")) _fileName = EditorUtility.OpenFilePanel("Select project", Directory.GetCurrentDirectory(), "asmdef");

            var fileSet = File.Exists(_fileName);

            if (fileSet) _overwrite = GUILayout.Toggle(_overwrite, "Override files");

            if (fileSet && GUILayout.Button("Initialize")) OnInitializeClicked();
        }

        private void OnInitializeClicked() => CreateProjectCreator().InitializeProject(_fileName, _overwrite);
    }
}
