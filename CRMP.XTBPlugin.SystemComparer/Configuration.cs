namespace CRMP.XTBPlugin.SystemComparer
{
    internal class Configuration
    {
        internal bool IncludeAttributeMetadata { get; set; }

        internal bool IncludeForms { get; set; }

        internal bool IncludeViews { get; set; }

        internal bool ListHideEqualItems { get; set; }

        public Configuration()
        {
            IncludeAttributeMetadata = true;
            IncludeForms = false;
            IncludeViews = false;
            ListHideEqualItems = true;
        }
    }
}
