using System.Linq;
using UnityCsprojNuget.Editor.Bll;
using UnityCsprojNuget.Editor.Bll.Entities;
using UnityCsprojNuget.Editor.Extensions;
using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor.Ui
{
    public sealed class NugetHelperWindow : EditorWindow
    {
        private ProjectDescriptor[] _projects = new ProjectDescriptor[0];

        [MenuItem("Unity Csproj / Open Window")]
        public static void OpenWindow() => GetWindow<NugetHelperWindow>();

        private void Awake() => DiscoverProjects();

        private void OnGUI()
        {
            if (GUILayout.Button("Search for asmdef")) DiscoverProjects();

            GuiLayoutHelper.DrawUiLine(Color.black);

            foreach (var project in _projects)
            {
                GUILayout.Label(project.AsmdefPath);

                project.OverWrite = GUILayout.Toggle(project.OverWrite, "Overwrite files");

                if (GUILayout.Button("Initialize")) InitializeProject(project);

                if (GUILayout.Button("Build")) BuildProject(project);

                GuiLayoutHelper.DrawUiLine(Color.black);
            }

            if (_projects.Length <= 1) return;

            if (GUILayout.Button("Initialize All")) InitializeAll();
            if (GUILayout.Button("Build All")) BuildAll();
        }

        private void BuildAll() => _projects.ForEach(BuildProject);

        private void InitializeAll() => _projects.ForEach(InitializeProject);

        private static void InitializeProject(ProjectDescriptor project) => ProjectCreator.CreateProjectCreator().InitializeProject(project);

        private static void BuildProject(ProjectDescriptor project) => ProjectBuilder.CreateProjectBuilder().BuildProject(project);

        private void DiscoverProjects() => _projects = ProjectDiscoverer.CreateProjectDiscoverer().FindAsmdefPaths().ToArray();
    }
}
