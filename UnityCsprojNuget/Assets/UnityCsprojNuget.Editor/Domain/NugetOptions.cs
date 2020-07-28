using System.IO;

namespace UnityCsprojNuget.Editor.Domain
{
    public sealed class NugetOptions
    {
        public bool AddProjectsToSolution { get; set; }

        public static string CreateDefaultPath() => Path.Combine(Directory.GetCurrentDirectory(), "NugetOptions.xml");
    }
}
