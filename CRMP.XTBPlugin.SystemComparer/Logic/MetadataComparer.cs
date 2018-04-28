using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CRMP.XTBPlugin.SystemComparer.DataModel;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Logic
{
    public class MetadataComparer
    {
        public MetadataComparison Compare(string name, List<EntityMetadata> source, List<EntityMetadata> target)
        {
            MetadataComparison entities = new MetadataComparison(name, source, target, null);
            BuildComparisons(entities, null, source, target);

            return entities;
        }

        private void BuildComparisons(MetadataComparison parent, PropertyInfo prop, object source, object target)
        {
            // Make sure at least one value is not null
            if (source != null || target != null)
            {
                // Extract the value types
                Type type = GetCommonType(source, target);

                // Don't continue if the types differ
                if (type == null)
                {
                    parent.IsDifferent = true;
                }
                else
                {
                    MetadataComparison originalParent = parent;

                    // Determine if a new CustomizationComparison node should be created
                    if (type != typeof(List<EntityMetadata>)) //&& ComparisonTypeMap.IsTypeComparisonType(type))
                    {
                        string name;

                        switch (type.Name)
                        {
                            case "EntityMetadata":
                            {
                                name = ((EntityMetadata)(source ?? target)).LogicalName;
                                break;
                            }
                            case "AttributeMetadata":
                            case "StringAttributeMetadata":
                            case "MemoAttributeMetadata":
                            case "DoubleAttributeMetadata":
                            case "IntegrationAttributeMetadata":
                            case "MoneyAttributeMetadata":
                            case "DateTimeAttributeMetadata":
                            case "LookupAttributeMetadata":
                            case "DecimalAttributeMetadata":
                            case "PicklistAttributeMetadata":
                            case "IntegerAttributeMetadata":
                            case "BooleanAttributeMetadata":
                            case "ImageAttributeMetadata":
                            case "BigIntAttributeMetadata":
                            case "EntityNameAttributeMetadata":
                            case "StateAttributeMetadata":
                            case "StatusAttributeMetadata":
                                {
                                name = ((AttributeMetadata)(source ?? target)).LogicalName;
                                break;
                                }
                            default:
                                name = prop.Name;
                                break;
                        }

                        parent = new MetadataComparison(name, source, target, type)
                        {
                            ParentProperty = prop
                        };
                        originalParent.Children.Add(parent);
                    }

                    if (IsSimpleType(type))
                    {
                        // for simple types just compare values
                         if (!Equals(source, target))
                         {
                             originalParent.IsDifferent = true;
                             parent.IsDifferent = true;
                         }
                    }
                    else if (typeof(IEnumerable).IsAssignableFrom(type))
                    {
                        // Several arrays need to be sorted by a specific property (for example: Entity name)
                        originalParent.IsDifferent |= BuildArrayComparisonTypes(parent, prop, (IEnumerable)source, (IEnumerable)target);
                    }
                    else
                    {
                        // for classes, just compare each property
                        foreach (PropertyInfo p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            if (p.CanRead)
                            {
                                object sourceValue = source != null ? p.GetValue(source, null) : null;
                                object targetValue = target != null ? p.GetValue(target, null) : null;

                                BuildComparisons(parent, p, sourceValue, targetValue);
                                originalParent.IsDifferent |= parent.IsDifferent;
                            }
                        }
                    }
                }
            }
        }

        private static Type GetCommonType(object source, object target)
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

        private static bool IsSimpleType(Type type)
        {
            return (!type.IsClass || type == typeof(String));
        }

        private bool BuildArrayComparisonTypes(MetadataComparison parent, PropertyInfo prop, IEnumerable source, IEnumerable target)
        {
            bool isDifferent = false;

            Array sourceArray = ToArray(source);
            Array targetArray = ToArray(target);

            // If the arrays need special sorting, this will sort them and 
            // insert nulls for the missing entries from either the source 
            // or target.
            SynchronizeArraysByIdentity(ref sourceArray, ref targetArray);

            int sourceLength = sourceArray?.Length ?? 0;
            int targetLength = targetArray?.Length ?? 0;

            for (int i = 0; i < Math.Max(sourceLength, targetLength); i++)
            {
                object sourceItem = i < sourceLength ? sourceArray.GetValue(i) : null;
                object targetItem = i < targetLength ? targetArray.GetValue(i) : null;

                BuildComparisons(parent, prop, sourceItem, targetItem);
                isDifferent |= parent.IsDifferent;
            }

            return isDifferent;
        }

        private static Array ToArray(IEnumerable enumerable)
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

        private static void SynchronizeArraysByIdentity(ref Array source, ref Array target)
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
