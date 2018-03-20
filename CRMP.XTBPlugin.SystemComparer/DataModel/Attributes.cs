using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CRMP.XTBPlugin.SystemComparer.Logic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{
    internal class Attributes
    {
        private Dictionary<string, AttributeMetadata> _sourceAttributes;
        private Dictionary<string, AttributeMetadata> _targetAttributes;

        private DataTable _dataTable;

        private IEnumerable<KeyValuePair<string, AttributeMetadata>> _intersect;


        public Attributes()
        {
            _sourceAttributes = new Dictionary<string, AttributeMetadata>();
            _targetAttributes = new Dictionary<string, AttributeMetadata>();
        }

        internal void Add(EntityMetadata entityMetadata, ConnectionType connectionType = ConnectionType.Source)
        {
            if (connectionType == ConnectionType.Source)
            {
                foreach (AttributeMetadata attributeMetadata in entityMetadata.Attributes)
                {
                    _sourceAttributes.Add($"{attributeMetadata.EntityLogicalName}.{attributeMetadata.LogicalName}", attributeMetadata);
                }
            }
            else
            {
                foreach (AttributeMetadata attributeMetadata in entityMetadata.Attributes)
                {
                    _targetAttributes.Add($"{attributeMetadata.EntityLogicalName}.{attributeMetadata.LogicalName}", attributeMetadata);
                }
            }
        }

        private bool IsInBoth(AttributeMetadata attributeMetadata)
        {
            if (_intersect == null)
            {
                _intersect = _sourceAttributes.Intersect(_targetAttributes, new AttributesComparer());
            }

            return _intersect.Contains(new KeyValuePair<string, AttributeMetadata>($"{attributeMetadata.EntityLogicalName}.{attributeMetadata.LogicalName}", attributeMetadata), new AttributesComparer());
        }


        internal DataTable GetDataTable()
        {
            if (_dataTable == null)
            {
                _dataTable = InitializeDataTableWithHeaders();
            }

            if (_dataTable.Rows.Count == 0)
            {
                /*Parallel.ForEach(_sourceAttributes.Values.AsEnumerable(), attributeMetadata =>
                {
                    _dataTable.Rows.Add(
                        attributeMetadata.EntityLogicalName,
                        attributeMetadata.DisplayName.UserLocalizedLabel == null ? string.Empty : attributeMetadata.DisplayName.UserLocalizedLabel.Label,
                        attributeMetadata.SchemaName,
                        attributeMetadata.LogicalName,
                        attributeMetadata.AttributeTypeName,
                        true,
                        IsInBoth(attributeMetadata),
                        false
                    );
                });*/

                foreach (AttributeMetadata attributeMetadata in _sourceAttributes.Values)
                {
                    var inBoth = IsInBoth(attributeMetadata);
                    _dataTable.Rows.Add(
                        attributeMetadata.EntityLogicalName,
                        attributeMetadata.DisplayName.UserLocalizedLabel == null ? string.Empty : attributeMetadata.DisplayName.UserLocalizedLabel.Label,
                        attributeMetadata.SchemaName,
                        attributeMetadata.LogicalName,
                        attributeMetadata.AttributeTypeName,
                        true,
                        inBoth,
                        !inBoth
                    );
                }

                foreach (AttributeMetadata attributeMetadata in _targetAttributes.Values)
                {
                    if (!IsInBoth(attributeMetadata))
                    {
                        _dataTable.Rows.Add(
                            attributeMetadata.EntityLogicalName,
                            attributeMetadata.DisplayName.UserLocalizedLabel == null ? string.Empty : attributeMetadata.DisplayName.UserLocalizedLabel.Label,
                            attributeMetadata.SchemaName,
                            attributeMetadata.LogicalName,
                            attributeMetadata.AttributeTypeName,
                            false,
                            true,
                            true
                        );
                    }
                }
            }

            return _dataTable;
        }

        private DataTable InitializeDataTableWithHeaders()
        {
            DataTable newTable = new DataTable("attributes");
            newTable.Columns.Add("EntityLogicalName");
            newTable.Columns.Add("DisplayName");
            newTable.Columns.Add("SchemaName");
            newTable.Columns.Add("LogicalName");
            newTable.Columns.Add("AttributeTypeName");

            newTable.Columns.Add("IsInSource", typeof(bool));
            newTable.Columns.Add("IsInTarget", typeof(bool));
            newTable.Columns.Add("IsDifferent", typeof(bool));

            newTable.PrimaryKey = new[] { newTable.Columns["EntityLogicalName"], newTable.Columns["LogicalName"] };

            return newTable;
        }
    }
}
