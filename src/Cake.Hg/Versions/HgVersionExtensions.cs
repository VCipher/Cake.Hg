using Mercurial;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cake.Hg.Versions
{
    public static class HgVersionExtensions
    {
        /// <summary>
        /// Get the mercurial version info for the project. 
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        public static HgVersion Version(this Repository repository)
        {
            return Version(repository, new HgVersionSettings());
        }

        /// <summary>
        /// Get the mercurial version info for the project. 
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="settings">Hg version settings</param>
        public static HgVersion Version(this Repository repository, HgVersionSettings settings)
        {
            var pattern = new Regex(settings.TagPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var resultTuple = repository.Tags()
                .Select(tag => new TagMatch(tag, pattern.Match(tag.Name)))
                .LastOrDefault(tuple => IsMatch(tuple.Match, settings));

            if (resultTuple == null)
                return new HgVersion();

            return GetVersion(repository, resultTuple);
        }

        private static bool IsMatch(Match match, HgVersionSettings settings)
        {
            return match.Success && IsProjectMatch(match, settings);
        }

        private static bool IsProjectMatch(Match match, HgVersionSettings settings)
        {
            if (string.IsNullOrEmpty(settings.Project))
                return true;

            return StringComparer.OrdinalIgnoreCase.Equals(match.Groups["proj"].Value, settings.Project);
        }

        private static HgVersion GetVersion(Repository repository, TagMatch tuple)
        {
            var project = tuple.Match.Groups["proj"].Value;
            var version = new Version(tuple.Match.Groups["ver"].Value);
            var changeset = repository.Changeset(tuple.Tag.RevisionNumber);

            return new HgVersion(project, version, changeset);
        }
    }
}