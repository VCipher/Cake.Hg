using Cake.Core.Annotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Cake.Hg")]
[assembly: AssemblyDescription("Cake AddIn that extends Cake with Mercurial features")]
[assembly: AssemblyCompany("vCipher")]
[assembly: AssemblyProduct("Cake.Hg")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8E7F175A-9805-4FB2-8708-C358FF9F5CB2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.0.4.0")]
[assembly: AssemblyFileVersion("0.0.4.0")]

// Cake build configuration
[assembly: CakeNamespaceImport("Mercurial")]
[assembly: CakeNamespaceImport("Cake.Hg")]
[assembly: CakeNamespaceImport("Cake.Hg.Aliases")]
[assembly: CakeNamespaceImport("Cake.Hg.Versions")]