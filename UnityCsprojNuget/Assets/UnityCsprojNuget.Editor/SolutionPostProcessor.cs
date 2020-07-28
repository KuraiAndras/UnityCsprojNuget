using UnityCsprojNuget.Editor.Application;
using UnityEditor;

namespace UnityCsprojNuget.Editor
{
    public sealed class SolutionPostProcessor : AssetPostprocessor
    {
        public static string OnGeneratedSlnSolution(string _, string content)
        {
            var options = NugetOptionsFactory.CreateDefault().LoadFromFile();

            return SolutionProcessor.CreateDefault(options).ProcessSolutionFile(content);
        }
    }
}