using System.IO;
using System.Linq;
using UnityCsprojNuget.Editor.Extensions;

namespace UnityCsprojNuget.Editor.Application
{
    public sealed class ProjectRegenerator : IProjectRegenerator
    {
        public void RegenerateProject()
        {
            Directory
                .GetFiles(Directory.GetCurrentDirectory())
                .Where(d => d.EndsWith(".sln") || d.EndsWith(".csproj"))
                .ForEach(File.Delete);

            UnityEditor.EditorApplication.ExecuteMenuItem("Assets/Open C# Project");
        }

        public static IProjectRegenerator CreateDefault() => new ProjectRegenerator();
    }
}