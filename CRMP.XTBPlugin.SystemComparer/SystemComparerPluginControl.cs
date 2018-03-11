using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CRMP.XTBPlugin.SystemComparer.Logic;
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using XrmToolBox.Extensibility.Interfaces;

namespace CRMP.XTBPlugin.SystemComparer
{
    public partial class SystemComparerPluginControl : PluginControlBase, IXrmToolBoxPluginControl
    {

        private ConnectionDetail _sourceConnection;
        private ConnectionDetail _targetConnection;

        private Settings mySettings;

        public event EventHandler OnRequestConnection;

        private Logic.SystemComparer _systemComparer;

        public SystemComparerPluginControl()
        {
            InitializeComponent();
            _sourceConnection = ConnectionDetail;

        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            /*ShowInfoNotification("This is a notification that can lead to XrmToolBox repository",
                new Uri("http://github.com/MscrmTools/XrmToolBox"));*/

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            mySettings.LastUsedOrganizationWebappUrl = e.ConnectionDetail.WebApplicationUrl;
            LogInfo("Connection has changed to: {0}", e.ConnectionDetail.WebApplicationUrl);
        }

        private void buttonSourceChange_Click(object sender, EventArgs e)
        {
            if (OnRequestConnection != null)
            {
                var arg = new RequestConnectionEventArgs
                {
                    ActionName = "SourceOrganization",
                    Control = this
                };
                OnRequestConnection(this, arg);
            }
        }

        private void buttonChangeTarget_Click(object sender, EventArgs e)
        {
            if (OnRequestConnection != null)
            {
                var arg = new RequestConnectionEventArgs
                {
                    ActionName = "TargetOrganization",
                    Control = this
                };
                OnRequestConnection(this, arg);
            }
        }

        private void SetConnectionLabel(ConnectionDetail detail, string serviceType)
        {
            switch (serviceType)
            {
                case "Source":
                    labelSourceName.Text = detail.ConnectionName;
                    labelSourceName.ForeColor = Color.Green;
                    break;

                case "Target":
                    labelTargetName.Text = detail.ConnectionName;
                    labelTargetName.ForeColor = Color.Green;
                    break;
            }
        }

        public void UpdateConnection(IOrganizationService newService, ConnectionDetail connectionDetail,
            string actionName = "", object parameter = null)
        {
            if (actionName == "TargetOrganization")
            {
                _targetConnection = connectionDetail;
                SetConnectionLabel(connectionDetail, "Target");
            }
            else
            {
                _sourceConnection = connectionDetail;
                SetConnectionLabel(connectionDetail, "Source");
            }

            if (_targetConnection != null && _sourceConnection != null)
            {
                tbbLoadMetadata.Enabled = true;
            }
            else
            {
                tbbLoadMetadata.Enabled = false;
            }
        }

        private void tbbLoadMetadata_Click(object sender, EventArgs e)
        {
            LoadEntites();
            //ExecuteMethod(LoadEntites(_sourceConnection.ServiceClient));
        }

        private void LoadEntites()
        {
            _systemComparer = new Logic.SystemComparer(_sourceConnection, _targetConnection);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Metadata",
                Work = (worker, args) =>
                {
                    worker.ReportProgress(0, "Fetching Metadata from Source");
                    _systemComparer.RetrieveMetadata(ConnectionType.Source);
                    worker.ReportProgress(50, "Fetching Metadata from Target");
                    _systemComparer.RetrieveMetadata(ConnectionType.Target);

                    args.Result = _systemComparer;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    /*var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }*/
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }
    }
}