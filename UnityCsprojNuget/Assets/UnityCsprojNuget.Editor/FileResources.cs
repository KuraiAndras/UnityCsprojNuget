namespace UnityCsprojNuget.Editor
{
    public static class FileResources
    {
        public const string DefaultCsproj =
            "<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n  <PropertyGroup>\r\n    <TargetFramework>net471</TargetFramework>\r\n  </PropertyGroup>\r\n\r\n  <ItemGroup >\r\n    <PackageReference Include=\"Microsoft.NETFramework.ReferenceAssemblies\" Version=\"1.0.0\" />\r\n  </ItemGroup>\r\n\r\n</Project>\r\n";

        public const string DefaultGitIgnore = "!*.csproj";
    }
}
