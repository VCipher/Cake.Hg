using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Mercurial;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Cake.Hg
{
    /// <summary>
    /// Contains functionality for working with Mercurial.
    /// <code>
    ///     #addin Cake.Hg
    /// </code>
    /// </summary>
    [CakeAliasCategory("Hg")]
    public static partial class HgAliases
    {
        /// <summary>
        /// Return mercurial repository. 
        /// <example>
        /// <code>
        ///     var repo = Hg("./");
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <returns>Mercurial repository</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Hg")]
        public static Repository Hg(this ICakeContext context, DirectoryPath repositoryPath)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));

            var path = repositoryPath.MakeAbsolute(context.Environment);
            return new Repository(path.FullPath);
        }
    }
}