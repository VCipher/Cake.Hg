using System.Runtime.CompilerServices;
using Cake.Core.Annotations;

// Cake build configuration
[assembly: CakeNamespaceImport("Mercurial")]
[assembly: CakeNamespaceImport("Cake.Hg")]

// Testings settings
[assembly: InternalsVisibleTo("Cake.Hg.Tests")]
