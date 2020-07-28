using System.Collections.Generic;
using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public interface IProjectDiscoverer
    {
        IEnumerable<ProjectDescriptor> FindAsmdefPaths();
    }
}