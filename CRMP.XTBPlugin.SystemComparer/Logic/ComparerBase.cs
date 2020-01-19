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

        protected static bool IsSimpleType(Type type)
        {
            return (!type.IsClass || type == typeof(String));
        }

        protected static Array ToArray(IEnumerable enumerable)
        {
            if (enumerable == null) return null;
            if (enumerable.GetType().IsArray) return (Array)enumerable;

            Type elementType = enumerable.GetType().GetGenericArguments().Any() ? enumerable.GetType().GetGenericArguments()[0] : null;

            string typeName = elementType != null ? elementType.Name : enumerable.GetType().Name;


            switch (typeName)
            {
                case "EntityMetadata":
                    {
                        return enumerable.Cast<EntityMetadata>().ToArray();
                    }
                case "AttributeMetadata":
                    {
                        return enumerable.Cast<AttributeMetadata>().ToArray();
                    }
                case "OptionMetadataCollection":
                    {
                        return enumerable.Cast<OptionMetadata>().ToArray();
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

            if (typeof(OptionMetadata).IsAssignableFrom(elementType))
            {
                SyncOptionMetadata(ref source, ref target);
                return;
            }
            
            if(typeof(ManyToManyRelationshipMetadata).IsAssignableFrom(elementType))
            {
                SyncManyToManyRelationshipMetadata(ref source, ref target);
                return;
            }

            if (typeof(OneToManyRelationshipMetadata).IsAssignableFrom(elementType))
            {
                SyncOneToManyRelationshipMetadata(ref source, ref target);
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

        private static void SyncOptionMetadata(ref Array source, ref Array target)
        {
            OptionMetadata[] sourceIdentities = source?.Cast<OptionMetadata>().ToArray() ?? new OptionMetadata[0];

            OptionMetadata[] targetIdentities = target?.Cast<OptionMetadata>().ToArray() ?? new OptionMetadata[0];

            // create a list of combined entities to determine the order by 
            // which both lists will be sorted
            int?[] combinedIdentities = sourceIdentities.Select(i => i.Value)
                .Union(targetIdentities.Select(i => i.Value))
                .OrderBy(s => s)
                .ToArray();

            source = SortAndPad3(combinedIdentities, sourceIdentities);
            target = SortAndPad3(combinedIdentities, targetIdentities);
        }

        private static void SyncManyToManyRelationshipMetadata(ref Array source, ref Array target)
        {
            ManyToManyRelationshipMetadata[] sourceIdentities = source?.Cast<ManyToManyRelationshipMetadata>().ToArray() ?? new ManyToManyRelationshipMetadata[0];

            ManyToManyRelationshipMetadata[] targetIdentities = target?.Cast<ManyToManyRelationshipMetadata>().ToArray() ?? new ManyToManyRelationshipMetadata[0];

            // create a list of combined entities to determine the order by 
            // which both lists will be sorted
            string[] combinedIdentities = sourceIdentities.Select(i => i.IntersectEntityName)
                .Union(targetIdentities.Select(i => i.IntersectEntityName))
                .OrderBy(s => s)
                .ToArray();

            source = SortAndPad4(combinedIdentities, sourceIdentities);
            target = SortAndPad4(combinedIdentities, targetIdentities);
        }

        private static void SyncOneToManyRelationshipMetadata(ref Array source, ref Array target)
        {
            OneToManyRelationshipMetadata[] sourceIdentities = source?.Cast<OneToManyRelationshipMetadata>().ToArray() ?? new OneToManyRelationshipMetadata[0];

            OneToManyRelationshipMetadata[] targetIdentities = target?.Cast<OneToManyRelationshipMetadata>().ToArray() ?? new OneToManyRelationshipMetadata[0];

            // create a list of combined entities to determine the order by 
            // which both lists will be sorted
            string[] combinedIdentities = sourceIdentities.Select(i => i.SchemaName)
                .Union(targetIdentities.Select(i => i.SchemaName))
                .OrderBy(s => s)
                .ToArray();

            source = SortAndPad5(combinedIdentities, sourceIdentities);
            target = SortAndPad5(combinedIdentities, targetIdentities);
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

        private static Array SortAndPad3(int?[] identityKeys, OptionMetadata[] array)
        {
            if (array == null) return null;

            return identityKeys
                .Select(k => array.FirstOrDefault(i => i.Value == k))
                .ToArray();
        }

        private static Array SortAndPad4(string[] identityKeys, ManyToManyRelationshipMetadata[] array)
        {
            if (array == null) return null;

            return identityKeys
                .Select(k => array.FirstOrDefault(i => i.IntersectEntityName == k))
                .ToArray();
        }

        private static Array SortAndPad5(string[] identityKeys, OneToManyRelationshipMetadata[] array)
        {
            if (array == null) return null;

            return identityKeys
                .Select(k => array.FirstOrDefault(i => i.SchemaName == k))
                .ToArray();
        }
    }
}
