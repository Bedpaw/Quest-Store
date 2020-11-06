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
                var genericControllerType = typeof(GenericController<,,>)
                    .MakeGenericType(entityType, responseType, requestType);
                if (!feature.Controllers.Any(t => t.IsSubclassOf(genericControllerType)))
                {
                    feature.Controllers.Add(genericControllerType.GetTypeInfo());
                }
            }

            foreach (var (entityType, responseType, postResponseType) in ControllersTypes.LinkingControllers.Keys)
            {
                var linkingControllerType = typeof(LinkingGenericController<,,>)
                    .MakeGenericType(entityType, responseType, postResponseType);
                if (!feature.Controllers.Any(t => t.IsSubclassOf(linkingControllerType)))
                {
                    feature.Controllers.Add(linkingControllerType.GetTypeInfo());
                }
            }

        }
    }
}
