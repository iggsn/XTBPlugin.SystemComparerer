using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{

    /// <summary>
    /// https://msdn.microsoft.com/de-de/library/bb460136(v=vs.110).aspx
    /// </summary>
    internal class EntitiesComparer : IEqualityComparer<EntityMetadata>
    {
        public bool Equals(EntityMetadata source, EntityMetadata target)
        {
            if (ReferenceEquals(source, target)) return true;

            return source != null && target != null && source.LogicalName.Equals(target.LogicalName);
        }

        public int GetHashCode(EntityMetadata obj)
        {
            //Get hash code for the Name field if it is not null. 
            int hashProductName = obj.LogicalName == null ? 0 : obj.LogicalName.GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName; // ^ hashProductCode;
        }
    }
}
