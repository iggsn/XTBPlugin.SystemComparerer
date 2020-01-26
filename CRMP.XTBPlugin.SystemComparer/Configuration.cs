namespace CRMP.XTBPlugin.SystemComparer
{
    public class Configuration
    {
        internal bool IncludeAllMetadata { get; set; }

        internal bool IncludeForms { get; set; }

        internal bool IncludeViews { get; set; }

        internal bool ListHideEqualItems { get; set; }

        internal bool IgnoreManagedState { get; set; }

        public Configuration()
        {
            IncludeAllMetadata = false;
            IncludeForms = false;
            IncludeViews = false;
            ListHideEqualItems = true;
            IgnoreManagedState = true;
        }
    }
}
