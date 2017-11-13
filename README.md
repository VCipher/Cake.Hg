# Cake.Hg
Cake AddIn that extends Cake with Mercurial features using Mercurial.Net

[![NuGet](https://img.shields.io/nuget/v/Cake.Hg.svg)](https://www.nuget.org/packages/Cake.Hg) [![MyGet](https://img.shields.io/myget/cake-contrib/vpre/Cake.Hg.svg?label=MyGet)](https://www.myget.org/feed/cake-contrib/package/nuget/Cake.Hg)

| Build server                | Platform     | Status                                                                                                                    |
|-----------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status](https://img.shields.io/appveyor/ci/cakecontrib/cake-hg/master.svg)](https://ci.appveyor.com/project/cakecontrib/cake-hg/branch/master) |

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
