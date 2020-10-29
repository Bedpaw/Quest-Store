using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestStore.API.GenericControllersFactory
{
    public class LinkingControllerConfiguration
    {
        public Type ResponseType { get; set; }
        public string Name { get; set; }
        public string ParentRoute { get; set; }
        public string ChildRoute { get; set; }
    }
}
