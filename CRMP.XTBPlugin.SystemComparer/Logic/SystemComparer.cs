using System;
using System.Collections.Generic;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace CRMP.XTBPlugin.SystemComparer.Logic
{
    class SystemComparer
    {
        private List<EntityMetadata> _sourceEntityMetadatas;
        private List<EntityMetadata> _targetEntityMetadatas;

        private readonly ConnectionDetail _sourceConnection;
        private readonly ConnectionDetail _targetConnection;

        public SystemComparer(ConnectionDetail sourceConnection, ConnectionDetail targetConnection)
        {
            _sourceEntityMetadatas = new List<EntityMetadata>();
            _targetEntityMetadatas = new List<EntityMetadata>();
            _sourceConnection = sourceConnection;
            _targetConnection = targetConnection;
        }

        public void RetrieveMetadata(ConnectionType connectionType)
        {
            List<EntityMetadata> list = new List<EntityMetadata>();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.All,
                RetrieveAsIfPublished = false
            };

            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);

            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)crmServiceClient.Execute(request);

            foreach (EntityMetadata entityMetadata in response.EntityMetadata)
            {
                list.Add(entityMetadata);
            }

            if (connectionType == ConnectionType.Source)
            {
                _sourceEntityMetadatas = list;
            }
            else
            {
                _targetEntityMetadatas = list;
            }
        }

        private CrmServiceClient GetCrmServiceClient(ConnectionType connectionType, bool forceNew = false)
        {
            switch (connectionType)
            {
                case ConnectionType.Source:
                    return _sourceConnection.GetCrmServiceClient(forceNew);
                case ConnectionType.Target:
                    return _targetConnection.GetCrmServiceClient(forceNew);
                default:
                    throw new Exception("Something wnt wrong");
            }
        }
    }
}
