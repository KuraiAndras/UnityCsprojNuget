using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public sealed class OptionsApplier : IOptionsApplier
    {
        private readonly IProjectRegenerator _projectRegenerator;

        public OptionsApplier(IProjectRegenerator projectRegenerator) => _projectRegenerator = projectRegenerator;

        public void ApplyOptions(NugetOptions options) => _projectRegenerator.RegenerateProject();

        public static IOptionsApplier CreateDefault() => new OptionsApplier(ProjectRegenerator.CreateDefault());
    }
}