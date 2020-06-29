using System.Linq;
using UnityCsprojNuget.Editor.Bll;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UnityCsprojNuget.Editor
{
    public sealed class NugetPreprocessor : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }

        public void OnPreprocessBuild(BuildReport report) => BuildAllProjects();

        public static void BuildAllProjects()
        {
            var projects = ProjectDiscoverer.CreateProjectDiscoverer().FindAsmdefPaths().ToArray();

            foreach (var asmdefPath in projects)
            {
                ProjectBuilder.CreateProjectBuilder().BuildProject(asmdefPath);
            }
        }
    }
}
