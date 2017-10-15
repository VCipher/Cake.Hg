using Mercurial;
using System.Linq;

namespace Cake.Hg
{
    public static class HgExtensions
    {
        /// <summary>
        /// Retrieve first changeset by revision
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="revision">Revision</param>
        /// <returns></returns>
        public static Changeset Changeset(this Repository repository, RevSpec revision)
        {
            return repository
                .Log(new LogCommand().WithRevision(revision))
                .First();
        }

        /// <summary>
        /// Retrieve first parent of changeset.
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="changeset">Changeset</param>
        /// <returns></returns>
        public static Changeset Parent(this Repository repository, Changeset changeset)
        {
            return repository.Parent(changeset.Revision);
        }

        /// <summary>
        /// Retrieve first parent of revision.
        /// </summary>
        /// <param name="repository">Mercurial repository</param>
        /// <param name="revision">Revision</param>
        /// <returns></returns>
        public static Changeset Parent(this Repository repository, RevSpec revision)
        {
            return repository
                .Parents(new ParentsCommand().WithRevision(revision))
                .First();
        }
    }
}
