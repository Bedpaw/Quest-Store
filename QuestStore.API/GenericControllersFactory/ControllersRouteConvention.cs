using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using QuestStore.API.Controllers;
using QuestStore.Core;

namespace QuestStore.API.GenericControllersFactory
{
    public class ControllersRouteConvention : IControllerModelConvention
    {
        public void Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel controller)
        {
            var controllerType = controller.ControllerType;

            if (!controllerType.IsGenericType) return;

            var entityType = controllerType.GenericTypeArguments[0];

            // `2 in the name of the controller results form that it has got 2 generic parameters.
            if (controllerType.Name == nameof(LinkingGenericController<object,object>) + "`2")
            {
                controller.ControllerName =
                    ControllersTypes.LinkingControllersConfigurations[entityType].Name ?? entityType.Name + "s";

                controller.RouteValues["ParentController"] =
                    ControllersTypes.LinkingControllersConfigurations[entityType].ParentRoute ?? entityType.Name + "s";

                controller.RouteValues["ChildController"] =
                    ControllersTypes.LinkingControllersConfigurations[entityType].ChildRoute ?? entityType.Name + "s";

            }
            else
            {
                controller.ControllerName =
                    ControllersTypes.GenericControllersConfigurations[entityType].Name ?? entityType.Name + "s";

                controller.RouteValues["Controller"] =
                    ControllersTypes.GenericControllersConfigurations[entityType].Route ?? entityType.Name + "s";
            }


        }
    }
}
