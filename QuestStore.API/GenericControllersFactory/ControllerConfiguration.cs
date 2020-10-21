using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuestStore.API.GenericControllersFactory
{
    public class ControllerConfiguration
    {
        public Type RequestType { get; set; }
        public Type ResponseType { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
    }
}
