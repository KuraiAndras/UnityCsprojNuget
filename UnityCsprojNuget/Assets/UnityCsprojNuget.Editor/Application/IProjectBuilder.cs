using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public interface IProjectBuilder
    {
        void BuildProject(ProjectDescriptor project);
    }
}