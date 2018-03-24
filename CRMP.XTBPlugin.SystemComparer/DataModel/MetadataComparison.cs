using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.XTBPlugin.SystemComparer.DataModel
{
    public class MetadataComparison
    {
        public String Name { get; set; }

        public Object SourceValue { get; set; }

        public Object TargetValue { get; set; }

        public bool IsDifferent { get; set; }

        public PropertyInfo ParentProperty { get; set; }

        public List<MetadataComparison> Children { get; private set; }

        public MetadataComparison(string name, object source, object target)
            : this()
        {
            Name = name;
            SourceValue = source;
            TargetValue = target;
        }

        public MetadataComparison()
        {
            Children = new List<MetadataComparison>();
        }
    }
}
