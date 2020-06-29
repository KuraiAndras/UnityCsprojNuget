using UnityCsprojNuget.Editor.Bll.Entities;

namespace UnityCsprojNuget.Editor.Bll
{
    public interface IProjectCreator
    {
        void InitializeProject(ProjectDescriptor project);
    }
}