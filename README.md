# UnityCsprojNuget [![openupm](https://img.shields.io/npm/v/com.kuraiandras.unitycsprojnuget?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.kuraiandras.unitycsprojnuget/)

This project provides nuget support trough sdk-style csproj files in Unity, with a Unity Editor tool.

![Editor Window](/images/EditorWindow.png)

The editor utility can be started from the Unity Csproj / Open window menu item.

The project assumes that you are using asmdef in your project in a structure:

```
ProjectRoot/Assets/MyAwesomeProject/MyAwesomeProject.asmdef
ProjectRoot/Assets/MyAwesomeLibrary/MyAwesomeLibrary.asmdef
```

This might change in the future, but right now it is a recommended pattern nevertheless.

## Why this and not [NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity)

Although NugetForUnity is a great project, it has several constraints:

- Can't easily use specific nuget versions through nugget.org
- It still has problems with downloading the required dlls [1](https://github.com/GlitchEnzo/NuGetForUnity/issues/325) [2](https://github.com/GlitchEnzo/NuGetForUnity/issues/320) [3](https://github.com/GlitchEnzo/NuGetForUnity/issues/318)
- If you are working on other projects the generated csproj file can be used to directly reference them making it easier to work with projects not directly targeting Unity. Just add a reference to it.

## How does it work?

The main idea is [this](https://kuraiandras.github.io/unity/2020/04/28/modern-unity/) blog post I wrote a while back. We are creating a .net framework project which we will use to generate the needed dlls, and then let Unity discover them. This project builds on that concepts, and automates the creation of the needed project file.

## How do I use it?

1. Install the dotnet core sdk, and make sure it is available in your PATH
2. Install the project through either [openupm](https://openupm.com/packages/com.kuraiandras.unitycsprojnuget/) (this is recommended) or with the provided [unitypackage](https://github.com/KuraiAndras/UnityCsprojNuget/releases/latest). 
3. Launch the csproj window as shown on the above image
4. This window will enumerate through all of your asmdef files, and will let you create a csproj file for it's dependencies, and also place a folder named NugetDlls with a gitignore for the dlls and their meta files. The csproj is placed in a folder called .nuget which will be ignored by Unity. If you do not want to use the provided gitignore files, then delete them after initialization.
5. Regenerate the Unity project files through either the "Regenerate project file" button, or in the Unity options: "Edit/Preferences/External Tools".
6. Launch Visual Studio and add nuget packages to the generated project file, or use the dotnet cli tools
7. Build the generated project from either Visual Studio, the dotnet cli or through the provided Editor UI
8. (Optional) This is not needed if your are using Unity 2020.1 and have the latest Visual Studio package. If you are using Visual Studio to debug then unload the generated projects from Visual Studio, so they do not interfere when attaching to Unity.
9. You are done!

## Settings

Setting | Description
 --- | ---
 Add projects to solution | Whether to add the initialized projects to the unity-generated solution file, when the project is regenerated

Settings are persisted in the root unity folder in the NugetOptions.xml file. To save and apply the settings press the "Save settings" button.

## Additional stuff

- When Unity generates the solution files your nuget projects will be added to the solution. If you want to debug your Unity project you may need to unload them from the solution by right clicking on them in Visual Studio. (Only when using Unity older than 2020.1)
- If you want to use this in a CI-CD environment then you don't need to manually run dotnet build for the nuget projects. The project comes with an IPreprocessBuildWithReport which will do the same thing as the Build All button.
- Running the build command will replicate the output of the dotnet cli to the Unity Debug console.

## Gotchas
- Although it was not tested on Linux and MacOS building the generated projects should work via the .Net Framework reference assemblies, so a dotnet -build should just work.
- You only need to initialize a project once, when you set this up. Initializing again might override the packages you added.
- Tested with Unity version 2019.4 but other recent versions (2018+) should work
- The same gotchas are expected when just dealing with manually adding dlls
- Never forget that this project does nothing magical, it just automates the process of getting the needed dlls to be recognized with Unity