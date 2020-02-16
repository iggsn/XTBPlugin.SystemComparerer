using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CRMP.XTBPlugin.SystemComparer.DataModel;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Logic
{
    public class MetadataComparer : ComparerBase
    {
        private readonly Configuration _configuration;

        public MetadataComparer()
        {
            IgnoreList.Add("MetadataId");
            IgnoreList.Add("ColumnNumber");
            IgnoreList.Add("PrivilegeId");
            IgnoreManagedList.Add("IsManaged");
            IgnoreManagedList.Add("CanBeChanged");
        }

        public MetadataComparer(Configuration configuration)
        {
            _configuration = configuration;
        }


        protected override void BuildComparisons(MetadataComparison parent, PropertyInfo prop, object source, object target)
        {
            //OnLogMessageRaised(new EventArgs());
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
                            case "MultiSelectPicklistAttributeMetadata":
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

                    if (IsSimpleType(type) && !IgnoreList.Any(s => parent.Name.Contains(s)))
                    {
                        // for simple types just compare values
                        if (parent.Name == "AutoNumberFormat" &&
                            (source == null || string.IsNullOrEmpty(source.ToString())) &&
                            (target == null || string.IsNullOrEmpty(target.ToString()))
                            )
                        {
                            // Ignore AutonumberFormat when null or Empty String
                        }
                        else if (_configuration.IgnoreManagedState && IgnoreManagedList.Any(s => parent.Name.Contains(s)))
                        {
                            // ignore IsManaged
                        }
                        else if (!Equals(source, target))
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
                        foreach (PropertyInfo p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public).OrderBy(property => property.Name))
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
    }
}
