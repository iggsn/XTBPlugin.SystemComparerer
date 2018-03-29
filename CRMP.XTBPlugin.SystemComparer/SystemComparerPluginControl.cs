using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CRMP.XTBPlugin.SystemComparer.DataModel;
using CRMP.XTBPlugin.SystemComparer.Logic;
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using XrmToolBox.Extensibility.Interfaces;

namespace CRMP.XTBPlugin.SystemComparer
{
    public partial class SystemComparerPluginControl : PluginControlBase, IXrmToolBoxPluginControl
    {
        const int StateImageIndexDashPlus = 0;
        const int StateImageIndexDashMinus = 1;

        const int DifferenceImageIndexUnchanged = 0;
        const int DifferenceImageIndexChanged = 1;
        const int DifferenceImageIndexNotInSource = 2;
        const int DifferenceImageIndexNotInTarget = 3;

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
                    _systemComparer.RetrieveMetadata(ConnectionType.Source, worker.ReportProgress);
                    _systemComparer.RetrieveMetadata(ConnectionType.Target, worker.ReportProgress);

                    args.Result = _systemComparer;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    var emds = (Logic.SystemComparer)args.Result;

                    MetadataComparer comparer = new MetadataComparer();

                    MetadataComparison comparison = null;
                    comparison = comparer.Compare(emds._sourceCustomizationRoot.EntitiesRaw,
                        emds._targetCustomizationRoot.EntitiesRaw);

                    comparisonListView.Items.Clear();

                    AddItem(comparison, null);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void AddItem(MetadataComparison customizationRoot, ListViewItem parentItem)
        {
            ListViewItem item = new ListViewItem
            {
                Text = customizationRoot.Name,
                Checked = false,
                StateImageIndex = customizationRoot.Children.Count > 0 ? StateImageIndexDashPlus : -1,
                Tag = customizationRoot,
                ImageIndex = GetImageIndex(customizationRoot),
                IndentCount = parentItem?.IndentCount + 1 ?? 0
            };

            object obj = customizationRoot.SourceValue ?? customizationRoot.TargetValue;
            if (obj != null && customizationRoot.Children.Count > 0)
            {
                item.SubItems.Add(customizationRoot.GetUnchangedCount().ToString());
                item.SubItems.Add(customizationRoot.GetChangedCount().ToString());
                item.SubItems.Add(customizationRoot.GetMissingInSourceCount().ToString());
                item.SubItems.Add(customizationRoot.GetMissingInTargetCount().ToString());
            }

            comparisonListView.Items.Insert(parentItem?.Index + 1 ?? 0, item);
        }

        private int GetImageIndex(MetadataComparison metadataComparison)
        {
            if (metadataComparison.IsDifferent)
            {
                if (metadataComparison.SourceValue == null)
                {
                    return DifferenceImageIndexNotInSource;
                }

                if (metadataComparison.TargetValue == null)
                {
                    return DifferenceImageIndexNotInTarget;
                }

                return DifferenceImageIndexChanged;
            }

            return DifferenceImageIndexUnchanged;
        }

        private void comparisonListView_Click(object sender, EventArgs e)
        {
            ListViewHitTestInfo hitTest = comparisonListView.HitTest(comparisonListView.PointToClient(MousePosition));
            if (hitTest.Location == ListViewHitTestLocations.StateImage)
            {
                ToggleItem(hitTest.Item);
            }
        }

        private void ToggleItem(ListViewItem item)
        {
            if (item.Checked) // expanded
            {
                using (new LockRedraw(comparisonListView.Handle))
                {
                    while (comparisonListView.Items.Count > item.Index + 1 &&
                           comparisonListView.Items[item.Index + 1].IndentCount > item.IndentCount)
                    {
                        comparisonListView.Items.RemoveAt(item.Index + 1);
                    }

                    item.Checked = false;
                    item.StateImageIndex = StateImageIndexDashPlus;
                }
            }
            else
            {
                MetadataComparison comparison = (MetadataComparison)item.Tag;
                if (comparison.Children.Count > 0)
                {
                    using (new LockRedraw(comparisonListView.Handle))
                    {
                        foreach (MetadataComparison childComparison in comparison.Children.AsEnumerable().Reverse())
                        {
                            AddItem(childComparison, item);
                        }
                        item.StateImageIndex = StateImageIndexDashMinus;
                        item.Checked = true;
                    }
                }
            }
        }

        private void comparisonListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                MetadataComparison comparison = (MetadataComparison)e.Item.Tag;

                var sourceString = JsonConvert.SerializeObject(comparison.SourceValue, Formatting.Indented, new JsonSerializerSettings() { MaxDepth = 1 });


            }
        }
    }
}