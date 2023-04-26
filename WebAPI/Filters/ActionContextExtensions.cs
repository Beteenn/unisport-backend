using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace WebAPI.Filters
{
    public static class ActionContextExtensions
    {
        public static bool IsAnonymousAllowed(this ActionContext actionContext)
        {
            var actionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
            var allowAnonymousClass = actionDescriptor?.ControllerTypeInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            var allowAnonymousMethod = actionDescriptor?.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();

            return allowAnonymousClass != null || allowAnonymousMethod != null;
        }
    }
}
