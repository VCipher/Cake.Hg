using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Mercurial;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Cake.Hg
{
    public static partial class HgAliases
    {
        /// <summary>
        /// Get diff of repository.
        /// </summary>
        /// <example>
        /// <code>
        ///     var diff = HgDiff("./", "6b0f32157b9045a9495821db1927348250076e6b:e40ce466124109a074af6dc582c1d54db3e9cd01");
        /// </code>
        /// </example>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="revisions">Revision or revision range to view a diff</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Diff")]
        public static string HgDiff(this ICakeContext context, DirectoryPath repositoryPath, RevSpec revisions)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (revisions == null) throw new ArgumentNullException(nameof(revisions));
            
            using (var repository = context.Hg(repositoryPath))
            {
                return repository.Diff(revisions);
            }
        }
    }
}
