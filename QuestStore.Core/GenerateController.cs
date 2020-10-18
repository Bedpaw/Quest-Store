using System;

namespace QuestStore.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GenerateController : Attribute
    {
        public string Route { get; }

        public GenerateController(string route)
        {
            Route = route;
        }
    }
}
