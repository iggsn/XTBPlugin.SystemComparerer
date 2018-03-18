using System;
using System.Data;
using CRMP.XTBPlugin.SystemComparer.DataModel;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace CRMP.XTBPlugin.SystemComparer.Logic
{
    class SystemComparer
    {
        private Entities _entitiesModel;

        private readonly ConnectionDetail _sourceConnection;
        private readonly ConnectionDetail _targetConnection;

        public SystemComparer(ConnectionDetail sourceConnection, ConnectionDetail targetConnection)
        {
            _entitiesModel = new Entities();

            _sourceConnection = sourceConnection;
            _targetConnection = targetConnection;
        }

        public void RetrieveMetadata(ConnectionType connectionType)
        {
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = false
            };

            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);

            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)crmServiceClient.Execute(request);

            foreach (EntityMetadata entityMetadata in response.EntityMetadata)
            {
                _entitiesModel.Add(entityMetadata, connectionType);
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
                    throw new Exception("Something went wrong");
            }
        }

        internal DataSet CreateDataSet()
        {
            DataSet dataSet = new DataSet();

            dataSet.Tables.Add(_entitiesModel.GetDataTable());

            return dataSet;
        }
    }
}
