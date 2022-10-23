using System.Net;
using DrugovichApp.Domain.VO;

namespace DrugovichApp.Domain.Exceptions;

public class NotFoundExcpetionDrug : ExceptionDrugBase
{
   public NotFoundExcpetionDrug(List<ValidacaoErro> validacoes) : base(HttpStatusCode.NotFound, validacoes){}

}