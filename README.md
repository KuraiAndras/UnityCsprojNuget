# UnityCsprojNuget [![openupm](https://img.shields.io/npm/v/com.unitycsprojnuget?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.unitycsprojnuget/)

This project provides nuget support trough sdk-style csproj files in Unity, with a Unity Editor tool.

![Editor Window](/images/EditorWindow.png)

The editor utility can be started from the Unity Csproj / Open window menu item.

The project assumes that you are using asmdef in your project in a structure:

```
ProjectRoot/Assets/MyAwesomeProject/MyAwesomeProject.asmdef
ProjectRoot/Assets/MyAwesomeLibrary/MyAwesomeLibrary.asmdef
```

This might change in the future, but right now it is a recommended pattern nevertheless.

## How does it work?

The main idea is [this](https://kuraiandras.github.io/unity/2020/04/28/modern-unity/) blog post I wrote a while back. We are creating a .net framework project which we will use to generate the needed dlls, and then let Unity discover them. This project builds on that concepts, and automates the creation of the needed project file.

## How do I use it?

1. Install the dotnet core sdk, and make sure it is available in your PATH
2. Install the project through either [openupm](https://openupm.com/packages/com.unitycsprojnuget/) (this is recommended) or with the provided [unitypackage](https://github.com/KuraiAndras/UnityCsprojNuget/releases/latest). 
3. Launch the csproj window as shown on the above image
4. This window will enumerate through all of your asmdef files, and will let you create a csproj file for it's dependencies, and also place a folder named NugetDlls with a gitignore for the dlls and their meta files. The csproj is placed in a folder called .nuget which will be ignored by Unity. The project assumes that you are using a proper gitignore file when collaborating with others. If you do not want to use the provided gitignore files, then delete them after initialization.
5. Regenerate the Unity project files through Edit/Preferences/External Tools
6. Launch Visual Studio and add nuget packages to the generated project file, or use the dotnet cli tools
7. Build the generated project from either Visual Studio, the dotnet cli or through the provided Editor UI
8. (Optional) If you are using Visual Studio to debug then unload the generated projects from Visual Studio, so they do not interfere when attaching to Unity.
9. You are done!

## Additional stuff

- When Unity generates the solution files your nuget projects will be added to the solution. If you want to debug your Unity project you may need to unload them from the solution by right clicking on them in Visual Studio.
- If you want to use this in a CI-CD environment then you don't need to manually run dotnet build for the nuget projects. The project comes with an IPreprocessBuildWithReport which will do the same thing as the Build All button.
- Running the build command will replicate the output of the dotnet cli to the Unity Debug console.

## Gotchas
- Although it was not tested on Linux and MacOS building the generated projects should work via the .Net Framework reference assemblies, so a dotnet -build should just work.
- You only need to initialize a project once, when you set this up. Initializing again might override the packages you added.
- Tested with Unity version 2019.4 but other recent versions (2018+) should work
- The same gotchas are expected when just dealing with manually adding dlls
- Never forget that this project does nothing magical, it just automates the process of getting the needed dlls to be recognized with Unity