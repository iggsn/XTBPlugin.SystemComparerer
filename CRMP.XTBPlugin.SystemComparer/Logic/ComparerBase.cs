using System;
using System.Collections;
using System.Linq;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Logic
{
    public class ComparerBase
    {
        protected static Type GetCommonType(object source, object target)
        {
            Type type = null;

            if (source != null && target != null)
            {
                if (source.GetType() == target.GetType())
                {
                    type = source.GetType();
                }
            }
            else
            {
                type = (source ?? target).GetType();
            }

            return type;
        }

        protected static Type GetKeyValuePairType(object source, object target)
        {
            Type type = null;

            if (source != null && target != null)
            {
                if (((dynamic)source).Value.GetType() == ((dynamic)target).Value.GetType())
                {
                    type = ((dynamic)source).Value.GetType();
                }
            }
            else
            {
                type = ((dynamic)(source ?? target)).Value.GetType();
            }

            return type;
        }

        protected static bool IsSimpleType(Type type)
        {
            return (!type.IsClass || type == typeof(String));
        }

        protected static Array ToArray(IEnumerable enumerable)
        {
            if (enumerable == null) return null;
            if (enumerable.GetType().IsArray) return (Array)enumerable;

            Type elementType = enumerable.GetType().GetGenericArguments().Any() ? enumerable.GetType().GetGenericArguments()[0] : null;

            if (elementType != null)
            {

                switch (elementType.Name)
                {
                    case "EntityMetadata":
                        {
                            return enumerable.Cast<EntityMetadata>().ToArray();
                        }
                    case "AttributeMetadata":
                        {
                            return enumerable.Cast<AttributeMetadata>().ToArray();
                        }
                }
            }

            return enumerable.Cast<object>().ToArray();
        }

        protected static void SynchronizeArraysByIdentity(ref Array source, ref Array target)
        {
            if (source == null && target == null) return;

            // Only proceed if the array elements implement IIdentifiable.
            Type elementType = (source ?? target).GetType().GetElementType();
            //if (!typeof(EntityMetadata).IsAssignableFrom(elementType)) return;

            if (typeof(EntityMetadata).IsAssignableFrom(elementType))
            {
                SyncEntityMetadata(ref source, ref target);
                return;
            }
            if (typeof(AttributeMetadata).IsAssignableFrom(elementType))
            {
                SyncAttributeMetadata(ref source, ref target);
                return;
            }
        }

        private static void SyncEntityMetadata(ref Array source, ref Array target)
        {
            EntityMetadata[] sourceIdentities = source?.Cast<EntityMetadata>().ToArray() ?? new EntityMetadata[0];

            EntityMetadata[] targetIdentities = target?.Cast<EntityMetadata>().ToArray() ?? new EntityMetadata[0];

            // create a list of combined entities to determine the order by 
            // which both lists will be sorted
            string[] combinedIdentities = sourceIdentities.Select(i => i.LogicalName)
                .Union(targetIdentities.Select(i => i.LogicalName))
                .OrderBy(s => s)
                .ToArray();

            source = SortAndPad(combinedIdentities, sourceIdentities);
            target = SortAndPad(combinedIdentities, targetIdentities);
        }

        private static void SyncAttributeMetadata(ref Array source, ref Array target)
        {
            AttributeMetadata[] sourceIdentities = source?.Cast<AttributeMetadata>().ToArray() ?? new AttributeMetadata[0];

            AttributeMetadata[] targetIdentities = target?.Cast<AttributeMetadata>().ToArray() ?? new AttributeMetadata[0];

            // create a list of combined entities to determine the order by 
            // which both lists will be sorted
            string[] combinedIdentities = sourceIdentities.Select(i => i.LogicalName)
                .Union(targetIdentities.Select(i => i.LogicalName))
                .OrderBy(s => s)
                .ToArray();

            source = SortAndPad2(combinedIdentities, sourceIdentities);
            target = SortAndPad2(combinedIdentities, targetIdentities);
        }

        /// <summary>
        /// Sorts an array based on a set of keys and fills in missing key values with null.
        /// </summary>
        /// <param name="identityKeys">The identity keys.</param>
        /// <param name="array">The array.</param>
        /// <returns>The sorted array.</returns>
        private static Array SortAndPad(string[] identityKeys, EntityMetadata[] array)
        {
            if (array == null) return null;

            return identityKeys
                .Select(k => array.FirstOrDefault(i => i.LogicalName == k))
                .ToArray();
        }

        private static Array SortAndPad2(string[] identityKeys, AttributeMetadata[] array)
        {
            if (array == null) return null;

            return identityKeys
                .Select(k => array.FirstOrDefault(i => i.LogicalName == k))
                .ToArray();
        }
    }
}
