using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using System;

namespace Cake.Hg.Aliases
{
    public static partial class HgAliases
    {
        /// <summary>
        /// Apply a symbolic identifier for a changeset [tag]. 
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="tagName">Tag name</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Tag")]
        public static void HgTag(this ICakeContext context, DirectoryPath repositoryPath, string tagName)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (tagName == null) throw new ArgumentNullException(nameof(tagName));

            context.Hg(repositoryPath).Tag(tagName);
        }
    }
}