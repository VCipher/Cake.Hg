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
        /// Get the tip revision.
        /// </summary>
        /// <example>
        /// <code>
        ///     var changeset = HgTip("./");
        /// </code>
        /// </example>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Tip")]
        public static Changeset HgTip(this ICakeContext context, DirectoryPath repositoryPath)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));

            return context.Hg(repositoryPath).Tip();
        }
    }
}