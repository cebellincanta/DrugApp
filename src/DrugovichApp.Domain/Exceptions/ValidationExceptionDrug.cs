using System.Net;
using DrugovichApp.Domain.VO;

namespace DrugovichApp.Domain.Exceptions;

public class ValidationExceptionDrug : ExceptionDrugBase
{
   public ValidationExceptionDrug(List<ValidacaoErro> validacoes) : base(HttpStatusCode.BadRequest, validacoes){}

}