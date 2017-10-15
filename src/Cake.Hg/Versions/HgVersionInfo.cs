﻿using Mercurial;
using System;

namespace Cake.Hg.Versions
{
    /// <summary>
    /// Info about project version in mercurial repository
    /// </summary>
    public sealed class HgVersionInfo
    {
        /// <summary>
        /// Project name
        /// </summary>
        public string Project { get; set; }
        
        /// <summary>
        /// Project version
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Changeset, in wich current project version was assigned
        /// </summary>
        public Changeset Changeset { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public HgVersionInfo(string project)
        {
            Project = project;
            Version = new Version(0, 0, 0);
            Changeset = new Changeset();
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="project">Project name</param>
        /// <param name="version">Project version</param>
        /// <param name="changeset">Changeset, in wich current project version was assigned</param>
        public HgVersionInfo(string project, Version version, Changeset changeset)
        {
            Project = project;
            Version = version;
            Changeset = changeset;
        }
    }
}