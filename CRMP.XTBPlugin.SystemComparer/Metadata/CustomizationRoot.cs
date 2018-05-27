﻿using System.Collections.Generic;
using System.IO;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace CRMP.XTBPlugin.SystemComparer.Metadata
{
    public class CustomizationRoot
    {
        public string Name { get; set; }

        public List<EntityMetadata> EntitiesRaw { get;  set; }

        public List<Entity> Organizations { get; set; }

        public Dictionary<string, Dictionary<string, List<Entity>>> Forms { get; set; }

        public CustomizationRoot()
        {
            Name = "Root";
            EntitiesRaw = new List<EntityMetadata>();
            Forms = new Dictionary<string, Dictionary<string, List<Entity>>>();
        }
    }
}
