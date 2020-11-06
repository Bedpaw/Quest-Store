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
            var linkingControllerName = nameof(LinkingGenericController<object, object, object>) + "`3";
            if (controllerType.Name == linkingControllerName || controllerType.BaseType.Name == linkingControllerName)
            {
                controller.ControllerName = ControllersTypes.LinkingControllers[controllerArguments].Name ??
                                            controller.ControllerName;

                controller.RouteValues["ParentController"] =
                    ControllersTypes.LinkingControllers[controllerArguments].ParentRoute;

                controller.RouteValues["ChildController"] =
                    ControllersTypes.LinkingControllers[controllerArguments].ChildRoute;
            }
            else
            {
                controller.ControllerName =
                    ControllersTypes.GenericControllers[controllerArguments].Name ?? controllerArguments.Item1.Name + "s";

                controller.RouteValues["Controller"] =
                    ControllersTypes.GenericControllers[controllerArguments].Route ?? controllerArguments.Item1.Name + "s";
            }


        }
    }
}
