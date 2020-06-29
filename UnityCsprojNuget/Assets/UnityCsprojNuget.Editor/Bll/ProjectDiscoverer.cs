using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityCsprojNuget.Editor.Bll.Entities;

namespace UnityCsprojNuget.Editor.Bll
{
    public sealed class ProjectDiscoverer : IProjectDiscoverer
    {
        public IEnumerable<ProjectDescriptor> FindAsmdefPaths() =>
            Directory
                .GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Assets"), "*.asmdef", SearchOption.AllDirectories)
                .Select(ProjectDescriptor.Default);

        public static IProjectDiscoverer CreateProjectDiscoverer() => new ProjectDiscoverer();
    }
}