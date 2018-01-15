using NUnit.Framework;

namespace Cake.Hg.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Self)]
    class HgExtensionsTests: RepositoryTestsBase
    {
        [Test]
        public void Changeset_AllowsNavigateToParentRevision()
        {
            Repository.Init();
            WriteTextAndCommit("ff.txt", "content1", "message1", true);
            var firstTip = Repository.Tip();

            WriteTextAndCommit("ff2.txt", "content2", "message2", true);
            var tip = Repository.Tip();
            var parentChangeset = Repository.Changeset(tip.LeftParentRevision);

            Assert.That(0, Is.EqualTo(tip.LeftParentRevision));
            Assert.That(parentChangeset, Is.EqualTo(firstTip));
        }
    }
}
