using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Hg.Aliases
{
    public static partial class HgAliases
    {
        /// <summary>
        /// Create mercurial commit. 
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="message">Commit message</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Commit")]
        public static void HgCommit(this ICakeContext context, DirectoryPath repositoryPath, string message)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (message == null) throw new ArgumentNullException(nameof(message));

            context.Hg(repositoryPath).Commit(message);
        }
    }
}