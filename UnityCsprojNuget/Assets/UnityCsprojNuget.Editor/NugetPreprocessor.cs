using UnityCsprojNuget.Editor.Bll;
using UnityCsprojNuget.Editor.Extensions;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UnityCsprojNuget.Editor
{
    public sealed class NugetPreprocessor : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }

        public void OnPreprocessBuild(BuildReport report) => BuildAllProjects();

        public static void BuildAllProjects() =>
            ProjectDiscoverer
                .CreateProjectDiscoverer()
                .FindAsmdefPaths()
                .ForEach(p => ProjectBuilder
                    .CreateProjectBuilder()
                    .BuildProject(p));
    }
}
