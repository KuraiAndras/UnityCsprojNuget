using System.Linq;
using UnityCsprojNuget.Editor.Bll;
using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor.Ui
{
    public sealed class NugetHelperWindow : EditorWindow
    {
        private (string asmdefPath, bool overwrite)[] _projects = new (string asmdefPath, bool overwrite)[0];

        [MenuItem("Unity Csproj / Open Window")]
        public static void OpenWindow() => GetWindow<NugetHelperWindow>();

        private void Awake() => DiscoverProjects();

        private void OnGUI()
        {
            if (GUILayout.Button("Search for asmdef")) DiscoverProjects();

            GuiLayoutHelper.DrawUiLine(Color.black);

            for (var i = 0; i < _projects.Length; i++)
            {
                var (asmdefPath, overwrite) = _projects[i];

                GUILayout.Label(asmdefPath);

                _projects[i].overwrite = GUILayout.Toggle(overwrite, "Override files");

                if (GUILayout.Button("Initialize")) InitializeProject(asmdefPath, overwrite);

                if (GUILayout.Button("Build")) BuildProject(asmdefPath);

                GuiLayoutHelper.DrawUiLine(Color.black);
            }
        }

        private static void InitializeProject(string asmdefPath, bool overwrite) => ProjectCreator.CreateProjectCreator().InitializeProject(asmdefPath, overwrite);

        private static void BuildProject(string asmdefPath) => ProjectBuilder.CreateProjectBuilder().BuildProject(asmdefPath);

        private void DiscoverProjects() => _projects = ProjectDiscoverer.CreateProjectDiscoverer().FindAsmdefPaths().Select(p => (p, true)).ToArray();
    }
}
