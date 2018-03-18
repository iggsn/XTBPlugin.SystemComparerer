using System.Collections.Generic;
using System.Data;
using System.Linq;
using CRMP.XTBPlugin.SystemComparer.Logic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{
    internal class Entities
    {
        private List<EntityMetadata> _sourceEntities;
        private List<EntityMetadata> _targetEntities;

        private DataTable _dataTable;

        private IEnumerable<EntityMetadata> _intersect;


        public Entities()
        {
            _sourceEntities = new List<EntityMetadata>();
            _targetEntities = new List<EntityMetadata>();
        }

        internal void Add(EntityMetadata entityMetadata, ConnectionType connectionType = ConnectionType.Source)
        {
            if (connectionType == ConnectionType.Source)
            {
                _sourceEntities.Add(entityMetadata);
            }
            else
            {
                _targetEntities.Add(entityMetadata);
            }
        }

        private bool IsInTarget(EntityMetadata entityMetadata)
        {
            if (_intersect == null)
            {
               _intersect = _sourceEntities.Intersect(_targetEntities, new EntitiesComparer());
            }

            return _intersect.Contains(entityMetadata);
        }


        internal DataTable GetDataTable()
        {
            if (_dataTable == null)
            {
                _dataTable = InitializeDataTableWithHeaders();
            }

            if (_dataTable.Rows.Count == 0)
            {
                foreach (EntityMetadata entityMetadata in _sourceEntities)
                {
                    _dataTable.Rows.Add(
                        entityMetadata.DisplayName.UserLocalizedLabel.Label,
                        entityMetadata.SchemaName,
                        entityMetadata.LogicalName,
                        true,
                        IsInTarget(entityMetadata),
                        false
                    );
                }
            }

            return _dataTable;
        }

        private DataTable InitializeDataTableWithHeaders()
        {
            DataTable newTable = new DataTable("entites");
            newTable.Columns.Add("DisplayName");
            newTable.Columns.Add("SchemaName");
            newTable.Columns.Add("LogicalName");

            newTable.Columns.Add("IsInSource", typeof(bool));
            newTable.Columns.Add("IsInTarget", typeof(bool));
            newTable.Columns.Add("IsDifferent", typeof(bool));

            return newTable;
        }
    }
}
