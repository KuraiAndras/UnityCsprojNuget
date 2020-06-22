using System.IO;

namespace UnityCsprojNuget.Editor
{
    internal sealed class ProjectCreator : IProjectCreator
    {
        public void InitializeProject(string asmFileName, bool overwrite)
        {
            var baseDirectory = new FileInfo(asmFileName).DirectoryName;

            CreateFolderStructure(baseDirectory, overwrite);
            CreateDefaultFiles(baseDirectory, Path.GetFileNameWithoutExtension(new FileInfo(asmFileName).FullName), overwrite);
        }

        private static void CreateFolderStructure(string baseDirectory, bool overwrite)
        {
            FileHelper.EnsureDirectoryCreated(Path.Combine(baseDirectory, RelativeDirectoryPaths.BaseFolder), overwrite);
            FileHelper.EnsureDirectoryCreated(Path.Combine(baseDirectory, RelativeDirectoryPaths.BaseFolder, "Nuget"), overwrite);
        }

        private static void CreateDefaultFiles(string baseDirectory, string asmdefName, bool overwrite)
        {
            var nugetBase = Path.Combine(baseDirectory, RelativeDirectoryPaths.BaseFolder);

            FileHelper.EnsureFileCreated(Path.Combine(nugetBase, asmdefName + ".Nuget.csproj"), FileResources.DefaultCsproj, overwrite);
            FileHelper.EnsureFileCreated(Path.Combine(nugetBase, ".gitignore"), FileResources.ProjectGitIgnore, overwrite);
            FileHelper.EnsureFileCreated(Path.Combine(nugetBase, "Nuget", ".gitignore"), FileResources.DllGitIgnore, overwrite);
        }
    }
}