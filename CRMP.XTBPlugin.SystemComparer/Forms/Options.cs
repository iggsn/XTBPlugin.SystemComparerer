using System.Windows.Forms;

namespace CRMP.XTBPlugin.SystemComparer.Forms
{
    public partial class Options : Form
    {
        private SystemComparerPluginControl _plugin;

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

            checkBoxAllowStatistics.Checked = settings.AllowLogUsage.GetValueOrDefault(false);
            checkBoxSendExceptions.Checked = settings.AllowExceptionLogging.GetValueOrDefault(false);
        }

        internal Settings GetSettings()
        {
            Settings settings = _plugin.Settings;
            settings.AllowLogUsage = checkBoxAllowStatistics.Checked;
            settings.AllowExceptionLogging = checkBoxSendExceptions.Checked;

            return settings;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            _plugin.Settings = GetSettings();
            _plugin.SaveSettings();
            Close();
        }
    }
}
