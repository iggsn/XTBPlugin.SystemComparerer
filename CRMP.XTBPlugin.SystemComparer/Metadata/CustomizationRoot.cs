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

        public List<CustomizationEntity> Forms { get; set; }

        public List<CustomizationEntity> Views { get; set; }

        public CustomizationRoot()
        {
            Name = "Root";
            EntitiesRaw = new List<EntityMetadata>();
            Forms = new List<CustomizationEntity>();
            Views = new List<CustomizationEntity>();
        }
    }

    public class CustomizationEntity
    {
        internal string Name { get; set; }
        public List<CustomizationType> CustomzationTypes { get; set; }

        public CustomizationEntity(string name)
        {
            Name = name;
            CustomzationTypes = new List<CustomizationType>();
        }
    }

    public class CustomizationType
    {
        internal string Name { get; set; }
        public List<Entity> Entities { get; set; }

        public CustomizationType(string name)
        {
            Name = name;
            Entities = new List<Entity>();
        }
    }
}
