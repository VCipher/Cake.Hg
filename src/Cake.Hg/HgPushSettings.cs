using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Hg
{
    /// <summary>
    /// Settings used by <see cref="HgAliases.HgPush(ICakeContext,DirectoryPath,HgPushSettings)"/> 
    /// </summary>
    public sealed class HgPushSettings
    {
        /// <summary>
        /// Username to authenticate with.
        /// </summary>
        public string User { get; set; }
        
        /// <summary>
        /// Password to authenticate with.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Url to remote repository
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Returns url to remote repository like 'https://user:password@bitbucket.org'
        /// </summary>
        /// <returns></returns>
        internal string GetAuthUrl()
        {
            var uri = new Uri(Url);
            return $"{uri.Scheme}://{User}:{Password}@{uri.Host}{uri.PathAndQuery}";
        }
    }
}