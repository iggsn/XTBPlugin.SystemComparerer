using System.Windows.Forms;

namespace CRMP.XTBPlugin.SystemComparer.Forms
{
    public partial class Options : Form
    {
        private readonly SystemComparerPluginControl _plugin;

        public Options(SystemComparerPluginControl plugin)
        {
            InitializeComponent();
            _plugin = plugin;
            PopulateSettings(_plugin.Settings);
        }

        private void PopulateSettings(Settings settings)
        {
            if (settings == null)
            {
                settings = new Settings();
            }

            checkBoxAllowStatistics.Checked = settings.AllowLogUsage;
            checkBoxSendExceptions.Checked = settings.AllowExceptionLogging;
        }

        internal Settings GetSettings()
        {
            Settings settings = _plugin.Settings;
            settings.AllowLogUsage = checkBoxAllowStatistics.Checked;
            settings.AllowExceptionLogging = checkBoxSendExceptions.Checked;

            return settings;
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, System.EventArgs e)
        {
            _plugin.Settings = GetSettings();
            _plugin.SaveSettings();
            Close();
        }
    }
}
