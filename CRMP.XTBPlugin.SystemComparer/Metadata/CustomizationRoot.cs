using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationRoot
    {
        public string Name { get; set; }

        public List<EntityMetadata> EntitiesRaw { get;  set; }

        public List<CustomizationEntity> Entities { get; private set; }

        public List<CustomizationForms> Forms { get; private set; }

        public CustomizationRoot()
        {
            Name = "Root";
            EntitiesRaw = new List<EntityMetadata>();
            Entities = new List<CustomizationEntity>();
            Forms = new List<CustomizationForms>();
        }
    }
}
