using Microsoft.AspNetCore.Mvc.Filters;
using Service.Services.Abstractions;

namespace web.ActionFilters
{
    public class LogActionAttribute : ActionFilterAttribute
    {

        private readonly ILoggerService _logService;

        public LogActionAttribute(ILoggerService logService)
        {
            _logService = logService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var MethodName = context.RouteData.Values[""];

            _logService.LogInfo($"Controller: {controller} " + $"Action: {action}");
        }

    }
}
