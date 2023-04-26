using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebAPI.ViewModels;

namespace WebAPI.Filters
{
	public class ExceptionHandlerActionFilter : IExceptionFilter
	{
        public ExceptionHandlerActionFilter() { }

        public void OnException(ExceptionContext context)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel(context.Exception.Message);

            context.Result = new JsonResult(errorViewModel);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Exception = null!;
        }
    }
}
