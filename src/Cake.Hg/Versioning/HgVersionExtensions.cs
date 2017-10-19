using Mercurial;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cake.Hg.Versioning
{
    public static class HgVersionExtensions
    {
        private static Regex AssemblyVersionPattern = new Regex(
            @"^(\s*\[\s*assembly\s*:\s*((System\s*\.)?\s*Reflection\s*\.)?\s*AssemblyVersion\()(.*)(\)\])"
            , RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        private static Regex AssemblyFileVersionPattern = new Regex(
            @"^(\s*\[\s*assembly\s*:\s*((System\s*\.)?\s*Reflection\s*\.)?\s*AssemblyFileVersion\()(.*)(\)\])"
            , RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        private static Regex TagVersionPattern = new Regex(
            @"(?<proj>[^\s\d]*)?\s*(?<ver>(\d+\.)*(\d+))"
            , RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Update AssemblyInfo.cs file with actual project version
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="settings">Hg update assembly version info settings</param>
        public static void UpdateAssemblyInfo(this Repository repository, HgUpdateAssemblyInfoSettings settings = null)
        {
            settings = settings ?? new HgUpdateAssemblyInfoSettings();
            repository.TryIncrementVersion(out var info, settings);

            var path = Path.Combine(repository.Path, settings.AssembyInfoPath);
            var content = File.ReadAllText(path);
            var version = info.Version;

            content = AssemblyVersionPattern.Replace(content, $"$1\"{version}\"$5");
            content = AssemblyFileVersionPattern.Replace(content, $"$1\"{version}\"$5");

            File.WriteAllText(path, content);
        }

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
        /// <param name="info">Next project version</param>
        /// <param name="settings">Hg increment version settings</param>
        /// <returns></returns>
        public static bool TryIncrementVersion(this Repository repository, out HgVersionInfo info, HgIncrementVersionSettings settings = null)
        {
            settings = settings ?? new HgIncrementVersionSettings();
            info = repository.VersionInfo(settings);

            var tip = repository.Changeset(RevSpec.ByBranch(settings.Branch));
            var revisions = GetDiffRevisions(info, tip);

            var diff = repository.Diff(new DiffCommand()
                .WithNames(settings.ProjectPath)
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
        public static HgVersionInfo VersionInfo(this Repository repository, HgVersionSettings settings = null)
        {
            settings = settings ?? new HgVersionSettings();
            var resultTuple = repository.Tags()
                .Select(tag => new TagMatch(tag, TagVersionPattern.Match(tag.Name)))
                .LastOrDefault(tuple => IsMatch(tuple.Match, settings));

            if (resultTuple == null)
                return new HgVersionInfo(settings.ProjectName);

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
            if (string.IsNullOrEmpty(settings.ProjectName))
                return true;

            return StringComparer.OrdinalIgnoreCase.Equals(match.Groups["proj"].Value, settings.ProjectName);
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