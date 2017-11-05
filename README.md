# Cake.Hg
Cake AddIn that extends Cake with Mercurial features using Mercurial.Net

# Usage

```c#
#addin "Cake.Hg"

var target = Argument("target", "Default");

Task("Hg-CreateTag")
    .Does(() => 
    {
        HgTag("./", "0.0.1");
    });

Task("Default")
    .IsDependentOn("Hg-CreateTag");
    
RunTarget(target);
```
