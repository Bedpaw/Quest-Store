using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestStore.API.GenericControllersFactory
{
    public class LinkingControllerConfiguration
    {
        public string Name { get; set; }
        public string ParentRoute { get; set; }
        public string ChildRoute { get; set; }
        public bool ReverseKeyOrder { get; set; }
    }
}
