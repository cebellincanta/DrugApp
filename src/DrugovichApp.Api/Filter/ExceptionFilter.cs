using System.Net;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Response;
using DrugovichApp.Domain.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DrugovichApp.Api.Filter;

public class ExceptionFilter : IExceptionFilter
{
    private ILogger _logger;

    public ExceptionFilter(ILoggerFactory facotry)
    {
        _logger = facotry.CreateLogger<ExceptionFilter>();
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception?.Message, context.Exception);

        var error500 = HttpStatusCode.InternalServerError;
        var listErros = new List<ValidacaoErro>();
        
        if(context.Exception is ExceptionDrugBase drugBase)
        {
            context.ExceptionHandled = true;
            error500 = drugBase._status;
            listErros = drugBase._validacaoErro;
        }

        var result = new ErroResponse($"ERRO-{error500}", listErros);

        context.Result = new JsonResult(result)
        {
            StatusCode = (int)error500,
            ContentType = "application/json" 
        };

    }
}
