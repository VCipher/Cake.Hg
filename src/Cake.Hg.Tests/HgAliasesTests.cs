using System.IO;
using Cake.Hg.Tests.Fakes;
using NUnit.Framework;

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
    }
}