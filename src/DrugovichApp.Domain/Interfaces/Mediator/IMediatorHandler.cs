namespace DrugovichApp.Domain.Interfaces.Repositories;

public interface IMediatorHandler<T,TReturn> where T : class
{
    Task<TReturn> SendCommandAsync(T command);
    Task<TReturn> SendQuery(T query);

}