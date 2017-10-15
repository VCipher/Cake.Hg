using Cake.Hg;
using Cake.Hg.Versions;
using Mercurial;
using NUnit.Framework;
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
        public void Version_Simple()
        {
            Repository.Init();
            WriteTextFileAndCommit(Repository, "test.txt", "dummy", "dummy");

            Tag(version: "0.0.1");
            Tag(version: "0.0.2");
            Tag(version: "0.0.3");

            var info = Repository.Version();
            var lastChangeset = GetLastChangeset();

            Assert.That(lastChangeset.Tags, Has.Exactly(1).EqualTo("0.0.3"));
            Assert.That(info.Version.ToString(), Is.EqualTo("0.0.3"));
            Assert.That(info.Changeset, Is.EqualTo(lastChangeset));
            Assert.That(info.Project, Is.EqualTo(string.Empty));
        }
        
        [Test]
        [TestCase("SomeProject")]
        [TestCase("OtherProject")]
        public void Version_ManyProjects(string project)
        {
            Repository.Init();
            WriteTextFileAndCommit(Repository, "test.txt", "dummy", "dummy");

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

            var info = Repository.Version(settings);
            var lastChangeset = GetLastChangeset(project);

            Assert.That(lastChangeset.Tags, Has.Exactly(1).EqualTo($"{project} 0.0.3"));
            Assert.That(info.Version.ToString(), Is.EqualTo("0.0.3"));
            Assert.That(info.Changeset, Is.EqualTo(lastChangeset));
            Assert.That(info.Project, Is.EqualTo(settings.Project));
        }

        [Test]
        [TestCase("SomeProject")]
        [TestCase("OtherProject")]
        public void Version_ManyProjects_SameRevision(string project)
        {
            Repository.Init();
            WriteTextFileAndCommit(Repository, "test.txt", "dummy", "dummy");

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

            var info = Repository.Version(settings);
            var lastChangeset = GetLastChangeset(project);

            Assert.That(lastChangeset.Tags, Has.Exactly(2).Contains("0.0.3"));
            Assert.That(info.Version.ToString(), Is.EqualTo("0.0.3"));
            Assert.That(info.Changeset, Is.EqualTo(lastChangeset));
            Assert.That(info.Project, Is.EqualTo(settings.Project));
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