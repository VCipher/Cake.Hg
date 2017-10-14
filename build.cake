var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");

var solution = GetFiles("./*.sln")
    .First()
    .GetFilenameWithoutExtension();

Task("Default")
    .Does(() =>
{
    Information("Cake bootstrap completed...");
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories("./build");
});

Task("NuGet-Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./" + solution + ".sln");
});

Task("Build")
    .IsDependentOn("NuGet-Restore")
    .Does(() =>
{
    MSBuild("./" + solution + ".sln", settings =>
        settings.SetConfiguration(configuration)
            .WithTarget("Rebuild"));
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    Information("Test completed...");
});

Task("NuGet-Pack")
    .IsDependentOn("Test")
    .Does(() =>
{
    var projects = GetFiles("./**/*.nuspec")
        .Select(file => file.GetFilenameWithoutExtension())
        .SelectMany(file => GetFiles("./**/" + file + ".csproj"));

    var settings = new NuGetPackSettings 
    {
        Copyright = "Copyright © vCipher " + DateTime.Now.Year,
        OutputDirectory = "./build",
        Properties = new Dictionary<string, string>
        {
            ["Configuration"] = configuration
        }
    };

    NuGetPack(projects, settings);
});

Task("AppVeyor")
    .IsDependentOn("NuGet-Pack");

RunTarget(target);