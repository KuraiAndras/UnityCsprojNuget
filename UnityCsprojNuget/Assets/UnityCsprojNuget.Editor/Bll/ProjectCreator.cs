using System.IO;
using UnityCsprojNuget.Editor.Utility;

namespace UnityCsprojNuget.Editor.Bll
{
    public sealed class ProjectCreator : IProjectCreator
    {
        public void InitializeProject(string asmdefPath, bool overwrite)
        {
            var baseDirectory = new FileInfo(asmdefPath).DirectoryName;

            CreateFolderStructure(baseDirectory, overwrite);
            CreateDefaultFiles(baseDirectory, asmdefPath, overwrite);
        }

        private static void CreateFolderStructure(string baseDirectory, bool overwrite)
        {
            FileHelper.EnsureDirectoryCreated(Path.Combine(baseDirectory, NamesPaths.BaseFolder), overwrite);
            FileHelper.EnsureDirectoryCreated(Path.Combine(baseDirectory, NamesPaths.BaseFolder, "Nuget"), overwrite);
        }

        private static void CreateDefaultFiles(string baseDirectory, string asmdefPath, bool overwrite)
        {
            var nugetBase = Path.Combine(baseDirectory, NamesPaths.BaseFolder);

            FileHelper.EnsureFileCreated(NamesPaths.CreateCsprojPathFromAsmDefPath(asmdefPath), FileResources.DefaultCsproj, overwrite);
            FileHelper.EnsureFileCreated(Path.Combine(nugetBase, ".gitignore"), FileResources.ProjectGitIgnore, overwrite);
            FileHelper.EnsureFileCreated(Path.Combine(nugetBase, "Nuget", ".gitignore"), FileResources.DllGitIgnore, overwrite);
        }

        public static IProjectCreator CreateProjectCreator() => new ProjectCreator();
    }
}