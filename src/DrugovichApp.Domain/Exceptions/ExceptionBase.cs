using System.Net;
using DrugovichApp.Domain.VO;

namespace DrugovichApp.Domain.Exceptions;

public  abstract class ExceptionDrugBase : Exception
{
    public HttpStatusCode _status {get; init;}
    public IEnumerable<ValidacaoErro> _validacaoErro {get; init; }

    protected ExceptionDrugBase(HttpStatusCode? status, List<ValidacaoErro>? validacaoErro) : base ()
    {
        _status = status ?? HttpStatusCode.InternalServerError;
        _validacaoErro = validacaoErro ?? new List<ValidacaoErro>();
    }
}