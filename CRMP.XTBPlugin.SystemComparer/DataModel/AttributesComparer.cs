using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{

    /// <summary>
    /// https://msdn.microsoft.com/de-de/library/bb460136(v=vs.110).aspx
    /// </summary>
    internal class AttributesComparer : IEqualityComparer<KeyValuePair<string, AttributeMetadata>>
    {
        public bool Equals(KeyValuePair<string, AttributeMetadata> source, KeyValuePair<string, AttributeMetadata> target)
        {
            if (ReferenceEquals(source.Value, target.Value)) return true;

            return source.Value != null && target.Value != null && source.Key.Equals(target.Key) && source.Value.LogicalName.Equals(target.Value.LogicalName);
        }

        public int GetHashCode(KeyValuePair<string, AttributeMetadata> obj)
        {
            //Get hash code for the Name field if it is not null. 
            int hashEntityLocalName = obj.Value.EntityLogicalName == null ? 0 : obj.Value.EntityLogicalName.GetHashCode();

            int hashAttributeLocalName = obj.Value.LogicalName == null ? 0 : obj.Value.LogicalName.GetHashCode();

            //Calculate the hash code for the product. 
            return hashEntityLocalName ^ hashAttributeLocalName;
        }
    }
}
