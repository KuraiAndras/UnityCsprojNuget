namespace UnityCsprojNuget.Editor
{
    public static class FileResources
    {
        public const string DefaultCsproj =
            "<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n  <PropertyGroup>\r\n    <TargetFramework>net471</TargetFramework>\r\n  </PropertyGroup>\r\n\r\n  <ItemGroup>\r\n    <PackageReference Include=\"Microsoft.NETFramework.ReferenceAssemblies\" Version=\"1.0.0\" />\r\n  </ItemGroup>\r\n\r\n  <Target Name=\"Copy DLLs\" AfterTargets=\"AfterBuild\">\r\n    <Delete Files=\"$(OutDir)/$(MSBuildProjectName).dll\"/>\r\n    <Delete Files=\"$(OutDir)/$(MSBuildProjectName).pdb\"/>\r\n\r\n    <RemoveDir Directories=\"$(MSBuildProjectDirectory)/../NugetDlls\"/>\r\n\r\n    <CreateItem Include=\"$(OutDir)/**/*\">\r\n      <Output ItemName=\"AllOutDirFiles\" TaskParameter=\"Include\" />\r\n    </CreateItem>\r\n    <Copy SourceFiles=\"@(AllOutDirFiles)\" DestinationFolder=\"$(MSBuildProjectDirectory)/../NugetDlls\" />\r\n  </Target>\r\n\r\n</Project>\r\n";

        public const string DefaultGitIgnore = "!*.csproj";
    }
}
