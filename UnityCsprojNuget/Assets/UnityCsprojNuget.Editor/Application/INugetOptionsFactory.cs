using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public interface INugetOptionsFactory
    {
        void Save(NugetOptions options);
        NugetOptions LoadFromFile();
    }
}
