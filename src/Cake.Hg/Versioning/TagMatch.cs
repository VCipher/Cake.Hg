using Mercurial;
using System.Text.RegularExpressions;

namespace Cake.Hg.Versioning
{
    internal sealed class TagMatch
    {
        public Tag Tag { get; set; }
        public Match Match { get; set; }

        public TagMatch(Tag tag, Match match)
        {
            Tag = tag;
            Match = match;
        }
    }
}
