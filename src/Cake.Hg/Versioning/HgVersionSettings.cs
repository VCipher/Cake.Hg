namespace Cake.Hg.Versioning
{
    public class HgVersionSettings
    {
        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public HgVersionSettings()
        {
            ProjectName = string.Empty;
        }
    }
}