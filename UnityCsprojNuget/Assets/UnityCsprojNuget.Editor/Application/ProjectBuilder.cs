using System.Diagnostics;
using System.IO;
using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Editor.Application
{
    public sealed class ProjectBuilder : IProjectBuilder
    {
        public static IProjectBuilder CreateProjectBuilder() => new ProjectBuilder();

        public void BuildProject(ProjectDescriptor project)
        {
#pragma warning disable IDE0062 // Make local function 'static'
            void WriteProcessError(object sender, DataReceivedEventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(e.Data)) UnityEngine.Debug.LogError(e.Data);
            }

            void WriteProcessOutput(object sender, DataReceivedEventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(e.Data)) UnityEngine.Debug.Log(e.Data);
            }
#pragma warning restore IDE0062 // Make local function 'static'

            var csprojPath = NamesPaths.CreateCsprojPathFromAsmDefPath(project.AsmdefPath);

            if (!File.Exists(csprojPath))
            {
                UnityEngine.Debug.LogWarning($"Skipping project file, because it does not exists: {csprojPath}");
                return;
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"build \"{csprojPath}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            var outputHandler = new DataReceivedEventHandler(WriteProcessOutput);
            var errorHandler = new DataReceivedEventHandler(WriteProcessError);

            UnityEngine.Debug.Log($"Starting {project.AsmdefPath} build");

            process.OutputDataReceived += outputHandler;
            process.ErrorDataReceived += errorHandler;

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            process.OutputDataReceived -= outputHandler;
            process.ErrorDataReceived -= errorHandler;

            UnityEngine.Debug.Log($"Finished {project.AsmdefPath} build");
        }
    }
}