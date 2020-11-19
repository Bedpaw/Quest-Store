using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using QuestStore.API.Controllers;
using QuestStore.Core;

namespace QuestStore.API.GenericControllersFactory
{
    public class ControllersRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerType = controller.ControllerType;

            if (!controllerType.IsGenericType && !controllerType.BaseType.IsGenericType) return;

            var controllerArguments = controllerType.IsGenericType
                ? (controllerType.GenericTypeArguments[0],
                    controllerType.GenericTypeArguments[1], controllerType.GenericTypeArguments[2])
                : (controllerType.BaseType.GenericTypeArguments[0],
                    controllerType.BaseType.GenericTypeArguments[1], controllerType.BaseType.GenericTypeArguments[2]);

            // `3 in the name of the controller results form that it has got 3 generic parameters.
            const string linkingControllerName = nameof(LinkingGenericController<object, object, object>) + "`3";
            if (controllerType.Name == linkingControllerName || controllerType.BaseType.Name == linkingControllerName)
            {
                if (ControllersTypes.LinkingControllers.TryGetValue(controllerArguments, out var configuration))
                {
                    controller.ControllerName = configuration.Name ?? controller.ControllerName;
                    controller.RouteValues["ParentController"] = configuration.ParentRoute;
                    controller.RouteValues["ChildController"] = configuration.ChildRoute;
                }
            }
            else
            {
                if (ControllersTypes.GenericControllers.TryGetValue(controllerArguments, out var configuration))
                {
                    controller.ControllerName = configuration.Name ?? controllerArguments.Item1.Name + "s";
                    controller.RouteValues["Controller"] = configuration.Route ?? controllerArguments.Item1.Name + "s";
                }
            }


        }
    }
}
