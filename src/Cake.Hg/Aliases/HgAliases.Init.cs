using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using System;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Cake.Hg.Aliases
{
    public static partial class HgAliases
    {
        /// <summary>
        /// Init mercurial repository. 
        /// </summary>
        /// <example>
        /// <code>
        ///     HgInit("./");
        /// </code>
        /// </example>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Init")]
        public static void HgInit(this ICakeContext context, DirectoryPath repositoryPath)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));

            context.Hg(repositoryPath).Init();
        }
    }
}