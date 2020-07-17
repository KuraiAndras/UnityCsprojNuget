using System.Linq;
using UnityCsprojNuget.Editor.Application;
using UnityCsprojNuget.Editor.Domain;
using UnityCsprojNuget.Editor.Extensions;
using UnityEditor;
using UnityEngine;

namespace UnityCsprojNuget.Editor.Ui
{
    public sealed class NugetHelperWindow : EditorWindow
    {
        private NugetOptions _options = new NugetOptions();

        private ProjectDescriptor[] _projects = new ProjectDescriptor[0];

        [MenuItem("Unity Csproj / Open Window")]
        public static void OpenWindow() => GetWindow<NugetHelperWindow>();

        private void Awake()
        {
            DiscoverProjects();
            _options = NugetOptionsFactory.CreateDefault().LoadFromFile();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Search for asmdef")) DiscoverProjects();

            GuiLayoutHelper.DrawUiHorizontalLine(Color.black);

            foreach (var project in _projects)
            {
                GuiLayoutHelper.LabelCentered(project.ProjectName);

                GuiLayoutHelper.LabelCentered(project.AsmdefPath);

                project.OverWrite = GUILayout.Toggle(project.OverWrite, "Overwrite files");

                GuiLayoutHelper.InHorizontal(() =>
                {
                    if (GUILayout.Button("Generate DLLs")) BuildProject(project);
                    if (GUILayout.Button("Initialize")) InitializeProject(project);
                });

                GuiLayoutHelper.DrawUiHorizontalLine(Color.black);
            }

            if (_projects.Length > 1)
            {
                GuiLayoutHelper.LabelCentered("All projects");

                GuiLayoutHelper.InHorizontal(() =>
                {
                    if (GUILayout.Button("Generate DLLs")) BuildAll();
                    if (GUILayout.Button("Initialize")) InitializeAll();
                });

                GuiLayoutHelper.DrawUiHorizontalLine(Color.black);
            }

            GuiLayoutHelper.LabelCentered("Settings");

            _options.AddProjectsToSolution = GUILayout.Toggle(_options.AddProjectsToSolution, "Add projects to solution");

            if (GUILayout.Button("Save settings")) NugetOptionsFactory.CreateDefault().Save(_options);
        }

        private void BuildAll() => _projects.ForEach(BuildProject);

        private void InitializeAll() => _projects.ForEach(InitializeProject);

        private static void InitializeProject(ProjectDescriptor project) => ProjectCreator.CreateProjectCreator().InitializeProject(project);

        private static void BuildProject(ProjectDescriptor project) => ProjectBuilder.CreateProjectBuilder().BuildProject(project);

        private void DiscoverProjects() => _projects = ProjectDiscoverer.CreateProjectDiscoverer().FindAsmdefPaths().ToArray();
    }
}
