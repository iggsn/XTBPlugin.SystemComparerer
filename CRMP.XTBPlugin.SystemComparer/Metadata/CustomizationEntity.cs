using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationEntity
    {
        public string Name { get; set; }

        public EntityMetadata Object { get; set; }

        public List<CustomizationAttribute> Attributes { get; private set; }

        public CustomizationEntity(string name, EntityMetadata value) 
            : this()
        {
            Name = name;
            Object = value;
        }

        public CustomizationEntity()
        {
            Attributes = new List<CustomizationAttribute>();
        }
    }
}
