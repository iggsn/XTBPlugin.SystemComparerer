using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationForms
    {
        public string Name { get; set; }

        public Entity Object { get; set; }

        public CustomizationForms(string name, Entity value)
        {
            Name = name;
            Object = value;
        }

        public CustomizationForms()
        {
        }
    }
}
