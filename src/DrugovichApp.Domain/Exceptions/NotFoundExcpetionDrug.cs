using System.Net;
using DrugovichApp.Domain.VO;

namespace DrugovichApp.Domain.Exceptions;

public class NotFoundExcpetionDrug : ExceptionDrugBase
{
   public NotFoundExcpetionDrug(IEnumerable<ValidacaoErro> validacoes) : base(HttpStatusCode.NotFound, validacoes){}

}