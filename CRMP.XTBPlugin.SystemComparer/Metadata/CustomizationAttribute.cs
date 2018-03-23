using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationAttribute
    {
        public string Name { get; set; }

        public AttributeMetadata Object { get; set; }

        public CustomizationAttribute(string name, AttributeMetadata value)
        {
            Name = name;
            Object = value;
        }
    }
}
