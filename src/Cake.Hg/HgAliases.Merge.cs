using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Mercurial;
using System.Linq;

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
        /// <returns>MergeResult.Success if merge was successfull, MergeResult.UnresolvedFiles if merge conflict has occured</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        public static MergeResult HgMerge(this ICakeContext context, DirectoryPath repositoryPath, string sourceBranch, string destinationBranch = null)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (sourceBranch == null) throw new ArgumentNullException(nameof(sourceBranch));
            
            using (var repository = context.Hg(repositoryPath))
            {
                if (!string.IsNullOrEmpty(destinationBranch))
                    repository.Update(destinationBranch);
                else
                    destinationBranch = repository.Summary().Branch;

                MergeResult result;

                try
                {
                    result = repository.Merge(RevSpec.ByBranch(sourceBranch),
                        new MergeCommand {
                            MergeTool = ":merge"
                        });
                }
                catch (MercurialExecutionException ex)
                {
                    if (!ex.Message.Contains("merging with a working directory ancestor has no effect"))
                        throw;
                    result = MergeResult.UnresolvedFiles;
                }
                

                if (result == MergeResult.Success)
                    repository.Commit($"Merge with {sourceBranch}");
                else
                    repository.Update(new UpdateCommand { Clean = true });

                return result;
            }
        }
    }
}
