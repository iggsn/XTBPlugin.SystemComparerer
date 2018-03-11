using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void RetrieveMetadata(string type)
        {
            List<EntityMetadata> list = new List<EntityMetadata>();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.All,
                RetrieveAsIfPublished = false
            };

            CrmServiceClient crmServiceClient = type == "Source"
                ? _sourceConnection.GetCrmServiceClient()
                : _targetConnection.GetCrmServiceClient();

            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)crmServiceClient.Execute(request);

            foreach (EntityMetadata entityMetadata in response.EntityMetadata)
            {
                list.Add(entityMetadata);
            }

            if (type == "Source")
            {
                _sourceEntityMetadatas = list;
            }
            else
            {
                _targetEntityMetadatas = list;
            }
        }
    }
}
