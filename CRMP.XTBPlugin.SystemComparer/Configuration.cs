namespace CRMP.XTBPlugin.SystemComparer
{
    public class Configuration
    {
        internal bool IncludeAttributeMetadata { get; set; }

        internal bool IncludeForms { get; set; }

        internal bool IncludeViews { get; set; }

        internal bool ListHideEqualItems { get; set; }

        internal bool IgnoreManagedState { get; set; }

        public Configuration()
        {
            IncludeAttributeMetadata = true;
            IncludeForms = false;
            IncludeViews = false;
            ListHideEqualItems = true;
            IgnoreManagedState = true;
        }
    }
}
