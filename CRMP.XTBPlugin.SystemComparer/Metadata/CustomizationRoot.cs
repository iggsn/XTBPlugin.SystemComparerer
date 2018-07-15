using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationRoot
    {
        public string Name { get; set; }

        public List<EntityMetadata> EntitiesRaw { get;  set; }

        public List<Entity> Organizations { get; set; }

        public List<FormEntity> Forms { get; set; }

        public List<ViewEntity> Views { get; set; }

        public CustomizationRoot()
        {
            Name = "Root";
            EntitiesRaw = new List<EntityMetadata>();
            Forms = new List<FormEntity>();
            Views = new List<ViewEntity>();
        }
    }

    public class FormEntity
    {
        public string Name { get; set; }
        public List<FormType> FormTypes { get; set; }

        public FormEntity(string name)
        {
            Name = name;
            FormTypes = new List<FormType>();
        }
    }

    public class FormType
    {
        public string Name { get; set; }
        public List<Entity> Forms { get; set; }

        public FormType(string name)
        {
            Name = name;
            Forms = new List<Entity>();
        }
    }

    public class ViewEntity
    {
        public string Name { get; set; }
        public List<ViewType> ViewTypes { get; set; }

        public ViewEntity(string name)
        {
            Name = name;
            ViewTypes = new List<ViewType>();
        }
    }

    public class ViewType
    {
        public string Name { get; set; }
        public List<Entity> Views { get; set; }

        public ViewType(string name)
        {
            Name = name;
            Views = new List<Entity>();
        }
    }
}
