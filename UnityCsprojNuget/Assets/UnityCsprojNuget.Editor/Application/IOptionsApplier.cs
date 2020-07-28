using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public interface IOptionsApplier
    {
        void ApplyOptions(NugetOptions options);
    }
}