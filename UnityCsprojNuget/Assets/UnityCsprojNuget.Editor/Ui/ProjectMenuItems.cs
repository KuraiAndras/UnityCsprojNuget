using UnityCsprojNuget.Editor.Application;
using UnityEditor;

namespace UnityCsprojNuget.Editor.Ui
{
    public static class ProjectMenuItems
    {
        [MenuItem("Unity Csproj / Open Options")]
        public static void OpenWindow() => NugetHelperWindow.CreateDefault();

        [MenuItem("Unity Csproj / Regenerate Project files")]
        public static void RegenerateProjectFiles() => ProjectRegenerator.CreateDefault().RegenerateProject();
    }
}