using System;
using Mercurial;

namespace Cake.Hg.Versions
{
    public sealed class HgVersion
    {
        public string Project { get; set; }
        public Version Version { get; set; }
        public Changeset Changeset { get; set; }

        public HgVersion()
        {
            Project = string.Empty;
            Version = new Version(0, 0, 0, 0);
            Changeset = new Changeset();
        }
        
        public HgVersion(string project, Version version, Changeset changeset)
        {
            Project = project;
            Version = version;
            Changeset = changeset;
        }
    }
}