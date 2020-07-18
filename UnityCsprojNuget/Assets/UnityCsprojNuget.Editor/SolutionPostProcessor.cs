﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityCsprojNuget.Editor.Application;
using UnityEditor;

namespace UnityCsprojNuget.Editor
{
    public sealed class SolutionPostProcessor : AssetPostprocessor
    {
        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once Unity.IncorrectMethodSignature
#pragma warning disable IDE0051 // Remove unused private members
        public static string OnGeneratedSlnSolution(string _, string content)
        {
            var options = NugetOptionsFactory.CreateDefault().LoadFromFile();

            var projects = ProjectDiscoverer.CreateProjectDiscoverer().FindAsmdefPaths().ToArray();

            if (!options.AddProjectsToSolution)
            {
                var sb = new StringBuilder();

                var projectGuids = new List<Guid>();
                using (var reader = new StringReader(content))
                {
                    string line;
                    while (!((line = reader.ReadLine()) is null))
                    {
                        if (!projects.Any(project => line.Contains(NamesPaths.CreateCsprojPathFromAsmDefPath(project.AsmdefPath)))) continue;

                        var guidString = line.Substring(line.Length - Guid.Empty.ToString().Length - 2, line.Length - 2);

                        projectGuids.Add(Guid.Parse(guidString));

                        break;
                    }
                }

                using (var reader = new StringReader(content))
                {
                    string line;
                    while (!((line = reader.ReadLine()) is null))
                    {
                        if (!projectGuids.Any(g => line.Contains(g.ToString()))) sb.AppendLine(line);
                    }
                }

                return content;
            }

#pragma warning disable IDE0063 // Use simple 'using' statement
            using (var reader = new StringReader(content))
            {
                var sb = new StringBuilder();

                string line;
                var projectGuids = new List<Guid>();
                while (!((line = reader.ReadLine()) is null))
                {
                    sb.AppendLine(line);

                    if (line.Contains("# Visual Studio 15"))
                    {
                        foreach (var project in projects)
                        {
                            var csprojPath = NamesPaths.CreateCsprojPathFromAsmDefPath(project.AsmdefPath);

                            if (!File.Exists(csprojPath) || csprojPath.EndsWith(".sln")) continue;

                            var nugetProjectName = new FileInfo(csprojPath).Name.Replace(".asmdef", ".Nuget");

                            if (content.Contains(nugetProjectName)) continue;

                            var projectGuid = Guid.NewGuid();

                            var lineToAdd = $"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{nugetProjectName}\", \"{csprojPath}\", \"{{{projectGuid}}}\"";

                            if (content.Contains(lineToAdd)) continue;

                            sb.AppendLine(lineToAdd);
                            sb.AppendLine("EndProject");

                            projectGuids.Add(projectGuid);
                        }
                    }
                    else if (line.Contains("GlobalSection(ProjectConfigurationPlatforms) = postSolution"))
                    {
                        foreach (var addedGuid in projectGuids)
                        {
                            var firstLine = $"		{{{addedGuid}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU";

                            if (content.Contains(firstLine)) continue;

                            sb.AppendLine(firstLine);
                            sb.AppendLine($"		{{{addedGuid}}}.Debug|Any CPU.Build.0 = Debug|Any CPU");
                            sb.AppendLine($"		{{{addedGuid}}}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                            sb.AppendLine($"		{{{addedGuid}}}.Release|Any CPU.Build.0 = Release|Any CPU");
                        }
                    }
                }

                return sb.ToString();
            }
#pragma warning restore IDE0063 // Use simple 'using' statement
        }
#pragma warning restore IDE0051 // Remove unused private members
    }
}