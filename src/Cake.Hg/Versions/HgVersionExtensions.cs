using Mercurial;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cake.Hg.Versions
{
    public static class HgVersionExtensions
    {
        /// <summary>
        /// Add version info tag for changeset.
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="info">Project version info</param>
        public static void Tag(this Repository repository, HgVersionInfo info)
        {
            repository.Tag(new TagCommand()
                .WithName($"{info.Project} {info.Version}")
                .WithRevision(info.Changeset.Revision));
        }

        /// <summary>
        /// Try to get next project version by relative project path.
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="path">Relative project path</param>
        /// <param name="settings">Hg increment version settings</param>
        /// <param name="info">Next project version</param>
        /// <returns></returns>
        public static bool TryIncrementVersion(this Repository repository, string path, HgIncrementVersionSettings settings, out HgVersionInfo info)
        {
            info = repository.VersionInfo(settings);

            var tip = repository.Changeset(RevSpec.ByBranch(settings.Branch));
            var revisions = GetDiffRevisions(info, tip);

            var diff = repository.Diff(new DiffCommand()
                .WithNames(path)
                .WithRevisions(revisions));

            if (string.IsNullOrEmpty(diff))
                return false;

            var nextVersion = settings.Increment(info.Version);
            info = new HgVersionInfo(info.Project, nextVersion, tip);

            return true;
        }

        /// <summary>
        /// Get the mercurial version info for the project. 
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        public static HgVersionInfo VersionInfo(this Repository repository)
        {
            return VersionInfo(repository, new HgVersionSettings());
        }

        /// <summary>
        /// Get the mercurial version info for the project. 
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="settings">Hg version settings</param>
        public static HgVersionInfo VersionInfo(this Repository repository, HgVersionSettings settings)
        {
            var pattern = new Regex(settings.TagPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var resultTuple = repository.Tags()
                .Select(tag => new TagMatch(tag, pattern.Match(tag.Name)))
                .LastOrDefault(tuple => IsMatch(tuple.Match, settings));

            if (resultTuple == null)
                return new HgVersionInfo(settings.Project);

            return GetVersion(repository, resultTuple);
        }

        private static RevSpec GetDiffRevisions(HgVersionInfo info, Changeset tip)
        {
            var from = info?.Changeset?.Revision ?? RevSpec.Null;
            var to = tip?.Revision ?? RevSpec.Null;

            return RevSpec.Range(from, to);
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

        private static HgVersionInfo GetVersion(Repository repository, TagMatch tuple)
        {
            var project = tuple.Match.Groups["proj"].Value;
            var version = new Version(tuple.Match.Groups["ver"].Value);
            var changeset = repository.Changeset(tuple.Tag.RevisionNumber);

            return new HgVersionInfo(project, version, changeset);
        }
    }
}