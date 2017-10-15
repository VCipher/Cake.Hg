using Cake.Hg;
using Cake.Hg.Versions;
using Mercurial;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cake.HgTests
{
    [TestFixture]
    public class HgVersionTests : RepositoryTestsBase
    {
        private Dictionary<string, RevSpec> _revisions;

        public HgVersionTests()
        {
            _revisions = new Dictionary<string, RevSpec>();
        }

        [Test]
        public void VersionInfo_Simple()
        {
            Repository.Init();
            WriteTextFileAndCommit("test.txt", "dummy");

            Tag(version: "0.0.1");
            Tag(version: "0.0.2");
            Tag(version: "0.0.3");

            var info = Repository.VersionInfo();
            var changeset = GetLastChangeset();

            Assert.That(changeset.Tags, Has.Exactly(1).EqualTo("0.0.3"));
            Assert.That(info.Version.ToString(), Is.EqualTo("0.0.3"));
            Assert.That(info.Changeset, Is.EqualTo(changeset));
            Assert.That(info.Project, Is.EqualTo(string.Empty));
        }

        [Test]
        [TestCase("SomeProject")]
        [TestCase("OtherProject")]
        public void VersionInfo_ManyProjects(string project)
        {
            Repository.Init();
            WriteTextFileAndCommit("test.txt", "dummy");

            Tag(project: "SomeProject", version: "0.0.1");
            Tag(project: "OtherProject", version: "0.0.1");
            Tag(project: "SomeProject", version: "0.0.2");
            Tag(project: "OtherProject", version: "0.0.2");
            Tag(project: "SomeProject", version: "0.0.3");
            Tag(project: "OtherProject", version: "0.0.3");

            var settings = new HgVersionSettings
            {
                Project = project
            };

            var info = Repository.VersionInfo(settings);
            var changeset = GetLastChangeset(project);

            Assert.That(changeset.Tags, Has.Exactly(1).EqualTo($"{project} 0.0.3"));
            Assert.That(info.Version.ToString(), Is.EqualTo("0.0.3"));
            Assert.That(info.Changeset, Is.EqualTo(changeset));
            Assert.That(info.Project, Is.EqualTo(settings.Project));
        }

        [Test]
        [TestCase("SomeProject")]
        [TestCase("OtherProject")]
        public void VersionInfo_ManyProjects_SameRevision(string project)
        {
            Repository.Init();
            WriteTextFileAndCommit("test.txt", "dummy");

            Tag(project: "SomeProject", version: "0.0.1");
            Tag(project: "OtherProject", version: "0.0.1");
            Tag(project: "SomeProject", version: "0.0.2");
            Tag(project: "OtherProject", version: "0.0.2");

            var tip = Repository.Tip();
            Tag(project: "SomeProject", version: "0.0.3", changeset: tip);
            Tag(project: "OtherProject", version: "0.0.3", changeset: tip);

            var settings = new HgVersionSettings
            {
                Project = project
            };

            var info = Repository.VersionInfo(settings);
            var changeset = GetLastChangeset(project);

            Assert.That(changeset.Tags, Has.Exactly(2).Contains("0.0.3"));
            Assert.That(info.Version.ToString(), Is.EqualTo("0.0.3"));
            Assert.That(info.Changeset, Is.EqualTo(changeset));
            Assert.That(info.Project, Is.EqualTo(settings.Project));
        }

        [Test]
        [TestCase("SomeProject", "0.0.3", true)]
        [TestCase("OtherProject", "0.0.3", false)]
        public void TryIncrementVersion(string project, string version, bool canIncrementVersion)
        {
            Repository.Init();

            #region change first project 
            WriteTextFileAndCommit("SomeProject/index.txt", "dummy");
            Tag(project: "SomeProject", version: "0.0.1");

            WriteTextFileAndCommit("SomeProject/test.txt", "dummy");
            Tag(project: "SomeProject", version: "0.0.2");

            WriteTextFileAndCommit("SomeProject/test.txt", "dummy...");
            #endregion

            #region change second project
            WriteTextFileAndCommit("OtherProject/index.txt", "dummy");
            Tag(project: "OtherProject", version: "0.0.1");

            WriteTextFileAndCommit("OtherProject/test.txt", "dummy");
            Tag(project: "OtherProject", version: "0.0.2");

            WriteTextFileAndCommit("OtherProject/test.txt", "dummy...");
            Tag(project: "OtherProject", version: "0.0.3");
            #endregion

            var settings = new HgVersionSettings
            {
                Project = project
            };

            var result = Repository.TryIncrementVersion(project, settings, out var info);

            Assert.That(result, Is.EqualTo(canIncrementVersion));
            Assert.That(info.Version.ToString(), Is.EqualTo(version));
            Assert.That(info.Project, Is.EqualTo(settings.Project));
        }

        [Test]
        [TestCase("SomeProject", "0.0.1", true)]
        [TestCase("OtherProject", "0.0.0", false)]
        public void TryIncrementVersion_FirstVersion(string project, string version, bool canIncrementVersion)
        {
            Repository.Init();
            WriteTextFileAndCommit("SomeProject/index.txt", "dummy");

            var settings = new HgVersionSettings
            {
                Project = project
            };

            var result = Repository.TryIncrementVersion(project, settings, out var info);

            Assert.That(result, Is.EqualTo(canIncrementVersion));
            Assert.That(info.Version.ToString(), Is.EqualTo(version));
            Assert.That(info.Project, Is.EqualTo(settings.Project));
        }

        [Test]
        public void TryIncrementVersion_FirstVersion_WholeRepository()
        {
            Repository.Init();
            WriteTextFileAndCommit("SomeProject/index.txt", "dummy");

            var settings = new HgVersionSettings();
            var result = Repository.TryIncrementVersion(string.Empty, settings, out var info);

            Assert.That(result, Is.True);
            Assert.That(info.Version, Is.EqualTo(new Version(0, 0, 1)));
            Assert.That(info.Project, Is.Empty);
        }

        [Test]
        public void Tag_VersionInfo()
        {
            Repository.Init();
            WriteTextFileAndCommit("SomeProject/index.txt", "dummy");
            
            var version = new Version("0.0.1");
            var project = "SomeProject";            
            var info = new HgVersionInfo(project, version, Repository.Tip());
            
            Repository.Tag(info);

            var changeset = Repository.Parent(Repository.Tip());
            var tag = "SomeProject 0.0.1";

            Assert.That(changeset.Tags, Has.Exactly(1).EqualTo(tag));
        }

        private void Tag(string project = null, string version = null, Changeset changeset = null)
        {
            var tip = changeset ?? Repository.Tip();
            Repository.Tag(new TagCommand()
                .WithName($"{project} {version}")
                .WithRevision(tip.Revision));

            _revisions[project ?? string.Empty] = tip.Revision;
        }

        private Changeset GetLastChangeset(string project = null)
        {
            return Repository.Changeset(_revisions[project ?? string.Empty]);
        }
    }
}