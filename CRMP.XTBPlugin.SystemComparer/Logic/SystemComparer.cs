using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using CRMP.XTBPlugin.SystemComparer.Metadata;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace CRMP.XTBPlugin.SystemComparer.Logic
{
    class SystemComparer
    {
        //private Entities _entitiesModel;
        internal CustomizationRoot _sourceCustomizationRoot;
        internal CustomizationRoot _targetCustomizationRoot;

        private readonly ConnectionDetail _sourceConnection;
        private readonly ConnectionDetail _targetConnection;

        public SystemComparer(ConnectionDetail sourceConnection, ConnectionDetail targetConnection)
        {
            _sourceCustomizationRoot = new CustomizationRoot();
            _targetCustomizationRoot = new CustomizationRoot();

            _sourceConnection = sourceConnection;
            _targetConnection = targetConnection;
        }

        public void RetrieveMetadata(ConnectionType connectionType, Action<int, string> reportProgress)
        {
            reportProgress(0, $"Fetching Entity Metadata from {connectionType.ToString()}");

            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);
            CustomizationRoot customzationRoot = GetCustomizationRoot(connectionType);

            // Retrieve the MetaData.
            List<EntityMetadata> entitiesMetadata = crmServiceClient.GetAllEntityMetadata(true, EntityFilters.Entity);

            customzationRoot.EntitiesRaw = entitiesMetadata;

            /*reportProgress(0, $"Processing Entity Metadata from {connectionType.ToString()}");

            foreach (EntityMetadata entityMetadata in entitiesMetadata)
            {
                CustomizationEntity customizationEntity = new CustomizationEntity(entityMetadata.LogicalName, entityMetadata);

                customzationRoot.Entities.Add(customizationEntity);

                foreach (AttributeMetadata attributeMetadata in entityMetadata.Attributes)
                {
                    CustomizationAttribute customizationAttribute = new CustomizationAttribute(attributeMetadata.LogicalName,attributeMetadata);

                    customizationEntity.Attributes.Add(customizationAttribute);
                }
            }

            QueryExpression query = new QueryExpression
            {
                EntityName = "systemform",
                ColumnSet = new ColumnSet(true),
                PageInfo = new PagingInfo
                {
                    Count = 5000,
                    PageNumber = 1,
                    PagingCookie = null
                },
                Orders =
                {
                    new OrderExpression("objecttypecode", OrderType.Ascending)
                }
            };

            reportProgress(0, $"Retrieving and processing Forms from {connectionType.ToString()}");
            ExecuteQueryWithPaging(query, crmServiceClient, customzationRoot.Forms);

            crmServiceClient.RetrieveMultiple(query);*/
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

        private CustomizationRoot GetCustomizationRoot(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.Source:
                    return _sourceCustomizationRoot;
                case ConnectionType.Target:
                    return _targetCustomizationRoot;
                default:
                    throw new Exception("Something went wrong");
            }
        }

        private void ExecuteQueryWithPaging<TCustomization>(QueryExpression query, CrmServiceClient crmServiceClient, List<TCustomization> children)
            where TCustomization : new()
        {
            while (true)
            {
                RetrieveMultipleRequest request = new RetrieveMultipleRequest()
                {
                    Query = query
                };

                // Retrieve the MetaData.
                RetrieveMultipleResponse response = (RetrieveMultipleResponse)crmServiceClient.Execute(request);

                foreach (Entity entity in response.EntityCollection.Entities)
                {
                    Type classType = typeof(TCustomization);
                    ConstructorInfo classConstructor = classType.GetConstructor(new [] { typeof(string), typeof(Entity) });
                    TCustomization classInstance = (TCustomization)classConstructor.Invoke(new object[] { entity.LogicalName, entity });

                    children.Add(classInstance);
                }

                if (response.EntityCollection.MoreRecords)
                {
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = response.EntityCollection.PagingCookie;
                }
                else
                {
                    break;
                }
            }
        }

        internal DataSet CreateDataSet()
        {
            DataSet dataSet = new DataSet();

            //dataSet.Tables.Add(_entitiesModel.GetDataTable());
            //dataSet.Tables.Add(_entitiesModel._attributes.GetDataTable());

            /*DataRelation relation = new DataRelation("EntityAttributes",
                  dataSet.Tables["entities"].Columns["LogicalName"],
                  dataSet.Tables["attributes"].Columns["EntityLogicalName"]);

            dataSet.Relations.Add(relation);*/

            return dataSet;
        }
    }
}
