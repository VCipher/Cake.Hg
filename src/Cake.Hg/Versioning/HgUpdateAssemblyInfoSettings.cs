namespace Cake.Hg.Versioning
{
    public class HgUpdateAssemblyInfoSettings : HgIncrementVersionSettings
    {
        /// <summary>
        /// Relative AssemblyInfo.cs file path
        /// </summary>
        public string AssembyInfoPath { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public HgUpdateAssemblyInfoSettings() : base()
        {
            AssembyInfoPath = "Properties/AssemblyInfo.cs";
        }
    }
}
