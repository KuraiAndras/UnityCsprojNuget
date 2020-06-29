using UnityCsprojNuget.Editor.Bll.Entities;

namespace UnityCsprojNuget.Editor.Bll
{
    public interface IProjectBuilder
    {
        void BuildProject(ProjectDescriptor project);
    }
}