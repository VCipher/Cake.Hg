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
        /// Return mercurial repository. 
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
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