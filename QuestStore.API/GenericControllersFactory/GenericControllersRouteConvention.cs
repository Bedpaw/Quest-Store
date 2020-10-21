using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using QuestStore.Core;

namespace QuestStore.API.GenericControllersFactory
{
    public class GenericControllersRouteConvention : IControllerModelConvention
    {
        public void Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType) return;

            var entityType = controller.ControllerType.GenericTypeArguments[0];

            controller.ControllerName =
                ControllersTypes.Configurations[entityType].Name ?? entityType.Name + "s";

            controller.RouteValues["Controller"] =
                ControllersTypes.Configurations[entityType].Route ?? entityType.Name + "s";

        }
    }
}
