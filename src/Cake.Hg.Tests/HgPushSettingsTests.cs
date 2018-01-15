using NUnit.Framework;

namespace Cake.Hg.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class HgPushSettingsTests
    {
        [TestCase("http://bitbucket.org", "http://user:password@bitbucket.org/")]
        [TestCase("https://bitbucket.org", "https://user:password@bitbucket.org/")]
        [TestCase("https://bitbucket.org/company", "https://user:password@bitbucket.org/company")]
        [TestCase("https://bitbucket.org/company?f=1", "https://user:password@bitbucket.org/company?f=1")]
        [TestCase("https://u:p@bitbucket.org/company?f=1", "https://user:password@bitbucket.org/company?f=1")]
        public void GetAuthUrl(string url, string expected)
        {
            var settings = new HgPushSettings
            {
                User = "user",
                Password = "password",
                Url = url
            };
            
            var actual = settings.GetAuthUrl();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}