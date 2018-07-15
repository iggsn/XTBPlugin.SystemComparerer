using System;
using System.Collections.Generic;
using CRMP.XTBPlugin.SystemComparer.AppCode;
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

        public void RetrieveMetadata(ConnectionType connectionType, bool includeAttributes , Action<int, string> reportProgress)
        {
            reportProgress(0, $"Fetching Entity Metadata from {connectionType.ToString()}");

            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);
            CustomizationRoot customzationRoot = GetCustomizationRoot(connectionType);

            // Retrieve the MetaData.
            List<EntityMetadata> entitiesMetadata = crmServiceClient.GetAllEntityMetadata(true, includeAttributes ? EntityFilters.Attributes : EntityFilters.All);

            customzationRoot.EntitiesRaw = entitiesMetadata;
        }

        public void RetrieveOrganization(ConnectionType connectionType, Action<int, string> reportProgress)
        {
            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);
            CustomizationRoot customzationRoot = GetCustomizationRoot(connectionType);

            QueryExpression query = new QueryExpression
            {
                EntityName = "organization",
                ColumnSet = new ColumnSet(true),
                PageInfo = new PagingInfo
                {
                    Count = 5000,
                    PageNumber = 1,
                    PagingCookie = null
                }
            };

            reportProgress(0, $"Retrieving and processing Organization data from {connectionType.ToString()}");
            customzationRoot.Organizations = ExecuteQueryWithPaging(query, crmServiceClient);
        }

        public void RetrieveForms(ConnectionType connectionType, bool execute, Action<int, string> reportProgress)
        {
            if (!execute) return;

            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);
            CustomizationRoot customizationRoot = GetCustomizationRoot(connectionType);

            QueryExpression query = new QueryExpression
            {
                EntityName = "systemform",
                ColumnSet = new ColumnSet("formid", "introducedversion", "description", "isairmerged", "iscustomizable", "formpresentation", "formxml", "componentstate", "isdesktopenabled", "formjson", "formidunique", "version", "versionnumber", "canbedeleted", "ismanaged", "formactivationstate", "uniquename", "type", "objecttypecode", "isdefault"),
                PageInfo = new PagingInfo
                {
                    Count = 5000,
                    PageNumber = 1,
                    PagingCookie = null
                },
                Orders =
                {
                    new OrderExpression("objecttypecode", OrderType.Ascending),
                    new OrderExpression("name", OrderType.Ascending),
                    //new OrderExpression("type", OrderType.Ascending)
                }
            };

            reportProgress(0, $"Retrieving and processing system forms data from {connectionType.ToString()}");
            List<Entity> formsResult = ExecuteQueryWithPaging(query, crmServiceClient);

            foreach (Entity form in formsResult)
            {
                string entityName = form.GetAttributeValue<string>("objecttypecode");
                string typeName = form.FormattedValues["type"];

                FormEntity formEntity = customizationRoot.Forms.Find(e => e.Name == entityName);
                if (formEntity == null)
                {
                    formEntity = new FormEntity(entityName);
                    customizationRoot.Forms.Add(formEntity);
                }

                FormType formType = formEntity.FormTypes.Find(t => t.Name == typeName);
                if (formType == null)
                {
                    formType = new FormType(typeName);
                    formEntity.FormTypes.Add(formType);
                }

                formType.Forms.Add(form);
            }
        }

        public void RetrieveViews(ConnectionType connectionType, bool execute, Action<int, string> reportProgress)
        {
            if (!execute) return;

            CrmServiceClient crmServiceClient = GetCrmServiceClient(connectionType);
            CustomizationRoot customizationRoot = GetCustomizationRoot(connectionType);

            QueryExpression query = new QueryExpression
            {
                EntityName = "savedquery",
                ColumnSet = new ColumnSet("introducedversion", "description", "iscustomizable", "componentstate", "versionnumber", "canbedeleted", "ismanaged", "solutionid", "isdefault", "isuserdefined", "savedqueryid", "statecode", "savedqueryidunique", "conditionalformatting", "name", "querytype", "isquickfindquery", "columnsetxml", "offlinesqlquery", "queryappusage", "advancedgroupby", "fetchxml", "returnedtypecode", "isprivate", "iscustom", "layoutjson", "statuscode", "queryapi", "organizationtaborder", "layoutxml"),
                PageInfo = new PagingInfo
                {
                    Count = 5000,
                    PageNumber = 1,
                    PagingCookie = null
                },
                Orders =
                {
                    new OrderExpression("returnedtypecode", OrderType.Ascending),
                    new OrderExpression("name", OrderType.Ascending),
                    //new OrderExpression("type", OrderType.Ascending)
                }
            };

            reportProgress(0, $"Retrieving and processing system view data from {connectionType.ToString()}");
            List<Entity> viewsResult = ExecuteQueryWithPaging(query, crmServiceClient);

            foreach (Entity view in viewsResult)
            {
                string entityName = view.GetAttributeValue<string>("returnedtypecode");
                string typeName = view.FormattedValues["querytype"];

                ViewEntity viewEntity = customizationRoot.Views.Find(e => e.Name == entityName);
                if (viewEntity == null)
                {
                    viewEntity = new ViewEntity(entityName);
                    customizationRoot.Views.Add(viewEntity);
                }

                ViewType viewType = viewEntity.ViewTypes.Find(t => t.Name == typeName);
                if (viewType == null)
                {
                    viewType = new ViewType(typeName);
                    viewEntity.ViewTypes.Add(viewType);
                }

                viewType.Views.Add(view);
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

        private List<Entity> ExecuteQueryWithPaging(QueryExpression query, CrmServiceClient crmServiceClient)
        {
            List<Entity> results = new List<Entity>();
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
                    results.Add(entity);
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

            return results;
        }
    }
}
