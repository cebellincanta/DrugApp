using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.VO;
using FluentValidation;
using MediatR;

namespace DrugovichApp.Application.MediatRService;

public class ValidationBehavivior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validadors;

    public ValidationBehavivior(IEnumerable<IValidator<TRequest>> validadors)
    {
        _validadors = validadors;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var valicacoes = _validadors.Select(async v => await v.ValidateAsync(context))
                                    .SelectMany(result => result.Result.Errors)
                                    .GroupBy(x => x.PropertyName)
                                    .Select(
                                        falhas =>
                                        new ValidacaoErro(falhas.Key, string.Join("|", falhas.Select(x => x.ErrorMessage)))
                                    )
                                    .Where(w => w != null)
                                    .ToList();
        if (valicacoes.Any())
        {
            throw new ValidationExceptionDrug(valicacoes);
        }
        return next();
    }
}