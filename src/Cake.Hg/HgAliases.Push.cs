using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Mercurial;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Cake.Hg
{
    public partial class HgAliases
    {
        /// <summary>
        /// Push local changes to remote repository. 
        /// </summary>
        /// <example>
        /// <code>
        ///     HgPush("./");
        /// </code>
        /// </example>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Push")]
        public static void HgPush(this ICakeContext context, DirectoryPath repositoryPath)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));

            using (var repository = context.Hg(repositoryPath))
            {
                repository.Push();
            }
        }
        
        /// <summary>
        /// Push local changes to remote repository. 
        /// </summary>
        /// <example>
        /// <code>
        ///     HgPush("./", new HgPushSettings
        ///     {
        ///         User = "user",
        ///         Password = "password",
        ///         Url = "https://bitbucket.org/mycompany/myrepository
        ///     });
        /// </code>
        /// </example>
        /// <param name="context">Cake context</param>
        /// <param name="repositoryPath">Path to repository</param>
        /// <param name="settings">Push settings</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Push")]
        public static void HgPush(this ICakeContext context, DirectoryPath repositoryPath, HgPushSettings settings)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (repositoryPath == null) throw new ArgumentNullException(nameof(repositoryPath));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            using (var repository = context.Hg(repositoryPath))
            {
                var command = new PushCommand()
                    .WithDestination(settings.GetAuthUrl());
                
                repository.Push(command);
            }
        }
    }
}