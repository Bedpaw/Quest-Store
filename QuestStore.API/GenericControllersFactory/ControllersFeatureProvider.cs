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
    public class ControllersFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var entityType in ControllersTypes.GenericControllersConfigurations.Keys)
            {
                feature.Controllers.Add(
                    typeof(GenericController<,,>).MakeGenericType(
                            entityType,
                            ControllersTypes.GenericControllersConfigurations[entityType].ResponseType,
                            ControllersTypes.GenericControllersConfigurations[entityType].RequestType)
                        .GetTypeInfo());
            }

            foreach (var entityType in ControllersTypes.LinkingControllersConfigurations.Keys)
            {
                feature.Controllers.Add(
                    typeof(LinkingGenericController<,>).MakeGenericType(
                            entityType,
                            ControllersTypes.LinkingControllersConfigurations[entityType].ResponseType)
                        .GetTypeInfo());
            }

        }
    }
}
