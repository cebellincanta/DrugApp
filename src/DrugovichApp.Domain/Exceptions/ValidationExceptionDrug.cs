using System.Net;
using DrugovichApp.Domain.VO;

namespace DrugovichApp.Domain.Exceptions;

public class ValidationExceptionDrug : ExceptionDrugBase
{
   public ValidationExceptionDrug(IEnumerable<ValidacaoErro> validacoes) : base(HttpStatusCode.BadRequest, validacoes){}
}