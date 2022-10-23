namespace DrugovichApp.Domain.Interfaces.Mediator;

public interface IMediatorHandler<T,TReturn> where T : class
{
    Task<TReturn> SendCommandAsync(T command);
    Task<TReturn> SendQuery(T query);

}