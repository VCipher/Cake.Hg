using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Mercurial;
using NUnit.Framework;

namespace Cake.HgTests
{
    public abstract class RepositoryTestsBase
    {
        protected Repository Repository { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Repository = CreateTempRepository();
        }

        [TearDown]
        public virtual void TearDown()
        {
            DeleteTempRepository(Repository);
        }
        
        protected static void WriteTextFileAndCommit(Repository repo, string fileName, string contents, string commitMessage)
        {
            File.WriteAllText(Path.Combine(repo.Path, fileName), contents);
            repo.Commit(new CommitCommand { Message = commitMessage, AddRemove = true });
        }

        private static Repository CreateTempRepository()
        {
            var repoPath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid()
                    .ToString()
                    .Replace("-", string.Empty)
                    .ToLowerInvariant());
            
            Directory.CreateDirectory(repoPath);
            return new Repository(repoPath);
        }

        private static void DeleteTempRepository(Repository repository)
        {
            for (int index = 1; index < 5; index++)
            {
                try
                {
                    if (Directory.Exists(repository.Path))
                        Directory.Delete(repository.Path, true);
                    break;
                }
                catch (DirectoryNotFoundException)
                {
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("exception while cleaning up repository directory: " 
                                    + ex.GetType().Name + ": " +
                                    ex.Message);
                    
                    Thread.Sleep(1000);
                }
            }
        }
    }
}