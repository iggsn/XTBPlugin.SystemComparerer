using System.Collections.Generic;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationRoot
    {
        public string Name { get; set; }

        public List<CustomizationEntity> Entities { get; private set; }

        public List<CustomizationForms> Forms { get; private set; }

        public CustomizationRoot()
        {
            Entities = new List<CustomizationEntity>();
            Forms = new List<CustomizationForms>();
        }
    }
}
