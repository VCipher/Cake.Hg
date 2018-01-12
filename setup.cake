#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.Hg",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.Hg",
    appVeyorAccountName: "cakecontrib",
    solutionFilePath: "./src/Cake.Hg.sln",
    shouldRunCodecov: false,
    shouldRunDupFinder: false,
    wyamSourceFiles: "../../src/**/{!bin,!obj,!packages,!*Tests,}/**/*.cs");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
    dupFinderExcludePattern: new string[] {
        BuildParameters.RootDirectoryPath + "/src/Cake.HgTests/**/*.cs",
        BuildParameters.RootDirectoryPath + "/src/Cake.Hg/**/*.AssemblyInfo.cs"
    });

Build.Run();