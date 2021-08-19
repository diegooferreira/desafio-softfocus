using DesafioSoftFocus.Api.Exceptions;
using DesafioSoftFocus.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace DesafioSoftFocus.Api.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleBaseExceptionResponse(Exception ex)
        {
            IActionResult response;

            if (ex is BusinessException)
            {
                response = BadRequest(new ErrorResponse() { Message = ex.Message });
            }
            else if (ex is ArgumentException || ex is ArgumentNullException)
            {
                response = BadRequest(new ErrorResponse { Message = ex.Message });
            }
            else
            {
                var objResult = new ObjectResult(new ErrorResponse { Message = ex.Message });
                objResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = objResult;
            }

            return response;
        }
    }
}
