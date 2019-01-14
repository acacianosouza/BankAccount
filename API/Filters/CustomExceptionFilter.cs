using Infrastructure.Http.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> logger;
        private readonly IHostingEnvironment hostingEnvironment;

        public CustomExceptionFilter(
            ILogger<CustomExceptionFilter> logger,
            IHostingEnvironment hostingEnvironment)
        {
            this.logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;

            context.HttpContext.Response.StatusCode = statusCode;

            BaseResponse<Exception> result = new BaseResponse<Exception>();

            if (hostingEnvironment.IsProduction())
            {
                result.Data = null;
                result.Errors = new System.Collections.Generic.List<ErrorResponse>
                {
                    new ErrorResponse
                    {
                        Code = statusCode,
                        Message = "Erro inesperado"
                    }
                };
            }
            else
            {
                result.Data = context.Exception;
                result.Errors = new System.Collections.Generic.List<ErrorResponse>
                {
                    new ErrorResponse
                    {
                        Code = statusCode,
                        Message = "Erro inesperado"
                    }
                };
            }

            context.Result = new JsonResult(result);
        }
    }
}