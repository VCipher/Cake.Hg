using System.IO;
using Cake.Hg.Tests.Fakes;
using NUnit.Framework;
using Mercurial;
using System.Linq;

namespace Cake.Hg.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Self)]
    public class HgAliasesTests : RepositoryTestsBase
    {
        [Test]
        public void BasicsScenario()
        {
            var repository = Repository.Path;
            var context = new FakeCakeContext();
            
            context.HgInit(repository);
            
            File.WriteAllText(repository + "/dummy.txt", "123");
            context.HgCommit(repository, "Initial commit");
            var initCommit = context.HgTip(repository).Hash;
            
            File.WriteAllText(repository + "/dummy.txt", "213");
            context.HgCommit(repository, "Dummy commit");
            var firstCommit = context.HgTip(repository).Hash;

            var diff = context.HgDiff(repository, $"{initCommit}:{firstCommit}");
            
            Assert.Multiple(() =>
            {
                Assert.That(initCommit, Is.Not.Empty);
                Assert.That(firstCommit, Is.Not.Empty);
                Assert.That(diff, Is.Not.Empty);
            });
        }

        [Test]
        public void HgMerge_ShouldMergeWithCurrentBranch()
        {
            var path = Repository.Path;
            var context = new FakeCakeContext();
            
            context.HgInit(path);
            var repository = context.Hg(Repository.Path);
            
            //default branch
            File.WriteAllText(path + "/dummy.txt", "123");
            context.HgCommit(path, "Initial commit");
            var firstCommit = context.HgTip(path);

            File.WriteAllText(path + "/dummy.txt", "213");
            context.HgCommit(path, "Dummy commit");
            var defaultCommit = context.HgTip(path);

            repository.Update(firstCommit.Hash);

            //dev branch
            repository.Branch("dev");
            File.WriteAllText(path + "/next.txt", "111");
            context.HgCommit(path, "dev commit");
            var devCommit = context.HgTip(path);

            //back to default
            repository.Update("default");

            //merge
            context.HgMerge(path, "dev");

            //check if merge was ok
            var mergeCommit = context.HgTip(path);
            Assert.Multiple(() =>
            {
                Assert.That(mergeCommit.LeftParentHash, Is.EqualTo(defaultCommit.Hash));
                Assert.That(mergeCommit.RightParentHash, Is.EqualTo(devCommit.Hash));
            });

        }

        [Test]
        public void HgMerge_ShouldMergeNonCurrentBranches()
        {
            var path = Repository.Path;
            var context = new FakeCakeContext();

            context.HgInit(path);
            var repository = context.Hg(Repository.Path);

            //default branch
            File.WriteAllText(path + "/dummy.txt", "123");
            context.HgCommit(path, "Initial commit");
            var firstCommit = context.HgTip(path);

            //other branch
            repository.Branch("other");
            File.WriteAllText(path + "/dummy.txt", "213");
            context.HgCommit(path, "Dummy commit");
            var otherCommit = context.HgTip(path);

            repository.Update(firstCommit.Hash);

            //dev branch
            repository.Branch("dev");
            File.WriteAllText(path + "/next.txt", "111");
            context.HgCommit(path, "dev commit");
            var devCommit = context.HgTip(path);

            //back to default
            repository.Update("default");

            //merge
            context.HgMerge(path, "dev", "other");

            //check if merge was ok
            var mergeCommit = context.HgTip(path);
            Assert.Multiple(() =>
            {
                Assert.That(mergeCommit.Branch, Is.EqualTo("other"));
                Assert.That(mergeCommit.LeftParentHash, Is.EqualTo(otherCommit.Hash));
                Assert.That(mergeCommit.RightParentHash, Is.EqualTo(devCommit.Hash));
            });

        }
    }
}