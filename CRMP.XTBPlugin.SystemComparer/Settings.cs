namespace CRMP.XTBPlugin.SystemComparer
{
    /// <summary>
    /// This class can help you to store settings for your plugin
    /// </summary>
    /// <remarks>
    /// This class must be XML serializable
    /// </remarks>
    public class Settings
    {
        /// <summary>
        /// Enables the event logging to Application Insight
        /// </summary>
        public bool AllowLogUsage { get; set; }

        /// <summary>
        /// Enables the Exception Logging to Application Insight
        /// </summary>
        public bool AllowExceptionLogging { get; set; }
    }
}