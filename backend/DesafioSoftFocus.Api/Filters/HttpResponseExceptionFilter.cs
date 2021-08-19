using DesafioSoftFocus.Api.Exceptions;
using DesafioSoftFocus.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DesafioSoftFocus.Api.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BusinessException)
            {
                context.Result = new ObjectResult(new ErrorResponse() { Message = context.Exception.Message })
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception)
            {
                context.Result = new ObjectResult(new ErrorResponse() { Message = "Erro Interno do servidor" })
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
