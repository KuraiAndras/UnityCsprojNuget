using System.IO;
using System.Linq;
using UnityCsprojNuget.Editor.Domain;
using UnityCsprojNuget.Editor.Extensions;

namespace UnityCsprojNuget.Editor.Application
{
    public sealed class OptionsApplier : IOptionsApplier
    {
        public void ApplyOptions(NugetOptions options)
        {
            Directory
                .GetFiles(Directory.GetCurrentDirectory())
                .Where(d => d.EndsWith(".sln") || d.EndsWith(".csproj"))
                .ForEach(File.Delete);

            UnityEditor.EditorApplication.ExecuteMenuItem("Assets/Open C# Project");
        }

        public static IOptionsApplier CreateDefault() => new OptionsApplier();
    }
}