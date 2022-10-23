
using DrugovichApp.Domain.Interfaces.Mediator;
using MediatR;

namespace DrugovichApp.Application.MediatRService;

public class MediatRHandler<T, TReturn> : IMediatorHandler<T, TReturn> where T : class
{
    private readonly IMediator _mediator;

    public MediatRHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TReturn> SendCommandAsync(T command)
    {
        return (TReturn?)await _mediator.Send(command);
    }

    public async Task<TReturn> SendQuery(T query)
    {
        return (TReturn?)await _mediator.Send(query);
    }
}
