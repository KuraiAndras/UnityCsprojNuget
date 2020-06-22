using System.IO;

namespace UnityCsprojNuget.Editor.Bll
{
    public sealed class ProjectDiscoverer : IProjectDiscoverer
    {
        public string[] FindAsmdefPaths() =>
            Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Assets"), "*.asmdef", SearchOption.AllDirectories);
    }
}