using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using QuestStore.Core;

namespace QuestStore.API.GenericControllersFactory
{
    public class GenericControllersRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType) return;

            var generateControllerAttribute = controller.ControllerType.GenericTypeArguments[0]
                .GetCustomAttribute<GenerateControllerAttribute>();

            if (generateControllerAttribute == null) return;

            var entityType = controller.ControllerType.GenericTypeArguments[0];

            controller.ControllerName = entityType.Name;
            controller.RouteValues["Controller"] = entityType.Name;
        }
    }
}
