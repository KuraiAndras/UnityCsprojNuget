using System.Collections.Generic;
using UnityCsprojNuget.Editor.Bll.Entities;

namespace UnityCsprojNuget.Editor.Bll
{
    public interface IProjectDiscoverer
    {
        IEnumerable<ProjectDescriptor> FindAsmdefPaths();
    }
}