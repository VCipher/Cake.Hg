// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Cake.Hg.Versioning
{
    /// <summary>
    /// Contains settings used by <see cref="HgVersionExtensions.GetVersionInfo(Mercurial.Repository,Cake.Hg.Versioning.HgVersionSettings)"/>.
    /// </summary>
    public class HgVersionSettings
    {
        /// <summary>
        /// Branch name
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public HgVersionSettings()
        {
            Branch = "default";
            ProjectName = string.Empty;
        }
    }
}