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
        /// Perform merge of two branches
        /// </summary>
        /// <example>
        /// <code>
        ///     var diff = HgMerge("./", "rc", "dev");
        /// </code>
        /// </example>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="sourceBranch">Name of source branch</param>
        /// <param name="destinationBranch">Name of destination branch (Can be ommited to merge into current branch)</param>
        //
        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        public static void HgMerge(this ICakeContext context, DirectoryPath repositoryPath, string sourceBranch, string destinationBranch = null)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (sourceBranch == null) throw new ArgumentNullException(nameof(sourceBranch));
            
            using (var repository = context.Hg(repositoryPath))
            {
                if (!string.IsNullOrEmpty(destinationBranch))
                {
                    repository.Update(destinationBranch);
                }

                repository.Merge(RevSpec.ByBranch(sourceBranch));
                repository.Commit($"Merge with {sourceBranch}");
            }
        }
    }
}
