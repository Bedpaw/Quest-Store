using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using QuestStore.API.Controllers;
using QuestStore.Core;
using QuestStore.Core.Entities;

namespace QuestStore.API.GenericControllersFactory
{
    public class GenericControllersFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var entityType in ControllersTypes.Configurations.Keys)
            {
                feature.Controllers.Add(
                    typeof(GenericController<,,>).MakeGenericType(
                            entityType,
                            ControllersTypes.Configurations[entityType].ResponseType,
                            ControllersTypes.Configurations[entityType].RequestType)
                        .GetTypeInfo());
            }
        }
    }
}
