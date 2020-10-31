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
            foreach (var (entityType, responseType, requestType) in ControllersTypes.GenericControllers.Keys)
            {
                feature.Controllers.Add(
                    typeof(GenericController<,,>)
                        .MakeGenericType(entityType, responseType, requestType)
                        .GetTypeInfo());
            }

            foreach (var (entityType, responseType, postResponseType) in ControllersTypes.LinkingControllers.Keys)
            {
                feature.Controllers.Add(
                    typeof(LinkingGenericController<,,>)
                        .MakeGenericType(entityType, responseType, postResponseType)
                        .GetTypeInfo());
            }

        }
    }
}
