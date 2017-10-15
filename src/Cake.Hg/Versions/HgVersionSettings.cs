using System;

namespace Cake.Hg.Versions
{
    public class HgVersionSettings
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
        /// .ctor
        /// </summary>
        public HgVersionSettings()
        {
            Project = string.Empty;
            TagPattern = @"(?<proj>[^\s\d]*)?\s*(?<ver>(\d+\.)*(\d+))";
        }
    }
}