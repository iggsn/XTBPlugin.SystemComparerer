namespace CRMP.XTBPlugin.SystemComparer
{
    internal class Configuration
    {
        internal bool IncludeAttributeMetadata { get; set; }

        internal bool IncludeForms { get; set; }

        internal bool IncludeViews { get; set; }

        public Configuration()
        {
            IncludeAttributeMetadata = true;
            IncludeForms = true;
            IncludeViews = true;
        }
    }
}
