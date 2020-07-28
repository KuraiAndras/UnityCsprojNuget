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
        private readonly Color _lineColor = Color.black;

        private NugetOptions _options = new NugetOptions();

        private ProjectDescriptor[] _projects = new ProjectDescriptor[0];

        private void Awake()
        {
            DiscoverProjects();
            _options = NugetOptionsFactory.CreateDefault().LoadFromFile();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Search for asmdef projects")) DiscoverProjects();

            GuiLayoutHelper.DrawUiHorizontalLine(_lineColor);

            foreach (var project in _projects)
            {
                GuiLayoutHelper.LabelCentered(project.ProjectName);

                GuiLayoutHelper.LabelCentered(project.AsmdefPath);

                GuiLayoutHelper.InHorizontal(() =>
                {
                    project.OverWrite = GUILayout.Toggle(project.OverWrite, "Overwrite files");
                    if (GUILayout.Button("Initialize")) InitializeProject(project);
                });

                if (GUILayout.Button("Generate DLLs")) BuildProject(project);

                GuiLayoutHelper.DrawUiHorizontalLine(_lineColor);
            }

            if (_projects.Length > 1)
            {
                GuiLayoutHelper.LabelCentered("All projects");

                GuiLayoutHelper.InHorizontal(() =>
                {
                    if (GUILayout.Button("Generate DLLs")) BuildAll();
                    if (GUILayout.Button("Initialize")) InitializeAll();
                });

                GuiLayoutHelper.DrawUiHorizontalLine(_lineColor);
            }

            GuiLayoutHelper.LabelCentered("Utility");

            if (GUILayout.Button("Regenerate project files")) RegenerateProjectFiles();

            GuiLayoutHelper.DrawUiHorizontalLine(_lineColor);

            GuiLayoutHelper.LabelCentered("Settings");

            _options.AddProjectsToSolution = GUILayout.Toggle(_options.AddProjectsToSolution, "Add projects to solution");

            if (GUILayout.Button("Save settings")) SaveSettings();
        }

        private void BuildAll() => _projects.ForEach(BuildProject);

        private void InitializeAll() => _projects.ForEach(InitializeProject);

        private void DiscoverProjects() => _projects = ProjectDiscoverer.CreateProjectDiscoverer().FindAsmdefPaths().ToArray();

        private void SaveSettings()
        {
            NugetOptionsFactory.CreateDefault().Save(_options);
            OptionsApplier.CreateDefault().ApplyOptions(_options);
        }

        private static void InitializeProject(ProjectDescriptor project) => ProjectCreator.CreateProjectCreator().InitializeProject(project);

        private static void BuildProject(ProjectDescriptor project) => ProjectBuilder.CreateProjectBuilder().BuildProject(project);

        private static void RegenerateProjectFiles() => ProjectRegenerator.CreateDefault().RegenerateProject();
    }
}
