namespace Cake.Hg.Versioning
{
    public class HgVersionSettings
    {
        /// <summary>
        /// Branch name
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public HgVersionSettings()
        {
            Branch = "default";
            ProjectName = string.Empty;
        }
    }
}