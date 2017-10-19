using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Hg.Versioning;
using System;

namespace Cake.Hg.Aliases
{
    public static partial class HgAliases
    {
        /// <summary>
        /// Get the mercurial version info for the project. 
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static HgVersionInfo HgVersion(this ICakeContext context, DirectoryPath repositoryPath)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));

            return context.Hg(repositoryPath).GetVersionInfo();
        }

        /// <summary>
        /// Get the mercurial version info for the project. 
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="settings">Hg version settings</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static HgVersionInfo HgVersion(this ICakeContext context, DirectoryPath repositoryPath, HgVersionSettings settings)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));

            return context.Hg(repositoryPath).GetVersionInfo(settings);
        }
    }
}