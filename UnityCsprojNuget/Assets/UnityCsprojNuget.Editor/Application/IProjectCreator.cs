using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public interface IProjectCreator
    {
        void InitializeProject(ProjectDescriptor project);
    }
}