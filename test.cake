#addin "Cake.Hg"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////
var target          = Argument<string>("target", "Default");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////

var testRepo        = MakeAbsolute(Directory("./tests/repo"));
var initCommit      = (string)null;
var firstCommit     = (string)null;

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
    // Executed BEFORE the first task.
    Information("Running tasks...");
    Information("Testing \"Cake.Hg Addin\"");
});

Teardown(ctx =>
{
    // Executed AFTER the last task.
    Information("Finished running tasks.");

    try
    {
        Information("Trying to clean up test repo {0}", testRepo);
        if (DirectoryExists(testRepo))
        {
            ForceDeleteDirectory(testRepo.FullPath);
        }
        if (DirectoryExists(testRepo))
        {
            Warning("Failed to clean {0}", testRepo);
        }
        else
        {
            Information("Successfully cleaned test repo {0}", testRepo);
        }
    }
    catch(Exception ex)
    {
        Error("Failed to clean up test reop {0}\r\n{1}", testRepo, ex);
    }
});

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    // Clean up if repo exists
    if (DirectoryExists(testRepo))
    {
        ForceDeleteDirectory(testRepo.FullPath);
    }
});

Task("Hg-Init")
    .IsDependentOn("Clean")
    .Does(() =>
{
    Information("Creating repository...");
    CreateDirectory(testRepo);
    HgInit(testRepo);
    
    if (!DirectoryExists(testRepo + "/.hg"))
    {
        throw new DirectoryNotFoundException($"Failed to create repository {testRepo}");
    }

    Information("Repository created {0}.", testRepo);
});

Task("Hg-Init-Commit")
    .IsDependentOn("Hg-Init")
    .Does(() =>
{
    Information("Committing files...");
    
    CreateFile(Context, testRepo + "/init.txt");
    HgCommit(testRepo, "Inital commit");
    initCommit = HgTip(testRepo).Hash;

    if (string.IsNullOrEmpty(initCommit))
    {
        throw new Exception($"Failed to commit initial state {testRepo}");
    }

    Information("Commit created {0}", initCommit);
});

Task("Hg-Commit")
    .IsDependentOn("Hg-Init-Commit")
    .Does(() =>
{
    Information("Committing files...");
    
    CreateFile(Context, testRepo + "/dummy.txt");
    HgCommit(testRepo, "Dummy commit");
    firstCommit = HgTip(testRepo).Hash;
    
    if (string.IsNullOrEmpty(firstCommit))
    {
        throw new Exception($"Failed to commit modified changes {testRepo}");
    }

    Information("Commit created {0}.", firstCommit);
});

Task("Hg-Tip")
    .IsDependentOn("Hg-Commit")
    .Does(() =>
{
    Information("Getting tip revision...");
    
    var tip = HgTip(testRepo).Hash;
    
    if (!string.Equals(firstCommit, tip))
    {
        throw new Exception($"Failed to get tip {testRepo}");
    }

    Information("Tip {0}.", tip);
});

Task("Hg-Diff")
    .IsDependentOn("Hg-Commit")
    .Does(() =>
{
    Information("Getting diff...");
    
    CreateFile(Context, testRepo + "/dummy.txt");
    var diff = HgDiff(testRepo, $"{initCommit}:{firstCommit}");
    
    if (string.IsNullOrEmpty(diff))
    {
        throw new Exception($"Failed to get diff {testRepo}");
    }

    Information("Diff:\r\n{0}", diff);
});

Task("Hg-Tag")
    .IsDependentOn("Hg-Commit")
    .Does(() =>
{
    Information("Tagging...");
    
    HgTag(testRepo, "0.0.1");
    
    var tags = HgTags(testRepo);

    if (tags == null || tags.Count() == 0)
    {
        throw new Exception($"Failed to tag {testRepo}");
    }

    foreach (var tag in tags)
    {
        Information("Name: {0}, Revision: {1}", tag.Name, tag.RevisionNumber);
    }

    Information("Tagging completed.");
});

Task("Hg-Merge")
    .IsDependentOn("Hg-Init-Commit")
    .Does(() =>
{
    Information("Merging branches...");
    
    var repository = Hg(testRepo);
            
    //default branch
    var defaultCommit = HgTip(testRepo).Hash;
    CreateFile(Context, testRepo + "/first.txt");
    HgCommit(testRepo, "Initial commit");
    var firstCommit = HgTip(testRepo).Hash;

    repository.Update(defaultCommit);
    repository.Branch("new-branch");

    CreateFile(Context, testRepo + "/second.txt");
    HgCommit(testRepo, "second commit");
    var secondCommit = HgTip(testRepo).Hash;

    repository.Update("default");

    var result = HgMerge(testRepo, "new-branch");
    
    var mergeCommit = HgTip(testRepo);
    
    if (result != MergeResult.Success || mergeCommit.LeftParentHash != firstCommit || mergeCommit.RightParentHash != secondCommit)
    {
        throw new Exception($"Merge ended with unexpected results {testRepo}");
    }

});

Task("Default")
    .IsDependentOn("Hg-Init")
    .IsDependentOn("Hg-Commit")
    .IsDependentOn("Hg-Tip")
    .IsDependentOn("Hg-Diff")
    .IsDependentOn("Hg-Tag")
    .IsDependentOn("Hg-Merge");

RunTarget(target);

public static void ForceDeleteDirectory(string path)
{
    var directory = new System.IO.DirectoryInfo(path) { Attributes = FileAttributes.Normal };

    foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
    {
        info.Attributes = FileAttributes.Normal;
    }

    directory.Delete(true);
}

public static void CreateFile(ICakeContext context, FilePath filePath)
{
    var file = context.FileSystem.GetFile(filePath);
    var guid = new Guid();

    using(var stream = file.OpenWrite())
    using(var writer = new System.IO.StreamWriter(stream, Encoding.ASCII))
    {
        writer.WriteLine(guid);
    }
}