using System.Collections.Generic;
using System.Data;
using System.Linq;
using CRMP.XTBPlugin.SystemComparer.Logic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{
    internal class Entities
    {
        private Dictionary<string, EntityMetadata> _sourceEntities;
        private Dictionary<string, EntityMetadata> _targetEntities;

        private DataTable _entityDataTable;

        private IEnumerable<KeyValuePair<string, EntityMetadata>> _intersect;

        internal Attributes _attributes;


        public Entities()
        {
            _sourceEntities = new Dictionary<string, EntityMetadata>();
            _targetEntities = new Dictionary<string, EntityMetadata>();

            _attributes = new Attributes();
        }

        internal void Add(EntityMetadata entityMetadata, ConnectionType connectionType = ConnectionType.Source)
        {
            if (connectionType == ConnectionType.Source)
            {
                _sourceEntities.Add(entityMetadata.LogicalName, entityMetadata);
            }
            else
            {
                _targetEntities.Add(entityMetadata.LogicalName, entityMetadata);
            }

            _attributes.Add(entityMetadata, connectionType);
        }

        private bool IsInBoth(EntityMetadata entityMetadata)
        {
            if (_intersect == null)
            {
               _intersect = _sourceEntities.Intersect(_targetEntities, new EntitiesComparer());
            }

            return _intersect.Contains(new KeyValuePair<string, EntityMetadata>(entityMetadata.LogicalName, entityMetadata), new EntitiesComparer());
        }


        internal DataTable GetDataTable()
        {
            if (_entityDataTable == null)
            {
                _entityDataTable = InitializeDataTableWithHeaders();
            }

            if (_entityDataTable.Rows.Count == 0)
            {
                /*Parallel.ForEach(_sourceEntities.Values.AsEnumerable(), entityMetadata =>
                {
                    _entityDataTable.Rows.Add(
                        entityMetadata.DisplayName.UserLocalizedLabel == null ? string.Empty : entityMetadata.DisplayName.UserLocalizedLabel.Label,
                        entityMetadata.SchemaName,
                        entityMetadata.LogicalName,
                        true,
                        IsInBoth(entityMetadata),
                        false
                    );
                });*/
                foreach (EntityMetadata entityMetadata in _sourceEntities.Values)
                {
                    _entityDataTable.Rows.Add(
                        entityMetadata.DisplayName.UserLocalizedLabel == null ? string.Empty : entityMetadata.DisplayName.UserLocalizedLabel.Label,
                        entityMetadata.SchemaName,
                        entityMetadata.LogicalName,
                        true,
                        IsInBoth(entityMetadata),
                        false
                    );
                }

                foreach (EntityMetadata entityMetadata in _targetEntities.Values)
                {
                    if (!IsInBoth(entityMetadata))
                    {
                        _entityDataTable.Rows.Add(
                            entityMetadata.DisplayName.UserLocalizedLabel == null ? string.Empty : entityMetadata.DisplayName.UserLocalizedLabel.Label,
                            entityMetadata.SchemaName,
                            entityMetadata.LogicalName,
                            false,
                            true,
                            true
                        );
                    }
                }
            }

            return _entityDataTable;
        }

        private DataTable InitializeDataTableWithHeaders()
        {
            DataTable newTable = new DataTable("entities");
            newTable.Columns.Add("DisplayName");
            newTable.Columns.Add("SchemaName");
            newTable.Columns.Add("LogicalName");

            newTable.Columns.Add("IsInSource", typeof(bool));
            newTable.Columns.Add("IsInTarget", typeof(bool));
            newTable.Columns.Add("IsDifferent", typeof(bool));

            newTable.PrimaryKey = new[] { newTable.Columns["LogicalName"] };

            return newTable;
        }
    }
}
