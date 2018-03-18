using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{

    /// <summary>
    /// https://msdn.microsoft.com/de-de/library/bb460136(v=vs.110).aspx
    /// </summary>
    internal class EntitiesComparer : IEqualityComparer<KeyValuePair<string, EntityMetadata>>
    {
        public bool Equals(KeyValuePair<string, EntityMetadata> source, KeyValuePair<string, EntityMetadata> target)
        {
            if (ReferenceEquals(source.Value, target.Value)) return true;

            return source.Value != null && target.Value != null && source.Key.Equals(target.Key) && source.Value.LogicalName.Equals(target.Value.LogicalName);
        }

        public int GetHashCode(KeyValuePair<string, EntityMetadata> obj)
        {
            //Get hash code for the Name field if it is not null. 
            int hashProductName = obj.Value.LogicalName == null ? 0 : obj.Value.LogicalName.GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName; // ^ hashProductCode;
        }
    }
}
