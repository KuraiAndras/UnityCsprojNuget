using System.Diagnostics;
using System.IO;

namespace UnityCsprojNuget.Editor.Bll
{
    public sealed class ProjectBuilder : IProjectBuilder
    {
        public static IProjectBuilder CreateProjectBuilder() => new ProjectBuilder();

        public void BuildProject(string asmdefPath)
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

            var csprojPath = NamesPaths.CreateCsprojPathFromAsmDefPath(asmdefPath);

            if (!File.Exists(csprojPath)) throw new FileNotFoundException(csprojPath);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"build {csprojPath}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            var outputHandler = new DataReceivedEventHandler(WriteProcessOutput);
            var errorHandler = new DataReceivedEventHandler(WriteProcessError);

            UnityEngine.Debug.Log($"Starting {asmdefPath} build");

            process.OutputDataReceived += outputHandler;
            process.ErrorDataReceived += errorHandler;

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            process.OutputDataReceived -= outputHandler;
            process.ErrorDataReceived -= errorHandler;

            UnityEngine.Debug.Log($"Finished {asmdefPath} build");
        }
    }
}