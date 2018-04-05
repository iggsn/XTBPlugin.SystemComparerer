using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{
    public class MetadataComparison
    {
        public string Name { get; set; }

        public Type ValueType { get; set; }

        public string ValueTypeName => ValueType == null ? string.Empty : ValueType.Name;

        public object SourceValue { get; set; }

        public object TargetValue { get; set; }

        public bool IsDifferent { get; set; }

        public PropertyInfo ParentProperty { get; set; }

        public List<MetadataComparison> Children { get; private set; }

        public MetadataComparison(string name, object source, object target, Type type)
            : this()
        {
            Name = name;
            SourceValue = source;
            TargetValue = target;
            ValueType = type;
        }

        public MetadataComparison()
        {
            Children = new List<MetadataComparison>();
        }

        /// <summary>
        /// Gets the number of children that are identical in both the source and the target.
        /// </summary>
        /// <returns></returns>
        public int GetUnchangedCount()
        {
            return Children.Count(c => !c.IsDifferent);
        }

        /// <summary>
        /// Gets the number of children that exist in both the source and target, but are different.
        /// </summary>
        /// <returns></returns>
        public int GetChangedCount()
        {
            return Children.Count(c => c.IsDifferent && c.SourceValue != null && c.TargetValue != null);
        }

        /// <summary>
        /// Gets the number of children that exist solely in the target.
        /// </summary>
        /// <returns></returns>
        public int GetMissingInSourceCount()
        {
            return Children.Count(c => c.SourceValue == null);
        }

        /// <summary>
        /// Gets the number of children that exist solely in the source.
        /// </summary>
        /// <returns></returns>
        public int GetMissingInTargetCount()
        {
            return Children.Count(c => c.TargetValue == null);
        }
    }
}
