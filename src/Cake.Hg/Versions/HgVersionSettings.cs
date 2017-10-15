using System;

namespace Cake.Hg.Versions
{
    public sealed class HgVersionSettings
    {
        /// <summary>
        /// Project name
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Regexp pattern to determine project version.
        /// </summary>
        public string TagPattern { get; set; }

        /// <summary>
        /// Project version increment strategy.
        /// </summary>
        public Func<Version, Version> Increment { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public HgVersionSettings()
        {
            Project = string.Empty;
            TagPattern = @"(?<proj>[^\s\d]*)?\s*(?<ver>(\d+\.)*(\d+))";
            Increment = DefaultIncrement;
        }

        private static Version DefaultIncrement(Version version)
        {
            var major = version.Major;
            var minor = version.Minor;
            var build = version.Build;
            var revision = version.Revision;

            if (revision != -1)
                return new Version(major, minor, build, revision + 1);

            if (build != -1)
                return new Version(major, minor, build + 1);

            return new Version(major, minor + 1);
        }
    }
}