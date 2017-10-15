using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Mercurial;
using System;

namespace Cake.Hg.Aliases
{
    public static partial class HgAliases
    {
        /// <summary>
        /// Get diff of repository. 
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="revisions">Revision or revision range to view a diff</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Diff")]
        public static void HgDiff(this ICakeContext context, DirectoryPath repositoryPath, RevSpec revisions)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (revisions == null) throw new ArgumentNullException(nameof(revisions));

            context.Hg(repositoryPath).Diff(revisions);
        }
    }
}
