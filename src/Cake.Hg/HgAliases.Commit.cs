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
        /// Create mercurial commit.
        /// </summary>
        /// <example>
        /// <code>
        ///     HgCommit("./", "Initial commit");
        /// </code>
        /// </example>
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

            using (var repository = context.Hg(repositoryPath))
            {
                var command = new CommitCommand()
                    .WithMessage(message)
                    .WithAddRemove();
                
                repository.Commit(command);
            }
        }
    }
}